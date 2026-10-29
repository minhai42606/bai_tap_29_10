using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BUS
{
    public class PhongBUS
    {
        private PhongDAL phongDAL = new PhongDAL();

        public DataTable GetDanhSachPhong()
        {
            return phongDAL.GetDanhSachPhong();
        }

        public bool CapNhatTrangThaiPhong(string soPhong, string trangThai)
        {
            return phongDAL.CapNhatTrangThaiPhong(soPhong, trangThai);
        }
    }
}
