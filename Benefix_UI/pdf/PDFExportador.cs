using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.pdf
{
    abstract class PDFExportador
    {
        protected iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

        public void ExportarPDFARuta(String title, List<String> columnHeaderList, List<Object> objectLists, String rutaDestino)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaDestino, FileMode.Create));

            doc.AddTitle("Reportes Benefix");
            doc.AddCreator("Benefix");

            doc.Open();

            doc.Add(new Paragraph(title));
            doc.Add(Chunk.NEWLINE);

            PdfPTable tblPrueba = new PdfPTable(columnHeaderList.Count);
            tblPrueba.WidthPercentage = 100;

            columnHeaderList.ForEach(cabecara =>
            {
                PdfPCell clNombre = new PdfPCell(new Phrase(cabecara, _standardFont));
                clNombre.BorderWidth = 0;
                clNombre.BorderWidthBottom = 0.75f;
                tblPrueba.AddCell(clNombre);
            });

            CompletarDocumento(tblPrueba, objectLists);
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();
        }

        protected abstract void CompletarDocumento(PdfPTable tabla, List<Object> objectLists);
    }

}
