using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Model for Reaction trigger, to list the triggers in a certain reaction. 
    //Includes trigger and reaction that it's connected to.
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