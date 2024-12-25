using Blog.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Blog.Data;

public class DataSeeder
{
    public async Task SeedAsync(BlogContext context)
    {
        var passwordHasher = new PasswordHasher<AppUser>();

        var rootAdminRoleId = Guid.NewGuid();
        if (!context.Roles.Any())
        {
            await context.Roles.AddAsync(new AppRole()
            {
                Id = rootAdminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                DisplayName = "Quản trị viên"
            });
            await context.SaveChangesAsync();
        }

        if (!context.Users.Any())
        {
            var userId = Guid.NewGuid();
            var user = new AppUser()
            {
                Id = userId,
                FirstName = "Trong",
                LastName = "Hieu",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = false,
                DateCreated = DateTime.Now,
            };
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
            await context.Users.AddAsync(user);
            await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
            {
                RoleId = rootAdminRoleId,
                UserId = userId
            });
            await context.SaveChangesAsync();
        }
    }
}