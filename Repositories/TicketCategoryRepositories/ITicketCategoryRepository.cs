using EndavaProject.Models;

namespace EndavaProject.Repositories.TicketCategoryRepositories
{
    public interface ITicketCategoryRepository
    {
        public Task<TicketCategory?> Get(long id);
    }
}