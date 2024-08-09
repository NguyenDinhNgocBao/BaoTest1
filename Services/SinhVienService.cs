using BaoTest1.Models;
using Microsoft.EntityFrameworkCore;

namespace BaoTest1.Services
{
    public class SinhVienService
    {
        AppDbContext _context;

        public SinhVienService()
        {
            if(_context == null)
            {
                _context = new AppDbContext();
            }
        }
        //Lấy sv theo ma lop
        public List<SinhVien> GetAll(int maLop)
        {
            var ds = _context.sinhViens
                              .Where(e => e.MaLopHoc == maLop)
                              .ToList();
            return ds;
        }
        //lấy sv theo mã id
        public SinhVien Get(int id)
        {
            var ds = _context.sinhViens.Where(e => e.Id == id).FirstOrDefault();
            return ds;
        }
        //lấy sv theo mã sv
        public SinhVien GetByMaSV(string maSV)
        {
            var ds = _context.sinhViens.Where(e => e.MaSinhVien == maSV).FirstOrDefault();
            return ds;
        }
        public bool Insert(SinhVien sinhVien)
        {
            var sv = _context.sinhViens.Where(e => e.MaSinhVien == sinhVien.MaSinhVien).FirstOrDefault();
            if(sv == null)
            {
                return false;
            }
            sv = new SinhVien
            {
                MaSinhVien = sinhVien.MaSinhVien,
                HoSinhVien = sinhVien.HoSinhVien,
                TenSinhVien = sinhVien.TenSinhVien,
                MaLopHoc = sinhVien.MaLopHoc,
                NgaySinh = sinhVien.NgaySinh,
                GioiTinh = sinhVien.GioiTinh
            };
            _context.sinhViens.Add(sv);
            _context.SaveChanges();
            return true;

            /*Cach 2
            try
            {
                // Thêm đối tượng LopHoc vào DbSet
                _context.sinhViens.Add(sinhVien);

                // Lưu các thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();

                return true;
            }
            catch (DbUpdateException ex)
            {
                // Xử lý lỗi cập nhật cơ sở dữ liệu
                Console.WriteLine($"DbUpdateException: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return false;
            */
        }
        public bool Update(SinhVien sinhVien)
        {
            try
            {
                var sv = _context.sinhViens.Where(e => e.Id == sinhVien.Id).FirstOrDefault();
                if (sv == null)
                {
                    return false;
                }

                // Cập nhật các thuộc tính
                sv.MaSinhVien = sinhVien.MaSinhVien;
                sv.HoSinhVien = sinhVien.HoSinhVien;
                sv.TenSinhVien = sinhVien.TenSinhVien;
                sv.NgaySinh = sinhVien.NgaySinh;
                sv.GioiTinh = sinhVien.GioiTinh;

                _context.sinhViens.Update(sv);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return false;
        }
        public bool Delete(int id)
        {
            try
            {
                var sinhvien = _context.sinhViens.Where(e => e.Id == id).FirstOrDefault();
                if (sinhvien == null)
                {
                    return false;
                }
                _context.sinhViens.Remove(sinhvien);
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"DbUpdateException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return false;
        }
    }
}
