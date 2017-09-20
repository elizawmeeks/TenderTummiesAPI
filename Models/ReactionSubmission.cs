using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Reaction symptom join table to keep track of the symptoms from each reaction.
    public class ReactionSubmission
    {
        public int ChildID {get; set; }
        public int IngestionID { get; set; }
        public string FoodType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }
        public string Description { get; set; }

        public List<int> TriggerIDs { get; set; }

    }
}