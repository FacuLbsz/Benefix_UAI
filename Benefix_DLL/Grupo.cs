using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Grupo
{

    public List<Beneficio> beneficiosAsignados { get; set; }
    public List<Equipo> equiposAsignados { get; set; }
    public int identificador { get; set; }
    public String nombre { get; set; }
    public Beneficio m_Beneficio { get; set; }

    public Grupo()
    {
        beneficiosAsignados = new List<Beneficio>();
    }

    public override bool Equals(object obj)
    {
        var item = obj as Grupo;

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