<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AnalisisMensual.aspx.cs" Inherits="TPCGrupo30.AnalisisMensual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="vh-100 gradient-custom">
        <div class="container py-2 h-100">
            <div class="row justify-content-center h-100">
                <div class="col-12 col-lg-9 col-xl-7">
                    <div class="card shadow-2-strong card-registration" style="border-radius: 15px;">
                        <div class="card-body p-4 p-md-5">
                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="XX-Large" Text="Costo"></asp:Label>

                            <div class="container">
                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtNombre">Cant Empleados planta:</label>
                                            <asp:TextBox ID="txtCantEmpleados" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtApellido">Horas Teóricas por mes por Empleado:</label>
                                            <asp:TextBox ID="txtHorasTeoricasMesEmpleado" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group">
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtHorasTeoricasTot">Horas Teoricas Totales:</label>
                                            <asp:TextBox ID="txtHorasTeoricasTot" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtHorasRealesTot">Horas Reales Totales:</label>
                                            <asp:TextBox ID="txtHorasRealesTot" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtPorcentajeTeoricas"></label>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text="90%"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtIneficiencia">Ineficiencia de planta:</label>
                                            <asp:TextBox ID="txtIneficiencia" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtPorcentajeIneficiencia"></label>
                                            <asp:TextBox ID="txtPorcentajeIneficiencia" runat="server" CssClass="form-control" Text="10%"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtHorasTeoricasTot">Total costo del taller estimado:</label>
                                            <asp:TextBox ID="txtTotalEstimado" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtHorasTeoricasTot">Total costo hora de taller:</label>
                                            <asp:TextBox ID="txtCostoTotal" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <%-- ---------------------------------------------------------------------------------------------------- --%>
                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Font-Size="XX-Large" Text="Venta"></asp:Label>
                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtNombre">Valor hora de taller a cobrar</label>
                                            <asp:TextBox ID="txtValorHoraACobrar" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre">Margen Bruto</label>
                                            <asp:TextBox ID="txtMargenBruto" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <hr />
                                <%-- ----------------------------------------------------------------------------------------------------- --%>
                                <asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="XX-Large" Text="Objetivo"></asp:Label>
                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtFacturacionObjetivoUEN1">Facturacion Objetivo UEN1</label>
                                            <asp:TextBox ID="txtFacturacionObjetivoUEN1" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtUtilidadObjetivo">Utilidad Objetivo </label>
                                            <asp:TextBox ID="txtUtilidadObjetivo" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtFacturacionRealUEN1">Facturacion Real UEN1</label>
                                            <asp:TextBox ID="txtFacturacionRealUEN1" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre">Real vs Objetivo </label>
                                            <asp:TextBox ID="txtRealXObjetivo" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtNombre">Otros Costos Variables </label>
                                            <asp:TextBox ID="txtOCV" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="txtPorcentajeOCV" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtNombre">Subtotal 1 </label>
                                            <asp:TextBox ID="txtSubtotal1" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="txtPorcentajeSubtotal1" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre">Total costo taller est. </label>
                                            <asp:TextBox ID="txtTotalCostoTallerEstimado" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre">Desvio costo taller </label>
                                            <asp:TextBox ID="txtDesvioCostoTaller" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtNombre">Subtotal 2 </label>
                                            <asp:TextBox ID="txtSubtotal2" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="txtPorcentajeSubtotal2" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtNombre">Imp. Ganancias </label>
                                            <asp:TextBox ID="txtImpuestoGanancias" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-8">
                                        <div class="form-group">
                                            <label for="txtNombre">Rentabilidad Neta</label>
                                            <asp:TextBox ID="txtRentabilidadNeta" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <hr />
                                <%-- ----------------------------------------------------------------------------------------------------- --%>
                                <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="XX-Large" Text="P.Equilibrio"></asp:Label>
                                <div class="row">
                                    <div class="col-md-5">
                                        <div class="form-group">
                                            <label for="txtNombre">P. Equilibrio Teorico</label>
                                            <asp:TextBox ID="txtPuntoEquilibrio" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-5">
                                        <div class="form-group">
                                            <label for="txtNombre">P. Equilibrio Real</label>
                                            <asp:TextBox ID="txtPuntoEquilibrioReal" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control" Text="%"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label for="txtNombre"></label>
                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control" Text="$"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>



                            </div>


                        </div>
                    </div>
                </div>
            </div>
    </section>

</asp:Content>
