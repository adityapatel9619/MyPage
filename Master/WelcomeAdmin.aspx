<%@ Page Title="" Language="C#" MasterPageFile="~/AdminDashboard.Master" AutoEventWireup="true" CodeBehind="WelcomeAdmin.aspx.cs" Inherits="MyPage.Master.Welcome" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="PanelModal" runat="server" CssClass="Popup" align="center" style = "display:none">
    <div x-show="isModalOpen" x-transition:enter="transition ease-out duration-150" x-transition:enter-start="opacity-0" x-transition:enter-end="opacity-100" x-transition:leave="transition ease-in duration-150" x-transition:leave-start="opacity-100" x-transition:leave-end="opacity-0" class="fixed inset-0 z-30 flex items-end bg-black bg-opacity-50 sm:items-center sm:justify-center">

      <!-- Modal -->
      <div x-show="isModalOpen" x-transition:enter="transition ease-out duration-150" x-transition:enter-start="opacity-0 transform translate-y-1/2" x-transition:enter-end="opacity-100" x-transition:leave="transition ease-in duration-150" x-transition:leave-start="opacity-100" x-transition:leave-end="opacity-0  transform translate-y-1/2" @click.away="closeModal" @keydown.escape="closeModal" class="w-full px-6 py-4 overflow-hidden bg-white rounded-t-lg dark:bg-gray-800 sm:rounded-lg sm:m-4 sm:max-w-xl" role="dialog" id="modal">
        <!-- Remove header if you don't want a close icon. Use modal body to place modal tile. -->
        <header class="flex justify-end">
          <button class="inline-flex items-center justify-center w-6 h-6 text-gray-400 transition-colors duration-150 rounded dark:hover:text-gray-200 hover: hover:text-gray-700" aria-label="close" @click="closeModal">
            <svg class="w-4 h-4" fill="currentColor" viewBox="0 0 20 20" role="img" aria-hidden="true">
              <path d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z" clip-rule="evenodd" fill-rule="evenodd"></path>
            </svg>
          </button>
        </header>

        <!-- Modal body -->
        <div class="mt-4 mb-6">
          <!-- Modal title -->
          <%--<p class="mb-2 text-lg font-semibold text-gray-700 dark:text-gray-300">Modal header</p>--%>
          <!-- Modal description -->
                <asp:Image runat="server" CssClass="object-cover w-8 h-8 rounded-full" ID="ModImage" AlternateText="II" Visible="true" />
                <asp:FileUpload runat="server" ID="fpChange" AllowMultiple="false" Visible="true" />
        </div>

        <footer class="flex flex-col items-center justify-end px-6 py-3 -mx-6 -mb-4 space-y-4 sm:space-y-0 sm:space-x-6 sm:flex-row bg-gray-50 dark:bg-gray-800">
          
            <asp:Button runat="server" ID="ButtonClose" CssClass="w-full px-5 py-3 text-sm font-medium leading-5 text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg sm:w-auto sm:px-4 sm:py-2 active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple"
                Text="Cancel" />

            <asp:Button runat="server" ID="ButtonUpdate" CssClass="w-full px-5 py-3 text-sm font-medium leading-5 text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg sm:w-auto sm:px-4 sm:py-2 active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple"
                Text="Save Changes"  OnClick="ButtonUpdate_Click"/>            
        </footer>
      </div>
    </div>
