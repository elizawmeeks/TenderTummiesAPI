using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Trigger symptom join table to keep track of the symptoms from each trigger.
    // Includes trigger and symptoms, and whether it's a chronic or acute symptom.
    public class TriggerSymptomSubmission
    {
        
        [Required]
        public int SymptomID { get; set; }
        
        [Required]
        public bool Acute { get; set; }

        [Required]
        public bool Chronic { get; set; }

    }
}