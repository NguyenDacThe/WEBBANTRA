<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="khach.aspx.cs" Inherits="BanTraTMShop.Admin.khach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <style>
     body {
         font-family: Arial, sans-serif;
         margin: 20px;
         background-color: #f4f4f9;
     }

     h1 {
         text-align: center;
         color: #f2f2f2;
     }

     table {
         width: 100%;
         border-collapse: collapse;
         margin-top: 20px;
         background-color: #fff;
     }

     th, td {
         padding: 10px;
         text-align: left;
         border: 1px solid #ddd;
     }

     th {
         background-color: #007bff;
         color: white;
     }

     tr:nth-child(even) {
         background-color: #f9f9f9;
     }

     tr:hover {
         background-color: #f1f1f1;
     }

     .btn {
         padding: 5px 10px;
         border: none;
         border-radius: 3px;
         cursor: pointer;
     }

     .btn-delete {
         background-color: #dc3545;
         color: white;
     }

         .btn-delete:hover {
             background-color: #c82333;
         }
 </style>

 <h1 style="color: #f2f2f2;">Quản lý khách hàng</h1>
 <table>
     <thead>
         <tr>
             <th>ID User</th>
             <th>Tên Người Dùng</th>
             <th>Email</th>
             <th>Số Điện Thoại</th>
             <th>Địa Chỉ</th>
             <th>Số Đơn Mua</th>
         </tr>
     </thead>
     <tbody>
         <asp:Repeater ID="RepeaterCustomer" runat="server">
             <ItemTemplate>
                 <tr>
                     <td><%# Eval("maTaiKhoan") %></td>
                     <td><%# Eval("hoTen") %></td>
                     <td><%# Eval("email") %></td>
                     <td><%# Eval("soDT") %></td>
                     <td><%# Eval("diaChi") %></td>
                     <td><%# Eval("soLuong") %></td>
                 </tr>
             </ItemTemplate>
         </asp:Repeater>
     </tbody>
 </table>
</asp:Content>
