using Application;
using Data;
using Data.Repositories;
using Data.Repositories.Banks;
using Data.Repositories.Expenses;
using Data.Repositories.PaidInstallments;
using DetailsSampleView;
using Domain.Entities.Banks;
using Domain.Entities.Expenses;
using Domain.Entities.PaidInstallments;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

static void RegisterServices()
{
    //NativeInjectorBootStrapper.RegisterServices();
    #region Dependency Injection
    IServiceCollection services = new ServiceCollection();

    //NativeInjectorBootStrapper.RegisterServices(services);
    #region Build Services

    // repositories
    services.AddScoped<IRepository, Repository>();
    services.AddScoped<IBankRepository, BankRepository>();
    services.AddScoped<IExpensesRepository, ExpensesRepository>();
    services.AddScoped<IPaidInstallmentsRepository, PaidInstallmentsRepository>();

    // services
    services.AddScoped<IService, Service>();
    services.AddScoped<IBankService, BanksService>();
    services.AddScoped<IExpensesService, ExpensesService>();
    services.AddScoped<IPaidInstallmentsService, PaidInstallmentsService>();

    // entity framework
    services.AddDbContextPool<FinancasDbContext>(db =>
    {
        db.UseSqlServer(@"Data Source=DESKTOP-8D688B2\SQLEXPRESS;Initial Catalog=financasdb;Integrated Security=True;");
    });
    #endregion

    var serviceProvider = services.BuildServiceProvider();

    #region Get Services

    // repositories
    var _repository = serviceProvider.GetRequiredService<IRepository>();

    var _bankRepository = serviceProvider.GetRequiredService<IBankRepository>();
    var _expensesRepository = serviceProvider.GetRequiredService<IExpensesRepository>();
    var _paidInstallmentsRepository = serviceProvider.GetRequiredService<IPaidInstallmentsRepository>();

    // services
    var _service = serviceProvider.GetRequiredService<IService>();

    var _banksService = serviceProvider.GetRequiredService<IBankService>();
    var _expensesService = serviceProvider.GetRequiredService<IExpensesService>();
    var _paidInstallmentsService = serviceProvider.GetRequiredService<IPaidInstallmentsService>();
    #endregion

    #endregion

    DetailsView view = _service.BuildObjectConsole();

    foreach (var bank in view.BanksList)
    {
        // Inicio do que futuramente será um TXT
        Console.WriteLine($"Dados Atualizados {DateTime.Now}");
        Console.WriteLine($"{bank.BankName} || Total de despesas {bank.Expenses.Count}\n");

        bank.Calculate();

        foreach (var item in bank.Expenses.OrderBy(x => x.Inactive).ThenByDescending(x => x.Separeted).ThenBy(x => x.RemainingInstallments == 0 ? x.CountInstallments - x.RemainingInstallments : -1).ThenByDescending(x => x.TotalExpensesItem))
            Console.WriteLine($"Comecei a pagar em {item.DateFirstInstallments.ToString("dd/MM/yyyy")} || {item.Describe} || Dinheiro separado? {item.Separeted} \n " +
                              $"    Total de parcelas: {item.CountInstallments} || Total Inicial: {item.TotalExpensesItem} || Parcelas Pagas: {item.PayedInstallments} || Parcelas restante: {item.RemainingInstallments} X {item.Amount} = {item.TotalExpensesItemRemaining} " +
                              $"Forma Pagamento: {item.PaymentType} || " +
                              $"Inativa: {item.Inactive} \n\n" +
                              $"___________________________________________________________________________________________________________________\n");

        // ter um diferença sem cnh, asus e óculos. ter um para a diferença da fatura atual? 
        // ter um que mostre a diferença do total inicial menos os pagos menos o saldo do banco para eu saber quando que eu ficaria quitando tudo hoje

        Console.WriteLine($"\nSaldo Banco: {bank.Balance} " +
                          $"\nDescontado mensalmente: {bank.TotalMensalActive} " +
                          $"\nDiferença mensal: {bank.Balance - bank.TotalMensalActive} " +
                          $"\nFatura Cartão de crédito : {bank.Fatura} " +

                          $"\n----------------------------------------------------------------------------------------------------------------------\n\n" +

                          $"    TOTAL TO SEPARETE" +
                          $"\n\n Total credit cart to separete monthly: {bank.TotalToSepareteCreditCardMonthly} " +
                          $"\n Total credit cart to separete: {bank.TotalToSepareteCreditCard} " +

                          $"\n\n Total pix to separete monthly: {bank.TotalToSeparetePixMonthly} " +
                          $"\n Total pix to separete: {bank.TotalToSeparetePix} " +

                          $"\n\n Total to separete monthly: {bank.TotalMonthly()} " +
                          $"\n Total to separete: {bank.TotalASeparar} " +

                          $"\n----------------------------------------------------------------------------------------------------------------------\n\n" +

                          $"    TOTAL SEPARETED" +
                          $"\n\n Total boleto separeted monthly: {bank.TotalSeparetedBoletoMonthly} " +
                          $"\n Total boleto separeted: {bank.TotalSeparetedBoleto} " +

                          $"\n\n Total debit separeted monthly: {bank.TotalSeparetedDebitoMonthly} " +
                          $"\n Total debit separeted: {bank.TotalSeparetedDebito} " +

                          $"\n\n Total credit cart separeted monthly: {bank.TotalSeparetedCreditCardMonthly} " +
                          $"\n Total credit cart separeted: {bank.TotalSeparetedCreditCard} " +

                          $"\n\n Total pix separeted monthly: {bank.TotalSeparetedPixMonthly} " +
                          $"\n Total pix separeted: {bank.TotalSeparetedPix} " +

                          $"\n\n Total separeted monthly: {bank.TotalSeparetedMonthly()} " +
                          $"\n Total separeted: {bank.TotalSepareted()} ");

        Console.WriteLine("\n\n\n===================================================================================================================== \n\n\n");
    }
}

//$"\nTotal parcelas restantes: {bank.TotalAllExpensesRemainingActive}" +
//$"\n Diferença parcelas restantes pagando tudo hoje: {bank.Balance - bank.TotalAllExpensesRemainingActive}" +

// See https://aka.ms/new-console-template for more information
RegisterServices();