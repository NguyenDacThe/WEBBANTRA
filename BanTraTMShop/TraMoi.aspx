<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="TraMoi.aspx.cs" Inherits="BanTraTMShop.TraMoi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="padding-left: 20px; margin-bottom: 5px">Trà Thảo Mộc</h3>
    <hr style="border: none; height: 3px; background-color: #007bff; margin-left: 20px; width: 100%;"/> 
    <style>
       .products {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-around;
            margin: 20px 50px;
        }
        .product {
            width: 250px;
            height: 350px;
            margin: 20px;
            border: none;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            transition: transform 0.1s, box-shadow 0.1s;
            padding: 20px;
            background-color: #fff;
            text-align: center;
        }
        .product img {
            object-fit: cover;
            border-radius: 3px;
        }
        .product p {
            margin: 10px 0;
            color: #333;
        }
        .product strong {
            font-size: 18px;
            color: #1E90FF;
        }
        .product:hover {
            transform: translateY(-1px);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.3);
        }
        .product .price {
            color: #FF6347;
            font-weight: bold;
            font-size: 17px;
        }
        .sold-info {
            background-color: rgba(255, 165, 0, 0.8);
            color: white;
            border-radius: 5px;
            padding: 5px 10px;
            font-size: 14px;
            width: 70px;
            height: 20px;
            line-height: 20px;
            margin-left: -10px;
        }
    </style>
        <div class="products">
        <asp:Repeater ID="Repeater" runat="server">
            <ItemTemplate>
                <a href="ProductDetail.aspx?maTra=<%# Eval("maTra") %>" style="text-decoration: none; color: inherit;">
                    <div class="product">
                        <div class="sold-info">
                            Mới
                        </div>
                        <img src="<%# Eval("anh") %>" width="200" height="250" alt="<%# Eval("tenTra") %>" />
                        <p><strong><%# Eval("tenTra") %></strong></p>
                        <p class="price"><%# Eval("giaBan", "{0:N0}") %> VND</p>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
        </div>
</asp:Content>