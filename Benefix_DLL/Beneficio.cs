using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Beneficio
{
    public String descripcion { get; set; }
    public List<Grupo> gruposAsignados { get; set; }
    public int identificador { get; set; }
    public String nombre { get; set; }
    public int puntaje { get; set; }

    public Beneficio()
    {

    }

    public override bool Equals(object obj)
    {
        var item = obj as Beneficio;

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