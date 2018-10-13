using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Objetivo
{

    String descripcion { get; set; }
    List<Equipo> equiposAsignados { get; set; }
    int identificador { get; set; }
    String nombre { get; set; }
    int puntaje { get; set; }
    Equipo m_Equipo { get; set; }

    public Objetivo()
    {

    }

}