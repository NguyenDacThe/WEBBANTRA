<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BanTraTMShop.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <style>
        .container {
    max-width: 1200px;
    margin: 0 auto;
}

/* Định dạng các thành phần chính trong giỏ hàng */
.cart-item {
    display: flex;
    padding: 15px;
    border-bottom: 1px solid #ddd;
    margin-bottom: 20px;
}

/* Hình ảnh sản phẩm */
.cart-item img {
    max-width: 100px;
    max-height: 100px;
    object-fit: cover;
}

/* Định dạng thông tin sản phẩm */
.cart-item .col-md-6 {
    padding-left: 20px;
}

/* Tạo màu nền cho các button */
.btn {
    border-radius: 5px;
    padding: 10px 20px;
    border: none;
    cursor: pointer;
}

.btn-primary {
    background-color: #007bff;
    color: white;
}

.btn-primary:hover {
    background-color: #0056b3;
}

.btn-warning {
    background-color: #ffc107;
    color: white;
}

.btn-warning:hover {
    background-color: #e0a800;
}

.btn-danger {
    background-color: #dc3545;
    color: white;
}

.btn-danger:hover {
    background-color: #c82333;
}

/* Tạo giao diện cho tổng tiền */
.total-row {
    background-color: #f8f9fa;
    padding: 15px;
    border-radius: 5px;
    margin-top: 20px;
    font-size: 20px;
}

.total-row h4 {
    font-weight: bold;
}

.text-end {
    text-align: right;
}

/* Định dạng cho các thông báo */
.error-message {
    color: red;
    font-weight: bold;
    display: none;
}

.success-message {
    color: green;
    font-weight: bold;
}

/* Tạo khoảng cách giữa các thành phần */
.mt-4 {
    margin-top: 40px;
}

.mb-4 {
    margin-bottom: 40px;
}

/* Tạo hiệu ứng khi hover vào các sản phẩm trong giỏ hàng */
.cart-item:hover {
    background-color: #f0f0f0;
    transition: background-color 0.3s ease;
}

/* Căn chỉnh nút thanh toán */
.text-center {
    text-align: center;
}

/* Các thẻ input và select trong giỏ hàng */
.form-control {
    padding: 10px;
    border-radius: 5px;
    border: 1px solid #ccc;
    margin-top: 10px;
    font-size: 16px;
}

/* Định dạng cho phần tổng tiền khi thanh toán */
.total-row h4 strong {
    color: green;
}
    </style>
    <div class="container mt-4">
        <h2 class="text-center mb-4">Giỏ Hàng</h2>

        <!-- Repeater hiển thị các mặt hàng trong giỏ hàng -->
        <asp:Repeater ID="rptCart" runat="server">
            <ItemTemplate>
                <div class="row cart-item border-bottom py-3">
                    <div class="col-md-2">
                        <img src='<%# ResolveUrl("~/image/tra1" + Eval("anh")) %>' alt="Book Image" class="img-fluid" />
                    </div>
                    <div class="col-md-6">
                        <h5><%# Eval("tenTra") %></h5>
                        <p>Giá: <strong><%# Eval("giaBan", "{0}") %> VND</strong></p>
                        <p>
                            Số lượng: 
                            <asp:TextBox ID="txtsoLuong" runat="server" Text='<%# Eval("soLuong") %>' CssClass="form-control w-25" />
                        </p>
                        <p>
                            Tổng: <strong><%# ((decimal)Eval("Gia") * (int)Eval("SoLuong")).ToString() %> VND</strong>
                        </p>
                    </div>
                    <div class="col-md-4 d-flex align-items-center justify-content-end">
                        <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CommandName="Update" CommandArgument='<%# Eval("maTra") %>' OnClick="btnUpdate_Click" CssClass="btn btn-warning me-2" />
                        <asp:Button ID="btnDelete" runat="server" Text="Xóa" CommandName="Delete" CommandArgument='<%# Eval("maTra") %>' OnClick="btnDelete_Click" CssClass="btn btn-danger" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa không?');"/>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <!-- Tổng tiền -->
        <div class="total-row text-end mt-4">
            <h4><strong>Tổng cộng: </strong><asp:Label ID="lblTotal" runat="server" CssClass="text-success"></asp:Label></h4>
        </div>

        <!-- Thanh toán -->
        <div class="text-center mt-4 mb-4">
            <asp:Button ID="btnCheckout" runat="server" Text="Thanh Toán" OnClick="btnCheckout_Click" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
