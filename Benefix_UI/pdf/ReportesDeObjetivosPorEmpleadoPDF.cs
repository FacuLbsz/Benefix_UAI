using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Genesis.pdf
{
    class ReportesDeObjetivosPorEmpleadoPDF : PDFExportador
    {
        protected override void CompletarDocumento(PdfPTable tabla, List<Object> objectLists)
        {

            Dictionary<String, List<Evaluacion>> equipoObjetivo = new Dictionary<string, List<Evaluacion>>();

            objectLists.ForEach(obj =>
            {
                Evaluacion evaluacion = (Evaluacion)obj;

                var equipoNombre = evaluacion.equipoObjetvo.equipo.nombre;

                if (!equipoObjetivo.ContainsKey(equipoNombre))
                {
                    equipoObjetivo.Add(equipoNombre, new List<Evaluacion>());
                }

                equipoObjetivo[equipoNombre].Add(evaluacion);
            });

            foreach (String equipo in equipoObjetivo.Keys)
            {

                PdfPCell rowCell = new PdfPCell(new Phrase(equipo, _standardFont));
                rowCell.BorderWidth = 0;
                tabla.AddCell(rowCell);

                rowCell = new PdfPCell(new Phrase("", _standardFont));
                rowCell.BorderWidth = 0;
                tabla.AddCell(rowCell);

                equipoObjetivo[equipo].ForEach(evaluacion =>
                {
                    rowCell = new PdfPCell(new Phrase(evaluacion.equipoObjetvo.objetivo.nombre, _standardFont));
                    rowCell.BorderWidth = 0;
                    tabla.AddCell(rowCell);

                    rowCell = new PdfPCell(new Phrase(evaluacion.alcanzado ? "SI" : "NO", _standardFont));
                    rowCell.BorderWidth = 0;
                    tabla.AddCell(rowCell);
                });

            }
        }
    }
}
