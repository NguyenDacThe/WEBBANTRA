using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int maTra = 0;
                if (int.TryParse(Request.QueryString["maTra"], out maTra))
                {
                    // Tạo đối tượng DatabaseHelper để lấy thông tin sản phẩm theo ID_Sach
                    DatabaseHelper dbHelper = new DatabaseHelper();
                    Tra t = dbHelper.GetTeaById(maTra);

                    if (t != null)
                    {
                        // Tạo danh sách chứa sản phẩm để liên kết với Repeater
                        List<Tra> teaList = new List<Tra> { t };

                        // Liên kết dữ liệu với Repeater
                        RepeaterTea.DataSource = teaList;
                        RepeaterTea.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('Không tìm thấy sản phẩm.');</script>");
                    }
                }
            }
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                int maTra = Convert.ToInt32(button.CommandArgument);

                // Kiểm tra nếu người dùng đã đăng nhập chưa
                if (Session["maTaiKhoan"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                int maTaiKhoan = Convert.ToInt32(Session["maTaiKhoan"]);
                DatabaseHelper db = new DatabaseHelper();

                // Kiểm tra giỏ hàng của người dùng
                int maGioHang = db.GetOrCreateCart(maTaiKhoan);

                // Thêm sản phẩm vào giỏ hàng
                bool isAdded = db.AddToCart(maGioHang, maTra, 1);  // Số lượng là 1

                if (isAdded)
                {
                    Response.Write("<script>alert('Sản phẩm đã được thêm vào giỏ hàng.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Không thể thêm sản phẩm vào giỏ hàng.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Có lỗi xảy ra: {ex.Message}');</script>");
            }
        }
    }
}