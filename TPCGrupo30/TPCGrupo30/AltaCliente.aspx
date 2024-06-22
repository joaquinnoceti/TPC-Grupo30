<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="TPCGrupo30.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="vh-100 gradient-custom">
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <div class="container py-5 h-100">
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">
                            <asp:Label ID="Label1" CssClass="form form-control-lg toast-header" runat="server" Text="Registrar Cliente"></asp:Label>
                            <hr />
                            <div class="row">
                                <div class="col-md-6 mb-4">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtNombre">Nombre: </label>
                                        <asp:TextBox ID="txtNombre" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtApellido">Apellido: </label>
                                        <asp:TextBox ID="txtApellido" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-4 d-flex align-items-center">

                                    <div class="form-outline datepicker w-100">
                                        <label for="txtFecha" class="form-label">Fecha Nacimiento:</label>
                                        <asp:TextBox ID="txtFecha" TextMode="Date" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtDni">DNI: </label>
                                        <asp:TextBox ID="txtDni" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-4 pb-2">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtEmail">Email: </label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4 pb-2">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtTelefono">Telefono: </label>
                                        <asp:TextBox ID="txtTelefono" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-4 pb-2">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtDirecion">Direccion: </label>
                                        <asp:TextBox ID="txtDirecion" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="d-flex justify-content-between align-items-center mb-4">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary btn-lg" OnClick="btnAceptar_Click" />
                            <div class="ml-auto">
                                <a href="ABMClientes.aspx" class="btn btn-outline-danger">Atras</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

</asp:Content>
