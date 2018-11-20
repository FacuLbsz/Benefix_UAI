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

        return null;
    }

    public int CrearObjetivo(Objetivo objetivo)
    {
        objetivo.nombre = GestorDeEncriptacion.EncriptarAes(objetivo.nombre);
        var puntaje = GestorDeEncriptacion.EncriptarAes(objetivo.puntaje.ToString());

        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM OBJETIVO WHERE nombre = '{0}'", objetivo.nombre)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }


        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("INSERT INTO OBJETIVO (descripcion,nombre,puntaje,habilitado) VALUES ('{0}','{1}','{2}',1)", objetivo.descripcion, objetivo.nombre, puntaje));

        return registros;
    }

    public int EliminarObjetivo(Objetivo objetivo)
    {

        var objetivoOBtenido = ObtenerObjetivoBD(objetivo.identificador);
        var nombreObjetivo = objetivoOBtenido.nombre;
        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se elimino el objetivo " + objetivo.identificador, criticidad = 1, funcionalidad = "ADMINISTRACION DE OBJETIVOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);


       nombreObjetivo = GestorDeEncriptacion.EncriptarAes(nombreObjetivo + " Eliminado el dia: " + DateTime.Now.ToString("yyyy-MM-dd"));

        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE OBJETIVO SET habilitado = 0, nombre = '{0}' WHERE idObjetivo = {1}", nombreObjetivo, objetivo.identificador));

        return registros;
    }

    private Objetivo ObtenerObjetivoBD(int identificador)
    {
        DataTable nombreObjetivoTable = BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM OBJETIVO WHERE IDOBJETIVO = {0}", identificador));

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

        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM OBJETIVO WHERE nombre = '{0}'", nuevoNombreEncriptado)).Rows.Count > 0)
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

        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE OBJETIVO SET {0} WHERE idObjetivo = {1}", set, objetivo.identificador));

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se modifico el objetivo " + objetivo.identificador, criticidad = 2, funcionalidad = "ADMINISTRACION DE OBJETIVOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return registros;
    }

}