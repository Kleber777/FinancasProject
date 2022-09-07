using Domain.Entities.Expenses;

namespace Data.Repositories.Expenses
{
    public class ExpensesRepository : Repository, IExpensesRepository
    {
        private readonly FinancasDbContext _context;

        public ExpensesRepository(FinancasDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
