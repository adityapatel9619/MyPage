<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="CommunityMaster.aspx.cs" Inherits="MyPage.Master.CommunityMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- Country Section --%>
    <div class="px-4 py-3 mb-8 mt-4 bg-white rounded-lg shadow-md dark:bg-gray-800">
        <asp:Label runat="server" CssClass="inline-flex items-center text-gray-600 dark:text-gray-400">
            <span class="text-gray-700 dark:text-gray-400">Country Name:</span>
            <asp:TextBox runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                placeholder="INDIA" ID="tbCountryName"></asp:TextBox>
        </asp:Label>

        <asp:Label runat="server" CssClass="inline-flex items-center ml-6 text-gray-600 dark:text-gray-400">
                        <span class="text-gray-700 dark:text-gray-400">Country Code:</span>
            <asp:TextBox runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                placeholder="IND" MaxLength="5" ID="tbCountryCode"></asp:TextBox>
        </asp:Label>
        <asp:Button runat="server" CssClass="btn btn-primary ml-3" ID="btnAddCountry" Text="Add" OnClick="btnAddCountry_Click"/>

        <%--<asp:Button runat="server" CssClass="btn btn-success ml-3" ID="btnShowCountry" Text="Show"/>--%>

    </div>

    <%-- State Section --%>
    <div class="px-4 py-3 mb-8 bg-white rounded-lg shadow-md dark:bg-gray-800">
         <div class="mt-6">

        <asp:Label runat="server" CssClass="inline-flex items-center text-gray-600 dark:text-gray-400">
            <span class="text-gray-700 dark:text-gray-400">Select Country:</span>
            <asp:DropDownList runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                ID="dpCountry"></asp:DropDownList>
        </asp:Label>

        <asp:Label runat="server" CssClass="inline-flex items-center text-gray-600 dark:text-gray-400">
            <span class="text-gray-700 dark:text-gray-400">State Name:</span>
            <asp:TextBox runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                placeholder="Maharashtra" ID="tbStateName"></asp:TextBox>
        </asp:Label>

        <asp:Label runat="server" CssClass="inline-flex items-center ml-6 text-gray-600 dark:text-gray-400">
                        <span class="text-gray-700 dark:text-gray-400">State Code:</span>
            <asp:TextBox runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                placeholder="MAH" MaxLength="5" ID="tbStateCode"></asp:TextBox>
        </asp:Label>

        <asp:Button runat="server" CssClass="btn btn-primary ml-3" ID="btnAddState" Text="Add" OnClick="btnAddState_Click"/>
        </div>
    </div>


        <%-- City Section --%>
    <div class="px-4 py-3 mb-8 bg-white rounded-lg shadow-md dark:bg-gray-800">
         <div class="mt-6">

        <asp:Label runat="server" CssClass="inline-flex items-center text-gray-600 dark:text-gray-400">
            <span class="text-gray-700 dark:text-gray-400">Select Country:</span>
            <asp:DropDownList runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                ID="cmbCountry" OnSelectedIndexChanged="cmbCountry_SelectedIndexChanged" AutoPostBack="false"></asp:DropDownList>
        </asp:Label>

        <asp:Label runat="server" CssClass="inline-flex items-center text-gray-600 dark:text-gray-400">
            <span class="text-gray-700 dark:text-gray-400">Select State:</span>
            <asp:DropDownList runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                ID="cmbState"></asp:DropDownList>
        </asp:Label>

        <asp:Label runat="server" CssClass="inline-flex items-center text-gray-600 dark:text-gray-400">
            <span class="text-gray-700 dark:text-gray-400">City Name:</span>
            <asp:TextBox runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                placeholder="Mumbai" ID="tbCityName"></asp:TextBox>
        </asp:Label>

        <asp:Label runat="server" CssClass="inline-flex items-center ml-6 text-gray-600 dark:text-gray-400">
             <span class="text-gray-700 dark:text-gray-400">City Code:</span>
            <asp:TextBox runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                placeholder="MUM" MaxLength="5" ID="tbCityCode"></asp:TextBox>
        </asp:Label>

        <asp:Button runat="server" CssClass="btn btn-primary ml-3" ID="btnAddCity" Text="Add"/>
        </div>
    </div>
</asp:Content>
