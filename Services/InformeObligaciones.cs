using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OficioPersuasivoPenalizable.Entities;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace OficioPersuasivoPenalizable.Services
{
    public class InformeObligaciones:IDocument
    {
        public PdfReport Model { get;}

        public InformeObligaciones(PdfReport model)
        {
            Model = model;
        }
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4); // Tamaño A4
                page.Margin(2, Unit.Centimetre); // Márgenes de 2 cm
                /*         page.Header().AlignCenter().Text("INFORME DE OBLIGACIONES PENALIZABLES").FontSize(20).Bold();*/ // Encabezado principal

                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                        columns.RelativeColumn(1);
                    });

                    table.Cell().ColumnSpan(4).Column(column =>
                    {
                        column.Item().Text("INFORME DE OBLIGACIONES PENALIZABLES").AlignCenter();
                        column.Item().Text("FECHA ACTO 09").AlignCenter();
                    });

                    table.Cell().Column(column =>
                    {
                        column.Item().Text("N° Expediente:");
                        column.Item().Text("200002200");
                    });

                    table.Cell().Column(column =>
                    {
                        column.Item().Text("N° Proceso:");
                        column.Item().Text("1");
                    });

                    table.Cell().Column(column =>
                    {
                        column.Item().Text("Administración:");
                        column.Item().Text("11 – MEDELLÍN");
                    });

                    table.Cell().Column(column =>
                    {
                        column.Item().Text("Dependencia:");
                        column.Item().Text("272 – RECAUDO Y COBRANZAS");
                    });

                    table.Cell().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                        });

                        table.Cell().Column(column =>
                        {
                            column.Item().Text("NIT:");
                            column.Item().Text("800101425");
                        });

                        table.Cell().Column(column =>
                        {
                            column.Item().Text("DV:");
                            column.Item().Text("2");
                        });

                    });

                    table.Cell().ColumnSpan(3).Column(column =>
                    {
                        column.Item().Text("Apellidos y nombres o razón social completa:");
                        column.Item().Text("INDUSTRIAS PETALO S.A.S.");
                    });

                    table.Cell().ColumnSpan(2).Column(column =>
                    {
                        column.Item().Text("Dirección:");
                        column.Item().Text("CL 37 38 A 20");
                    });

                    table.Cell().Column(column =>
                    {
                        column.Item().Text("Municipio:");
                        column.Item().Text("360 - ITAGUI");
                    });

                    table.Cell().Column(column =>
                    {
                        column.Item().Text("Departamento:");
                        column.Item().Text("5 - ANTIOQUIA");
                    });

                    table.Cell().ColumnSpan(4).Text("Dando cumplimiento a las órdenes administrativas 007 de 2000 y 004 de 2004 que " +
                        "señalan los requisitos y el procedimiento en materia de denuncias penales, se elabora informe del " +
                        "contribuyente de la referencia con obligaciones de impuesto sobre las ventas y retención en la fuente sin " +
                        "cancelar:"
                    );

                    table.Cell().ColumnSpan(4).Text("1. RELACIÓN DE OBLIGACIONES SIN CANCELAR:").Bold();

                    table.Cell().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(1);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("Concepto");
                            header.Cell().Text("Año");
                            header.Cell().Text("Período");
                            header.Cell().Text("Impuesto ($)");
                            header.Cell().Text("Sanción Actualizada ($)");
                        });

                        foreach (var item in Model.declaracion)
                        {
                            table.Cell().Text(item.concepto);
                            table.Cell().Text(item.anio);
                            table.Cell().Text(item.periodo);
                            table.Cell().Text(item.impuesto);
                            table.Cell().Text(item.sancion);
                        }
                    });

                });
            });
        }

    }
}
