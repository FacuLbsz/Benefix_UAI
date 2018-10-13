
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeEncriptacion
{

    private GestorDeEncriptacion instancia;

    private GestorDeEncriptacion()
    {

    }

    public GestorDeEncriptacion ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeEncriptacion();
        }

        return instancia;
    }

    public List<String> DesencriptarAes(List<String> list)
    {

        return null;
    }

    public List<String> EncriptarAes(List<String> list)
    {

        return null;
    }

    public List<String> EncriptarMD5(List<String> list)
    {

        return null;
    }

}