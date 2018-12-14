using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAO_EFCORE.DAL.Models
{
    public class Checklist
    {
        //Define checklist entity
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ChecklistId { get; set; }
        public string Content { get; set; }
        public long NoteId { get; set; }

        //Navigation property
        public virtual Note Note { get; set; }
    }
}
