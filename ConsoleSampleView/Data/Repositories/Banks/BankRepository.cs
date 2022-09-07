using Domain.Entities.Banks;

namespace Data.Repositories.Banks
{
    public class BankRepository :Repository, IBankRepository
    {
        private readonly FinancasDbContext _context;
        public BankRepository(FinancasDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
