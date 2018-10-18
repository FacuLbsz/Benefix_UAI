using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorSistema
{

    private static GestorSistema instancia;
    public GestorDeUsuarios m_GestorDeUsuarios;
    public GestorDePatentes m_GestorDePatentes;
    public GestorIdioma m_GestorIdioma;

    //SDC Añadir relacion
    private GestorDeEncriptacion gestorDeEncriptacion;

    //SDC Relacion con gestor de digito verificador
    private GestorDeDigitoVerificador gestorDeDigitoVerificador;

    private BaseDeDatos baseDeDatos;

    private GestorSistema()
    {
        gestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
        gestorDeEncriptacion = GestorDeEncriptacion.ObtenerInstancia();
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorSistema ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorSistema();
        }

        return instancia;
    }

    public int ConsultarIntegridadDeBaseDeDatos()
    {

        var map = new Dictionary<String, List<String>>();
        map.Add("BITACORA", new List<String>() { "criticidad", "descripcion", "fecha", "funcionalidad", "Usuario_idUsuario" });
        //map.Add("USUARIO", new List<String>() { "nombreUsuario", "nombre", "apellido", "contrasena" });
        map.Add("PATENTEUSUARIO", new List<String>() { "esPermisiva", "Patente_idPatente", "Usuario_idUsuario" });
        map.Add("FAMILIAPATENTE", new List<String>() { "Patente_idPatente", "Familia_idFamilia" });
        map.Add("BENEFICIO", new List<String>() { "descripcion", "puntaje" });
        //SDC Modificar campos que contendran DVH en la tabla EVALUACION
        map.Add("EVALUACION", new List<String>() { "puntaje", "periodo" });


        foreach (String tabla in map.Keys)
        {
            if (ConsultaIntegridadDeUnaTabla(tabla, map[tabla]) == 0)
            {
                return 0;
            }
        }
        return 1;
    }

    private int ConsultaIntegridadDeUnaTabla(String tabla, List<String> atributos)
    {

        DataTable dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM {0}", tabla));

        String digitosVHBitacora = "";
        foreach (DataRow eventoBitacora in dataTable.Rows)
        {
            List<String> argumentos = new List<String>();
            foreach (String atributo in atributos)
            {
                argumentos.Add(Convert.ToString(eventoBitacora[atributo]));
            }

            var digitoVH = gestorDeDigitoVerificador.ObtenerDigitoVH(argumentos);

            if (!digitoVH.Equals(Convert.ToString(eventoBitacora["digitoVerificadorH"])))
            {
                return 0;
            }

            digitosVHBitacora = digitosVHBitacora + digitoVH;
        }

        if (digitosVHBitacora.Length > 0)
        {
            dataTable = baseDeDatos.ConsultarBase(String.Format("SELECT digitoVerificador FROM digitoverificadorvertical WHERE tabla = '{0}'", tabla));

            if (dataTable.Rows.Count > 0)
            {
                if (!Convert.ToString(dataTable.Rows[0]["digitoVerificador"]).Equals(gestorDeEncriptacion.EncriptarMD5(digitosVHBitacora)))
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        return 1;
    }

    public int ModificarStringDeConexion(String stringDeConexion)
    {

        return 0;
    }

    private Object ObtenerBaseDeDatos()
    {

        return null;
    }

    private int Particionar(int cantidadVolumenes)
    {

        return 0;
    }

    public int RealizarBackup(String rutaDestino, int cantidadVolumenes)
    {

        return 0;
    }

    public int RealizarRestore(String rutaOrigen)
    {

        return 0;
    }

    private int RestaurarBackup(String rutaOrigen)
    {

        return 0;
    }

    private int ValidarRutaDestino(String rutaDestino)
    {

        return 0;
    }

    private int ValidarRutaOrigen()
    {

        return 0;
    }

}