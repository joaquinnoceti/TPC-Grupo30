﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaServicio.aspx.cs" Inherits="TPCGrupo30.AltaServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Alta de Servicios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container register-form">
        <div class="form">
            <div class="form-content">
                <div class="row">
                    <div class="col-md-6 mt-3">
                        <div class="form-group mb-3">
                            <asp:Label ID="lblServicios" runat="server" Text="Servicios"></asp:Label>
                            <asp:DropDownList ID="ddlServicios" runat="server"></asp:DropDownList>
                            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary btn-lg" Text="Agregar" OnClick="btnAgregar_Click" />
                        </div>
                    </div>
                    <div class="ml-auto">
                    </div>
                    <asp:GridView ID="gdvServiciosAgregados" CssClass="table" runat="server">
                    </asp:GridView>
                   
                    <div class="ml-auto">
                        <asp:Button ID="btnAgregarOT" runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnAgregarOT_Click" Text="Agregar a la Orden de Trabajo" />
                    </div>
                    <div class="ml-auto">
                        <a href="ABMOrdenes.aspx" class="btn btn-outline-danger">Atras</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>