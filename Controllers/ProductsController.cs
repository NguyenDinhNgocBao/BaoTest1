using BaoTest1.Models;
using BaoTest1.Services;
using BaoTest1.ViewModel;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

namespace BaoTest1.Controllers
{
    public class ProductsController : Controller
    {
        ProductsService service;
        public ProductsController() { 
            service = new ProductsService();
        }
        public IActionResult Index(String? keyword)
        {
            var productViewModel = new ProductsViewModel();
            productViewModel.Products = service.GetProducts(keyword);


            ViewBag.Key = keyword;
            return View(productViewModel);
        }

        public IActionResult DeleteProduct(int Id)
        {
            //Delete
            service.Delete(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var p = service.GetById(Id);
            var model = new ProductsViewModel();
            model.ProductRespone = p;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductsViewModel model)
        {
            var p = model.ProductRespone;
            //Thanh cong
            service.Update(p); // Cap nhat
            return RedirectToAction("Index") ;
        }

        public IActionResult AddProduct( )
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Products product)
        {
            service.AddProduct(product);
            return RedirectToAction("Index");
        }
    }
}
