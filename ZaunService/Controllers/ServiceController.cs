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

        // GET: Service ==> Endpoint convertido a Lambda
        public async Task<IActionResult> Index()
            => View(await _context.Services.ToListAsync());
    }
}
