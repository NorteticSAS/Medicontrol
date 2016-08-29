<%@ Page Title="" Language="C#" MasterPageFile="~/Citas/fiffsCitas.Master" AutoEventWireup="true" CodeBehind="AsignarCitas.aspx.cs" Inherits="Medicontrol.Citas.Formulario_web1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css" rel="Stylesheet" type="text/css" />
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
    <script type="text/javascript">
        $(function () {
            $("[id$=txt_nombrePaciente]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("/Citas/AsignarCitas.aspx/BuscarPaciente") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset>
        <legend></legend>
        <div class="form-group">

            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                <asp:Label Font-Size="Medium" ID="Label1" runat="server" Text="Seleccione IPS"></asp:Label><br />
                <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddl_ips_SelectedIndexChanged" CssClass="form-control" Font-Size="Medium" ID="ddl_ips" runat="server"></asp:DropDownList>
                <br />
                <br />
                <asp:Label Font-Size="Medium" ID="Label3" runat="server" Text="Seleccione Profesional"></asp:Label><br />
                <asp:DropDownList Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddl_profesionales_SelectedIndexChanged" CssClass="form-control" Font-Size="Medium" ID="ddl_profesionales" runat="server"></asp:DropDownList>

            </div>
            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4" style="margin: 0 auto;">
                <asp:Label Style="text-align: center" Font-Size="Medium" ID="Label2" runat="server" Text="Seleccione Fecha de Cita"></asp:Label><br />
                <asp:TextBox Enabled="false" ID="txt_fechaCita" CssClass="form-control text-center" runat="server" ReadOnly="true"></asp:TextBox><br />
                <asp:Calendar align="center" Enabled="false" ID="CalendarCita" runat="server" BorderWidth="1px" BackColor="White" Width="220px" ForeColor="#003399" Height="200px" Font-Size="8pt" Font-Names="Verdana" BorderColor="#3366CC" OnSelectionChanged="CalendarCita_SelectionChanged" CellPadding="1" DayNameFormat="Shortest">
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White"></TodayDayStyle>
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"></NextPrevStyle>
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px"></DayHeaderStyle>
                    <SelectedDayStyle ForeColor="#CCFF99" BackColor="#009999" Font-Bold="True"></SelectedDayStyle>
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle Font-Size="10pt" Font-Bold="True" BorderWidth="1px" ForeColor="#CCCCFF" BorderColor="#3366CC" BackColor="#003399" Height="25px"></TitleStyle>
                    <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>
            </div>


            <div class="col-xs-12 col-sm-12 col-md-4 col-lg-4">
                <asp:Panel runat="server" ID="panel1" DefaultButton="btn_buscarPaciente">
                    <asp:Label Font-Size="Medium" ID="Label4" runat="server" Text="Buscar Paciente"></asp:Label><br />
                    <asp:TextBox ID="txt_CedulaPaciente" placeholder="Buscar por Documento" CssClass="form-control text-center" runat="server" ReadOnly="true"></asp:TextBox><br />
                    <asp:TextBox ID="txt_nombrePaciente" placeholder="Buscar por Nombre" CssClass="form-control text-center" runat="server" ReadOnly="true"></asp:TextBox><br />
                    <asp:Button runat="server" ID="btn_buscarPaciente" Text="Buscar" CssClass="btn btn-primary" OnClick="btn_buscarPaciente_Click" />
                    <br />
                    <br />
                    <asp:Label Font-Size="Medium" ID="Label5" runat="server" Text="Fecha del Sistema"></asp:Label><br />
                    <asp:TextBox ID="txt_fechaDias" CssClass="form-control text-center" runat="server" ReadOnly="true"></asp:TextBox><br />

                </asp:Panel>
            </div>

        </div>
    </fieldset>
    <fieldset>
        <legend></legend>
        <div class="form-group">
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                <asp:Label Font-Size="Medium" ID="Label6" runat="server" Text="Jornada de la Mañana"></asp:Label><br />
                <asp:DropDownList CssClass="form-control" ID="manana" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="manana_SelectedIndexChanged">
                    <asp:ListItem Value="0">Seleccione una Hora</asp:ListItem>
                    <asp:ListItem Value="1">06:00 am</asp:ListItem>
                    <asp:ListItem Value="2">06:20 am</asp:ListItem>
                    <asp:ListItem Value="3">06:40 am</asp:ListItem>
                    <asp:ListItem Value="4">07:00 am</asp:ListItem>
                    <asp:ListItem Value="5">07:20 am</asp:ListItem>
                    <asp:ListItem Value="6">07:40 am</asp:ListItem>
                    <asp:ListItem Value="7">08:00 am</asp:ListItem>
                    <asp:ListItem Value="8">08:20 am</asp:ListItem>
                    <asp:ListItem Value="9">08:40 am</asp:ListItem>
                    <asp:ListItem Value="10">09:00 am</asp:ListItem>
                    <asp:ListItem Value="11">09:20 am</asp:ListItem>
                    <asp:ListItem Value="12">09:40 am</asp:ListItem>
                    <asp:ListItem Value="13">10:00 am</asp:ListItem>
                    <asp:ListItem Value="14">10:20 am</asp:ListItem>
                    <asp:ListItem Value="15">10:40 am</asp:ListItem>
                    <asp:ListItem Value="16">11:00 am</asp:ListItem>
                    <asp:ListItem Value="17">11:20 am</asp:ListItem>
                    <asp:ListItem Value="18">11:40 am</asp:ListItem>
                    <asp:ListItem Value="19">12:00 pm</asp:ListItem>
                    <asp:ListItem Value="20">12:20 pm</asp:ListItem>
                    <asp:ListItem Value="21">12:40 pm</asp:ListItem>
                    <asp:ListItem Value="22">01:00 pm</asp:ListItem>
                    <asp:ListItem Value="23">01:20 pm</asp:ListItem>
                    <asp:ListItem Value="24">01:40 pm</asp:ListItem>
                </asp:DropDownList><br />
            </div>
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                <asp:Label Font-Size="Medium" ID="Label7" runat="server" Text="Jornada de la Tarde"></asp:Label><br />
                <asp:DropDownList AutoPostBack="true" CssClass="form-control" ID="tarde" Enabled="false" runat="server" OnSelectedIndexChanged="tarde_SelectedIndexChanged">
                    <asp:ListItem Value="0">Seleccione una Hora</asp:ListItem>
                    <asp:ListItem Value="25">02:00 pm</asp:ListItem>
                    <asp:ListItem Value="26">02:20 pm</asp:ListItem>
                    <asp:ListItem Value="27">02:40 pm</asp:ListItem>
                    <asp:ListItem Value="28">03:00 pm</asp:ListItem>
                    <asp:ListItem Value="29">03:20 pm</asp:ListItem>
                    <asp:ListItem Value="30">03:40 pm</asp:ListItem>
                    <asp:ListItem Value="31">04:00 pm</asp:ListItem>
                    <asp:ListItem Value="32">04:20 pm</asp:ListItem>
                    <asp:ListItem Value="33">04:40 pm</asp:ListItem>
                    <asp:ListItem Value="34">05:00 pm</asp:ListItem>
                    <asp:ListItem Value="35">05:20 pm</asp:ListItem>
                    <asp:ListItem Value="36">05:40 pm</asp:ListItem>
                    <asp:ListItem Value="37">06:00 pm</asp:ListItem>
                    <asp:ListItem Value="38">06:20 pm</asp:ListItem>
                    <asp:ListItem Value="39">06:40 pm</asp:ListItem>
                    <asp:ListItem Value="40">07:00 pm</asp:ListItem>
                    <asp:ListItem Value="41">07:20 pm</asp:ListItem>
                    <asp:ListItem Value="42">07:40 pm</asp:ListItem>
                    <asp:ListItem Value="43">08:00 pm</asp:ListItem>
                    <asp:ListItem Value="44">08:20 pm</asp:ListItem>
                    <asp:ListItem Value="45">08:40 pm</asp:ListItem>
                    <asp:ListItem Value="46">09:00 pm</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </fieldset>
    <fieldset>
        <asp:Label runat="server" ID="cedulapaciente" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="nombrepaciente" Visible="false"></asp:Label>

        <legend></legend>
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3">
            <label style="font-size: medium">
                <asp:ImageButton Width="30" ID="btn_delete60" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete60_Click" /><asp:ImageButton Width="30" ID="btn_imprimir600" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir600_Click" />&nbsp;<asp:Label ID="m60" runat="server" Text="06:00am"></asp:Label><asp:TextBox CssClass="form-control" ID="seisam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete62" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete62_Click" /><asp:ImageButton Width="30" ID="btn_imprimir620" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir620_Click" />&nbsp;<asp:Label ID="m62" runat="server" Text="06:20am"></asp:Label><asp:TextBox CssClass="form-control" ID="seisveinteam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete64" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete64_Click" /><asp:ImageButton Width="30" ID="btn_imprimir640" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir640_Click" />&nbsp;<asp:Label ID="m64" runat="server" Text="06:40am"></asp:Label><asp:TextBox CssClass="form-control" ID="seiscuarentaam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete70" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete70_Click" /><asp:ImageButton Width="30" ID="btn_imprimir700" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir700_Click" />&nbsp;<asp:Label ID="m70" runat="server" Text="07:00am"></asp:Label><asp:TextBox CssClass="form-control" ID="sieteam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete72" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete72_Click" /><asp:ImageButton Width="30" ID="btn_imprimir720" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir720_Click" />&nbsp;<asp:Label ID="m72" runat="server" Text="07:20am"></asp:Label><asp:TextBox CssClass="form-control" ID="sieteveinteam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete74" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete74_Click" /><asp:ImageButton Width="30" ID="btn_imprimir740" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir740_Click" />&nbsp;<asp:Label ID="m74" runat="server" Text="07:40am"></asp:Label><asp:TextBox CssClass="form-control" ID="sietecuarentaam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete80" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete80_Click" /><asp:ImageButton Width="30" ID="btn_imprimir800" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir800_Click" />&nbsp;<asp:Label ID="m80" runat="server" Text="08:00am"></asp:Label><asp:TextBox CssClass="form-control" ID="ochoam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete82" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete82_Click" /><asp:ImageButton Width="30" ID="btn_imprimir820" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir820_Click" />&nbsp;<asp:Label ID="m82" runat="server" Text="08:20am"></asp:Label><asp:TextBox CssClass="form-control" ID="ochoveinteam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete84" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete84_Click" /><asp:ImageButton Width="30" ID="btn_imprimir840" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir840_Click" />&nbsp;<asp:Label ID="m84" runat="server" Text="08:40am"></asp:Label><asp:TextBox CssClass="form-control" ID="ochocuarentaam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete90" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete90_Click" /><asp:ImageButton Width="30" ID="btn_imprimir900" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir900_Click" />&nbsp;<asp:Label ID="m90" runat="server" Text="09:00am"></asp:Label><asp:TextBox CssClass="form-control" ID="nueveam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete92" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete92_Click" /><asp:ImageButton Width="30" ID="btn_imprimir920" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir920_Click" />&nbsp;<asp:Label ID="m92" runat="server" Text="09:20am"></asp:Label><asp:TextBox CssClass="form-control" ID="nueveveinteam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete94" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete94_Click" /><asp:ImageButton Width="30" ID="btn_imprimir940" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir940_Click" />&nbsp;<asp:Label ID="m94" runat="server" Text="09:40am"></asp:Label><asp:TextBox CssClass="form-control" ID="nuevecuarentaam" runat="server" ReadOnly="true"></asp:TextBox>
                
            </label>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3">
            <label style="font-size: medium">
                <asp:ImageButton Width="30" ID="btn_delete1000" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete1000_Click" /><asp:ImageButton Width="30" ID="btn_imprimir1000" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir1000_Click" />&nbsp;<asp:Label ID="m100" runat="server" Text="10:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="diezam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete1020" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete1020_Click" /><asp:ImageButton Width="30" ID="btn_imprimir1020" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir1020_Click" />&nbsp;<asp:Label ID="m102" runat="server" Text="10:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="diezveinteam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete1040" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete1040_Click" /><asp:ImageButton Width="30" ID="btn_imprimir1040" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir1040_Click" />&nbsp;<asp:Label ID="m104" runat="server" Text="10:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="diezcuarentaam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete1100" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete1100_Click"  /><asp:ImageButton Width="30" ID="btn_imprimir1100" runat="server" ImageUrl="~/Imagenes/ico-print.png"  OnClick="btn_imprimir1100_Click" />&nbsp;<asp:Label ID="m110" runat="server" Text="11:00am"></asp:Label><asp:TextBox CssClass="form-control" ID="onceam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete1120" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete1120_Click"  /><asp:ImageButton Width="30" ID="btn_imprimir1120" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir1120_Click"  />&nbsp;<asp:Label ID="m112" runat="server" Text="11:20am"></asp:Label><asp:TextBox CssClass="form-control" ID="onceveinteam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete1140" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete1140_Click" /><asp:ImageButton Width="30" ID="btn_imprimir1140" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir1140_Click"  />&nbsp;<asp:Label ID="m114" runat="server" Text="11:40am"></asp:Label><asp:TextBox CssClass="form-control" ID="oncecuarentaam" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete1200" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete1200_Click"  /><asp:ImageButton Width="30" ID="btn_imprimir1200" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir1200_Click"  />&nbsp;<asp:Label ID="m120" runat="server" Text="12:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="docepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete1220" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete1220_Click"  /><asp:ImageButton Width="30" ID="btn_imprimir1220" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir1220_Click"  />&nbsp;<asp:Label ID="m122" runat="server" Text="12:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="doceveintepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete1240" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete1240_Click" /><asp:ImageButton Width="30" ID="btn_imprimir1240" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir1240_Click"  />&nbsp;<asp:Label ID="m124" runat="server" Text="12:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="docecuarentapm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0100" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0100_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0100" runat="server" ImageUrl="~/Imagenes/ico-print.png"  OnClick="btn_imprimir0100_Click" />&nbsp;<asp:Label ID="m010" runat="server" Text="01:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="unopm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0120" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0120_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0120" runat="server" ImageUrl="~/Imagenes/ico-print.png"  OnClick="btn_imprimir0120_Click" />&nbsp;<asp:Label ID="m012" runat="server" Text="01:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="unoveintepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0140" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0140_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0140" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0140_Click"  />&nbsp;<asp:Label ID="m014" runat="server" Text="01:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="unocuarentapm" runat="server" ReadOnly="true"></asp:TextBox>

            </label>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3">
            <label style="font-size: medium">
                <asp:ImageButton Width="30" ID="btn_delete0200" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0200_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0200" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0200_Click" />&nbsp;<asp:Label ID="m020" runat="server" Text="02:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="dospm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0220" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0220_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0220" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0220_Click" />&nbsp;<asp:Label ID="m022" runat="server" Text="02:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="dosveintepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0240" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0240_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0240" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0240_Click" />&nbsp;<asp:Label ID="m024" runat="server" Text="02:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="doscuarentapm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0300" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0300_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0300" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0300_Click" />&nbsp;<asp:Label ID="m030" runat="server" Text="03:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="trespm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0320" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0320_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0320" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0320_Click" />&nbsp;<asp:Label ID="m032" runat="server" Text="03:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="tresveintepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0340" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0340_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0340" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0340_Click" />&nbsp;<asp:Label ID="m034" runat="server" Text="03:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="trescuarentapm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0400" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0400_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0400" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0400_Click"  />&nbsp;<asp:Label ID="m040" runat="server" Text="04:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="cuatropm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0420" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0420_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0420" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0420_Click" />&nbsp;<asp:Label ID="m042" runat="server" Text="04:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="cuatroveintepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0440" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0440_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0440" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0440_Click" />&nbsp;<asp:Label ID="m044" runat="server" Text="04:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="cuatrocuarentapm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0500" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0500_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0500" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0500_Click" />&nbsp;<asp:Label ID="m050" runat="server" Text="05:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="cincopm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0520" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0520_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0520" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0520_Click" />&nbsp;<asp:Label ID="m052" runat="server" Text="05:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="cincoveintepm" runat="server" ReadOnly="true"></asp:TextBox>
                
            </label>
        </div>
         <div class="col-xs-12 col-sm-12 col-md-6 col-lg-3">
            <label style="font-size: medium">
                <asp:ImageButton Width="30" ID="btn_delete0540" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0540_Click" /><asp:ImageButton Width="30" ID="btn_imprimir0540" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="btn_imprimir0540_Click" />&nbsp;<asp:Label ID="m054" runat="server" Text="05:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="cincocuarentapm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0600" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0600_Click" /><asp:ImageButton Width="30" ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton1_Click" />&nbsp;<asp:Label ID="m060" runat="server" Text="06:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="seispm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0620" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0620_Click" /><asp:ImageButton Width="30" ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton2_Click" />&nbsp;<asp:Label ID="m062" runat="server" Text="06:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="seisveintepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0640" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0640_Click" /><asp:ImageButton Width="30" ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton3_Click" />&nbsp;<asp:Label ID="m064" runat="server" Text="06:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="seiscuarentapm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0700" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0700_Click" /><asp:ImageButton Width="30" ID="ImageButton4" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton4_Click" />&nbsp;<asp:Label ID="m070" runat="server" Text="07:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="sietepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0720" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0720_Click" /><asp:ImageButton Width="30" ID="ImageButton5" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton5_Click" />&nbsp;<asp:Label ID="m072" runat="server" Text="07:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="sieteveintepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0740" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0740_Click" /><asp:ImageButton Width="30" ID="ImageButton6" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton6_Click" />&nbsp;<asp:Label ID="m074" runat="server" Text="07:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="sietecuarentapm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0800" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0800_Click" /><asp:ImageButton Width="30" ID="ImageButton7" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton7_Click" />&nbsp;<asp:Label ID="m080" runat="server" Text="08:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="ochopm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0820" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0820_Click" /><asp:ImageButton Width="30" ID="ImageButton8" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton8_Click" />&nbsp;<asp:Label ID="m082" runat="server" Text="08:20pm"></asp:Label><asp:TextBox CssClass="form-control" ID="ochoveintepm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0840" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0840_Click" /><asp:ImageButton Width="30" ID="ImageButton9" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton9_Click" />&nbsp;<asp:Label ID="m084" runat="server" Text="08:40pm"></asp:Label><asp:TextBox CssClass="form-control" ID="ochocuarentapm" runat="server" ReadOnly="true"></asp:TextBox>
                <asp:ImageButton Width="30" ID="btn_delete0900" runat="server" ImageUrl="~/Imagenes/Delete-icon (1).png" OnClick="btn_delete0900_Click" /><asp:ImageButton Width="30" ID="ImageButton10" runat="server" ImageUrl="~/Imagenes/ico-print.png" OnClick="ImageButton10_Click" />&nbsp;<asp:Label ID="m090" runat="server" Text="09:00pm"></asp:Label><asp:TextBox CssClass="form-control" ID="nuevepm" runat="server" ReadOnly="true"></asp:TextBox>

            </label>
        </div>
    </fieldset>
    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

    <script type="text/javascript">
        function ShowPopupNoexiste() {
            $("#noUsuarios").click();
        }
    </script>
    <button type="button" style="display: none;" id="noUsuarios" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#ModalUsuarios">
        Launch demo modal
    </button>

    <div class="modal fade" id="ModalUsuarios" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Admisiones</h4>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lbl_mensajeUsuario" runat="server" />
                    <br />

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btn_crear" OnClick="btn_crear_Click" Text="Si" runat="server" type="button" class="btn btn-primary"></asp:Button>
                    <asp:Button ID="btn_nocrear" OnClick="btn_nocrear_Click" Text="No" runat="server" type="button" class="btn btn-primary"></asp:Button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
    </div>
                           
</asp:Content>
