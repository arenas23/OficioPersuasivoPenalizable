using OficioPersuasivoPenalizable.Entities;
using System.Collections;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

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
            string pdfPath = "";
            string text = "";
            const string FIRST_SENTENCE = "Fecha Concepto Período Impuesto ($)";
            const string LAST_SENTENCE = "Total ($) :";
            int firstIndex;
            int lastIndex;
            List<string> lines = new();
            List<Declaracion> taxesLines = new();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pdfPath = openFileDialog1.FileName;

                using (var document = PdfDocument.Open(pdfPath))
                {
                    for (var i = 0; i < document.NumberOfPages; i++)
                    {
                        var page = document.GetPage(i + 1);
                        var words = page.GetWords();
                        //var blocks = DocstrumBoundingBoxes.Instance.GetBlocks(words);
                        var blocks = DefaultPageSegmenter.Instance.GetBlocks(words);
                        foreach (var line in blocks[0].TextLines)
                        {
                            lines.Add(line.Text);
                        }
                        
                    }

                    firstIndex = lines.IndexOf(FIRST_SENTENCE);
                    lastIndex = lines.IndexOf(LAST_SENTENCE);

                    if (firstIndex != -1 && lastIndex != -1)
                    {
                        firstIndex++;
                        lastIndex--;

                        taxesLines = GetDeclaracionList(firstIndex, lastIndex, lines);
                    }else
                    {
                        throw new Exception("No se identifico el inicio de la tabla o el final");
                    }


                }
            }
        }

        private bool CompareString(string validator, string text)
        {
            return validator.ToLower().Equals(text.ToLower());
        }

        private List<Declaracion> GetDeclaracionList(int startIndex,int lastIndex, List<string> text)
        {
            List<Declaracion> declaracionList = new();
            for(int i = startIndex; i < lastIndex; i++)
            {
                string[] declaracionParts = text[i].Split(' ');
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
