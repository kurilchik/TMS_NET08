using Microsoft.EntityFrameworkCore;

namespace Tasks.HW11
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable($"andrew.kurilchik@gmail.com_Bank.{nameof(User)}s");

                e.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

                e.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Transaction>(e =>
            {
                e.ToTable($"andrew.kurilchik@gmail.com_Bank.{nameof(Transaction)}s");

                e.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

                e.HasKey(x => x.Id);

                e.Property(x => x.Amount).IsRequired();

                e.Property(x => x.Date).IsRequired();

                e.HasOne(x => x.User).WithMany(x => x.Transactions).HasForeignKey(x => x.UserId);
            });
        }
    }
}
