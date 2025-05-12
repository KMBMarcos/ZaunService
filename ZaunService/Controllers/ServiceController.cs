using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZaunService.Models;

namespace ZaunService.Controllers
{
    public class ServiceController : Controller
    {
        private readonly TicketServiceContext _context;

        public ServiceController(TicketServiceContext context)
        {
            _context = context;
        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }
    }
}
