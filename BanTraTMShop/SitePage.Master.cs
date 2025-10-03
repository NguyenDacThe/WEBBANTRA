using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop
{
    public partial class SitePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Xóa các session
            Session["maTaiKhoan"] = null;
            Session["Role"] = null;

            // Chuyển hướng  đến trang đăng nhập
            Response.Redirect("~/Login.aspx");
        }
        protected void btnCart_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Cart.aspx");
        }

        public event EventHandler SearchButtonClick;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (SearchButtonClick != null)
            {
                SearchButtonClick(this, e);
            }
        }
        public string GetSearchTerm()
        {
            return txtSearch.Text.Trim();
        }
        protected void btnUserIcon_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"CHUTHIHONG\SQLEXPRESS",
                InitialCatalog = "QLBANHANG_FINAL1",
                IntegratedSecurity = true,
                Encrypt = true,
                TrustServerCertificate = true
            };
            string query = "SELECT hoTen, matKhau, email, soDT, ngaySinh FROM NGUOIDUNG WHERE loaiNguoiDung = 'khach hang'";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Response.Redirect("ThongtinTK.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Không có khách hàng nào.');</script>");
                }
            }
            if (Session["ID_User"] != null)
            {
                Response.Redirect("ThongtinTK.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnViewOrderHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("XemLichSuDonHang.aspx");
        }
    }
}