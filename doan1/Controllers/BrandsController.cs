using doan1.Data;
using doan1.Data.Service;
using doan1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace doan1.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandsService _service;
        public BrandsController(IBrandsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Address,PhoneNumber,Email,Description")]Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            await _service.AddAsync(brand);
            return RedirectToAction(nameof(Index));
        }

        //Get: Brands/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);

            if (brandDetails == null) return View("NotFound");
            return View(brandDetails);
        }

        //Get: Brands/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);

            if (brandDetails == null) return View("NotFound");
            return View(brandDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Address,PhoneNumber,Email,Description")]Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }
            await _service.UpdateAsync(id, brand);
            return RedirectToAction(nameof(Index));
        }

        //Get: Brands/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null) return View("NotFound");
            return View(brandDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
