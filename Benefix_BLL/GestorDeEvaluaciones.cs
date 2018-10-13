using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeEvaluaciones
{

    private GestorDeEvaluaciones instancia;
    public GestorDeDigitoVerificador m_GestorDeDigitoVerificador;

    private GestorDeEvaluaciones()
    {

    }

    public GestorDeEvaluaciones ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeEvaluaciones();
        }

        return instancia;
    }

    public int CrearEvaluacion(Usuario empleado, Objetivo objetivo, Equipo equipo)
    {

        return 0;
    }

    public Object ObtenerEvaluacionDeUnEmpleadoParaUnPeriodo(Usuario empleado, int periodo)
    {

        return null;
    }

    public Object ObtenerEvaluacionDeUnEmpleadoParaUnPeriodoYUnEquipo(Equipo equipo, Usuario empleado, int periodo)
    {

        return null;
    }

    public Object ObtenerEvaluacionDeUnEquipoParaUnPeriodo(Equipo equipo, int periodo)
    {

        return null;
    }

    public List<Evaluacion> ObtenerEvaluacionesDeUnObjetivo(Objetivo objetivo)
    {

        return null;
    }

}