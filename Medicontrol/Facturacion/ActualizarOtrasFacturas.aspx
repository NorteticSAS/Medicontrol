<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ActualizarOtrasFacturas.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web110" %>
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
    <asp:Label runat="server" ID="txt_valorNormal" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_upc2" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="ValorUPCmes1" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodContratoo" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_upc" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Esta" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TipoDoc" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Prefijo" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="NumFactura" Text="" Visible="false"></asp:Label>
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
 <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_entidad" Text="Entidad"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_entidad" AutoPostBack="true" OnSelectedIndexChanged="ddl_entidad_SelectedIndexChanged" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_contrato" Enabled="false" Text="Contrato"></asp:Label>
            <asp:DropDownList runat="server" Enabled="false" ID="ddl_contrato" OnSelectedIndexChanged="ddl_contrato_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
    </div>

 
    <br />
    <br />
    <br />
    <br />
    <div class="form-group">

        <asp:GridView runat="server" ID="gridFacCap" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridFacCap_RowDataBound" OnSelectedIndexChanged="gridFacCap_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="PrefijoFactura" HeaderText="Prefijo" />
                <asp:BoundField DataField="NumFactura" HeaderText="Factura" />
                <asp:BoundField DataField="CodIPS" HeaderText="IPS" />
                <asp:BoundField DataField="FechaExpedicion" HeaderText="FechaExp" />
                <asp:BoundField DataField="FechaInicial" HeaderText="Fecha Ini" />
                <asp:BoundField DataField="FechaFinal" HeaderText="Fecha Fin" />
                <asp:BoundField DataField="Valor" HeaderText="Valor" />
                <asp:BoundField DataField="Detalle" HeaderText="Detalle" />
                <asp:BoundField DataField="Municipio" HeaderText="Municipio" />

            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
        <script type="text/javascript">
            $(function () {
                $("[id*=gridFacCap] td").hover(function () {
                    $("td", $(this).closest("tr")).addClass("hover_row");
                }, function () {
                    $("td", $(this).closest("tr")).removeClass("hover_row");
                });
            });
        </script>
        <br />
    </div>
   <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>
</asp:Content>
