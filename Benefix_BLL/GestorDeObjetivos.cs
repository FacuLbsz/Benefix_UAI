using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeObjetivos
{

    private GestorDeObjetivos instancia;
    public GestorDeEncriptacion m_GestorDeEncriptacion;

    private GestorDeObjetivos()
    {

    }

    public GestorDeObjetivos ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeObjetivos();
        }

        return instancia;
    }

    public List<EquipoObjetivo> ConsultarObjetivosAsignadosAUnEquipoEnUnPeriodo(Equipo equipo, int periodo)
    {

        return null;
    }

    public int CrearObjetivo(Objetivo objetivo)
    {

        return 0;
    }

    public int EliminarObjetivo(Objetivo objetivo)
    {

        return 0;
    }

    public List<Objetivo> ListarObjetivos()
    {

        return null;
    }

    public int ModificarObjetivo(Objetivo objetivo)
    {

        return 0;
    }

}