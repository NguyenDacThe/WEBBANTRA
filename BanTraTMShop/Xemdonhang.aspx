<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="Xemdonhang.aspx.cs" Inherits="BanTraTMShop.Xemdonhang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
        }

        .container {
            width: 80%;
            margin: 0 auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        h2 {
            text-align: center;
            color: #333;
            font-size: 28px;
            margin-bottom: 20px;
        }

        h4 {
            font-size: 20px;
            color: #444;
            margin-bottom: 10px;
        }

        .order-header {
            margin-bottom: 30px;
            padding-bottom: 15px;
            border-bottom: 2px solid #f2f2f2;
            margin-top: 10px;
        }

        .order-header p {
            font-size: 16px;
            color: #555;
            margin: 5px 0;
        }

        .order-header strong {
            color: #333;
        }

        .order-details {
            margin-top: 20px;
        }

        .order-details h4 {
            font-size: 22px;
            color: #333;
            margin-bottom: 15px;
        }

        .gridview-container {
            margin-top: 20px;
            overflow-x: auto;
        }

        .gridview-container table {
            width: 100%;
            border-collapse: collapse;
        }

        .gridview-container th, .gridview-container td {
            padding: 10px;
            text-align: left;
            border-bottom: 1px solid #ddd;
            font-size: 16px;
        }

        .gridview-container th {
            background-color: #f4f4f4;
            color: #333;
        }

        .gridview-container tr:hover {
            background-color: #f9f9f9;
        }

        .gridview-container td {
            color: #555;
        }

        .alert-message {
            color: red;
            font-weight: bold;
        }
    </style>

    <div class="container">
        <h2>Thông tin đơn hàng</h2>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false" CssClass="alert-message"></asp:Label>

        <div class="order-header">
            <h4>Thông tin chung:</h4>
            <p><strong>Mã đơn hàng:</strong> <asp:Label ID="lblmaDonHang" runat="server"></asp:Label></p>
            <p><strong>Ngày đặt hàng:</strong> <asp:Label ID="lblngayDatHang" runat="server"></asp:Label></p>
            <p><strong>Ngày hủy:</strong> <asp:Label ID="lblngayHuy" runat="server"></asp:Label></p>
            <p><strong>Lý do hủy:</strong> <asp:Label ID="lbllyDoHuy" runat="server"></asp:Label></p>
            <p><strong>Tình Trạng:</strong> <asp:Label ID="lbltinhTrang" runat="server"></asp:Label></p>
            <p><strong>Tổng tiền:</strong> <asp:Label ID="lbltongTien" runat="server"></asp:Label></p>
        </div>

        <div class="order-details">
            <h4>Chi tiết đơn hàng:</h4>

            <div class="gridview-container">
                <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="False" CssClass="gridview" BorderStyle="None">
                    <Columns>
                        <asp:BoundField DataField="maTra" HeaderText="Mã trà" SortExpression="maTra" />
                        <asp:BoundField DataField="tenTra" HeaderText="Tên trà" SortExpression="tenTra" />
                        <asp:BoundField DataField="soLuong" HeaderText="Số lượng" SortExpression="soLuong" />
                        <asp:BoundField DataField="giaBanRa" HeaderText="Giá bán ra" DataFormatString="{0:C}" SortExpression="giaBanRa" />
                        <asp:BoundField DataField="tongTien" HeaderText="Tổng tiền" DataFormatString="{0:C}" SortExpression="tongTien" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
