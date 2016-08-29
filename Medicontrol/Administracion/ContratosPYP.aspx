<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="ContratosPYP.aspx.cs" Inherits="Medicontrol.Administracion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <h3>Metas Contratos de Promoción y Prevención</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>

    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_entidades" Text="Entidades"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_entidades" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_entidades_SelectedIndexChanged" >
               
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_contrato" Text="Contrato"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_contrato" CssClass="form-control" Enabled="false">
                
            </asp:DropDownList>
            <br />
        </div>
    </div>
     <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <asp:Label runat="server" ID="Label1" Text="Programa PYP"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_programapyp" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_programapyp_SelectedIndexChanged" Enabled="true" >
               
            </asp:DropDownList>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <asp:Label runat="server" ID="Label2" Text="Procedimiento"></asp:Label>
            <asp:DropDownList runat="server" ID="ddl_procedimiento" CssClass="form-control" Enabled="false">
                
            </asp:DropDownList>
            <br />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label3" Text="Primer Trimestre"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_primerTri"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label4" Text="Segundo Trimestre"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_segundoTri"></asp:TextBox>
            <br />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label5" Text="Tercer Trimestre"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_tercerTri"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label6" Text="Cuarto Trimestre"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_cuartoTri"></asp:TextBox>
            <br />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label7" Text="Meta Anual"></asp:Label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txt_metaAnual"></asp:TextBox>
            <br />
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="Label8" Text=""></asp:Label><br />
            <asp:Button Visible="true" runat="server" ID="btn_registrar" Text="Guardar" CssClass="btn btn-primary" OnClick="btn_registrar_Click" />
            <br />
        </div>
    </div>
</asp:Content>
