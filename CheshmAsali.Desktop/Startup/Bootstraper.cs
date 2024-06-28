using Autofac;
using CheshmAsali.Desktop.ViewModels;
using CheshmAsali.Desktop.Views;
using CheshmAsali.Domain.Data;
using CheshmAsali.Domain.Data.Interfaces;
using CheshmAsali.Domain.Models;
using CheshmAsali.Infrastructure.Common.Repositories;
using CheshmAsali.Infrastructure.Communication.Interfaces;
using CheshmAsali.Infrastructure.Communication.Services.Customers;


namespace CheshmAsali.Desktop.Startup
{
    public class Bootstraper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            // Register your types
            builder.RegisterType<GenericRepository<Customer>>().As<IGenericRepository<Customer>>();

            // Register other services and types here
            // builder.RegisterType<YourService>().As<IYourService>();

            // Register view models
            builder.RegisterType<RegisterViewModel>();

            // Register views
            builder.RegisterType<RegisterWindow>();

            return builder.Build();
        }
    }
}