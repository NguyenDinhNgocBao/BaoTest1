using BaoTest1.Models;

namespace BaoTest1.ViewModel
{
    public class LopHocViewModel
    {
        public List<LopHoc> ListLopHoc { get; set; }
        public LopHoc LopHocRespone { get; set; }
        public List<SinhVien> ListSinhVien { get; set; }
        public LopHoc LopHocCurrent { get; set; }
    }
}
