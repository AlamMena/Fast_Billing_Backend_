namespace API.Dtos.Reports.Core
{
    public class ReportByDate
    {
        public string Label { get; set; } = null!;
        public IEnumerable<ReportByDateDetail> Data { get; set; } = null!;
        public decimal Total { get; set; }
        public decimal IncreasePercentage { get; set; }
    }
}