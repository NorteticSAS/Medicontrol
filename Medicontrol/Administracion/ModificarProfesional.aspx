﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="ModificarProfesional.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>

    <h3>Administración de Profesionales</h3>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <hr />
        <div class="btn-group btn-group-justified" role="group" aria-label="...">
            <div class="btn-group" role="group">
                <asp:Button PostBackUrl="~/Administracion/NuevoProfesional.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button  PostBackUrl="~/Administracion/BuscarProfesional.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button BackColor="#999999" Enabled="true" PostBackUrl="~/Administracion/ModificarProfesional.aspx" runat="server" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
            </div>
        </div>
        <hr />
        <h3>Modificar Profesionales</h3>
        <br />
        <div class="alert alert-danger">
            <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
        </div>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_buscarPro">

        <div class="form-group">
            <asp:Label runat="server" ID="lbl_buscar" Text="Digite el Código del Profesional" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-3"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-2">
                <asp:TextBox ReadOnly="false" runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
                <br />
            </div>
            <asp:Button Enabled="true" runat="server" ID="btn_buscarPro" OnClick="btn_buscarPro_Click" CssClass="btn btn-primary" Text="Buscar" />
        </div>
                    </asp:Panel>
        <br />
                                <asp:Panel ID="Panel2" runat="server" DefaultButton="btn_modificar">

        <div class="form-group">
                <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label runat="server" ID="lbl_codigo" Text="Código Profesional" ></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigo"></asp:TextBox>
                    <br />
                </div>
                <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label runat="server" ID="lbl_primernombre" Text="Primer Nombre" ></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_primernombre"></asp:TextBox>
                    <br />
                </div>

                <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label runat="server" ID="lbl_segundonombre" Text="Segundo Nombre" ></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_segundonombre"></asp:TextBox>
                    <br />
                </div>
               
            </div>
            <div class="form-group">
                 <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">

                    <asp:Label runat="server" ID="lbl_primerapellido" Text="Primer Apellido"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_primerapellido"></asp:TextBox>
                    <br />
                </div>
                <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label runat="server" ID="lbl_segundoapellido" Text="Segundo Apellido" ></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_segundoapellido"></asp:TextBox>
                    <br />
                </div>

                <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                     <asp:Label runat="server" ID="lbl_tipopersona" Text="Tipo de Persona" ></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_tipopersona" CssClass="form-control">
                        <asp:ListItem Text="Seleccione Un tipo de especialista" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Medico Especialista" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Medico General" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Enfermería" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Auxiliar de Enfermería" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Otros" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                
            </div>
            <div class="form-group">
                <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label runat="server" ID="lbl_estado" Text="Estado" ></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_estado" CssClass="form-control">
                        
                        <asp:ListItem Text="Activo" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Inactivo" Value="1"></asp:ListItem>

                    </asp:DropDownList>
                    <br />
                    </div>
              <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12"></div>
            </div>    
        <div class="form-group">
            <asp:Label Visible="false" runat="server" ID="lbl_btn" Text="" ></asp:Label>
                <asp:Button Visible="false"  runat="server" ID="btn_modificar" OnClick="btn_modificar_Click" Text="Guardar" CssClass="btn btn-primary" />
                <br />
        </div>
                            </asp:Panel>

    </div>
</asp:Content>
