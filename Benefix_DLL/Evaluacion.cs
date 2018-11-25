using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Evaluacion
{

    public int identificador { get; set; }
    public EquipoObjetivo equipoObjetvo { get; set; }
    public int periodo { get; set; }
    public Usuario usuario { get; set; }
    public bool alcanzado { get; set; }
    public int puntaje { get; set; }

    public Evaluacion()
    {

    }
}