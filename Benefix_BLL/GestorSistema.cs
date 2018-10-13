using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorSistema
{

    private GestorSistema instancia;
    public GestorDeUsuarios m_GestorDeUsuarios;
    public GestorDePatentes m_GestorDePatentes;
    public GestorIdioma m_GestorIdioma;

    private GestorSistema()
    {

    }

    public GestorSistema ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorSistema();
        }

        return instancia;
    }

    public int ConsultarIntegridadDeBaseDeDatos()
    {

        return 0;
    }

    public int ModificarStringDeConexion(String stringDeConexion)
    {

        return 0;
    }

    private Object ObtenerBaseDeDatos()
    {

        return null;
    }

    private int Particionar(int cantidadVolumenes)
    {

        return 0;
    }

    public int RealizarBackup(String rutaDestino, int cantidadVolumenes)
    {

        return 0;
    }

    public int RealizarRestore(String rutaOrigen)
    {

        return 0;
    }

    private int RestaurarBackup(String rutaOrigen)
    {

        return 0;
    }

    private int ValidarRutaDestino(String rutaDestino)
    {

        return 0;
    }

    private int ValidarRutaOrigen()
    {

        return 0;
    }

}