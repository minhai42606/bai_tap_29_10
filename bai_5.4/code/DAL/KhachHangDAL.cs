using DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class KhachHangDAL : DBConnect
    {
        public KhachHangDTO TimKhachHangTheoCCCD(string cccd)
        {
            KhachHangDTO kh = null;
            using (MySqlConnection conn = GetConnection())
            {
                string query = "SELECT MaKH, HoTen, CCCD, SoDienThoai FROM KhachHang WHERE CCCD = @CCCD";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@CCCD", MySqlDbType.VarChar).Value = cccd;
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            kh = new KhachHangDTO
                            {
                                MaKH = reader.GetInt32("MaKH"),
                                HoTen = reader.GetString("HoTen"),
                                CCCD = reader.GetString("CCCD"),
                                SoDienThoai = reader.IsDBNull(reader.GetOrdinal("SoDienThoai")) ? "" : reader.GetString("SoDienThoai")
                            };
                        }
                    }
                }
            }
            return kh;
        }

        public int ThemKhachHang(KhachHangDTO kh)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai) VALUES (@HoTen, @CCCD, @SoDienThoai); SELECT LAST_INSERT_ID();";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                    cmd.Parameters.AddWithValue("@CCCD", kh.CCCD);
                    cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
