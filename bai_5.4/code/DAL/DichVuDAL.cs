using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class DichVuDAL : DBConnect
    {
        public DataTable GetDanhSachDichVu()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = GetConnection())
            {
                string query = "SELECT MaDV, TenDV, DonGia FROM DichVu";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
