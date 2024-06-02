<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="TPCGrupo30.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container1">



        <div class="left-section">
            <div class="links">
                <a href="AltaCliente.aspx">ADMINISTRACION CLIENTES</a>
                <a href="AltaOrden.aspx">ADMINISTRACION EMPLEADOS</a>
                <a href="#">ADMINISTRACION ORDENES</a>
            </div>
        </div>
        <div class="right-section">
            <div class="links">
                <a href="AltaCliente.aspx">ADMINISTRACION GASTOS</a>
                <a href="AltaOrden.aspx">REPORTERIA</a>
                <a href="#">ADMINISTRACION USUARIOS</a>
            </div>
        </div>
    </div>
</asp:Content>
