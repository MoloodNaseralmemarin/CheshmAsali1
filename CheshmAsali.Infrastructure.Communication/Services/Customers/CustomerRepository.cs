using CheshmAsali.Domain.Data.Interfaces;
using CheshmAsali.Domain.Models;
using CheshmAsali.Infrastructure.Communication.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheshmAsali.Infrastructure.Communication.Services.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private IGenericRepository<Customer> _customerRepository;
        public CustomerRepository(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Dispose()
        {
            _customerRepository.Dispose();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await  _customerRepository.GetEntitiesQuery().ToListAsync();
        }
    }
}
