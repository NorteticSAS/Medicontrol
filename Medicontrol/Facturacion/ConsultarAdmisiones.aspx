<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ConsultarAdmisiones.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web13" %>
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
    <div class="btn-group btn-group-justified" role="group" aria-label="...">
        <div class="btn-group" role="group">
            <asp:Button  PostBackUrl="~/Facturacion/Admisiones.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nueva Admisión" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button BackColor="#999999" runat="server" ID="btn_Buscar" OnClick="btn_Buscar_Click" CssClass="btn btn-primary" Text="Consultar Admision"/>
        </div>
       <%-- <div class="btn-group" role="group">
            <asp:Button PostBackUrl="~/Facturacion/ModificarAdmision.aspx" Enabled="true" runat="server" ID="btn_Modficar" CssClass="btn btn-primary" Text="Modificar Admision" />
        </div>--%>
    </div>

    <hr />
    <h3>Consultar Admisiones</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_tipoadmision" Text="Tipo de Admisión"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_admision" CssClass="form-control">
                <asp:ListItem Text="Ambulatoria" Value="0"></asp:ListItem>
                <asp:ListItem Text="Hospitalizacion" Value="1"></asp:ListItem>
                <asp:ListItem Text="Urgencias" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Panel runat="server" ID="panel" DefaultButton="btn_buscarAdmision">
            <asp:Label runat="server" ID="lbl_numadmision" Text="Número Admisión"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numadmision" />
            <br />
            <asp:Button runat="server" ID="btn_buscarAdmision" Text="Buscar por No Admision" CssClass="btn btn-primary" OnClick="btn_buscarAdmision_Click" />
            </asp:Panel>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Panel runat="server" ID="panel1" DefaultButton="btn_buscarAdmision">
            <asp:Label runat="server" ID="lbl_documento" Text="Documento"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_documento" />
            <br />
            <asp:Button runat="server" ID="btn_buscarDocumento" Text="Buscar por Documento" CssClass="btn btn-primary" OnClick="btn_buscarDocumento_Click" />
        </asp:Panel>
        </div>
        
           
    </div>
    <br />
    <div class="form-group">
        <br /><br />
        <asp:GridView runat="server" ID="gridAdmisiones" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridAdmisiones_RowDataBound" OnSelectedIndexChanged="gridAdmisiones_SelectedIndexChanged">
                            <Columns>

                                <asp:BoundField DataField="NumeroADM" HeaderText="No. Admision" />
                                <asp:BoundField DataField="TipoADM" HeaderText="TipoAdm" />
                                <asp:BoundField DataField="FechaADM" HeaderText="Fecha" />
                                <asp:BoundField DataField="DocumentoADM" HeaderText="Documento" />
                                <asp:BoundField DataField="EntidadADM" HeaderText="Entidad" />
                                <asp:BoundField DataField="ContratoADM" HeaderText="Contrato" />
                                <asp:BoundField DataField="EstadoADM" HeaderText="Estado" />
                                <asp:BoundField />
                            </Columns>
                        </asp:GridView>
                        <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                        <script type="text/javascript">
                            $(function () {
                                $("[id*=gridAdmisiones] td").hover(function () {
                                    $("td", $(this).closest("tr")).addClass("hover_row");
                                }, function () {
                                    $("td", $(this).closest("tr")).removeClass("hover_row");
                                });
                            });
                        </script>
        <br /><br />
        <asp:Button runat="server" ID="btn_imprimirAdmision" OnClick="btn_imprimirAdmision_Click" Text="Imprimir Admisión" CssClass="btn btn-danger" Visible="false" /> 
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_estado" Text="Estado*"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_estado" CssClass="form-control">
                <asp:ListItem Value="0" Text="Abierta"></asp:ListItem>
                <asp:ListItem Value="1" Text="Con orden de salida"></asp:ListItem>
                <asp:ListItem Value="2" Text="Facturada"></asp:ListItem>
                <asp:ListItem Value="3" Text="Anulada"></asp:ListItem>
                <asp:ListItem Value="4" Text="No facturable"></asp:ListItem>
                <asp:ListItem Value="5" Text="Hospitalizada"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-1">
            <br />
            <asp:Button Visible="false" runat="server" ID="btn_imprimir" Text="Imprimir" CssClass="btn btn-primary" />
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-7">
            <br />
            <asp:Button runat="server" Visible="false" ID="btn_guardar" Text="Guardar" OnClick="btn_guardar_Click" CssClass="btn btn-primary" />
            <br />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <asp:Label runat="server" ID="lbl_info" Text="*Estado: Abierta = 0, Con orden de salida = 1, Facturada = 2, Anulada = 3, No facturable = 4, Hospitalización = 5"></asp:Label>
        </div>
    </div>

         <script type="text/javascript">
             function ShowPopupExito() {
                 $("#btn_mensaje").click();
             }
        </script>
        <button type="button" style="display: none;" id="btn_mensaje" class="btn btn-primary btn-lg"
            data-toggle="modal" data-target="#modalExito">
            Launch demo modal
        </button>

        <div class="modal fade" id="modalExito" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                         <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Admisiones</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lbl_mensajeExito" runat="server" />
                        <br />
                        
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Aceptar" Text="Aceptar" runat="server" type="button" class="btn btn-primary" OnClick="Aceptar_Click"></asp:Button>
                        
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.MENSAJE HOSPITALIZADO -->
        <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>
</asp:Content>
