using API.DbModels.Core;

namespace API.DbModels.Ncf
{
    public class NcfType : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Prefix { get; set; } = null!;
    }
}
