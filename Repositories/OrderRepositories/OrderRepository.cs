using EndavaProject.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace EndavaProject.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EndavaPrjContext _context;

        public OrderRepository(EndavaPrjContext context)
        {
            _context = context;
        }

        public async Task Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(long id)
        {
            return await _context.Orders.Where(x => x.OrdersId == id).ExecuteDeleteAsync();
        }

        public Task<Order?> Get(long id)
        {
            return _context.Orders.Include(x => x.TicketCategory)
                .Include(x => x.Customers)
                .FirstOrDefaultAsync(x => x.OrdersId == id);
        }

        public Task<List<Order>> GetAll()
        {
            var orders = _context.Orders.Include(x => x.TicketCategory)
                .Include(x => x.Customers)
                .ToListAsync();
            return orders;
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