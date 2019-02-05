using System;
using System.Collections.Generic;
using CQRS.Core;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Api
{
    internal class EfContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("football");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>().HasKey(x => x.Name);
            modelBuilder.Entity<Team>().HasData(TeamsInitialData());
        }

        private static IEnumerable<Team> TeamsInitialData()
        {
            var teamNames = new [] { "Bayern", "Borussia", "Eintracht", "Schalke", "Bayer", "Hertha", "Leipizg", "Hoffenheim", "Stuttgart", "Wolfsburg" };
            var random = new Random();

            for (var i = 0; i < 10; i++)
            {
                var team = new Team(teamNames[i]);
                for (var j = 0; j < 8; j++)
                {
                    team.InsertResult(random.Next(0, 5), random.Next(0, 5));
                }

                yield return team;
            }
        }
    }
}
