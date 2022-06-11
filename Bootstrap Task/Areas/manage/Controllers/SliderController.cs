using Bootstrap_Task.Data_Access_Layer;
using Bootstrap_Task.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bootstrap_Task.Utilies;

namespace Bootstrap_Task.Areas.manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }
        private readonly IWebHostEnvironment _evn;
        public SliderController(AppDbContext context, IWebHostEnvironment evn)
        {
            _context = context;
            _evn = evn;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (slider.Photo.CheckSize(3000))
            {
                ModelState.AddModelError("Photo", "Faylin olcusu sertden cox ola bilmez");
                return View();
            }
            if (!slider.Photo.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "Sekil deyil");
                return View();
            }
            slider.Image = await slider.Photo.SaveFileAsync(Path.Combine(_evn.WebRootPath, "assets", "imgs", "theme"));
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
