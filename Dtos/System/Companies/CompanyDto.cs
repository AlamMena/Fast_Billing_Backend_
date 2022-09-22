using API.Dtos.Core;

namespace API.Dtos.System.Companies
{
    public class CompanyDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string NoIdentification { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Location { get; set; } = null!;
    }
}