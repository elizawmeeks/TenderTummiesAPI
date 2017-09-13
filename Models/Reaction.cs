using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{

    public class Reaction
    {
        [Key]
        public int ReactionID { get; set; }

        [Required]
        public int ChildID {get; set;}

        [Required]
        public int IngestionID { get; set; }

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