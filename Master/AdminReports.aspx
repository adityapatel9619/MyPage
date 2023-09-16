<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="AdminReports.aspx.cs" Inherits="MyPage.Master.TestModal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col text-center mt-2">
                <asp:Button runat="server" ID="btnGenrateData" CssClass="btn btn-outline-danger" Text="Generate" target="_blank" OnClick="btnGenrateData_Click"/>
            </div>
        </div>
        
    </div>    
</asp:Content>
