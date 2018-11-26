using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDeObjetivos
{

    private static GestorDeObjetivos instancia;
    public GestorDeEncriptacion m_GestorDeEncriptacion;
    private GestorDeDigitoVerificador gestorDeDigitoVerificador;
    private BaseDeDatos baseDeDatos;

    private GestorDeObjetivos()
    {
        gestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDeObjetivos ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeObjetivos();
        }

        return instancia;
    }

    public List<EquipoObjetivo> ConsultarObjetivosAsignadosAUnEquipoEnUnPeriodo(Equipo equipo, int periodo)
    {
        var equipoObjetivosAsignados = baseDeDatos.ConsultarBase(String.Format("SELECT EQUIPOOBJETIVO.idEquipoObjetivo, equipoobjetivo.periodoFin, equipoobjetivo.periodoInicio, EQUIPO.idEquipo, EQUIPO.nombre AS NOMBREEQUIPO, EQUIPO.HABILITADO AS equipoHabilitado, OBJETIVO.HABILITADO AS objetivoHabilitado, OBJETIVO.idObjetivo, OBJETIVO.nombre AS NOMBREOBJETIVO, OBJETIVO.puntaje FROM EQUIPOOBJETIVO INNER JOIN EQUIPO ON EQUIPO.IDEQUIPO = equipoobjetivo.Equipo_idEquipo INNER JOIN OBJETIVO ON OBJETIVO.IDOBJETIVO = equipoobjetivo.Objetivo_idObjetivo WHERE Equipo_idEquipo = {0} AND (periodoFin is null or periodoFin >= {1})  AND periodoInicio <= {1}", equipo.identificador, periodo));
        List<EquipoObjetivo> equipoObjetivos = new List<EquipoObjetivo>();
        if (equipoObjetivosAsignados.Rows.Count > 0)
        {
            foreach (DataRow objetivorow in equipoObjetivosAsignados.Rows)
            {
                equipoObjetivos.Add(PopularEquipoObjetivoDesdeBD(objetivorow));
            }
        }
        return equipoObjetivos;
    }

    public int CrearObjetivo(Objetivo objetivo)
    {
        var nombre = objetivo.nombre;
        objetivo.nombre = GestorDeEncriptacion.EncriptarAes(objetivo.nombre);
        var puntaje = GestorDeEncriptacion.EncriptarAes(objetivo.puntaje.ToString());

        if (baseDeDatos.ConsultarBase(String.Format("SELECT * FROM OBJETIVO WHERE nombre = '{0}'", objetivo.nombre)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }


        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("INSERT INTO OBJETIVO (descripcion,nombre,puntaje,habilitado) VALUES ('{0}','{1}','{2}',1)", objetivo.descripcion, objetivo.nombre, puntaje));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se creo el objetivo " + nombre, criticidad = 1, funcionalidad = "ADMINISTRACION DE OBJETIVOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return registros;
    }

    public int EliminarObjetivo(Objetivo objetivo)
    {

        var objetivoOBtenido = ObtenerObjetivoBD(objetivo.identificador);
        var nombreObjetivo = objetivoOBtenido.nombre;


        nombreObjetivo = GestorDeEncriptacion.EncriptarAes(nombreObjetivo + " Eliminado el dia: " + DateTime.Now.ToString("yyyy-MM-dd"));

        var registros = baseDeDatos.ModificarBase(String.Format("UPDATE OBJETIVO SET habilitado = 0, nombre = '{0}' WHERE idObjetivo = {1}", nombreObjetivo, objetivo.identificador));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se elimino el objetivo " + objetivo.identificador, criticidad = 1, funcionalidad = "ADMINISTRACION DE OBJETIVOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);

        return registros;
    }

    private Objetivo ObtenerObjetivoBD(int identificador)
    {
        DataTable nombreObjetivoTable = baseDeDatos.ConsultarBase(String.Format("SELECT * FROM OBJETIVO WHERE IDOBJETIVO = {0}", identificador));

        foreach (DataRow objetivorow in nombreObjetivoTable.Rows)
        {
            return PopularObjetivoDesdeBD(objetivorow);
        }

        return null;
    }

    public List<Objetivo> ListarObjetivos()
    {

        DataTable objetivosTable = baseDeDatos.ConsultarBase("SELECT * FROM OBJETIVO WHERE HABILITADO = 1");

        List<Objetivo> objetivos = new List<Objetivo>();
        foreach (DataRow row in objetivosTable.Rows)
        {
            Objetivo objetivo = new Objetivo();

            objetivo = PopularObjetivoDesdeBD(row);
            objetivos.Add(objetivo);
        }
        return objetivos;
    }
    private EquipoObjetivo PopularEquipoObjetivoDesdeBD(DataRow equipoObjetivoRow)
    {
        EquipoObjetivo equipoObjetivo = new EquipoObjetivo();
        equipoObjetivo.identificador = Convert.ToInt32(equipoObjetivoRow["idEquipoObjetivo"]);
        equipoObjetivo.equipo = new Equipo() { identificador = Convert.ToInt32(equipoObjetivoRow["idEquipo"]), nombre = Convert.ToString(equipoObjetivoRow["nombreEquipo"]), habilitado = Convert.ToBoolean(equipoObjetivoRow["equipoHabilitado"]) };
        equipoObjetivo.objetivo = new Objetivo() { identificador = Convert.ToInt32(equipoObjetivoRow["idObjetivo"]), nombre = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(equipoObjetivoRow["nombreObjetivo"])), puntaje = Convert.ToInt32(GestorDeEncriptacion.DesencriptarAes(Convert.ToString(equipoObjetivoRow["puntaje"]))), habilitado = Convert.ToBoolean(equipoObjetivoRow["objetivoHabilitado"]) };
        if (DBNull.Value != equipoObjetivoRow["periodoFin"])
        {
            equipoObjetivo.periodoFin = Convert.ToInt32(equipoObjetivoRow["periodoFin"]);
        }
        equipoObjetivo.periodoInicio = Convert.ToInt32(equipoObjetivoRow["periodoInicio"]);

        return equipoObjetivo;
    }
    private Objetivo PopularObjetivoDesdeBD(DataRow objetivoRow)
    {
        Objetivo objetivo = new Objetivo();
        objetivo.identificador = Convert.ToInt32(objetivoRow["idObjetivo"]);
        objetivo.nombre = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(objetivoRow["nombre"]));
        objetivo.puntaje = Convert.ToInt32(GestorDeEncriptacion.DesencriptarAes(Convert.ToString(objetivoRow["puntaje"])));
        objetivo.descripcion = Convert.ToString(objetivoRow["descripcion"]);
        return objetivo;
    }

    public int ModificarObjetivo(Objetivo objetivo)
    {
        Objetivo objetivoViejo = ObtenerObjetivoBD(objetivo.identificador);

        var nuevoNombreEncriptado = GestorDeEncriptacion.EncriptarAes(objetivo.nombre);
        var puntajeEncriptado = GestorDeEncriptacion.EncriptarAes(objetivo.puntaje.ToString());

        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM OBJETIVO WHERE nombre = '{0}' and idObjetivo != {1}", nuevoNombreEncriptado, objetivo.identificador)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }

        String set = "";
        if (objetivo.nombre != null && objetivoViejo.nombre != objetivo.nombre)
        {
            set = String.Format(" nombre = '{0}' ", nuevoNombreEncriptado);
        }
        if (objetivo.descripcion != null && objetivoViejo.descripcion != objetivo.descripcion)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            set = set + String.Format(" descripcion = '{0}' ", objetivo.descripcion);
        }

        if (objetivoViejo.puntaje != objetivo.puntaje)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            set = set + String.Format(" puntaje = '{0}' ", puntajeEncriptado);
        }

        var registros = baseDeDatos.ModificarBase(String.Format("UPDATE OBJETIVO SET {0} WHERE idObjetivo = {1}", set, objetivo.identificador));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se modifico el objetivo " + objetivo.identificador, criticidad = 2, funcionalidad = "ADMINISTRACION DE OBJETIVOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return registros;
    }

}