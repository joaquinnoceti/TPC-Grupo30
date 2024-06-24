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
                            <asp:Label ID="lblNombreCli" runat="server" Text=""></asp:Label>
                            <hr />
                            <div class="row">
                                <div class="col-md-6 mb-4">

                                    <div class="form-outline">
                                        <label class="form-label" for="ddlMarca">Marca: </label>
                                        <asp:DropDownList ID="ddlMarca" CssClass="form-select form-select-lg" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged"></asp:DropDownList>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtModelo">Modelo: </label>
                                        <asp:DropDownList ID="ddlModelo" CssClass="form-select form-select-lg" runat="server"></asp:DropDownList>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-4 d-flex align-items-center">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtAño">Año: </label>
                                        <asp:TextBox ID="txtAño" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4">

                                    <div class="form-outline">
                                        <label class="form-label" for="txtPatente">Patente: </label>
                                        <asp:TextBox ID="txtPatente" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6 mb-4 pb-2">

                                    <div class="form-outline">
                                        <label class="form-label" for="ddlTipoVehiculo">Tipo Vehiculo: </label>
                                        <asp:DropDownList ID="ddlTipoVehiculo" CssClass="form-select form-select-lg" runat="server">
                                            <asp:ListItem>Coche</asp:ListItem>
                                            <asp:ListItem>Camioneta</asp:ListItem>
                                            <asp:ListItem>Camion</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="col-md-6 mb-4 pb-2">
                                </div>
                            </div>

                            <div class="d-flex justify-content-between align-items-center mb-4">
                                <asp:Button ID="btnAceptar" runat="server" Text="Asignar" CssClass="btn btn-primary btn-lg" OnClick="btnAceptar_Click" />
                                <div class="ml-auto">
                                    <a href="ABMClientes.aspx" class="btn btn-outline-danger">Atras</a>
                                </div>
                            </div>
                            <div>
                                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
