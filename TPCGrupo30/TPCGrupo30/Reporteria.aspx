<%@ Page Title="Reporte Mensual" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Reporteria.aspx.cs" Inherits="TPCGrupo30.Reporteria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvCostos" CssClass="table table-dark table-bordered table-striped" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" PageSize="15">
        <Columns>
            <asp:BoundField DataField="CodigoCuenta.DescripcionCuenta" HeaderText="Cuenta" />
            <asp:BoundField DataField="CodigoSubCuenta.DescripcionSubCuenta" HeaderText="SubCuenta" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="Comentarios" HeaderText="Asignación" />
            <asp:BoundField DataField="FechaCosto" HeaderText="Fecha" />
            <asp:BoundField DataField="Importe" HeaderText="Importe" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="dgvOrdenes" CssClass="table table-dark table-bordered table-striped" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" PageSize="15">
        <Columns>
            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Creación" />
            <asp:BoundField DataField="Cliente.Apellido" HeaderText="Cliente" />
            <asp:BoundField DataField="Vehiculo.NombreVehiculo" HeaderText="Vehículo" />
            <asp:BoundField DataField="FechaFinalizacion" HeaderText="Fecha Fin" />
            <asp:BoundField DataField="Total" HeaderText="Importe" />
            <asp:BoundField DataField="Mecanico.Apellido" HeaderText="Mecanico" />
        </Columns>
    </asp:GridView>
</asp:Content>
