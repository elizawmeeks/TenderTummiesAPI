using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{

    public class Safe
    {
        [Key]
        public int SafeID {get; set;}

        [Required]
        public int ChildID { get; set; }

        public virtual Child Child { get; set; }
        
        [Required]
        public string Food { get; set; }

    }
}