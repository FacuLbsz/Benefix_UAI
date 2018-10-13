using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeEquipos
{

    private GestorDeEquipos instancia;

    private GestorDeEquipos()
    {

    }

    public GestorDeEquipos ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeEquipos();
        }

        return instancia;
    }

    public int AsignarCoordinador(Usuario empleado, Equipo equipo)
    {

        return 0;
    }

    public int AsignarEmpleado(Usuario empleado, Equipo equipo)
    {

        return 0;
    }

    public int AsignarGrupo(Grupo grupo, Equipo equipo)
    {

        return 0;
    }

    public List<Equipo> ConsultarEquipos()
    {

        return null;
    }

    public List<Equipo> ConsultarEquiposDeUnEmpleadoPorPeriodo(Usuario empleado, int periodo)
    {

        return null;
    }

    public int CrearEquipo(Equipo equipo)
    {

        return 0;
    }

    public int DesasignarEmpleado(Usuario empleado, Equipo equipo)
    {

        return 0;
    }

    public int DesasignarGrupo(Grupo grupo, Equipo equipo)
    {

        return 0;
    }

    public List<Equipo> ObtenerEquiposPorCoordinador(Usuario empleado)
    {

        return null;
    }

}