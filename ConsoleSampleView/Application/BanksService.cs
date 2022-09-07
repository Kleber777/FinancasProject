using Domain.Entities.Banks;
using Domain.Entities.Expenses;
using Domain.Entities.PaidInstallments;

namespace Application
{
    public class BanksService : Service, IBankService
    {
        public BanksService(IBankRepository bankRepository, IExpensesRepository expensesRepository, IPaidInstallmentsRepository paidInstallmentsRepository) : base(bankRepository, expensesRepository, paidInstallmentsRepository)
        {
        }
    }
}
