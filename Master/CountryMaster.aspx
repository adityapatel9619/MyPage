<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="CountryMaster.aspx.cs" Inherits="MyPage.Master.CountryMaster" %>
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

            <%-- Country GridView Section --%>
    <div class="px-4 py-3 mb-8 mt-4 bg-white rounded-lg shadow-md dark:bg-gray-800">
        <asp:GridView runat="server" ID="gvCountry" AutoGenerateColumns="false" OnRowEditing="gvCountry_RowEditing" OnRowCancelingEdit="gvCountry_RowCancelingEdit" OnRowUpdating="gvCountry_RowUpdating" CssClass="w-full whitespace-no-wrap">
            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCountryID" Text='<%#Eval("ID")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Country"> 
                    <ItemTemplate> 
                        <asp:Label ID="lblCountryName" runat="server" Text='<%#Eval("CountryName") %>'></asp:Label> 
                    </ItemTemplate> 
                    <EditItemTemplate> 
                        <asp:TextBox ID="tbCountryName" runat="server" Text='<%#Eval("CountryName") %>' CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"></asp:TextBox> 
                    </EditItemTemplate> 
                </asp:TemplateField> 

                <asp:TemplateField HeaderText="Country Code"> 
                    <ItemTemplate> 
                        <asp:Label ID="lblCountryCode" runat="server" Text='<%#Eval("CountryCode") %>'></asp:Label> 
                    </ItemTemplate> 
                    <EditItemTemplate> 
                        <asp:TextBox ID="tbCountryCode" runat="server" Text='<%#Eval("CountryCode") %>' MaxLength="5" CssClass="block w-min ml-3 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input"></asp:TextBox> 
                    </EditItemTemplate> 
                </asp:TemplateField> 


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit"/>
                    </ItemTemplate>
                    <EditItemTemplate> 
                        <asp:LinkButton ID="btn_Update" runat="server" Text="Update" CommandName="Update"/> 
                        <asp:LinkButton ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/> 
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
