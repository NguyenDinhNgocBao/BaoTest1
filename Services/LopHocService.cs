using BaoTest1.Models;
using Microsoft.EntityFrameworkCore;

namespace BaoTest1.Services
{
    public class LopHocService
    {
        AppDbContext db;
        public LopHocService()
        {
            if(db == null)
            {
                db = new AppDbContext();
            }
        }
        public List<LopHoc> GetList()
        {
            var ls = db.LopHocs.ToList();
            return ls;
        }
        public List<LopHoc> Get(String Key) {
            var rs = db.LopHocs.Where(e=> e.TenLopHoc.ToLower().Contains(Key.ToLower())).ToList();
            return rs; 
        }

        public LopHoc GetById(int id)
        {
            return db.LopHocs.FirstOrDefault(p => p.MaLopHoc == id);
        }


        public bool Insert(LopHoc lopHoc)
        {
            try
            {
                // Thêm đối tượng LopHoc vào DbSet
                db.LopHocs.Add(lopHoc);

                // Lưu các thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

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
        }

        public bool Delete(int id)
        {
            try
            {
                var lophoc = db.LopHocs.Where(e => e.MaLopHoc == id).FirstOrDefault();
                if (lophoc == null)
                {
                    return false;
                }
                db.LopHocs.Remove(lophoc);
                db.SaveChanges();
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

        public bool Update(LopHoc lopHoc)
        {
            try
            {
                var existingLopHoc = db.LopHocs.Where(e => e.MaLopHoc == lopHoc.MaLopHoc).FirstOrDefault();
                if (existingLopHoc == null)
                {
                    return false;
                }

                // Cập nhật các thuộc tính
                existingLopHoc.TenLopHoc = lopHoc.TenLopHoc;
                existingLopHoc.PhongHoc = lopHoc.PhongHoc;

                db.LopHocs.Update(existingLopHoc);
                db.SaveChanges();
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
