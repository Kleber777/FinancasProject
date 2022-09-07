using Domain.Entities.Banks;
using Domain.Entities.Expenses;
using Domain.Entities.PaidInstallments;

namespace Application
{
    public class ExpensesService : Service, IExpensesService
    {
        public ExpensesService(IBankRepository bankRepository, IExpensesRepository expensesRepository, IPaidInstallmentsRepository paidInstallmentsRepository) : base(bankRepository, expensesRepository, paidInstallmentsRepository)
        {
        }
    }
}
