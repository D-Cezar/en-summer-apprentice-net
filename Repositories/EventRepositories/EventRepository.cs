using EndavaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EndavaProject.Repositories.EventRepositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EndavaPrjContext _context;

        public EventRepository(EndavaPrjContext context)
        {
            _context = context;
        }

        public Task<Event?> Get(long id)
        {
            return _context.Events.Where(x => x.EventId == id).Include(x => x.TicketCategories)
                .Include(x => x.EventType)
                .Include(x => x.Venue).FirstOrDefaultAsync();
        }

        public Task<List<Event>> GetAll()
        {
            return _context.Events.Include(x => x.TicketCategories)
                .Include(x => x.EventType)
                .Include(x => x.Venue).ToListAsync();
        }
    }
}