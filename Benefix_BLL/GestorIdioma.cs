using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorIdioma
{

    private GestorIdioma instancia;

    private GestorIdioma()
    {

    }

    public GestorIdioma ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorIdioma();
        }

        return instancia;
    }

    public List<Idioma> ConsultarIdiomas()
    {

        return null;
    }

    public Idioma ObtenerIdiomaDeUnUsuario(Usuario usuario)
    {

        return null;
    }

    public String ObtenerInternacionalizacion(Idioma idioma, String key)
    {

        return "";
    }

}