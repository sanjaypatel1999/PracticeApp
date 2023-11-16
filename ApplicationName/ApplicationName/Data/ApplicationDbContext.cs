using ApplicationName.Models;
using ApplicationName.Models.Account;
using Microsoft.EntityFrameworkCore;


namespace ApplicationName.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Emp> Emps { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
