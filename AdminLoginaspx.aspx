<%@ Page Title="Admin Login" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="AdminLoginaspx.aspx.cs" Inherits="MyPage.AdminLoginaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login - Admin</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mb-4 text-xl font-semibold text-gray-700 dark:text-gray-200">Admin Login</h1>
    <%-- Email ID --%>
    <div class="block text-sm">
        <asp:Label runat="server" ID="lblEmail" CssClass="text-gray-700 dark:text-gray-400">Email</asp:Label>
        <asp:TextBox runat="server" CssClass="block w-full mt-1 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" ID="tbEmail" placeholder="admin"></asp:TextBox>
    </div>
    
    <%-- Password --%>
    <div class="block mt-4 text-sm">
        <asp:Label runat="server" ID="lblPassword" CssClass="text-gray-700 dark:text-gray-400">Password</asp:Label>
        <asp:TextBox runat="server" ID="tbPassword" type="password" CssClass="block w-full mt-1 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" placeholder="***************"></asp:TextBox>
    </div>

    <%-- Login Buuton --%>
    <asp:Button runat="server" ID="btnLogin" CssClass="block w-full px-4 py-2 mt-4 text-sm font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" Text="Log In"  OnClick="btnLogin_Click"/>

    <hr class="my-8" />

    <%-- Forgot Password --%>
    <div class="mt-4">
        <asp:HyperLink runat="server" CssClass="text-sm font-medium text-purple-600 dark:text-purple-400 hover:underline">Forgot your password ?</asp:HyperLink>
    </div>

<%--    <div class="mt-1">
        <asp:HyperLink runat="server" CssClass="text-sm font-medium text-purple-600 dark:text-purple-400 hover:underline">New User ?</asp:HyperLink>
    </div>--%>


</asp:Content>
