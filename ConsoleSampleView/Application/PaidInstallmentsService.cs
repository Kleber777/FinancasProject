using Domain.Entities.Banks;
using Domain.Entities.Expenses;
using Domain.Entities.PaidInstallments;

namespace Application
{
    public class PaidInstallmentsService : Service, IPaidInstallmentsService
    {
        public PaidInstallmentsService(IBankRepository bankRepository, IExpensesRepository expensesRepository, IPaidInstallmentsRepository paidInstallmentsRepository) : base(bankRepository, expensesRepository, paidInstallmentsRepository)
        {
        }
    }
}
