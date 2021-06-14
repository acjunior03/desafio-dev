using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ContextDesafioDev : DbContext
    {
        public ContextDesafioDev(DbContextOptions<ContextDesafioDev> options) : base(options)
        {
        }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionDescription> TransactionDescription { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasKey(x => x.Id);
            modelBuilder.Entity<TransactionDescription>().HasKey(x => x.Id);
        }
    }
}
