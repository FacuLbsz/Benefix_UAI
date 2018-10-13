using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class EquipoGrupo
{

    Equipo equipo { get; set; }
    Grupo grupo { get; set; }
    int identificador { get; set; }
    int periodoFin { get; set; }
    int periodoInicio { get; set; }
    Equipo m_Equipo { get; set; }
    Grupo m_Grupo { get; set; }

    public EquipoGrupo()
    {

    }
}