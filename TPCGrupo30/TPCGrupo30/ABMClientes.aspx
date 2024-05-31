<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="TPCGrupo30.ABMClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvClientes" CssClass="table" runat="server">
        <Columns>
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
        </Columns>
    </asp:GridView>

</asp:Content>
