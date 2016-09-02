<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="AT3-SolicitudServiciosSalud.aspx.cs" Inherits="Medicontrol.Facturacion.WebForm7" EnableEventValidation="false" %>

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
            $("[id$=Modal_DescDiagP]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/AT3-SolicitudServiciosSalud.aspx/BuscarDiagnostico") %>',
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
    <script type="text/javascript">
        $(function () {
            $("[id$=Modal_DescD1]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/AT3-SolicitudServiciosSalud.aspx/BuscarDiagnostico") %>',
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
    <script type="text/javascript">
        $(function () {
            $("[id$=Modal_DescD2]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/AT3-SolicitudServiciosSalud.aspx/BuscarDiagnostico") %>',
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
    <script type="text/javascript">
        $(function () {
            $("[id$=txt_procedimiento]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/AT3-SolicitudServiciosSalud.aspx/BuscarProcedimientos") %>',
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
    <fieldset>
        <legend>Solicitud de Autorización de Servicios de Salud. Res. 3047 de 2008. Anexo Técnico 3.</legend>
        <br />
        <div class="alert alert-danger">
            <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
        </div>
        <asp:Label runat="server" ID="CodigoSesion" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="FechaNacimientoPac" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="fechanacimiento" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CodEntidad" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CodContrato" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="CodTipoContrato" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="txt_tipodocvictimacc" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="txt_tipodocvictimace" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="txt_tipodocvictimapa" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="txt_tipodocvictimati" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="txt_tipodocvictimarc" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="txt_tipodocvictimaas" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="txt_tipodocvictimams" Text="" Visible="false"></asp:Label>
        <div class="form-group">
            <asp:Panel runat="server" ID="panel" DefaultButton="btn_buscarPaciente">
                <asp:Label runat="server" ID="lbl_buscar" Text="Digite el número de documento" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-3"></asp:Label>
                <div class="col-sm-12 col-xs-12 col-md-12 col-lg-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
                    <br />
                </div>
                <asp:Button runat="server" ID="btn_buscarPaciente" OnClick="btn_buscarPaciente_Click" Text="Buscar" CssClass="btn btn-primary" />
            </asp:Panel>
        </div>
        <br />
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                <asp:Label runat="server" ID="Label1" Text="Documento de Identidad"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_cedula" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                <asp:Label runat="server" ID="Label10" Text=" "></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_tipodoc" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="Label3" Text="Numero de Informe"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_numInforme" ReadOnly="true"></asp:TextBox>
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
                <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="txt_sexo"></asp:TextBox>
                <br />
            </div>
        </div>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" ID="Label5" Text="" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="coberturaContributivo" Text="" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="coberturasubsidiototal" Text="" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="coberturasubsidioparcial" Text="" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="coberturapobreconsisben" Text="" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="coberturapobresinsisben" Text="" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="coberturadesplazados" Text="" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="coberturaplanadicional" Text="" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="coberturaotro" Text="" Visible="false"></asp:Label>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_autorizacion" Text="Cobertura en Salud"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_cobertura" CssClass="form-control">
                    <asp:ListItem Value="0" Text="Seleccione"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Regimen Contributivo"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Regimen Subsidiado - total"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Regimen Subsidiado - parcial"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Población pobre no aseg - con SISBEN"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Población pobre no aseg - sin SISBEN"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Desplazados"></asp:ListItem>
                    <asp:ListItem Value="7" Text="Plan adicional de Salúd"></asp:ListItem>
                    <asp:ListItem Value="8" Text="Otro"></asp:ListItem>

                </asp:DropDownList>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="enfermedadgenaral" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="enfermedadprofesional" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="accidentetrabajo" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="accidentetransito" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="eventocatastrofico" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lbl_causa" Text="Origen de la Atención"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_origenAtencion" CssClass="form-control">
                    <asp:ListItem Value="0" Text="Seleccione"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Enfermedad General"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Enfermedad Profesional"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Accidente de Trabajo"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Accidente de Transito"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Evento Catastrófico"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </div>
        </div>
        <hr />
    </fieldset>
    <fieldset>
        <legend>Información de la Atencion y Servicios Solicitados</legend>
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                 <asp:Label runat="server" ID="posterior" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="electivos" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="Label2" Text="Tipos de Servicios Solicitados"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_serviciossol" CssClass="form-control">
                    <asp:ListItem Value="0" Text="Seleccione"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Posterior a la atención inicial de urgencias"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Servicios electivos"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                 <asp:Label runat="server" ID="prioritariasi" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="prioritariano" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="Label4" Text="Prioridad de la Atencion"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_prioridad" CssClass="form-control">
                    <asp:ListItem Value="0" Text="Seleccione"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Prioritaria"></asp:ListItem>
                    <asp:ListItem Value="2" Text="No prioritaria"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="opcionconsultaext" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="opcionurgencias" Text="" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="opcionhospitalizacion" Text="" Visible="false"></asp:Label>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <asp:Label runat="server" Font-Size="Medium" ID="Label6" Text="Ubicacion del paciente al momento de la Solicitud de Autorización"></asp:Label>
                    <asp:CheckBox Font-Size="Medium" runat="server" ID="chk_consultaExt" Text="Consulta Externa" CssClass="checkbox" OnCheckedChanged="chk_consultaExt_CheckedChanged" AutoPostBack="true" />
                    <asp:CheckBox Font-Size="Medium" runat="server" ID="chk_urgencias" Text="Urgencias" OnCheckedChanged="chk_urgencias_CheckedChanged" CssClass="checkbox" AutoPostBack="true" />
                    <asp:CheckBox Font-Size="Medium" runat="server" ID="chk_hospitalizacion" OnCheckedChanged="chk_hospitalizacion_CheckedChanged" Text="Hospitalización" AutoPostBack="true" CssClass="checkbox" />
                </div>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                <asp:Label runat="server" Font-Size="Medium" ID="Label7" Text="Servicio"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_servicio" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                <asp:Label runat="server" Font-Size="Medium" ID="Label8" Text="Cama"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_cama" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
        </div>
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <asp:Label runat="server" Font-Size="Medium" ID="Label9" Text="Manejo integral según guia de"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_guia" ReadOnly="false"></asp:TextBox>
            </div>
        </div>
    </fieldset>
    <asp:Label runat="server" ID="FacturaCodigoProcedimiento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaDescProcedimiento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCantidad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCodigoCups" Visible="false"></asp:Label>

    <fieldset>

        <legend></legend>
        <div class="panel panel-primary">
            <div class="panel-heading">Servicios Solicitados</div>
            <div class="panel-body">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Panel runat="server" ID="panelcantidad" DefaultButton="btn_codigoCups">
                        <asp:TextBox runat="server" placeholder="Codigo CUPS" CssClass="form-control" ID="txt_codigoCups" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btn_codigoCups" CssClass="btn btn-link" OnClick="btn_codigoCups_Click" />
                    </asp:Panel>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Panel runat="server" ID="panel1" DefaultButton="btn_buscarNombre">
                        <asp:TextBox runat="server" placeholder="Nombre de Procedimiento" CssClass="form-control" ID="txt_procedimiento" ReadOnly="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btn_buscarNombre" CssClass="btn btn-link" OnClick="btn_buscarNombre_Click" />
                    </asp:Panel>
                </div>
                <br />
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <asp:GridView runat="server" ID="gridservicios" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridservicios_RowDataBound" OnSelectedIndexChanged="gridservicios_SelectedIndexChanged">
                        <Columns>

                            <asp:BoundField DataField="CodCups" HeaderText="Codigo" />
                            <asp:BoundField DataField="DesCups" HeaderText="Descripcion" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="CodSoat" HeaderText="Codigo CUPS" />
                            <asp:BoundField DataField="id" HeaderText="ID" />


                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=gridservicios] td").hover(function () {
                                $("td", $(this).closest("tr")).addClass("hover_row");
                            }, function () {
                                $("td", $(this).closest("tr")).removeClass("hover_row");
                            });
                        });
                    </script>
                </div>
                <br />
                <br />
                <asp:Button Visible="false" runat="server" ID="btn_eliminar" Text="Eliminar" CssClass="btn btn-primary" OnClick="btn_eliminar_Click" />
            </div>
        </div>

    </fieldset>
    <fieldset>

        <legend></legend>
        <div class="panel panel-primary">
            <div class="panel-heading">Justificación Clínica</div>
            <div class="panel-body">
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txt_justificacion" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </fieldset>

    <fieldset>

        <legend></legend>
        <div class="panel panel-primary">
            <div class="panel-heading">Impresión Diagnóstica</div>
            <div class="panel-body">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                     <asp:Panel runat="server" ID="panelprincipal" DefaultButton="btn_principal">
                            <asp:Label runat="server" ID="Label20" Text="Diagnostico Principal"></asp:Label>
                            <asp:TextBox placeholder="Código Diagnostico Principal" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodDiagP"></asp:TextBox><br />
                            <asp:TextBox runat="server" placeholder="Descripción Diagnostico Principal" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescDiagP"></asp:TextBox><br />
                         <asp:Button runat="server" ID="btn_principal" CssClass="btn btn-link" OnClick="btn_principal_Click" />
                     </asp:Panel>
                        </div>
                       
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Panel runat="server" ID="panel2" DefaultButton="btn_R1">
                            <asp:Label runat="server" ID="Label22" Text="Diagnostico Relacionado 1"></asp:Label>
                            <asp:TextBox placeholder="Código D1" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodD1"></asp:TextBox><br />
                            <asp:TextBox placeholder="Descripción D1" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescD1"></asp:TextBox><br />
                         <asp:Button runat="server" ID="btn_R1" CssClass="btn btn-link" OnClick="btn_R1_Click" />
                     </asp:Panel>
                                </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Panel runat="server" ID="panel4" DefaultButton="btn_R2">
                            <asp:Label runat="server" ID="Label14" Text="Diagnostico Relacionado 2"></asp:Label>
                            <asp:TextBox placeholder="Código D2" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodD2"></asp:TextBox><br />
                            <asp:TextBox placeholder="Descripción D2" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescD2"></asp:TextBox><br />
                        <asp:Button runat="server" ID="btn_R2" CssClass="btn btn-link" OnClick="btn_R2_Click" />
                     </asp:Panel>
                                </div>
                        
            </div>
        </div>
        <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <br />
            <asp:Button runat="server" ID="btn_guardar" Text="Guardar" OnClick="btn_guardar_Click" CssClass="btn btn-primary" />
            <asp:Button runat="server" ID="btn_imprimir" Text="Imprimir" OnClick="btn_imprimir_Click" CssClass="btn btn-primary" />
            <br />
        </div>
    </div>
    </fieldset>

    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>
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

</asp:Content>
