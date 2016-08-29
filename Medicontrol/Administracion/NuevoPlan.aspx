<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="NuevoPlan.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web16" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
            <asp:Panel ID="Panel2" runat="server" DefaultButton="btn_registrar">

    <h3>Administración de Planes</h3>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <hr />
        <div class="btn-group btn-group-justified" role="group" aria-label="...">
            <div class="btn-group" role="group">
                <asp:Button BackColor="#999999" PostBackUrl="~/Administracion/NuevoPlan.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button PostBackUrl="~/Administracion/BuscarPlan.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="true" runat="server" PostBackUrl="~/Administracion/ModificarPlan.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
            </div>
        </div>
        <hr />
        <h3>Creación de Planes</h3>
        <br />
        <div class="alert alert-danger">
            <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-6">

                <asp:Label runat="server" ID="lbl_codigo" Text="Código del Plan"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigo"></asp:TextBox>
                <br />

                <asp:Label runat="server" ID="lbl_descripcion" Text="Nombre del Plan"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_descripcion"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="lbl_btn" Text="" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:Button runat="server" ID="btn_registrar" OnClick="btn_registrar_Click" Text="Guardar" CssClass="btn btn-primary" />
                <br />
            </div>
        </div>
        
    </div>
                </asp:Panel>
</asp:Content>
