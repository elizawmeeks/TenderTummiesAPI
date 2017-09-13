using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    // Model for Child. Includes UserID, name, weight, gender and age.
    public class Child
    {
        [Key]
        public int ChildID {get; set;}

        [Required]
        public string UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int WtNumber { get; set; }

        [Required]
        public string WtUnit { get; set; }

        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        public ICollection<Safe> Safes { get; set; }
        public ICollection<Trigger> Triggers { get; set; }
        public ICollection<Trial> Trials { get; set; }
        public ICollection<Reaction> Reactions { get; set; }

    }
}