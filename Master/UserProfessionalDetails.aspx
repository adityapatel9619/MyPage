<%@ Page Title="" Language="C#" MasterPageFile="~/UserDashBoard.Master" AutoEventWireup="true" CodeBehind="UserProfessionalDetails.aspx.cs" Inherits="MyPage.Master.UserProfessionalDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="px-4 py-3 mb-8 mt-4 bg-white rounded-lg shadow-md dark:bg-gray-800">

        <asp:Menu ID="Menu1" Orientation="Horizontal"
            OnMenuItemClick="Menu1_MenuItemClick" runat="server" StaticDisplayLevels="1">
            <StaticMenuItemStyle CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-auto p-4.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500 tabs" />
            <Items>
                <asp:MenuItem Text="Employee Details" Value="0" Selected="true" />
                <asp:MenuItem Text="Experience Details" Value="1" />
                <asp:MenuItem Text="Document Details" Value="2" />
            </Items>
        </asp:Menu>

        <div class="tabContents">
            <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="grid gap-6 mb-6 md:grid-cols-2">
                        <div>
                            <asp:Label runat="server" CssClass="block mb-2 text-sm font-medium text-gray-900 dark:text-white" Text="First Name"></asp:Label>
                            <asp:TextBox runat="server" ID="tbFName" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label runat="server" CssClass="block mb-2 text-sm font-medium text-gray-900 dark:text-white" Text="Last Name"></asp:Label>
                            <asp:TextBox runat="server" ID="tblName" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></asp:TextBox>
                        </div>
                    </div>
                    <div class="grid gap-6 mb-6 md:grid-cols-2">
                        <div>
                            <asp:Label runat="server" CssClass="block mb-2 text-sm font-medium text-gray-900 dark:text-white" Text="Date Of Joining"></asp:Label>
                            <asp:TextBox runat="server" ID="dtDoJ" TextMode ="Date" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label runat="server" CssClass="block mb-2 text-sm font-medium text-gray-900 dark:text-white" Text="Employee ID"></asp:Label>
                            <asp:TextBox runat="server" ID="tbEMPID" ReadOnly="true" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label runat="server" CssClass="block mb-2 text-sm font-medium text-gray-900 dark:text-white" Text="Office Email ID"></asp:Label>
                            <asp:TextBox runat="server" ID="tbEmailID" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"></asp:TextBox>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <br />

                    <div class="px-4 py-3 mb-8 mt-4 bg-white rounded-lg shadow-md dark:bg-gray-800">
                       <asp:GridView runat="server" ID="gvExperience" AutoGenerateColumns="false" ShowFooter="true" CssClass="w-full whitespace-no-wrap">
                           <Columns>
                               <asp:BoundField DataField="Id" HeaderText="Sr No" />
                               <asp:TemplateField HeaderText="Company Name">
                                   <ItemTemplate>
                                       <asp:TextBox ID="tbCompanyName" runat="server" Text='<%#Eval("CompanyName") %>'  CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"/>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="Start Date">
                                   <ItemTemplate>
                                       <asp:TextBox ID="tbStartDate" runat="server" Text='<%#Eval("StartDate") %>' TextMode="Date" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"/>
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:TemplateField HeaderText="End Date">
                                   <ItemTemplate>
                                       <asp:TextBox ID="tbEndDate" runat="server" Text='<%#Eval("EndDate") %>' TextMode="Date" CssClass="bg-gray-50 border border-gray-300 text-gray-900 text-lg rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"/>
                                   </ItemTemplate>
                               </asp:TemplateField>
                           </Columns>
                       </asp:GridView>
                        <asp:Button runat="server" ID="btnNewRow" Text="Add New Row" OnClick="btnNewRow_Click" CssClass="btn btn-primary"/>
                    </div>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <br />
                    This is the third view
            <br />
                    This is the third view
            <br />
                    This is the third view
            <br />
                    This is the third view
                </asp:View>
            </asp:MultiView>
        </div>
        <asp:Button runat="server" ID="btnDraft" Text="Save as Draft" CssClass="btn btn-warning" OnClick="btnDraft_Click"/>
        <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" />
    </div>

</asp:Content>
