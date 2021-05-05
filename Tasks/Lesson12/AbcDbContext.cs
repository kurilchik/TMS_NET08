using Microsoft.EntityFrameworkCore;

namespace Tasks.Lesson12
{
    public class AbcDbContext : DbContext
    {
        public AbcDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<A>(e =>
            {
                e.ToTable($"andrew.kurilchik@gmail.com_Abc.{nameof(A)}");

                e.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

                e.HasKey(x => x.Id);

                e.Property(x => x.Value).IsRequired();

                e.Property(x => x.Date).IsRequired();
            });

            modelBuilder.Entity<B>(e =>
            {
                e.ToTable($"andrew.kurilchik@gmail.com_Abc.{nameof(B)}");

                e.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

                e.HasKey(x => x.Id);

                e.Property(x => x.Date).IsRequired();
            });
        }
    }
}
