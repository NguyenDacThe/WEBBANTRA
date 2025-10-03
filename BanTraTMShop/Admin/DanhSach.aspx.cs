using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop.Admin
{
    public partial class DanhSach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra nếu người dùng đã đăng nhập
                if (Session["maTaiKhoan"] != null)
                {
                    int userId = Convert.ToInt32(Session["maTaiKhoan"]);
                    LoadOrders(userId); // Gọi phương thức LoadOrders với userId
                }
                else
                {
                    Response.Redirect("Login.aspx"); // Chuyển hướng tới trang đăng nhập nếu chưa đăng nhập
                }
            }
        }
        // Phương thức tải đơn hàng theo userId
        private void LoadOrders(int userId)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"CHUTHIHONG\SQLEXPRESS",
                InitialCatalog = "QLBANHANG_FINAL1",
                IntegratedSecurity = true,
                Encrypt = true,
                TrustServerCertificate = true
            };

            // Câu lệnh truy vấn lấy đơn hàng của người dùng
            string query = "SELECT maDonHang, ngayDatHang, ngayHuy, lyDoHuy, tinhTrang, tongTien FROM DONHANG WHERE maTaiKhoan = @maTaiKhoan ORDER BY ngayDatHang DESC";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị tất cả đơn hàng vào GridView
                    gvOrderHistory.DataSource = dataTable;
                    gvOrderHistory.DataBind();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Lỗi: " + ex.Message;
                    lblMessage.Visible = true;
                }
            }
        }


        protected void gvOrderHistory_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewOrder")
            {
                string orderId = e.CommandArgument.ToString();
                Response.Redirect("Xemdonhang.aspx?maDonHang=" + orderId);
            }
        }
    }
}