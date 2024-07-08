<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ABMOrdenes.aspx.cs" Inherits="TPCGrupo30.ABMOrdenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-3">
        <div class="row mb-3">
            <div class="col-md-4">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Placeholder="Filtrar..." />
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlFiltrar" runat="server" CssClass="form-control">
                    <asp:ListItem Text="ID" Value="1" />
                    <asp:ListItem Text="Cliente" Value="2" />
                    <asp:ListItem Text="Empleado" Value="2" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
            </div>
        </div>
        <asp:GridView ID="dgvOrdenes" CssClass="table table-dark table-bordered table-striped" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnPageIndexChanging="dgvOrdenes_PageIndexChanging" OnSelectedIndexChanged="dgvOrdenes_SelectedIndexChanged" AllowPaging="true" PageSize="15">
            <Columns>
                <asp:CommandField ButtonType="Button" ControlStyle-BackColor="green" ItemStyle-Width="5%"  ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
                 <asp:BoundField DataField="ID" HeaderText="NUMERO" />
                <asp:BoundField DataField="Cliente.Apellido" HeaderText="Cliente" />
                <asp:BoundField DataField="Mecanico.Apellido" HeaderText="Mecanico" />
                <asp:BoundField DataField="Vehiculo.NombreVehiculo" HeaderText="Vehiculo" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
                <asp:BoundField DataField="Cobrado" HeaderText="Cobrado" />
                <asp:BoundField DataField="Estado.NombreEstado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-4">
        <a href="Principal.aspx" class="btn btn-outline-danger">Atras</a>
        <div class="ml-auto">
            <a href="AltaServicio.aspx" class="btn btn-primary mr-2">Nueva Orden</a>
        </div>
    </div>


</asp:Content>
