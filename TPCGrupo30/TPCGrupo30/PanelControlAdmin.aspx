<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PanelControlAdmin.aspx.cs" Inherits="TPCGrupo30.PanelControlAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>PANEL DE CONTROL</title>
        <title>Órdenes de Trabajo</title>
    <style>
        .container {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #000;
        }
        .filters {
            margin-bottom: 20px;
        }
        .filters input {
            margin-right: 10px;
        }
        .filters button {
            margin-right: 10px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container">
        <h1>PANEL DE CONTROL</h1>
        <hr />
        <h2>ORDENES DE TRABAJO</h2>
        <div class="filters">

            <asp:Label ID="lblNumeroOrden" runat="server" Text="Número de Orden:"></asp:Label>
            <asp:TextBox ID="txtNroOrden" runat="server" OnTextChanged="txtNroOrden_TextChanged" ></asp:TextBox>

            <asp:Label ID="lblNombreVehiculo" runat="server" Text="Nombre Vehículo:"></asp:Label>
            <asp:TextBox ID="txtNombreVehiculo" runat="server"></asp:TextBox>

            <asp:Label ID="lblMecanico" runat="server" Text="Mecánico:"></asp:Label>
            <asp:TextBox ID="txtMecanico" runat="server"></asp:TextBox>

            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
        </div>

        <asp:GridView ID="dgvOrdenes" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="GridViewOrdenes_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Número de Orden" ReadOnly="True" />
                <asp:TemplateField HeaderText="Vencimiento (días)">
                    <ItemTemplate>
                        <%# CalcularVencimiento(Eval("FechaCreacion"), Eval("HorasTeoricas")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Horas dedicadas por día">
                    <ItemTemplate>
                        <asp:TextBox ID="txtHorasDiarias" runat="server" Text="8" Width="30px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Estado.NombreEstado" HeaderText="Estado" />
                <asp:BoundField DataField="CreadoPor" HeaderText="Creado Por" />
                <asp:BoundField DataField="Vehiculo.Patente" HeaderText="Nombre Vehículo" />
                <asp:BoundField DataField="Cliente.Apellido" HeaderText="Cliente" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnHistorial" runat="server" Text="Ver Historial" CommandName="VerHistorial" CommandArgument='<%# Eval("ID") %>' />
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnAgregar" runat="server" Text="Nueva Orden" OnClick="btnAgregar_Click" />
    </div>




</asp:Content>
