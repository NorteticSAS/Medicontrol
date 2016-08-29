<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="NuevaEntidad.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web115" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
                                    
    <h3>Administración de Entidades</h3>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <hr />
        <div class="btn-group btn-group-justified" role="group" aria-label="...">
            <div class="btn-group" role="group">
                <asp:Button BackColor="#999999" PostBackUrl="~/Administracion/NuevaEntidad.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button PostBackUrl="~/Administracion/BuscarEntidad.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="true" runat="server" PostBackUrl="~/Administracion/ModificarEntidad.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
            </div>
        </div>
        <hr />
        <asp:Panel ID="Panel2" runat="server" DefaultButton="btn_registrar">
        <h3>Registro de Entidades</h3>
        <br />
        <div class="alert alert-danger">
            <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_codigo" Text="Código Entidad"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigo"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_razonsocial" Text="Razón Social"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_razonsocial"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_nit" Text="NIT"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_nit"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_reprelegal" Text="Representante Legal"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_reprelegal"></asp:TextBox>
                <br />
            </div>
        </div>


        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_direccion" Text="Dirección"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_direccion"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_telefono" Text="Teléfono"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_telefono"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_ciudad" Text="Ciudad"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_ciudad"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_estado" Text="Estado"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_estado" CssClass="form-control">
                    <asp:ListItem Text="Seleccione Un Estado" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="2"></asp:ListItem>

                </asp:DropDownList>
                <br />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="lbl_btn" Text="" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-12">
                <asp:Button runat="server" ID="btn_registrar" Text="Guardar" CssClass="btn btn-primary" OnClick="btn_registrar_Click" />
                <br />
            </div>
        </div>
                                                    </asp:Panel>

    </div>
</asp:Content>
