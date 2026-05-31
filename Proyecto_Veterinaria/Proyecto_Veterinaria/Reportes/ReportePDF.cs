using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Veterinaria.Entidades
{
    public class ReportePDF
    {
        public static void GenerarComprobanteConsulta(GuiaConsulta consulta, Medico medico)
        {
            // 1. Ruta de guardado automático: Carpeta "Mis Documentos" del usuario
            string carpetaDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string nombreArchivo = $"Comprobante_Consulta_{consulta.IdConsulta}.pdf";
            string rutaCompleta = Path.Combine(carpetaDocumentos, nombreArchivo);

            // 2. Crear lienzo del documento (Tamaño Carta con márgenes de 40 puntos)
            Document doc = new Document(PageSize.LETTER, 40, 40, 40, 40);

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(rutaCompleta, FileMode.Create));
                doc.Open();

                // 3. Paleta de colores profesionales (Azul Clínico y Gris Oscuro)
                BaseColor colorPrimario = new BaseColor(41, 128, 185);     // #2980b9
                BaseColor colorTexto = new BaseColor(44, 62, 80);          // #2c3e50
                BaseColor colorFondoCelda = new BaseColor(242, 244, 244); // #f2f4f4

                // Fuentería estándar iTextSharp
                Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, colorPrimario);
                Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, BaseColor.GRAY);
                Font fuenteSeccion = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13, colorPrimario);
                Font fuenteTextoNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, colorTexto);
                Font fuenteTextoNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10, colorTexto);

                // =========================================================================
                // ENCABEZADO PRINCIPAL
                // =========================================================================
                Paragraph titulo = new Paragraph("CENTRO VETERINARIO \"HUELLITAS FELICES\"", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                Paragraph subtitulo = new Paragraph("COMPROBANTE DE REGISTRO CLÍNICO DE CONSULTA", fuenteSubtitulo);
                subtitulo.Alignment = Element.ALIGN_CENTER;
                subtitulo.SpacingAfter = 18;
                doc.Add(subtitulo);

                // Línea estética divisoria
                Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1.5f, 100f, colorPrimario, Element.ALIGN_CENTER, -5f)));
                linea.SpacingAfter = 15;
                doc.Add(linea);

                // =========================================================================
                // TABLA 1: DATOS DE CONTROL DE LA CONSULTA
                // =========================================================================
                PdfPTable tablaGeneral = new PdfPTable(2);
                tablaGeneral.WidthPercentage = 100;
                tablaGeneral.SetWidths(new float[] { 50f, 50f });
                tablaGeneral.SpacingAfter = 15;

                // Datos de la izquierda
                PdfPCell celdaInfo = new PdfPCell();
                celdaInfo.Border = PdfPCell.NO_BORDER;
                celdaInfo.AddElement(new Paragraph($"Consulta N°: {consulta.IdConsulta}", fuenteTextoNegrita));
                celdaInfo.AddElement(new Paragraph($"Fecha / Hora: {consulta.FechaConsulta.ToString("dd/MM/yyyy HH:mm")}", fuenteTextoNormal));
                tablaGeneral.AddCell(celdaInfo);

                // Datos de la derecha (Médico encargado)
                PdfPCell celdaMed = new PdfPCell();
                celdaMed.Border = PdfPCell.NO_BORDER;
                celdaMed.AddElement(new Paragraph($"Médico Veterinario:", fuenteTextoNegrita));
                celdaMed.AddElement(new Paragraph($"Dr(a). {medico.Nombre} {medico.Apellido}", fuenteTextoNormal));
                tablaGeneral.AddCell(celdaMed);

                doc.Add(tablaGeneral);

                // =========================================================================
                // TABLA 2: PROPIETARIO Y PACIENTE
                // =========================================================================
                doc.Add(new Paragraph("Información del Propietario y Paciente", fuenteSeccion) { SpacingAfter = 6 });

                PdfPTable tablaActores = new PdfPTable(4);
                tablaActores.WidthPercentage = 100;
                tablaActores.SetWidths(new float[] { 22f, 28f, 22f, 28f });
                tablaActores.SpacingAfter = 15;

                // Fila 1 (Con fondo gris de distinción)
                AgregarCelda(tablaActores, "Propietario:", fuenteTextoNegrita, colorFondoCelda);
                AgregarCelda(tablaActores, $"{consulta.Dueno.Nombre} {consulta.Dueno.Apellido}", fuenteTextoNormal, colorFondoCelda);
                AgregarCelda(tablaActores, "Mascota (Paciente):", fuenteTextoNegrita, colorFondoCelda);
                AgregarCelda(tablaActores, $"{consulta.Mascota.Nombre}", fuenteTextoNormal, colorFondoCelda);

                // Fila 2 (Fondo blanco limpio)
                AgregarCelda(tablaActores, "Cédula Identidad:", fuenteTextoNegrita, BaseColor.WHITE);
                AgregarCelda(tablaActores, $"{consulta.Dueno.Cedula}", fuenteTextoNormal, BaseColor.WHITE);
                AgregarCelda(tablaActores, "Especie / Raza:", fuenteTextoNegrita, BaseColor.WHITE);
                AgregarCelda(tablaActores, $"{consulta.Mascota.Especie} / {consulta.Mascota.Raza}", fuenteTextoNormal, BaseColor.WHITE);

                doc.Add(tablaActores);

                // =========================================================================
                // TABLA 3: CONSTANTES VITALES (SIGNOS CLÍNICOS)
                // =========================================================================
                doc.Add(new Paragraph("Signos Clínicos y Constantes Vitales", fuenteSeccion) { SpacingAfter = 6 });

                PdfPTable tablaSignos = new PdfPTable(5);
                tablaSignos.WidthPercentage = 100;
                tablaSignos.SpacingAfter = 15;

                // Encabezados de la tabla de signos
                AgregarCeldaCentro(tablaSignos, "Temperatura", fuenteTextoNegrita, colorFondoCelda);
                AgregarCeldaCentro(tablaSignos, "Peso", fuenteTextoNegrita, colorFondoCelda);
                AgregarCeldaCentro(tablaSignos, "Frec. Cardíaca", fuenteTextoNegrita, colorFondoCelda);
                AgregarCeldaCentro(tablaSignos, "Frec. Respiratoria", fuenteTextoNegrita, colorFondoCelda);
                AgregarCeldaCentro(tablaSignos, "Estatura", fuenteTextoNegrita, colorFondoCelda);

                // Valores clínicos reales mapeados
                tablaSignos.AddCell(new PdfPCell(new Phrase($"{consulta.Temperatura} °C", fuenteTextoNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
                tablaSignos.AddCell(new PdfPCell(new Phrase($"{consulta.Peso} kg", fuenteTextoNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
                tablaSignos.AddCell(new PdfPCell(new Phrase($"{consulta.FrecuenciaCardiaca} bpm", fuenteTextoNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
                tablaSignos.AddCell(new PdfPCell(new Phrase($"{consulta.FrecuenciaRespiratoria} rpm", fuenteTextoNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });
                tablaSignos.AddCell(new PdfPCell(new Phrase($"{consulta.Estatura} cm", fuenteTextoNormal)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 6 });

                doc.Add(tablaSignos);

                // =========================================================================
                // TABLA 4: BLOQUES LARGOS (MOTIVO, DIAGNÓSTICO Y TRATAMIENTO)
                // =========================================================================
                doc.Add(new Paragraph("Evaluación Médica y Tratamiento", fuenteSeccion) { SpacingAfter = 6 });

                PdfPTable tablaDetalles = new PdfPTable(1);
                tablaDetalles.WidthPercentage = 100;

                AgregarBloqueTextoLargo(tablaDetalles, "Motivo del Ingreso / Consulta:", consulta.Motivo, fuenteTextoNegrita, fuenteTextoNormal);
                AgregarBloqueTextoLargo(tablaDetalles, "Diagnóstico Definitivo:", consulta.Diagnostico, fuenteTextoNegrita, fuenteTextoNormal);
                AgregarBloqueTextoLargo(tablaDetalles, "Tratamiento Recomendado / Receta:", consulta.Tratamiento, fuenteTextoNegrita, fuenteTextoNormal);

                doc.Add(tablaDetalles);

                // Cierre y guardado del archivo
                doc.Close();

                // 4. Ventana emergente interactiva para abrir el PDF al instante
                var res = MessageBox.Show($"¡Consulta registrada exitosamente en el sistema!\n¿Desea abrir la vista previa del archivo PDF creado?",
                                          "Comprobante PDF Listo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (res == DialogResult.Yes)
                {
                    // Lanza el lector predeterminado de PDFs del sistema de inmediato
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(rutaCompleta) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un inconveniente al armar la estructura interna del PDF: " + ex.Message, "Error Reporte");
            }
        }

        // =========================================================================
        // MÉTODOS DE SOPORTE DISEÑO (Evitan repetir código de celdas)
        // =========================================================================
        private static void AgregarCelda(PdfPTable tabla, string texto, Font fuente, BaseColor fondo)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, fuente));
            celda.BackgroundColor = fondo;
            celda.Border = PdfPCell.BOTTOM_BORDER;
            celda.BorderColor = BaseColor.LIGHT_GRAY;
            celda.Padding = 6;
            tabla.AddCell(celda);
        }

        private static void AgregarCeldaCentro(PdfPTable tabla, string texto, Font fuente, BaseColor fondo)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, fuente));
            celda.BackgroundColor = fondo;
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.Padding = 6;
            tabla.AddCell(celda);
        }

        private static void AgregarBloqueTextoLargo(PdfPTable tabla, string titulo, string contenido, Font fuenteTitulo, Font fuenteCuerpo)
        {
            PdfPCell celda = new PdfPCell();
            celda.Padding = 8;
            celda.BorderColor = BaseColor.LIGHT_GRAY;
            celda.AddElement(new Paragraph(titulo, fuenteTitulo) { SpacingAfter = 3 });
            celda.AddElement(new Paragraph(string.IsNullOrWhiteSpace(contenido) ? "No especificado por el médico." : contenido, fuenteCuerpo));
            tabla.AddCell(celda);
        }
    }
}
