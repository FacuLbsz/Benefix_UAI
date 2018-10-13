using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class EquipoObjetivo
{

    Equipo equipo { get; set; }
    int identificador { get; set; }
    Objetivo objetivo { get; set; }
    int periodoFin { get; set; }
    int periodoInicio { get; set; }
    Objetivo m_Objetivo { get; set; }
    Equipo m_Equipo { get; set; }

    public EquipoObjetivo()
    {

    }
}