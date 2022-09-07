using Domain.Entities.Expenses;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Banks
{
    public class BanksModel : Entity
    {
        private IList<ExpensesModel> _expenses;
        public BanksModel()
        {
            ExpensesTest = new List<ExpensesModel>();
        }
        public decimal Balance { get; private set; }
        public IReadOnlyCollection<ExpensesModel> Expenses { get { return _expenses.ToArray(); } }

        [NotMapped]
        public List<ExpensesModel> ExpensesTest { get; set; }
        public string BankName { get; private set; }

        public void AddExpensesToBanks(ExpensesModel expenses) =>
            _expenses.Add(expenses);
    }
}
