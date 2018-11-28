using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;

namespace Genesis.pdf
{
    class BitacoraPDF : PDFExportador
    {
        protected override void CompletarDocumento(PdfPTable tabla, List<Object> objectLists)
        {
            objectLists.ForEach(obj =>
            {
                DataGridViewRow row = (DataGridViewRow) obj;

                foreach(DataGridViewCell cell in row.Cells)
                {
                    PdfPCell rowCell = new PdfPCell(new Phrase(cell.Value.ToString(), _standardFont));
                    rowCell.BorderWidth = 0;
                    tabla.AddCell(rowCell);
                    
                }
                /*
                PdfPCell rowCell = new PdfPCell(new Phrase(eventoBitacora.usuario.nombreUsuario, _standardFont));
                rowCell.BorderWidth = 0;
                tabla.AddCell(rowCell);

                rowCell = new PdfPCell(new Phrase(eventoBitacora.fecha.ToString(), _standardFont));
                rowCell.BorderWidth = 0;
                tabla.AddCell(rowCell);

                rowCell = new PdfPCell(new Phrase(eventoBitacora.funcionalidad, _standardFont));
                rowCell.BorderWidth = 0;
                tabla.AddCell(rowCell);

                rowCell = new PdfPCell(new Phrase(eventoBitacora.descripcion, _standardFont));
                rowCell.BorderWidth = 0;
                tabla.AddCell(rowCell);

                String criticidadString = "";
                switch (eventoBitacora.criticidad)
                {
                    case 1:
                        criticidadString = "Alta";
                        break;
                    case 2:
                        criticidadString = "Media";
                        break;
                    case 3:
                        criticidadString = "Baja";
                        break;
                }
                rowCell = new PdfPCell(new Phrase(criticidadString, _standardFont));
                rowCell.BorderWidth = 0;
                tabla.AddCell(rowCell);*/
            });
        }
    }
}
