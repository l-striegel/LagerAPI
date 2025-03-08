using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
            .Property(a => a.StylesJson)
            .HasDefaultValue("{}");

        modelBuilder.Entity<Article>()
            .Property(a => a.Timestamp)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedNever();
    }

}
