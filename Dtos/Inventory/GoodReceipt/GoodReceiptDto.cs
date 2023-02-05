using API.Dtos.Core;
using API.Dtos.Payments;

namespace API.Dtos.Inventory.GoodReceipt
{
    public class GoodReceiptDto : CoreDto
    {
        public int TypeId { get; set; }
        public string? InvoiceNumber { get; set; }
        public int WareHouseId { get; set; }
        public int NcfTypeId { get; set; }
        public int CreditDates { get; set; }
        public int SupplierId { get; set; }
        public bool WithTax { get; set; }
        public decimal TotalGrab { get; set; }
        public decimal Total { get; set; }
        public decimal Disccount { get; set; }
        public decimal TotalPayed { get; set; }
        public string? Note { get; set; }
        public bool Updated { get; set; }
        public List<GoodReceiptDetailDto> Details { get; set; }
        public List<PaymentDto> Payments { get; set; }

        public GoodReceiptDto()
        {
            Details = new List<GoodReceiptDetailDto>();
            Payments = new List<PaymentDto>();
        }
    }
}
