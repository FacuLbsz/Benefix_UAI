using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Objetivo
{

    public String descripcion { get; set; }
    public List<Equipo> equiposAsignados { get; set; }
    public int identificador { get; set; }
    public String nombre { get; set; }
    public int puntaje { get; set; }
    public Equipo m_Equipo { get; set; }
    public bool habilitado { get; set; }

    public Objetivo()
    {

    }

    public override bool Equals(object obj)
    {
        var item = obj as Objetivo;

        if (item == null)
        {
            return false;
        }

        return item.identificador == identificador;
    }

    public override int GetHashCode()
    {
        return identificador;
    }

}