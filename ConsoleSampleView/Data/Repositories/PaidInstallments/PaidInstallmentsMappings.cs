using Domain.Entities.PaidInstallments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repositories.PaidInstallments
{
    public class PaidInstallmentsMappings : IEntityTypeConfiguration<PaidInstallmentsModel>
    {
        public void Configure(EntityTypeBuilder<PaidInstallmentsModel> builder)
        {
            builder.ToTable("paidinstallmentstable");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PaymentDate).HasColumnName("paymentdate").HasColumnType("datetime2");

            // relational
            builder.HasOne(x => x.Expenses).WithMany(x => x.PaidInstallments).HasForeignKey(x => x.IdExpenses);
        }
    }
}
