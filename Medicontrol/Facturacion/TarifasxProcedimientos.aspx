<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="TarifasxProcedimientos.aspx.cs" Inherits="Medicontrol.Facturacion.WebForm11" %>

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
            $("[id$=txt_proced]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/TarifasxProcedimientos.aspx/BuscarProcedimientos") %>',
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


    <h3>Tarifas por Procedimiento</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_entida" Text="Entidad"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_entidad" AutoPostBack="true" OnSelectedIndexChanged="ddl_entidad_SelectedIndexChanged" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_fechainc" Text="Contrato"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_contrato" Enabled="false" CssClass="form-control">
            </asp:DropDownList>
            <br />
        </div>

    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Panel runat="server" ID="panelCodigo" DefaultButton="btn_buscarCodigo">
                <asp:TextBox runat="server" ID="txt_codProced" placeholder="Buscar por Código" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" CssClass="btn btn-link" ID="btn_buscarCodigo" OnClick="btn_buscarCodigo_Click" />
                <br />
            </asp:Panel>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Panel runat="server" ID="panel2" DefaultButton="btn_buscarNombre">
                <asp:TextBox runat="server" ID="txt_proced" placeholder="Buscar por Nombre" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" CssClass="btn btn-link" ID="btn_buscarNombre" OnClick="btn_buscarNombre_Click" />
                <br />
            </asp:Panel>
        </div>

    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <asp:TextBox runat="server" ID="txt_desproced" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <br />
        </div>

    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label1" Text="Valor 100%"></asp:Label>
            <asp:TextBox runat="server" ID="txt_valorProced" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label2" Text="Valor Entidad"></asp:Label>
            <hr />
            <asp:Label runat="server" ID="Label3" Text="Primer Nivel"></asp:Label>
            <asp:TextBox runat="server" ID="Entidadnivel1" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <hr />
            <asp:Label runat="server" ID="Label4" Text="Segundo Nivel"></asp:Label>
            <asp:TextBox runat="server" ID="Entidadnivel2" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <hr />
            <asp:Label runat="server" ID="Label5" Text="Tercer Nivel"></asp:Label>
            <asp:TextBox runat="server" ID="Entidadnivel3" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label6" Text="Valor Copago"></asp:Label>
            <hr />
            <asp:Label runat="server" ID="Label7" Text="Primer Nivel"></asp:Label>
            <asp:TextBox runat="server" ID="copagonivel1" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <hr />
            <asp:Label runat="server" ID="Label8" Text="Segundo Nivel"></asp:Label>
            <asp:TextBox runat="server" ID="copagonivel2" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <hr />
            <asp:Label runat="server" ID="Label9" Text="Tercer Nivel"></asp:Label>
            <asp:TextBox runat="server" ID="copagonivel3" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <br />
        </div>

    </div>

</asp:Content>
