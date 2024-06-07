<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaVehiculo.aspx.cs" Inherits="TPCGrupo30.AltaVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-100">
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">
                            <h3 class="mb-4 pb-2 pb-md-0 mb-md-5">Registrar Vehiculo a Cliente</h3>
                            <asp:Label ID="lblNombreCli" runat="server" Text="Label"></asp:Label>
                            <hr />
                            <div class="row">
                                <div class="col-md-6 mb-4">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtNombreVehiculo">Nombre: </label>
                                        <asp:TextBox ID="txtNombreVehiculo" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtMarca">Marca: </label>
                                        <asp:TextBox ID="txtMarca" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-4 d-flex align-items-center">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtModelo">Modelo: </label>
                                        <asp:TextBox ID="txtModelo" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtAnio">Anio: </label>
                                        <asp:TextBox ID="txtAnio" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-4 pb-2">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtPatente">Patente: </label>
                                        <asp:TextBox ID="txtPatente" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
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
                                        <label class="form-label" for="txtTipoVehiculo">Tipo Vehiculo: </label>
                                        <asp:TextBox ID="txtTipoVehiculo" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="d-flex justify-content-between align-items-center mb-4">
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary btn-lg"  />
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
