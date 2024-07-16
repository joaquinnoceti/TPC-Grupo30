<%@ Page Title="Reporte Mensual" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Reporteria.aspx.cs" Inherits="TPCGrupo30.Reporteria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <label class="form-label" style="color: #09834E; font-weight: bold; font-size: 20px;" runat="server">Costos Mensuales</label>
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
    <asp:label ID="lblCosto" class="form-label" style="color: #09834E; font-weight: bold; font-size: 15px;" runat="server" Text=""></asp:label>
    <div></div>
    <label class="form-label" style="color: #09834E; font-weight: bold; font-size: 20px;" runat="server">Ordenes de Trabajo</label>
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
    <asp:label ID="lblOT" class="form-label" style="color: #09834E; font-weight: bold; font-size: 15px;" runat="server" Text=""></asp:label>
    <div></div>
    <asp:label ID="lblRentabilidad" class="form-label" style="color: #09834E; font-weight: bold; font-size: 20px;" runat="server" Text=""></asp:label>
</asp:Content>
