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
                        //foreach (var line in blocks[0].TextLines)
                        //{
                        //    text += line.Text;
                        //}
                        rchTxtBxInfo.Text += blocks[0].TextLines[21].Text;
                    }
                        
                }
            }
        }
    }
}
