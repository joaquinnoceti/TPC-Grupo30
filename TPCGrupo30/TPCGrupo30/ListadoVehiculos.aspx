<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListadoVehiculos.aspx.cs" Inherits="TPCGrupo30.ListadoVehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-3">
        <div class="row mb-3">
            <div class="col-md-4">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Placeholder="Filtrar..." AutoPostBack="true" />
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlFiltrar" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Marca" Value="1" />
                    <asp:ListItem Text="Tipo Vehiculo" Value="2" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
            </div>

        </div>
        <hr />
        <asp:Label ID="Label1" runat="server" Text="Vehiculos del cliente: "></asp:Label>
        <asp:GridView ID="dgvVehiculo" CssClass="table table-dark" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvVehiculo_RowCommand" DataKeyNames="IDVehiculo">
            <Columns>
                <asp:ButtonField ButtonType="Link" Text="Detalle" CommandName="Detalle" />
                <asp:ButtonField ButtonType="Link" Text="🗑️" CommandName="Baja" />
                <asp:BoundField HeaderText="ID" DataField="IDVehiculo" />
                <asp:BoundField HeaderText="Nombre" DataField="NombreCli" />
                <asp:BoundField HeaderText="Vehiculo" DataField="Marca" />
                <asp:BoundField HeaderText="Patente" DataField="Patente" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-4">
        <div class="ml-auto">
            <a href="ABMClientes.aspx" class="btn btn-outline-danger">Atras</a>
        </div>
    </div>



</asp:Content>
