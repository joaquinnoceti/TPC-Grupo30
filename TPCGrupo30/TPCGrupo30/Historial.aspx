<%@ Page Title="Historial de OT" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Historial.aspx.cs" Inherits="TPCGrupo30.Historial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvHistorial" CssClass="table table-dark table-bordered table-striped" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" PageSize="15">
        <Columns>
            <asp:BoundField DataField="IDOrdenDeTrabajo" HeaderText="OT" />
            <asp:BoundField DataField="FechaModificacion" HeaderText="Fecha Obs." />
            <asp:BoundField DataField="Observacion" HeaderText="Detalle" />
            <asp:BoundField DataField="ModificadoPor.Apellido" HeaderText="Mecánico" />
        </Columns>
    </asp:GridView>
    <div class="d-flex justify-content-between align-items-center mb-4">
        <a href="Principal.aspx" class="btn btn-success">Inicio</a>
        <%--<div class="ml-auto">--%>
            <asp:Button ID="btnHistorial" CssClass="btn btn-secondary" Text="Atrás" runat="server" OnClick="btnHistorial_Click" />
        <%--</div>--%>
    </div>
</asp:Content>
