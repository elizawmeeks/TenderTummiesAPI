using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{

    public class Ingestion
    {
        [Key]
        public int IngestionID {get; set;}
        
        [Required]
        public string Name { get; set; }

        public ICollection<Reaction> Reactions { get; set; }

    }
}