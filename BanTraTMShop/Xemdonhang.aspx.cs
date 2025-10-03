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
    public partial class Xemdonhang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string orderId = Request.QueryString["maDonHang"];
                if (!string.IsNullOrEmpty(orderId))
                {
                    LoadOrderSummary(orderId);
                }
                else
                {
                    Response.Redirect("DSdonhang.aspx");
                }
            }
        }
        private void LoadOrderSummary(string orderId)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"CHUTHIHONG\SQLEXPRESS",
                InitialCatalog = "QLBANHANG_FINAL1",
                IntegratedSecurity = true,
                Encrypt = true,
                TrustServerCertificate = true
            };
            string queryOrder = @"
            SELECT maDonHang, ngayDatHang, ngayHuy, lyDoHuy, tinhTrang, tongTien
            FROM DONHANG
            WHERE maDonHang = @maDonHang";

            string queryOrderDetails = @"
            SELECT ct.maTra, s.tenTra, ct.soLuong, ct.giaBanRa, (ct.soLuong * ct.giaBanRa) AS tongTien
            FROM TRA_DONHANG ct
            JOIN TRA s ON ct.maTra = s.maTra
            WHERE ct.maDonHang = @maDonHang";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Lấy thông tin đơn hàng
                    using (SqlCommand command = new SqlCommand(queryOrder, connection))
                    {
                        command.Parameters.AddWithValue("@maDonHang", orderId);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            lblmaDonHang.Text = reader["maDonHang"].ToString();
                            lblngayDatHang.Text = Convert.ToDateTime(reader["ngayDatHang"]).ToString("dd/MM/yyyy HH:mm");
                            lblngayHuy.Text = reader["ngayHuy"] == DBNull.Value ? "N/A" : Convert.ToDateTime(reader["ngayHuy"]).ToString("dd/MM/yyyy HH:mm");
                            lbllyDoHuy.Text = reader["lyDoHuy"]?.ToString() ?? "N/A";
                            lbltinhTrang.Text = reader["tinhTrang"].ToString();
                            lbltongTien.Text = string.Format("{0} VND", reader["TongTien"]);
                        }
                        else
                        {
                            lblMessage.Text = "Không tìm thấy đơn hàng!";
                            lblMessage.Visible = true;
                            return;
                        }
                        reader.Close();
                    }

                    // Lấy chi tiết đơn hàng
                    using (SqlCommand command = new SqlCommand(queryOrderDetails, connection))
                    {
                        command.Parameters.AddWithValue("@maDonHang", orderId);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            gvOrderDetails.DataSource = dataTable;
                            gvOrderDetails.DataBind();
                        }
                        else
                        {
                            lblMessage.Text = "Không có chi tiết đơn hàng!";
                            lblMessage.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Lỗi: " + ex.Message;
                    lblMessage.Visible = true;
                }
            }
        }
    }
}