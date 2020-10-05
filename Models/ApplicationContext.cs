using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cipherNg.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ReplacementRule> replacementRules { get; set; }
        public DbSet<EnctiptionLog> enctiptionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ReplacementRule firstRule = new ReplacementRule {Id = 1, OldSymbol = 'a', NewSymbol = 'x' };
            ReplacementRule secondRule = new ReplacementRule {Id = 2, OldSymbol = 'e', NewSymbol = '8' };
            ReplacementRule thirdRule = new ReplacementRule {Id = 3, OldSymbol = 'l', NewSymbol = 'q' };

            modelBuilder.Entity<ReplacementRule>().HasData(new ReplacementRule[] { firstRule, secondRule, thirdRule });

            base.OnModelCreating(modelBuilder);
        }

    }
}
