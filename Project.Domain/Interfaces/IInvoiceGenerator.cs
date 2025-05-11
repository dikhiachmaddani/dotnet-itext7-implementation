using Project.Domain.Entities;

namespace Project.Domain.Interfaces
{
    public interface IInvoiceGenerator
    {
        Task<string> GenerateInvoiceAsync(string inputHtmlFile, Invoice invoice);
    }
}