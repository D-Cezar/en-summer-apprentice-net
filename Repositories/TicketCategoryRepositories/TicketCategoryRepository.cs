using EndavaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EndavaProject.Repositories.TicketCategoryRepositories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly EndavaPrjContext _context;

        public TicketCategoryRepository(EndavaPrjContext context)
        {
            _context = context;
        }

        public Task<TicketCategory?> Get(long id)
        {
            return _context.TicketCategories.Where(x => x.TicketCategoryId == id).FirstOrDefaultAsync();
        }
    }
}