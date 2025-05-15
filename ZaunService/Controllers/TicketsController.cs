using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZaunService.Models;

namespace ZaunService.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketServiceContext _context;

        public TicketsController(TicketServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var service = _context.Tickets
                    .Include(t => t.Service);
            return View(await service.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Services"] = new SelectList(_context.Services, "Id", "Name");
            return View();
        }
    }
}
