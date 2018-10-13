using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Equipo
{

    List<Grupo> gruposAsignados { get; set; }
    int identificador { get; set; }
    int nombre { get; set; }
    List<Objetivo> objetivosAsignados { get; set; }
    List<Usuario> usuariosAsignados { get; set; }
    Grupo m_Grupo { get; set; }

    public Equipo()
    {

    }
}