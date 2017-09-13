using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{

    public class Trigger
    {
        [Key]
        public int TriggerID {get; set;}

        [Required]
        public string Food { get; set; }

        [Required]
        public int ChildID { get; set; }

        public virtual Child Child { get; set; }
        
        [Required]
        public string Severity { get; set; }

        public ICollection<TriggerSymptom> TriggerSymptoms { get; set; }
        public ICollection<ReactionTrigger> ReactionTrigger { get; set; }
        public ICollection<Trial> Trials { get; set; }
        
    }
}