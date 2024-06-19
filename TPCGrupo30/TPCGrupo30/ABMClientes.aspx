<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ABMClientes.aspx.cs" Inherits="TPCGrupo30.ABMClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-3">
        <div class="row mb-3">
            <div class="col-md-4">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Placeholder="Filtrar..." AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" />
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="ddlFiltrar" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Nombre" Value="1" />
                    <asp:ListItem Text="Apellido" Value="2" />
                    <asp:ListItem Text="Inactivos" Value="3" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
            </div>

        </div>
        <hr />
        <asp:GridView ID="dgvClientes" CssClass="table table-dark" runat="server" OnRowCommand="dgvClientes_RowCommand" DataKeyNames="ID">
            <Columns>
                <asp:ButtonField ButtonType="Link" Text="✍️" CommandName="ModifCliente" />
                <asp:ButtonField ButtonType="Link" Text="❌" CommandName="BajaCliente" />
                <asp:ButtonField ButtonType="Link" Text="🚗" CommandName="AsignarVehiculo" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-4">
        <a href="AltaCliente.aspx" class="btn btn-primary mr-2">Nuevo Cliente</a>
        <div class="ml-auto">
            <a href="Principal.aspx" class="btn btn-outline-danger">Atras</a>
        </div>
    </div>

</asp:Content>
