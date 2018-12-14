using Microsoft.EntityFrameworkCore;

namespace DAO_EFCORE.DAL.Models
{
    public class KeepNoteContext : DbContext, IKeepNoteContext
    {
        //Implement KeepNoteContext class
        public KeepNoteContext() { }
        public KeepNoteContext(DbContextOptions<KeepNoteContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>()
                .Property(c => c.Title).IsRequired();

            modelBuilder.Entity<Note>()
                .Property(b => b.Title).HasMaxLength(150);

            //modelBuilder.Entity<Note>()
            //    .Property(c => c.CreatedOn).HasDefaultValue("GETDATE()");

            modelBuilder.Entity<Checklist>()
                .Property(b => b.Content).HasMaxLength(500);

            modelBuilder.Entity<Label>()
                .Property(b => b.Content).HasMaxLength(30);


            //relationship among tables
            modelBuilder.Entity<Label>().HasOne(o => o.Note).WithMany(c => c.Labels);
            modelBuilder.Entity<Checklist>().HasOne(o => o.Note).WithMany(c => c.ListItems);
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
    }
}
