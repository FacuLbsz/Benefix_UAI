using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorIdioma
{

    private static GestorIdioma instancia;
    private BaseDeDatos baseDeDatos;
    private Dictionary<int, String> idiomaCulturaMap;

    private GestorIdioma()
    {
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
        idiomaCulturaMap = new Dictionary<int, String>();
        idiomaCulturaMap.Add(1, "es-ES");
        idiomaCulturaMap.Add(2, "en-US");
    }

    public static GestorIdioma ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorIdioma();
        }

        return instancia;
    }

    public List<Idioma> ConsultarIdiomas()
    {
        DataTable idiomasTable = baseDeDatos.ConsultarBase("SELECT * FORM IDIOMA");

        List<Idioma> idiomas = new List<Idioma>();
        foreach (DataRow idiomaRow in idiomasTable.Rows)
        {
            idiomas.Add(new Idioma() { identificador = Convert.ToInt32(idiomaRow["idIdioma"]), nombre = Convert.ToString(idiomaRow["nombre"]) });
        }
        return idiomas;
    }

    public Idioma ObtenerIdiomaDeUnUsuario(Usuario usuario)
    {
        DataTable idiomasTable = baseDeDatos.ConsultarBase(String.Format("SELECT idioma.idIdioma, idioma.nombre FROM USUARIO INNER JOIN IDIOMA on idioma.idIdioma = usuario.Idioma_idIdioma WHERE idUsuario = {0}", usuario.identificador));
        Idioma idioma = null;
        foreach (DataRow idiomaRow in idiomasTable.Rows)
        {
            idioma = new Idioma() { identificador = Convert.ToInt32(idiomaRow["idIdioma"]), nombre = Convert.ToString(idiomaRow["nombre"]) };
        }
        idioma.nombre = idiomaCulturaMap[idioma.identificador];
        return idioma;
    }

    public String ObtenerInternacionalizacion(Idioma idioma, String key)
    {
        return key;
    }

}