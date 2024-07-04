<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCosto.aspx.cs" Inherits="TPCGrupo30.AltaGasto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container register-form">
        <div class="form">
            <div class="form-content">
                <div class="row">
                    <div class="col-md-6 mt-3">
                        <div class="form-group mb-3">
                            <label>Fecha Emision:</label>
                            <asp:TextBox ID="txtFechaEmision" CssClass="form-control" placeholder="Fecha de emision..." runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="form-group mb-3">
                                    <label>Cuenta:</label>
                                    <asp:DropDownList ID="ddlCuenta" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCuenta_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group mb-3">
                                    <label>SubCuenta:</label>
                                    <asp:DropDownList ID="ddlSubCuenta" CssClass="form-select" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group mb-3">
                            <label>Tipo:</label>
                            <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" placeholder="Fijo o Variable"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Asignacion:</label>
                            <asp:TextBox ID="txtAsignacion" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label>Importe</label>
                            <asp:TextBox ID="txtImporte" CssClass="form-control" placeholder="Importe neto sin IVA.." runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="d-flex justify-content-between align-items-center mb-4">
                    <a href="ABMCostos.aspx" class="btn btn-outline-danger">Atras</a>
                    <div class="ml-auto">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-lg" />
                        
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
