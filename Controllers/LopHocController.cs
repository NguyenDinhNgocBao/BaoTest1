using BaoTest1.Models;
using BaoTest1.Services;
using BaoTest1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BaoTest1.Controllers
{
    public class LopHocController : Controller
    {
        LopHocService lopHocService;
        SinhVienService sinhVienService;
        public LopHocController() 
        { 
            lopHocService = new LopHocService();
            sinhVienService = new SinhVienService();
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



        //Patrial Detail 
        public IActionResult Detail(int id)
        {
            LopHocViewModel model = new LopHocViewModel();
            model.LopHocCurrent = lopHocService.GetById(id);
            model.ListSinhVien = sinhVienService.GetAll(id);
            return PartialView("Detail", model);
        }
        public IActionResult LopHocTable()
        {
            LopHocViewModel model = new LopHocViewModel();
            model.ListLopHoc = lopHocService.GetList();
            return PartialView("LopHocTable", model);
        }
        /*
        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return PartialView("_LopHocTable", lopHocService.GetList()); // Trả về danh sách lớp học đầy đủ nếu không có từ khóa
            }
            var ds = lopHocService.Get(key);
            return PartialView("_LopHocTable", ds); // Trả về danh sách kết quả tìm kiếm
        }
        */
    }
}


