using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{

    public class TriggerSymptom
    {
        [Key]
        public int TriggerSymptomID {get; set;}

        [Required]
        public int TriggerID { get; set; }

        public virtual Trigger Trigger { get; set; }

        [Required]
        public int SymptomID { get; set; }

        public virtual Symptom Symptom { get; set; }
        
        [Required]
        public bool Acute { get; set; }

        [Required]
        public bool Chronic { get; set; }

    }
}