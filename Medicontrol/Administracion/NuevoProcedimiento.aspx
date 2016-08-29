<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="NuevoProcedimiento.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web19" %>

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
                <asp:Panel ID="Panel2" runat="server" DefaultButton="btn_registrar">

    <h3>Administración de Procedimientos</h3>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <hr />
        <div class="btn-group btn-group-justified" role="group" aria-label="...">
            <div class="btn-group" role="group">
                <asp:Button BackColor="#999999" PostBackUrl="~/Administracion/NuevoProcedimiento.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button PostBackUrl="~/Administracion/BuscarProcedimiento.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Consultar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="false" runat="server" PostBackUrl="#" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
            </div>
        </div>
        <hr />
        <br />
        <h3>Crear Procedimiento</h3>
        <br />
        <div class="alert alert-danger">
            <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
        </div>

        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_codigo" Text="Codigo Procedimiento"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigo"></asp:TextBox>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_descripcion" Text="Descripción"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_descripcion"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_tarifarios" Text="Tarifarios"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_tarifarios" CssClass="form-control"></asp:DropDownList>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_grupoqx" Text="Grupo Qx"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_grupoQx" CssClass="form-control">
                    <asp:ListItem Value="Seleccione un Grupo" Text="Seleccione un Grupo"></asp:ListItem>
                    <asp:ListItem Value="0" Text="No Aplica"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Grupo 02"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Grupo 03"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Grupo 04"></asp:ListItem>
                    <asp:ListItem Value="5" Text="Grupo 05"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Grupo 06"></asp:ListItem>
                    <asp:ListItem Value="7" Text="Grupo 07"></asp:ListItem>
                    <asp:ListItem Value="8" Text="Grupo 08"></asp:ListItem>
                    <asp:ListItem Value="9" Text="Grupo 09"></asp:ListItem>
                    <asp:ListItem Value="10" Text="Grupo 10"></asp:ListItem>
                    <asp:ListItem Value="11" Text="Grupo 11"></asp:ListItem>
                    <asp:ListItem Value="12" Text="Grupo 12"></asp:ListItem>
                    <asp:ListItem Value="13" Text="Grupo 13"></asp:ListItem>
                    <asp:ListItem Value="20" Text="Grupo especial 20"></asp:ListItem>
                    <asp:ListItem Value="21" Text="Grupo especial 21"></asp:ListItem>
                    <asp:ListItem Value="22" Text="Grupo especial 22"></asp:ListItem>
                    <asp:ListItem Value="23" Text="Grupo especial 23"></asp:ListItem>
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
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_rips" Text="RIPS"></asp:Label>
                <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddl_rips_SelectedIndexChanged" runat="server" ID="ddl_rips" CssClass="form-control"></asp:DropDownList>
                <br />
            </div>
           
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                <asp:Label runat="server" ID="lbl_finalidad" Text="Finalidad"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_finalidad" CssClass="form-control"></asp:DropDownList>
                <br />
            </div>
                       </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_rips" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        </div>

        <div class="form-group">
             <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                <asp:Label runat="server" ID="lbl_codcups" Text="Código CUPS"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigocups"></asp:TextBox>
                <br />
            </div>
           
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                <asp:Label runat="server" ID="lbl_tiposervicio" Text="Tipo Servicio"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_tiposervicio" CssClass="form-control">
                    <asp:ListItem Value="Seleccione tipo Servicio" Text="Seleccione tipo Servicio"></asp:ListItem>
                    <asp:ListItem Value="0" Text="No Aplica"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Materiales e Insumos"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Traslados"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Estancias"></asp:ListItem>
                    <asp:ListItem Value="4" Text="Honorarios"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                <asp:Label runat="server" ID="lbl_estado" Text="Estado"></asp:Label>
                <asp:DropDownList runat="server" ID="ddl_estado" CssClass="form-control">
                    <asp:ListItem Text="Selesccione Estado" Value="Seleccione"></asp:ListItem>
                    <asp:ListItem Text="Activo" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="1"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </div>
        </div>

        <br />
        <hr />
        <br />
        <div class="form-group">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">

            <div class="form-group">
                <asp:Label runat="server" ID="lbl_tarifas" Text="Tarifas Actuales" CssClass="control-label"></asp:Label>
                <br />
            </div>
           
           
                         
                <asp:GridView runat="server" ID="gridTarifas" Visible="false" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="gridTarifas_RowDataBound" OnSelectedIndexChanged="gridTarifas_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="CodPlan" HeaderText="Cod Plan" />
                        <asp:BoundField DataField="DescPlan" HeaderText="Desc Plan" />
                        <asp:BoundField DataField="Puntos" HeaderText="SMLDV" />
                        <asp:BoundField DataField="Valor" HeaderText="Valor" />

                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
                <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
                <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
                <script type="text/javascript">
                    $(function () {
                        $("[id*=gridTarifas] td").hover(function () {
                            $("td", $(this).closest("tr")).addClass("hover_row");
                        }, function () {
                            $("td", $(this).closest("tr")).removeClass("hover_row");
                        });
                    });
                </script>
                   
                <br />
        </div>
        <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
            <div class="form-group">
                <br />
                <div class="alert alert-danger">
                    <asp:Label runat="server" ID="lbl_resultadoTarifas" Text=""></asp:Label>
                </div>
                <br />

                <asp:Label runat="server" ID="Label2" Text="Planes"></asp:Label>

                 <asp:UpdatePanel ID="UpdatePanel3" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
                <asp:DropDownList runat="server" ID="ddl_planes" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_planes_SelectedIndexChanged"></asp:DropDownList><br />
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombreplan" ReadOnly="true"></asp:TextBox><br />
                    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_planes" EventName="SelectedIndexChanged" />
                </Triggers>
                     </asp:UpdatePanel>
                <asp:Label runat="server" ID="Label1" Text="Puntos"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_puntos"></asp:TextBox><br />
                <asp:Label runat="server" ID="Label3" Text="Valor"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control col-lg-4" ID="txt_valor"></asp:TextBox>


                <br />
                <br />
                <br />
                <br />
                <div class="form-group">
                    <asp:Button runat="server" ID="btn_nuevatarifa" Text="Agregar" OnClick="btn_nuevatarifa_Click" CssClass="btn btn-primary" />
                    <asp:Button runat="server" ID="btn_acttarifa" Text="Actualizar" CssClass="btn btn-primary" OnClick="btn_acttarifa_Click" />
                    <asp:Button runat="server" ID="btn_elimtarifa" Text="Eliminar" CssClass="btn btn-primary" OnClick="btn_elimtarifa_Click" />
                    <br />
                </div>
                </>
            </div>
        </div>
        </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gridTarifas" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
                    </div>
                    

        <hr />
        <div class="form-group">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
            <div class="form-group">
                <asp:Label runat="server" ID="Label4" Text="Centro de costos asociado al procedimiento"></asp:Label>
                <br />
            </div>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-12">
                <asp:GridView runat="server" ID="GridViewCostos" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" OnRowDataBound="GridViewCostos_RowDataBound" OnSelectedIndexChanged="GridViewCostos_SelectedIndexChanged" Visible="false">
                    <Columns>
                        <asp:BoundField DataField="CodUnidadF" HeaderText="Cod UF" />
                        <asp:BoundField DataField="DescUnidadF" HeaderText="Unidad Funcional" />
                        <asp:BoundField DataField="CodCentroCostos" HeaderText="Cod CC" />
                        <asp:BoundField DataField="DescCentroCosto" HeaderText="Centro de Costos" />
                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
                 <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
                <script type="text/javascript">
                    $(function () {
                        $("[id*=GridViewCostos] td").hover(function () {
                            $("td", $(this).closest("tr")).addClass("hover_row");
                        }, function () {
                            $("td", $(this).closest("tr")).removeClass("hover_row");
                        });
                    });
                </script>
                <br />
            </div>
        </div>
        <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
            <div class="form-group">
                <br />
                <div class="alert alert-danger">
                    <asp:Label runat="server" ID="lbl_resultadocentro" Text=""></asp:Label>
                </div>

                <br />
                <asp:Label runat="server" ID="lbl_unidadfuncional" Text="Unidad Funcional"></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
                <asp:DropDownList runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_unidadfuncional_SelectedIndexChanged" ID="ddl_unidadfuncional" CssClass="form-control"></asp:DropDownList><br />
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_UnidadFuncional" ReadOnly="true"></asp:TextBox><br />

                <asp:Label runat="server" ID="lbl_centrocostos" Text="Centro de Costos"></asp:Label>
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
                <asp:DropDownList runat="server" ID="ddl_centrocostos" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_centrocostos_SelectedIndexChanged"></asp:DropDownList><br />
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_CentroCostos" ReadOnly="true"></asp:TextBox>
                     </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_unidadfuncional" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
                   </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddl_unidadfuncional" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>

                <br />
                <div class="form-group">
                    <asp:Button runat="server" ID="btn_agregarunidad" Text="Agregar" CssClass="btn btn-primary" OnClick="btn_agregarunidad_Click" />
                    <asp:Button runat="server" ID="btn_eliminarunidad" Text="Eliminar" CssClass="btn btn-primary" OnClick="btn_eliminarunidad_Click" />
                    <br />
                </div>
            </div>
        </div>
</ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="GridViewCostos" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
                    </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <asp:Button runat="server" ID="btn_registrar" Text="Guardar" OnClick="btn_registrar_Click" CssClass="btn btn-primary" />
        </div>
        <br />

    </div>
                    </asp:Panel>
</asp:Content>
