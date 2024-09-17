using OficioPersuasivoPenalizable.Entities;
using OficioPersuasivoPenalizable.Services;
using System.Collections;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

namespace OficioPersuasivoPenalizable
{
    public partial class Form1 : Form
    {
        PdfReader pdfReader;
        PdfReport report;
        PdfCreator pdfCreator;
        public Form1()
        {
            InitializeComponent();
            pdfReader = new();
            report = new();
            pdfCreator = new();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
              
            try
            {
                pdfCreator.CreateDocument();
            }
            catch (Exception)
            {

                throw;
            }
         
            //string pdfPath;

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    pdfPath = openFileDialog1.FileName;
            //    ExtractInfo(pdfPath);
            //}
        }

        private void ExtractInfo(string pdfPath)
        {
            List<string> textLines = [];
            string[] recordAndProcess;

            textLines = pdfReader.ReadPdf(pdfPath);
            report.declaracion = pdfReader.GetDeclaracionList(textLines);
            report.contribuyente = pdfReader.GetContribuyenteData(textLines);
            report.total = pdfReader.GetTotalDeclaracion(textLines);
            recordAndProcess = pdfReader.GetRecordAndProcess(textLines);
            report.expediente = recordAndProcess[0];
            report.proceso = recordAndProcess[1];
        }

    }
}
