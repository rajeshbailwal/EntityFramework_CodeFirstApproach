using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAO_EFCORE.DAL.Models
{
    public class Note
    {
        //To-Do define Note Entity
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NoteId { get; set; }
        public string Title { get; set; }
        public string NoteType { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        //Navigation property
        [JsonIgnore]
        public virtual ICollection<Checklist> ListItems { get; set; }

        [JsonIgnore]
        public virtual ICollection<Label> Labels { get; set; }
    }
}
