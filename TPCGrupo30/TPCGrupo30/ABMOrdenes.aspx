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
                    <asp:ListItem Text="Opción 1" Value="1" />
                    <asp:ListItem Text="Opción 2" Value="2" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
            </div>
        </div>
        <asp:GridView ID="dgvOrdenes" CssClass="table table-dark" runat="server">
            <Columns>
                <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Acción" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-4">
        <a href="AltaOrden.aspx" class="btn btn-primary mr-2">Nueva Orden</a>
        <div class="ml-auto">
            <a href="Principal.aspx" class="btn btn-outline-danger">Atras</a>
        </div>
    </div>


</asp:Content>
