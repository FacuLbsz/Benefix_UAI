using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class Familia
{

    int identificador { get; set; }
    List<Patente> patentesAsignadas { get; set; }
    List<Usuario> usuariosAsignados { get; set; }
    Patente m_Patente { get; set; }

    public Familia()
    {

    }
}