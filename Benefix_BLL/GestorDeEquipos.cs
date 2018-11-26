using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDeEquipos
{

    private static GestorDeEquipos instancia;
    private GestorDeUsuarios gestorDeUsuarios;
    private GestorDeGrupos gestorDeGrupos;
    private BaseDeDatos baseDeDatos;


    private GestorDeEquipos()
    {
        gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();
        gestorDeGrupos = GestorDeGrupos.ObtenerInstancia();
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDeEquipos ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeEquipos();
        }

        return instancia;
    }

    public int AsignarCoordinador(Usuario empleado, Equipo equipo)
    {
        return baseDeDatos.ModificarBase(String.Format("update equipo set coordinador = {0} where idEquipo = {1}", empleado.identificador, equipo.identificador));
    }

    public int AsignarEmpleado(Usuario empleado, Equipo equipo)
    {
        int periodoActual = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        DataTable relacionAActualizarSiExiste = baseDeDatos.ConsultarBase(String.Format("select * from equipoempleado where Usuario_idUsuario = {0} and Equipo_idEquipo = {1} and periodoFin = {2}", empleado.identificador, empleado.identificador, periodoActual));

        var idRelacion = 0;
        foreach (DataRow relacionAActualizar in relacionAActualizarSiExiste.Rows)
        {
            idRelacion = Convert.ToInt32(relacionAActualizar["idEquipoEmpleado"]);
        }

        if (idRelacion > 0)
        {
            var registros = baseDeDatos.ModificarBase(String.Format("update equipoempleado set periodoFin is null where idEquipoEmpleado = {1}", idRelacion));
            return registros;
        }
        else
        {
            var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO equipoempleado (periodoInicio, Equipo_idEquipo, Usuario_idUsuario) VALUES({0},{1},{2})", periodoActual, equipo.identificador, empleado.identificador));
            return registros;
        }
    }

    public int AsignarGrupo(Grupo grupo, Equipo equipo)
    {

        int periodoActual = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        DataTable relacionAActualizarSiExiste = baseDeDatos.ConsultarBase(String.Format("select * from equipogrupo where Grupo_idGrupo = {0} and Equipo_idEquipo = {1} and periodoFin = {2}", grupo.identificador, equipo.identificador, periodoActual));

        var idRelacion = 0;
        foreach (DataRow relacionAActualizar in relacionAActualizarSiExiste.Rows)
        {
            idRelacion = Convert.ToInt32(relacionAActualizar["idEquipoGrupo"]);
        }

        if (idRelacion > 0)
        {
            var registros = baseDeDatos.ModificarBase(String.Format("update equipogrupo set periodoFin is null where idEquipoGrupo = {1}", idRelacion));
            return registros;
        }
        else
        {
            var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO equipogrupo (periodoInicio, Equipo_idEquipo, Grupo_idGrupo) VALUES({0},{1},{2})", periodoActual, equipo.identificador, grupo.identificador));
            return registros;
        }
    }

    public List<Equipo> ConsultarEquipos()
    {
        DataTable datable = baseDeDatos.ConsultarBase("SELECT * FROM EQUIPO WHERE habilitado = 1");
        List<Equipo> equipos = new List<Equipo>();
        foreach (DataRow equipoRow in datable.Rows)
        {
            Equipo equipo = new Equipo() { identificador = Convert.ToInt32(equipoRow["idEquipo"]), nombre = Convert.ToString(equipoRow["nombre"]) };

            DataTable equipogrupoTable = baseDeDatos.ConsultarBase(String.Format("select grupo.idGrupo, grupo.nombre from equipogrupo inner join grupo on grupo.idGrupo = equipogrupo.Grupo_idGrupo where Equipo_idEquipo = {0} and grupo.habilitado = 1 and equipogrupo.periodoFin is null", equipo.identificador));
            foreach (DataRow equipogrupoRow in equipogrupoTable.Rows)
            {
                Grupo grupo = new Grupo() { identificador = Convert.ToInt32(equipogrupoRow["idGrupo"]), nombre = Convert.ToString(equipogrupoRow["nombre"]) };
                equipo.gruposAsignados.Add(grupo);
            }

            DataTable equipoobjetivoTable = baseDeDatos.ConsultarBase(String.Format("select objetivo.idObjetivo, objetivo.nombre from equipoobjetivo inner join objetivo on objetivo.idObjetivo = equipoobjetivo.Objetivo_idObjetivo where Equipo_idEquipo = {0} and objetivo.habilitado = 1 and equipoobjetivo.periodoFin is null", equipo.identificador));
            foreach (DataRow equipoobjetivo in equipoobjetivoTable.Rows)
            {
                Objetivo objetivo = new Objetivo() { identificador = Convert.ToInt32(equipoobjetivo["idObjetivo"]), nombre = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(equipoobjetivo["nombre"])) };
                equipo.objetivosAsignados.Add(objetivo);
            }

            DataTable equipoempleadoTable = baseDeDatos.ConsultarBase(String.Format("select usuario.idUsuario, usuario.nombreUsuario from equipoempleado inner join usuario on usuario.idUsuario = equipoempleado.Usuario_idUsuario where equipoempleado.Equipo_idEquipo = {0} and usuario.habilitado = 1 and equipoempleado.periodoFin is null", equipo.identificador));
            foreach (DataRow equipoEmpleado in equipoempleadoTable.Rows)
            {
                Usuario usuario = new Usuario() { identificador = Convert.ToInt32(equipoEmpleado["idUsuario"]), nombreUsuario = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(equipoEmpleado["nombreUsuario"])) };
                equipo.usuariosAsignados.Add(usuario);
            }

            if (Convert.ToString(equipoRow["coordinador"]).Length != 0)
            {
                DataTable coordinadorTable = baseDeDatos.ConsultarBase(String.Format("select * from Usuario where idUsuario = {0}", equipoRow["coordinador"]));
                foreach (DataRow coordinadorRow in coordinadorTable.Rows)
                {
                    Usuario usuario = new Usuario() { identificador = Convert.ToInt32(coordinadorRow["idUsuario"]), nombre = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(coordinadorRow["nombreUsuario"])) };
                    equipo.coordinador = usuario;
                }
            }

            equipos.Add(equipo);
        }
        return equipos;
    }

    public int AsignarObjetivo(Objetivo objetivo, Equipo equipo)
    {
        int periodoActual = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        DataTable relacionAActualizarSiExiste = baseDeDatos.ConsultarBase(String.Format("select * from equipoobjetivo where Objetivo_idObjetivo = {0} and Equipo_idEquipo = {1} and periodoFin = {2}", objetivo.identificador, equipo.identificador, periodoActual));

        var idRelacion = 0;
        foreach (DataRow relacionAActualizar in relacionAActualizarSiExiste.Rows)
        {
            idRelacion = Convert.ToInt32(relacionAActualizar["idEquipoObjetivo"]);
        }

        if (idRelacion > 0)
        {
            var registros = baseDeDatos.ModificarBase(String.Format("update equipoobjetivo set periodoFin is null where idEquipoObjetivo = {1}", idRelacion));
            return registros;
        }
        else
        {
            var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO equipoobjetivo (periodoInicio, Equipo_idEquipo, Objetivo_idObjetivo) VALUES({0},{1},{2})", periodoActual, equipo.identificador, objetivo.identificador));
            return registros;
        }
    }

    public int DesasignarObjetivo(Objetivo objetivo, Equipo equipo)
    {
        DataTable relacionAEliminarTable = baseDeDatos.ConsultarBase(String.Format("select * from equipoobjetivo where Equipo_idEquipo = {0} and Objetivo_idObjetivo = {1} and periodoFin is null", equipo.identificador, objetivo.identificador));

        var idRelacion = 0;
        foreach (DataRow relacionAEliminar in relacionAEliminarTable.Rows)
        {
            idRelacion = Convert.ToInt32(relacionAEliminar["idEquipoObjetivo"]);
        }

        DataTable evaluacionesDeLaRelacion = baseDeDatos.ConsultarBase(String.Format("select * from Evaluacion where EquipoObjetivo_idEquipoObjetivo = {0} ORDER BY periodo DESC", idRelacion));

        if (evaluacionesDeLaRelacion.Rows.Count == 0)
        {
            return baseDeDatos.ModificarBase(String.Format("DELETE FROM equipoobjetivo where idEquipoObjetivo = {0}", idRelacion));
        }
        else
        {
            int periodoFin = Convert.ToInt32(evaluacionesDeLaRelacion.Rows[0]["periodo"]);
            var registros = baseDeDatos.ModificarBase(String.Format("update equipoobjetivo set periodoFin = {0} where idEquipoObjetivo = {1}", periodoFin, idRelacion));
            return registros;
        }
    }

    public List<Equipo> ConsultarEquiposDeUnEmpleadoPorPeriodo(Usuario empleado, int periodo)
    {
        var datable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM EQUIPO INNER JOIN equipoempleado ON EQUIPO.IDEQUIPO = equipoempleado.Equipo_idEquipo WHERE equipoempleado.Usuario_idUsuario = {0} AND (periodoFin is null or periodoFin >= {1}) AND periodoInicio <= {1}", empleado.identificador, periodo));
        List<Equipo> equipos = new List<Equipo>();
        foreach (DataRow equipoRow in datable.Rows)
        {
            Equipo equipo = new Equipo() { identificador = Convert.ToInt32(equipoRow["idEquipo"]), nombre = Convert.ToString(equipoRow["nombre"]) };
            equipos.Add(equipo);
        }
        return equipos;
    }

    public int CrearEquipo(Equipo equipo)
    {

        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM EQUIPO WHERE nombre = '{0}'", equipo.nombre)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }

        var registros = baseDeDatos.ModificarBase(String.Format("INSERT INTO EQUIPO (nombre,habilitado) VALUES ('{0}',1)", equipo.nombre));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se crea el equipo " + equipo.nombre, criticidad = 1, funcionalidad = "ADMINISTRACION DE EQUIPOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return registros;
    }

    public int DesasignarEmpleado(Usuario empleado, Equipo equipo)
    {

        DataTable relacionAEliminarTable = baseDeDatos.ConsultarBase(String.Format("select * from equipoempleado where Equipo_idEquipo = {0} and Usuario_idUsuario = {1} and periodoFin is null", equipo.identificador, empleado.identificador));

        var idRelacion = 0;
        foreach (DataRow relacionAEliminar in relacionAEliminarTable.Rows)
        {
            idRelacion = Convert.ToInt32(relacionAEliminar["idEquipoEmpleado"]);
        }

        int periodoFin = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        var registros = baseDeDatos.ModificarBase(String.Format("update equipoempleado set periodoFin = {0} where idEquipoEmpleado = {1}", periodoFin, idRelacion));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se desasigna el empleado " + empleado.identificador + " al equipo " + equipo.identificador, criticidad = 1, funcionalidad = "ADMINISTRACION DE EQUIPOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return registros;
    }

    public int DesasignarGrupo(Grupo grupo, Equipo equipo)
    {

        DataTable relacionAEliminarTable = baseDeDatos.ConsultarBase(String.Format("select * from equipogrupo where Equipo_idEquipo = {0} and Grupo_idGrupo = {1} and periodoFin is null", equipo.identificador, grupo.identificador));

        var idRelacion = 0;
        foreach (DataRow relacionAEliminar in relacionAEliminarTable.Rows)
        {
            idRelacion = Convert.ToInt32(relacionAEliminar["idEquipoGrupo"]);
        }

        int periodoFin = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        var registros = baseDeDatos.ModificarBase(String.Format("update equipogrupo set periodoFin = {0} where idEquipoGrupo = {1}", periodoFin, idRelacion));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se desasigna el grupo " + grupo.identificador + " al equipo " + equipo.identificador, criticidad = 1, funcionalidad = "ADMINISTRACION DE EQUIPOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return registros;
    }

    public List<Equipo> ObtenerEquiposPorCoordinador(Usuario empleado)
    {
        List<Equipo> equipos = new List<Equipo>();
        var equiposACargo = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM Equipo WHERE coordinador = {0}", empleado.identificador));

        foreach (DataRow equipoRow in equiposACargo.Rows)
        {
            Equipo equipo = new Equipo() { identificador = Convert.ToInt32(equipoRow["idEquipo"]), nombre = Convert.ToString(equipoRow["nombre"]), habilitado = Convert.ToBoolean(equipoRow["habilitado"]) };

            DataTable equipoempleadoTable = baseDeDatos.ConsultarBase(String.Format("select usuario.idUsuario, usuario.nombreUsuario from equipoempleado inner join usuario on usuario.idUsuario = equipoempleado.Usuario_idUsuario where equipoempleado.Equipo_idEquipo = {0} and usuario.habilitado = 1 and equipoempleado.periodoFin is null", equipo.identificador));
            foreach (DataRow equipoEmpleado in equipoempleadoTable.Rows)
            {
                Usuario usuario = new Usuario() { identificador = Convert.ToInt32(equipoEmpleado["idUsuario"]), nombreUsuario = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(equipoEmpleado["nombreUsuario"])) };
                equipo.usuariosAsignados.Add(usuario);
            }
            equipos.Add(equipo);
        }

        return equipos;
    }

    private Equipo ObtenerEquipoBD(int identificador)
    {
        DataTable nombreEquipoTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM Equipo WHERE IDequipo = {0}", identificador));

        foreach (DataRow equiporow in nombreEquipoTable.Rows)
        {
            return PopularEquipoDesdeBD(equiporow);
        }

        return null;
    }

    private Equipo PopularEquipoDesdeBD(DataRow equipoRow)
    {
        Equipo equipo = new Equipo();
        equipo.identificador = Convert.ToInt32(equipoRow["idEquipo"]);
        equipo.nombre = Convert.ToString(equipoRow["nombre"]);
        return equipo;
    }

    public int ModificarEquipo(Equipo equipo)
    {
        Equipo equipoViejo = ObtenerEquipoBD(equipo.identificador);

        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM EQUIPO WHERE nombre = '{0}'", equipo.nombre)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }

        String set = "";
        if (equipo.nombre != null && equipoViejo.nombre != equipo.nombre)
        {
            set = String.Format(" nombre = '{0}' ", equipo.nombre);
        }

        var registros = baseDeDatos.ModificarBase(String.Format("UPDATE EQUIPO SET {0} WHERE idEquipo = {1}", set, equipo.identificador));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se modifico el equipo " + equipo.identificador, criticidad = 2, funcionalidad = "ADMINISTRACION DE EQUIPOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return registros;
    }

    public int EliminarEquipo(Equipo equipo)
    {

        var equipoOBtenido = ObtenerEquipoBD(equipo.identificador);
        var nombreEquipo = equipoOBtenido.nombre;

        DataTable gruposAsignados = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM equipogrupo WHERE Equipo_idEquipo = {0} AND PERIODOFIN = NULL", equipo.identificador));

        int periodoFin = Convert.ToInt32(DateTime.Now.ToString("yyyyMM"));
        foreach (DataRow grupoAsignado in gruposAsignados.Rows)
        {
            var relacionAFinalizar = Convert.ToInt32(grupoAsignado["idEquipoGrupo"]);
            baseDeDatos.ModificarBase(String.Format("update equipogrupo set periodoFin = {0} where idEquipoGrupo = {1}", periodoFin, relacionAFinalizar));

        }

        DataTable objetivosAsignados = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM equipoobjetivo WHERE Equipo_idEquipo = {0} AND PERIODOFIN = NULL", equipo.identificador));

        foreach (DataRow objetivoAsignado in objetivosAsignados.Rows)
        {
            var relacionAFinalizar = Convert.ToInt32(objetivoAsignado["idEquipoObjetivo"]);
            baseDeDatos.ModificarBase(String.Format("update equipoobjetivo set periodoFin = {0} where idEquipoObjetivo = {1}", periodoFin, relacionAFinalizar));

        }

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se elimino el equipo " + equipo.identificador, criticidad = 1, funcionalidad = "ADMINISTRACION DE EQUIPOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        nombreEquipo = GestorDeEncriptacion.EncriptarAes(nombreEquipo + " Eliminado el dia: " + DateTime.Now.ToString("yyyy-MM-dd"));
        var registros = baseDeDatos.ModificarBase(String.Format("UPDATE EQUIPO SET habilitado = 0, nombre = '{0}' WHERE idEquipo = {1}", nombreEquipo, equipo.identificador));

        return registros;
    }

}