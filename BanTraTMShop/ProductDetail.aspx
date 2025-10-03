<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="BanTraTMShop.ProductDetail" %>
<asp:Content ID="TitleContent2" ContentPlaceHolderID="TitleContent" runat="server">
    Chi Tiết Sản Phẩm
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <style>
        /* CSS sẽ được thêm sau phần HTML */
        .product-detail {
    background-color: #fff;
    border-radius: 5px;
    padding: 20px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.product-detail .row {
    margin-bottom: 20px;
}

.product-detail img {
    width: 100%;
    max-height: 400px;
    object-fit: cover;
}

.product-detail h4 {
    font-size: 24px;
    margin-bottom: 10px;
}

.product-detail p {
    font-size: 18px;
    margin-bottom: 15px;
}

.product-detail button {
    padding: 10px 20px;
    font-size: 16px;
    border-radius: 5px;
    border: none;
    cursor: pointer;
    background-color: #28a745;
    color: white;
}

.product-detail button:hover {
    background-color: #218838;
}
    </style>

   <asp:Repeater ID="RepeaterTea" runat="server">
    <ItemTemplate>
        <div class="product-detail">
            <img src='<%# Eval("anh") %>' alt="Product Image" />
            <h3><%# Eval("tenTra") %></h3>
            <p><%# Eval("nguyenLieu") %></p>
            <p><%# Eval("moTa") %></p>
            <p>Giá: <%# Eval("giaBan", "{0:C}") %></p>
            <p>Số lượng còn: <%# Eval("soLuongCo") %></p>
            <button runat="server" onserverclick="btnAddToCart_Click" commandargument='<%# Eval("maTra") %>'>Thêm vào giỏ hàng</button>
        </div>
    </ItemTemplate>
</asp:Repeater>
</asp:Content>