using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Genesis.pdf
{
    class MiEstadoPDF
    {
        protected static iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

        public static void ExportarPDFARuta(String subTitle, List<String> objetivosList, List<Evaluacion> objetivosObjs, List<String> beneficiosList, List<Beneficio> beneficiosObjs, String rutaDestino)
        {
            Document doc = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaDestino, FileMode.Create));

            doc.AddTitle("Mi Estado");
            doc.AddCreator("Benefix");

            doc.Open();

            doc.Add(new Paragraph(subTitle));
            doc.Add(Chunk.NEWLINE);

            PdfPTable tblPrueba = new PdfPTable(objetivosList.Count);
            tblPrueba.WidthPercentage = 100;

            objetivosList.ForEach(cabecara =>
                {
                    PdfPCell cabeceraCell = new PdfPCell(new Phrase(cabecara, _standardFont));
                    cabeceraCell.BorderWidth = 0;
                    cabeceraCell.BorderWidthBottom = 0.75f;
                    tblPrueba.AddCell(cabeceraCell);
                });



            Dictionary<String, List<Evaluacion>> equipoObjetivo = new Dictionary<string, List<Evaluacion>>();

            objetivosObjs.ForEach(evaluacion =>
            {
                var equipoNombre = evaluacion.equipoObjetvo.equipo.nombre;

                if (!equipoObjetivo.ContainsKey(equipoNombre))
                {
                    equipoObjetivo.Add(equipoNombre, new List<Evaluacion>());
                }

                equipoObjetivo[equipoNombre].Add(evaluacion);
            });
            var puntajeObtenido = 0;
            foreach (String equipo in equipoObjetivo.Keys)
            {

                PdfPCell rowCell = new PdfPCell(new Phrase(equipo, _standardFont));
                rowCell.BorderWidth = 0;
                tblPrueba.AddCell(rowCell);

                rowCell = new PdfPCell(new Phrase("", _standardFont));
                rowCell.BorderWidth = 0;
                tblPrueba.AddCell(rowCell);

                rowCell = new PdfPCell(new Phrase("", _standardFont));
                rowCell.BorderWidth = 0;
                tblPrueba.AddCell(rowCell);

                equipoObjetivo[equipo].ForEach(evaluacion =>
                {
                    if (evaluacion.alcanzado)
                        puntajeObtenido = puntajeObtenido + evaluacion.puntaje;

                    rowCell = new PdfPCell(new Phrase(evaluacion.equipoObjetvo.objetivo.nombre, _standardFont));
                    rowCell.BorderWidth = 0;
                    tblPrueba.AddCell(rowCell);

                    rowCell = new PdfPCell(new Phrase(evaluacion.equipoObjetvo.objetivo.puntaje.ToString(), _standardFont));
                    rowCell.BorderWidth = 0;
                    tblPrueba.AddCell(rowCell);

                    rowCell = new PdfPCell(new Phrase(evaluacion.alcanzado ? "SI" : "NO", _standardFont));
                    rowCell.BorderWidth = 0;
                    tblPrueba.AddCell(rowCell);
                });

            }
            doc.Add(tblPrueba);
            doc.Add(Chunk.NEWLINE);

            PdfPTable tblPrueba2 = new PdfPTable(beneficiosList.Count);
            tblPrueba2.WidthPercentage = 100;

            beneficiosList.ForEach(cabecara =>
            {
                PdfPCell cabeceraCell = new PdfPCell(new Phrase(cabecara, _standardFont));
                cabeceraCell.BorderWidth = 0;
                cabeceraCell.BorderWidthBottom = 0.75f;
                tblPrueba2.AddCell(cabeceraCell);
            });


            beneficiosObjs.ForEach(beneficio =>
            {
                PdfPCell cabeceraCell = new PdfPCell(new Phrase(beneficio.nombre, _standardFont));
                cabeceraCell.BorderWidth = 0;
                tblPrueba2.AddCell(cabeceraCell);

                cabeceraCell = new PdfPCell(new Phrase(puntajeObtenido + "/" + beneficio.puntaje, _standardFont));
                cabeceraCell.BorderWidth = 0;
                tblPrueba2.AddCell(cabeceraCell);

            });
            doc.Add(tblPrueba2);

            doc.Close();
            writer.Close();
        }
    }
}
