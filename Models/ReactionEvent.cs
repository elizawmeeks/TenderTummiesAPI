using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{

    public class ReactionEvent
    {
        [Key]
        public int ReactionEventID {get; set;}

        [Required]
        public int ReactionID { get; set; }

        public int TrialID { get; set; }
        
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