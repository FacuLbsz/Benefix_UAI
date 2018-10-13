using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeGrupos
{

    private GestorDeGrupos instancia;

    private GestorDeGrupos()
    {

    }

    public GestorDeGrupos ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeGrupos();
        }

        return instancia;
    }

    public int AsignarBeneficio(Beneficio beneficio, Grupo grupo)
    {

        return 0;
    }

    public List<Grupo> ConsultarGrupos()
    {

        return null;
    }

    public int CrearGrupo(Grupo grupo)
    {

        return 0;
    }

    public int DesasignarBeneficio(Beneficio beneficio, Grupo grupo)
    {

        return 0;
    }

    public List<EquipoGrupo> ObtenerAsignacionDeGruposDeUnEquipoEnUnPeriodo(Equipo equipo, int periodo)
    {

        return null;
    }

}