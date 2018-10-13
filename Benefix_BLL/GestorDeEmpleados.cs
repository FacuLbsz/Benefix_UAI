using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeEmpleados
{

    private GestorDeEmpleados instancia;
    public GestorDeObjetivos m_GestorDeObjetivos;
    public GestorDeEquipos m_GestorDeEquipos;
    public GestorDeEvaluaciones m_GestorDeEvaluaciones;
    public GestorDeGrupos m_GestorDeGrupos;

    private GestorDeEmpleados()
    {

    }

    public GestorDeEmpleados ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeEmpleados();
        }

        return instancia;
    }

    public List<Usuario> ConsultarEmpleados()
    {

        return null;
    }

    public List<Usuario> ConsultarEmpleadosSinEquipo()
    {

        return null;
    }

}