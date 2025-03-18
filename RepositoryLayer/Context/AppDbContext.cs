using Microsoft.EntityFrameworkCore;
using AddressBook.RepositoryLayer.Entity; 

namespace AddressBook.RepositoryLayer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<AddressBookEntry> AddressBookEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
