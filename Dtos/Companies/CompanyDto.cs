using API.Dtos.Core;

public class CompanyDto : CoreDto
{
    public string Name { get; set; } = null!;
    public string NoIdentification { get; set; } = null!;
    public string? PostalCode { get; set; }
    public string Location { get; set; } = null!;
}