<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="NuevoTarifario.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web112" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>

    <h3>Administración de Tarifarios</h3>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12"></div>
    <hr />
    <div class="btn-group btn-group-justified" role="group" aria-label="...">
        <div class="btn-group" role="group">
            <asp:Button BackColor="#999999" PostBackUrl="~/Administracion/NuevoTarifario.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button PostBackUrl="~/Administracion/BuscarTarifarios.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button Enabled="true" runat="server" PostBackUrl="~/Administracion/ModificarTarifario.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
        </div>
    </div>
    <hr />
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="btn_registrar">

    <h3>Registro de Tarifario</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_codigo" Text="Código Tarifario"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigo"></asp:TextBox>
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
            <asp:Button runat="server" ID="btn_registrar" Text="Guardar" CssClass="btn btn-primary" OnClick="btn_registrar_Click"/>
            <br />
        </div>
    </div>
                        </asp:Panel>
</asp:Content>
