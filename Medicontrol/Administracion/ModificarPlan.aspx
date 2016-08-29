<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="ModificarPlan.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
        <asp:Panel ID="p" runat="server" DefaultButton="btn_buscarPlan">

     <h3>Administración de Planes</h3>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <hr />
        <div class="btn-group btn-group-justified" role="group" aria-label="...">
            <div class="btn-group" role="group">
                <asp:Button PostBackUrl="~/Administracion/NuevoPlan.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button  PostBackUrl="~/Administracion/BuscarPlan.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button BackColor="#999999" Enabled="true" runat="server" PostBackUrl="~/Administracion/ModificarPlan.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar"/>
            </div>
        </div>
        <hr />
        <h3>Modificar Plan</h3>
        <br />
        <div class="alert alert-danger">
            <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lbl_buscar" Text="Digite el Código del Plan" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-3"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-2">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
                <br />
            </div>
            <asp:Button Enabled="true" runat="server" ID="btn_buscarPlan" OnClick="btn_buscarPlan_Click" CssClass="btn btn-primary" Text="Buscar" />
        </div>
        <br />
        <div class="form-group">
            <asp:Label Visible="true" runat="server" ID="lbl_codigo" Text="Código del Plan" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox ReadOnly="true" Visible="true" runat="server" CssClass="form-control" ID="txt_codigo"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <asp:Label Visible="true" runat="server" ID="lbl_descripcion" Text="Nombre del Plan" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox Visible="true" runat="server" CssClass="form-control" ID="txt_descripcion"></asp:TextBox>
                <br />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lbl_btn" Text="" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:Button Visible="false" runat="server" ID="btn_registrar" OnClick="btn_registrar_Click" Text="Guardar" CssClass="btn btn-primary" /> 
                <br />
            </div>
        </div>
        </div>
            </asp:Panel>
</asp:Content>
