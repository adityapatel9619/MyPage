<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="MyPage.User.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="Assests/css/tailwind.output.css" />
    
    <script src="https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js"></script>
    <script src="Assests/js/init-alpine.js"></script>

    <%-- Sweet Alert --%>
    <script src="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.min.js"></script>
    <link rel="stylesheet" type="text/css" href="https://common.olemiss.edu/_js/sweet-alert/sweet-alert.css" />
    <%-- Sweet Alert --%>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <section class="vh-100" style="background-color: #eee;">
                <div class="container h-100">
                    <div class="row d-flex justify-content-center align-items-center h-100">
                        <div class="col-lg-12 col-xl-11">
                            <div class="card text-black" style="border-radius: 25px;">
                                <div class="card-body p-md-5">
                                    <div class="row justify-content-center">
                                        <div class="col-md-10 col-lg-6 col-xl-5 order-2 order-lg-1">

                                            <p class="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Sign up</p>

                                            <div class="mx-1 mx-md-4">

                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <asp:Label runat="server" ID="lblName" Text="Your First Name"></asp:Label>
                                                        <asp:TextBox runat="server" ID="tbName" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-user fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <asp:Label runat="server" ID="lblLastName" Text="Your Last Name"></asp:Label>
                                                        <asp:TextBox runat="server" ID="tbLastName" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-envelope fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <asp:Label runat="server" ID="lblEmail" Text="Your Email"></asp:Label>
                                                        <asp:TextBox runat="server" ID="tbEmail" CssClass="form-control" placeholder="Email Id"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="d-flex flex-row align-items-center mb-4">
                                                    <i class="fas fa-lock fa-lg me-3 fa-fw"></i>
                                                    <div class="form-outline flex-fill mb-0">
                                                        <asp:Label runat="server" ID="lblPass" Text="Your Password"></asp:Label>
                                                        <asp:TextBox runat="server" ID="tbPass" CssClass="form-control" type="password"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="form-check d-flex justify-content-center mb-5">
                                                    <asp:CheckBox runat="server" ID="chkTerms" />
                                                    <asp:Label runat="server" CssClass="form-check-label">
                                                        I agree all statements in <a href="#!">Terms of service</a></asp:Label>
                                                </div>

                                                <div class="d-flex justify-content-center mx-4 mb-3 mb-lg-4">
                                                    <asp:Button runat="server" ID="btnRegister" Text="Register" CssClass="btn btn-primary btn-lg"
                                                        OnClick="btnRegister_Click"/>
                                                </div>

                                            </div>

                                        </div>
                                        <div class="col-md-10 col-lg-6 col-xl-7 d-flex align-items-center order-1 order-lg-2">

                                            <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-registration/draw1.webp"
                                                class="img-fluid" alt="Sample image" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ENjdO4Dr2bkBIFxQpeoTz1HIcje39Wm4jDKdf19U8gI4ddQ3GYNS7NTKfAdVQSZe" crossorigin="anonymous"></script>
</body>
</html>
