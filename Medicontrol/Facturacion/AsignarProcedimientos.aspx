<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AsignarProcedimientos.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web14" %>

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
    <script type="text/javascript">
        $(function () {
            $("[id$=txt_procedimiento]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/software/Facturacion/AsignarProcedimientos.aspx/BuscarProcedimientos") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        }
                        
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <asp:Label runat="server" ID="cc" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="ce" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="TipoAdmision" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoEntidad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TipoContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CUF" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CCC" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_codRips" Visible="false"></asp:Label>


    <asp:Label runat="server" ID="CodProcedimientoH" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="DesProcedimientoH" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FechaServicioH" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CantidadProcedH" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoRipsH" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodUfuncionalH" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodCentrocH" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CODDP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CODD1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CODD2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CODD3" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CDPRP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CDRRP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CDCRP" Visible="false"></asp:Label>
    <%--<asp:Label runat="server" ID="CantO" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CantD" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CantA" Visible="false"></asp:Label>--%>


    <h3>Asignar Procedimientos</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
    <br />

    <div class="form-group">
        <asp:Panel runat="server" ID="panel1" DefaultButton="btn_buscarAdmision">
        <asp:Label runat="server" ID="lbl_buscar" Text="Digite el número de documento"></asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btn_buscarAdmision" Text="Buscar" CssClass="btn btn-primary" OnClick="btn_buscarAdmision_Click" />
</asp:Panel>
    </div>

    <div class="form-group">

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label1" Text="Documento de Identidad"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_cedula" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label2" Text="Paciente"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label3" Text="No. Admisión"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numeroAdmision" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
    </div><br />
    <div class="form-group">

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label4" Text="Entidad"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_entidad" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label5" Text="Contrato"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_contrato" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label6" Text="Tipo de Admisión"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_tipoAdmision" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
    </div><br />
    <div class="form-group">

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label7" Text="Fecha y Hora de Ingreso"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechaHora" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label8" Text="Fecha de Servicio"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechaServicio" ReadOnly="true"></asp:TextBox>
            <br />
        </div>

    </div><br />
    <div class="form-group">
        <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
             <asp:Panel runat="server" ID="panel2" DefaultButton="btn_BuscarCodigo">

                <asp:TextBox runat="server" CssClass="form-control" ID="txt_Codprocedimiento"></asp:TextBox>
                <asp:Button runat="server" ID="btn_BuscarCodigo" Visible="true" Text="Buscar" OnClick="btn_BuscarCodigo_Click" CssClass="btn btn-primary" />

            </asp:Panel>
        </div>
        <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                         <asp:Panel runat="server" ID="panel4" DefaultButton="btn_buscarXnombre">

                <asp:TextBox runat="server" CssClass="form-control" ID="txt_procedimiento"></asp:TextBox>
                <asp:Button runat="server" ID="btn_buscarXnombre" Visible="true" Text="Buscar" OnClick="btn_buscarXnombre_Click" CssClass="btn btn-primary" /><br /><br /><br />
</asp:Panel>
        </div>
    </div><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
<asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
    <div class="form-group">
        <div class="panel panel-primary">
            <div class="panel-heading">Consultas</div>
            <div class="panel-body">
                        

                <asp:GridView runat="server" ID="gridConsultas" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridConsultas_RowDataBound" OnSelectedIndexChanged="gridConsultas_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="CodProcedimiento" HeaderText="Cód" />
                        <asp:BoundField DataField="DesProcedimiento" HeaderText="Desc" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cant" />
                        <asp:BoundField DataField="Profesional" HeaderText="Prof" />
                        <asp:BoundField DataField="Finalidad" HeaderText="Finalidad" />
                        <asp:BoundField DataField="CausaEXT" HeaderText="C. Ext" />
                        <asp:BoundField DataField="DxPrincipal" HeaderText="DxPpal" />
                        <asp:BoundField DataField="TipoDXPrincipal" HeaderText="T.DxPpal" />
                        <asp:BoundField DataField="DX1" HeaderText="DxR1" />
                        <asp:BoundField DataField="DX2" HeaderText="DxR2" />
                        <asp:BoundField DataField="DX3" HeaderText="DxR3" />
                        <asp:BoundField DataField="Ufuncional" HeaderText="U.Fun" />
                        <asp:BoundField DataField="CentroC" HeaderText="C.Costo" />
                        <asp:BoundField DataField="Rip" HeaderText="RIP" />
                    </Columns>
                </asp:GridView>
                <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                <script type="text/javascript">
                    $(function () {
                        $("[id*=gridConsultas] td").hover(function () {
                            $("td", $(this).closest("tr")).addClass("hover_row");
                        }, function () {
                            $("td", $(this).closest("tr")).removeClass("hover_row");
                        });
                    });
                </script>
                <br />
                <asp:Button ID="eliminarConsulta" runat="server" Text="Eliminar Registro" Visible="false" OnClick="eliminarConsulta_Click"></asp:Button>
            </div>
        </div>

    </div>
    <br />
    <div class="form-group">
        <div class="panel panel-primary">
            <div class="panel-heading">Procedimientos</div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="gridProcedimientos" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridProcedimientos_RowDataBound" OnSelectedIndexChanged="gridProcedimientos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="CodProcedimiento" HeaderText="Cód" />
                        <asp:BoundField DataField="DesProcedimiento" HeaderText="Desc" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cant" />
                        <asp:BoundField DataField="Profesional" HeaderText="Prof" />
                        <asp:BoundField DataField="Finalidad" HeaderText="Finalidad" />
                        <asp:BoundField DataField="Personal" HeaderText="P.Atiende" />
                        <asp:BoundField DataField="DPX" HeaderText="DxPpal" />
                        <asp:BoundField DataField="DRX" HeaderText="DxRel" />
                        <asp:BoundField DataField="DCX" HeaderText="DxComp" />
                        <asp:BoundField DataField="UnidadF" HeaderText="U.Fun" />
                        <asp:BoundField DataField="CentroC" HeaderText="C.Costo" />
                        <asp:BoundField DataField="RIP" HeaderText="RIP" />
                    </Columns>
                </asp:GridView>
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                <script type="text/javascript">
                    $(function () {
                        $("[id*=gridProcedimientos] td").hover(function () {
                            $("td", $(this).closest("tr")).addClass("hover_row");
                        }, function () {
                            $("td", $(this).closest("tr")).removeClass("hover_row");
                        });
                    });
                </script>
                <br />
                <asp:Button ID="EliminarProcedimientos" runat="server" Text="Eliminar Registro" Visible="false" OnClick="EliminarProcedimientos_Click"></asp:Button>
            </div>
        </div>

    </div>
    <br />
    <div class="form-group">
        <div class="panel panel-primary">
            <div class="panel-heading">Medicamentos</div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="gridMedicamentos" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridMedicamentos_RowDataBound" OnSelectedIndexChanged="gridMedicamentos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Codigo" HeaderText="Cód" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Desc" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="CantO" HeaderText="CantOrd" />
                        <asp:BoundField DataField="CantD" HeaderText="CantDesp" />
                        <asp:BoundField DataField="CantA" HeaderText="CantAdm" />
                        <asp:BoundField DataField="UnidadF" HeaderText="U.Fun" />
                        <asp:BoundField DataField="CentroC" HeaderText="C.Costo" />
                        <asp:BoundField DataField="RIP" HeaderText="RIP" />
                    </Columns>
                </asp:GridView>
                <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
                <script type="text/javascript">
                    $(function () {
                        $("[id*=gridMedicamentos] td").hover(function () {
                            $("td", $(this).closest("tr")).addClass("hover_row");
                        }, function () {
                            $("td", $(this).closest("tr")).removeClass("hover_row");
                        });
                    });
                </script>
                <br />
                <asp:Button ID="eliminarMedicamento" runat="server" Text="Eliminar Registro" Visible="false" OnClick="eliminarMedicamento_Click"></asp:Button>
            </div>
        </div>

    </div>
    <br />
    <div class="form-group">
        <div class="panel panel-primary">
            <div class="panel-heading">Otros Servicios</div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="gridOtrosservicios" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridOtrosservicios_RowDataBound" OnSelectedIndexChanged="gridOtrosservicios_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Codigo" HeaderText="Cód" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Desc" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cant" />
                        <asp:BoundField DataField="UnidadF" HeaderText="U.Fun" />
                        <asp:BoundField DataField="CentroC" HeaderText="C.Costo" />
                        <asp:BoundField DataField="RIP" HeaderText="RIP" />
                    </Columns>
                </asp:GridView>
                <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
                <script type="text/javascript">
                    $(function () {
                        $("[id*=gridOtrosservicios] td").hover(function () {
                            $("td", $(this).closest("tr")).addClass("hover_row");
                        }, function () {
                            $("td", $(this).closest("tr")).removeClass("hover_row");
                        });
                    });
                </script>
                <br />
                <asp:Button ID="EliminarOtrosS" runat="server" Text="Eliminar Registro" Visible="false" OnClick="EliminarOtrosS_Click"></asp:Button>
            </div>
        </div>

    </div>
    <br />
                     </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gridConsultas" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
    <div class="form-group">
        <asp:Button runat="server" ID="btn_guardarTabla" CssClass="btn btn-primary" Text="Guardar" OnClick="btn_guardarTabla_Click" />
    </div>


    <script type="text/javascript">
        function ShowPopupCantidad() {
            $("#btn_cantidad").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_cantidad" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalCantidad">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalCantidad" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <asp:Panel ID="Panel3" runat="server" DefaultButton="btn_cantidadProced">

                    <div class="modal-body">
                        <asp:Label ID="lbl_mensajeCantidad" runat="server" />
                        <br />
                        <asp:TextBox runat="server" ID="txt_CantidadProcedimiento" Text="1" placeholder="Digite la cantidad facturar" CssClass="form-control"></asp:TextBox>

                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btn_cantidadProced" OnClick="btn_cantidadProced_Click" Text="Facturar" runat="server" type="button" class="btn btn-primary"></asp:Button>
                    </div>
                </asp:Panel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <script type="text/javascript">
        function ShowPopupCentroCostos() {
            $("#btnCostos").click();
        }
    </script>
    <button type="button" style="display: none;" id="btnCostos" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#Mcetrocostos">
        Launch demo modal
    </button>

    <div class="modal fade" id="Mcetrocostos" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_centroCostos" runat="server" />
                    <br />
                    <br />
                    <asp:GridView runat="server" ID="GridCentroCostos" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="GridCentroCostos_RowDataBound" OnSelectedIndexChanged="GridCentroCostos_SelectedIndexChanged">
                        <Columns>

                            <asp:BoundField DataField="CodigoUnidad" HeaderText="Código UF" />
                            <asp:BoundField DataField="DescUnidad" HeaderText="Descripción UF" />
                            <asp:BoundField DataField="CodigoCentroCostos" HeaderText="Código CC" />
                            <asp:BoundField DataField="DescCentroCostos" HeaderText="Descripción CC" />
                            <asp:BoundField />
                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=GridCentroCostos] td").hover(function () {
                                $("td", $(this).closest("tr")).addClass("hover_row");
                            }, function () {
                                $("td", $(this).closest("tr")).removeClass("hover_row");
                            });
                        });
                    </script>
                </div>

            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>


    <script type="text/javascript">
        function ShowPopupRipsConsulta() {
            $("#btn_RipsC").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_RipsC" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalRipsConsulta">
        Launch demo modal
    </button>
    <script type="text/javascript">
        $(function () {
            $("[id$=Modal_DescDiagP]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/software/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id$=Modal_DescD1]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/software/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id$=Modal_DescD2]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/software/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id$=Modal_DescD3]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/software/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <div class="modal fade" id="ModalRipsConsulta" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación - RIPS Consulta</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="alert alert-danger">
        <asp:Label runat="server" ID="resultadoc" Text=""></asp:Label>
    </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label17" Text="Codigo de Procedimiento"></asp:Label>
                            <asp:TextBox runat="server" onkeydown = "return (event.keyCode!=13);" ReadOnly="false" placeholder="Código" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="Modal_CodProced"></asp:TextBox>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label11" Text="Profesional"></asp:Label>
                            <asp:DropDownList runat="server" onkeydown = "return (event.keyCode!=13);" CssClass="form-control" ID="ddl_profesional"></asp:DropDownList><br />
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label18" Text="Finalidad"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="Modal_ddlFinalidadConsulta"></asp:DropDownList><br />
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label19" Text="Causa Externa"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="Modal_ddlCausaEterna"></asp:DropDownList><br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label21" Text="Tipo de Diagnostico Principal"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="Modal_ddlTipoDX"></asp:DropDownList><br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label20" Text="Diagnostico Principal"></asp:Label>
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Código Diagnostico Principal" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodDiagP"></asp:TextBox><br />
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" runat="server" placeholder="Descripción Diagnostico Principal" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescDiagP"></asp:TextBox><br />
                           
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label22" Text="Diagnostico R1"></asp:Label>
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Código D1" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodD1"></asp:TextBox><br />
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Descripción D1" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescD1"></asp:TextBox><br />
                           
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label14" Text="Diagnostico R2"></asp:Label>
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Código D2" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodD2"></asp:TextBox><br />
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Descripción D2" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescD2"></asp:TextBox><br />
                            
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label15" Text="Diagnostico R3"></asp:Label>
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Código D3" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodD3"></asp:TextBox><br />
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Descripción D3" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescD3"></asp:TextBox>
                            
                                <br />
                        </div>
                        <br />
                        <br />

                    </div>
                </div>
                <br />
                <div class="modal-footer">
                    <div class="form-group">
                        <br />
                        <br />
                        <asp:Button ID="GuardarConsulta" Text="Guardar" OnClick="GuardarConsulta_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>


    <script type="text/javascript">
        function ShowPopupRipsProced() {
            $("#btn_Ripsp").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_Ripsp" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalRipsProced">
        Launch demo modal
    </button>
    <script type="text/javascript">
        $(function () {
            $("[id$=RPDDiangP]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/software/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id$=RPDDiagR]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/software/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id$=RPDDiagC]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/software/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <div class="modal fade" id="ModalRipsProced" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Sistema de Facturación - RIPS Procedimientos</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label16" Text="Codigo de Procedimiento"></asp:Label>
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" runat="server" ReadOnly="false" placeholder="Código Procedimiento" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="RPCodProced"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label9" Text="Profesional"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_profesional2"></asp:DropDownList>

                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label24" Text="Ambito"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_ambito"></asp:DropDownList>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label26" Text="Personal que atiende"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_personal"></asp:DropDownList>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label23" Text="Finalidad"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="RPFinalidad"></asp:DropDownList><br />
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label25" Text="Diagnostico Principal"></asp:Label>
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Código Diagnostico Principal" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="RPCodDiagP"></asp:TextBox><br />
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" runat="server" placeholder="Descripción Diagnostico Principal" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="RPDDiangP"></asp:TextBox><br />

                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label27" Text="Diagnostico Relacionado"></asp:Label>
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Código DC" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="RPCodDiaGR"></asp:TextBox><br />
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Descripción DC" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="RPDDiagR"></asp:TextBox><br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label28" Text="Diagnostico Complementario"></asp:Label>
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Código DR" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="RPCodDiagC"></asp:TextBox><br />
                            <asp:TextBox onkeydown = "return (event.keyCode!=13);" placeholder="Descripción DR" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="RPDDiagC"></asp:TextBox><br />
                        </div>

                        <br />
                        <br />

                    </div>
                </div>
                <br />
                <div class="modal-footer">
                    <div class="form-group">
                        <br />
                        <br />
                        <asp:Button ID="GuardarRipsProced" Text="Guardar" OnClick="GuardarRipsProced_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <script type="text/javascript">
        function ShowPopupMedicamentos() {
            $("#btn_medi").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_medi" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalMedica">
        Launch demo modal
    </button>
    <div class="modal fade" id="ModalMedica" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Sistema de Facturación - RIPS Procedimientos</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label12" Text="Cantidad Ordenada"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="false" CssClass="form-control col-lg-4 col-md-12 col-sm-12 col-xs-12" ID="CantO"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label13" Text="Cantidad Despachada"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="false" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="CantD"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label29" Text="Cantidad Administrada"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="false" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="CantA"></asp:TextBox>
                        </div>

                        <br />
                        <br />

                    </div>
                </div>
                <br />
                <div class="modal-footer">
                    <div class="form-group">
                        <br />
                        <br />
                        <asp:Button ID="GuardarMedicamentos" Text="Guardar" OnClick="GuardarMedicamentos_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

     <script type="text/javascript">
         function ShowPopupOrdenSalida() {
             $("#btn_orden").click();
         }
    </script>
    <button type="button" style="display: none;" id="btn_orden" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ordenSalidaModal">
        Launch demo modal
    </button>

    <div class="modal fade" id="ordenSalidaModal" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_mensajeOrden" runat="server" />
                    <br />
                    <br />
                   
                </div>
                <div class="modal-footer">
                    <div class="form-group">
                        <br />
                        <br />
                        <asp:Button ID="btn_aCeptar" Text="Si" OnClick="btn_aCeptar_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                        <asp:Button runat="server" ID="btn_No" Text="No" OnClick="btn_No_Click" CssClass="btn btn-primary" /> 
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

</asp:Content>
