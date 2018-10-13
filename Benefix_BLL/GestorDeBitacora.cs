using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GestorDeBitacora
{

    private GestorDeBitacora instancia;
    public GestorDeDigitoVerificador m_GestorDeDigitoVerificador;
    public GestorDeEncriptacion m_GestorDeEncriptacion;

    private GestorDeBitacora()
    {

    }

    public GestorDeBitacora ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeBitacora();
        }

        return instancia;
    }

    public List<EventoBitacora> ConsultarEventos(String criticidad, DateTime fechaDesde, DateTime fechaHasta)
    {

        return null;
    }

    public int RegistrarEvento(EventoBitacora evento)
    {

        return 0;
    }

}