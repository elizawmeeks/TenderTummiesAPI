using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Model for Reaction events. Includes reaction, trial (if relevant), acute/chronic, description and date/time.
    public class ReactionEvent
    {
        [Key]
        public int ReactionEventID {get; set;}

        [Required]
        public int ReactionID { get; set; }

        public virtual Reaction Reaction { get; set; }

        public Nullable<int> TrialID { get; set; }

        public virtual Trial Trial { get; set; }
        
        [Required]
        public bool Acute { get; set; }

        [Required]
        public bool Chronic { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        public ICollection<ReactionEventSymptom> ReactionEventSymptoms { get; set; }
    }
}