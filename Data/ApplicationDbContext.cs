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


            modelBuilder.Entity<Models.CalculatorAction>().HasData(
                new CalculatorAction { Id = 1, Operation = "Addition", Descirption = "Perform addition" },
                new CalculatorAction { Id = 2, Operation = "Subtraction", Descirption = "Perform subtraction" },
                new CalculatorAction { Id = 3, Operation = "Division", Descirption = "Perform division" },
                new CalculatorAction { Id = 4, Operation = "Multiplication", Descirption = "Perform multiplication" }


                );
        }
    }
}
