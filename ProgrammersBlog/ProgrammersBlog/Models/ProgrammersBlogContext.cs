using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProgrammersBlog.Models
{
    public class ProgrammersBlogContext: DbContext
    {
        public ProgrammersBlogContext() : base("ProgrammersBlogContext") { }

        public virtual DbSet <User> User { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("UsersRoles")
                .MapLeftKey("UserId")
                .MapLeftKey("RoleId"));

            modelBuilder.Entity<Comment>()
               .HasRequired<Post>(e => e.Post)
               .WithMany(e => e.Comments)
               .HasForeignKey(e => e.PostId);
        }

        public System.Data.Entity.DbSet<ProgrammersBlog.Models.Post> Posts { get; set; }
    }
}