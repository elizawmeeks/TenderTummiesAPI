using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Model for events in trials. Includes the trial it's connected to, the quantity and food type, and the date/time.
    public class TrialEvent
    {
        [Key]
        public int TrialEventID { get; set; }

        [Required]
        public int TrialID { get; set;}

        public virtual Trial Trial { get; set; }

        [Required]
        public string Quantity { get; set; }

        [Required]
        public string FoodType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

    }
}