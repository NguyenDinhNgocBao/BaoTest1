using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaoTest1.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<LopHoc> LopHocs { get; set; }
        public DbSet<SinhVien> sinhViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = "Server=DESKTOP-J6LOB53;Database=QlLopHoc;User Id=sa;Password=123;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(conString);
        }


    }
    [Table("LopHoc")]
    public class LopHoc
    {
        [Key]
        public int MaLopHoc { get; set; }
        [StringLength(50)]
        public string TenLopHoc { get; set; }
        [StringLength(50)]
        public string PhongHoc { get; set; }
        public virtual List<SinhVien> ListSV{ get; set; }
    }

    [Table("SinhVien")]
    public class SinhVien
    {
        [Key]
        public int Id {  get; set; }
        public string MaSinhVien { get; set; }
        [StringLength(50)]
        public string HoSinhVien { get; set; }
        [StringLength(50)]
        public string TenSinhVien { get; set; }
        [StringLength(50)]
        public DateTime? NgaySinh {  get; set; }
        public EGioiTinh GioiTinh {  get; set; }
        public int MaLopHoc { get; set; }
        [ForeignKey(nameof(MaLopHoc))]
        public virtual LopHoc LopHoc { get; set; }
    }
    public enum EGioiTinh
    {
        Nam, Nu, Khac
    }
}
