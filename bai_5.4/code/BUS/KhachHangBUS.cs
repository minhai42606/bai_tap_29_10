using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAL khDAL = new KhachHangDAL();

        public KhachHangDTO TimKhachHangTheoCCCD(string cccd)
        {
            return khDAL.TimKhachHangTheoCCCD(cccd);
        }

        public int ThemKhachHang(KhachHangDTO kh)
        {
            return khDAL.ThemKhachHang(kh);
        }
    }
}
