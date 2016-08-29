<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="OrdenSalida.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web15" %>

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
    <asp:Label runat="server" ID="CodigoTipoAdmision" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoEntidad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodigoTipoContrato" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="fechaNacimiento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Edad" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Sexopaciente" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_FechaAdmision" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TipoDocumento" Visible="false"></asp:Label>
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <h3>Ordenes de Salida </h3>
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
            <asp:Button runat="server" ID="btn_buscarAdmision" OnClick="btn_buscarAdmision_Click1" Text="Buscar" CssClass="btn btn-primary" />
        </asp:Panel>
    </div>
    <br />
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_documento" Text="Documento"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_documento" ReadOnly="true" />
            <br />
        </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_fecha" Text="Fecha"></asp:Label>
            <asp:TextBox runat="server" placeholder="Seleccione fecha de salida" CssClass="form-control birthday" ID="txt_fecha" ReadOnly="false" />
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_hora" Text="Hora"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_hora" ReadOnly="true" />
            <br />
        </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
            <asp:Label runat="server" ID="lbl_num" Text="No."></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numAdmision" ReadOnly="true" />
            <br />
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_pacient" Text="Paciente"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre" ReadOnly="true" />
            <br />
        </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_tipoadm" Text=" Tipo Admisión"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_tipoadmision" ReadOnly="true" />
            <br />
        </div>
    </div>



    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_entidad" Text="Entidad"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_entidad" ReadOnly="true" />
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_contrato" Text="Contrato"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_contrato" ReadOnly="true" />
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_admi" Text="Fecha Admisión"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_admision" ReadOnly="true" />
            <br />
        </div>
    </div>

    <div class="form-group">
        <asp:Panel runat="server" ID="panel1" DefaultButton="btn_consultar1">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">

                <div class="alert alert-danger">
                    <asp:Label runat="server" ID="ResultadoDx" Text=""></asp:Label><br />
                </div>
                <asp:Label runat="server" ID="lbl_cie101" Text="Diagnóstico la salida"></asp:Label>
                <asp:TextBox placeholder="Buscar por código" runat="server" CssClass="form-control" ID="txt_cie101"></asp:TextBox>
                <asp:Button runat="server" ID="btn_consultar1" OnClick="btn_consultar1_Click" Text="Buscar" CssClass="btn btn-primary" />
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <br />
                <br />
                <br />
                <br />
                <asp:Label runat="server" ID="lbl_diagnostico1" Text="Nombre de Diagnóstico"></asp:Label>
                <asp:TextBox placeholder="Buscar por Nombre" runat="server" CssClass="form-control" ID="txt_diagnostico1" ReadOnly="false"></asp:TextBox>
                <br />
                <br />
            </div>
        </asp:Panel>
    </div>

    <div class="form-group">
        <asp:Panel runat="server" ID="panel2" DefaultButton="btn_consultar2">

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_cie102" Text="Diagnóstico R1 la salida"></asp:Label>
                <asp:TextBox placeholder="Buscar por código" runat="server" CssClass="form-control" ID="txt_cie102"></asp:TextBox>
                <asp:Button runat="server" ID="btn_consultar2" OnClick="btn_consultar2_Click" Text="Buscar" CssClass="btn btn-primary" />
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_diagnostico2" Text="Nombre Diagnóstico Relacionado"></asp:Label>
                <asp:TextBox placeholder="Buscar por Nombre" runat="server" CssClass="form-control" ID="txt_diagnostico2" ReadOnly="false"></asp:TextBox>
                <br />
                <br />
            </div>
        </asp:Panel>
    </div>
    <div class="form-group">
        <asp:Panel runat="server" ID="panel3" DefaultButton="btn_consultar3">

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_cie103" Text="Diagnóstico R2 la salida"></asp:Label>
                <asp:TextBox placeholder="Buscar por código" runat="server" CssClass="form-control" ID="txt_cie103"></asp:TextBox>
                <asp:Button runat="server" ID="btn_consultar3" OnClick="btn_consultar3_Click" Text="Buscar" CssClass="btn btn-primary" />
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_diagnostico3" Text="Nombre Diagnóstico Relacionado 2"></asp:Label>
                <asp:TextBox placeholder="Buscar por Nombre" runat="server" CssClass="form-control" ID="txt_diagnostico3" ReadOnly="false"></asp:TextBox>
                <br />
                <br />
            </div>
        </asp:Panel>
    </div>
    <div class="form-group">
        <asp:Panel runat="server" ID="panel4" DefaultButton="Button1">

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_cie104" Text="Diagnóstico R3 la salida"></asp:Label>
                <asp:TextBox runat="server" placeholder="Buscar por código" CssClass="form-control" ID="txt_cie104"></asp:TextBox>
                <asp:Button runat="server" ID="Button1" OnClick="Button1_Click" Text="Buscar" CssClass="btn btn-primary" />
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_diagnostico4" Text="Nombre Diagnóstico Relacionado "></asp:Label>
                <asp:TextBox runat="server" placeholder="Buscar por Nombre" CssClass="form-control" ID="txt_diagnostico4" ReadOnly="false"></asp:TextBox>
                <br />
                <br />
            </div>
        </asp:Panel>
    </div>
    <div class="form-group">
        <asp:Panel runat="server" ID="panel5" DefaultButton="Button2">

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_cie105" Text="Diagnóstico complicación"></asp:Label>
                <asp:TextBox runat="server" placeholder="Buscar por código" CssClass="form-control" ID="txt_cie105"></asp:TextBox>
                <asp:Button runat="server" ID="Button2" OnClick="Button2_Click" Text="Buscar" CssClass="btn btn-primary" />
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_diagnostico5" Text="Nombre Diagnóstico Relacionado "></asp:Label>
                <asp:TextBox placeholder="Buscar por Nombre" runat="server" CssClass="form-control" ID="txt_diagnostico5" ReadOnly="false"></asp:TextBox>
                <br />
                <br />
            </div>
        </asp:Panel>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_destinosalida" Text="Destino del usuario a la salida"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_destinosalida" CssClass="form-control">
                <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                <asp:ListItem Text="Alta de Urgencias" Value="1"></asp:ListItem>
                <asp:ListItem Text="Remisión a otro nivel" Value="2"></asp:ListItem>
                <asp:ListItem Text="Hospitalización" Value="3"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_estado" Text="Estado a la salida"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_estado" CssClass="form-control">
                <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                <asp:ListItem Text="Vivo" Value="1"></asp:ListItem>
                <asp:ListItem Text="Muerto" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
    </div>


    <div class="form-group">
        <asp:Panel runat="server" ID="panel6" DefaultButton="Button3">

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_cie106" Text="Causa básica de muerte"></asp:Label>
                <asp:TextBox runat="server" placeholder="Buscar por código" CssClass="form-control" ID="txt_cie106"></asp:TextBox>
                <asp:Button runat="server" ID="Button3" OnClick="Button3_Click" Text="Buscar" CssClass="btn btn-primary" />
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_diagnostico6" Text="Nombre Diagnóstico Relacionado "></asp:Label>
                <asp:TextBox placeholder="Buscar por Nombre" runat="server" CssClass="form-control" ID="txt_diagnostico6" ReadOnly="false"></asp:TextBox>
                <br />
                <br />
            </div>
        </asp:Panel>
    </div>
    <script type="text/javascript">
        $(function () {
            $("[id$=txt_diagnostico1]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/OrdenSalida.aspx/BuscarDiagnostico") %>',
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
            $("[id$=txt_diagnostico2]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/OrdenSalida.aspx/BuscarDiagnostico") %>',
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
            $("[id$=txt_diagnostico3]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/OrdenSalida.aspx/BuscarDiagnostico") %>',
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
            $("[id$=txt_diagnostico4]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/OrdenSalida.aspx/BuscarDiagnostico") %>',
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
            $("[id$=txt_diagnostico5]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/OrdenSalida.aspx/BuscarDiagnostico") %>',
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
            $("[id$=txt_diagnostico6]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Facturacion/OrdenSalida.aspx/BuscarDiagnostico") %>',
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

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_recien" Text="Recién nacido"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_recien" CssClass="form-control">
                <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                <asp:ListItem Text="No" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <br />
            <asp:Button runat="server" ID="Button4" Text="Guardar" OnClick="Button4_Click" CssClass="btn btn-primary" />
            <br />
        </div>

    </div>


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
                            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_RNFechanacimiento"></asp:TextBox>
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
                        <asp:Button runat="server" ID="cerrarRECIEN" Text="Cerrar" CssClass="btn btn-primary" OnClick="cerrarRECIEN_Click" />
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <script type="text/javascript">
        function ShowPopupLiquidar() {
            $("#btn_liquidar").click();
        }
    </script>
    <button type="button" style="display: none;" id="btn_liquidar" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#LiquidarModal">
        Launch demo modal
    </button>

    <div class="modal fade" id="LiquidarModal" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Sistema de Facturación</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_liquidar" runat="server" />
                    <br />
                    <br />

                </div>
                <div class="modal-footer">
                    <div class="form-group">
                        <br />
                        <br />
                        <asp:Button ID="btn_aCeptar" Text="Si" OnClick="btn_aCeptar_Click" runat="server" type="button" class="btn btn-primary"></asp:Button>
                        <asp:Button runat="server" ID="LiquidarNo" Text="No" CssClass="btn btn-primary" OnClick="LiquidarNo_Click" />

                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

</asp:Content>
