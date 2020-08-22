using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SJ.One_Core.Data.Config;
using SJ.One_Core.Models;

namespace SJ.One_Core.Data
{
    public class SJOneContext : IdentityDbContext<User>
    {
        internal SJOneContext()
        {
        }

        public DbSet<AutoTiming> AutoTimings { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<EventImage> EventImages { get; set; }
        public DbSet<HandTiming> HandTimings { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SportClub> SportClubs { get; set; }
        public DbSet<SportEvent> SportEvents { get; set; }
        public DbSet<StartNumber> StartNumbers { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public SJOneContext(DbContextOptions<SJOneContext> options)
           : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AgeGroup_RaceConfiguration());
            modelBuilder.ApplyConfiguration(new AgeGroupConfiguration());
            modelBuilder.ApplyConfiguration(new AutoTimingConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentConfiguration());
            modelBuilder.ApplyConfiguration(new Event_TagConfiguration());
            modelBuilder.ApplyConfiguration(new EventImageConfiguration());
            modelBuilder.ApplyConfiguration(new HandTimingConfiguration());
            modelBuilder.ApplyConfiguration(new LocalityConfiguration());
            modelBuilder.ApplyConfiguration(new ProtocolConfiguration());
            modelBuilder.ApplyConfiguration(new RaceConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new SportClubConfiguration());
            modelBuilder.ApplyConfiguration(new SportEventConfiguration());
            modelBuilder.ApplyConfiguration(new StartNumbertConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new User_RaceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
