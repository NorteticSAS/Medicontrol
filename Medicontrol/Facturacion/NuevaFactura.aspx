<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="NuevaFactura.aspx.cs" EnableEventValidation="false" Inherits="Medicontrol.Facturacion.Formulario_web1" %>

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
                        url: '<%=ResolveUrl("/Facturacion/NuevaFactura.aspx/BuscarProcedimientos") %>',
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
                             $("[id$=txt_nombrePac]").autocomplete({
                                 source: function (request, response) {
                                     $.ajax({
                                         url: '<%=ResolveUrl("/Facturacion/NuevaFactura.aspx/BuscarPaciente") %>',
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
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12"></div>
    <hr />
    <div class="btn-group btn-group-justified" role="group" aria-label="...">
        <div class="btn-group" role="group">
            <asp:Button BackColor="#999999" OnClick="btn_Nuevo_Click" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nueva Factura" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button runat="server" ID="btn_GuardarFactura" CssClass="btn btn-primary" Text="Guardar Factura" OnClick="btn_GuardarFactura_Click" />
        </div>
        <%-- <div class="btn-group" role="group">
            <asp:Button Enabled="true" runat="server" PostBackUrl="~/Facturacion/ModificarPaciente.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Guardar e Imprimir Factura" />
        </div>--%>
        <%--<div class="btn-group" role="group">
            <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
        </div>--%>
    </div>
    <%--variables factura--%>
    <asp:Label runat="server" ID="CodigoEnSesion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CargoUsuario" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="username" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Ambito" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FamiliasEnAccion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="DemandaInducidatext" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="Liquidara" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="NumeroAdmision" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="TipoAdmision" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="FacturaTipoAfiliado" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCodigoEntidad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCodigoContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCodigoEstrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaTipoContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaFamiliasAccion" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaDemandaInducida" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCCC" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCUF" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaDCC" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaDUF" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Label30" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="FacturaCodigoCliente" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCodigoProcedimiento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaDescProcedimiento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCantidad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorProcedimiento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorUnitario" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorCopago" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorProcedimientoSN" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorUnitarioSN" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorCuotaModeradora" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorPorcEstrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCuotaModeradoraEstrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCuotaModeradoraEstratoSN" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaCobraCopago" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaTotalEmpresa" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaTotalEmpresaSN" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorTotalProcedimientos" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorTotalProcedimientosSN" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorCopagoTotal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaValorCopagoTotalSN" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaRips" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="FacturaTipoServicio" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="ValorCopagoFactura" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="ValorModeradoraFactura" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TotalP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TotalC" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="GCCodProced" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="GCFinalidadPYP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="GCCExterna" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CODDP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CODD1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CODD2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CODD3" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="CDPRP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CDRRP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CDCRP" Visible="false"></asp:Label>



    <asp:Label runat="server" ID="GPCodProced" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="GPAmbito" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="GPFinalidad" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="PrefijoFactura" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="PrefijoOrden" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="valorTotalFinalCopago" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="valorTotalFinalProced" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="ValorTotalFinalSubtotal" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="CodRipsP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="ConsecutivoF" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="direccionP" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="telefonoP" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="CodigoTipoAdmsion" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="CodContrato" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="CodEntidadT" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="CodProcedT" Visible="false"></asp:Label>


    <hr />
    <h3>Nueva Factura</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

   <div class="form-group">
            
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_buscar" Text="Digite el Documento del paciente"></asp:Label>
                <asp:Panel runat="server" ID="panel4" DefaultButton="btn_buscarPaciente">
                    <asp:TextBox placeholder="Buscar por Cédula" runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
                    <br />
                    <asp:Button runat="server" ID="btn_buscarPaciente" Text="Buscar" CssClass="btn btn-primary" OnClick="btn_buscarPaciente_Click" />
                </asp:Panel>
                <br />
            </div>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Panel runat="server" ID="panel5" DefaultButton="btn_buscarNombre">
                    <br />
                    <asp:TextBox placeholder="Buscar por Nombre" runat="server" CssClass="form-control" ID="txt_nombrePac"></asp:TextBox>
                    <br />
                    <asp:Button runat="server" ID="btn_buscarNombre" Text="Buscar" CssClass="btn btn-primary" OnClick="btn_buscarNombre_Click" />
                </asp:Panel>
                <br />
            </div>
        </div>
        <br />
    <br />
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_servicio" Text="Servicio"></asp:Label>
            <asp:DropDownList Enabled="false" runat="server" ID="ddl_servicio" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_fecha" Text="Fecha Factura"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fecha" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_numfacmanual" Text="Número de Factura Manual"></asp:Label>
            <asp:CheckBox Enabled="false" Checked="false" runat="server" CssClass="form-control" ID="chb_numfacmanual" />
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
            <asp:Label runat="server" ID="lbl_nombre" Text="Nombre"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
            <asp:Label runat="server" ID="lbl_documento" Text="Documento"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_documento" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
            <asp:Label runat="server" ID="lbl_tipodoc" Text="Tipo de Documento"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_tipodoc" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4 ">
            <asp:Label runat="server" ID="lbl_sexo" Text="Sexo"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_sexo" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_fechanac" Text="Fecha de Nacimiento"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechanac" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_edad" Text="Edad"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="Edad" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_zona" Text="Zona Residencial"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_zona" ReadOnly="true"></asp:TextBox>
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
            <asp:Label runat="server" ID="lbl_tipousuario" Text="Tipo Usuario"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_tipousuario" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_ips" Text="IPS"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_ips" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
    </div>

    <div class="form-group">
        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                        <asp:Label runat="server" ID="lbl_profesional" Text="Nombre del Profesional"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddl_profesional" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddl_profesional_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <br />
                    </div>

                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                        <asp:Label runat="server" ID="lbl_codprofesional" Text="Código del Profesional"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_codprofesional" ReadOnly="true"></asp:TextBox>
                        <br />
                        <br />
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_profesional" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                        <asp:Label runat="server" ID="lbl_pyp" Text="Programa PYP"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddl_pyp" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_pyp_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                        <asp:Label runat="server" ID="lbl_codpyp" Text="Código Programa PYP"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_codpyp" ReadOnly="true"></asp:TextBox>
                        <br />
                        <br />
                    </div>
                     </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_pyp" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
               
        </div>
    </div>
    <br />
    <br />
    
    <div class="form-group col-lg-6 col-md-6 col-sm-12 col-xs-12">
        <div class="panel panel-primary">
            <div class="panel-heading">Cargar Procedimientos por Código</div>
            <div class="panel-body">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_buscarProcedimientoCodigo">
                <asp:TextBox ReadOnly="false" runat="server" CssClass="form-control" placeholder="Digite el Código de Procedimiento" ID="txt_codProcedimiento"></asp:TextBox>
                
                <br />
                <asp:Button runat="server" Enabled="true" ID="btn_buscarProcedimientoCodigo" Text="Buscar Procedimiento" CssClass="btn btn-primary" OnClick="btn_buscarProcedimientoCodigo_Click" />
            </asp:Panel>
                    </div>
            
        </div>

    </div>
    <div class="form-group col-lg-6 col-md-6 col-sm-12 col-xs-12">
        <div class="panel panel-primary">
            <div class="panel-heading">Cargar Procedimientos por Nombre</div>
            <div class="panel-body">
                <asp:Panel ID="Panel2" runat="server" DefaultButton="btn_buscarProcedimiento">
                <asp:TextBox ReadOnly="false" runat="server" CssClass="form-control" placeholder="Digite el procedimiento que desee facturar" ID="txt_procedimiento"></asp:TextBox>

                <br />
                <asp:Button runat="server" Enabled="true" ID="btn_buscarProcedimiento" Text="Buscar Procedimiento" CssClass="btn btn-primary" OnClick="btn_buscarProcedimiento_Click" />
                    </asp:Panel>
            </div>
        </div>
    </div>
    
    <br />
    <br />
   <asp:UpdatePanel ID="UpdatePanel3" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
    <div class="form-group">
        
        <asp:GridView runat="server" ID="GridCuerpoFactura" Visible="true" AutoGenerateColumns="false" OnRowDataBound="GridCuerpoFactura_RowDataBound" CssClass="table table-bordered bs-table" OnSelectedIndexChanged="GridCuerpoFactura_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="CodProced" HeaderText="Código" />
                <asp:BoundField DataField="DescProced" HeaderText="Descripción" />
                <asp:BoundField DataField="CantProced" HeaderText="Cantidad" />
                <asp:BoundField DataField="Valor" HeaderText="Valor Proced" />
                <asp:BoundField DataField="ValorProced" HeaderText="Valor Unit" />
                <asp:BoundField DataField="EstratoCopago" HeaderText="Valor Copago" />
                <asp:BoundField DataField="Subtotal" HeaderText="Valor Total" />
                <asp:BoundField DataField="CodUnidadFuncional" HeaderText="UFuncional" />
                <asp:BoundField DataField="CodCentroC" HeaderText="CCosto" />
                <asp:BoundField DataField="CodRips" HeaderText="RIPS" />
                <asp:BoundField DataField="TipoServicio" HeaderText="TS" />

            </Columns>
        </asp:GridView>
        <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
        <script type="text/javascript">
            $(function () {
                $("[id*=GridCuerpoFactura] td").hover(function () {
                    $("td", $(this).closest("tr")).addClass("hover_row");
                }, function () {
                    $("td", $(this).closest("tr")).removeClass("hover_row");
                });
            });
        </script>
                    
    </div>
    <div class="form-group">
        <asp:Button runat="server" CssClass="btn btn-danger" ID="EliminarCelda" OnClick="EliminarCelda_Click" Text="Eliminar Registro" Visible="false" />
    </div>
                     </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridCuerpoFactura" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
    <br />
    <br />
    <br />
                  
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Cargar RIPS Consulta</div>
                <div class="panel-body">

                    <asp:Button ID="btn_ripsConsulta" Enabled="false" Visible="true" runat="server" OnClick="btn_ripsConsulta_Click" CssClass="btn btn-success" Text="Cargar"></asp:Button>
                    <asp:Button ID="btn_eliminarRipsConsulta" Enabled="false" Visible="true" runat="server" OnClick="btn_eliminarRipsConsulta_Click" CssClass="btn btn-danger" Text="Eliminar"></asp:Button>

                    <br />
                    <asp:GridView runat="server" ID="GridRipsConsulta" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="GridRipsConsulta_RowDataBound" OnSelectedIndexChanged="GridRipsConsulta_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="CodProcedimiento" HeaderText="Cod" />
                            <asp:BoundField DataField="Finalidad" HeaderText="Finalidad" />
                            <asp:BoundField DataField="CausaEXT" HeaderText="C Ext" />
                            <asp:BoundField DataField="DXPrincipal" HeaderText="DxP" />
                            <asp:BoundField DataField="TipoDXPrincipal" HeaderText="TDxP" />
                            <asp:BoundField DataField="DX1" HeaderText="DR1" />
                            <asp:BoundField DataField="DX2" HeaderText="DR2" />
                            <asp:BoundField DataField="DX3" HeaderText="DR3" />


                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=GridRipsConsulta] td").hover(function () {
                                $("td", $(this).closest("tr")).addClass("hover_row");
                            }, function () {
                                $("td", $(this).closest("tr")).removeClass("hover_row");
                            });
                        });
                    </script>
                </div>
            </div>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Cargar RIPS Procedimientos</div>
                <div class="panel-body">
                    <asp:Button ID="btn_ripsProced" Visible="true" Enabled="false" runat="server" OnClick="btn_ripsProced_Click" CssClass="btn btn-success" Text="Cargar"></asp:Button>
                    <asp:Button ID="btn_eliminarRipsProced" Enabled="false" Visible="true" runat="server" OnClick="btn_eliminarRipsProced_Click" CssClass="btn btn-danger" Text="Eliminar"></asp:Button>
                    <br />
                    <asp:GridView runat="server" ID="GridRipsProced" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="GridRipsProced_RowDataBound" OnSelectedIndexChanged="GridRipsProced_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="CodProcedimiento" HeaderText="Cod" />
                            <asp:BoundField DataField="Ambito" HeaderText="Ambito" />
                            <asp:BoundField DataField="Finalidad" HeaderText="Finalidad" />
                            <asp:BoundField DataField="Personal" HeaderText="Personal" />
                            <asp:BoundField DataField="DPX" HeaderText="Dxp" />
                            <asp:BoundField DataField="DRX" HeaderText="DRel" />
                            <asp:BoundField DataField="DCX" HeaderText="DComp" />


                        </Columns>
                    </asp:GridView>
                    <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>
                    <script type="text/javascript">
                        $(function () {
                            $("[id*=GridRipsProced] td").hover(function () {
                                $("td", $(this).closest("tr")).addClass("hover_row");
                            }, function () {
                                $("td", $(this).closest("tr")).removeClass("hover_row");
                            });
                        });
                    </script>
                </div>
            </div>
        </div>

    </div>
    <br />
    <br />
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">Totales Factura</div>
                <div class="panel-body">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="lbl_vrprocedimiento" Text="Valor Procedimientos"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="txt_vrprocedimiento"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="lbl_copago" Text="Valor Copago"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="txt_copago"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="lbl_vrtotal" Text="Valor Total Entidad"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="txt_vrtotal"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                        <asp:Label runat="server" ID="lbl_vrcuota" Text="Valor Cuota Moderadora"></asp:Label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txt_vrcuota"></asp:TextBox>
                        <br />
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <asp:Label runat="server" ID="Label23" Text="Valor en Letras"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_ValorLetras" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <asp:Label runat="server" ID="lbl_observacion" Text="Observaciones"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_observacion" TextMode="MultiLine"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
        </div>




    </div>
     <script type="text/javascript">
         function ShowPopupLiquidarAdmision() {
             $("#btn_liquidar").click();
         }
    </script>
    <button type="button" style="display: none;" id="btn_liquidar" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalLiquidacion">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalLiquidacion" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_liquidar" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btn_liquidaSI" Text="Si" runat="server" type="button" class="btn btn-primary" OnClick="btn_liquidaSI_Click"></asp:Button>
                    <asp:Button ID="btn_liquidaNO" Text="No" runat="server" type="button" class="btn btn-primary" OnClick="btn_liquidaNO_Click"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
     
    <script type="text/javascript">
        function ShowPopupImprimir() {
            $("#btn_print").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_print" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalPrint">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalPrint" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="Label42" Text="¿Desea imprimir la factura?" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button ID="Imprimesi" Text="Si" runat="server" type="button" class="btn btn-primary" OnClick="Imprimesi_Click"></asp:Button>
                    <asp:Button ID="Imprimeno" Text="No" runat="server" type="button" class="btn btn-primary" OnClick="Imprimeno_Click"></asp:Button>
                    <asp:Button ID="Cerrar" Text="Cerrar" runat="server" type="button" class="btn btn-primary" OnClick="Cerrar_Click"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
                           
     <script type="text/javascript">
         function ClosepopupCuentasxPagar() {
            $('#ModalFormPagoCop').modal('close');
        }
    </script>
    <script type="text/javascript">
        function ShowPopupFormCopago() {
            $("#ShowPopupFormCopago").click();
        }
    </script>
    <button type="button" style="display: none;" id="ShowPopupFormCopago" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalFormPagoCop">
        Launch demo modal
    </button>
    <div class="modal fade" id="ModalFormPagoCop" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Sistema de Facturación - RIPS Procedimientos</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">

                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label29" Text="Numero Factura"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="true" placeholder="" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="MPNumFactura"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label31" Text="Documento"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="true" placeholder="" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="MP_Documento"></asp:TextBox>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label32" Text="Nombre y Apellido"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="true" placeholder="" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="MP_Nombre"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label33" Text="Dirección"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="true" placeholder="" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="MP_Direccion"></asp:TextBox>
                        </div>

                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label34" Text="Telefono"></asp:Label>
                            <asp:TextBox placeholder="" ReadOnly="true" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="MP_Telefono"></asp:TextBox><br />

                        </div>

                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label35" Text="Fecha"></asp:Label>
                            <asp:TextBox placeholder="" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="MP_Fecha"></asp:TextBox><br />
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label36" Text="Valor Factura"></asp:Label>
                            <asp:TextBox placeholder="" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="MP_ValorFactura"></asp:TextBox><br />
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label37" Text="Ciudad"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="MP_ddl_Municipio"></asp:DropDownList><br />

                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label38" Text="Valor Copago y/o Cuota Moderadora"></asp:Label>
                            <asp:TextBox placeholder="" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="MP_ValorFacturaCopago"></asp:TextBox><br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label39" Text="Valor pagado por el Usuario"></asp:Label>
                            <asp:TextBox placeholder="" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="MP_ValorFacturaUsuario"></asp:TextBox><br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label40" Text="Valor adeudado por el Usuario"></asp:Label>
                            <asp:TextBox placeholder="" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="MP_ValordEudausuario"></asp:TextBox><br />
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
                        <asp:Button ID="Button4" Text="Guardar" OnClick="Button4_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                        <asp:Button ID="Button5" Text="Cerrar"  OnClick="Button1_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>

                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
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
                    <asp:Button ID="btn_cantidadProced" OnClick="btn_cantidad_Click" Text="Facturar" runat="server" type="button" class="btn btn-primary"></asp:Button>
                </div>
                                    </asp:Panel>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

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
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_contratos" runat="server" />
                    <br />
                    <br />
                    <asp:GridView runat="server" ID="gridPacienteContrato" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridPacienteContrato_RowDataBound1" OnSelectedIndexChanged="gridPacienteContrato_SelectedIndexChanged1">
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
    <!-- /.modal -->



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
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_mensajeUsuario" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        No</button>
                    <asp:Button ID="Button2" PostBackUrl="~/Facturacion/NuevoPaciente.aspx" Text="Si" runat="server" type="button" class="btn btn-primary"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <script type="text/javascript">
        function ShowPopupFamiliasAccion() {
            $("#FamiliaAccion").click();
        }
    </script>
    <button type="button" style="display: none;" id="FamiliaAccion" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalFamilias">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalFamilias" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_familias" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        No</button>
                    <asp:Button ID="btn_familias" Text="Si" OnClick="btn_familias_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <script type="text/javascript">
        function ShowPopupDemandaInducida() {
            $("#btn_demanda").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_demanda" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalDemanda">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalDemanda" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_demanda" runat="server" />
                    <br />
                    <div class="container">
                        <asp:CheckBoxList CssClass="checkbox" Font-Size="Medium" ID="checkDemanda" runat="server" AutoPostBack="true" OnSelectedIndexChanged="checkDemanda_SelectedIndexChanged">
                            <asp:ListItem Value="1" Text="Remitido por un promotor del Hospital"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Remitido por un promotor de la IPS"></asp:ListItem>
                            <asp:ListItem Value="0" Text="Viene por su propia Voluntad"></asp:ListItem>
                            <asp:ListItem Value="3" Text="Familias en Acción"></asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>
                <%-- <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                No</button>
                            <asp:Button ID="Button3" Text="Si" OnClick="btn_familias_Click" runat="server" type="button" class="btn btn-primary">
                                </asp:Button>
                        </div>--%>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <script type="text/javascript">
        function ShowPopupRecienNacidos() {
            $("#btn_nacidos").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_nacidos" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalNacidos">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalNacidos" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="col-lg-3 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label9" Text="Tipo Documento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNTipodocumento" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-3 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label10" Text="Documento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNDocumento" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label11" Text="Nombre y Apellido"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNNombre" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label12" Text="Entidad"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNEntidad" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label13" Text="Contrato"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNContrato" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="lbl_RNFecha" Text="Fecha de Nacimiento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNFechanacimiento"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="lbl_RNHoraNacimiento" Text="Hora de Nacimiento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNHoraNacimiento"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label1" Text="Edad Gestacional"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNgestacional"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label2" Text="Control Prenatal"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_controlprenatal" CssClass="form-control">
                                <asp:ListItem Value="0" Text="Seleccione una opción"></asp:ListItem>
                                <asp:ListItem Value="Si" Text="Si"></asp:ListItem>
                                <asp:ListItem Value="No" Text="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label3" Text="Sexo"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_RNSexo" CssClass="form-control">
                                <asp:ListItem Value="0" Text="Seleccione Sexo"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Masculino"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Femenino"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label4" Text="Peso"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNPeso"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label5" Text="Diagnostico"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNDiagnostico"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label6" Text="Diagnostico Muerte"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNDiagnosticoMuerte"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label7" Text="Fecha Muerte"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNFechamuerte" placeholder="DD/MM/YYYY"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label8" Text="Hora Muerte"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_RNHoramuerte" placeholder="HH:MM"></asp:TextBox>
                            <br />
                        </div>


                    </div>
                </div>
                <div class="modal-footer">
                    <div class="form-group">
                        <br />
                        <br />
                        <asp:Button ID="btn_registrarRecienNacido" Text="Registrar" OnClick="btn_registrarRecienNacido_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <script type="text/javascript">
        function ShowPopupDeudas() {
            $("#btn_deudas").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_deudas" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalDeuda">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalDeuda" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_mensajedeuda" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btn_deudasPendientes" Text="Aceptar" OnClick="btn_deudas_Click" class="btn btn-default" />


                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>


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
                    <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
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


    <!-- /.MODAL RIPS CONSULTAS -->

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
                        url: '<%=ResolveUrl("/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
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
                        url: '<%=ResolveUrl("/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
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
                        url: '<%=ResolveUrl("/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
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
            $("[id$=Modal_DescD3]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
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

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label17" Text="Codigo de Procedimiento"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="false" placeholder="Código" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="Modal_CodProced"></asp:TextBox>
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
                            <asp:TextBox placeholder="Código Diagnostico Principal" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodDiagP"></asp:TextBox><br />
                            <asp:TextBox runat="server" placeholder="Descripción Diagnostico Principal" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescDiagP"></asp:TextBox><br />

                        </div>
                       
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label22" Text="Diagnostico R1"></asp:Label>
                            <asp:TextBox placeholder="Código D1" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodD1"></asp:TextBox><br />
                            <asp:TextBox placeholder="Descripción D1" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescD1"></asp:TextBox><br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label14" Text="Diagnostico R2"></asp:Label>
                            <asp:TextBox placeholder="Código D2" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodD2"></asp:TextBox><br />
                            <asp:TextBox placeholder="Descripción D2" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescD2"></asp:TextBox><br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label15" Text="Diagnostico R3"></asp:Label>
                            <asp:TextBox placeholder="Código D3" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="Modal_CodD3"></asp:TextBox><br />
                            <asp:TextBox placeholder="Descripción D3" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="Modal_DescD3"></asp:TextBox>
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
                        <asp:Button ID="Button3" Text="Guardar" OnClick="Button3_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>



    <!-- /.MODAL RIPS PROCEDIMIENTOS -->

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
                        url: '<%=ResolveUrl("/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
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
            $("[id$=RPDDiagR]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
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
            $("[id$=RPDDiagC]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/NuevaFactura.aspx/BuscarDiagnostico") %>',
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
                            <asp:TextBox runat="server" ReadOnly="false" placeholder="Código Procedimiento" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="RPCodProced"></asp:TextBox>
                        </div>
                        <%--<div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label23" Text="Profesional"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_profesional2"></asp:DropDownList>

                        </div>--%>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label24" Text="Ambito"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_ambito"></asp:DropDownList>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label26" Text="Personal que atiende"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_personal"></asp:DropDownList>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label25" Text="Finalidad"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="RPFinalidad"></asp:DropDownList><br />
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label27" Text="Diagnostico Principal"></asp:Label>
                            <asp:TextBox placeholder="Código Diagnostico Principal" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="RPCodDiagP"></asp:TextBox><br />
                            <asp:TextBox runat="server" placeholder="Descripción Diagnostico Principal" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="RPDDiangP"></asp:TextBox><br />

                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label28" Text="Diagnostico Relacionado"></asp:Label>
                            <asp:TextBox placeholder="Código DC" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="RPCodDiaGR"></asp:TextBox><br />
                            <asp:TextBox placeholder="Descripción DC" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="RPDDiagR"></asp:TextBox><br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label41" Text="Diagnostico Complementario"></asp:Label>
                            <asp:TextBox placeholder="Código DR" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="RPCodDiagC"></asp:TextBox><br />
                            <asp:TextBox placeholder="Descripción DR" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="RPDDiagC"></asp:TextBox><br />
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

    <%--<div class="modal fade" id="ModalRipsProced" data-backdrop="static" data-keyboard="false">
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
                            <asp:TextBox runat="server" ReadOnly="false" placeholder="Código Procedimiento" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="RPCodProced"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label24" Text="Ambito"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="false" placeholder="Ambito" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="RPAmbito"></asp:TextBox>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label26" Text="Personal que atiende"></asp:Label>
                            <asp:TextBox runat="server" ReadOnly="false" placeholder="Digite personal" CssClass="form-control col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="RPPersonal"></asp:TextBox>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label23" Text="Finalidad"></asp:Label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="RPFinalidad"></asp:DropDownList><br />
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label25" Text="Diagnostico Principal"></asp:Label>
                            <asp:TextBox placeholder="Código Diagnostico Principal" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="RPCodDiagP"></asp:TextBox><br />
                            <asp:TextBox runat="server" placeholder="Descripción Diagnostico Principal" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="RPDDiangP"></asp:TextBox><br />

                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label27" Text="Diagnostico Relacionado"></asp:Label>
                            <asp:TextBox placeholder="Código DC" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="RPCodDiaGR"></asp:TextBox><br />
                            <asp:TextBox placeholder="Descripción DC" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="RPDDiagR"></asp:TextBox><br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label runat="server" ID="Label28" Text="Diagnostico Complementario"></asp:Label>
                            <asp:TextBox placeholder="Código DR" runat="server" CssClass="form-control col-lg-3 col-md-3 col-sm-12 col-xs-12" ID="RPCodDiagC"></asp:TextBox><br />
                            <asp:TextBox placeholder="Descripción DR" runat="server" CssClass="form-control col-lg-9 col-md-9 col-sm-12 col-xs-12" ID="RPDDiagC"></asp:TextBox><br />
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
    </div>--%>

    <script type="text/javascript">
        function ShowPopupPagarCopago() {
            $("#btn_copagopagar").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_copagopagar" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalPCopago">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalPCopago" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<asp:Button runat="server" OnClick="Unnamed_Click" type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></asp:Button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_copagoPago" Text="El usuario cancelo el copago y/o cuota moderadora? " runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" Text="Si" ID="sipagocopago" CssClass="btn btn-primary" OnClick="sipagocopago_Click" />
                    <asp:Button ID="PagaCopago" Text="No" OnClick="PagaCopago_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                   <asp:Button ID="Button1" Text="Cerrar" OnClick="Button1_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <script type="text/javascript">
        function ClosepopupCopago() {
            $('#ModalPCopago').modal('close');
        }
    </script>



                               

    <!-- jQuery -->
    <!-- Bootstrap Core JavaScript -->

     <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>


</asp:Content>
