<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaServicio.aspx.cs" Inherits="TPCGrupo30.AltaServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Seleccione los servicios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container register-form">
        <div class="form">
            <div class="form-content">
                <div class="row">
                    <div class="col-md-6 mt-3">
                        <div class="form-group mb-3">
                            <asp:Label ID="lblServicios" runat="server" Text="Servicios"></asp:Label>
                            <asp:DropDownList ID="ddlServicios" runat="server"></asp:DropDownList>
                            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary btn-lg" Text="Agregar" OnClick="btnAgregar_Click" />
                        </div>
                    </div>
                    <div class="ml-auto">
                    </div>
                    <asp:GridView ID="gdvServiciosAgregados" CssClass="table" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvServiciosAgregados_RowCommand">

                        <Columns>
                            <asp:BoundField DataField="NombreServicio" HeaderText="Nombre del Servicio" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:N2}" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnRemove" runat="server" Text="Quitar" CommandName="RemoveService" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-danger" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="ml-auto"></div>
                    <div class="col-md-12 d-flex justify-content-between">
                        <asp:Button ID="btnAgregarOT" runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnAgregarOT_Click" Text="Crear Orden de Trabajo" />
                        <a href="ABMOrdenes.aspx" class="btn btn-outline-danger btn-lg">Atras</a>
                        <a href="NuevoServicio.aspx" class="btn btn-outline-danger btn-lg">Nuevo Servicio</a>
                    </div>
                </div>
             </div>
        </div>
    </div>
    <br />

</asp:Content>
