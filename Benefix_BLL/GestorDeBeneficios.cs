using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeBeneficios
{
    private GestorDeBeneficios instancia;
    public GestorDeDigitoVerificador m_GestorDeDigitoVerificador;
    public GestorDeEncriptacion m_GestorDeEncriptacion;

    private GestorDeBeneficios()
    {

    }

    public GestorDeBeneficios ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeBeneficios();
        }

        return instancia;
    }

    public List<Beneficio> ConsultarBeneficios()
    {

        return null;
    }


    public List<Beneficio> ConsultarBeneficiosDeUnGrupo(Grupo grupo)
    {

        return null;
    }


    public int CrearBeneficio(Beneficio beneficio)
    {

        return 0;
    }


    public int EliminarBeneficio(Beneficio beneficio)
    {

        return 0;
    }


    public int ModificarBeneficio(Beneficio beneficio)
    {

        return 0;
    }


    public List<Beneficio> ObtenerBeneficiosParaUnEmpleadoYUnPeriodo(Usuario empleado, int periodo)
    {

        return null;
    }

    public int ObtenerReporteDeUnEmpleadoParaUnPeriodo(Usuario empleado, int periodo)
    {

        return 0;
    }

}