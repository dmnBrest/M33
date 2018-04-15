using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using M33.Models;
using M33.Models.DB;

namespace M33.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContextAccessor
        ): base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.LastUpdatedAt = now;
                            trackable.LastUpdatedBy = user;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.CreatedBy = user;
                            trackable.LastUpdatedAt = now;
                            trackable.LastUpdatedBy = user;
                            break;
                    }
                }
            }
        }

        private string GetCurrentUser()
        {

            // var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            // If it returns null, even when the user was authenticated, you may try to get the value of a specific claim
            // var authenticatedUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
            var claim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            var authenticatedUserId = claim != null ? claim.Value : "Anonymous";

            // TODO use name to set the shadow property value like in the following post: https://www.meziantou.net/2017/07/03/entity-framework-core-generate-tracking-columns

            return authenticatedUserId;

            // If you are using ASP.NET Core, you should look at this answer on StackOverflow
            // https://stackoverflow.com/a/48554738/2996339
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Item>()
                .HasIndex(b => b.Slug)
                .IsUnique();

            builder.Entity<ItemTag>()
                .HasKey(bc => new { bc.ItemId, bc.TagId });

            builder.Entity<ItemTag>()
                .HasOne(bc => bc.Item)
                .WithMany(b => b.ItemTags)
                .HasForeignKey(bc => bc.ItemId);

            builder.Entity<ItemTag>()
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.ItemTags)
                .HasForeignKey(bc => bc.TagId);

        }

        public DbSet<Post> Post { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<ItemTag> ItemTag { get; set; }
        public DbSet<Image> Image { get; set; }

    }
}
