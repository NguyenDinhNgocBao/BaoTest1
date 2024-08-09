using BaoTest1.Models;
using BaoTest1.Services;
using BaoTest1.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BaoTest1.Controllers
{
    public class SinhVienController : Controller
    {
        SinhVienService _sinhVienService;

        public SinhVienController()
        {
            _sinhVienService = new SinhVienService();
        }

        public IActionResult Index(int maLop)
        {
            var ds = new List<SinhVien>();
            
            ds = _sinhVienService.GetAll(maLop);
            var model = new SinhVienViewModel
            {
                LisSV = ds
            };
            
           
            return View(model);
        }
    }
}
