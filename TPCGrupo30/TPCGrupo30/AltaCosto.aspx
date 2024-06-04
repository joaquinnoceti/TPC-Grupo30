<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCosto.aspx.cs" Inherits="TPCGrupo30.AltaGasto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container register-form">
        <div class="form">
            <div class="form-content">
                <div class="row">
                    <div class="col-md-6 mt-3">
                        <div class="form-group mb-3">
                            <label>Fecha Emision:</label>
                            <asp:TextBox ID="txtFechaEmision" CssClass="form-control" placeholder="Fecha de emision..." runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Cuenta:</label>
                            <asp:DropDownList ID="ddlCuenta" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Cuenta ejemplo 1"></asp:ListItem>
                                <asp:ListItem Text="Cuenta ejemplo 2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mb-3">
                            <label>Tipo:</label>
                            <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Tipo ejemplo 1"></asp:ListItem>
                                <asp:ListItem Text="Tipo ejemplo 2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mb-3">
                            <label>Asignacion:</label>
                            <asp:DropDownList ID="ddlAsignacion" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Asignacion ejemplo 1"></asp:ListItem>
                                <asp:ListItem Text="Asignacion ejemplo 2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mb-3">
                            <label>Importe</label>
                            <asp:TextBox ID="txtImporte" CssClass="form-control" placeholder="Importe neto sin IVA.." runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-between align-items-center mb-4">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary btn-lg" />
                    <div class="ml-auto">
                        <a href="ABMCostos.aspx" class="btn btn-outline-danger">Atras</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
