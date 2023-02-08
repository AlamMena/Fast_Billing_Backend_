using API.DbModels.Core;

namespace API.DbModels.Errors
{
    public class Error : CoreModel
    {
        public string Message { get; set; } = null!;
        public string Exception { get; set; } = null!;
    }
}