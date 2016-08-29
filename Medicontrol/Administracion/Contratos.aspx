<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="Contratos.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web118" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id$=txt_municipio]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Administracion/Contratos.aspx/Municipios") %>',
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



    <h3>Contratos</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="form-group">

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            
            <div class="form-group">
            <asp:Label runat="server" ID="lbl_entidades" Text="Entidades"></asp:Label>
            
                <asp:DropDownList runat="server" ID="ddl_entidades" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_entidades_SelectedIndexChanged">
                    <asp:ListItem Text="Seleccione una Entidad" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="2"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:GridView runat="server" ID="gridContratos" Visible="true" Enabled="true" OnRowDataBound="gridContratos_RowDataBound" OnSelectedIndexChanged="gridContratos_SelectedIndexChanged" CssClass="table table-bordered bs-table" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
                <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
                <script type="text/javascript">
                    $(function () {
                        $("[id*=gridContratos] td").hover(function () {
                            $("td", $(this).closest("tr")).addClass("hover_row");
                        }, function () {
                            $("td", $(this).closest("tr")).removeClass("hover_row");
                        });
                    });
                </script>
            </div>
            <asp:Button Visible="false" runat="server" ID="btn_nuevo" Text="Nuevo Contrato" CssClass="btn btn-primary" OnClick="btn_nuevo_Click" />
            <asp:Button Visible="false" runat="server" ID="btn_registrar" Text="Registrar" CssClass="btn btn-primary" OnClick="btn_registrar_Click" />
            <asp:Button Visible="false" runat="server" ID="btn_modificar" Text="Modificar" CssClass="btn btn-primary" OnClick="btn_modificar_Click" />
            
            <br /><br />
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_codigo" Text="Código Contrato"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigo"></asp:TextBox><br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_razonsocial" Text="Número Contrato"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_numcontrato"></asp:TextBox><br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_descripcion" Text="Descripción"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_descripcion"></asp:TextBox><br />
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                     <asp:UpdatePanel ID="UpdatePanel3" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label runat="server" ID="lbl_tipocontrato" Text="Tipo de Contrato" Enabled="false"></asp:Label>
                    <asp:DropDownList Enabled="true" runat="server" ID="ddl_tipocontrato" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_tipocontrato_SelectedIndexChanged">
                        <asp:ListItem Text="Seleccione un tipo de contrato" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Evento" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Capitado" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_tipocontrato" ReadOnly="true" Visible="false"></asp:TextBox><br />
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_tipocontrato" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
                    </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_capita" Text="% Capita"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_capita"></asp:TextBox><br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_afiliados" Text="Numero de Afiliados"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_afiliados"></asp:TextBox><br />
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                <asp:Label runat="server" ID="lbl_valormes" Text="Valor Mes"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_valormes" Visible="false"></asp:TextBox><br />
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_valormes1"></asp:TextBox><br />
                
                    </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label runat="server" ID="lbl_regimen" Text="Régimen"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_regimen" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_regimen_SelectedIndexChanged">
                        <asp:ListItem Text="Seleccione el Régimen" Value="0"></asp:ListItem>

                    </asp:DropDownList>

                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_regimen" ReadOnly="true" Visible="false"></asp:TextBox>
                    <br />
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_regimen" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
                    </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
            <asp:Label runat="server" ID="lbl_estado" Text="Estado"></asp:Label>
            
                    <asp:DropDownList runat="server" ID="ddl_estado" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_estado_SelectedIndexChanged">
                        <asp:ListItem Text="Seleccione el Estado" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactivo" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_estado" ReadOnly="true" Visible="false"></asp:TextBox>
                    <br />
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_estado" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
                    </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_municipio" Text="Municipio"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_municipio" ReadOnly="false"></asp:TextBox><br />
                    </div>

            </div>
            <br />
                     
                        <div class="form-group">
                 
            
            <asp:Label runat="server" ID="lbl_inicial" Text="Fecha Inicial"></asp:Label>
            <asp:TextBox runat="server" ID="txt_inicial" CssClass="form-control birthday"></asp:TextBox>
                    </div>
                                                    <div class="form-group">

            <asp:Label runat="server" ID="lbl_final" Text="Fecha Final"></asp:Label>
            <asp:TextBox runat="server" ID="txt_final" CssClass="form-control birthday"></asp:TextBox>
           </div>
               
                    </div>
      </div>              
    <br />
    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

</asp:Content>
