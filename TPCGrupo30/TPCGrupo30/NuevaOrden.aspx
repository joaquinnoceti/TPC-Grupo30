<%@ Page Title="Nueva OT" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="NuevaOrden.aspx.cs" Inherits="TPCGrupo30.NuevaOrden" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-50">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                    <div class="card bg-dark text-white" style="border-radius: 1rem;">
                        <div class="card-body p-5 text-center">

                            <div class="mb-md-5 mt-md-4 pb-5">

                                <h2 class="fw-bold mb-2">Nueva orden de trabajo</h2>
                                <p class="text-white-50 mb-5">Detalle a completar:</p>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Cliente</span>
                                    <div class="form-floating">
                                        <input type="text" id="txtCliente" class="form-control" placeholder="Cliente" />
                                        <label for="txtCliente">Cliente</label>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Vehículo</span>
                                    <div class="form-floating">
                                        <input type="text" id="txtVehiculo" class="form-control" placeholder="Vehículo" />
                                        <label for="txtVehiculo">Vehículo</label>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Fecha de finalización</span>
                                    <div class="form-floating">
                                        <input type="text" id="txtFechaFin" class="form-control" placeholder="Fecha fin" />
                                        <label for="txtFechaFin">Fecha fin</label>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Observaciones</span>
                                    <div class="form-floating">
                                        <textarea id="txtObservaciones" class="form-control" rows="4"></textarea>
                                        <label for="txtObservaciones">Observaciones</label>
                                    </div>
                                </div>
                                
                                <a href="#"  class="btn btn-outline-light btn-lg px-5" >Crear orden</a>

                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
