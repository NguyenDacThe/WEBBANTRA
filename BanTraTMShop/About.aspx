<%@ Page Title="" Language="C#" MasterPageFile="~/SitePage.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BanTraTMShop.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <main aria-labelledby="title">
     <h2 id="title"><%: Title %>.</h2>
     <h3>Your application description page.</h3>
     <p>Use this area to provide additional information.</p>
 </main>
</asp:Content>
