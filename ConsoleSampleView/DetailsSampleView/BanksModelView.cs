using DetailsSampleView.Enums;

namespace DetailsSampleView
{
    public class BanksModelView
    {
        public BanksModelView(int id, decimal balance, string bankName, List<ExpensesModelView> lst)
        {
            Id = id;
            Balance = balance;
            BankName = bankName;
            Expenses = lst;
        }
        public int Id { get; private set; }
        public decimal Balance { get; private set; }

        public List<ExpensesModelView> Expenses { get; set; }

        public string BankName { get; private set; }


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

            TotalASeparar = Expenses.Where(x => x.Inactive == false && x.Separeted == false).Sum(x => x.TotalExpensesItemRemaining); // esse cálculo eu posso obter somando os TotalToSeparete ao invés dessa condição, mas com essa condição é bacana que mostra que o código está calculando corretamente


            #region Calculate Total To Separeted
            // Total a separar crédito 
            TotalToSepareteCreditCardMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Separeted == false &&
                x.Inactive == false).Sum(x => x.Amount);

            TotalToSepareteCreditCard = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Separeted == false &&
                x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

            // Total a pix
            TotalToSeparetePixMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Pix.ToString() && x.Separeted == false &&
                x.Inactive == false).Sum(x => x.Amount);

            TotalToSeparetePix = Expenses.Where(x => x.PaymentType == EPaymentType.Pix.ToString() && x.Separeted == false &&
                x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);
            #endregion

            #region Calculete Total Separeted
            // Total separeted boleto
            TotalSeparetedBoletoMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Boleto.ToString() && x.Separeted == true &&
                x.Inactive == false).Sum(x => x.Amount);

            TotalSeparetedBoleto = Expenses.Where(x => x.PaymentType == EPaymentType.Boleto.ToString() && x.Separeted == true &&
                x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

            // Total separeted debito
            TotalSeparetedDebitoMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Debito.ToString() && x.Separeted == true &&
                x.Inactive == false).Sum(x => x.Amount);

            TotalSeparetedDebito = Expenses.Where(x => x.PaymentType == EPaymentType.Debito.ToString() && x.Separeted == true &&
                x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

            // Total separeted credit card
            TotalSeparetedCreditCardMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Separeted == true &&
                x.Inactive == false).Sum(x => x.Amount);

            TotalSeparetedCreditCard = Expenses.Where(x => x.PaymentType == EPaymentType.Credito.ToString() && x.Separeted == true &&
                x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);

            // Total separeted pix
            TotalSeparetedPixMonthly = Expenses.Where(x => x.PaymentType == EPaymentType.Pix.ToString() && x.Separeted == true &&
                x.Inactive == false).Sum(x => x.Amount);

            TotalSeparetedPix = Expenses.Where(x => x.PaymentType == EPaymentType.Pix.ToString() && x.Separeted == true &&
                x.Inactive == false).Sum(x => x.TotalExpensesItemRemaining);
            #endregion
        }
        public decimal TotalAllExpensesActive { get; set; }
        public decimal TotalAllExpensesRemainingActive { get; set; }
        public decimal Fatura { get; set; } // só é valido para crédito
        public decimal TotalMensalActive { get; set; }
        public decimal TotalSeparetedActive { get; set; }
        public decimal TotalAllCountInstallments { get; set; }
        public decimal TotalAllCountInstallmentsRemaining { get; set; }

        #region To Separete
        // Total a separar credito 
        public decimal TotalToSepareteCreditCardMonthly { get; set; }
        public decimal TotalToSepareteCreditCard { get; set; }

        // Total a separar Pix 
        public decimal TotalToSeparetePixMonthly { get; set; }
        public decimal TotalToSeparetePix { get; set; }

        // Real Total To Separete
        public decimal TotalMonthly() =>
            TotalToSepareteCreditCardMonthly + TotalToSeparetePixMonthly;
        public decimal TotalASeparar { get; set; }
        #endregion

        #region Total Separeted
        // Total Separeted Boleto 
        public decimal TotalSeparetedBoletoMonthly { get; set; }
        public decimal TotalSeparetedBoleto { get; set; }

        // Total Separeted Debito 
        public decimal TotalSeparetedDebitoMonthly { get; set; }
        public decimal TotalSeparetedDebito { get; set; }

        // Total Separeted Credit card
        public decimal TotalSeparetedCreditCardMonthly { get; set; }
        public decimal TotalSeparetedCreditCard { get; set; }
        
        // Total Separeted Pix
        public decimal TotalSeparetedPixMonthly { get; set; }
        public decimal TotalSeparetedPix { get; set; }

        // Real Total Separeted
        public decimal TotalSeparetedMonthly() =>
            TotalSeparetedDebitoMonthly + TotalSeparetedCreditCardMonthly + TotalSeparetedPixMonthly + TotalSeparetedBoletoMonthly;
        public decimal TotalSepareted() =>
            TotalSeparetedDebito + TotalSeparetedCreditCard + TotalSeparetedPix + TotalSeparetedBoleto;
        #endregion

    }
}
