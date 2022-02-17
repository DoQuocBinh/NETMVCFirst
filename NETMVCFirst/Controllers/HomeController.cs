using Microsoft.AspNetCore.Mvc;
using NETMVCFirst.Models;
using System.Diagnostics;

namespace NETMVCFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static List<Product> _products = new List<Product>();
      
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //find the product in the List
            var p = _products.FirstOrDefault(p => p.Id ==id);
            _products.Remove(p);
            //redirect to allProduct
            return RedirectToAction("ViewAllProduct");
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            //find the product in the List
            var p = _products.FirstOrDefault(p=>p.Id==product.Id);
            //update the product's properties
            p.ProductName = product.ProductName;
            p.Price = product.Price;
            //redirect to allProduct
            return RedirectToAction("ViewAllProduct");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //find the product with the primary key: productId
            var product = _products.FirstOrDefault(p=>p.Id == id);
            return View(product);
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create(string txtName, decimal txtPrice)
        {
            var product = new Product();
            product.ProductName = txtName;
            product.Price = txtPrice;
            product.Id = _products.Count;
            _products.Add(product);
            return View("ProductDetail",product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ProductIndex()
        {
            return View();
        }

        public IActionResult ViewAllProduct()
        {
            return View(_products);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}