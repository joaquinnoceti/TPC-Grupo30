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
        <asp:GridView ID="dgvVehiculo" CssClass="table table-dark" runat="server" AutoGenerateColumns="false" DataKeyNames="IDVehiculo">
            <Columns>
                <asp:ButtonField ButtonType="Link" Text="Detalle" CommandName="Detalle" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.NombreMarca" />
                <asp:BoundField HeaderText="Modelo" DataField="Modelo.NombreModelo" />
                <asp:BoundField HeaderText="Anio" DataField="Anio" />
                <asp:BoundField HeaderText="Patente" DataField="Patente" />
                <asp:BoundField HeaderText="TipoVehiculo" DataField="TipoVehiculo" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-4">
        <div class="ml-auto">
            <a href="ABMClientes.aspx" class="btn btn-outline-danger">Atras</a>
        </div>
    </div>



</asp:Content>
