using HeroWiki.Shared.Models;
using HeroWiki_Console;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HeroWiki.Shared.Data.DB
{
    public class HeroWikiContext : DbContext
    {
        public DbSet<Hero> Hero { get; set; }
        public DbSet<Power> Power { get; set; }
        public DbSet<League> League { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HeroWiki_BD_V0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>().HasMany(c => c.Leagues).WithMany(c => c.Heros);
        }
    }
}