<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ConsultarFacturas.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                    <asp:Panel ID="p" runat="server" DefaultButton="Button1">

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
    <script src="../jquery.js"></script>
    <script src="../jquery.PrintArea.js"></script>
    <asp:Label runat="server" ID="CodigoEntidad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="NombreEntidad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="NITentidad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Direccion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FechaFactura" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="EntidadNombre" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="EntidadNIT" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="NumeroFactura" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="NombreContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TipoFacturaCodigo" Visible="false"></asp:Label>


    <asp:Label runat="server" ID="PacienteNombre" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Documento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Edad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="HistoriaClinica" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Estrato" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="ValorProcedimiento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="ValorCopago" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="ValorEntidad" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="NombreUsuario" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoUsuario" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="TipoFactura" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="TotalP" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="TotalC" Visible="false"></asp:Label>


    <asp:Label runat="server" ID="txt_vrprocedimiento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_vrtotal" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="valorTotalFinalCopago" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="valorTotalFinalProced" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="ValorTotalFinalSubtotal" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="ValorModeradoraFactura" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_vrcuota" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="txt_copago" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="txt_iva" Visible="false"></asp:Label>



    <h3>Consultar Factura</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_tipo" Text="Tipo de Documento"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_tipo" CssClass="form-control" OnSelectedIndexChanged="ddl_tipo_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Factura de Venta" Value="1"></asp:ListItem>
                <asp:ListItem Text="Orden de Servicio" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_factura" Text="Factura de Venta" Visible="true"></asp:Label>
            <asp:Label runat="server" ID="lbl_orden" Text="Orden de Servicio" Visible="false"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_factura"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_docpaciente" Text="Documento Paciente"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_docpaciente"></asp:TextBox>
            <br />
        </div>
        <br />
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Button runat="server" ID="Button1" Text="Buscar" CssClass="btn btn-primary" OnClick="Button1_Click" />
                         <h4>seleccione en el listado la factura que desee imprimir.</h4>

            <br />
        </div>
    </div>
    <br />
    <div class="from-group">
        <asp:GridView runat="server" ID="GridFacturas" CssClass="table table-bordered bs-table" AutoGenerateColumns="false" OnRowDataBound="GridFacturas_RowDataBound" OnSelectedIndexChanged="GridFacturas_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="FPrefijo" HeaderText="Pref" />
                <asp:BoundField DataField="FNumero" HeaderText="Fact" />
                <asp:BoundField DataField="FTipoDoc" HeaderText="Tipo Doc" />
                <asp:BoundField DataField="FNombreEntidad" HeaderText="Entidad" />
                <asp:BoundField DataField="FContratoDesc" HeaderText="Contrato" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Paciente" />
                <asp:BoundField DataField="FFecha" HeaderText="FechaF" />
                <asp:BoundField DataField="FVrTotalProced" HeaderText="VTotal" />
                <asp:BoundField DataField="ValorCopago" HeaderText="VCopago" />
                <asp:BoundField DataField="FValorEntidad" HeaderText="VEntidad" />
                <asp:BoundField DataField="FEstado" HeaderText="Estado" />
                <asp:BoundField DataField="FUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="FFechaAnulo" HeaderText="FAnul" />
                <asp:BoundField DataField="FCobro" HeaderText="Ccobro" />
              
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
        <script type="text/javascript">
            $(function () {
                $("[id*=GridFacturas] td").hover(function () {
                    $("td", $(this).closest("tr")).addClass("hover_row");
                }, function () {
                    $("td", $(this).closest("tr")).removeClass("hover_row");
                });
            });
        </script>
    </div>
    <br />
   
    <br />
   
    <div class="content container">
        <div class="form-group">
            <div style="font-size: medium" class="row">
                <asp:Literal runat="server" ID="Cabezal"></asp:Literal>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <asp:Literal runat="server" ID="Cuerpo"></asp:Literal>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <asp:Literal runat="server" ID="Footer"></asp:Literal>
            </div>
        </div>

    </div>
   
		<script>
		    $(document).ready(function () {
		        $("#print_button1").click(function () {
		            var mode = 'iframe'; // popup
		            var close = mode == "popup";
		            var options = { mode: mode, popClose: close };
		            $("div.wrapper").printArea(options);
		        });
		        $("#print_button2").click(function () {
		            var mode = 'iframe'; // popup
		            var close = mode == "popup";
		            var options = { mode: mode, popClose: close };
		            $("div.content").printArea(options);
		        });
		    });

  </script>
</asp:Panel>
</asp:Content>
