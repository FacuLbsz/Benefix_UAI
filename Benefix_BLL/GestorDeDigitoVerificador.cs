using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeDigitoVerificador
{

    private GestorDeDigitoVerificador instancia;

    private GestorDeDigitoVerificador()
    {

    }

    public GestorDeDigitoVerificador ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeDigitoVerificador();
        }

        return instancia;
    }

    public int ModificarDigitoVV(String tabla, int digitoVH)
    {

        return 0;
    }

    public List<String> ObtenerDigitoVH(List<String> argumentos)
    {

        return null;
    }

}