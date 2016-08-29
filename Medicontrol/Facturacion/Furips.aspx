<%@ Page Title="" Language="C#" MasterPageFile="~/Facturacion/Facturacion.Master" AutoEventWireup="true" CodeBehind="Furips.aspx.cs" Inherits="Medicontrol.Facturacion.Formulario_web17" %>

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

    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Label runat="server" ID="txt_NumeroConsecutivo" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_tipodocvictimacc" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocvictimace" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocvictimapa" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocvictimati" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocvictimarc" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocvictimaas" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocvictimams" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_cconductor" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_cpeaton" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_cocupante" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_cciclista" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_accidentetransito" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_sismo" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_maremoto" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_erupcion" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_huracan" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_inundaciones" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_avalancha" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_deslizamiento" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_incendionat" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_explosion" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_masacre" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_mina" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_combate" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_incendio" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_ataque" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_otro" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_estadoAsegurado" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_asegurado" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_noasegurado" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_fantasma" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_polizafalsa" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_fuga" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_interpolicia" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_interpolsi" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_interpolno" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_cobroexcedente" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_cobrosi4" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_cobrono4" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="TS1" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TS2" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TS3" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TS4" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TS5" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TS6" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="TS7" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_tipodocpropietariocc" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocpropietariocd" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocpropietariopa" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocpropietarionit" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocpropietarioti" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocpropietariorc" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_tipodocconductorcc" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocconductorce" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocconductorpa" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocconductorti" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocconductorrc" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocconductoras" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_remision7" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_orden7" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tiporeferencia" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_tipoAmbulancia" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_ambubasica8" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_ambumedicalizada8" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_zonavictima" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_zonaurbanovictima" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_zonaruralvictima" Text="" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="txt_tipodoccc9" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocce9" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocpa9" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocti9" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocrc9" Text="" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="txt_tipodocas9" Text="" Visible="false"></asp:Label>

    <hr />
    <h3>FURIPS</h3>
    <br />
    <div class="alert alert-danger">
        <asp:Label runat="server" ID="lbl_resultado" Text=""></asp:Label>
    </div>
    <div class="form-group">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server"
            UpdateMode="Conditional">
            <ContentTemplate>
                <section id="1">
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_consecutivo" Text="Consecutivo"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_consecutivo" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_fecharadicacion" Text="Fecha de Radicación"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_fecharadicacion" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_rg" Text="Respuesta a Glosa (RG)"></asp:Label>
                            <asp:Label runat="server" ID="txt_respglosa" Text="Respuesta a Glosa (RG)" Visible="false"></asp:Label>
                            <asp:CheckBox runat="server" AutoPostBack="true" CssClass="form-control" ID="txt_rg" Checked="false" OnCheckedChanged="txt_rg_CheckedChanged"></asp:CheckBox>
                            <br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_numradicado" Text="No. Radicado"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numradicado" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_radianterior" Text="Radicación Anterior"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_radianterior" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_numfactura" Text="No. Factura/Cuenta de Cobro"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numfactura"></asp:TextBox>
                            <br />
                            <br />
                        </div>
                    </div>

                    <h3>I. DATOS DE LA INSTITUCIÓN PRESTADORA DE SERVICIOS DE SALUD</h3>
                    <br />

                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_razon1" Text="Razón Social"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_razon1"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_codhabil1" Text="Código Habilitación"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_codhabil1"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_nit1" Text="NIT"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nit1"></asp:TextBox>
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                </section>

                <section id="2">
                    <h3>II. DATOS DE LA VÍCTIMA DEL EVENTO CATASTRÓFICO O ACCIDENTE DE TRÁNSITO</h3>
                    <br />
                   
                    <br />
                    <asp:Panel runat="server" ID="panelVictimas" DefaultButton="btn_buscarVictima">
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_apellido12" Text="Primer Apellido"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido12"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_apellido22" Text="Segundo Apellido"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido22"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_nombre12" Text="Primer Nombre"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre12"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_nombre22" Text="Segundo Nombre"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre22"></asp:TextBox>
                            <br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            
                            <asp:Label runat="server" ID="lbl_documento2" Text="Número de Documento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_documento2"></asp:TextBox>
                            <asp:Button Visible="true" runat="server" ID="btn_buscarVictima" OnClick="btn_buscarVictima_Click" Text="Buscar" CssClass="btn btn-primary" />
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_tipodoc2" Text="Tipo de Documento"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_tipodoc2" CssClass="form-control">
                                
                            </asp:DropDownList>
                            <br /><br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_sexo2" Text="Género"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_sexo2" CssClass="form-control">
                                
                                <asp:ListItem Text="Femenino" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Masculino" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <br /><br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_Fechanaci2" Text="Fecha de Nacimiento"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_fechanaci2" AutoPostBack="true" Checked="false" OnCheckedChanged="chk_fechanaci2_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_fechanaci2" ReadOnly="false" Enabled="true"></asp:TextBox>
                            <br /><br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-8">
                            <asp:Label runat="server" ID="lbl_direccion2" Text="Dirección Residencia"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_direccion2"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_telefono2" Text="Número de Teléfono"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_telefono2"></asp:TextBox>
                            <br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_departamento2" Text="Departamento"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_departamento2" CssClass="form-control" OnSelectedIndexChanged="ddl_departamento2_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_coddepart2" Text="Código Departamento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_coddepart2" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_municipio2" Text="Municipio"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_municipio2" Enabled="false" CssClass="form-control" OnSelectedIndexChanged="ddl_municipio2_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <asp:Label runat="server" ID="lbl_codmunicipio2" Text="Código Municipio"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_codmunicipio2" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_condicion2" Text="Condición del Accidentado"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_condicion2" CssClass="form-control">
                                
                                <asp:ListItem Text="Conductor" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Peaton" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Ocupante" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Ciclista" Value="4"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <br />
                            <asp:Button Enabled="true" runat="server" ID="btn_copiarpropietario2" CssClass="btn btn-primary" Text="Copiar Datos a Propietario" OnClick="btn_copiarpropietario2_Click" />
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-5">
                            <br />
                            <asp:Button Enabled="true" runat="server" ID="btn_copiarconductor2" CssClass="btn btn-primary" Text="Copiar Datos a Conductor" OnClick="btn_copiarconductor2_Click" />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                        </asp:Panel>
                </section>

                <section id="3">

                    <h3>III. DATOS DEL SITIO DONDE OCURRIÓ EL EVENTO CATASTRÓFICO O EL ACCIDENTE DE TRANSITO</h3>
                    <br />
                    <h4>Naturaleza del Evento</h4>
                    <br />
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_naturales3" Text="Naturales/Terroristas"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_naturales3" CssClass="form-control" OnSelectedIndexChanged="ddl_naturales3_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Accidente de Tránsito" Value="01"></asp:ListItem>
                                <asp:ListItem Text="Sismo" Value="02"></asp:ListItem>
                                <asp:ListItem Text="Maremoto" Value="03"></asp:ListItem>
                                <asp:ListItem Text="Erupciones Volcánicas" Value="04"></asp:ListItem>
                                <asp:ListItem Text="Huracán" Value="05"></asp:ListItem>
                                <asp:ListItem Text="Inundaciones" Value="06"></asp:ListItem>
                                <asp:ListItem Text="Avalancha" Value="07"></asp:ListItem>
                                <asp:ListItem Text="Deslizamiento de Tierra" Value="08"></asp:ListItem>
                                <asp:ListItem Text="Incendio Natural" Value="09"></asp:ListItem>
                                <asp:ListItem Text="Explosión" Value="10"></asp:ListItem>
                                <asp:ListItem Text="Masacre" Value="11"></asp:ListItem>
                                <asp:ListItem Text="Mina Antipersonal" Value="12"></asp:ListItem>
                                <asp:ListItem Text="Combate" Value="13"></asp:ListItem>
                                <asp:ListItem Text="Incendio" Value="14"></asp:ListItem>
                                <asp:ListItem Text="Ataque a Municipios" Value="15"></asp:ListItem>
                                <asp:ListItem Text="Otra" Value="16"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_cual3" Text="¿Cual?"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_cual3" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_ocurrencia3" Text="Dirección de la Ocurrencia"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_ocurrencia3" TextMode="MultiLine"></asp:TextBox>
                            <br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_zona3" Text="Zona"></asp:Label>
                            <br />
                            <asp:CheckBox runat="server" ID="checkZonaUrb" Checked="false" Text="Urbano" AutoPostBack="true" OnCheckedChanged="checkZonaUrb_CheckedChanged" />
                            <br />
                            <asp:CheckBox runat="server" ID="checkZonaRural" Checked="false" Text="Rural" AutoPostBack="true" OnCheckedChanged="checkZonaRural_CheckedChanged" />
                            <asp:TextBox runat="server" ID="txt_zonaIII" Visible="false"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txt_zonaUIII" Visible="false"></asp:TextBox>
                            <asp:TextBox runat="server" ID="txt_zonaRIII" Visible="false"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_fechaevento3" Text="Fecha Evento/Accidente"></asp:Label>
                            <asp:CheckBox runat="server" ID="checkFechaIII" AutoPostBack="true" Checked="false" OnCheckedChanged="checkFechaIII_CheckedChanged" />
                            <asp:TextBox runat="server" Enabled="true" ReadOnly="false" CssClass="form-control birthday" ID="txt_fechaevento3"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_hora3" Text="Hora"></asp:Label>
                            <asp:CheckBox runat="server" ID="CheckHoraIII" AutoPostBack="true" Checked="false" OnCheckedChanged="CheckHoraIII_CheckedChanged" />
                            <asp:TextBox Enabled="false" ReadOnly="false" runat="server" CssClass="form-control" ID="txt_hora3"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_departamento3" Text="Departamento"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_departamento3" CssClass="form-control" OnSelectedIndexChanged="ddl_departamento3_SelectedIndexChanged" AutoPostBack="true">
                                
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_coddepar3" Text="Código Departamento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_coddepar3" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_municipio3" Text="Municipio"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_municipio3" CssClass="form-control" OnSelectedIndexChanged="ddl_municipio3_SelectedIndexChanged" AutoPostBack="true">
                                
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <asp:Label runat="server" ID="lbl_codmunicipio3" Text="Código Municipio"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_codmunicipio3" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <asp:Label runat="server" ID="lbl_descripcion3" Text="Descripción breve del evento catastrófico o accidente de trabajo, enuncie las principales características de evento/accidente."></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_descripcion3" TextMode="MultiLine"></asp:TextBox>
                            <br />
                            <br />
                        </div>
                </section>

                <section id="4">
                    <h3>IV. DATOS DEL VEHICULO DEL ACCIDENTE DE TRANSITO</h3>
                    <br />
                    <h5>Estado de Aseguramiento</h5>
                    <br />
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <asp:CheckBox runat="server" ID="chk_asegurado" Checked="false" Text="Asegurado" AutoPostBack="true" OnCheckedChanged="chk_asegurado_CheckedChanged" />
                            <asp:CheckBox runat="server" ID="chk_noasegurado" Checked="false" Text="No Asegurado" AutoPostBack="true" OnCheckedChanged="chk_noasegurado_CheckedChanged" />
                            <asp:CheckBox runat="server" ID="chk_fantasma" Checked="false" Text="Vehículo Fantasma" AutoPostBack="true" OnCheckedChanged="chk_fantasma_CheckedChanged" />
                            <asp:CheckBox runat="server" ID="chk_polizafalsa" Checked="false" Text="Póliza Falsa" AutoPostBack="true" OnCheckedChanged="chk_polizafalsa_CheckedChanged" />
                            <asp:CheckBox runat="server" ID="chk_fuga" Checked="false" Text="Vehículo en Fuga" AutoPostBack="true" OnCheckedChanged="chk_fuga_CheckedChanged" />
                        </div>
                        <br />
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_marca4" Text="Marca"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_marca4"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <asp:Label runat="server" ID="lbl_placa4" Text="Placa"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_placa4"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_tiposerv4" Text="Tipo de Servicio"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_tiposerv4" CssClass="form-control">
                                <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Particular" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Público" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Oficial" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Vehículo de Emergencia" Value="5"></asp:ListItem>
                                <asp:ListItem Text="Vehículo de Servicio Diplomático o Consular" Value="6"></asp:ListItem>
                                <asp:ListItem Text="Vehículo de Transporte Masivo" Value="7"></asp:ListItem>
                                <asp:ListItem Text="Vehículo Escolar" Value="8"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_codaseguradora4" Text="Código Aseguradora"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_codaseguradora4" CssClass="form-control">
                                <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                <asp:ListItem Text="fin 1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="fin 2" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_numpoliza4" Text="No. Póliza"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numpoliza4"></asp:TextBox>
                            <br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_fechadesde4" Text="Fecha Desde"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_fechadesde4" AutoPostBack="true" Checked="false" OnCheckedChanged="chk_fechadesde4_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_fechadesde4" ReadOnly="false" Enabled="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_fechahasta4" Text="Fecha Hasta"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_fechahasta4" AutoPostBack="true" Checked="false" OnCheckedChanged="chk_fechahasta4_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_fechahasta4" ReadOnly="false" Enabled="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_intervencion4" Text="Intervención de la Policia"></asp:Label>
                            <br />
                            <asp:CheckBox runat="server" ID="chk_interpolsi" Checked="false" Text="SI" AutoPostBack="true" OnCheckedChanged="chk_interpolsi_CheckedChanged" />
                            <br />
                            <asp:CheckBox runat="server" ID="chk_interpolno" Checked="false" Text="NO" AutoPostBack="true" OnCheckedChanged="chk_interpolno_CheckedChanged" />
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_cobroexc4" Text="Cobro Excedente Póliza"></asp:Label>
                            <br />
                            <asp:CheckBox runat="server" ID="chk_cobrosi" Checked="false" Text="SI" AutoPostBack="true" OnCheckedChanged="chk_cobrosi_CheckedChanged" />
                            <br />
                            <asp:CheckBox runat="server" ID="chk_cobrono" Checked="false" Text="NO" AutoPostBack="true" OnCheckedChanged="chk_cobrono_CheckedChanged" />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                </section>

                <section id="5">
                    <h3>V. DATOS DEL PROPIETARIO DEL VEHÍCULO </h3>
                    <br />
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_apellido15" Text="Primer Apellido o Razón Social"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido15"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_apellido25" Text="Segundo Apellido"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido25"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_nombre15" Text="Primer Nombre"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre15"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_nombre25" Text="Segundo Nombre"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre25"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_numdoc5" Text="Número de Documento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numdoc5"></asp:TextBox>
                            <asp:Button Visible="true" runat="server" ID="btn_buscarPropietario" OnClick="btn_buscarPropietario_Click" Text="Buscar" CssClass="btn btn-primary" />
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_tipodoc5" Text="Tipo de Documento"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_tipodoc5" CssClass="form-control">
                                <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                            <br /><br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_direccion5" Text="Dirección Residencia"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_direccion5"></asp:TextBox>
                            <br /><br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <asp:Label runat="server" ID="lbl_telefono5" Text="Número de Teléfono"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_telefono5"></asp:TextBox>
                            <br /><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_departamento5" Text="Departamento"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_departamento5" CssClass="form-control" OnSelectedIndexChanged="ddl_departamento5_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_coddepar5" Text="Código Departamento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_coddepar5" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_municipio5" Text="Municipio"></asp:Label>
                            <asp:DropDownList Enabled="false" runat="server" ID="ddl_municipio5" CssClass="form-control" OnSelectedIndexChanged="ddl_municipio5_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <asp:Label runat="server" ID="lbl_codmunicipio5" Text="Código Municipio"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_codmunicipio5" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <asp:Button Enabled="true" runat="server" ID="btn_copiarvictima5" CssClass="btn btn-primary" Text="Copiar Datos de Víctima" OnClick="btn_copiarvictima5_Click" />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                </section>

                <section id="6">
                    <h3>VI. DATOS DEL CONDUCTOR DEL VEHÍCULO INVOLUCRADO EN EL ACCIDENTE DE TRANSITO</h3>
                    <br />
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_apellido16" Text="Primer Apellido"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido16"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_apellido26" Text="Segundo Apellido"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido26"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_nombre16" Text="Primer Nombre"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre16"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_nombre26" Text="Segundo Nombre"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre26"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_documento6" Text="Número de Documento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_documento6"></asp:TextBox>
                            <asp:Button Visible="true" runat="server" ID="btn_buscarCondulctor" OnClick="btn_buscarCondulctor_Click" Text="Buscar" CssClass="btn btn-primary" />
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_tipodoc6" Text="Tipo de Documento"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_tipodoc6" CssClass="form-control">
                                <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                <asp:ListItem Text="fin 1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="fin 2" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <br /><br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_direccion6" Text="Dirección Residencia"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_direccion6"></asp:TextBox>
                            <br /><br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <asp:Label runat="server" ID="lbl_telefono6" Text="Número de Teléfono"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_telefono6"></asp:TextBox>
                            <br /><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_departamento6" Text="Departamento"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_departamento6" CssClass="form-control" OnSelectedIndexChanged="ddl_departamento6_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>

                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_coddepart6" Text="Código Departamento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_coddepart6" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_municipio6" Text="Municipio"></asp:Label>
                            <asp:DropDownList Enabled="false" runat="server" ID="ddl_municipio6" CssClass="form-control" OnSelectedIndexChanged="ddl_municipio6_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <asp:Label runat="server" ID="lbl_codmunicipio6" Text="Código Municipio"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_codmunicipio6" ReadOnly="true"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <br />
                            <asp:Button Enabled="true" runat="server" ID="btn_copiarpropietario6" CssClass="btn btn-primary" Text="Copiar Datos de Propietario" OnClick="btn_copiarpropietario6_Click" />
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-9">
                            <br />
                            <asp:Button Enabled="true" runat="server" ID="btn_copiarvictima6" CssClass="btn btn-primary" Text="Copiar Datos de Víctima" OnClick="btn_copiarvictima6_Click" />
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                </section>

                <section id="7">
                    <h3>VII. DATOS DE REMISIÓN</h3>
                    <br />
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_tiporemision" Text="Tipo de Remisión"></asp:Label>
                            <br />
                            <asp:CheckBox runat="server" ID="chk_remision" Checked="false" Text="Remisión" AutoPostBack="true" OnCheckedChanged="chk_remision_CheckedChanged" />
                            <br />
                            <asp:CheckBox runat="server" ID="chk_orden" Checked="false" Text="Orden de Servicio" AutoPostBack="true" OnCheckedChanged="chk_orden_CheckedChanged" />
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_fecharemision7" Text="Fecha de Remisión"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_fecharemision7" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_fecharemision7_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_fecharemision7" ReadOnly="false" Enabled="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_horaremision7" Text="Hora"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_horaremision7" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_horaremision7_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_horaremision7" ReadOnly="false" Enabled="true"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_prestaremite7" Text="Prestador que Remite"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_prestaremite7"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_codinscripcion7a" Text="Código de Inscripción"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_codinscripcion7"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_proremite7" Text="Profesional que Remite"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_proremite7"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <asp:Label runat="server" ID="lbl_cargo7a" Text="Cargo"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_cargo7a"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_fechaaceptacion7" Text="Fecha de Aceptación"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_fechaacep7" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_fechaacep7_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_fechaaceptacion7" ReadOnly="false" Enabled="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_horaaceptacion7" Text="Hora"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_horaacep7" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_horaacep7_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_horaaceptacion7" ReadOnly="false" Enabled="false"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_prestarecibe7" Text="Prestador que Recibe"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_prestarecibe7"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_codinscripcion7b" Text="Código de Inscripción"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_codinscripcion7b"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_prorecibe7" Text="Profesional que Recibe"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_prorecibe7"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_cargo7b" Text="Cargo"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_cargo7b"></asp:TextBox>
                            <br />
                            <br />
                        </div>
                    </div>
                </section>

                <section id="8">
                    <h3>VIII. AMPARO DE TRANSPORTE Y MOVILIZACIÓN DE LA VÍCTIMA</h3>
                    <br />
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <asp:Label runat="server" ID="lbl_placas8" Text="Placas del Vehículo"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_placas8"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-5">
                            <asp:Label runat="server" ID="lbl_transdesde8" Text="Transporta a la Víctima Desde"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_transdesde8"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-5">
                            <asp:Label runat="server" ID="lbl_transhasta8" Text="Transporta a la Víctima Hasta"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_transhasta8"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_tipitrans8" Text="Tipo de Transporte"></asp:Label>
                            <br />
                            <asp:CheckBox runat="server" ID="chk_ambubasica" Text="Ambulancia Básica" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_ambubasica_CheckedChanged" />
                            <br />
                            <asp:CheckBox runat="server" ID="chk_ambumedica" Text="Ambulancia Medicalizada" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_ambumedica_CheckedChanged" />
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_recoge8" Text="Lugar donde recoge a la victima"></asp:Label>
                            <br />
                            <asp:CheckBox runat="server" ID="chk_urbana" Text="Urbana" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_urbana_CheckedChanged" />
                            <br />
                            <asp:CheckBox runat="server" ID="chk_rural" Text="Rural" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_rural_CheckedChanged" />
                            <br />
                            <br />
                        </div>
                    </div>
                </section>

                <section id="9">
                    <h3>IX. CERTIFICACIÓN DE LA ATENCIÓN MÉDICA DE LA VÍCTIMA COMO PRUEBA DEL ACCIDENTE O EVENTO</h3>
                    <br />
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_fechaingreso9" Text="Fecha de Ingreso"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_fechaingreso9" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_fechaingreso9_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_fechaingreso9" ReadOnly="false" Enabled="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_horaingreso9" Text="Hora Ingreso"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_horaingreso9" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_horaingreso9_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_horaingreso9" ReadOnly="false" Enabled="false"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_fechasalida9" Text="Fecha de Egreso"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_fechasalida9" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_fechasalida9_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control birthday" ID="txt_fechasalida9" ReadOnly="false" Enabled="true"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_horasalida9" Text="Hora de Egreso"></asp:Label>
                            <asp:CheckBox runat="server" ID="chk_horasalida9" Checked="false" AutoPostBack="true" OnCheckedChanged="chk_horasalida9_CheckedChanged" />
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_horasalida9" ReadOnly="false" Enabled="false"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_coddx1ingreso9" Text="Código Diagnóstico Principal de Ingreso"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_coddx1ingreso9"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_coddx1salida9" Text="Código Diagnóstico Principal de Egreso"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_coddx1salida9"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_otrodxingreso29" Text="Otro Código Diagnóstico de Ingreso"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_otrodxingreso29"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_otrodxsalida29" Text="Otro Código Diagnóstico de Egreso"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_otrodxegreso29"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_otrodxingreso39" Text="Otro Código Diagnóstico de Ingreso"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_otrodxingreso39"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_otrodxsalida39" Text="Otro Código Diagnóstico de Egreso"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_otrodxsalida39"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_apellido1medico9" Text="Primer Apellido del Médico o Profesional Tratante"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido1medico9"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_apellido2medico9" Text="Segundo Apelido del Médico o Profesional Tratante"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_apellido2medico9"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_nomber1medico9" Text="Primer Nombre del Médico o Profesional Tratante"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre1medico9"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-3">
                            <asp:Label runat="server" ID="lbl_nombre2medico9" Text="Segundo Apellido del Médico o Profesional Tratante"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_nombre2medico9"></asp:TextBox>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_documento9" Text="Número de Documento"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_documento9"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_tipodoc9" Text="Tipo de Documento"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl_tipodoc9" CssClass="form-control">
                                <asp:ListItem Text="Seleccione" Value="0"></asp:ListItem>
                                <asp:ListItem Text="fin 1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="fin 2" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_numregistro9" Text="Número de Registro Médico"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_numregistro9"></asp:TextBox>
                            <br />
                            <br />
                        </div>
                    </div>
                </section>

                <section id="10">
                    <h3>IX. AMPAROS QUE RECLAMA</h3>
                    <br />
                    <h4 style="text-align: center;">Gastos Médicos Quirúrgicos</h4>
                    <div class="form-group">
                        <br />
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_vrfacturado10" Text="Valor Total Facturado"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_vrfacturado10"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <asp:Label runat="server" ID="lbl_vrfosyga10" Text="Valor Reclamo al FOSYGA"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_vrfosyga10"></asp:TextBox>
                            <br />
                            <br />
                        </div>
                    </div>
                    <h4 style="text-align: center;">Gastos de Transporte y Movilización de la Víctima</h4>
                    <div class="form-group">
                        <br />
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_vr2facturado10" Text="Valor Total Facturado"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_vr2facturado10"></asp:TextBox>
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_vr2fosyga10" Text="Valor Reclamo al FOSYGA"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_vr2fosyga10"></asp:TextBox>
                            <br />
                        </div>
                         <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4">
                            <asp:Label runat="server" ID="lbl_totalfolios" Text="Total Folios"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txt_totalfolios"></asp:TextBox>
                            <br />
                        </div>
                    </div>

                   
                </section>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl_departamento2" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
         <div class="form-group">
                       
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-2">
                            <br />
                            <asp:Button Enabled="true" runat="server" ID="btn_guardar" CssClass="btn btn-primary" Text="Guardar" OnClick="btn_guardar_Click" />
                            <br />
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6">
                            <br />
                            <asp:Button Enabled="true" runat="server" ID="btn_imprimir" CssClass="btn btn-primary" Text="Imprimir" OnClick="btn_imprimir_Click" />
                            <br />
                        </div>
                    </div>
    </div>

    <script src="../Scripts/bootstrapcantidad/bootstrap.min.js"></script>

</asp:Content>
