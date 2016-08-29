<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="CuentasporCobrar.aspx.cs" Inherits="Medicontrol.Facturacion.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Panel runat="server" ID="PanelBusqueda" DefaultButton="btn_buscar">
                <asp:Label runat="server" ID="CodigoSesion" Visible="false" ></asp:Label>
                <asp:Label runat="server" ID="lbl_entidad" Text="Numero de Factura"></asp:Label>
                <asp:TextBox runat="server" ID="txt_numFactura" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" ID="btn_buscar" CssClass="btn btn-link" Text=" " OnClick="btn_buscar_Click" />
                <br />
            </asp:Panel>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Panel runat="server" ID="Panel1" DefaultButton="btn_buscarDocumento">

                <asp:Label runat="server" ID="lbl_contrato" Enabled="false" Text="Documento de identidad"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Documento" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" ID="btn_buscarDocumento" CssClass="btn btn-link" Text=" " OnClick="btn_buscarDocumento_Click" />
                <br />
            </asp:Panel>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label1" Enabled="false" Text="Nombres"></asp:Label>
            <asp:TextBox runat="server" ID="txt_nombre" CssClass="form-control"></asp:TextBox>
            <br />
            <br />
        </div>

    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="Label2" Enabled="false" Text="Telefono"></asp:Label>
            <asp:TextBox runat="server" ID="txt_telefono" ReadOnly="true" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-9">
            <asp:Label runat="server" ID="Label3" Enabled="false" Text="Direccion de Residencia"></asp:Label>
            <asp:TextBox runat="server" ID="txt_direccion" ReadOnly="true" CssClass="form-control"></asp:TextBox><br />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="Label4" Text="Fecha"></asp:Label>
            <asp:TextBox runat="server" ID="txt_fecha" CssClass="form-control birthday"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="Label5" Enabled="false" Text="Valor de la Factura"></asp:Label>
            <asp:TextBox runat="server" ID="txt_valor" CssClass="form-control"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label6" Enabled="false" Text="Detalle"></asp:Label>
            <asp:TextBox runat="server" ID="txt_detalle" CssClass="form-control"></asp:TextBox>
            <br />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <asp:Button runat="server" ID="btn_guardar" Text="Guardar" CssClass="btn btn-primary" OnClick="btn_guardar_Click" />
        </div>
    </div>

    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>
</asp:Content>
