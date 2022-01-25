using Library.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<AppUser>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(k => k.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(k => k.RoleId)
                .IsRequired();
            
            builder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('books_id_seq'::regclass)");

                entity.Property(e => e.Author).HasColumnName("author");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });
        }
    }
}