using dotnet_5_role_based_authorization_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Jobs_Tags> JobsTags { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("TestDb");
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobPost>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.JobPosts)
                .UsingEntity<Jobs_Tags>(
                    j => j
                        .HasOne(pt => pt.Tag)
                        .WithMany(t => t.JobPostTags)
                        .HasForeignKey(pt => pt.TagId),
                    j => j
                        .HasOne(pt => pt.JobPost)
                        .WithMany(p => p.PostTags)
                        .HasForeignKey(pt => pt.PostId)
                    
);
        }
    }
}
