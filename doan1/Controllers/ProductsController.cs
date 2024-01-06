using doan1.Data;
using doan1.Data.Service;
using doan1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace doan1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;
        public ProductsController(IProductsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var dataProducts = await _service.GetAllAsync();
            return View(dataProducts);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var dataProducts = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = dataProducts.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", dataProducts);
        }

        //Get: Products/Manage
        public async Task<IActionResult> Manage()
        {
            var dataProducts = await _service.GetAllAsync();
            return View(dataProducts);
        }

        //Get: Products/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }

        //Get: Products/Manage_Details/1
        public async Task<IActionResult> Manage_Details(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            return View(productDetails);
        }

        //Get: Products/Create
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Brands = new SelectList(productDropdownsData.Brands, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();

                ViewBag.Brands = new SelectList(productDropdownsData.Brands, "Id", "Name");

                return View(product);
            }

            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        //Get: Products/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                ImageURL = productDetails.ImageURL,
                Name = productDetails.Name,
                Price = productDetails.Price,
                Description = productDetails.Description,
                ProductCategory = productDetails.ProductCategory,
                BrandId = productDetails.BrandId,
            };

            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Brands = new SelectList(productDropdownsData.Brands, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();

                ViewBag.Brands = new SelectList(productDropdownsData.Brands, "Id", "Name");

                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
