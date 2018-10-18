using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class PatenteUsuario
{

     public Boolean esPermisivo { get; set; }
     public int identificador { get; set; }
     public Patente patente { get; set; }
     public Usuario usuario { get; set; }
     public Usuario m_Usuario { get; set; }

    public PatenteUsuario()
    {

    }

}