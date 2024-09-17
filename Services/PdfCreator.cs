using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace OficioPersuasivoPenalizable.Services
{
    public class PdfCreator
    {
        public void CreateDocument()
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    // page content
                    page.Size(PageSizes.A4);
                    
                });
            })
            .ShowInPreviewerAsync();
        }
    }
}
