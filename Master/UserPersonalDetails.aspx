<%@ Page Title="" Language="C#" MasterPageFile="~/UserDashBoard.Master" AutoEventWireup="true" CodeBehind="UserPersonalDetails.aspx.cs" Inherits="MyPage.Master.UserPersonalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Profile Details --%>

    <div class="px-4 py-3 mb-8 mt-4 bg-white rounded-lg shadow-md dark:bg-gray-800">
        <div class="grid gap-6 mb-6 md:grid-cols-2">
            <div>
                <asp:Label runat="server" CssClass="block mb-2 text-sm font-medium text-gray-900 dark:text-white" Text="Name"></asp:Label>
                <asp:TextBox runat="server" ID="tbFirstName" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" ReadOnly="true"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" CssClass="block mb-2 text-sm font-medium text-gray-900 dark:text-white" Text="Name"></asp:Label>
                <asp:TextBox runat="server" ID="tbLastName" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class="mb-4">
            <div>
                <asp:Label runat="server" CssClass="block mb-2 text-sm font-medium text-gray-900 dark:text-white" Text="Email Id"></asp:Label>
                <asp:TextBox runat="server" ID="tbEmail" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <div class="mb-4">
            <div>
                <asp:Image runat="server" CssClass="object-cover w-8 h-8 rounded-full" ID="Image" AlternateText="II" Visible="true" />
                <asp:FileUpload runat="server" ID="fpChange" AllowMultiple="false" Visible="false" />
            </div>
        </div>
        <asp:Button runat="server" ID="btnEdit" CssClass="btn btn-primary" Text="Edit" Visible="true" OnClick="btnEdit_Click" />
        <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-warning" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
        <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-success" Text="Cancel" Visible="false" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
