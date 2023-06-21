using Microsoft.EntityFrameworkCore;
using NoteNozdrinEdition.Configuration;
using NoteNozdrinEdition.Models;

namespace NoteNozdrinEdition.Data
{
    public class NoteDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-QHR1LI1\MSSQLSERVERR; Database = noteBase; Integrated Security = true;Trusted_Connection = true; TrustServerCertificate = true; MultipleActiveResultSets = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
