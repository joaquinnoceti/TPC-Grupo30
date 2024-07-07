<%@ Page Title="Nueva OT" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaOrden.aspx.cs" Inherits="TPCGrupo30.AltaOrden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Label ID="lblError" runat="server" CssClass="btn-outline-danger" Text=""></asp:Label>

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
                                <%if (Request.QueryString["ID"] != null)
                                    {%>
                                <div class="form-group mb-3">
                                    <label>Cliente</label>
                                    <asp:TextBox ID="txtCliente" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group mb-3">
                                    <label>Vehiculo</label>
                                    <asp:TextBox ID="txtVehiculo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <%}
                                    else
                                    {%>
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
                                <%}%>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group mb-3">
                            <label>Horas Reales</label>
                            <asp:TextBox ID="txtReales" CssClass="form-control" placeholder="Horas reales..." runat="server"></asp:TextBox>
                        </div>
                        <%if (Request.QueryString["ID"] != null)
                            {%>
                            <div class="form-group mb-3">
                                <asp:Label ID="lblModifServicios" runat="server" Text="Label">Servicios</asp:Label>
                                <asp:Button ID="btnModificarServicios" runat="server" Text="Modificar Servicios" OnClick="btnModificarServicios_Click" CssClass="btn btn-primary btn-lg" />
                            </div>
                        <div class="form-group mb-3">
                            <asp:Label ID="lblServ" runat="server" Text="Label">Servicios</asp:Label>
                            <asp:GridView ID="gdvServiciosAgregados2" CssClass="table" runat="server"></asp:GridView>
                        </div>
                        <%}
                            else
                            {%>
                        <div class="form-group mb-3">
                            <asp:Label ID="lblServicios" runat="server" Text="Label">Servicios</asp:Label>
                            <asp:GridView ID="gdvServiciosAgregados1" CssClass="table" runat="server">
                            </asp:GridView>
                        </div>
                        <%}%>
                        <div class="form-group mb-3">
                            <label>Horas Teoricas</label>
                            <asp:TextBox ID="txtTeoricas" CssClass="form-control" placeholder="Horas teoricas..." runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Observaciones</label>
                            <asp:TextBox ID="tbObservaciones" TextMode="MultiLine" CssClass="form-control" placeholder="Observaciones..." runat="server"></asp:TextBox>
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
                            </asp:DropDownList>
                        </div>
                        <%--<div class="form-group mb-3">
                            <label>Estado</label>
                            <asp:DropDownList ID="ddlEstado" CssClass="form-select" runat="server">
                            </asp:DropDownList>
                        </div>--%>
                        <%if (Request.QueryString["ID"] != null)
                            {%>
                            <div class="form-group mb-3">
                                <label class="h4">Estado:</label>
                                <asp:TextBox ID="txtEstado" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                <asp:Label Text="Avanzar Estado" ID="lblAvanzar" runat="server" />
                                <%if(txtEstado.Text != "COMPLETADO") { %>
                                <asp:Button ID="btnAvanzarEstado" CssClass="btn btn-outline-success btn-sm" Text="Avanzar" OnClick="btnAvanzarEstado_Click" runat="server" />
                                <%}%>
                            </div>
                        <%}%>

                        <div class="form-group mb-3">
                            <label>Cobrado: </label>
                            <div class="btn-group" role="group" aria-label="Basic radio toggle button group">
                                <asp:RadioButton CssClass="btn btn-outline-primary" ID="rdbSi" Text="SI" runat="server" GroupName="Cobrado" />
                                <asp:RadioButton CssClass="btn btn-outline-danger" ID="rdbNo" Text="NO" runat="server" GroupName="Cobrado" Checked="true" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="d-flex justify-content-between align-items-center mb-4">
                <%if (Request.QueryString["ID"] != null)
                    {%>
                <div class="d-flex justify-content-between align-items-center mb-4">
                    <asp:Button ID="btnModificar" CssClass="btn btn-primary btn-lg" Text="Modificar" OnClick="btnModificar_Click" runat="server" />
                </div>
                <%}
                    else
                    {%>
                <div class="d-flex justify-content-between align-items-center mb-4">
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" CssClass="btn btn-primary btn-lg" />
                </div>

                <%}%>
                <div class="ml-auto">
                    <a href="ABMOrdenes.aspx" class="btn btn-outline-danger">Atras</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
