using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DichVuDTO
    {
        public int MaDV { get; set; }
        public string TenDV { get; set; }
        public decimal DonGia { get; set; }

        public DichVuDTO() { }

        public DichVuDTO(int maDV, string tenDV, decimal donGia)
        {
            MaDV = maDV;
            TenDV = tenDV;
            DonGia = donGia;
        }
    }
}
