using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteNozdrinEdition.Models;

namespace NoteNozdrinEdition.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Note");
            builder.HasKey(note => note.Id);
            builder.Property(note => note.Id).HasColumnName("Id").IsRequired();
            builder.Property(note => note.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            builder.Property(note => note.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            builder.Property(note => note.DateBirth).HasColumnName("DateBirth").HasColumnType("date").IsRequired();
        }
    }
}
