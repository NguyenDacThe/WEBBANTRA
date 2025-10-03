<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="BanTraTMShop.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        /* CSS sẽ được thêm sau phần HTML */
        .checkout-form {
    background-color: #fff;
    border-radius: 5px;
    padding: 20px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.checkout-form .form-group {
    margin-bottom: 20px;
}

.checkout-form .form-group label {
    font-weight: bold;
}

.checkout-form .form-control {
    border-radius: 5px;
    padding: 10px;
    border: 1px solid #ccc;
    font-size: 16px;
}

.checkout-form .form-control:focus {
    border-color: #007bff;
}

.checkout-form .text-end {
    font-weight: bold;
    font-size: 18px;
}

/* Tạo khoảng cách cho các phần tử */
.mt-4 {
    margin-top: 40px;
}

.mb-4 {
    margin-bottom: 40px;
}

/* Căn chỉnh nút thanh toán */
.text-center {
    text-align: center;
}

.btn-primary {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 10px 30px;
    border-radius: 5px;
    cursor: pointer;
}

.btn-primary:hover {
    background-color: #0056b3;
}
    </style>

   <form id="form1" runat="server">
        <div>
            <h2>Thanh Toán</h2>

            <!-- Hiển thị tổng tiền -->
            <asp:Label ID="lblTotal" runat="server" Text="Tổng tiền: "></asp:Label><br />

            <!-- Thông tin người dùng -->
            <label for="txtName">Họ tên:</label>
            <asp:TextBox ID="txtName" runat="server" /><br />
            
            <label for="txtAddress">Địa chỉ:</label>
            <asp:TextBox ID="txtAddress" runat="server" /><br />

            <label for="txtPhone">Số điện thoại:</label>
            <asp:TextBox ID="txtPhone" runat="server" /><br />

            <!-- Phương thức thanh toán -->
            <label for="paymentMethod">Phương thức thanh toán:</label>
            <asp:DropDownList ID="paymentMethod" runat="server">
                <asp:ListItem Value="Tiền mặt">Tiền mặt</asp:ListItem>
                <asp:ListItem Value="Chuyển khoản">Chuyển khoản</asp:ListItem>
            </asp:DropDownList><br />

            <!-- Nút xác nhận thanh toán -->
            <asp:Button ID="btnConfirmPayment" runat="server" Text="Xác nhận thanh toán" OnClick="btnConfirmPayment_Click" />
        </div>
    </form>
</asp:Content>
