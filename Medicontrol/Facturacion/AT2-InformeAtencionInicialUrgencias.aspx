<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="AT2-InformeAtencionInicialUrgencias.aspx.cs" Inherits="Medicontrol.Facturacion.WebForm6" EnableEventValidation="false" %>
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
    <h4>Informe de la Atención Inicial de Urgencias - Res. 3047 de 2008. Anexo técnico No. 2</h4>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
    <asp:Label runat="server" ID="CodigoSesion" Text="" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="FechaNacimientoPac" Visible="false"></asp:Label>
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
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label1" Text="Documento de Identidad"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_cedula" ReadOnly="true"></asp:TextBox>
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
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_causa" Text="Tipo de Documento"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_tipodoc" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
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
                
            </asp:DropDownList>            <br />
        </div>
    </div>
    <hr />
    
    <hr />
     <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <h3>Información de la Atención</h3><br />
            <asp:Label runat="server" ID="Label2" Text="Origen de la Atención"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_causas" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <h3 style="visibility:hidden">hola</h3><br />
            <asp:Label runat="server" ID="Label4" Text="Clasificación Triage"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_triage" CssClass="form-control">
                <asp:ListItem Value="0" Text="Seleccione"></asp:ListItem>
                <asp:ListItem Value="1" Text="1. Rojo"></asp:ListItem>
                <asp:ListItem Value="2" Text="2. Amarillo"></asp:ListItem>
                <asp:ListItem Value="3" Text="3. Verde"></asp:ListItem>
            </asp:DropDownList>            <br />
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
