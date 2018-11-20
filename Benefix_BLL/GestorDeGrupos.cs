using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDeGrupos
{

    private static GestorDeGrupos instancia;
    private GestorDeBeneficios gestorDeBeneficios;
    private BaseDeDatos baseDeDatos;

    private GestorDeGrupos()
    {
        gestorDeBeneficios = GestorDeBeneficios.ObtenerInstancia();
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDeGrupos ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeGrupos();
        }

        return instancia;
    }

    public int AsignarBeneficio(Beneficio beneficio, Grupo grupo)
    {

        int periodoActual = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        DataTable relacionAActualizarSiExiste = baseDeDatos.ConsultarBase(String.Format("select * from grupobeneficio where Grupo_idGrupo = {0} and Beneficio_idBeneficio = {1} and periodoFin = {2}", grupo.identificador, beneficio.identificador, periodoActual));

        var idRelacion = 0;
        foreach (DataRow relacionAActualizar in relacionAActualizarSiExiste.Rows)
        {
            idRelacion = Convert.ToInt32(relacionAActualizar["idGrupoBeneficio"]);
        }

        if (idRelacion > 0)
        {
            var registros = baseDeDatos.ModificarBase(String.Format("update grupobeneficio set periodoFin is null where idGrupoBeneficio = {1}", idRelacion));
            return registros;
        }
        else
        {
            var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO grupobeneficio(periodoInicio, Grupo_idGrupo, Beneficio_idBeneficio) VALUES({0},{1},{2})", periodoActual, grupo.identificador, beneficio.identificador));
            return registros;
        }
    }

    public List<Grupo> ConsultarGrupos()
    {
        DataTable datable = baseDeDatos.ConsultarBase("SELECT * FROM GRUPO WHERE habilitado = 1");
        List<Grupo> grupos = new List<Grupo>();
        foreach (DataRow grupoRow in datable.Rows)
        {
            Grupo grupo = new Grupo() { identificador = Convert.ToInt32(grupoRow["idGrupo"]), nombre = Convert.ToString(grupoRow["nombre"]) };

            DataTable grupobeneficioTable = baseDeDatos.ConsultarBase(String.Format("SELECT beneficio.idBeneficio, beneficio.nombre FROM grupobeneficio INNER JOIN beneficio on grupobeneficio.Beneficio_idBeneficio = beneficio.idBeneficio WHERE Grupo_idGrupo = {0}", grupo.identificador));
            foreach (DataRow grupobeneficioRow in grupobeneficioTable.Rows)
            {
                Beneficio beneficio = new Beneficio() { identificador = Convert.ToInt32(grupobeneficioRow["idBeneficio"]), nombre = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(grupobeneficioRow["nombre"])) };
                grupo.beneficiosAsignados.Add(beneficio);
            }

            grupos.Add(grupo);
        }
        return grupos;
    }

    public int CrearGrupo(Grupo grupo)
    {

        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM GRUPO WHERE nombre = '{0}'", grupo.nombre)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }

        var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO GRUPO (nombre,habilitado) VALUES ('{0}',1)", grupo.nombre));

        return registros;
    }

    public int DesasignarBeneficio(Beneficio beneficio, Grupo grupo)
    {
        DataTable relacionAEliminarTable = baseDeDatos.ConsultarBase(String.Format("select * from grupobeneficio where Grupo_idGrupo = {0} and Beneficio_idBeneficio = {1} and periodoFin is null", grupo.identificador, beneficio.identificador));

        var idRelacion = 0;
        foreach (DataRow relacionAEliminar in relacionAEliminarTable.Rows)
        {
            idRelacion = Convert.ToInt32(relacionAEliminar["idGrupoBeneficio"]);
        }

        int periodoFin = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        var registros = baseDeDatos.ModificarBase(String.Format("update grupobeneficio set periodoFin = {0} where idGrupoBeneficio = {1}", periodoFin, idRelacion));
        return registros;
    }

    public List<EquipoGrupo> ObtenerAsignacionDeGruposDeUnEquipoEnUnPeriodo(Equipo equipo, int periodo)
    {

        return null;
    }

    public int ModificarGrupo(Grupo grupo)
    {
        Grupo grupoViejo = ObtenerGrupoBD(grupo.identificador);

        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM BENEFICIO WHERE nombre = '{0}'", grupo.nombre)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }

        String set = "";
        if (grupo.nombre != null && grupoViejo.nombre != grupo.nombre)
        {
            set = String.Format(" nombre = '{0}' ", grupo.nombre);
        }

        var registros = baseDeDatos.ModificarBase(String.Format("UPDATE BENEFICIO SET {0} WHERE idGrupo = {1}", set, grupo.identificador));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se modifico el grupo " + grupo.identificador, criticidad = 2, funcionalidad = "ADMINISTRACION DE GRUPOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return registros;
    }

    private Grupo ObtenerGrupoBD(int identificador)
    {
        DataTable nombreGrupoTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM GRUPO WHERE IDgrupo = {0}", identificador));

        foreach (DataRow gruporow in nombreGrupoTable.Rows)
        {
            return PopularGrupoDesdeBD(gruporow);
        }

        return null;
    }

    private Grupo PopularGrupoDesdeBD(DataRow grupoRow)
    {
        Grupo grupo = new Grupo();
        grupo.identificador = Convert.ToInt32(grupoRow["idGrupo"]);
        grupo.nombre = Convert.ToString(grupoRow["nombre"]);
        return grupo;
    }

    public int EliminarGrupo(Grupo grupo)
    {

        var grupoOBtenido = ObtenerGrupoBD(grupo.identificador);
        var nombreGrupo = grupoOBtenido.nombre;

        DataTable beneficiosAsignados = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM GRUPOBENEFICIO WHERE GRUPO_IDGRUPO = {0} AND PERIODOFIN = NULL", grupo.identificador));

        int periodoFin = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        foreach (DataRow beneficioAsignado in beneficiosAsignados.Rows)
        {
            var relacionAFinalizar = Convert.ToInt32(beneficioAsignado["idGrupoBeneficio"]);
            baseDeDatos.ModificarBase(String.Format("update grupobeneficio set periodoFin = {0} where idGrupoBeneficio = {1}", periodoFin, relacionAFinalizar));

        }

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se elimino el grupo " + grupo.identificador, criticidad = 1, funcionalidad = "ADMINISTRACION DE GRUPOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        nombreGrupo = GestorDeEncriptacion.EncriptarAes(nombreGrupo + " Eliminado el dia: " + DateTime.Now.ToString("yyyy-MM-dd"));
        var registros = baseDeDatos.ModificarBase(String.Format("UPDATE GRUPO SET habilitado = 0, nombre = '{0}' WHERE idGrupo = {1}", nombreGrupo, grupo.identificador));

        return registros;
    }
}