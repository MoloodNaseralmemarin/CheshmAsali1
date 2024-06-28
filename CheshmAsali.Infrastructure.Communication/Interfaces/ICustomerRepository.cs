using CheshmAsali.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheshmAsali.Infrastructure.Communication.Interfaces
{
    public interface ICustomerRepository : IDisposable
    {
        Task<List<Customer>> GetAllCustomers();
     }
}
