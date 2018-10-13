using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Beneficio
{
    String descripcion { get; set; }
    List<Grupo> gruposAsignados { get; set; }
    int identificador { get; set; }
    String nombre { get; set; }
    int puntaje { get; set; }

    public Beneficio()
    {

    }
}