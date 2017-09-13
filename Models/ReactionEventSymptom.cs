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

        [Required]
        public int SymptomID { get; set; }

    }
}