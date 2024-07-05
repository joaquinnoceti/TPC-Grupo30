<%@ Page Title="Login" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPCGrupo30.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-50">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card bg-dark text-white" style="border-radius: 1rem;">
                        <div class="card-body p-5 text-center">

                            <div class="mb-md-5 mt-md-4 pb-5">

                                <h2 class="fw-bold mb-2">Bienvenido</h2>
                                <p class="text-white-50 mb-5">Porfavor, ingresar credenciales</p>

                                <div  class="form-outline form-white mb-4">
                                    <asp:TextBox ID="txtMail" cssclass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    <label class="form-label" for="typeEmailX">Usuario</label>
                                </div>

                                <div  class="form-outline form-white mb-4">
                                    <asp:TextBox ID="txtPass" TextMode="Password" runat="server" cssclass="form-control form-control-lg"></asp:TextBox>
                                    <label class="form-label" for="typePasswordX">Password</label>
                                </div>
                                <a href="Principal.aspx"  class="btn btn-outline-light btn-lg px-5" >Ingresar</a>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
