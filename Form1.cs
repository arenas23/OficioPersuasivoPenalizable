using OficioPersuasivoPenalizable.Entities;
using System.Collections;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;
using UglyToad.PdfPig.Graphics;

namespace OficioPersuasivoPenalizable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string pdfPath;
           

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pdfPath = openFileDialog1.FileName;

                
            }
        }

        private void ExtractInfo(string pdfPath)
        {
            List<string> textLines = [];
            List<Declaracion> taxesLines = [];

            textLines = ReadPdf(pdfPath);
            GetDeclaracionList(textLines);
        }

        private bool CompareString(string validator, string text)
        {
            return validator.ToLower().Equals(text.ToLower());
        }

        private List<string> ReadPdf(string pdfPath)
        {
            List<string> lines = [];
            using (var document = PdfDocument.Open(pdfPath))
            {
                for (var i = 0; i < document.NumberOfPages; i++)
                {
                    var page = document.GetPage(i + 1);
                    var words = page.GetWords();
                    var blocks = DefaultPageSegmenter.Instance.GetBlocks(words);
                    foreach (var line in blocks[0].TextLines)
                    {
                        lines.Add(line.Text);
                    }

                }
                return lines;
            }
        }
        private List<Declaracion> GetDeclaracionList(List<string> lines)
        {
            const string FIRST_SENTENCE = "Fecha Concepto Período Impuesto ($)";
            const string LAST_SENTENCE = "Total ($) :";
            List<Declaracion> declaracionList = [];

            int firstIndex = lines.IndexOf(FIRST_SENTENCE);
            int lastIndex = lines.IndexOf(LAST_SENTENCE);

            if (firstIndex == -1 && lastIndex == -1)
            {
                throw new Exception("No se identifico el inicio de la tabla o el final");
            }

            for (int i = firstIndex + 1; i < lastIndex - 1; i++)
            {
                string[] declaracionParts = lines[i].Split(' ');
                declaracionList.Add(
                    new Declaracion
                    {
                        numero = declaracionParts[0],
                        tipo = declaracionParts[1],
                        fecha = declaracionParts[2],
                        concepto = declaracionParts[3],
                        anio = declaracionParts[4],
                        periodo = declaracionParts[5],
                        impuesto = declaracionParts[6],
                        sancion = declaracionParts[7]
                    }
                ); 
            }

            return declaracionList;
        }
    }
}
