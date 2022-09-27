using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Ncf
{
    [Table("sales_ncf_sequences")]
    public class NcfSequence : TenantModel
    {
        public int NCFTypeId { get; set; }
        public NcfType NCFType { get; set; } = null!;
        //public string Renglon { get; set; } = null!;
        public int LastNumber { get; set; }
        public string Prefix { get; set; } = null!;
        public int Quantity { get; set; }
        public int SequenceSince { get; set; }
        public int SequenceUntil { get; set; }
        public int Alert { get; set; }
        public DateTime? ExiprationDate { get; set; }
    }
}
