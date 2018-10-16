using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Usuario
{

    public String apellido { get; set; }
    public String contrase�a { get; set; }
    public String email { get; set; }
    public int identificador { get; set; }
    public Idioma idioma { get; set; }
    public String nombre { get; set; }
    public String nombreUsuario { get; set; }
    public List<PatenteUsuario> patenteUsuarioAsignadas { get; set; }
    public Idioma m_Idioma { get; set; }
    public Familia m_Familia { get; set; }
    public Equipo m_Equipo { get; set; }

    public Usuario()
    {

    }
}