using Microsoft.EntityFrameworkCore;

namespace Tasks.Lesson10
{
    public class TikTokDbContext : DbContext
    {
        public TikTokDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable($"andrew.kurilchik@gmail.com_TikTo.{nameof(User)}");
                e.Property(x => x.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.HasKey(x => x.Id);
            });

            modelBuilder.Entity<UserVideos>(e =>
            {
                e.ToTable($"andrew.kurilchik@gmail.com_TikTo.{nameof(UserVideos)}");
                e.Property(x => x.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.HasKey(x => x.Id);

                e.Property(x => x.CreateAt)
                    .IsRequired();

                e.HasOne(x => x.User)
                    .WithMany(x => x.Videos)
                    .HasForeignKey(x => x.UserId);
            });

        }
    }
}
