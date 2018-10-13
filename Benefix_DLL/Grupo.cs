using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Grupo
{

    List<Beneficio> beneficiosAsignados { get; set; }
    List<Equipo> equiposAsignados { get; set; }
    int identificador { get; set; }
    String nombre { get; set; }
    Beneficio m_Beneficio { get; set; }

    public Grupo()
    {

    }

}