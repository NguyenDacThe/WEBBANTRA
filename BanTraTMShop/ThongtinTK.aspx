<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="ThongtinTK.aspx.cs" Inherits="BanTraTMShop.ThongtinTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Thông tin tài khoản
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    <h3 style="padding-left: 20px; margin-bottom: 5px">Thông tin tài khoản</h3>
    <style>
        .info-container {
            width: 80%;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            background-color: #f9f9f9;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }
        .info-container h2 {
            text-align: center;
            color: #333;
            font-family: 'Arial', sans-serif;
        }
        .info-item {
            margin-bottom: 15px;
        }
        .info-item label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
            color: #333;
        }
        .info-item span {
            margin-left: 10px;
        }
        .info-item input[type="text"] {
                width: 400px;
                padding: 10px;
                margin-top: 5px;
                border-radius: 5px;
                border: 1px solid #ccc;
                font-size: 14px;
                color: #333;
                box-sizing: border-box;
        }
        .info-item input[type="text"]:focus {
            border-color: #5b9bd5;
            outline: none;
        }
        .button-group {
            text-align: center;
            margin-top: 20px;
        }
        .button-group input[type="button"] {
            padding: 10px 20px;
            margin: 10px;
            border-radius: 5px;
            border: 1px solid #007bff;
            background-color: #007bff;
            color: white;
            font-size: 14px;
            cursor: pointer;
        }
        .button-group input[type="button"]:hover {
            background-color: #0056b3;
        }
    </style>
    <div class="info-container">
    <h2>Thông tin tài khoản</h2>
    <div class="info-item">
        <label for="txthoTen">Tên khách hàng:</label>
        <span><asp:Label ID="lblhoTen" runat="server" Text=""></asp:Label></span>
    </div>
     <div class="info-item">
         <asp:TextBox ID="txthoTen" runat="server" Visible="false" ></asp:TextBox>
     </div>
    <div class="info-item">
        <label for="txtemail">Email:</label>
        <span><asp:Label ID="lblemail" runat="server" Text=""></asp:Label></span>
    </div>
    <div class="info-item">
        <asp:TextBox ID="txtemail" runat="server" Visible="false"></asp:TextBox>
    </div>
    <div class="info-item">
        <label for="txtsoDT">Số điện thoại:</label>
        <span><asp:Label ID="lblsoDT" runat="server" Text=""></asp:Label></span>
    </div>
    <div class="info-item">
        <asp:TextBox ID="txtsoDT" runat="server" Visible="false"></asp:TextBox>
    </div>
    <div class="info-item">
        <label for="txtmatKhau">Mật khẩu:</label>
        <span><asp:Label ID="lblmatKhau" runat="server" Text=""></asp:Label></span>
    </div>
    <div class="info-item">
        <asp:TextBox ID="txtmatKhau" runat="server" Visible="false"></asp:TextBox>
    </div>
     <div class="info-item">
     <label for="txtngaySinh">Ngày Sinh:</label>
         <span><asp:Label ID="lblngaySinh" runat="server" Text=""></asp:Label></span>
     </div>
     <div class="info-item">
         <asp:TextBox type=" date" ID="txtngaySinh" runat="server" Visible="false"></asp:TextBox>
     </div>
    <div class="button-group">
    <asp:Button ID="btnEdit" runat="server" Text="Sửa thông tin" OnClick="btnEdit_Click" />
    <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" Visible="false" />
    <asp:Button ID="btnCancel" runat="server" Text="Hủy" OnClick="btnCancel_Click" Visible="false" />
    </div>
    <asp:Button ID="btnLogout" runat="server" Text="Đăng xuất" OnClick="btnLogout_Click"/>
</div>
</asp:Content>
