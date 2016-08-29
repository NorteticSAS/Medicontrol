<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Admisiones.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web12" %>

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
            $("[id$=txt_dximgreso]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/Admisiones.aspx/BuscarDiagnostico") %>',
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
                                                },
                                                error: function (response) {
                                                    alert(response.responseText);
                                                },
                                                failure: function (response) {
                                                    alert(response.responseText);
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
    <asp:Label runat="server" ID="ActConsecutivo" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoEnSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="NombreSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodEntidad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodTipoContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="EstadoAdmision" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_zona" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="EstadoA" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TipoAdmi" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TipoSexoDx" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FechaNacimientoPac" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="NumAdmision" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="SexoPacientes" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="fechaNacimiento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Sexopaciente" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Edad" Visible="false"></asp:Label>




    <div class="btn-group btn-group-justified" role="group" aria-label="...">
        <div class="btn-group" role="group">
            <asp:Button BackColor="#999999" OnClick="btn_Nuevo_Click" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nueva Admision" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button PostBackUrl="~/Facturacion/ConsultarAdmisiones.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar Admison" />
        </div>
       <%-- <div class="btn-group" role="group">
            <asp:Button Enabled="true" runat="server" PostBackUrl="~/Facturacion/ModificarAdmision.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar Admision" />
        </div>--%>
       <%-- <div class="btn-group" role="group">
            <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
        </div>--%>
    </div>

    <hr />
    <h3>Admisiones</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

    <div class="form-group">
        <asp:Panel runat="server" ID="panel" DefaultButton="btn_buscarAdmision">
            <asp:Label runat="server" ID="lbl_buscar" Text="Digite el número de documento" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-3"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-2">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
                <br />
            </div>
            <asp:Button runat="server" ID="btn_buscarAdmision" OnClick="btn_buscarAdmision_Click" Text="Buscar" CssClass="btn btn-primary" />
        </asp:Panel>
    </div>
    <br />
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>--%>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label1" Text="Documento de Identidad"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_cedula" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label2" Text="Tipo de Admisión"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_TipoAdmisiones" AutoPostBack="true" OnSelectedIndexChanged="ddl_TipoAdmisiones_SelectedIndexChanged" CssClass="form-control">
                <asp:ListItem Value="2" Text="Urgencias"></asp:ListItem>
                <asp:ListItem Value="0" Text="Ambulatoria"></asp:ListItem>
                <asp:ListItem Value="1" Text="Hospitalización"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label3" Text="Numero de Admisión"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numAdmision" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_nombre" Text="Nombre"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_fecha" Text="Fecha"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fecha" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_hora" Text="Hora"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_hora" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_entidad" Text="Entidad"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_entidad" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_contrato" Text="Contrato"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_contrato" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_estrato" Text="Estrato"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_estrato" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_edad" Text="Edad"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_edad" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_sexo" Text="Sexo"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_sexo"></asp:TextBox>
            <br />
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_causa" Text="Causa Externa"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_causas" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_autorizacion" Text="Autorización"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_autorizacion"></asp:TextBox>
            <br />
        </div>
    </div>


    <br />
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">Acompañante</div>
                <div class="panel-body">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                        <asp:Label runat="server" ID="lbl_acompañante" Text="Nombre del Acompañante"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_acompanante"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                        <asp:Label runat="server" ID="lbl_direccion" Text="Dirección"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_direccion"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                        <asp:Label runat="server" ID="lbl_telefono" Text="Teléfono"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_telefono"></asp:TextBox>
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <br />

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">Hospitalización</div>
                <div class="panel-body">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <asp:Label runat="server" ID="lbl_viaingreso" Text="Vía de Ingreso"></asp:Label>
                        <asp:DropDownList Enabled="false" runat="server" ID="ddl_viaingreso" CssClass="form-control">
                            <asp:ListItem Text="Urgencias" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Consulta externa o programada" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Remitido" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Nacido en la institución" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </div>

                    <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server"
                        UpdateMode="Conditional">
                        <ContentTemplate>--%>
                            
                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 alert alert-danger">
                                <asp:Label runat="server" ID="lbl_resultadoDx" Text=""></asp:Label>
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
                                <asp:Label runat="server" ID="lbl_cie10" Text="Ingrese código CIE10"></asp:Label>
                                <asp:TextBox ReadOnly="true" runat="server" CssClass="form-control" ID="txt_cie10" />
                                <br />
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                                <asp:Label runat="server" ID="lbl_dxingreso" Text="Diagnóstico de Ingreso (CIE10)"></asp:Label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_dximgreso" ReadOnly="true"></asp:TextBox>
                                <br />
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
                                <br />
                                <asp:Button Enabled="false" runat="server" ID="btn_buscardx" Text="Verificar" CssClass="btn btn-primary" OnClick="btn_buscardx_Click" />
                                <br />
                            </div>
                       <%-- </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btn_buscardx" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>--%>

                    <div class="form-group">
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server"
                                UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-xs-12 col-sm-12 col-md-7 col-lg-7">
                                        <asp:Label runat="server" ID="lbl_especialidad" Text="Especialidad"></asp:Label>
                                        <asp:DropDownList Enabled="false" runat="server" ID="ddl_especialidad" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddl_especialidad_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label runat="server" ID="CodEspecialidad" Visible="false"></asp:Label>

                                        <br />
                                    </div>

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server"
                                        UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                                                <asp:Label runat="server" ID="lbl_cama" Text="Cama Nº"></asp:Label>
                                                <asp:DropDownList Enabled="false" runat="server" OnSelectedIndexChanged="ddl_cama_SelectedIndexChanged" ID="ddl_cama" AutoPostBack="true" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:Label runat="server" ID="CodigoCama" Visible="false"></asp:Label>

                                                <br />
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddl_cama" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddl_especialidad" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>


                    <%-- </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_TipoAdmisiones" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel> --%>
                </div>

            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <br />
            <asp:Button runat="server" ID="btn_guardar" Text="Guardar" OnClick="btn_guardar_Click" CssClass="btn btn-primary" />
            <br />
        </div>
    </div>


    <script type="text/javascript">
        function ShowPopupContratos() {
            $("#btnContratos").click();
        }
    </script>
    <button type="button" style="display: none;" id="btnContratos" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#Mcontratos">
        Launch demo modal
    </button>
    <div class="modal fade" id="Mcontratos" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Admisiones</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_contratos" runat="server" />
                    <br />
                    <br />
                    <asp:GridView runat="server" ID="gridPacienteContrato" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridPacienteContrato_RowDataBound" OnSelectedIndexChanged="gridPacienteContrato_SelectedIndexChanged">
                        <Columns>

                            <asp:BoundField DataField="EntidadCodigo" HeaderText="Código Entidad" />
                            <asp:BoundField DataField="EntidadNombre" HeaderText="Entidad" />
                            <asp:BoundField DataField="ContratoCodigo" HeaderText="Código Contrato" />
                            <asp:BoundField DataField="ContratoDescripcion" HeaderText="Contrato" />
                            <asp:BoundField DataField="ContratoTipo" HeaderText="Tipo Contrato" />
                            <asp:BoundField />
                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=gridPacienteContrato] td").hover(function () {
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
    <!-- /.SELECCIONAR CONTRATOS -->

    <script type="text/javascript">
        function ShowPopupNoexiste() {
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

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        No</button>
                    <asp:Button ID="Button2" OnClick="Button2_Click" Text="Si" runat="server" type="button" class="btn btn-primary"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.CREAR USUARIOS -->

    <script type="text/javascript">
        function ShowPopupSexos() {
            $("#btn_sexo").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_sexo" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#modalSexo">
        Launch demo modal
    </button>

    <div class="modal fade" id="modalSexo" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Admisiones</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="mensajeSexo" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">

                    <asp:Button ID="btn_errorsexo" Text="Aceptar" runat="server" type="button" class="btn btn-primary" OnClick="btn_errorsexo_Click"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <script type="text/javascript">
        function ShowPopupAdverUrgencias() {
            $("#btn_urg").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_urg" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#modalUrgencias">
        Launch demo modal
    </button>

    <div class="modal fade" id="modalUrgencias" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Admisiones</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="mensajeUrgencias" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">

                    <asp:Button ID="btn_aceptar" OnClick="btn_aceptar_Click" Text="Aceptar" runat="server" class="btn btn-primary"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.ADVERTENCIA URGENCIAS -->

    <script type="text/javascript">
        function ShowPopupHojaUrgencias() {
            $("#btn_hojaurg").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_hojaurg" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#modalHojaUrgencias">
        Launch demo modal
    </button>

    <div class="modal fade" id="modalHojaUrgencias" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Admisiones</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="mensajeHojaUrgencias" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button ID="HojaUrgenciasSi" Text="Imprimir" runat="server" type="button" class="btn btn-primary" OnClick="HojaUrgenciasSi_Click"></asp:Button>
                    <asp:Button ID="HojaUrgenciasNo" Text="Asignar Procedimientos" runat="server" type="button" class="btn btn-default" OnClick="HojaUrgenciasNo_Click"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.ADVERTENCIA URGENCIAS -->

    <script type="text/javascript">
        function ShowPopupHospitalizado() {
            $("#btn_hospitalizado").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_hospitalizado" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#modalHosp">
        Launch demo modal
    </button>

    <div class="modal fade" id="modalHosp" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Admisiones</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_mensajehospitalizado" runat="server" />
                    <br />
                    <asp:Label ID="lbl_mensajeasignarProced" runat="server" />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btn_aceptarHosp" Text="Si" runat="server" type="button" class="btn btn-primary" OnClick="btn_aceptarHosp_Click"></asp:Button>
                    <asp:Button ID="btn_cancelar" Text="No" runat="server" type="button" class="btn btn-primary" OnClick="btn_cancelar_Click"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.MENSAJE HOSPITALIZADO -->

    <script type="text/javascript">
        function ShowPopupAmbulatorio() {
            $("#btn_ambulatorio").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_ambulatorio" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#modalAmbu">
        Launch demo modal
    </button>

    <div class="modal fade" id="modalAmbu" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Admisiones</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_mensajeambulatorio" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button1" Text="Aceptar" runat="server" type="button" class="btn btn-primary" OnClick="Button1_Click"></asp:Button>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.MENSAJE HOSPITALIZADO -->
    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>
</asp:Content>
