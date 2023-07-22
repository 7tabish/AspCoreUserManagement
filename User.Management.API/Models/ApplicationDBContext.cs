using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace User.Management.API.Models
{
    public class ApplicationDBContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.Seeds(builder);
        }

        private void Seeds(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
               (
                new IdentityRole() { Name = "Staff", ConcurrencyStamp = "1", NormalizedName = "Staff" },
                new IdentityRole() { Name = "HR", ConcurrencyStamp = "2", NormalizedName = "Human Resource" }
                );


        }
    }
}
