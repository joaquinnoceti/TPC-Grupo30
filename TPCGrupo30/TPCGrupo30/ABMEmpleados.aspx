<%@ Page Title="Administracion de Empleados" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ABMEmpleados.aspx.cs" Inherits="TPCGrupo30.ABMEmpleados" %>

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
                    <asp:ListItem Text="Categoria" Value="3" />
                    <asp:ListItem Text="DNI" Value="4" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:CheckBox ID="cBoxInactivos" Text="Inactivos" CssClass="form-control row-cols-xl-4" OnCheckedChanged="cBoxInactivos_CheckedChanged" AutoPostBack="true" runat="server"  />
            </div>

        </div>
        <hr />
        <asp:GridView ID="dgvEmpleados" CssClass="table table-dark" runat="server" OnRowCommand="dgvEmpleados_RowCommand" AutoGenerateColumns="false" DataKeyNames="ID">
            <Columns>
                <asp:ButtonField ButtonType="Link" Text="❌" CommandName="BajaUsuario" />
                <asp:ButtonField ButtonType="Link" Text="✍️" CommandName="ModificarUsuario" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono"/>
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex justify-content-between align-items-center mb-4">
        <a href="Principal.aspx" class="btn btn-outline-danger">Atras</a>
        <div class="ml-auto">
            <a href="AltaEmpleado.aspx" class="btn btn-primary mr-2">Nuevo Empleado</a>
        </div>
    </div>

</asp:Content>
