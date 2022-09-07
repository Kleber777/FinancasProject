using Application;
using Data;
using Data.Repositories;
using Data.Repositories.Banks;
using Data.Repositories.Expenses;
using Data.Repositories.PaidInstallments;
using Domain.Entities.Banks;
using Domain.Entities.Expenses;
using Domain.Entities.PaidInstallments;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices()
        {
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

        }
    }
}