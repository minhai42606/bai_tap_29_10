using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class PhieuDatPhongBUS
    {
        private PhieuDatPhongDAL pdpDAL = new PhieuDatPhongDAL();

        public bool LapPhieuDatPhong(string soPhong, int maKH, DateTime ngayNhan)
        {
            return pdpDAL.LapPhieuDatPhong(soPhong, maKH, ngayNhan);
        }

        public int LayMaPhieuDangHoatDong(string soPhong)
        {
            return pdpDAL.LayMaPhieuDangHoatDong(soPhong);
        }

        public bool ThemSuDungDichVu(int maPhieu, int maDV, int soLuong)
        {
            return pdpDAL.ThemSuDungDichVu(maPhieu, maDV, soLuong);
        }

        public bool CheckOut(int maPhieu, string soPhong, decimal tongTien)
        {
            return pdpDAL.CheckOut(maPhieu, soPhong, tongTien);
        }
    }
}
