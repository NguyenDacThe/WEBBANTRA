<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="DanhSach.aspx.cs" Inherits="BanTraTMShop.Admin.DanhSach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
<style>
    .btn-view-history {
        background-color: #ffffff;
        color: white;
        padding: 10px 20px;
        border: none;
        border-radius: 5px;
        font-size: 16px;
        cursor: pointer;
        text-align: center;
    }
</style>
<h2 style="color:#fff;">Lịch Sử Đơn Hàng</h2>
<div class="btn-view-history">
    <asp:GridView ID="gvOrderHistory" runat="server" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" GridLines="None"
        OnRowCommand="gvOrderHistory_RowCommand">
        <Columns>
            <asp:BoundField DataField="maDonHang" HeaderText="Mã đơn hàng" SortExpression="maDonHang" />
            <asp:BoundField DataField="ngayDatHang" HeaderText="Ngày đặt hàng" SortExpression="ngayDatHang"  DataFormatString="{0:yyyy-MM-dd}"/>
            <asp:BoundField DataField="ngayHuy" HeaderText="Ngày hủy" SortExpression="ngayHuy"  DataFormatString="{0:yyyy-MM-dd}"/>
            <asp:BoundField DataField="lyDoHuy" HeaderText="Lý do hủy" SortExpression="lyDoHuy" />
            <asp:BoundField DataField="tinhTrang" HeaderText="Tình trạng" SortExpression="tinhTrang" />
            <asp:BoundField DataField="tongTien" HeaderText="Tổng tiền" SortExpression="tongTien" DataFormatString="{0:C}"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnViewOrder" runat="server" Text="Xem Chi Tiết" CommandName="ViewOrder"
                        CommandArgument='<%# Eval("ID_Order") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
