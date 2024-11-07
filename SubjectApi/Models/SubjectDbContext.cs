using Microsoft.EntityFrameworkCore;

namespace SubjectApi.Models
{
    public class SubjectDbContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; } = null!;

        public SubjectDbContext() { }

        public SubjectDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "Server=localhost;Port=3306;Database=School;user=root;password=password";
                optionsBuilder.UseMySQL(conn);
            }
        }

    }
}
