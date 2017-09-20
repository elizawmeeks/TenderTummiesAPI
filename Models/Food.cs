using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
 
namespace TenderTummiesAPI.Models
{
    //Symptom model. Includes name of the symptom.
    public class Food
    {
        [Key]
        public int FoodID {get; set;}
        
        [Required]
        public string Name { get; set; }

        public ICollection<Trial> Trials { get; set; }
        public ICollection<Trigger> Triggers { get; set; }

        public ICollection<Safe> Safes { get; set; }

    }
}