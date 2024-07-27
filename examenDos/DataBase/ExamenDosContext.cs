using examenDos.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace examenDos.DataBase
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<CustomersEntity> Customers { get; set; }
        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<AmortizationDetailEntity> AmortizationDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

             
            base.OnModelCreating(modelBuilder);
        }

    }
}