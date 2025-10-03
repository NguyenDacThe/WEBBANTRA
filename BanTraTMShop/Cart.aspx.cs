using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanTraTMShop
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            if (Session["maTaiKhoan"] == null)
            {
                lblTotal.Text = "Bạn cần đăng nhập để xem giỏ hàng.";
                lblTotal.CssClass = "error-message show";
                return;
            }

            int userId = Convert.ToInt32(Session["maTaiKhoan"]);

            // Lấy CartId của người dùng
            DatabaseHelper db = new DatabaseHelper();
            int cartId = db.GetCartIdByUserId(userId);

            if (cartId == 0)
            {
                lblTotal.Text = "Giỏ hàng trống.";
                return;
            }

            // Lấy danh sách các sản phẩm trong giỏ hàng
            List<CartItem> cartItems = db.GetCartItems(cartId);
            rptCart.DataSource = cartItems;
            rptCart.DataBind();

            // Tính tổng tiền
            decimal total = 0;
            foreach (var item in cartItems)
            {
                total += item.giaBan * item.soLuong;
            }
            lblTotal.Text = total.ToString("C");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);
            int userId = Convert.ToInt32(Session["maTaiKhoan"]);
            int newQuantity = Convert.ToInt32(((TextBox)btn.NamingContainer.FindControl("txtsoLuong")).Text);

            // Cập nhật số lượng sản phẩm trong giỏ hàng
            DatabaseHelper db = new DatabaseHelper();
            int cartId = db.GetCartIdByUserId(userId);
            db.UpdateCartItemQuantity(cartId, productId, newQuantity);

            LoadCart();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);
            int userId = Convert.ToInt32(Session["maTaiKhoan"]);

            // Xóa sản phẩm khỏi giỏ hàng
            DatabaseHelper db = new DatabaseHelper();
            int cartId = db.GetCartIdByUserId(userId);
            db.DeleteCartItem(cartId, productId);

            LoadCart();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            // Kiểm tra giỏ hàng trống
            if (Session["maTaiKhoan"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int userId = Convert.ToInt32(Session["maTaiKhoan"]);

            // Tạo đơn hàng mới và thanh toán
            DatabaseHelper db = new DatabaseHelper();
            int cartId = db.GetCartIdByUserId(userId);
            List<CartItem> cartItems = db.GetCartItems(cartId);

            if (cartItems.Count == 0)
            {
                Response.Write("<script>alert('Giỏ hàng trống. Vui lòng thêm sản phẩm vào giỏ hàng trước khi thanh toán.');</script>");
                return;
            }

            db.ProcessCheckout(cartId, userId);
            Response.Write("<script>alert('Thanh toán thành công. Cảm ơn bạn đã mua hàng!');</script>");
            Response.Redirect("OrderConfirmation.aspx");
        }
    }
}