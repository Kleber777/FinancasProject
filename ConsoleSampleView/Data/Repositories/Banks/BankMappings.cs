using Domain.Entities.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Repositories.Banks
{
    public class BankMappings : IEntityTypeConfiguration<BanksModel>
    {
        
        public void Configure(EntityTypeBuilder<BanksModel> builder)
        {
            builder.ToTable("banktable");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BankName).HasColumnName("bankname").HasColumnType("varchar").HasMaxLength(255);
            builder.Property(x => x.Balance).HasColumnName("balance").HasColumnType("decimal").HasPrecision(10, 2);

            // relational
            builder.HasMany(x => x.Expenses).WithOne(x => x.Bank).HasForeignKey(x => x.IdBank);
        }
    }
        
}
