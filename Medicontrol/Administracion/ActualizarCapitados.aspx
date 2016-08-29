<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Administracion.Master" AutoEventWireup="true" CodeBehind="ActualizarCapitados.aspx.cs" Inherits="Medicontrol.Administracion.Formulario_web120" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
    .modal
    {
        position: fixed;
        top: 0;
        left: 0;
        background-color: black;
        z-index: 99;
        opacity: 0.8;
        filter: alpha(opacity=80);
        -moz-opacity: 0.8;
        min-height: 100%;
        width: 100%;
    }
    .loading
    {
        font-family: Arial;
        font-size: 10pt;
        border: 5px solid #67CFF5;
        width: 200px;
        height: 100px;
        display: none;
        position: fixed;
        background-color: White;
        z-index: 999;
    }
</style>
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }
        $('form').live("submit", function () {
            ShowProgress();
        });
    </script>
    <asp:Label runat="server" ID="CodContrato" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="CodEntidad" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="username" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="CodigoEnSesion" Visible="false" ></asp:Label>
    <asp:Label runat="server" ID="CargoUsuario" Visible="false" ></asp:Label>
        <h3>Actualizar Base de Datos Contratos Capitados</h3>
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
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
            <asp:Label runat="server" ID="lbl_ruta" Text="Ruta del Archivo"></asp:Label>
            <asp:FileUpload runat="server" ID="FileUploadToServer" />
            <br /><br /><br /><br />
        </div>
             <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                 <asp:CheckBox runat="server" ID="CheckBorrar" Text="Borrar Tablas Antes de Guardar" /><br />
                     <asp:Button Visible="true" runat="server" ID="btn_registrar" Text="Subir Base de Datos" CssClass="btn btn-primary" OnClick="btn_registrar_Click" />
                     <asp:Button Visible="true" Enabled="false" runat="server" ID="btn_cargar" Text="Cargar Datos al Sistema" CssClass="btn btn-danger" OnClick="btn_cargar_Click" /><br />
             <br />    
             </div>
        </div>
 
    <div class="form-group">
        <br /><br />
        <p class="h3">Para tener en cuenta</p>
        <br />
        <p>1. El archivo con la información de las bases de Datos debe ser de tipo Excel</p>
        <br />
        <p>2. El archivo debe cumplir con la misma estructura de tablas y contener la misma cantidad de columnas con la Tabla Capitados.</p>
        <br />
        <p>3. Para cargar la tabla Capitados de sebe seleccionar el archivo excel y posteriormente hacer clic en el Botón "Subir Base de Datos."</p> 
        <br />
        <p>4. Se debe seleccionar la Entidad y el Contrato que se le asignará a los Pacientes antes de proceder con la carga de Capitados.</p>
        <br />
        <p>5. Luego de cargada la base Capitados hacer clic en el botón "Cargar Datos al Sistema" para proceder con la actualización de los Pacientes.</p>
        <br />
        <p>6. El proceso finaliza con un mensaje de confirmacón.</p>   
    </div>
        <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

</asp:Content>
