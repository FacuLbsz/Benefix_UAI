using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Genesis.pdf
{
    class ReportesDeObjetivosPorEquiposPDF : PDFExportador
    {
        protected override void CompletarDocumento(PdfPTable tabla, List<Object> objectLists)
        {
            objectLists.ForEach(obj =>
            {
                Object[] eventoBitacora = (Object[])obj;

                PdfPCell rowCell = new PdfPCell(new Phrase(eventoBitacora[0].ToString(), _standardFont));
                rowCell.BorderWidth = 0;
                tabla.AddCell(rowCell);

                rowCell = new PdfPCell(new Phrase(eventoBitacora[1].ToString(), _standardFont));
                rowCell.BorderWidth = 0;
                tabla.AddCell(rowCell);
            });
        }
    }
}
