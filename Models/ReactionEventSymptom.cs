using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{

    public class ReactionEventSymptom
    {
        [Key]
        public int ReactionEventSymptomID {get; set;}

        [Required]
        public int ReactionEventID { get; set; }

        public virtual ReactionEvent ReactionEvent { get; set; }

        [Required]
        public int SymptomID { get; set; }

        public virtual Symptom Symptom { get; set; }

    }
}