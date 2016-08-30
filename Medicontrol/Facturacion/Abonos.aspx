<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Abonos.aspx.cs" Inherits="Medicontrol.Facturacion.WebForm5" %>

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
    <asp:Label runat="server" ID="txt_abono" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_saldos" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoSesion" Visible="false"></asp:Label>

    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
    <div class="form-group">

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Panel runat="server" ID="panel" DefaultButton="btn_buscar">
                <asp:Label runat="server" ID="lbl_contrato" Enabled="false" Text="Documento de identidad"></asp:Label>
                <asp:TextBox runat="server" ID="txt_Documento" ReadOnly="false" Visible="true" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" ID="btn_buscar" CssClass="btn btn-link" Text=" " OnClick="btn_buscar_Click" />
                <br />
            </asp:Panel>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-8">
            <asp:Label runat="server" ID="Label1" Enabled="false" Text="Nombres"></asp:Label>
            <asp:TextBox runat="server" ID="txt_nombre" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
            <asp:Label runat="server" ID="Label4" Enabled="false" Visible="true" Text="Saldo"></asp:Label>
            <asp:TextBox runat="server" ID="txt_saldo" ReadOnly="false" Visible="true" CssClass="form-control"></asp:TextBox><br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-9">
            <asp:Label runat="server" ID="Label5" Enabled="false" Visible="false" Text="Direccion de Residencia"></asp:Label>
            <asp:TextBox runat="server" ID="TextBox2" ReadOnly="true" Visible="false" CssClass="form-control"></asp:TextBox><br />
        </div>
    </div>
    <div class="form-group">

        <asp:GridView runat="server" ID="gridAbonos" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridAbonos_RowDataBound" OnSelectedIndexChanged="gridAbonos_SelectedIndexChanged">
            <Columns>

                <asp:BoundField DataField="NumFactura" HeaderText="Factura" />
                <asp:BoundField DataField="Detalle" HeaderText="Detalle" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="ValorFactura" HeaderText="Valor Factura" />
                <asp:BoundField DataField="ValorAbonos" HeaderText="Valor Abonos" />
                <asp:BoundField DataField="ValorSaldo" HeaderText="Valor Saldo" />

            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
        <script type="text/javascript">
            $(function () {
                $("[id*=gridAbonos] td").hover(function () {
                    $("td", $(this).closest("tr")).addClass("hover_row");
                }, function () {
                    $("td", $(this).closest("tr")).removeClass("hover_row");
                });
            });
        </script>
    </div>

    <script type="text/javascript">
        function ShowPopupAbonar() {
            $("#noUsuarios").click();
        }
    </script>
    <button type="button" style="display: none;" id="noUsuarios" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalUsuarios">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalUsuarios" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Admisiones</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_mensajeUsuario" runat="server" />
                    <br />
                    <asp:TextBox runat="server" ID="txt_valor" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Cancelar</button>
                    <asp:Button ID="btn_abonar" OnClick="btn_abonar_Click" Text="Abonar" runat="server" type="button" class="btn btn-primary"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.CREAR USUARIOS -->

    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

</asp:Content>
