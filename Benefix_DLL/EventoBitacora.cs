using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class EventoBitacora
{

    int criticidad { get; set; }
    String descripcion { get; set; }
    DateTime fecha { get; set; }
    String funcionalidad { get; set; }
    Usuario usuario { get; set; }
    Usuario m_Usuario { get; set; }

    public EventoBitacora()
    {

    }
}