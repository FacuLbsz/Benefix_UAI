using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Equipo
{

    public List<Grupo> gruposAsignados { get; set; }
    public int identificador { get; set; }
    public String nombre { get; set; }
    public List<Objetivo> objetivosAsignados { get; set; }
    public List<Usuario> usuariosAsignados { get; set; }
    public Grupo m_Grupo { get; set; }
    public Usuario coordinador { get; set; }
    public bool habilitado { get; set; }

    public Equipo()
    {
        objetivosAsignados = new List<Objetivo>();
        usuariosAsignados = new List<Usuario>();
        gruposAsignados = new List<Grupo>();
    }
}