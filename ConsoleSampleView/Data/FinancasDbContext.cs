using Data.Repositories.Banks;
using Data.Repositories.Expenses;
using Data.Repositories.PaidInstallments;
using Domain.Entities.Banks;
using Domain.Entities.Expenses;
using Domain.Entities.PaidInstallments;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FinancasDbContext : DbContext
    {
        public FinancasDbContext(DbContextOptions<FinancasDbContext> options) : base(options)
        {

        }

        public DbSet<BanksModel> BankModels { get; set; }
        public DbSet<ExpensesModel> ExpenseModels { get; set; }
        public DbSet<PaidInstallmentsModel> PaymentInstallmentModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankMappings());
            modelBuilder.ApplyConfiguration(new ExpensesMappings());
            modelBuilder.ApplyConfiguration(new PaidInstallmentsMappings());
            base.OnModelCreating(modelBuilder);
        }

    }
}
