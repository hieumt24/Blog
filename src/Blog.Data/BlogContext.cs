using Blog.Core.Domain.Content;
using Blog.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public DbSet<PostInSeries> PostInSeries { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<PostActivityLog> PostActivityLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims")
            .HasKey(x => x.Id);
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")
            .HasKey(x => x.Id);
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins")
            .HasKey(x => x.UserId);
        builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
            .HasKey(x => new { x.UserId, x.RoleId });
        builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
            .HasKey(x => new { x.UserId });
    }

}