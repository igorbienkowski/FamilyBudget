using Microsoft.EntityFrameworkCore;
using FamilyBudget.WebAPI.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<BudgetItem> BudgetItems { get; set; }
    public DbSet<SharedBudget> SharedBudgets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BudgetItem>()
            .Property(b => b.Amount)
            .HasColumnType("decimal(18, 2)");
        
        modelBuilder.Entity<SharedBudget>()
            .HasOne<User>(s => s.SharedWithUser)
            .WithMany()
            .HasForeignKey(s => s.SharedWithUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}