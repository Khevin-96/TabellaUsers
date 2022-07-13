using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabellaUsers.DataModel
{
    public class ModelAzienda
    {
        [Key]
        public int IdAzienda { get; set; }
        public string NameAzienda { get; set; }


        //Definisco la variabile foreignKey di Azienda_Id su ModelUsers 
        [ForeignKey("Azienda_Id")]
        public ICollection<ModelUsers>? Users { get; set; }
    }
}
