<%@ Page Title="" Language="C#" MasterPageFile="~/UserDashboard.Master" AutoEventWireup="true" CodeBehind="WelcomeUser.aspx.cs" Inherits="MyPage.Master.WelcomeUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome <asp:Label runat="server" ID="lblTxt" class="font-bold text-red-2000"></asp:Label></h1>
</asp:Content>
