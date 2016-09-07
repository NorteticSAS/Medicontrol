<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="AT10-ContrareferenciaPacientes.aspx.cs" Inherits="Medicontrol.Facturacion.WebForm10" %>
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

    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <fieldset>
        <legend>Contrareferencia de pacientes Anexo técnico 10 Res. 4331/12</legend>
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
                <asp:Label runat="server" ID="Label10" Text="Tipo"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_tipodoc" ReadOnly="true"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="Label3" Text="Numero"></asp:Label>
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
    </fieldset>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"
        UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset onkeydown="return (event.keyCode!=13)">
                <legend>DATOS DE LA PERSONA RESPONSABLE DEL PACIENTE</legend>
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                        <asp:Label runat="server" ID="docucc" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="docuce" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="docupa" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="docuti" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="docurc" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="docuas" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="docums" Text="" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="Label2" Text="Tipo de Documento"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddl_respTipoDocumento" CssClass="form-control"></asp:DropDownList>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                        <asp:Label runat="server" ID="Label4" Text="Documento"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_respDocumento" ReadOnly="false"></asp:TextBox>
                        <br />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="Label5" Text="Primer Nombre"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_respNombre1" ReadOnly="false"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="Label6" Text="Segundo Nombre"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_respNombre2" ReadOnly="false"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="Label7" Text="Primer Apellido"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_respApellido1" ReadOnly="false"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="Label8" Text="Segundo Apellido"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_respApellido2" ReadOnly="false"></asp:TextBox>
                        <br />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="Label9" Text="Direccion"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_direccion" ReadOnly="false"></asp:TextBox>
                        <br />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="Label11" Text="Telefono"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_respTelefono" ReadOnly="false"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="Label12" Text="Departamento"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddl_departamento" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_departamento_SelectedIndexChanged"></asp:DropDownList>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="Label13" Text="Municipio"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddl_municipio" CssClass="form-control" Enabled="false"></asp:DropDownList>
                        <br />
                    </div>
                </div>
            </fieldset>
            <fieldset onkeydown="return (event.keyCode!=13)">
                <legend>PROFESIONAL QUE CONTRAREFIERE</legend>
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                        <asp:Label runat="server" ID="Label14" Text="Profesional"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddl_profesionales" CssClass="form-control"></asp:DropDownList>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                        <asp:Label runat="server" ID="Label15" Text="Servicio que contrarefiere"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_serviciocontra" ReadOnly="false"></asp:TextBox>
                        <br />
                    </div>
                </div>
                
            </fieldset>
             </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddl_departamento" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
            <fieldset>
                <legend>INFORMACION CLINICA RELEVANTE</legend>
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        <asp:Label runat="server" ID="Label17" Text="Dilegencie en el orden indicado: fecha de inicio de atención (anotar el día, mes y año en el cual se inicio la atención del paciente remitido), fecha de alta o finalización (anotar el día, mes y año en el cual se inicio la atención del paciente remitido). Resumen de la evolución, fecha y resultados de examenes de apoyo diagnóstico realizados, diagnósticos, complicaciones, tratamientos empleados, pronóstico, recomendaciones, firma y registro del profesional responsable." ForeColor="Red"></asp:Label>
                        <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control" ID="txt_infoclinica" ReadOnly="false"></asp:TextBox>
                        <br />
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
</asp:Content>
