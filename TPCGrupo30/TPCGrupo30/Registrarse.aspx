<%@ Page Title="Crear cuenta" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TPCGrupo30.Registrarse" %>

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

                                <h2 class="fw-bold mb-2">Bienvenido</h2>
                                <p class="text-white-50 mb-5">Para crear una cuenta, complete el formulario</p>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Nombre</span>
                                    <div class="form-floating">
                                        <input type="text" id="txtNombre" class="form-control" placeholder="Nombre" />
                                        <label for="txtNombre">Nombre</label>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Apellido</span>
                                    <div class="form-floating">
                                        <input type="text" id="txtApellido" class="form-control" placeholder="Apellido" />
                                        <label for="txtApellido">Apellido</label>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">DNI</span>
                                    <div class="form-floating">
                                        <input type="text" id="txtDni" class="form-control" placeholder="DNI" />
                                        <label for="txtDni">DNI</label>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Email</span>
                                    <div class="form-floating">
                                        <input type="email" id="txtEmail" class="form-control" placeholder="Email" />
                                        <label for="txtEmail">Email</label>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Dirección</span>
                                    <div class="form-floating">
                                        <input type="text" id="txtDireccion" class="form-control" placeholder="Dirección" />
                                        <label for="txtDireccion">Dirección</label>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Telefono</span>
                                    <div class="form-floating">
                                        <input type="text" id="txtTelefono" class="form-control" placeholder="Telefono" />
                                        <label for="txtTelefono">Telefono</label>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Usuario</span>
                                    <div class="form-floating">
                                        <input type="text" id="txtUsuario" class="form-control" placeholder="Usuario" />
                                        <label for="txtUsuario">Usuario</label>
                                    </div>
                                </div>

                                <div  class="form-outline form-white mb-4">
                                    <input type="password" id="typePasswordX" class="form-control form-control-lg" />
                                    <label class="form-label" for="typePasswordX">Contraseña</label>
                                    <input type="password" id="typePasswordX" class="form-control form-control-lg" />
                                    <label class="form-label" for="typePasswordX">Repetir contraseña</label>
                                </div>

                                <a href="Principal.aspx"  class="btn btn-outline-light btn-lg px-5" >Crear cuenta</a>

                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
