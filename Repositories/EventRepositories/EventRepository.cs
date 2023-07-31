using EndavaProject.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        public async Task<int> Delete(long id)
        {
            return await _context.Events.Where(x => x.EventId == id).ExecuteDeleteAsync();
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

        public async Task Patch(long id, JsonPatchDocument modifications)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrdersId == id);
            modifications.ApplyTo(order);
            order.TotalPrice = order.NumberOfTickets * order.TicketCategory.Price;
            await _context.SaveChangesAsync();
        }
    }
}