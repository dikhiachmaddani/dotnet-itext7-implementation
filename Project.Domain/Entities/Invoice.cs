namespace Project.Domain.Entities
{
    public class ItemInvoice
    {
        public required string MaterialName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmountIDR { get; set; }
        public decimal TotalAmountUSD { get; set; }
    }

    public class Invoice
    {
        public required string InvoiceNo { get; set; }
        public required List<ItemInvoice> Items { get; set; }
    }
}
