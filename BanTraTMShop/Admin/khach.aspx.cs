using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop.Admin
{
    public partial class khach : System.Web.UI.Page
    {
        
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    BindData();
                }
            }

            private void BindData()
            {
                QLKH qlkh = new QLKH();
                List<NguoiDung> dsKhachHang = qlkh.GetDSKH();
                RepeaterCustomer.DataSource = dsKhachHang;
                RepeaterCustomer.DataBind();
            }
        public class QLKH
        {
            private string connectionString = @"Data Source=CHUTHIHONG\SQLEXPRESS;Initial Catalog=demosach3;Integrated Security=True;";

            // Phương thức lấy danh sách khách hàng
            public List<NguoiDung> GetDSKH()
            {
                List<NguoiDung> ds = new List<NguoiDung>();
                string query = @"
                SELECT 
                    u.maTaiKhoan,
                    u.hoTen,
                    u.email,
                    u.matKhau,
                    u.soDT,
                    u.diaChi,
                    COUNT(dh.maDonHang) AS soLuong
                FROM 
                    NGUOIDUNG u
                LEFT JOIN 
                    DONHANG dh ON u.maTaiKhoan = dh.maTaiKhoan
                WHERE 
                    u.loaiNguoiDung = 2
                GROUP BY 
                   u.maTaiKhoan,
                    u.hoTen,
                    u.email,
                    u.matKhau,
                    u.soDT,
                    u.diaChi,";

                SqlConnection con = new SqlConnection(connectionString);

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        NguoiDung u = new NguoiDung();
                        u.maTaiKhoan = (int)rd["ID_User"];
                        u.hoTen = (string)rd["TenNguoiDung"];
                        u.email = (string)rd["Email"];
                        u.matKhau = (string)rd["MatKhau"];
                        u.soDT = (string)rd["SoDienThoai"];
                        ds.Add(u);  // Thêm vào danh sách khách hàng
                    }
                }
                catch (Exception ex)
                {
                    // Log lỗi hoặc xử lý lỗi ở đây
                    throw new ApplicationException("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message);
                }
                finally
                {
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                    }
                }

                return ds;
            }
        }
    }
    }