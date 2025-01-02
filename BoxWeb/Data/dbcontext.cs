using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BoxContext : DbContext
    {
        public BoxContext(DbContextOptions<BoxContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coach>()
               .HasOne(cl => cl.Club)
               .WithMany(co => co.Coaches)
               .HasForeignKey(cl => cl.ClubID)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Sportsman>()
               .HasOne(cl => cl.Club)
               .WithMany(sp => sp.Sportsmen)
               .HasForeignKey(cl => cl.ClubID)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Tournament>()
              .HasOne(re => re.Refeere)
              .WithMany(to => to.Tournament)
              .HasForeignKey(re => re.RefeereID)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Fight>()
              .HasOne(to => to.Tournament)
              .WithMany(fi => fi.Fight)
              .HasForeignKey(to => to.TournamentID)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<SF>()
               .HasOne(sp => sp.sportsman)
               .WithMany()
               .HasForeignKey(sp => sp.SportsmanID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SF>()
               .HasOne(fi => fi.fight)
               .WithMany()
               .HasForeignKey(fi => fi.FightID)
               .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Sportsman> Sportmen { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Fight> Fights { get; set; }
        public DbSet<Refeere> Refeeres { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<SF> SFs { get; set; }
    }
}
