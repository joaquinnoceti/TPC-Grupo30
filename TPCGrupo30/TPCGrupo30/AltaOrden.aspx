<%@ Page Title="Nueva OT" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaOrden.aspx.cs" Inherits="TPCGrupo30.NuevaOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container register-form">
        <div class="form">
            <div class="form-content">
                <div class="row">
                    <div class="col-md-6 mt-3">
                        <div class="form-group mb-3">
                            <label>Fecha Emision:</label>
                            <asp:TextBox ID="txtFechaEmision" CssClass="form-control" placeholder="Fecha de emision..." runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="form-group mb-3">
                                    <label>Cliente:</label>
                                    <asp:DropDownList ID="ddlCliente" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group mb-3">
                                    <label>Vehiculo</label>
                                    <asp:DropDownList ID="ddlVehiculo" CssClass="form-select" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        <div class="form-group mb-3">
                            <label>Horas Reales</label>
                            <asp:TextBox ID="txtReales" CssClass="form-control" placeholder="Horas reales..." runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <asp:Label ID="lblServicios" runat="server" Text="Label">Servicios</asp:Label>
                            <asp:ListBox ID="lbServicios" runat="server">   
                            </asp:ListBox>
                            <asp:Button ID="btnAgregarServicio" runat="server" Text="Agregar Servicio" CssClass="btn btn-primary btn-lg" OnClick="btnAgregarServicio_Click"/>
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
                            <asp:TextBox ID="txtFechaFin" CssClass="form-control" placeholder="Fecha Fin..." runat="server" TextMode="Date"></asp:TextBox>
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
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="btn btn-primary btn-lg" />
                    <div class="ml-auto">
                        <a href="ABMOrdenes.aspx" class="btn btn-outline-danger">Atras</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
