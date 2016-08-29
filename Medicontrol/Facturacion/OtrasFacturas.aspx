<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="OtrasFacturas.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web19" %>

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
            <asp:DropDownList runat="server" Enabled="false" ID="ddl_contrato" OnSelectedIndexChanged="ddl_contrato_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
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

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_fechaini" Text="Fecha Inicial"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechaini" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_fechafin" Text="Fecha Final"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fechafin" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="lbl_vrmensual" Text="Valor Mensual"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_vrmensual" ReadOnly="true"></asp:TextBox>
            <br />
        </div>
    </div>
    <div class="form-group">

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-8">
            <asp:Label runat="server" ID="Label1" Text="IPS"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_ips" CssClass="form-control">
            </asp:DropDownList>
            <br />
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
            <asp:Label runat="server" ID="Label2" Text="Municipio"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_municipio" ReadOnly="false"></asp:TextBox>
            <br />
            <br />
        </div>

    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12"> 
        <asp:Label runat="server" ID="Label3" Text="Detalle"></asp:Label>
        <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control" ID="txt_detalle" ReadOnly="false"></asp:TextBox>
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




    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

</asp:Content>
