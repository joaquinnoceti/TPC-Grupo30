<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ABMServicios.aspx.cs" Inherits="TPCGrupo30.ABMServicios" %>
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
        <asp:GridView ID="dgvServicios" CssClass="table table-dark table-bordered table-striped" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnRowCommand="dgvServicios_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Link" Text="✍️" CommandName="ModifServicio" />
                <asp:ButtonField ButtonType="Link" Text="❌" CommandName="BajaServicio" />
                <asp:BoundField DataField="NombreServicio" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:N2}" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-4">
        <a href="NuevoServicio.aspx" class="btn btn-primary mr-2">Nuevo Servicio</a>
        <div class="ml-auto">
            <a href="Principal.aspx" class="btn btn-outline-danger">Atras</a>
        </div>
    </div>
    <br />
</asp:Content>
