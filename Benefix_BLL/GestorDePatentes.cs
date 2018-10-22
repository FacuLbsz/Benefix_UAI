using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDePatentes
{

    private GestorDeDigitoVerificador gestorDeDigitoVerificador;
    private BaseDeDatos baseDeDatos;
    private static GestorDePatentes instancia;

    private GestorDePatentes()
    {
        gestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDePatentes ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDePatentes();
        }

        return instancia;
    }

    //SDC Modificar parametro de entrada como PatenteUsuario
    public int AsignarAUnUsuario(PatenteUsuario patenteUsuario)
    {
        var usuario = patenteUsuario.usuario.identificador.ToString();
        var patente = patenteUsuario.patente.identificador.ToString();

        var esPermisivo = patenteUsuario.esPermisivo ? "1" : "0";

        var digitoVH = gestorDeDigitoVerificador.ObtenerDigitoVH(new List<string>() { esPermisivo, patente, usuario });

        var datataTable = baseDeDatos.ConsultarBase(String.Format("DELETE FROM PATENTEUSUARIO  WHERE Patente_idPatente = {0} AND Usuario_idUsuario  = {1}", patente, usuario));
        var registros = 0;
        if (datataTable.Rows.Count > 0)
        {
            registros = baseDeDatos.ModificarBase(String.Format("UPDATE PATENTEUSUARIO SET esPermisiva = {0}, digitoVerificadorH = '{0}'", esPermisivo, digitoVH));
        }
        else
        {
            registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO PATENTEUSUARIO  (esPermisiva  ,Patente_idPatente  ,Usuario_idUsuario  ,digitoVerificadorH)  VALUES  ({0}  ,{1}  ,{2} ,'{3}')", esPermisivo, patente, usuario, digitoVH));
        }

        gestorDeDigitoVerificador.ModificarDigitoVV("PATENTEUSUARIO");

        return registros;
    }

    public int DesasignarAUnUsuario(Usuario usuario, Patente patente)
    {

        var registros = baseDeDatos.ModificarBase(String.Format("DELETE FROM PATENTEUSUARIO  WHERE Patente_idPatente = {0} AND Usuario_idUsuario  = {1}", patente, usuario));
        gestorDeDigitoVerificador.ModificarDigitoVV("PATENTEUSUARIO");

        return registros;
    }

    public List<Patente> ObtenerPatentes()
    {
        var dataTable = baseDeDatos.ConsultarBase("SELECT * FROM PATENTE");
        List<Patente> patentes = new List<Patente>();
        foreach (DataRow row in dataTable.Rows)
        {
            Patente patente = new Patente();

            patente.identificador = Convert.ToInt32(row["idPatente"]);
            patente.nombre = Convert.ToString(row["nombre"]);

            patentes.Add(patente);

        }
        return patentes;
    }

    //SDC modificar por ObtenerPatentesNoAsignadasAUnUsuario
    public List<Patente> ObtenerPatentesNoAsignadasAUnUsuario(Usuario usuario)
    {
        var dataTable = baseDeDatos.ConsultarBase(String.Format("Select * from Patente where patente.idPatente not in(SELECT PATENTE.idPatente FROM PATENTE inner join patenteusuario on patente.idPatente = patenteusuario.idPatente where patenteusuario.Usuario_idUsuario = {0})", usuario.identificador));
        List<Patente> patentes = new List<Patente>();

        foreach (DataRow row in dataTable.Rows)
        {
            Patente patente = new Patente();

            patente.identificador = Convert.ToInt32(row["idPatente"]);
            patente.nombre = Convert.ToString(row["nombre"]);

            patentes.Add(patente);

        }
        return patentes;
    }

    //SDC Modificar parametro de salida como Lista de PatenteUsuario
    public List<PatenteUsuario> ObtenerPatentesParaUnUsuario(Usuario usuario)
    {

        var dataTable = baseDeDatos.ConsultarBase(String.Format("select PATENTE.nombre, patenteusuario.esPermisiva, patenteusuario.Patente_idPatente,patenteusuario.Usuario_idUsuario from patenteusuario INNER JOIN PATENTE on patenteusuario.Patente_idPatente = patente.idPatente WHERE patenteusuario.Usuario_idUsuario = {0}", usuario.identificador));
        List<PatenteUsuario> patenteUsuarios = new List<PatenteUsuario>();
        foreach (DataRow row in dataTable.Rows)
        {
            PatenteUsuario patenteUsuario = new PatenteUsuario();

            patenteUsuario.patente = new Patente() { identificador = Convert.ToInt32(row["Patente_idPatente"]), nombre = Convert.ToString(row["nombre"]) };
            patenteUsuario.usuario = new Usuario() { identificador = Convert.ToInt32(row["Usuario_idUsuario"]) };
            patenteUsuario.esPermisivo = Convert.ToBoolean(row["esPermisiva"]);

            patenteUsuarios.Add(patenteUsuario);

        }
        return patenteUsuarios;
    }

    public int VerificarPatenteEscencial(Patente patente)
    {
        var cantidadDeAsignacionesAUsuario = baseDeDatos.ConsultarBase(String.Format("select * FROM PATENTEUSUARIO WHERE PATENTEUSUARIO.Patente_idPatente = {0} AND esPermisiva = 1", patente.identificador)).Rows.Count;

        if (cantidadDeAsignacionesAUsuario > 1)
        {
            return 1;
        }

        var familiasPatenteDataTable = baseDeDatos.ConsultarBase(String.Format("select * FROM FAMILIAPATENTE WHERE FAMILIAPATENTE.Patente_idPatente = {0}", patente.identificador));

        if(cantidadDeAsignacionesAUsuario == 1 && familiasPatenteDataTable.Rows.Count == 0)
        {
            return 0;
        }

        int usuariosConEsaPatenteSegunFamilia = 0;
        foreach (DataRow familiasPatente in familiasPatenteDataTable.Rows)
        {
            usuariosConEsaPatenteSegunFamilia = usuariosConEsaPatenteSegunFamilia + baseDeDatos.ConsultarBase(String.Format("select * FROM FAMILIAUSUARIO WHERE FAMILIAUSUARIO.Familia_idFamilia = {0}", familiasPatente["Familia_idFamilia"].ToString())).Rows.Count;
        }
        
        return usuariosConEsaPatenteSegunFamilia == 1 ? 1 : 0;
    }

}