</asp:Panel>

    <%--<section style="background-color: #eee;">--%>
  <div class="container py-5">
    <div class="row">
      <div class="col-lg-4">
        <div class="card mb-4">
          <div class="card-body text-center">
              <asp:Image runat="server" CssClass="rounded-circle img-fluid" Width="150px" AlternateText="WOW" ID="crdImage" Visible="true" />
              <br />
                <asp:Label runat="server" CssClass="my-3" ID="crdNickName" Text="John Smith"></asp:Label>
              <br />
                <asp:Label runat="server" CssClass="text-muted mb-1" ID="crdDesignation" Text="Full Stack Developer"></asp:Label>
              <br />
                <asp:Label runat="server" CssClass="text-muted mb-4" ID="crdBOAdd" Text="Bay Area, San Francisco, CA"></asp:Label>
              <br />
            <div class="d-flex justify-content-center mb-2">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Button runat="server" ID="btnEditDetails" CssClass="btn btn-primary" Text="Edit"/>
                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="PanelModal" TargetControlID="btnEditDetails" CancelControlID="ButtonClose" BackgroundCssClass="Background">
                </cc1:ModalPopupExtender>

                <%--<button type="button" class="btn btn-outline-primary ms-1">Message</button>--%>
            </div>
          </div>
        </div>
        <div class="card mb-4 mb-lg-0">
          <div class="card-body p-0">
            <ul class="list-group list-group-flush rounded-3">
              <li class="list-group-item d-flex justify-content-between align-items-center p-3">
                <i class="fas fa-globe fa-lg text-warning"></i>
                <p class="mb-0">https://mdbootstrap.com</p>
              </li>
              <li class="list-group-item d-flex justify-content-between align-items-center p-3">
                <i class="fab fa-github fa-lg" style="color: #333333;"></i>
                <p class="mb-0">mdbootstrap</p>
              </li>
              <li class="list-group-item d-flex justify-content-between align-items-center p-3">
                <i class="fab fa-twitter fa-lg" style="color: #55acee;"></i>
                <p class="mb-0">@mdbootstrap</p>
              </li>
              <li class="list-group-item d-flex justify-content-between align-items-center p-3">
                <i class="fab fa-instagram fa-lg" style="color: #ac2bac;"></i>
                <p class="mb-0">mdbootstrap</p>
              </li>
              <li class="list-group-item d-flex justify-content-between align-items-center p-3">
                <i class="fab fa-facebook-f fa-lg" style="color: #3b5998;"></i>
                <p class="mb-0">mdbootstrap</p>
              </li>
            </ul>
          </div>
        </div>
      </div>
      <div class="col-lg-8">
        <div class="card mb-4">
          <div class="card-body">
            <div class="row">
              <div class="col-sm-3">
                  <asp:Label runat="server" ID="crdlblOffMail" CssClass="mb-0" Text="Official Mail"></asp:Label>
              </div>
              <div class="col-sm-9">
                  <asp:Label runat="server" ID="crdOffMail" CssClass="text-muted mb-0" Text="Jhon.Doe@mail.com"></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                  <asp:Label runat="server" ID="crdlblOffExt" CssClass="mb-0" Text="Office Extension"></asp:Label>
              </div>
              <div class="col-sm-9">
                  <asp:Label runat="server" ID="crdOffExt" CssClass="text-muted mb-0" Text="456"></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                  <asp:Label runat="server" ID="crdlblPhone" CssClass="mb-0" Text="Phone"></asp:Label>
              </div>
              <div class="col-sm-9">
                  <asp:Label runat="server" ID="crdPhone" CssClass="text-muted mb-0" Text="1234567890"></asp:Label>
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-md-6">
            <div class="card mb-4 mb-md-0">
              <div class="card-body">
                  <asp:Label runat="server" ID ="lblCandidateStatus" CssClass="mb-4 text-danger font-bold me-1" Text="Candidate Section"></asp:Label>
                <p class="mb-1" style="font-size: .77rem;">Web Design</p>
                <div class="progress rounded" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 80%" aria-valuenow="80"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <p class="mt-4 mb-1" style="font-size: .77rem;">Website Markup</p>
                <div class="progress rounded" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 72%" aria-valuenow="72"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <p class="mt-4 mb-1" style="font-size: .77rem;">One Page</p>
                <div class="progress rounded" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 89%" aria-valuenow="89"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <p class="mt-4 mb-1" style="font-size: .77rem;">Mobile Template</p>
                <div class="progress rounded" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 55%" aria-valuenow="55"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <p class="mt-4 mb-1" style="font-size: .77rem;">Backend API</p>
                <div class="progress rounded mb-2" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 66%" aria-valuenow="66"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <div class="card mb-4 mb-md-0">
              <div class="card-body">
                <p class="mb-4"><span class="text-primary font-italic me-1">assigment</span> Project Status
                </p>
                <p class="mb-1" style="font-size: .77rem;">Web Design</p>
                <div class="progress rounded" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 80%" aria-valuenow="80"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <p class="mt-4 mb-1" style="font-size: .77rem;">Website Markup</p>
                <div class="progress rounded" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 72%" aria-valuenow="72"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <p class="mt-4 mb-1" style="font-size: .77rem;">One Page</p>
                <div class="progress rounded" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 89%" aria-valuenow="89"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <p class="mt-4 mb-1" style="font-size: .77rem;">Mobile Template</p>
                <div class="progress rounded" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 55%" aria-valuenow="55"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
                <p class="mt-4 mb-1" style="font-size: .77rem;">Backend API</p>
                <div class="progress rounded mb-2" style="height: 5px;">
                  <div class="progress-bar" role="progressbar" style="width: 66%" aria-valuenow="66"
                    aria-valuemin="0" aria-valuemax="100"></div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
<%--</section>--%>
</asp:Content>
