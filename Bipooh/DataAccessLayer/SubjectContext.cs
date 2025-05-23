using Microsoft.EntityFrameworkCore;

namespace Bipooh.DataAccessLayer
{
    public class SubjectContext : DbContext
    {
        public SubjectContext(DbContextOptions<SubjectContext> options)
: base(options)
        {
        }

        public DbSet<Subject> SubjectsItems { get; set; } = null!;

    }
}
