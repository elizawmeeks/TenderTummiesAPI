using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Safe model. Includes child and the food that is safe.
    public class Safe
    {
        [Key]
        public int SafeID {get; set;}

        [Required]
        public int ChildID { get; set; }

        public virtual Child Child { get; set; }
        
        [Required]
        public int FoodID { get; set; }

        public virtual Food Food { get; set; }

    }
}