using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.Domain;

namespace StudentPortal.Data
{
    public class StudentPortalDbContext : DbContext
    {
        public StudentPortalDbContext(DbContextOptions<StudentPortalDbContext> options):base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
