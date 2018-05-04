namespace Instagraph.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;
    //Add the Confguration Ref
    using EntityConfiguration;

    public class InstagraphContext : DbContext
    {
        public InstagraphContext() { }

        public InstagraphContext(DbContextOptions options)
            :base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
        //Add the DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures{ get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserFollower> UsersFollowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add Entity Configuration
            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.ApplyConfiguration(new PictureConfig());

            modelBuilder.ApplyConfiguration(new PostConfig());

            modelBuilder.ApplyConfiguration(new CommentConfig());

            modelBuilder.ApplyConfiguration(new UserFollowerConfig());
        }
    }
}
