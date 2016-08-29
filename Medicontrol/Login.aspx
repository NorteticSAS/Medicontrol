<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Medicontrol.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>SIFSS</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <link href="../dist/css/sb-admin-2.css" rel="stylesheet" />

    <link href="../bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <asp:Literal ID="titulologin" runat="server" Text="Ingreso al Sistema" /></h3>
                    </div>
                    <div>
                        
                    </div>
                    <div class="panel-body">
                        <form id="Form1" role="form" runat="server">
                            <div class="form-group">
                               <asp:Label CssClass="alert alert-danger btn-block" Visible="false" runat="server" ID="lbl_resultado"></asp:Label>
                            </div>
                            
                            <hr />
                                <div class="form-group">
                                    <asp:TextBox ID="username" placeholder="Digite su Nombre de Usuario" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="password" TextMode="Password" placeholder="Digite su Clave de Acceso" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <!-- Change this to a button or input when using this as a form -->
                                <asp:Button runat="server" ID="inciar" CssClass="btn btn-lg btn-primary btn-block" OnClick="inciar_Click" Text="Ingresar"></asp:Button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- jQuery -->
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../bower_components/metisMenu/dist/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="../dist/js/sb-admin-2.js"></script>
</body>

</html>
