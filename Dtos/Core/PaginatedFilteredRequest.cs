namespace API.Dtos.Core
{

    public class PaginatedFilteredRequest
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string? Value { get; set; }
    }
}