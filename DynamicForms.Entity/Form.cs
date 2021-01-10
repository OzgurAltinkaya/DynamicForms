using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicForms.Entity
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public User User { get; set; }


        public ICollection<Field> Fields { get; set; }
    }
}