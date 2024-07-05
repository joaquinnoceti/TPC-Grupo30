<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="TPCGrupo30.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container1">
        <div class="left-section">
            <div class="links">
                <a href="ABMClientes.aspx">ADMINISTRACION CLIENTES</a>
                <a href="ABMEmpleados.aspx">ADMINISTRACION EMPLEADOS</a>
                <a href="ABMOrdenes.aspx">ADMINISTRACION ORDENES</a>
            </div>
        </div>
        <div class="right-section">
            <div class="links">
                <a href="ABMServicios.aspx">ADMINISTRACION SERVICIOS</a>
                <a href="ABMCostos.aspx">ADMINISTRACION COSTOS</a>
                <a href="AnalisisMensual.aspx">REPORTERIA</a>
            </div>
        </div>
    </div>
</asp:Content>
