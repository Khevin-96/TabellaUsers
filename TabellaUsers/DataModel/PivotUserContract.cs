using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TabellaUsers.DataModel
{


    //Questa Model non verrà migrata perchè le tabelle many to many vengono create automaticamente
    //quando crei le rispettive ICollection con le proprie ForeignKey nei loro rispettivi model
    //ed avvi la migration
    public class PivotUserContract
    {
        public ModelUsers user { get; set; }
        public int User_id { get; set; }
        public ModelContract contract { get; set; }
        public int Contract_id { get; set; }

    }
}
