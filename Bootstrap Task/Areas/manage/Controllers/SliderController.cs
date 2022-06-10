using Bootstrap_Task.Data_Access_Layer;
using Bootstrap_Task.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootstrap_Task.Areas.manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(Slider slider)
        {
            await _context.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction("Home", "Index");
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        public IActionResult Edit(Slider slider)
        {
            return View();
        }
    }
}
