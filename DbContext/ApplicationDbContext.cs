using DemoEfCoreKhanhPhong.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEfCoreKhanhPhong.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enroll> Enrolls { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}