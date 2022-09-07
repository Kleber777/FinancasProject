using DetailsSampleView;
using Domain.Entities.Banks;
using Domain.Entities.Expenses;
using Domain.Entities.PaidInstallments;
using Domain.Interfaces;

namespace Application
{
    public class Service : IService
    {
        private readonly IBankRepository _bankRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly IPaidInstallmentsRepository _paidInstallmentsRepository;

        // Serviço responsável por transmitir os dados como em um arquivo txt.
        public Service(IBankRepository bankRepository, IExpensesRepository expensesRepository, IPaidInstallmentsRepository paidInstallmentsRepository)
        {
            _bankRepository = bankRepository;
            _expensesRepository = expensesRepository;
            _paidInstallmentsRepository = paidInstallmentsRepository;
        }

        public DetailsView BuildObjectConsole()
        {
            // Isso aqui não pode ter
            var banks = _bankRepository.Read<BanksModel>();
            var expenses = _expensesRepository.Read<ExpensesModel>();
            var paidInstallments = _paidInstallmentsRepository.Read<PaidInstallmentsModel>();

            DetailsView view = new DetailsView();

            foreach (var bank in banks)
            {

                // Passando os dados aqui para atualizar depois 
                foreach (var item in bank.Expenses)
                    bank.ExpensesTest.Add(item);

                var lstTemp = new List<ExpensesModelView>();

                foreach (var item in bank.ExpensesTest)
                {
                    item.SumTotalExpensesItem();

                    if (item.Inactive)
                        item.SumInstallmentsAndTotalRemaning(0);
                    else
                        //Somo o total restante de cada despesa e parcela
                        item.SumInstallmentsAndTotalRemaning(item.PaidInstallments.Count);

                    bank.ExpensesTest.ForEach(x => x = item);

                    lstTemp.Add(new ExpensesModelView(item.Id ,item.Separeted, item.Inactive, item.DateLastInstallments, item.DateFirstInstallments, item.Amount, item.CountInstallments, item.Describe, item.PaymentType, item.TotalExpensesItem, item.TotalExpensesItemRemaining
                        , item.PayedInstallments, item.RemainingInstallments, item.IdBank));
                }

                //view.BanksList.Add(new BanksModelView(bank.Id, bank.Balance, bank.BankName, view.Expenses.Where(x => x.IdBank == bank.Id).ToList()));
                view.BanksList.Add(new BanksModelView(bank.Id, bank.Balance, bank.BankName, lstTemp));

            }
            
            //DetailsView
            return view;
        }
    }
}