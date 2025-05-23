using Microsoft.EntityFrameworkCore;

namespace Bipooh.DataAccessLayer
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
       : base(options)
        {
        }

        public DbSet<Student> StudentItems { get; set; } = null!;

    }
}
