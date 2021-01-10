using System.ComponentModel.DataAnnotations;

namespace DynamicForms.Entity
{
    public class Field
    {
        [Key]
        public int Id { get; set; }

        public bool Required { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }

        public int FormId { get; set; }
        public Form Form { get; set; }
    }
}