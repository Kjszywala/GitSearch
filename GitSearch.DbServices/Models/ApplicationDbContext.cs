using Microsoft.EntityFrameworkCore;
using GitSearch.DbServices.Models.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GitSearch.DbServices.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        private readonly IConfiguration configuration;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        { 
            this.configuration = configuration;
        }

        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.Roles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
        }
    }
}