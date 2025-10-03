using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txthoTen.Text;
            string password = txtmatKhau.Text;

            // Kiểm tra điều kiện nếu không đúng
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "Vui lòng điền đầy đủ thông tin!";
                lblMessage.CssClass = "error-message error show"; // Hiển thị thông báo lỗi
                return;
            }

            // Kiểm tra thông tin đăng nhập (Ví dụ)
            if (username != "admin" || password != "1234")
            {
                lblMessage.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                lblMessage.CssClass = "error-message error show"; // Hiển thị thông báo lỗi
            }
            else
            {
                lblMessage.Text = "Đăng nhập thành công!";
                lblMessage.CssClass = "error-message success show"; // Hiển thị thông báo thành công
            }

            if (string.IsNullOrWhiteSpace(txthoTen.Text) || string.IsNullOrWhiteSpace(txtmatKhau.Text) || ddlRole.SelectedValue == "0")
            {
                lblMessage.Text = "Vui lòng điền vào tất cả thông tin.";
                return; // Dừng xử lý nếu chưa đủ dữ liệu
            }

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"CHUTHIHONG\SQLEXPRESS",
                InitialCatalog = "QLBANHANG_FINAL1",
                IntegratedSecurity = true,
                Encrypt = true,
                TrustServerCertificate = true
            };
            using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
            {
                // Truy vấn để kiểm tra thông tin người dùng
                string query = @"
                    SELECT maTaiKhoan, hoTen, loaiNguoiDung
                    FROM NGUOIDUNG
                    WHERE hoTen = @Username AND matKhau = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Lấy thông tin người dùng từ cơ sở dữ liệu
                        string maTaiKhoan = reader["maTaiKhoan"].ToString();
                        string hoTen = reader["hoTen"].ToString();
                        string loaiNguoiDung = reader["loaiNguoiDung"].ToString();

                        // Lưu thông tin người dùng vào Session
                        Session["maTaiKhoan"] = maTaiKhoan;
                        Session["hoTen"] = hoTen;
                        Session["Role"] = loaiNguoiDung;

                        // Điều hướng dựa vào vai trò
                        if (loaiNguoiDung == "1") // Giả sử "1" là Admin
                        {
                            Response.Redirect("~/Admin/Admin.aspx");
                        }
                        else if (loaiNguoiDung == "2") // Giả sử "2" là Khách hàng
                        {
                            Response.Redirect("~/HomePage.aspx");
                        }
                        else
                        {
                            lblMessage.Text = "Quyền truy cập không xác định!";
                            lblMessage.CssClass = "error-message error show";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Sai tài khoản hoặc mật khẩu!";
                        lblMessage.CssClass = "error-message error show";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Đã xảy ra lỗi: " + ex.Message;
                    lblMessage.CssClass = "error-message error show";
                }
            }
        }
    }
}