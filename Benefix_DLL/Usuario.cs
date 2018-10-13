using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Usuario
{

    String apellido { get; set; }
    String contraseña { get; set; }
    String email { get; set; }
    int identificador { get; set; }
    Idioma idioma { get; set; }
    String nombre { get; set; }
    String nombreUsuario { get; set; }
    List<PatenteUsuario> patenteUsuarioAsignadas { get; set; }
    Idioma m_Idioma { get; set; }
    Familia m_Familia { get; set; }
    Equipo m_Equipo { get; set; }

    public Usuario()
    {

    }
}