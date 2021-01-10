using System.ComponentModel.DataAnnotations;

namespace DynamicForms.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}