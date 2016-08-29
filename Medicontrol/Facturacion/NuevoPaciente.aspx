<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="NuevoPaciente.aspx.cs" Inherits="Medicontrol.Facturacion.WebForm1" %>
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
                function ValidateDate(sender, args) {
                    var dateString = document.getElementById(sender.controltovalidate).value;
                    var regex = /(((0|1)[1-9]|2[0-9]|3[0-1])\/(0[1-9]|1[1-2])\/((19|20)\d\d))$/;
                    if (regex.test(dateString)) {
                        var parts = dateString.split("/");
                        var dt = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
                        args.IsValid = (dt.getDate() == parts[0] && dt.getMonth() + 1 == parts[1] && dt.getFullYear() == parts[2]);
                    } else {
                        args.IsValid = false;
                    }
                }
    </script>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12"></div>
    <hr />
    <div class="btn-group btn-group-justified" role="group" aria-label="...">
        <div class="btn-group" role="group">
            <asp:Button BackColor="#999999" PostBackUrl="~/Facturacion/NuevoPaciente.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button PostBackUrl="~/Facturacion/ModificarPaciente.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
        </div>
        <%--<div class="btn-group" role="group">
            <asp:Button Enabled="true" runat="server" PostBackUrl="~/Facturacion/ModificarPaciente.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
        </div>--%>
       <%-- <div class="btn-group" role="group">
            <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
        </div>--%>
    </div>

    <hr />
    <h3>Regístro de Nuevo Paciente</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

    <div class="form-group">
         <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_documento" Text="Documento"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_documento"></asp:TextBox>
            <br />
        </div>
       
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_tipodoc" Text="Tipo de Documento"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_tipodoc" CssClass="form-control" OnSelectedIndexChanged="ddl_tipodoc_SelectedIndexChanged" AutoPostBack="true">
               
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_numhistoria" Text="Número Historia"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" ID="txt_numhistoria"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_numcarnet" Text="Número de Carnet"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numcarnet"></asp:TextBox>
            <br />
        </div>
                     </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_tipodoc" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_nombre1" Text="Primer Nombre"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre1"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_nombre2" Text="Segundo Nombre"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre2"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_apellido1" Text="Primer Apellido"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido1"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_apellido2" Text="Segundo Apellido"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido2"></asp:TextBox>
            <br />
        </div>
    </div>

    <div class="form-group">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_tipousuario" Text="Tipo de Usuario"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_tipousuario" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_tipousuario_SelectedIndexChanged">
           
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_tipoafiliado" Text="Tipo de Afiliado"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_tipoafiliado" Enabled="false" CssClass="form-control">
               
            </asp:DropDownList>
            <br />
        </div>
                    </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_tipousuario" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_sexo" Text="Sexo"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_sexo" CssClass="form-control">
                <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                <asp:ListItem Text="Femenino" Value="1"></asp:ListItem>
                <asp:ListItem Text="Masculino" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_Fechanaci" Text="Fecha de Nacimiento"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechanaci"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator2" runat="server" OnServerValidate="ValidateDate"
            ControlToValidate="txt_fechanaci" ErrorMessage="Invalid Date." ValidationGroup="Group3" />
            <asp:TextBox runat="server" CssClass="form-control" ID="umEdad" Visible="false"></asp:TextBox>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_edad" Visible="false"></asp:TextBox>
            <br />
        </div>
    </div>
    
    <div class="form-group">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_departamento" Text="Departamento"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_departamento" CssClass="form-control" OnSelectedIndexChanged="ddl_departamento_SelectedIndexChanged" AutoPostBack="true">
               
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_municipio"  Text="Municipio"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_municipio" Enabled="false" CssClass="form-control">
                
            </asp:DropDownList>
            <br />
        </div>
        
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_zona" Text="Zona Residencial"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_zona" CssClass="form-control">
                <asp:ListItem Text="Seleccione Zona" Value="0"></asp:ListItem>
                <asp:ListItem Text="Rural" Value="1"></asp:ListItem>
                <asp:ListItem Text="Urbano" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_estrato" Text="Estrato"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_estrato" CssClass="form-control">
                
            </asp:DropDownList>
            <br />
        </div>
        </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_departamento" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_direccion" Text="Direccion"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_direccion"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_telefono" Text="Teléfono"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_telefono"></asp:TextBox>
            <br />
        </div>
    </div>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
        <asp:Label runat="server" ID="lbl_estado" Text="Estado"></asp:Label>
        <asp:DropDownList runat="server" ID="ddl_estado" CssClass="form-control">
            <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
            <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
            <asp:ListItem Text="Inactivo" Value="2"></asp:ListItem>
        </asp:DropDownList>
        <br />
    </div>

    <div class="form-group">
         <asp:UpdatePanel ID="UpdatePanel4" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_eapb" Text="EAPB"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_entidad" CssClass="form-control" OnSelectedIndexChanged="ddl_entidad_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_contrato" Text="Contrato"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_contrato" CssClass="form-control" Enabled="false">
                
            </asp:DropDownList>
            <br />

        </div>
                    </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_entidad" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
    </div>

    <div class="form-group">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-9">

            <br />
            <div class="alert alert-danger">
                <asp:Label runat="server" ID="lbl_mensajecontrato" Text=""></asp:Label>
            </div>
            <asp:GridView runat="server" ID="gridPacienteContrato" Visible="true" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridPacienteContrato_RowDataBound" OnSelectedIndexChanged="gridPacienteContrato_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="CodEntidad" HeaderText="Código Entidad" />
                    <asp:BoundField DataField="NombreEntidad" HeaderText="Entidad" />
                    <asp:BoundField DataField="CodContrato" HeaderText="Código Contrato" />
                    <asp:BoundField DataField="NombreContrato" HeaderText="Contrato" />
                    <asp:BoundField DataField="Documento" HeaderText="Documento" />
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
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Button Enabled="true" runat="server" ID="btn_agregar" CssClass="btn btn-primary" Text="Agregar" OnClick="btn_agregar_Click" Visible="true"/>
            <asp:Button Enabled="true" runat="server" ID="btn_eliminarcontrato" CssClass="btn btn-primary" Text="Eliminar" OnClick="btn_eliminarcontrato_Click" Visible="true"/>
            <br />
        </div>
                    </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gridPacienteContrato" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
    </div>
   
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Button Enabled="true" runat="server" ID="btn_guardar" CssClass="btn btn-primary" Text="Guardar" OnClick="btn_guardar_Click" Visible="true"/>
            <br />
        </div>
    </div>
    <script type="text/javascript">
        function ShowPopupOpcionPacientes() {
            $("#btn_opcion").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_opcion" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalOpcion">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalOpcion" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                     <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_mensajeopcion" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="btn_Admisiones" Text="ir a Admisiones" OnClick="btn_Admisiones_Click" class="btn btn-default" />
                    <asp:Button runat="server" ID="btn_Factura" Text="ir a facturacion" OnClick="btn_Factura_Click" class="btn btn-default" />
                    <asp:Button runat="server" ID="btn_citas" Text="Asignar Cita" OnClick="btn_citas_Click" class="btn btn-default" />

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
        <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

</asp:Content>
