using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop
{
    public partial class DSdonhang : System.Web.UI.Page
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
                    // Thêm tham số cho truy vấn SQL
                    adapter.SelectCommand.Parameters.AddWithValue("@maTaiKhoan", userId);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        // Hiển thị đơn hàng vào GridView
                        gvOrders.DataSource = dataTable;
                        gvOrders.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = "Không tìm thấy đơn hàng nào.";
                        lblMessage.Visible = true;
                        gvOrders.DataSource = null;
                        gvOrders.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Lỗi: " + ex.Message;
                    lblMessage.Visible = true;
                }
            }
        }

        // Xử lý khi người dùng nhấn vào lệnh "Xem đơn hàng"
        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewOrder")
            {
                string orderId = e.CommandArgument.ToString();
                // Chuyển hướng đến trang xem chi tiết đơn hàng
                Response.Redirect("Xemdonhang.aspx?maDonHang=" + orderId);
            }
        }
    }
}