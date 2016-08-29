<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FacturaCapitadaActualizar.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web18" %>

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
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-5">
            <asp:Label runat="server" ID="lbl_eapb" Text="Entidad"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_entidad" CssClass="form-control" OnSelectedIndexChanged="ddl_entidad_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-5">
            <asp:Label runat="server" ID="lbl_contrato" Text="Contrato"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_contrato" AutoPostBack="true" OnSelectedIndexChanged="ddl_contrato_SelectedIndexChanged" CssClass="form-control" Enabled="false">
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
            <asp:Label runat="server" ID="lbl_telefono" Text="Factura No."></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_facturaNum"></asp:TextBox><br />
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
                <asp:BoundField DataField="MesServicio" HeaderText="Mes Serv" />
                <asp:BoundField DataField="YearServicio" HeaderText="Año Serv" />
                <asp:BoundField DataField="FechaInicial" HeaderText="Fecha Ini" />
                <asp:BoundField DataField="FechaFinal" HeaderText="Fecha Fin" />
                <asp:BoundField DataField="NumAfiliados" HeaderText="Num Afil" />
                <asp:BoundField DataField="PorcentajeCap" HeaderText="% Capita" />
                <asp:BoundField DataField="Valor" HeaderText="Valor" />
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
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label1" Text="Fecha Factura"></asp:Label>
            <asp:TextBox runat="server" Enabled="true" CssClass="form-control birthday" ID="txt_fechafac"></asp:TextBox><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label2" Text="Numero Contrato"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numContrato" ReadOnly="true"></asp:TextBox><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
             <asp:Panel runat="server" ID="panel" DefaultButton="btn_umafil">
            <asp:Label runat="server" ID="Label3" Text="Numero de Afiliados"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numafiliados" ReadOnly="false"></asp:TextBox><br />
                 <asp:Button Enabled="true" style="visibility:hidden" runat="server" ID="btn_umafil" Visible="true" OnClick="btn_umafil_Click" />
                 </asp:Panel>
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label4" Text="Fecha Inicial"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control birthday" Enabled="false" ID="txt_fechaIni"></asp:TextBox><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label5" Text="Fecha Final"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control birthday" Enabled="false" ID="txt_fechaFin"></asp:TextBox><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label6" Text="% Capita"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_porcapita" ReadOnly="true"></asp:TextBox><br />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label7" Text="Valor Mensual"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_valor" ReadOnly="true"></asp:TextBox><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label8" Text="Servicios"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_servicio" CssClass="form-control">
                <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                <asp:ListItem Text="I Nivel de Atención" Value="1"></asp:ListItem>
                <asp:ListItem Text="Unidad Renal" Value="2"></asp:ListItem>
            </asp:DropDownList><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label9" Text="Municipio"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_municipio"></asp:TextBox><br />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label10" Text="Mes"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_mes" CssClass="form-control">
                <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                <asp:ListItem Text="Enero" Value="ENERO"></asp:ListItem>
                <asp:ListItem Text="Febrero" Value="FEBRERO"></asp:ListItem>
                <asp:ListItem Text="Marzo" Value="MARZO"></asp:ListItem>
                <asp:ListItem Text="Abril" Value="ABRIL"></asp:ListItem>
                <asp:ListItem Text="Mayo" Value="MAYO"></asp:ListItem>
                <asp:ListItem Text="Junio" Value="JUNIO"></asp:ListItem>
                <asp:ListItem Text="Julio" Value="JULIO"></asp:ListItem>
                <asp:ListItem Text="Agosto" Value="AGOSTO"></asp:ListItem>
                <asp:ListItem Text="Septiembre" Value="SEPTIEMBRE"></asp:ListItem>
                <asp:ListItem Text="Octubre" Value="OCTUBRE"></asp:ListItem>
                <asp:ListItem Text="Noviembre" Value="NOVIEMBRE"></asp:ListItem>
                <asp:ListItem Text="Diciembre" Value="DICIEMBRE"></asp:ListItem>
            </asp:DropDownList><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label11" Text="Año"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_año" CssClass="form-control">
                <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
            </asp:DropDownList><br />

        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label12" Text="IPS"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_ips" CssClass="form-control">
            </asp:DropDownList><br />

        </div>
    </div>
    <div class="form-group">
          <asp:Button OnClick="btn_guardar_Click" runat="server" ID="btn_guardar" Text="Guardar" CssClass="btn btn-primary" />
          <asp:Button OnClick="btn_imprimir_Click" runat="server" ID="btn_imprimir" Text="Imprimir" CssClass="btn btn-primary" />
    </div>

    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>
</asp:Content>
