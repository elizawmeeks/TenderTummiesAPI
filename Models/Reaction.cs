using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Model for Reaction. Includes child, ingestion, foodtype, start/end dates and description.
    public class Reaction
    {
        [Key]
        public int ReactionID { get; set; }

        [Required]
        public int ChildID {get; set;}

        public virtual Child Child {get; set; }

        [Required]
        public int IngestionID { get; set; }

        public virtual Ingestion Ingestion { get; set; }

        [Required]
        public string FoodType { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public ICollection<ReactionEvent> ReactionEvents { get; set; }
        public ICollection<ReactionTrigger> ReactionTriggers { get; set; }

    }
}