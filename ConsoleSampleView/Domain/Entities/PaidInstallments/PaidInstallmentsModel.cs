using Domain.Entities.Expenses;

namespace Domain.Entities.PaidInstallments
{
    public class PaidInstallmentsModel : Entity
    {
        public PaidInstallmentsModel()
        {

        }

        public DateTime PaymentDate { get; set; }

        // Relational 
        public int IdExpenses { get; private set; }
        public ExpensesModel Expenses { get; set; }

    }
}
