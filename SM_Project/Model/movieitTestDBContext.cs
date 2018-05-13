using Microsoft.EntityFrameworkCore;

namespace SM_Project.Model
{
    public partial class movieitTestDBContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Cinema> Cinema { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieCategory> MovieCategory { get; set; }
        public virtual DbSet<Reminder> Reminder { get; set; }
        public virtual DbSet<Seance> Seance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\szymonlocaldb;Database=movieitTestDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryGuid);

                entity.Property(e => e.CategoryGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.CinemaGuid);

                entity.Property(e => e.CinemaGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.DirectorGuid);

                entity.Property(e => e.DirectorGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieGuid);

                entity.Property(e => e.MovieGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FirstNight).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.DirectorGu)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.DirectorGuid)
                    .HasConstraintName("FK__Movie__DirectorG__3AD6B8E2");
            });

            modelBuilder.Entity<MovieCategory>(entity =>
            {
                entity.HasKey(e => e.MovieCategoryGuid);

                entity.Property(e => e.MovieCategoryGuid).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.CategoryGu)
                    .WithMany(p => p.MovieCategory)
                    .HasForeignKey(d => d.CategoryGuid)
                    .HasConstraintName("FK__MovieCate__Categ__3EA749C6");

                entity.HasOne(d => d.MovieGu)
                    .WithMany(p => p.MovieCategory)
                    .HasForeignKey(d => d.MovieGuid)
                    .HasConstraintName("FK__MovieCate__Movie__3F9B6DFF");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.HasKey(e => e.ReminderGuid);

                entity.Property(e => e.ReminderGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.NotifyDate).HasColumnType("datetime");

                entity.HasOne(d => d.MovieGu)
                    .WithMany(p => p.Reminder)
                    .HasForeignKey(d => d.MovieGuid)
                    .HasConstraintName("FK__Reminder__MovieG__436BFEE3");
            });

            modelBuilder.Entity<Seance>(entity =>
            {
                entity.HasKey(e => e.SeanceGuid);

                entity.Property(e => e.SeanceGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ShowDate).HasColumnType("datetime");

                entity.HasOne(d => d.CinemaGu)
                    .WithMany(p => p.Seance)
                    .HasForeignKey(d => d.CinemaGuid)
                    .HasConstraintName("FK__Seance__CinemaGu__4B0D20AB");

                entity.HasOne(d => d.MovieGu)
                    .WithMany(p => p.Seance)
                    .HasForeignKey(d => d.MovieGuid)
                    .HasConstraintName("FK__Seance__MovieGui__4A18FC72");
            });
        }
    }
}
