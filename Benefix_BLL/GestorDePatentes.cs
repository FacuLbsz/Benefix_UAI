using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDePatentes
{

    private GestorDePatentes instancia;

    private GestorDePatentes()
    {

    }

    public GestorDePatentes ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDePatentes();
        }

        return instancia;
    }

    public int AsignarAUnUsuario(Usuario usuario, Patente patente)
    {

        return 0;
    }

    public int DesasignarAUnUsuario(Usuario usuario, Patente patente)
    {

        return 0;
    }

    public List<Patente> ObtenerPatentes()
    {

        return null;
    }

    public List<Patente> ObtenerPatentesParaUnUsuario(Usuario usuario)
    {

        return null;
    }

    public int VerificarPatenteEscencial(Patente patente)
    {

        return 0;
    }

}