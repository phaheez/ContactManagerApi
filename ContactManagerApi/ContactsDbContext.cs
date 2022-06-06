using ContactManagerApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactManagerApi
{
    public class ContactsDbContext: DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options) { }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>().ToTable("RefreshToken");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Designation>().ToTable("Designation");
        }
    }
}
