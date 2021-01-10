using DynamicForms.Entity;
using System.Data.Entity;

namespace DynamicForms.DataAccess
{
    public class DynamicFormsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Field> Fields { get; set; }
    }
}