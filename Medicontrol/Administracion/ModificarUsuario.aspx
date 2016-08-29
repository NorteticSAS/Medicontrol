<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <asp:Panel ID="p" runat="server" DefaultButton="btn_buscarUsuario">
        
    <h3>Administración de Usuarios</h3>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <hr />
        <div class="btn-group btn-group-justified" role="group" aria-label="...">
            <div class="btn-group" role="group">
                <asp:Button PostBackUrl="~/Administracion/NuevoUsuario.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button  PostBackUrl="~/Administracion/BuscarUsuario.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button  Enabled="true" PostBackUrl="~/Administracion/ModificarUsuario.aspx" runat="server" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
            </div>
            <div class="btn-group" role="group">
                <asp:Button BackColor="#999999" Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
            </div>
        </div>
        <hr />

        <h3>Modificar Usuarios</h3>
        <br />
        <div class="alert alert-danger">
            <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lbl_buscar" Text="Digite el Código del Profesional" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-3"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-2">
                <asp:TextBox ReadOnly="false" runat="server" CssClass="form-control" ID="txt_buscar"></asp:TextBox>
                <br />
            </div>
            <asp:Button Enabled="true" runat="server" ID="btn_buscarUsuario" OnClick="btn_buscarUsuario_Click" CssClass="btn btn-primary" Text="Buscar" />
        </div>
        <br />
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btn_registrar">

        <div class="form-group">
            <asp:Label runat="server" ID="lbl_codigo" Text="Código Usuario" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigo"></asp:TextBox>
                <br />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="lbl_nombre" Text="Nombre y Apellido" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre"></asp:TextBox>
                <br />
            </div>
        </div>
      
        <div class="form-group">
            <asp:Label runat="server" ID="lbl_cargo" Text="Cargo" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_cargo"></asp:TextBox>
                <br />
            </div>
        </div>
       <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
        <div class="form-group">
            <asp:Label runat="server" ID="lbl_clave" Text="Clave" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_clave"></asp:TextBox>
                <asp:CheckBox AutoPostBack="true" Checked="false" Text="  Mostrar Clave" ID="CheckClave" OnCheckedChanged="CheckClave_CheckedChanged" runat="server" />
                <br />
                <br />
            </div>
        </div>
                     </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="CheckClave" EventName="CheckedChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" ID="lbl_direccion" Text="Dirección Residencia" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_direccion"></asp:TextBox>
                <br />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" ID="lbl_telefono" Text="Telefono" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_telefono"></asp:TextBox>
                <br />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" ID="lbl_celular" Text="Celular" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_celular"></asp:TextBox>
                <br />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" ID="lbl_correo" Text="Correo Electronico" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:TextBox runat="server" CssClass="form-control" ID="txt_correo"></asp:TextBox>
                <br />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" ID="lbl_estado" Text="Estado" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:DropDownList runat="server" ID="ddl_estado" CssClass="form-control">
                    <asp:ListItem Text="Seleccione Un Estado" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Inactivo" Value="2"></asp:ListItem>
                   
                </asp:DropDownList>
                <br />
            </div>
        </div>
              </asp:Panel>

         <div class="form-group">
            <asp:Label runat="server" ID="lbl_btn" Text="" CssClass="control-label col-xs-12 col-sm-12 col-md-12 col-lg-2"></asp:Label>
            <div class="col-sm-12 col-xs-12 col-md-12 col-lg-10">
                <asp:Button Visible="false" runat="server" ID="btn_registrar" OnClick="btn_registrar_Click" Text="Guardar" CssClass="btn btn-primary" /> 
                <br />
            </div>
        </div>
            </asp:Panel>
</asp:Content>
