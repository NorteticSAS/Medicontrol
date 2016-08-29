<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="CuentaCobro.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web111" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        td {
            cursor: pointer;
        }

        .hover_row {
            background-color: #FFFFBF;
        }
    </style>

    <h3>Cuentas Cobro</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-5">
            <asp:Label runat="server" ID="lbl_entida" Text="Entidad"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_entidad" AutoPostBack="true" OnSelectedIndexChanged="ddl_entidad_SelectedIndexChanged" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-5">
            <asp:Label runat="server" ID="lbl_fechainc" Text="Fecha inicial"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechaini" />
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2"></div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-5">
            <asp:Label runat="server" ID="lbl_codigous" Text="Contrato"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_contrato" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-5">
            <asp:Label runat="server" ID="lbl_fechafin" Text="Fecha Final"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechafin" />
            <br />

        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
            <br />
            <asp:Button runat="server" ID="btn_cargar" Text="Cargar" CssClass="btn btn-primary" OnClick="btn_cargar_Click" /><br />
        </div>


    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <asp:Label runat="server" ID="lbl_selectodo" Text="Seleccionar Todo"></asp:Label>
            <asp:CheckBox runat="server" CssClass="form-control col-lg-4 col-md-12 col-sm-12 col-xs-12" ID="chk_selectodo" Checked="false" />
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <br />
            <asp:Button runat="server" ID="btn_guardar" Text="Guardar" CssClass="btn btn-primary" />
            <br />
        </div>
    </div>
    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>
</asp:Content>
