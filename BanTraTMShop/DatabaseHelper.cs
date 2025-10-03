using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BanTraTMShop
{
    public class DatabaseHelper
    {
        public SqlConnection con;
        public DatabaseHelper()
        {
            string sqlCon = @"Data Source=CHUTHIHONG\SQLEXPRESS;Initial Catalog=QLBANHANG_FINAL1;Integrated Security=True;";

            con = new SqlConnection(sqlCon);
        }
        public List<Tra> GetTeas()
        {
            List<Tra> ds = new List<Tra>();
            string query = "SELECT * FROM TRA";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Tra s = new Tra
                {
                    maTra = rd["maTra"] != DBNull.Value ? (int)rd["maTra"] : 0,
                    tenTra = rd["tenTra"] != DBNull.Value ? (string)rd["tenTra"] : string.Empty,
                    nguyenLieu = rd["nguyenLieu"] != DBNull.Value ? (string)rd["nguyenLieu"] : string.Empty,
                    trongLuong = rd["trongLuong"] != DBNull.Value ? (int)rd["trongLuong"] : 0,
                    moTa = rd["moTa"] != DBNull.Value ? (string)rd["moTa"] : string.Empty,
                    cachCheBien = rd["cachCheBien"] != DBNull.Value ? (string)rd["cachCheBien"] : string.Empty,
                    giaBan = rd["giaBan"] != DBNull.Value ? (decimal)rd["giaBan"] : 0,
                    ngaySanXuat = rd["ngaySanXuat"] != DBNull.Value ? (DateTime)rd["ngaySanXuat"] : DateTime.MinValue,
                    hanSuDung = rd["hanSuDung"] != DBNull.Value ? (DateTime)rd["hanSuDung"] : DateTime.MinValue,
                    dongGoi = rd["dongGoi"] != DBNull.Value ? (string)rd["dongGoi"] : string.Empty,
                    luuY = rd["luuY"] != DBNull.Value ? (string)rd["luuY"] : string.Empty,
                    soLuongCo = rd["soLuongCo"] != DBNull.Value ? (int)rd["soLuongCo"] : 0,
                    maLoaiTra = rd["maLoaiTra"] != DBNull.Value ? (int)rd["maLoaiTra"] : 0,
                    anh = rd["anh"] != DBNull.Value ? (string)rd["anh"] : string.Empty,
                };
                ds.Add(s);
            }
            con.Close();
            return ds;
        }
        public Tra GetTeaById(int maTra)
        {
            Tra t = null;
            string query = @"
                SELECT 
                    TRA.maTra, 
                    TRA.tenTra, 
                    TRA.nguyenLieu, 
                    TRA.trongLuong, 
                    TRA.moTa, 
                    TRA.cachCheBien, 
                    TRA.giaBan, 
                    TRA.ngaySanXuat, 
                    TRA.hanSuDung, 
                    TRA.dongGoi, 
                    TRA.luuY, 
                    TRA.soLuongCo, 
                    TRA.maLoaiTra,
                    LOAITRA.tenLoaiTra,  
                    TRA.anh 
                FROM TRA
                JOIN LOAITRA ON TRA.maLoaiTra = LOAITRA.maLoaiTra
                WHERE TRA.maTra = @maTra";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@maTra", maTra);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                t = new Tra()
                {
                    maTra = (int)rd["maTra"],
                    tenTra = (string)rd["tenTra"],
                    nguyenLieu = (string)rd["nguyenLieu"],
                    trongLuong = (int)rd["trongLuong"],
                    moTa = (string)rd["moTa"],
                    cachCheBien = (string)rd["cachCheBien"],
                    giaBan = (decimal)rd["giaBan"],
                    ngaySanXuat = (DateTime)rd["ngaySanXuat"],
                    hanSuDung = (DateTime)rd["hanSuDung"],
                    dongGoi = (string)rd["dongGoi"],
                    luuY = (string)rd["luuY"],
                    soLuongCo = (int)rd["soLuongCo"],
                    maLoaiTra = (int)rd["maLoaiTra"],
                    tenLoaiTra = (string)rd["tenLoaiTra"],
                    anh = (string)rd["anh"],
                };
            }
            con.Close();
            return t;
        }
        public List<Tra> GetTraByDanhMuc(int maLoaiTra)
        {
            List<Tra> ds = new List<Tra>();
            string query = @"
            SELECT 
                t.maTra,
                t.tenTra,
                t.nguyenLieu,
                t.trongLuong,
                t.moTa,
                t.cachCheBien,
                t.giaBan,
                t.ngaySanXuat,
                t.hanSuDung,
                t.dongGoi,
                t.luuY,
                t.soLuongCo,
                t.anh,
                t.maLoaiTra,
                l.tenLoaiTra
            FROM 
                TRA t
            JOIN 
                LOAITRA l ON t.maLoaiTra = l.maLoaiTra
            WHERE 
                l.maLoaiTra = @maLoaiTra";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("maLoaiTra", maLoaiTra);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Tra t = new Tra
                    {
                        maTra = rd["maTra"] != DBNull.Value ? (int)rd["maTra"] : 0,
                        tenTra = rd["tenTra"] != DBNull.Value ? (string)rd["tenTra"] : string.Empty,
                        nguyenLieu = rd["nguyenLieu"] != DBNull.Value ? (string)rd["nguyenLieu"] : string.Empty,
                        trongLuong = rd["trongLuong"] != DBNull.Value ? (int)rd["trongLuong"] : 0,
                        moTa = rd["moTa"] != DBNull.Value ? (string)rd["moTa"] : string.Empty,
                        cachCheBien = rd["cachCheBien"] != DBNull.Value ? (string)rd["cachCheBien"] : string.Empty,
                        giaBan = rd["giaBan"] != DBNull.Value ? (decimal)rd["giaBan"] : 0,
                        ngaySanXuat = rd["ngaySanXuat"] != DBNull.Value ? (DateTime)rd["ngaySanXuat"] : DateTime.MinValue,
                        hanSuDung = rd["hanSuDung"] != DBNull.Value ? (DateTime)rd["hanSuDung"] : DateTime.MinValue,
                        dongGoi = rd["dongGoi"] != DBNull.Value ? (string)rd["dongGoi"] : string.Empty,
                        luuY = rd["luuY"] != DBNull.Value ? (string)rd["luuY"] : string.Empty,
                        soLuongCo = rd["soLuongCo"] != DBNull.Value ? (int)rd["soLuongCo"] : 0,
                        maLoaiTra = rd["maLoaiTra"] != DBNull.Value ? (int)rd["maLoaiTra"] : 0,
                        anh = rd["anh"] != DBNull.Value ? (string)rd["anh"] : string.Empty,
                    };
                    ds.Add(t);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching teas by danh muc", ex);
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public List<Tra> GetBestSellingTea()
        {
            List<Tra> ds = new List<Tra>();
            string query = @"
            SELECT TOP 6 T.maTra, T.tenTra, T.anh, T.giaBan, SUM(DTH.soLuong) AS soLuongBan
            FROM TRA AS T
            JOIN TRA_DONHANG AS DTH ON T.maTra = DTH.maTra
            GROUP BY T.maTra, T.tenTra, T.anh, T.giaBan
            ORDER BY soLuongBan DESC;
        ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Tra t = new Tra
                {
                    maTra = rd["maTra"] != DBNull.Value ? (int)rd["maTra"] : 0,
                    tenTra = rd["tenTra"] != DBNull.Value ? (string)rd["tenTra"] : string.Empty,
                    anh = rd["anh"] != DBNull.Value ? (string)rd["anh"] : string.Empty,
                    giaBan = rd["giaBan"] != DBNull.Value ? (decimal)rd["giaBan"] : 0,
                    soLuongBan = rd["soLuongBan"] != DBNull.Value ? (int)rd["soLuongBan"] : 0,
                };
                ds.Add(t);
            }
            con.Close();
            return ds;
        }
        public List<Tra> GetTraMoi()
        {
            List<Tra> ds = new List<Tra>();
            string query = @"
            SELECT *
            FROM TRA
            WHERE ngaySanXuat >= DATEADD(DAY, -30, GETDATE())
            ORDER BY ngaySanXuat DESC;
        ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Tra t = new Tra
                {
                    maTra = rd["maTra"] != DBNull.Value ? (int)rd["maTra"] : 0,
                    tenTra = rd["tenTra"] != DBNull.Value ? (string)rd["tenTra"] : string.Empty,
                    anh = rd["anh"] != DBNull.Value ? (string)rd["anh"] : string.Empty,
                    giaBan = rd["giaBan"] != DBNull.Value ? (decimal)rd["giaBan"] : 0,
                };
                ds.Add(t);
            }
            con.Close();
            return ds;
        }
        private string connectionString = "your_connection_string_here"; // Thay đổi với chuỗi kết nối của bạn

        // Lấy tổng giá trị giỏ hàng của người dùng
        public decimal GetCartTotal(int maTaiKhoan)
        {
            decimal total = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT SUM(giaBan * soLuong) FROM TRA_GIOHANG tg " +
                               "JOIN TRA t ON tg.maTra = t.maTra WHERE tg.maGioHang = @maGioHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maGioHang", maTaiKhoan); // Sử dụng mã giỏ hàng thay vì mã tài khoản trực tiếp

                conn.Open();
                total = (decimal)cmd.ExecuteScalar();
            }

            return total;
        }

        // Xử lý thanh toán
        public bool ProcessPayment(int maTaiKhoan, string name, string address, string phone, string paymentMethod)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Thêm đơn hàng vào bảng DONHANG
                    string query = "INSERT INTO DONHANG (ngayDatHang, maTaiKhoan, tinhTrang, tongTien) " +
                                   "OUTPUT INSERTED.maDonHang VALUES (GETDATE(), @maTaiKhoan, 'Đang xử lý', @tongTien)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                    cmd.Parameters.AddWithValue("@tongTien", GetCartTotal(maTaiKhoan)); // Lấy tổng giá trị giỏ hàng

                    conn.Open();
                    int maDonHang = (int)cmd.ExecuteScalar();

                    // Thêm các sản phẩm từ giỏ hàng vào bảng TRA_DONHANG
                    string addItemsQuery = "INSERT INTO TRA_DONHANG (maTra, maDonHang, soLuong, giaBanRa, tongTien) " +
                                           "SELECT tg.maTra, @maDonHang, tg.soLuong, t.giaBan, tg.soLuong * t.giaBan " +
                                           "FROM TRA_GIOHANG tg JOIN TRA t ON tg.maTra = t.maTra WHERE tg.maGioHang = @maGioHang";
                    SqlCommand addItemsCmd = new SqlCommand(addItemsQuery, conn);
                    addItemsCmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                    addItemsCmd.Parameters.AddWithValue("@maGioHang", maTaiKhoan); // Sử dụng mã giỏ hàng
                    addItemsCmd.ExecuteNonQuery();

                    // Xóa sản phẩm khỏi giỏ hàng sau khi thanh toán
                    string deleteQuery = "DELETE FROM TRA_GIOHANG WHERE maGioHang = @maGioHang";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@maGioHang", maTaiKhoan);
                    deleteCmd.ExecuteNonQuery();

                    // Lưu thông tin thanh toán vào bảng ThanhToan
                    string paymentQuery = "INSERT INTO ThanhToan (maDonHang, phuongThuc, trangThai, tongTien, ngayThanhToan) " +
                                          "VALUES (@maDonHang, @phuongThuc, 'Đã thanh toán', @tongTien, GETDATE())";
                    SqlCommand paymentCmd = new SqlCommand(paymentQuery, conn);
                    paymentCmd.Parameters.AddWithValue("@maDonHang", maDonHang);
                    paymentCmd.Parameters.AddWithValue("@phuongThuc", paymentMethod);
                    paymentCmd.Parameters.AddWithValue("@tongTien", GetCartTotal(maTaiKhoan));
                    paymentCmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                return false;
            }
        }

        // Lấy hoặc tạo giỏ hàng cho người dùng
        public int GetOrCreateCart(int maTaiKhoan)
        {
            int maGioHang = 0;

            // Kiểm tra nếu người dùng đã có giỏ hàng
            string query = "SELECT maGioHang FROM GIOHANG WHERE maTaiKhoan = @maTaiKhoan";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    maGioHang = Convert.ToInt32(reader["maGioHang"]);
                }
                else
                {
                    // Nếu không có giỏ hàng, tạo mới giỏ hàng
                    string insertQuery = "INSERT INTO GIOHANG (maTaiKhoan) VALUES (@maTaiKhoan); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@maTaiKhoan", maTaiKhoan);
                    maGioHang = Convert.ToInt32(insertCmd.ExecuteScalar());
                }
            }

            return maGioHang;
        }

        // Thêm sản phẩm vào giỏ hàng
        public bool AddToCart(int maGioHang, int maTra, int soLuong)
        {
            try
            {
                string query = "INSERT INTO TRA_GIOHANG (maTra, maGioHang, soLuong) VALUES (@maTra, @maGioHang, @soLuong)";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maTra", maTra);
                    cmd.Parameters.AddWithValue("@maGioHang", maGioHang);
                    cmd.Parameters.AddWithValue("@soLuong", soLuong);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}