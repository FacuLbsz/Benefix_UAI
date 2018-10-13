using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



public class GrupoBeneficio
{

    Beneficio beneficio { get; set; }
    Grupo grupo { get; set; }
    int identificador { get; set; }
    int periodoFin { get; set; }
    int periodoInicio { get; set; }
    Grupo m_Grupo { get; set; }
    Beneficio m_Beneficio { get; set; }

    public GrupoBeneficio()
    {

    }

}