using EndavaProject.Models;

namespace EndavaProject.Repositories.EventRepositories
{
    public interface IEventRepository
    {
        public Task<Event?> Get(long id);

        public Task<List<Event>> GetAll();
    }
}