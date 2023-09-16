<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="StateMaster.aspx.cs" Inherits="MyPage.Master.StateMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

<div class="px-4 py-3 mb-8 mt-4 bg-white rounded-lg shadow-md dark:bg-gray-800">
<%--        <asp:Label runat="server" CssClass="inline-flex items-center text-gray-600 dark:text-gray-400">
            <span class="text-gray-700 dark:text-gray-400">Select Country:</span>
            <asp:DropDownList runat="server" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"
                ID="dpFilterCountry" OnSelectedIndexChanged="dpFilterCountry_SelectedIndexChanged"></asp:DropDownList>
        </asp:Label>--%>
        <asp:GridView runat="server" ID="gvState" AutoGenerateColumns="false" OnRowEditing="gvState_RowEditing" OnRowCancelingEdit="gvState_RowCancelingEdit" OnRowUpdating="gvState_RowUpdating" OnRowDeleting="gvState_RowDeleting" CssClass="w-full whitespace-no-wrap">
            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblStateID" Text='<%#Eval("ID")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="State"> 
                    <ItemTemplate> 
                        <asp:Label ID="lblStateName" runat="server" Text='<%#Eval("StateName") %>'></asp:Label> 
                    </ItemTemplate> 
                    <EditItemTemplate> 
                        <asp:TextBox ID="tbStateName" runat="server" Text='<%#Eval("StateName") %>' CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"></asp:TextBox> 
                    </EditItemTemplate> 
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="State Code"> 
                    <ItemTemplate> 
                        <asp:Label ID="lblStateCode" runat="server" Text='<%#Eval("StateCode") %>'></asp:Label> 
                    </ItemTemplate> 
                    <EditItemTemplate> 
                        <asp:TextBox ID="tbStateCode" runat="server" Text='<%#Eval("StateCode") %>' MaxLength="5" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"></asp:TextBox> 
                    </EditItemTemplate> 
                </asp:TemplateField> 


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit"/>
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update"/> 
                        <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/> 
                        <asp:LinkButton ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete"/>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
