using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{

    public class ReactionTrigger
    {
        [Key]
        public int ReactionTriggerID {get; set;}

        [Required]
        public int TriggerID { get; set; }

        public virtual Trigger Trigger { get; set; }

        [Required]
        public int ReactionID { get; set; }

        public virtual Reaction Reaction { get; set; }

    }
}