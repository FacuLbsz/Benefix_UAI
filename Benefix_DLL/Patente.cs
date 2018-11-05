using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Patente
{

    public int identificador { get; set; }
    public String nombre { get; set; }
    public PatenteUsuario m_PatenteUsuario { get; set; }

    public Patente()
    {

    }

    public override bool Equals(object obj)
    {
        var item = obj as Patente;

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