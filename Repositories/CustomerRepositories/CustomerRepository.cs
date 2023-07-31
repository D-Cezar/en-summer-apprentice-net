using EndavaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EndavaProject.Repositories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EndavaPrjContext _context;

        public CustomerRepository(EndavaPrjContext context)
        {
            _context = context;
        }

        public Task<Customer?> Get(long id)
        {
            return _context.Customers.Where(x => x.CustomersId == id).FirstOrDefaultAsync();
        }
    }
}