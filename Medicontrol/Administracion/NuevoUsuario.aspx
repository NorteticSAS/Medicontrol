<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="NuevoUsuario.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <asp:Panel ID="p" runat="server" DefaultButton="btn_registrar">
        <h3>Administración de Usuarios</h3>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <hr />
            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                <div class="btn-group" role="group">
                    <asp:Button BackColor="#999999" PostBackUrl="~/Administracion/NuevoUsuario.aspx" runat="server" ID="btn_Nuevo" CssClass="btn btn-primary" Text="Nuevo" />
                </div>
                <div class="btn-group" role="group">
                    <asp:Button PostBackUrl="~/Administracion/BuscarUsuario.aspx" runat="server" ID="btn_Buscar" CssClass="btn btn-primary" Text="Buscar" />
                </div>
                <div class="btn-group" role="group">
                    <asp:Button Enabled="true" runat="server" PostBackUrl="~/Administracion/ModificarUsuario.aspx" ID="btn_Actualizar" CssClass="btn btn-primary" Text="Modificar" />
                </div>
                <div class="btn-group" role="group">
                    <asp:Button Enabled="false" runat="server" ID="btn_Eliminar" CssClass="btn btn-primary" Text="Eliminar" />
                </div>
            </div>
            <hr />
            <h3>Registro de Usuarios</h3>
            <br />
            <div class="alert alert-danger">
                <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_codigo" Text="Código Usuario"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_codigo"></asp:TextBox>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_nombre" Text="Nombre y Apellido"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre"></asp:TextBox>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_cargo" Text="Cargo"></asp:Label>
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
                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                                <asp:Label runat="server" ID="lbl_clave" Text="Clave"></asp:Label>

                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_clave"></asp:TextBox>
                                <asp:CheckBox AutoPostBack="true" Checked="false" Text="  Mostrar Clave" ID="CheckClave" OnCheckedChanged="CheckClave_CheckedChanged" runat="server" />
                                <br />
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                                <asp:Label runat="server" ID="lbl_direccion" Text="Dirección Residencia"></asp:Label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_direccion"></asp:TextBox>
                                <br />
                                <br />
                            </div>
                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                                <asp:Label runat="server" ID="lbl_telefono" Text="Telefono"></asp:Label>
                                <asp:TextBox runat="server" CssClass="form-control" ID="txt_telefono"></asp:TextBox>
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
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_celular" Text="Celular"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_correo"></asp:TextBox>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_correo" Text="Correo Electronico"></asp:Label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txt_celular"></asp:TextBox>
                    <br />
                </div>
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                    <asp:Label runat="server" ID="lbl_estado" Text="Estado"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddl_estado" CssClass="form-control">
                        <asp:ListItem Text="Seleccione Un Estado" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactivo" Value="2"></asp:ListItem>

                    </asp:DropDownList>
                    <br />
                </div>

            </div>



            <div class="form-group">
                <asp:Label runat="server" ID="lbl_btn" Text=""></asp:Label>
                    <asp:Button runat="server" ID="btn_registrar" OnClick="btn_registrar_Click" Text="Guardar" CssClass="btn btn-primary" />
                    <br />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
