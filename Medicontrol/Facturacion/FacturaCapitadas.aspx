<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="FacturaCapitadas.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label runat="server" ID="ValorUPCmes1" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="CodContratoo" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="ValorMesNormal" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_upc2" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="NumFactura" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="Prefijo" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TipoDoc" Visible="false"></asp:Label>
    <br />
    

  <%--  <asp:UpdatePanel ID="UpdatePanel3" runat="server"
        UpdateMode="Conditional">
        <ContentTemplate>--%>
            <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Label runat="server" ID="lbl_entidad" Text="Entidad"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_entidad" AutoPostBack="true" OnSelectedIndexChanged="ddl_entidad_SelectedIndexChanged" CssClass="form-control">
                       
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                    <asp:Label runat="server" ID="lbl_contrato" Enabled="false" Text="Contrato"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_contrato" OnSelectedIndexChanged="ddl_contrato_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                        
                    </asp:DropDownList>
                    <br />
                </div>
            </div>

            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_fecha" Text="Fecha Factura"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_fecha" ReadOnly="false"></asp:TextBox>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_numcontrato" Text="Número de Contrato"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_numcontrato" ReadOnly="true"></asp:TextBox>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_numfactura" Text="Factura No"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_numfactura" ReadOnly="true"></asp:TextBox>
                    <br />
                </div>
            </div>
              

            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_upc" Text="Valor UPC"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_upc" ReadOnly="true"></asp:TextBox>
                    <br /><br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Panel runat="server" ID="panel" DefaultButton="btn_umafil">
                    <asp:Label runat="server" ID="lbl_numafiliados" Text="Número Afiliados"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_numafiliados"></asp:TextBox>
                    <asp:Button Enabled="true" style="visibility:hidden" runat="server" ID="btn_umafil" Visible="true" OnClick="btn_umafil_Click" />
                    <br />
                        </asp:Panel>
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_fechaini" Text="Fecha Inicial"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechaini" ReadOnly="true"></asp:TextBox>
                    <br /><br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_fechafin" Text="Fecha Final"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechafin" ReadOnly="true"></asp:TextBox>
                    <br /><br />
                </div>
            </div>

            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_capita" Text="% Capita"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_capita" ReadOnly="true"></asp:TextBox>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_vrmensual" Text="Valor Mensual"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_vrmensual" ReadOnly="true"></asp:TextBox>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_servicio" Text="Servicios"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_servicio" CssClass="form-control">
                        <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                        <asp:ListItem Text="I Nivel de Atención" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Unidad Renal" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
            </div>

            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_mes" Text="Mes"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_mes" CssClass="form-control">
                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Enero" Value="Enero"></asp:ListItem>
                        <asp:ListItem Text="Febrero" Value="Febrero"></asp:ListItem>
                        <asp:ListItem Text="Marzo" Value="Marzo"></asp:ListItem>
                        <asp:ListItem Text="Abril" Value="Abril"></asp:ListItem>
                        <asp:ListItem Text="Mayo" Value="Mayo"></asp:ListItem>
                        <asp:ListItem Text="Junio" Value="Junio"></asp:ListItem>
                        <asp:ListItem Text="Julio" Value="Julio"></asp:ListItem>
                        <asp:ListItem Text="Agosto" Value="Agosto"></asp:ListItem>
                        <asp:ListItem Text="Septiembre" Value="Septiembre"></asp:ListItem>
                        <asp:ListItem Text="Octubre" Value="Octubre"></asp:ListItem>
                        <asp:ListItem Text="Noviembre" Value="Noviembre"></asp:ListItem>
                        <asp:ListItem Text="Diciembre" Value="Diciembre"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_año" Text="Año"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_año" CssClass="form-control">
                        <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                        <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                        <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                        <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                        <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                        <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                        <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                        <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                        <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                        <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                        <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                        <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                        <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_ips" Text="IPS"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_ips" CssClass="form-control">
                        
                    </asp:DropDownList>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_municipio" Text="Municipio"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_municipio"></asp:TextBox>
                    <br />
                </div>
            </div>

            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_conse1" Text="Consecutivo F. Venta"></asp:Label>
                    <asp:CheckBox AutoPostBack="true" runat="server" CssClass="form-control" ID="chb_conse1" OnCheckedChanged="chb_conse1_CheckedChanged" />
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <asp:Label runat="server" ID="lbl_conse2" Text="Consecutivo F. Venta Capitada"></asp:Label>
                    <asp:CheckBox AutoPostBack="true" runat="server" CssClass="form-control" ID="chb_conse2" OnCheckedChanged="chb_conse2_CheckedChanged" />
                    <br />
                </div>

                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <br />
                    <asp:Button runat="server" ID="btn_guardar" Text="Guardar" OnClick="btn_guardar_Click" CssClass="btn btn-primary" />
                    <asp:Button OnClick="btn_imprimir_Click" runat="server" ID="btn_imprimir" Text="Imprimir" CssClass="btn btn-primary" />

                    <br />
                </div>

                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                    <br />
                    <br />
                </div>
            </div>
           <%-- </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddl_entidad" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>--%>
      

    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

</asp:Content>
