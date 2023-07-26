using EndavaProject.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace EndavaProject.Repositories.OrderRepositories
{
    public interface IOrderRepository
    {
        public Task Add(Order order);

        public Task<int> Delete(long id);

        public Task<Order?> Get(long id);

        public Task<List<Order>> GetAll();

        public Task Patch(long id, JsonPatchDocument modifications);
    }
}