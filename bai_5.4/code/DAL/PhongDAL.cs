using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class PhongDAL : DBConnect
    {
        public DataTable GetDanhSachPhong()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection conn = GetConnection())
            {
                string query = "SELECT SoPhong, LoaiPhong, GiaTheoGio, TrangThai FROM Phong";
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

        public bool CapNhatTrangThaiPhong(string soPhong, string trangThai)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = "UPDATE Phong SET TrangThai = @TrangThai WHERE SoPhong = @SoPhong";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
