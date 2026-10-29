using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BUS
{
    public class DichVuBUS
    {
        private DichVuDAL dvDAL = new DichVuDAL();

        public DataTable GetDanhSachDichVu()
        {
            return dvDAL.GetDanhSachDichVu();
        }
    }
}
