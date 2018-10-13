using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeFamilias
{

    private GestorDeFamilias instancia;
    public GestorDeDigitoVerificador m_GestorDeDigitoVerificador;
    public GestorDeEncriptacion m_GestorDeEncriptacion;

    private GestorDeFamilias()
    {

    }

    public GestorDeFamilias ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeFamilias();
        }

        return instancia;
    }

    public int AsignarPatente(Patente patente, Familia familia)
    {

        return 0;
    }

    public int AsignarUsuario(Usuario usuario, Familia familia)
    {

        return 0;
    }

    public List<Familia> ConsultarFamilias()
    {

        return null;
    }

    public int CrearFamilia(Familia familia)
    {

        return 0;
    }

    public int DesasignarPatente(Patente patente, Familia familia)
    {

        return 0;
    }

    public int DesasignarUsuario(Usuario usuario, Familia familia)
    {

        return 0;
    }

}