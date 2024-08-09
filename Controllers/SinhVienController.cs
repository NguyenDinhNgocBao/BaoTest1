using BaoTest1.Models;
using BaoTest1.Services;
using BaoTest1.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BaoTest1.Controllers
{
    public class SinhVienController : Controller
    {
        SinhVienService _sinhVienService;

        public SinhVienController()
        {
            _sinhVienService = new SinhVienService();
        }

        public IActionResult Index(int maLop, string? maSV = null, string? tenSV = null)
        {
            var ds = new List<SinhVien>();
            ViewBag.MaLopHoc = maLop;
            if (!string.IsNullOrEmpty(maSV) || !string.IsNullOrEmpty(tenSV))
            {
                ds = _sinhVienService.Search(maLop, maSV, tenSV);
            }
            else
            {
                ds = _sinhVienService.GetAll(maLop);
            }
           
            var model = new SinhVienViewModel
            {
                LisSV = ds
            };
            
           
            return View(model);
        }

        //Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SinhVien sinhVien)
        {
            var result = _sinhVienService.Insert(sinhVien);
            if (!result)
            {
                // Thông báo lỗi nếu thêm không thành công
                ModelState.AddModelError("", "Failed to create new SinhVien.");
                return View(sinhVien);
            }
            TempData["Message"] = "Thêm Sinh Viên thành công !";
            return Redirect($"https://localhost:44326/SinhVien?malop={sinhVien.MaLopHoc}");
            
        }

        //Delete
        public IActionResult Delete(int Id)
        {
            //Delete
            var result = _sinhVienService.Delete(Id);

            if (result)
            {
                TempData["Message"] = "Xóa Sinh Viên thành công!";
            }
            else
            {
                TempData["Error"] = "Không thể xóa Sinh Viên.";
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        //Edit
        [HttpGet]
        public IActionResult Update(int id)
        {
            var sv = _sinhVienService.Get(id);
            var model = new SinhVienViewModel();
            model.SinhVienRespone = sv;
            if (sv == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(SinhVienViewModel model)
        {
            var sv = model.SinhVienRespone;

            // Cập nhật sinh viên
            _sinhVienService.Update(sv);

            // Lưu thông báo thành công vào TempData
            TempData["Message"] = "Cập nhật thông tin sinh viên thành công!";

            // Chuyển hướng đến URL với tham số malop
            return Redirect($"https://localhost:44326/SinhVien?malop={sv.MaLopHoc}");
        }
    }
}
