using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{

    public class Symptom
    {
        [Key]
        public int SymptomID {get; set;}
        
        [Required]
        public string Name { get; set; }

        public ICollection<ReactionEventSymptom> ReactionEventSymptoms { get; set; }
        public ICollection<TriggerSymptom> TriggerSymptoms { get; set; }

    }
}