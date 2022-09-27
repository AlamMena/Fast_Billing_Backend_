using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Ncf
{
    [Table("sales_ncf_types")]
    public class NcfType : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Prefix { get; set; } = null!;
    }
}
