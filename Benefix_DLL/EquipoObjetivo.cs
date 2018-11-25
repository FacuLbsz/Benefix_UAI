using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class EquipoObjetivo
{

    public int identificador { get; set; }
    public Equipo equipo { get; set; }
    public Objetivo objetivo { get; set; }
    public int periodoFin { get; set; }
    public int periodoInicio { get; set; }

    public EquipoObjetivo()
    {

    }

    public override String ToString()
    {
        return objetivo.nombre;
    }
}