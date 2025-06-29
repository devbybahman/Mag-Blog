using Mag_Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mag_Blog.DataLayer.Context;

public class BlogCobtext:DbContext
{
    public BlogCobtext(DbContextOptions<BlogCobtext> options):base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }  
    public DbSet<PostComment> PostComments { get; set; }  
    public DbSet<Category> Categories { get; set; }  
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var Rel in modelBuilder.Model.GetEntityTypes().SelectMany(p => p.GetForeignKeys()))
        {
            Rel.DeleteBehavior = DeleteBehavior.Restrict;
        }
        base.OnModelCreating(modelBuilder);
    }
}