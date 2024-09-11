using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OficioPersuasivoPenalizable.Entities;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;

namespace OficioPersuasivoPenalizable.Services
{
    public class PdfReader
    {
        public PdfDocument document;

        public List<string> ReadPdf(string pdfPath)
        {
            List<string> lines = [];
            document = PdfDocument.Open(pdfPath);
            
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

        public List<Declaracion> GetDeclaracionList(List<string> lines)
        {

            List<Declaracion> declaracionList = [];

            int firstIndex = lines.IndexOf(StringIndexConstants.START_DECLARATION_STRING);
            int lastIndex = lines.IndexOf(StringIndexConstants.LAST_DECLARATION_STRING);

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

        public Contribuyente GetContribuyenteData(List<string> lines)
        {
            string nitPattern = @"([\d]{9})\s([\d])\s(.*)";
            string addressPattern = @"(.*\s)(\d{1,3}\s-\s.*)(\d{1,3}\s-\s.*)";
            Regex nitRegex = new(nitPattern);
            Regex addressRegex = new(addressPattern);

            //int recordAndProcessIndex = lines.IndexOf(StringIndexConstants.RECORD_STRING) + 1;
            int nitAndDivIndex = lines.IndexOf(StringIndexConstants.NIT_DV_STRING) + 1;
            int addressIndex = lines.IndexOf(StringIndexConstants.ADDRESS_STRING) + 1;

            Match nitMatch = nitRegex.Match(lines[nitAndDivIndex]);
            Match addressMatch = addressRegex.Match(lines[addressIndex]);

            Contribuyente contribuyente = new()
            {
                nit = nitMatch.Groups[1].Value,
                dv = nitMatch.Groups[2].Value,
                nombre = nitMatch.Groups[3].Value,
                direccion = addressMatch.Groups[1].Value,
                municipio = addressMatch.Groups[2].Value,
                departamento = addressMatch.Groups[3].Value
            };

            return contribuyente;
            
        }
    }
}
