using Project.Domain.Interfaces;
using Project.Domain.Entities;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Threading.Tasks;

namespace Project.Infrastructure.Repositories
{
    public class InvoiceGenerator : IInvoiceGenerator
    {
        public async Task<string> GenerateInvoiceAsync(string inputHtmlFile, Invoice invoice)
        {
            try
            {
                string htmlContent = await File.ReadAllTextAsync(inputHtmlFile);
                var replacements = GetPropertyReplacements(invoice);
                foreach (var replacement in replacements)
                {
                    htmlContent = htmlContent.Replace($"{{{{{replacement.Key}}}}}", replacement.Value);
                }
                var itemRows = new StringBuilder();
                for (int i = 0; i < invoice.Items.Count; i++)
                {
                    itemRows.AppendLine($@"
                    <tr>
                        <td class='table-cell table-cell-border-bottom text-sm'>{i+1}</td>
                        <td class='table-cell table-cell-border-bottom text-sm'>{invoice.Items[i].MaterialName}</td>
                        <td class='table-cell table-cell-border-bottom text-sm'>{invoice.Items[i].Qty}</td>
                        <td class='table-cell table-cell-border-bottom text-right text-sm'>{invoice.Items[i].TotalAmountUSD}</td>
                        <td class='table-cell table-cell-border-bottom text-right text-sm'>{invoice.Items[i].TotalAmountIDR}</td>
                    </tr>");
                }
                htmlContent = htmlContent.Replace("{{item_rows}}", itemRows.ToString());
                string outputPdfFile = Path.Combine(Directory.GetCurrentDirectory(), "assets/itext7-output.pdf");
                using (var writer = new PdfWriter(outputPdfFile))
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);
                    document.SetMargins(0, 0, 0, 0);
                    var converterProperties = new ConverterProperties();
                    using (var htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(htmlContent)))
                    {
                        await Task.Run(() => HtmlConverter.ConvertToPdf(htmlStream, pdf, converterProperties));
                    }
                }
                return outputPdfFile;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error generating PDF: {ex.Message}", ex);
            }
        }

        private Dictionary<string, string> GetPropertyReplacements(Invoice invoice)
        {
            var replacements = new Dictionary<string, string>();
            replacements.Add("invoice_no", invoice.InvoiceNo);
            return replacements;
        }
    }
}
