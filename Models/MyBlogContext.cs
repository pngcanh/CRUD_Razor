using Microsoft.EntityFrameworkCore;


public class MyBlogContext : DbContext
{
    public DbSet<Articles> Articles { set; get; }
    public DbSet<Authors> Authors { set; get; }
    public DbSet<Categories> Categories { set; get; }
    public MyBlogContext()
    {

    }
    public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

//dotnet aspnet-codegenerator razorpage -m Articles -dc MyBlogContext -outDir Pages/Articles -udl --referenceScriptLibraries
