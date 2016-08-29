<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CuentaCobro.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web111" %>

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
   
   <%-- <fieldset>
        <legend></legend>--%>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
             <div style="height: 300px; border-radius: 5px; overflow-y: scroll" class="panel-body">
            <asp:GridView runat="server" ID="gridPacienteFactura" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridPacienteFactura_RowDataBound" OnSelectedIndexChanged="gridPacienteFactura_SelectedIndexChanged">
                <Columns>

                    <asp:BoundField DataField="NumFactura" HeaderText="Num Factura" />
                    <asp:BoundField DataField="FacturaDoc" HeaderText="Documento Paciente" />

                </Columns>
            </asp:GridView>
            <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
            <script type="text/javascript">
                $(function () {
                    $("[id*=gridPacienteFactura] td").hover(function () {
                        $("td", $(this).closest("tr")).addClass("hover_row");
                    }, function () {
                        $("td", $(this).closest("tr")).removeClass("hover_row");
                    });
                });
            </script>
                 </div>
        </div>
    </div>
<%--</fieldset>--%>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <br />
            <asp:Button runat="server" ID="btn_guardar" OnClick="btn_guardar_Click" Text="Guardar" CssClass="btn btn-primary" />
            <asp:Label runat="server" ID="NumCuentaCobro" Visible="false"></asp:Label>
            <br />
        </div>
    </div>

     <script type="text/javascript">
        function ShowPopupCuentaCobro() {
            $("#btn_ccobro").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_ccobro" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#modalcuentaCobro">
        Launch demo modal
    </button>

    <div class="modal fade" id="modalcuentaCobro" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Admisiones</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="mensajeCuenta" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btn_generarSi" Text="Si" runat="server" type="button" class="btn btn-primary" OnClick="btn_generarSi_Click"></asp:Button>
                    <asp:Button ID="btn_generarNo" Text="No" runat="server" type="button" class="btn btn-default" data-dismiss="modal" aria-label="Close"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.ADVERTENCIA URGENCIAS -->


    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>
</asp:Content>
