using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDeBeneficios
{
    private static GestorDeBeneficios instancia;
    public GestorDeDigitoVerificador m_GestorDeDigitoVerificador;
    private GestorDeDigitoVerificador gestorDeDigitoVerificador;
    private BaseDeDatos baseDeDatos;

    private GestorDeBeneficios()
    {
        gestorDeDigitoVerificador = GestorDeDigitoVerificador.ObtenerInstancia();
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
    }

    public static GestorDeBeneficios ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeBeneficios();
        }

        return instancia;
    }

    public List<Beneficio> ConsultarBeneficios()
    {
        DataTable beneficiosTable = baseDeDatos.ConsultarBase("SELECT * FROM BENEFICIO WHERE HABILITADO = 1");

        List<Beneficio> beneficios = new List<Beneficio>();
        foreach (DataRow row in beneficiosTable.Rows)
        {
            Beneficio beneficio = new Beneficio();

            beneficio = PopularbeneficioDesdeBD(row);
            beneficios.Add(beneficio);
        }
        return beneficios;

    }

    private Beneficio PopularbeneficioDesdeBD(DataRow beneficioRow)
    {
        Beneficio beneficio = new Beneficio();
        beneficio.identificador = Convert.ToInt32(beneficioRow["idBeneficio"]);
        beneficio.nombre = GestorDeEncriptacion.DesencriptarAes(Convert.ToString(beneficioRow["nombre"]));
        beneficio.puntaje = Convert.ToInt32(GestorDeEncriptacion.DesencriptarAes(Convert.ToString(beneficioRow["puntaje"])));
        beneficio.descripcion = Convert.ToString(beneficioRow["descripcion"]);
        return beneficio;
    }


    public List<Beneficio> ConsultarBeneficiosDeUnGrupo(Grupo grupo)
    {

        return null;
    }


    public int CrearBeneficio(Beneficio beneficio)
    {

        beneficio.nombre = GestorDeEncriptacion.EncriptarAes(beneficio.nombre);
        var puntaje = GestorDeEncriptacion.EncriptarAes(beneficio.puntaje.ToString());

        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM BENEFICIO WHERE nombre = '{0}'", beneficio.nombre)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }


        var digitoVH = ObtenerDigitoVerificadorHDeBeneficio(beneficio.nombre, puntaje);
        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("INSERT INTO BENEFICIO (descripcion,nombre,puntaje,habilitado,digitoVerificadorH) VALUES ('{0}','{1}','{2}',1,'{3}')", beneficio.descripcion, beneficio.nombre, puntaje, digitoVH));

        gestorDeDigitoVerificador.ModificarDigitoVV("BENEFICIO");
        return registros;
    }

    private String ObtenerDigitoVerificadorHDeBeneficio(String nombre, String puntaje)
    {
        return GestorDeDigitoVerificador.ObtenerDigitoVH(new List<String>() { nombre, puntaje });
    }

    private Beneficio ObtenerBeneficioBD(int identificador)
    {
        DataTable nombreBeneficioTable = BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM BENEFICIO WHERE IDBENEFICIO = {0}", identificador));

        foreach (DataRow beneficiorow in nombreBeneficioTable.Rows)
        {
            return PopularbeneficioDesdeBD(beneficiorow);
        }

        return null;
    }

    public int EliminarBeneficio(Beneficio beneficio)
    {

        var beneficioOBtenido = ObtenerBeneficioBD(beneficio.identificador);
        var nombreBeneficio = beneficioOBtenido.nombre;
        var puntaje = beneficioOBtenido.puntaje;


        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se elimino el beneficio " + beneficio.identificador, criticidad = 1, funcionalidad = "ADMINISTRACION DE BENEFICIOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);


        nombreBeneficio = GestorDeEncriptacion.EncriptarAes(nombreBeneficio + " Eliminado el dia: " + DateTime.Now.ToString("yyyy-MM-dd"));
        var puntajeEncriptado = GestorDeEncriptacion.EncriptarAes(puntaje.ToString());
        var digitoVH = ObtenerDigitoVerificadorHDeBeneficio(nombreBeneficio, puntajeEncriptado);


        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE BENEFICIO SET habilitado = 0, nombre = '{0}', digitoVerificadorH = '{1}' WHERE idBeneficio = {2}", nombreBeneficio, digitoVH, beneficio.identificador));
        gestorDeDigitoVerificador.ModificarDigitoVV("BENEFICIO");

        return registros;
    }


    public int ModificarBeneficio(Beneficio beneficio)
    {

        Beneficio beneficioViejo = ObtenerBeneficioBD(beneficio.identificador);

        var nuevoNombreEncriptado = GestorDeEncriptacion.EncriptarAes(beneficio.nombre);
        var puntajeEncriptado = GestorDeEncriptacion.EncriptarAes(beneficio.puntaje.ToString());

        if (BaseDeDatos.ObtenerInstancia().ConsultarBase(String.Format("SELECT * FROM BENEFICIO WHERE nombre = '{0}'", nuevoNombreEncriptado)).Rows.Count > 0)
        {
            throw new EntidadDuplicadaExcepcion("nombre");
        }

        String set = "";
        if (beneficio.nombre != null && beneficioViejo.nombre != beneficio.nombre)
        {
            set = String.Format(" nombre = '{0}' ", nuevoNombreEncriptado);
        }
        if (beneficio.descripcion != null && beneficioViejo.descripcion != beneficio.descripcion)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            set = set + String.Format(" descripcion = '{0}' ", beneficio.descripcion);
        }

        if (beneficioViejo.puntaje != beneficio.puntaje)
        {
            if (set.Length > 0)
            {
                set = set + " , ";
            }
            set = set + String.Format(" puntaje = '{0}' ", puntajeEncriptado);
        }


        var digitoVH = ObtenerDigitoVerificadorHDeBeneficio(nuevoNombreEncriptado, puntajeEncriptado);

        if (set.Length > 0)
        {
            set = set + " , ";
        }
        set = set + String.Format(" digitoVerificadorH = '{0}' ", digitoVH);

        var registros = BaseDeDatos.ObtenerInstancia().ModificarBase(String.Format("UPDATE BENEFICIO SET {0} WHERE idBeneficio = {1}", set, beneficio.identificador));
        gestorDeDigitoVerificador.ModificarDigitoVV("BENEFICIO");

        EventoBitacora evento = new EventoBitacora() { fecha = DateTime.Now, descripcion = "Se modifico el beneficio " + beneficio.identificador, criticidad = 2, funcionalidad = "ADMINISTRACION DE BENEFICIOS", usuario = GestorSistema.ObtenerInstancia().ObtenerUsuarioEnSesion() };
        GestorDeBitacora.ObtenerInstancia().RegistrarEvento(evento);
        return registros;
    }


    public List<Beneficio> ObtenerBeneficiosParaUnEmpleadoYUnPeriodo(Usuario empleado, int periodo)
    {

        return null;
    }

    public int ObtenerReporteDeUnEmpleadoParaUnPeriodo(Usuario empleado, int periodo)
    {

        return 0;
    }

}