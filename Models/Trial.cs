using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Trial model. Includes child, trigger, food, start/end dates, and whether or not the child passed.
    public class Trial
    {
        [Key]
        public int TrialID { get; set; }

        [Required]
        public int ChildID { get; set;}

        public virtual Child Child { get; set; }

        public Nullable<int> TriggerID { get; set; }

        public virtual Trigger Trigger { get; set; }

        [Required]
        public string Food { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }

        public bool Pass { get; set; }

        public ICollection<ReactionEvent> ReactionEvents { get; set; }
        public ICollection<TrialEvent> TrialEvents { get; set; }

    }
}