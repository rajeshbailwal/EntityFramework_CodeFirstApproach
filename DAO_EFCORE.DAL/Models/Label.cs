using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAO_EFCORE.DAL.Models
{
    public class Label
    {
        //Define Label entity
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }
        public string Content { get; set; }
        public long NoteId { get; set; }

        //Navigation property
        public virtual Note Note { get; set; }
    }
}
