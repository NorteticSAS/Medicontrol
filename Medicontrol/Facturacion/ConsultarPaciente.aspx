<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="ConsultarPaciente.aspx.cs" Inherits="Medicontrol.Facturacion.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="p" runat="server" DefaultButton="btn_buscarPaciente">

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
                             $("[id$=txt_nombre]").autocomplete({
                                 source: function (request, response) {
                                     $.ajax({
                                         url: '<%=ResolveUrl("/Facturacion/ModificarPaciente.aspx/BuscarPaciente") %>',
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
             <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12"></div>
    <hr />
    <div class="btn-group btn-group-justified" role="group" aria-label="...">
        <div class="btn-group" role="group">
            <asp:Button PostBackUrl="~/Facturacion/NuevoPaciente.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button BackColor="#999999" PostBackUrl="~/Facturacion/ConsultarPaciente.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button  Enabled="false" runat="server" OnClick="btn_Actualizar_Click" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
        </div>
        <div class="btn-group" role="group">
            <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
        </div>
    </div>

    <hr />
    <h3>Modificar Datos del Paciente</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

    <div class="form-group">
            
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_buscar" Text="Digite el Documento del paciente"></asp:Label>
                <asp:Panel runat="server" ID="panel1" DefaultButton="btn_buscarPaciente">
                    <asp:TextBox placeholder="Buscar por Cédula" runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
                    <br />
                    <asp:Button runat="server" ID="btn_buscarPaciente" Text="Buscar" CssClass="btn btn-primary" OnClick="btn_buscarPaciente_Click" />
                </asp:Panel>
                <br />
            </div>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">
                <asp:Panel runat="server" ID="panel2" DefaultButton="btn_buscarNombre">
                    <br />
                    <asp:TextBox placeholder="Buscar por Nombre" runat="server" CssClass="form-control" ID="txt_nombre"></asp:TextBox>
                    <br />
                    <asp:Button runat="server" ID="btn_buscarNombre" Text="Buscar" CssClass="btn btn-primary" OnClick="btn_buscarNombre_Click" />
                </asp:Panel>
                <br />
            </div>
        </div>
    <br />
<br />
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_documento" Text="Documento"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_documento" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_tipodoc" Text="Tipo de Documento"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_tipodoc" CssClass="form-control">
               
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_numhistoria" Text="Número Historia"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numhistoria" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_numcarnet" Text="Número de Carnet"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numcarnet"></asp:TextBox>
            <br />
        </div>
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
        <asp:UpdatePanel ID="UpdatePanel5" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_tipousuario" Text="Tipo de Usuario"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_tipousuario" CssClass="form-control" OnSelectedIndexChanged="ddl_tipousuario_SelectedIndexChanged" AutoPostBack="true">
               
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_tipoafiliado" Text="Tipo de Afiliado"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_tipoafiliado" Enabled="true" CssClass="form-control">
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
            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_fechanaci"></asp:TextBox>
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
            <asp:Label runat="server" ID="lbl_municipio" Text="Municipio"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_municipio" Enabled="true" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_zona" Text="Zona Residencial"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_zona" CssClass="form-control">
                <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
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
         <asp:UpdatePanel ID="UpdatePanel1" runat="server"
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
            <asp:DropDownList runat="server" ID="ddl_contrato" Enabled="false" CssClass="form-control">
                
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
         <asp:UpdatePanel ID="UpdatePanel3" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <br />
            <div class="alert alert-danger">
                <asp:Label runat="server" ID="lbl_mensajecontrato" Text=""></asp:Label>
            </div>
            <asp:GridView runat="server" ID="gridPacienteContrato" Visible="false" Enabled="false" CssClass="table table-bordered bs-table" AutoGenerateColumns="false" OnRowDataBound="gridPacienteContrato_RowDataBound" OnSelectedIndexChanged="gridPacienteContrato_SelectedIndexChanged">
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
            <asp:Button Enabled="true" runat="server" ID="btn_agregar" CssClass="btn btn-primary" Text="Agregar" OnClick="btn_agregar_Click"/>
            <asp:Button Enabled="true" runat="server" ID="btn_eliminarcontrato" CssClass="btn btn-primary" Text="Eliminar" OnClick="btn_eliminarcontrato_Click"/>
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
            <asp:Button Enabled="true" runat="server" ID="btn_guardar" CssClass="btn btn-primary" Text="Modificar Paciente" OnClick="btn_guardar_Click"/>
            <br />
        </div>
    </div>
                    </asp:Panel>
</asp:Content>
