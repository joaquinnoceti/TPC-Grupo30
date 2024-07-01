<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NuevoServicio.aspx.cs" Inherits="TPCGrupo30.NuevoServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container register-form">
        <div class="form">
            <div class="form-content">
                <div class="row">
                    <div class="col-md-6 mt-3">
                        <div class="form-group mb-3">
                            <label>Nombre:</label>
                            <asp:TextBox ID="txtNombreServ" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Descripcion:</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Precio</label>
                            <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-between align-items-center mb-4">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-lg" />
                    <div class="ml-auto">
                        <a href="ABMOrden.aspx" class="btn btn-outline-danger">Atras</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
















</asp:Content>
