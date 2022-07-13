using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TabellaUsers.DataModel
{
    public class ModelUsers
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public int? Azienda_Id { get; set; }
     
        public virtual ModelAzienda? Azienda { get; set; }


        //Definisco la variabile foreignKey di Contact_Id su ModelContract 

        public ICollection<PivotUserContract> Contracts { get; set; }

    }
}
