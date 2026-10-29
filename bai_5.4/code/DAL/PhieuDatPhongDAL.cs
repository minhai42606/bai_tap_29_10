using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class PhieuDatPhongDAL : DBConnect
    {
        public bool LapPhieuDatPhong(string soPhong, int maKH, DateTime ngayNhan)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string queryPhieu = "INSERT INTO PhieuDatPhong (SoPhong, MaKH, NgayNhanPhong, TongTienThanhToan) VALUES (@SoPhong, @MaKH, @NgayNhan, 0)";
                    using (MySqlCommand cmd = new MySqlCommand(queryPhieu, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                        cmd.Parameters.AddWithValue("@MaKH", maKH);
                        cmd.Parameters.AddWithValue("@NgayNhan", ngayNhan);
                        cmd.ExecuteNonQuery();
                    }

                    string queryPhong = "UPDATE Phong SET TrangThai = N'Đang ở' WHERE SoPhong = @SoPhong";
                    using (MySqlCommand cmd = new MySqlCommand(queryPhong, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

        public int LayMaPhieuDangHoatDong(string soPhong)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = "SELECT MaPhieu FROM PhieuDatPhong WHERE SoPhong = @SoPhong AND NgayTraPhong IS NULL LIMIT 1";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        public bool ThemSuDungDichVu(int maPhieu, int maDV, int soLuong)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO SuDungDichVu (MaPhieu, MaDV, SoLuong, ThoiGian) VALUES (@MaPhieu, @MaDV, @SoLuong, @ThoiGian)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmd.Parameters.AddWithValue("@MaDV", maDV);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@ThoiGian", DateTime.Now);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool CheckOut(int maPhieu, string soPhong, decimal tongTien)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string queryPhieu = "UPDATE PhieuDatPhong SET NgayTraPhong = @NgayTra, TongTienThanhToan = @TongTien WHERE MaPhieu = @MaPhieu";
                    using (MySqlCommand cmd = new MySqlCommand(queryPhieu, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@NgayTra", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TongTien", tongTien);
                        cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                        cmd.ExecuteNonQuery();
                    }

                    string queryPhong = "UPDATE Phong SET TrangThai = N'Đang dọn dẹp' WHERE SoPhong = @SoPhong";
                    using (MySqlCommand cmd = new MySqlCommand(queryPhong, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@SoPhong", soPhong);
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }
    }
}
