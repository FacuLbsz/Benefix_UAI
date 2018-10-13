using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class BaseDeDatos
{

    private BaseDeDatos instancia;

    private BaseDeDatos()
    {

    }

    public BaseDeDatos ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new BaseDeDatos();
        }
        return instancia;
    }

    public Object consultarBase(String query)
    {

        return null;
    }

    public int modificarBase(String query)
    {

        return 0;
    }

}