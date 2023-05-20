using Microsoft.EntityFrameworkCore;

public class NewContainerDataContext : DbContext
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<ServiceRequest> ServiceRequests { get; set; }

    public NewContainerDataContext(DbContextOptions<NewContainerDataContext> options)
        : base(options)
    {

        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure your database connection here
        //optionsBuilder.UseSqlServer("DataContext");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasMany(c => c.RequiredServices)
            .WithOne(sr => sr.Company)
            .HasForeignKey(sr => sr.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);


    }
}