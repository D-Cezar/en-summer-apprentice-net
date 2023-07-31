using EndavaProject.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace EndavaProject.Repositories.EventRepositories
{
    public interface IEventRepository
    {
        public Task<Event?> Get(long id);

        public Task<List<Event>> GetAll();

        public Task<int> Delete(long id);

        public Task Patch(long id, JsonPatchDocument modifications);
    }
}