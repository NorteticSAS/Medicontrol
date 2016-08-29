<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="PlanesContratos.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web119" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
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

    <h3>Planes por Contrato</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"
        UpdateMode="Conditional">
        <ContentTemplate>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Label runat="server" ID="lbl_entidades" Text="Entidades"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_entidades" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_entidades_SelectedIndexChanged">
                        <asp:ListItem Text="Seleccione una Entidad" Value="0"></asp:ListItem>
                        <asp:ListItem Text="entidad1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="entidad2" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Label runat="server" ID="lbl_contrato" Text="Contrato"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_contrato" CssClass="form-control" Enabled="false" OnSelectedIndexChanged="ddl_contrato_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Seleccione un Contrato" Value="0"></asp:ListItem>
                        <asp:ListItem Text="contrato1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="contrato2" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
            </div>

            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <asp:GridView runat="server" ID="gridContratos" Visible="true" Enabled="true" OnRowDataBound="gridContratos_RowDataBound" OnSelectedIndexChanged="gridContratos_SelectedIndexChanged" CssClass="table table-bordered bs-table" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" />
                            <asp:BoundField DataField="CodigoPlan" HeaderText="Código Plan" />
                            <asp:BoundField DataField="NombrePlan" HeaderText="Descripción Plan" />
                            <asp:BoundField DataField="CodigoTarifario" HeaderText="Código Tarifario" />
                            <asp:BoundField DataField="DescripcionTarifario" HeaderText="Descripción Tarifario" />
                            <asp:BoundField DataField="Porcentaje" HeaderText="% Tarifario" />
                            <asp:BoundField DataField="Capita" HeaderText="Copago" />
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
            </div>

            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Label runat="server" ID="lbl_tarifarios" Text="Tarifarios"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_tarifarios" CssClass="form-control" Enabled="false">
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Label runat="server" ID="lbl_planes" Text="Planes"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_planes" CssClass="form-control" Enabled="false">
                    </asp:DropDownList>
                    <br />
                </div>
            </div>

            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Label runat="server" ID="lbl_porcentaje" Text="% Tarifario"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_tarifario"></asp:TextBox>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Label runat="server" ID="lbl_copago" Text="Cobra Copago"></asp:Label>
                    <br />
                    <asp:CheckBox runat="server" ID="check_copago" Text="Si" />
                    <br />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" ID="lbl_btn" Text="" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-12"></asp:Label>
                <div class="col-sm-12 col-xs-12 col-md-12 col-lg-12">
                    <asp:Button runat="server" ID="btn_registrar" Text="Guardar" Visible="false" CssClass="btn btn-primary" OnClick="btn_registrar_Click" />
                    <asp:Button runat="server" ID="btn_eliminar" Text="Eliminar" Visible="false" CssClass="btn btn-primary" OnClientClick="return confirm('¿Desea Eliminar esta información?');" OnClick="btn_eliminar_Click" />
                    <asp:Button runat="server" ID="btn_modificar" Text="Modificar" Visible="false" CssClass="btn btn-primary" OnClick="btn_modificar_Click" />
                    <br />
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddl_entidades" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <br />
</asp:Content>
