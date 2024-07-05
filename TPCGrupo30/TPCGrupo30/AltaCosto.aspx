<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCosto.aspx.cs" Inherits="TPCGrupo30.AltaGasto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-100">
            <div class="row justify-content-center align-items-center h-100">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">

                            <asp:Label ID="Label1" CssClass="form form-control-lg toast-header" runat="server" Text="Nuevo Costo"></asp:Label>
                            <hr />

                            <div>
                                <label>Fecha Emision:</label>
                                <asp:TextBox ID="txtFechaEmision" CssClass="form-control" placeholder="Fecha de emision..." runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <label>Cuenta:</label>
                                        <asp:DropDownList ID="ddlCuenta" CssClass="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCuenta_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div>
                                        <label>SubCuenta:</label>
                                        <asp:DropDownList ID="ddlSubCuenta" CssClass="form-select" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div>
                                <label>Tipo:</label>
                                <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control" placeholder="Fijo o Variable"></asp:TextBox>
                            </div>
                            <div>
                                <label>Asignacion:</label>
                                <asp:TextBox ID="txtAsignacion" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <label>Importe</label>
                                <asp:TextBox ID="txtImporte" CssClass="form-control" placeholder="Importe neto sin IVA.." runat="server"></asp:TextBox>
                            </div>
                            <div class="d-flex col-md-12 justify-content-between align-items-center mb6 pt-sm-2">
                                <a href="ABMCostos.aspx" class="btn btn-outline-danger">Atras</a>
                                <div class="ml-auto">
                                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-lg" />


                                </div>
                                <div>
                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
