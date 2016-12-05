namespace WamesRepository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WamesModel : DbContext
    {
        public WamesModel()
            : base("name=WamesDBModel")
        {
        }

        public virtual DbSet<availablePlatforms> availablePlatforms { get; set; }
        public virtual DbSet<departments> departments { get; set; }
        public virtual DbSet<employees> employees { get; set; }
        public virtual DbSet<games> games { get; set; }
        public virtual DbSet<genre> genre { get; set; }
        public virtual DbSet<headquarters> headquarters { get; set; }
        public virtual DbSet<positions> positions { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<availablePlatforms>()
                .Property(e => e.platformId)
                .IsUnicode(false);

            modelBuilder.Entity<availablePlatforms>()
                .Property(e => e.platformName)
                .IsUnicode(false);

            modelBuilder.Entity<departments>()
                .Property(e => e.department_name)
                .IsUnicode(false);

            modelBuilder.Entity<departments>()
                .HasMany(e => e.employees)
                .WithRequired(e => e.departments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employees>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<employees>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<employees>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employees>()
                .Property(e => e.salary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<games>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<games>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<games>()
                .HasMany(e => e.availablePlatforms)
                .WithMany(e => e.games)
                .Map(m => m.ToTable("gamePlatform").MapLeftKey("gameId").MapRightKey("platformId"));

            modelBuilder.Entity<genre>()
                .Property(e => e.genre_name)
                .IsUnicode(false);

            modelBuilder.Entity<genre>()
                .HasMany(e => e.games)
                .WithRequired(e => e.genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<headquarters>()
                .Property(e => e.headquarters_name)
                .IsUnicode(false);

            modelBuilder.Entity<headquarters>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<headquarters>()
                .HasMany(e => e.departments)
                .WithRequired(e => e.headquarters)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<positions>()
                .Property(e => e.position_name)
                .IsUnicode(false);

            modelBuilder.Entity<positions>()
                .HasMany(e => e.employees)
                .WithRequired(e => e.positions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.team_name)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.employees)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.games)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);
        }
    }
}
