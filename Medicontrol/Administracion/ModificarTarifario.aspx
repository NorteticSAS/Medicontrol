<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="ModificarTarifario.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web114" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
        <asp:Panel ID="p" runat="server" DefaultButton="btn_buscarTari">

     <h3>Administración de Tarifarios</h3>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12"></div>
        <hr />
        <div class="btn-group btn-group-justified" role="group" aria-label="...">
            <div class="btn-group" role="group">
                <asp:Button PostBackUrl="~/Administracion/NuevoTarifario.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button PostBackUrl="~/Administracion/BuscarTarifarios.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button BackColor="#999999" Enabled="true" runat="server" PostBackUrl="~/Administracion/ModificarTarifario.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
            </div>
        </div>

        <hr />
        <h3>Modificar Tarifario</h3>
        <br />
        <div class="alert alert-danger">
            <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="lbl_buscar" Text="Digite el Código del Tarifario" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-3"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-2">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
                <br />
            </div>
            <asp:Button runat="server" ID="btn_buscarTari" Text="Buscar" CssClass="btn btn-primary" OnClick="btn_buscarTari_Click" />
        </div>
        <br />

        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_codigo" Text="Código Tarifario"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigo" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_descripciontarifario" Text="Descripción Tarifario"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_descripciontarifario"></asp:TextBox>
                <br />
            </div>
        </div>

    <div class="form-group">
            <asp:Label runat="server" ID="lbl_btn" Text="" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-12">
                <asp:Button runat="server" ID="btn_registrar" Text="Guardar" CssClass="btn btn-primary" OnClick="btn_registrar_Click" Visible="false"/>
                <br />
            </div>
        </div>
            </asp:Panel>
</asp:Content>
