using System.ComponentModel.DataAnnotations.Schema;

namespace DetailsSampleView
{
    public class ExpensesModelView
    {
        //private IList<PaidInstallmentsModel> _paidInstallments;
        public ExpensesModelView()
        {
            //_paidInstallments = new List<PaidInstallmentsModel>();
            //AddPaymentsToInstallments();
        }

        public ExpensesModelView(int id, bool separeted, bool inactive, DateTime dateLastInstallments, DateTime dateFirstInstallments, decimal amount, int countInstallments, string describe, string paymentType, decimal totalExpensesItem, decimal totalExpensesItemRemaining, int payedInstallments, int remainingInstallments, int idBank)
        {
            Id = id;
            Separeted = separeted;
            Inactive = inactive;
            DateLastInstallments = dateLastInstallments;
            DateFirstInstallments = dateFirstInstallments;
            Amount = amount;
            CountInstallments = countInstallments;
            Describe = describe;
            PaymentType = paymentType;
            TotalExpensesItem = totalExpensesItem;
            TotalExpensesItemRemaining = totalExpensesItemRemaining;
            PayedInstallments = payedInstallments;
            RemainingInstallments = remainingInstallments;
            IdBank = idBank;
        }


        //public ExpensesModel(DateTime dateFirstInstallments, string paymentType, string description, decimal amount, bool hasInstallments = false, int countInstallments = 1)
        //{
        //    //_paymentsInstallmenst = new List<PaidInstallmentsModel>();

        //    Separeted = hasInstallments;
        //    CountInstallments = countInstallments;
        //    DateFirstInstallments = dateFirstInstallments;
        //    DateLastInstallments = dateFirstInstallments.AddMonths(countInstallments);
        //    PaymentType = paymentType;
        //    Describe = description;
        //    Amount = amount;
        //}

        public int Id { get; private set; }
        public bool Separeted { get; private set; }
        public bool Inactive { get; private set; }
        public DateTime DateLastInstallments { get; private set; }
        public DateTime DateFirstInstallments { get; private set; }
        public decimal Amount { get; private set; }
        public int CountInstallments { get; private set; }
        public string Describe { get; private set; }
        public string PaymentType { get; private set; }

        //public IReadOnlyCollection<PaidInstallmentsModel> PaidInstallments { get { return _paidInstallments.ToArray(); } }
        // Not Mapped Properties

        [NotMapped]
        public decimal TotalExpensesItem { get; private set; }
        [NotMapped]
        public decimal TotalExpensesItemRemaining { get; private set; }
        [NotMapped]
        public int PayedInstallments { get; private set; }
        [NotMapped]
        public int RemainingInstallments { get; private set; }

        // relational maps
        public int IdBank { get; private set; }
        //public BanksModel Bank { get; set; }


        // Methods
        //public void AddPaymentsToInstallments(PaidInstallmentsModel PaidInstallments)
        //{
        //    _paidInstallments.Add(PaidInstallments);
        //}

        public void SumTotalExpensesItem() =>
             TotalExpensesItem = Inactive == false ? Amount * CountInstallments : 0;

        public void SumInstallmentsAndTotalRemaning(int payedInstallments)
        {
            PayedInstallments = payedInstallments;
            RemainingInstallments = PayedInstallments > 0 ? CountInstallments - PayedInstallments : 0;

            if (!Inactive)
                TotalExpensesItemRemaining = RemainingInstallments > 0 ? TotalExpensesItem - (Amount * PayedInstallments) : TotalExpensesItem;
        }

    }
}
