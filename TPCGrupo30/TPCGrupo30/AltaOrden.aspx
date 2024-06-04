<%@ Page Title="Nueva OT" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaOrden.aspx.cs" Inherits="TPCGrupo30.NuevaOrden" %>

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
                            <label>Cliente:</label>
                            <asp:DropDownList ID="ddlCliente" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Cliente ejemplo 1"></asp:ListItem>
                                <asp:ListItem Text="Cliente ejemplo 2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mb-3">
                            <label>Horas Reales</label>
                            <asp:TextBox ID="txtReales" CssClass="form-control" placeholder="Horas reales..." runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Servicios</label>
                            <asp:ListBox ID="ListBox1" runat="server">
                                <asp:ListItem Text="Ejemplo 1"></asp:ListItem>
                                <asp:ListItem Text="Ejemplo 2"></asp:ListItem>

                            </asp:ListBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Horas Teoricas</label>
                            <asp:TextBox ID="txtTeoricas" CssClass="form-control" placeholder="Horas teoricas..." runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Observaciones</label>
                            <asp:TextBox ID="TextBox1" TextMode="MultiLine" CssClass="form-control" placeholder="Observaciones..." runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6 mt-3">
                        <div class="form-group mb-3">
                            <label>Fecha Fin</label>
                            <asp:TextBox ID="txtFechaFin" CssClass="form-control" placeholder="Fecha Fin..." runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Vehiculo</label>
                            <asp:DropDownList ID="ddlVehiculo" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Vehiculo ejemplo 1"></asp:ListItem>
                                <asp:ListItem Text="Vehiculo ejemplo 2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mb-3">
                            <label>Total</label>
                            <asp:TextBox ID="txtTotal" CssClass="form-control" placeholder="Total..." runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Mecanico</label>
                            <asp:DropDownList ID="ddlMecanico" CssClass="form-select" placeholder="Mecanico..." runat="server">
                                <asp:ListItem Text="Mecanico Ejemplo 1"></asp:ListItem>
                                <asp:ListItem Text="Mecanico Ejemplo 2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mb-3">
                            <label>Estado</label>
                            <asp:DropDownList ID="ddlEstado" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Estado Ejemplo 1"></asp:ListItem>
                                <asp:ListItem Text="Estado Ejemplo 2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group mb-3">
                            <label>Cobrado: </label>
                            <div class="btn-group" role="group" aria-label="Basic radio toggle button group">
                                <input type="radio" class="btn-check" name="btnradio" id="btnradio1" autocomplete="off" checked>
                                <label class="btn btn-outline-primary" for="btnradio1">Si</label>

                                <input type="radio" class="btn-check" name="btnradio" id="btnradio2" autocomplete="off">
                                <label class="btn btn-outline-danger" for="btnradio2">No</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-between align-items-center mb-4">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary btn-lg" />
                    <div class="ml-auto">
                        <a href="ABMOrdenes.aspx" class="btn btn-outline-danger">Atras</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
