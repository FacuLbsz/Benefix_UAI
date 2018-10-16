using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

public class GestorDeBitacora
{

    private static GestorDeBitacora instancia;
    public GestorDeDigitoVerificador m_GestorDeDigitoVerificador;
    public GestorDeEncriptacion m_GestorDeEncriptacion;
    private BaseDeDatos baseDeDatos;
    //SDC Agregar llamado para obtener usuario desencriptado en diagrama de secuencia
    private GestorDeUsuarios gestorDeUsuarios;

    private GestorDeBitacora()
    {
        baseDeDatos = BaseDeDatos.ObtenerInstancia();
        gestorDeUsuarios = GestorDeUsuarios.ObtenerInstancia();
    }

    public static GestorDeBitacora ObtenerInstancia()
    {
        if (instancia == null)
        {
            instancia = new GestorDeBitacora();
        }

        return instancia;
    }

    //SDC Cambio tipos de parametros y agrego parametros
    public List<EventoBitacora> ConsultarEventos(int? criticidad, int? idUsuario, DateTime? fechaDesde, DateTime? fechaHasta)
    {
        DataTable dataTable = baseDeDatos.ConsultarBase("Select * from Bitacora " + CrearWhere(criticidad, idUsuario, fechaDesde, fechaHasta));

        List<EventoBitacora> eventosBitacora = new List<EventoBitacora>();
        foreach (DataRow row in dataTable.Rows)
        {
            EventoBitacora eventoBitacora = new EventoBitacora();
            eventoBitacora.criticidad = Convert.ToInt32(row["criticidad"]);
            eventoBitacora.usuario = gestorDeUsuarios.ObtenerUsuario(Convert.ToInt32(row["Usuario_idUsuario"]));
            eventoBitacora.fecha = Convert.ToDateTime(row["fecha"]);
            eventoBitacora.descripcion = Convert.ToString(row["descripcion"]);
            eventoBitacora.funcionalidad = Convert.ToString(row["funcionalidad"]);

            eventosBitacora.Add(eventoBitacora);
        }
        return eventosBitacora;
    }

    private string CrearWhere(int? criticidad, int? idUsuario, DateTime? fechaDesde, DateTime? fechaHasta)
    {
        String where = "";
        if (criticidad != null)
        {
            where = " criticidad = " + criticidad;
        }

        if (idUsuario != null)
        {
            if (where.Length > 0)
            {
                where = where + " AND ";
            }
            where = where + " Usuario_idUsuario = " + idUsuario;
        }

        if (fechaDesde != null && fechaHasta != null)
        {

            if (where.Length > 0)
            {
                where = where + " AND ";
            }
            where = where + " fecha between '" + fechaDesde.ToString() + "' and '" + fechaHasta.ToString() +"'";
        }

        if (where.Length > 0)
            return "WHERE " + where;
        else
            return "";

    }

    public int RegistrarEvento(EventoBitacora evento)
    {

        return 0;
    }

}