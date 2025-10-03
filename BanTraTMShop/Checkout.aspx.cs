using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace BanTraTMShop
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra người dùng đã đăng nhập chưa
                if (Session["maTaiKhoan"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    int maTaiKhoan = Convert.ToInt32(Session["maTaiKhoan"]);
                    LoadCartTotal(maTaiKhoan);
                }
            }
        }

        private void LoadCartTotal(int maTaiKhoan)
        {
            // Kết nối với cơ sở dữ liệu để lấy tổng giá trị giỏ hàng
            DatabaseHelper db = new DatabaseHelper();
            decimal totalAmount = db.GetCartTotal(maTaiKhoan);

            // Hiển thị tổng tiền
            lblTotal.Text = totalAmount.ToString("C") + " VND";
        }

        protected void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            // Kiểm tra người dùng đã đăng nhập chưa
            if (Session["maTaiKhoan"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int maTaiKhoan = Convert.ToInt32(Session["maTaiKhoan"]);
            string name = txtName.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;
            string paymentMethodSelected = paymentMethod.SelectedValue;

            // Xử lý thông tin thanh toán và lưu vào cơ sở dữ liệu
            DatabaseHelper db = new DatabaseHelper();

            try
            {
                // Lưu thông tin thanh toán
                bool paymentSuccess = db.ProcessPayment(maTaiKhoan, name, address, phone, paymentMethodSelected);

                if (paymentSuccess)
                {
                    Response.Redirect("ThankYou.aspx"); // Redirect to ThankYou page after payment success
                }
                else
                {
                    Response.Write("<script>alert('Thanh toán không thành công. Vui lòng thử lại.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Có lỗi xảy ra: " + ex.Message + "');</script>");
            }
        }
    }
}