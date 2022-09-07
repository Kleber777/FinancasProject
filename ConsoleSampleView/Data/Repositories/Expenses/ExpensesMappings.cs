using Domain.Entities.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repositories.Expenses
{
    public class ExpensesMappings : IEntityTypeConfiguration<ExpensesModel>
    {
        public void Configure(EntityTypeBuilder<ExpensesModel> builder)
        {
            builder.ToTable("expensestable");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("decimal").HasPrecision(10, 2);
            builder.Property(x => x.CountInstallments).HasColumnName("countinstallments").HasColumnType("int");
            builder.Property(x => x.DateFirstInstallments).HasColumnName("datefirstinstallments").HasColumnType("datetime2");
            builder.Property(x => x.DateLastInstallments).HasColumnName("datelastinstallments").HasColumnType("datetime2");
            builder.Property(x => x.Describe).HasColumnName("describe").HasColumnType("varchar").HasMaxLength(255);
            builder.Property(x => x.PaymentType).HasColumnName("paymenttype").HasColumnType("varchar").HasMaxLength(255);
            builder.Property(x => x.Separeted).HasColumnName("separeted").HasColumnType("bit");
            builder.Property(x => x.Inactive).HasColumnName("inactive").HasColumnType("bit");

            // relational
            builder.HasOne(x => x.Bank).WithMany(x => x.Expenses).HasForeignKey(x => x.IdBank);
            builder.HasMany(x => x.PaidInstallments).WithOne(x => x.Expenses).HasForeignKey(x => x.IdExpenses);
        }
    }
}

