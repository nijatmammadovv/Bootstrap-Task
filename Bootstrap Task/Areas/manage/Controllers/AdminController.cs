using Bootstrap_Task.Data_Access_Layer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootstrap_Task.Areas.manage.Controllers
{
    [Area("manage")]
    public class AdminController : Controller
    {
        private AppDbContext _context { get; }
        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
