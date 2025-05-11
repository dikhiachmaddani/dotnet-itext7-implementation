using Project.Application.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces;

namespace Project.Application.UseCases;

public class GenerateInvoiceUseCase : IGenerateInvoiceUseCase
{
    private readonly IInvoiceGenerator _invoiceGenerator;

    public GenerateInvoiceUseCase(IInvoiceGenerator invoiceGenerator)
    {
        _invoiceGenerator = invoiceGenerator;
    }

    public async Task<string> ExecuteAsync()
    {
        try
        {
            Invoice invoice = new Invoice
            {
                InvoiceNo = "RON-001",
                Items = new List<ItemInvoice>
                {
                    new ItemInvoice
                    {
                        MaterialName = "Cobalt Ore",
                        Qty = 2,
                        Price = 5000,
                        TotalAmountIDR = 10000,
                        TotalAmountUSD = 10000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Nickel Ore",
                        Qty = 3,
                        Price = 7500,
                        TotalAmountIDR = 22500,
                        TotalAmountUSD = 22500
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Copper Ore",
                        Qty = 4,
                        Price = 6000,
                        TotalAmountIDR = 24000,
                        TotalAmountUSD = 24000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Iron Ore",
                        Qty = 5,
                        Price = 4500,
                        TotalAmountIDR = 22500,
                        TotalAmountUSD = 22500
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Gold Ore",
                        Qty = 1,
                        Price = 15000,
                        TotalAmountIDR = 15000,
                        TotalAmountUSD = 15000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Silver Ore",
                        Qty = 2,
                        Price = 8000,
                        TotalAmountIDR = 16000,
                        TotalAmountUSD = 16000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Platinum Ore",
                        Qty = 1,
                        Price = 12000,
                        TotalAmountIDR = 12000,
                        TotalAmountUSD = 12000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Palladium Ore",
                        Qty = 2,
                        Price = 9000,
                        TotalAmountIDR = 18000,
                        TotalAmountUSD = 18000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Rhodium Ore",
                        Qty = 1,
                        Price = 20000,
                        TotalAmountIDR = 20000,
                        TotalAmountUSD = 20000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Cobalt Ore",
                        Qty = 2,
                        Price = 5000,
                        TotalAmountIDR = 10000,
                        TotalAmountUSD = 10000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Nickel Ore",
                        Qty = 3,
                        Price = 7500,
                        TotalAmountIDR = 22500,
                        TotalAmountUSD = 22500
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Copper Ore",
                        Qty = 4,
                        Price = 6000,
                        TotalAmountIDR = 24000,
                        TotalAmountUSD = 24000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Iron Ore",
                        Qty = 5,
                        Price = 4500,
                        TotalAmountIDR = 22500,
                        TotalAmountUSD = 22500
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Gold Ore",
                        Qty = 1,
                        Price = 15000,
                        TotalAmountIDR = 15000,
                        TotalAmountUSD = 15000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Silver Ore",
                        Qty = 2,
                        Price = 8000,
                        TotalAmountIDR = 16000,
                        TotalAmountUSD = 16000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Platinum Ore",
                        Qty = 1,
                        Price = 12000,
                        TotalAmountIDR = 12000,
                        TotalAmountUSD = 12000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Palladium Ore",
                        Qty = 2,
                        Price = 9000,
                        TotalAmountIDR = 18000,
                        TotalAmountUSD = 18000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Rhodium Ore",
                        Qty = 1,
                        Price = 20000,
                        TotalAmountIDR = 20000,
                        TotalAmountUSD = 20000
                    },
                    new ItemInvoice
                    {
                        MaterialName = "Ruthenium Ore",
                        Qty = 3,
                        Price = 7000,
                        TotalAmountIDR = 21000,
                        TotalAmountUSD = 21000
                    }
                }
            };
            string inputHtmlFile = "assets/template-itext/Invoice.html";
            var pdfFilePath = await _invoiceGenerator.GenerateInvoiceAsync(inputHtmlFile, invoice);
            return pdfFilePath;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Failed to generate invoice", ex);
        }
    }
}