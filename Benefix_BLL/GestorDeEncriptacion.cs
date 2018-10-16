
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeEncriptacion
{

    private static GestorDeEncriptacion instancia;

    private GestorDeEncriptacion()
    {

    }

    public static GestorDeEncriptacion ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeEncriptacion();
        }

        return instancia;
    }

    public List<String> DesencriptarAes(List<String> list)
    {

        return list;
    }

    public List<String> EncriptarAes(List<String> list)
    {

        return list;
    }

    public List<String> EncriptarMD5(List<String> list)
    {

        return list;
    }

}