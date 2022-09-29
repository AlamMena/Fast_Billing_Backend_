using API.Dtos.Core;

namespace API.Dtos.Sales.Clients
{
    public class ClientContactDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string Number { get; set; } = null!;
    }
}
