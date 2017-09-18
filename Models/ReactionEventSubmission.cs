using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // ReactionEvent symptom join table to keep track of the symptoms from each reaction event.
    public class ReactionEventSubmission
    {
        public int ReactionID { get; set; }

        public Nullable<int> TrialID { get; set; }

        public bool Acute { get; set; }

        public bool Chronic { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public List<int> SymptomIDs { get; set; }

    }
}