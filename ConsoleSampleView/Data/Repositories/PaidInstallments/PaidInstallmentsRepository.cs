using Domain.Entities.PaidInstallments;

namespace Data.Repositories.PaidInstallments
{
    public class PaidInstallmentsRepository : Repository, IPaidInstallmentsRepository
    {
        private readonly FinancasDbContext _context;
        public PaidInstallmentsRepository(FinancasDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
