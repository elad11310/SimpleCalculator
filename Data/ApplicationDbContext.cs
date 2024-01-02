using Microsoft.EntityFrameworkCore;
using SimpleCalculator.Models;



namespace SimpleCalculator.Data
{
    /// <summary>
    /// Basic configuration in order to use EF core
    /// </summary>
    public class ApplicationDbContext : DbContext
    {

        // Passing the options parameter to the base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<CalculatorAction> Actions { get; set; }
        public DbSet<ActionHistory> ActionHistory { get; set; }


        // Seed data into category table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seed data to Actions table
            modelBuilder.Entity<Models.CalculatorAction>().HasData(
                new CalculatorAction { Id = 1, Operation = "Addition", Description = "Perform addition" },
                new CalculatorAction { Id = 2, Operation = "Subtraction", Description = "Perform subtraction" },
                new CalculatorAction { Id = 3, Operation = "Division", Description = "Perform division" },
                new CalculatorAction { Id = 4, Operation = "Multiplication", Description = "Perform multiplication" }


                );

            // Make Operation field unique
            modelBuilder.Entity<CalculatorAction>(entity =>
            {
                entity.HasIndex(e => e.Operation).IsUnique();
            });

        }
    }
}
