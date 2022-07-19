using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabellaUsers.DataModel
{
    public class ModelContract
    {
        [Key]
        public int IdContract { get; set; }
        public string NameContract { get; set; }
        public ICollection<PivotUserContract>? Users { get; set; }
    }
}
