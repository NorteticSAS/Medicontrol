<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="BuscarEntidad.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web116" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>

    <h3>Administración de Entidades</h3>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <hr />
        <div class="btn-group btn-group-justified" role="group" aria-label="...">
            <div class="btn-group" role="group">
                <asp:Button PostBackUrl="~/Administracion/NuevaEntidad.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button BackColor="#999999" PostBackUrl="~/Administracion/BuscarEntidad.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="true" runat="server" PostBackUrl="~/Administracion/ModificarEntidad.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" OnClientClick="return confirm('¿Desea Eliminar esta información?');" OnClick="btn_Eliminar_Click" />
            </div>
        </div>
        <hr />

        <h3>Buscar Entidades</h3>
        <br />
        <div class="alert alert-danger">
            <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
        </div>

        <div class="form-group">
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_buscarEnt">

            <asp:Label runat="server" ID="lbl_buscar" Text="Digite el Código de la Entidad" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-3"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-2">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
                <br />
            </div>
            <asp:Button runat="server" ID="btn_buscarEnt" Text="Buscar" CssClass="btn btn-primary" OnClick="btn_buscarEnt_Click" />
                        </asp:Panel>
        </div>
        <br />

        <div class="form-group">
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" Visible="false" ID="lbl_codigo" Text="Código Entidad"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="txt_codigo" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" Visible="false" ID="lbl_razonsocial" Text="Razón Social"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="txt_razonsocial" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" Visible="false" ID="lbl_nit" Text="NIT"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="txt_nit" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" Visible="false" ID="lbl_reprelegal" Text="Representante Legal"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="txt_reprelegal" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" Visible="false" ID="lbl_direccion" Text="Dirección"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="txt_direccion" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" Visible="false" ID="lbl_telefono" Text="Teléfono"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="txt_telefono" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" Visible="false" ID="lbl_ciudad" Text="Ciudad"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="txt_ciudad" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" Visible="false" ID="lbl_estado" Text="Estado"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="txt_tempEstado" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
        </div>
        </div>

</asp:Content>
