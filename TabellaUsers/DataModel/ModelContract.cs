using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabellaUsers.DataModel
{
    public class ModelContract
    {
        [Key]
        public int IdContract { get; set; }
        public string NameContract { get; set; }



        //Definisco la variabile foreignKey di User_Id su ModelUsers 

        public ICollection<PivotUserContract> Users { get; set; }
    }
}
