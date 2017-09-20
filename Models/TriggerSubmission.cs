using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Trigger symptom join table to keep track of the symptoms from each trigger.
    // Includes trigger and symptoms, and whether it's a chronic or acute symptom.
    public class TriggerSubmission
    {
        [Required]
        public int FoodID { get; set; }

        [Required]
        public int ChildID { get; set; }

        [Required]
        public string Severity { get; set; }

        [Required]
        public TriggerSymptomSubmission[] TriggerSymptomSubmissions { get; set; }

    }
}