using BaoTest1.Models;
using BaoTest1.Services;
using BaoTest1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaoTest1.Controllers
{
    public class LopHocController : Controller
    {
        LopHocService lopHocService;
        public LopHocController() 
        { 
            lopHocService = new LopHocService();
        }
        public IActionResult Index(String? key)
        {
            LopHocViewModel model = new LopHocViewModel();
            if (!string.IsNullOrEmpty(key))
            {
                var ds = lopHocService.Get(key);
                model.ListLopHoc = ds;
            }
            else
            {
                model.ListLopHoc = lopHocService.GetList();
            }
            return View(model);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LopHoc lopHoc)
        {
            var lh = lopHocService.Insert(lopHoc);
            if (!lh)
            {
                ViewBag.Message = "Đã tồn tại lớp học này !";
                return View(lopHoc);
            }
            TempData["Message"] = "Thêm lớp học thành công !";
            return RedirectToAction("Index");
        }

        //Delete
        public IActionResult Delete(int Id)
        {
            //Delete
            lopHocService.Delete(Id);
            return RedirectToAction("Index");
        }

        //Edit
        [HttpGet]
        public IActionResult Update(int id)
        {
            var lopHoc = lopHocService.GetById(id);
            var model = new LopHocViewModel();
            model.LopHocRespone = lopHoc;
            if (lopHoc == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(LopHocViewModel model)
        {
            var lophoc = model.LopHocRespone;
            lopHocService.Update(lophoc);
            return RedirectToAction("Index");
        }
    }
}


