using DetailsSampleView.Enums;

namespace DetailsSampleView
{
    public class DetailsView
    {
        public DetailsView()
        {
            BanksList = new List<BanksModelView>();
            Expenses = new List<ExpensesModelView>();
        }
        public void Calculate()
        {
            

            // esse cara é responsável por saber o saldo final pagando tudo
            TotalAllExpensesRemainingActive = Expenses/*.Where(x => x.Separeted == false)*/.Sum(x => x.TotalExpensesItemRemaining);
            // esse cara é responsável por saber quanto que sobra do saldo do banco debitando todo o dinheiro separado
            TotalSeparetedActive = Expenses.Where(x => x.Separeted == true).Sum(x => x.TotalExpensesItemRemaining);


            // responsável por saber quanto que é debitado mensalmente.
            TotalMensalActive = Expenses.Where(x => x.Inactive == false).Sum(x => x.Amount);
            // responsável por saber a fatura do cartão de crédito
            Fatura = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Inactive == false).Sum(x => x.Amount);

            // responsável por saber o total inicial sem descontar as parcelas pagas
            TotalAllExpensesActive = Expenses.Sum(x => x.TotalExpensesItem);

            TotalASeparar = Expenses.Where(x => x.Inactive == false && x.Separeted == false).Sum(x => x.TotalExpensesItemRemaining);
        }

        public List<BanksModelView> BanksList { get; set; }

        public List<ExpensesModelView> Expenses { get; set; }
        public decimal TotalAllExpensesActive { get; set; }
        public decimal TotalAllExpensesRemainingActive { get; set; }
        public decimal Fatura { get; set; } // só é valido para crédito
        public decimal TotalMensalActive { get; set; }
        public decimal TotalSeparetedActive { get; set; }
        public decimal TotalASeparar { get; set; }
        public decimal TotalAllCountInstallments { get; set; }
        public decimal TotalAllCountInstallmentsRemaining { get; set; }

    }
}