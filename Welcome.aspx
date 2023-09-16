<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="MyPage.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Welcome <asp:Label ID="lblName" runat="server"></asp:Label></h1>



  <div id="dvImageUpload" style="margin-top:50px;">
      <asp:Label runat="server" Text="Upload Image" CssClass="form-label"></asp:Label>
      <asp:FileUpload runat="server" ID="fImage"/>
  </div>

  <div id="dvUpload" style="margin-top:50px;">
        <asp:Button runat="server" ID="btnUpload" Text="Upload" OnClick="btnUpload_Click"/>
  </div>

  <div id="dvShowImage" style="margin-top:50px;">
        <asp:Image ID="iImage" runat="server" Height="400" Width="200" ImageAlign="Right"  />
  </div>

</asp:Content>
