using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class PatenteUsuario
{

    Boolean esPermisivo { get; set; }
    int identificador { get; set; }
    Patente patente { get; set; }
    Usuario usuario { get; set; }
    Usuario m_Usuario { get; set; }

    public PatenteUsuario()
    {

    }

}