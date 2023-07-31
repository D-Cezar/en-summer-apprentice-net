using EndavaProject.Models;

namespace EndavaProject.Repositories.CustomerRepositories
{
    public interface ICustomerRepository
    {
        public Task<Customer?> Get(long id);
    }
}