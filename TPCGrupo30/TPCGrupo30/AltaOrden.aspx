<%@ Page Title="Nueva OT" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaOrden.aspx.cs" Inherits="TPCGrupo30.NuevaOrden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="form-group">
        <div class="row">
            <div class="col-6">
                <div class="mb-3 row">
                    <label for="txtFecha" class="col-sm-2 col-form-label">Fecha de Emision</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtFechaCreacion" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtCliente" class="col-sm-2 col-form-label">Cliente</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="ddlVehiculo" class="col-sm-2 col-form-label">Vehiculo</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlVehiculo" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="lbxServicios" class="col-sm-2 col-form-label">Servicios</label>
                    <div class="col-sm-10">
                        <asp:ListBox ID="lbxServicios" runat="server"></asp:ListBox>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtHorasTeoricas" class="col-sm-2 col-form-label">Horas Teoricas</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtHorasTeoricas" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtHorasReales" class="col-sm-2 col-form-label">Horas Reales</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtHorasReales" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtFechaFin" class="col-sm-2 col-form-label">Fecha Finalizacion</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtFechaFin" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtObservaciones" class="col-sm-2 col-form-label">Observaciones</label>
                    <div class="col-sm-10">
                        <textarea id="txtaObservaciones" cols="20" rows="2"></textarea>
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtTotal" class="col-sm-2 col-form-label">Total</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtTotal" CssClass="form-control" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtCobrado" class="col-sm-2 col-form-label">Cobrado</label>
                    <div class="col-sm-10">
                        <asp:RadioButton ID="rbCobrado" runat="server" />
                    </div>
                </div>
                <div class="mb-3 row">
                    <label for="txtMecanico" class="col-sm-2 col-form-label">Mecanico</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtMecanico" CssClass="form-control" />
                    </div>
                </div>
                 <div class="mb-3 row">
                    <label for="ddlEstado" class="col-sm-2 col-form-label">Estado</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                </div>
                <div class="col">
                    <asp:Button ID="Button2" runat="server" Text="Button" />
                </div>
                <div class="col">
                    <asp:Button ID="Button3" runat="server" Text="Button" />
                </div>
            </div>
            <a href="Principal.aspx">VOLVER</a>
        </div>
    </div>

</asp:Content>
