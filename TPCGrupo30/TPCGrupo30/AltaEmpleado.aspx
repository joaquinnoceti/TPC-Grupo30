<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaEmpleado.aspx.cs" Inherits="TPCGrupo30.AltaEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-100">
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">
                            <h3 class="mb-4 pb-2 pb-md-0 mb-md-5">Registrar Empleado</h3>

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
                                        <label for="txtEmail" class="form-label">Email:</label>
                                        <asp:TextBox ID="txtEmail" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
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
                                        <label class="form-label" for="txtFechaRegistro">Fecha Registro: </label>
                                        <asp:TextBox ID="txtFechaRegistro" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4 pb-2">

                                    <div class="form-outline">
                                        <label class="form-label" for="Categoria">Categoria: </label>
                                        <asp:TextBox ID="txtCategoria" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-4 pb-2">

                                    <div class="form-outline">
                                        <label class="form-label" for="Especialidad">Especialidad: </label>
                                        <asp:TextBox ID="txtEspecialidad" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4 pb-2">

                                    <div class="form-outline">
                                        <label class="form-label" for="Rol">Rol: </label>
                                        <asp:TextBox ID="txtRol" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="d-flex justify-content-between align-items-center mb-4">
                                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary btn-lg" />
                                <div class="ml-auto">
                                    <a href="ABMEmpleados.aspx" class="btn btn-outline-danger">Atras</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
