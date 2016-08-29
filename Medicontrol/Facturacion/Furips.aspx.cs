using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class Formulario_web17 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            txt_fecharadicacion.Text = hoy.ToShortDateString();
            txt_razon1.Text = "EMPRESA SOCIAL DEL ESTADO IMSALUD";
            txt_codhabil1.Text = "540010086101";
            txt_nit1.Text = "807.004.3523";
            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM Departamentos ORDER BY Departamento", "Departamentos");
                this.ddl_departamento2.DataSource = Datos.ds.Tables["Departamentos"];
                this.ddl_departamento2.DataTextField = "Departamento";
                this.ddl_departamento2.DataValueField = "CodDpto";
                this.ddl_departamento2.DataBind();


                Datos.consultar("SELECT * FROM Departamentos ORDER BY Departamento", "Departamentos");
                this.ddl_departamento3.DataSource = Datos.ds.Tables["Departamentos"];
                this.ddl_departamento3.DataTextField = "Departamento";
                this.ddl_departamento3.DataValueField = "CodDpto";
                this.ddl_departamento3.DataBind();


                Datos.consultar("SELECT * FROM Departamentos ORDER BY Departamento", "Departamentos");
                this.ddl_departamento5.DataSource = Datos.ds.Tables["Departamentos"];
                this.ddl_departamento5.DataTextField = "Departamento";
                this.ddl_departamento5.DataValueField = "CodDpto";
                this.ddl_departamento5.DataBind();

                Datos.consultar("SELECT * FROM Departamentos ORDER BY Departamento", "Departamentos");
                this.ddl_departamento6.DataSource = Datos.ds.Tables["Departamentos"];
                this.ddl_departamento6.DataTextField = "Departamento";
                this.ddl_departamento6.DataValueField = "CodDpto";
                this.ddl_departamento6.DataBind();
                


                Datos.consultar("SELECT * FROM TipoDocumento ORDER BY NomDocumento", "TipoDocumento"); //TIPO DE DOCUMENTO SECCION 2
                this.ddl_tipodoc2.DataSource = Datos.ds.Tables["TipoDocumento"];
                this.ddl_tipodoc2.DataTextField = "NomDocumento";
                this.ddl_tipodoc2.DataValueField = "CodDocumento";
                this.ddl_tipodoc2.DataBind();
                

                this.ddl_tipodoc5.DataSource = Datos.ds.Tables["TipoDocumento"]; //TIPO DOCUMENTO SECCION 5
                this.ddl_tipodoc5.DataTextField = "NomDocumento";
                this.ddl_tipodoc5.DataValueField = "CodDocumento";
                this.ddl_tipodoc5.DataBind();
                

                this.ddl_tipodoc6.DataSource = Datos.ds.Tables["TipoDocumento"]; //TIPO DOCUMENTO SECCION 5
                this.ddl_tipodoc6.DataTextField = "NomDocumento";
                this.ddl_tipodoc6.DataValueField = "CodDocumento";
                this.ddl_tipodoc6.DataBind();
                

                this.ddl_tipodoc9.DataSource = Datos.ds.Tables["TipoDocumento"]; //TIPO DOCUMENTO SECCION 5
                this.ddl_tipodoc9.DataTextField = "NomDocumento";
                this.ddl_tipodoc9.DataValueField = "CodDocumento";
                this.ddl_tipodoc9.DataBind();

                Datos.consultar("SELECT * FROM Entidad ORDER BY NombreEntidad", "Entidad");
                this.ddl_codaseguradora4.DataSource = Datos.ds.Tables["Entidad"];
                this.ddl_codaseguradora4.DataTextField = "NombreEntidad";
                this.ddl_codaseguradora4.DataValueField = "Codigo";
                this.ddl_codaseguradora4.DataBind();
            }
        }

        protected void txt_rg_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_rg.Checked == true)
            {
                txt_respglosa.Text = "X";
            }
            else
            {
                txt_respglosa.Text = string.Empty;
            }
        }

        protected void chk_fechanaci2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fechanaci2.Checked == true)
            {
                txt_fechanaci2.Enabled = true;
            }
            else
            {
                txt_fechanaci2.Enabled = false;
            }
        }

        protected void ddl_departamento2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_municipio2.Enabled = true;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento2.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio2.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio2.DataTextField = "Municipio";
            this.ddl_municipio2.DataValueField = "CodMncpio";
            this.ddl_municipio2.DataBind();
            ddl_municipio2.Items.Insert(0, new ListItem("Seleccionar"));
            txt_coddepart2.Text = ddl_departamento2.SelectedValue.ToString();
        }

        protected void btn_copiarpropietario2_Click(object sender, EventArgs e)
        {
            string apellido12 = txt_apellido12.Text;
            txt_apellido15.Text = apellido12;
            string apellido22 = txt_apellido22.Text;
            txt_apellido25.Text = apellido22;
            string nombre12 = txt_nombre12.Text;
            txt_nombre15.Text = nombre12;
            string nombre22 = txt_nombre22.Text;
            txt_nombre25.Text = nombre22;
            string docvictima = txt_documento2.Text;
            txt_numdoc5.Text = docvictima;
            string tipodocvictima = ddl_tipodoc2.SelectedValue.ToString();
            ddl_tipodoc5.ClearSelection();
            ddl_tipodoc5.Items.FindByValue(tipodocvictima).Selected = true;
            string direccionvictima = txt_direccion2.Text;
            txt_direccion5.Text = direccionvictima;
            string telvictima = txt_telefono2.Text;
            txt_telefono5.Text = telvictima;


            string codDepar2 = ddl_departamento2.SelectedValue.ToString();
            ddl_departamento5.ClearSelection();
            ddl_departamento5.Items.FindByValue(codDepar2).Selected = true;
            txt_coddepar5.Text = codDepar2;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento2.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio5.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio5.DataTextField = "Municipio";
            this.ddl_municipio5.DataValueField = "CodMncpio";
            this.ddl_municipio5.DataBind();
            ddl_municipio5.Items.Insert(0, new ListItem("Seleccionar"));
        
            ddl_municipio5.ClearSelection();
            ddl_municipio5.Items.FindByValue(txt_codmunicipio2.Text).Selected = true;
            txt_codmunicipio5.Text = txt_codmunicipio2.Text;
        }

        protected void btn_copiarconductor2_Click(object sender, EventArgs e)
        {
            string apellido1conductor = txt_apellido12.Text;
            txt_apellido16.Text = apellido1conductor;
            string apellido2conductor = txt_apellido22.Text;
            txt_apellido26.Text = apellido2conductor;
            string nombre1conductor = txt_nombre12.Text;
            txt_nombre16.Text = nombre1conductor;
            string nombre2conductor = txt_nombre22.Text;
            txt_nombre26.Text = nombre2conductor;
            string docconductor = txt_documento2.Text;
            txt_documento6.Text = docconductor;
            string tipodocconductor = ddl_tipodoc2.SelectedValue.ToString();
            ddl_tipodoc6.ClearSelection();
            ddl_tipodoc6.Items.FindByValue(tipodocconductor).Selected = true;
            string direccionconductor = txt_direccion2.Text;
            txt_direccion6.Text = direccionconductor;
            string telconductor = txt_telefono2.Text;
            txt_telefono6.Text = telconductor;

            string codDepar2 = ddl_departamento2.SelectedValue.ToString();
            ddl_departamento6.ClearSelection();
            ddl_departamento6.Items.FindByValue(codDepar2).Selected = true;
            txt_coddepart6.Text = codDepar2;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento2.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio6.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio6.DataTextField = "Municipio";
            this.ddl_municipio6.DataValueField = "CodMncpio";
            this.ddl_municipio6.DataBind();
            ddl_municipio6.Items.Insert(0, new ListItem("Seleccionar"));
            //Datos.consultar("SELECT * FROM Municipio WHERE Id='" + this.txt_coddepart2.Text + "' ORDER BY Nombre", "Municipio");
            //this.ddl_municipio6.DataSource = Datos.ds.Tables["Municipio"];
            //this.ddl_municipio6.DataTextField = "Nombre";
            //this.ddl_municipio6.DataValueField = "CodMunicipio";
            //this.ddl_municipio6.DataBind();
            //ddl_municipio6.Items.Insert(0, new ListItem("Seleccionar"));
            ddl_municipio6.ClearSelection();
            ddl_municipio6.Items.FindByValue(txt_codmunicipio2.Text).Selected = true;
            txt_codmunicipio6.Text = txt_codmunicipio2.Text;

        }

        protected void ddl_naturales3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_naturales3.SelectedValue.ToString() == "16")
            {
                txt_cual3.ReadOnly = false;
            }
            else
            {
                txt_cual3.ReadOnly = true;
            }
        }

        protected void checkZonaUrb_CheckedChanged(object sender, EventArgs e)
        {
            if (checkZonaUrb.Checked == true)
            {
                checkZonaRural.Checked = false;
                txt_zonaIII.Text = "U";
                txt_zonaUIII.Text = "X";
            }
            else
            {
                txt_zonaIII.Text = string.Empty;
                txt_zonaUIII.Text = string.Empty;
            }
        }

        protected void checkZonaRural_CheckedChanged(object sender, EventArgs e)
        {
            if (checkZonaRural.Checked == true)
            {
                checkZonaUrb.Checked = false;
                txt_zonaIII.Text = "R";
                txt_zonaRIII.Text = "X";

            }
            else
            {
                txt_zonaIII.Text = string.Empty;
                txt_zonaRIII.Text = string.Empty;
            }
        }

        protected void checkFechaIII_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFechaIII.Checked == true)
            {
                txt_fechaevento3.Enabled = true;
            }
            else
            {
                txt_fechaevento3.Enabled = false;
            }
        }

        protected void CheckHoraIII_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckHoraIII.Checked == true)
            {
                txt_hora3.Enabled = true;
            }
            else
            {
                txt_hora3.Enabled = false;
            }
        }

        protected void ddl_departamento3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_municipio3.Enabled = true;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento3.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio3.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio3.DataTextField = "Municipio";
            this.ddl_municipio3.DataValueField = "CodMncpio";
            this.ddl_municipio3.DataBind();
            ddl_municipio3.Items.Insert(0, new ListItem("Seleccionar"));
            txt_coddepar3.Text = ddl_departamento3.SelectedValue.ToString();
        }

        protected void ddl_municipio3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_codmunicipio3.Text = ddl_municipio3.SelectedValue.ToString();
        }

        protected void chk_asegurado_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_asegurado.Checked == true)
            {
                chk_noasegurado.Checked = false;
                chk_fantasma.Checked = false;
                chk_polizafalsa.Checked = false;
                chk_fuga.Checked = false;
                txt_estadoAsegurado.Text = "1";
                txt_asegurado.Text = "X";
                txt_noasegurado.Text = "";
                txt_fantasma.Text = "";
                txt_polizafalsa.Text = "";
                txt_fuga.Text = "";
            }
        }

        protected void chk_noasegurado_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_noasegurado.Checked == true)
            {
                chk_asegurado.Checked = false;
                chk_fantasma.Checked = false;
                chk_polizafalsa.Checked = false;
                chk_fuga.Checked = false;
                txt_estadoAsegurado.Text = "2";
                txt_asegurado.Text = "";
                txt_noasegurado.Text = "X";
                txt_fantasma.Text = "";
                txt_polizafalsa.Text = "";
                txt_fuga.Text = "";
            }
        }

        protected void chk_fantasma_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fantasma.Checked == true)
            {
                chk_asegurado.Checked = false;
                chk_noasegurado.Checked = false;
                chk_polizafalsa.Checked = false;
                chk_fuga.Checked = false;
                txt_estadoAsegurado.Text = "3";
                txt_asegurado.Text = "";
                txt_noasegurado.Text = "";
                txt_fantasma.Text = "X";
                txt_polizafalsa.Text = "";
                txt_fuga.Text = "";
            }
        }

        protected void chk_polizafalsa_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_polizafalsa.Checked == true)
            {
                chk_asegurado.Checked = false;
                chk_noasegurado.Checked = false;
                chk_fantasma.Checked = false;
                chk_fuga.Checked = false;
                txt_estadoAsegurado.Text = "4";
                txt_asegurado.Text = "";
                txt_noasegurado.Text = "";
                txt_fantasma.Text = "";
                txt_polizafalsa.Text = "X";
                txt_fuga.Text = "";
            }
        }

        protected void chk_fuga_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fuga.Checked == true)
            {
                chk_asegurado.Checked = false;
                chk_noasegurado.Checked = false;
                chk_fantasma.Checked = false;
                chk_polizafalsa.Checked = false;
                txt_estadoAsegurado.Text = "5";
                txt_asegurado.Text = "";
                txt_noasegurado.Text = "";
                txt_fantasma.Text = "";
                txt_polizafalsa.Text = "";
                txt_fuga.Text = "X";
            }
        }

        protected void chk_fechadesde4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fechadesde4.Checked == true)
            {
                txt_fechadesde4.Enabled = true;
            }
            else
            {
                txt_fechadesde4.Enabled = false;
            }
        }

        protected void chk_fechahasta4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fechahasta4.Checked == true)
            {
                txt_fechahasta4.Enabled = true;
            }
            else
            {
                txt_fechahasta4.Enabled = false;
            }
        }

        protected void chk_interpolsi_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_interpolsi.Checked == true)
            {
                chk_interpolno.Checked = false;
                txt_interpolicia.Text = "0";
                txt_interpolsi.Text = "X";
                txt_interpolno.Text = "";
            }
        }

        protected void chk_interpolno_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_interpolno.Checked == true)
            {
                chk_interpolsi.Checked = false;
                txt_interpolicia.Text = "1";
                txt_interpolsi.Text = "";
                txt_interpolno.Text = "X";
            }
        }

        protected void chk_cobrosi_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_cobrosi.Checked == true)
            {
                chk_cobrono.Checked = false;
                txt_cobroexcedente.Text = "0";
                txt_cobrosi4.Text = "X";
                txt_cobrono4.Text = "";
            }
        }

        protected void chk_cobrono_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_cobrono.Checked == true)
            {
                chk_cobrosi.Checked = false;
                txt_cobroexcedente.Text = "1";
                txt_cobrosi4.Text = "";
                txt_cobrono4.Text = "X";
            }
        }

        protected void ddl_departamento5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_municipio5.Enabled = true;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento5.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio5.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio5.DataTextField = "Municipio";
            this.ddl_municipio5.DataValueField = "CodMncpio";
            this.ddl_municipio5.DataBind();
            ddl_municipio5.Items.Insert(0, new ListItem("Seleccionar"));
            txt_coddepar5.Text = ddl_departamento5.SelectedValue.ToString();
        }

        protected void btn_copiarvictima5_Click(object sender, EventArgs e)
        {
            //string apellido1propietario = txt_apellido12.Text;
            //txt_apellido15.Text = apellido1propietario;
            //string apellido2propietario = txt_apellido22.Text;
            //txt_apellido25.Text = apellido2propietario;
            //string nombre1propietario = txt_nombre12.Text;
            //txt_nombre15.Text = nombre1propietario;
            //string nombre2propietario = txt_nombre22.Text;
            //txt_nombre25.Text = nombre2propietario;
            //string docpropietario = txt_documento2.Text;
            //txt_numdoc5.Text = docpropietario;
            //string tipodocpropietario = ddl_tipodoc2.SelectedValue.ToString();
            //ddl_tipodoc5.ClearSelection();
            //ddl_tipodoc5.Items.FindByValue(tipodocpropietario).Selected = true;
            //string dirpropietario = txt_direccion2.Text;
            //txt_direccion5.Text = dirpropietario;
            //string telpropietario = txt_telefono2.Text;
            //txt_telefono5.Text = telpropietario;

            //Datos.consultar("SELECT * FROM Municipio WHERE Id='" + this.txt_coddepar5.Text + "' ORDER BY Nombre", "Municipio");
            //this.ddl_municipio2.DataSource = Datos.ds.Tables["Municipio"];
            //this.ddl_municipio2.DataTextField = "Nombre";
            //this.ddl_municipio2.DataValueField = "CodMunicipio";
            //this.ddl_municipio2.DataBind();
            //ddl_municipio2.Items.Insert(0, new ListItem("Seleccionar"));
            //ddl_municipio2.ClearSelection();
            //ddl_municipio2.Items.FindByValue(txt_codmunicipio5.Text).Selected = true;
            //ddl_departamento2.ClearSelection();
            //ddl_departamento2.Items.FindByValue(txt_coddepar5.Text).Selected = true;

            string apellido12 = txt_apellido12.Text;
            txt_apellido15.Text = apellido12;
            string apellido22 = txt_apellido22.Text;
            txt_apellido25.Text = apellido22;
            string nombre12 = txt_nombre12.Text;
            txt_nombre15.Text = nombre12;
            string nombre22 = txt_nombre22.Text;
            txt_nombre25.Text = nombre22;
            string docvictima = txt_documento2.Text;
            txt_numdoc5.Text = docvictima;
            string tipodocvictima = ddl_tipodoc2.SelectedValue.ToString();
            ddl_tipodoc5.ClearSelection();
            ddl_tipodoc5.Items.FindByValue(tipodocvictima).Selected = true;
            string direccionvictima = txt_direccion2.Text;
            txt_direccion5.Text = direccionvictima;
            string telvictima = txt_telefono2.Text;
            txt_telefono5.Text = telvictima;


            string codDepar2 = ddl_departamento2.SelectedValue.ToString();
            ddl_departamento5.ClearSelection();
            ddl_departamento5.Items.FindByValue(codDepar2).Selected = true;
            txt_coddepar5.Text = codDepar2;

            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento2.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio5.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio5.DataTextField = "Municipio";
            this.ddl_municipio5.DataValueField = "CodMncpio";
            this.ddl_municipio5.DataBind();
            ddl_municipio5.Items.Insert(0, new ListItem("Seleccionar"));
            //Datos.consultar("SELECT * FROM Municipio WHERE Id='" + this.txt_coddepart2.Text + "' ORDER BY Nombre", "Municipio");
            //this.ddl_municipio5.DataSource = Datos.ds.Tables["Municipio"];
            //this.ddl_municipio5.DataTextField = "Nombre";
            //this.ddl_municipio5.DataValueField = "CodMunicipio";
            //this.ddl_municipio5.DataBind();
            //ddl_municipio5.Items.Insert(0, new ListItem("Seleccionar"));
            ddl_municipio5.ClearSelection();
            ddl_municipio5.Items.FindByValue(txt_codmunicipio2.Text).Selected = true;
            txt_codmunicipio5.Text = txt_codmunicipio2.Text;
        }

        protected void ddl_municipio2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_codmunicipio2.Text = ddl_municipio2.SelectedValue.ToString();
        }

        protected void ddl_municipio5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_codmunicipio5.Text = ddl_municipio5.SelectedValue.ToString();
        }

        protected void ddl_departamento6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_municipio6.Enabled = true;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento6.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio6.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio6.DataTextField = "Municipio";
            this.ddl_municipio6.DataValueField = "CodMncpio";
            this.ddl_municipio6.DataBind();
            ddl_municipio6.Items.Insert(0, new ListItem("Seleccionar"));
            txt_coddepart6.Text = ddl_departamento6.SelectedValue.ToString();
        }

        protected void ddl_municipio6_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_codmunicipio6.Text = ddl_municipio6.SelectedValue.ToString();
        }

        protected void btn_copiarpropietario6_Click(object sender, EventArgs e)
        {
            string apellido1conductor6 = txt_apellido15.Text;
            txt_apellido16.Text = apellido1conductor6;
            string apellido2conductor6 = txt_apellido25.Text;
            txt_apellido26.Text = apellido2conductor6;
            string nombre1conductor6 = txt_nombre15.Text;
            txt_nombre16.Text = nombre1conductor6;
            string nombre2conductor6 = txt_nombre25.Text;
            txt_nombre26.Text = nombre2conductor6;
            string numdocconductor6 = txt_numdoc5.Text;
            txt_documento6.Text = numdocconductor6;
            string tipodocconductor6 = ddl_tipodoc5.SelectedValue.ToString();
            ddl_tipodoc6.ClearSelection();
            ddl_tipodoc6.Items.FindByValue(tipodocconductor6).Selected = true;
            string dirconductor6 = txt_direccion5.Text;
            txt_direccion6.Text = dirconductor6;
            string telconductor6 = txt_telefono5.Text;
            txt_telefono6.Text = telconductor6;

            string codDepar2 = ddl_departamento5.SelectedValue.ToString();
            ddl_departamento6.ClearSelection();
            ddl_departamento6.Items.FindByValue(codDepar2).Selected = true;
            txt_coddepart6.Text = codDepar2;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento5.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio6.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio6.DataTextField = "Municipio";
            this.ddl_municipio6.DataValueField = "CodMncpio";
            this.ddl_municipio6.DataBind();
            ddl_municipio6.Items.Insert(0, new ListItem("Seleccionar"));
            //Datos.consultar("SELECT * FROM Municipio WHERE Id='" + this.txt_coddepar5.Text + "' ORDER BY Nombre", "Municipio");
            //this.ddl_municipio6.DataSource = Datos.ds.Tables["Municipio"];
            //this.ddl_municipio6.DataTextField = "Nombre";
            //this.ddl_municipio6.DataValueField = "CodMunicipio";
            //this.ddl_municipio6.DataBind();
            //ddl_municipio6.Items.Insert(0, new ListItem("Seleccionar"));
            ddl_municipio6.ClearSelection();
            ddl_municipio6.Items.FindByValue(txt_codmunicipio5.Text).Selected = true;
            txt_codmunicipio6.Text = txt_codmunicipio5.Text;
        }

        protected void btn_copiarvictima6_Click(object sender, EventArgs e)
        {
            string apellido1devictima = txt_apellido12.Text;
            txt_apellido16.Text = apellido1devictima;
            string apellido2devictima = txt_apellido22.Text;
            txt_apellido26.Text = apellido2devictima;
            string nombre1devictima = txt_nombre12.Text;
            txt_nombre16.Text = nombre1devictima;
            string nombre2devictima = txt_nombre22.Text;
            txt_nombre26.Text = nombre2devictima;
            string numdocdevictima = txt_documento2.Text;
            txt_documento6.Text = numdocdevictima;
            string tipodocdevictima = ddl_tipodoc2.SelectedValue.ToString();
            ddl_tipodoc6.ClearSelection();
            ddl_tipodoc6.Items.FindByValue(tipodocdevictima).Selected = true;
            string dirdevictima = txt_direccion2.Text;
            txt_direccion6.Text = dirdevictima;
            string teldevictima = txt_telefono2.Text;
            txt_telefono6.Text = teldevictima;

            string codDepar2 = ddl_departamento2.SelectedValue.ToString();
            ddl_departamento6.ClearSelection();
            ddl_departamento6.Items.FindByValue(codDepar2).Selected = true;
            txt_coddepart6.Text = codDepar2;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento2.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio6.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio6.DataTextField = "Municipio";
            this.ddl_municipio6.DataValueField = "CodMncpio";
            this.ddl_municipio6.DataBind();
            ddl_municipio6.Items.Insert(0, new ListItem("Seleccionar"));
            //Datos.consultar("SELECT * FROM Municipio WHERE Id='" + this.txt_coddepart2.Text + "' ORDER BY Nombre", "Municipio");
            //this.ddl_municipio6.DataSource = Datos.ds.Tables["Municipio"];
            //this.ddl_municipio6.DataTextField = "Nombre";
            //this.ddl_municipio6.DataValueField = "CodMunicipio";
            //this.ddl_municipio6.DataBind();
            //ddl_municipio6.Items.Insert(0, new ListItem("Seleccionar"));
            ddl_municipio6.ClearSelection();
            ddl_municipio6.Items.FindByValue(txt_codmunicipio2.Text).Selected = true;
            txt_codmunicipio6.Text = txt_codmunicipio2.Text;
        }

        protected void chk_remision_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_remision.Checked == true)
            {
                chk_orden.Checked = false;
                txt_tiporeferencia.Text = "1";
                txt_remision7.Text = "X";
                txt_orden7.Text = "";
            }
        }

        protected void chk_orden_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_orden.Checked == true)
            {
                chk_remision.Checked = false;
                txt_tiporeferencia.Text = "2";
                txt_remision7.Text = "";
                txt_orden7.Text = "X";
            }
        }

        protected void chk_fecharemision7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fecharemision7.Checked == true)
            {
                txt_fecharemision7.Enabled = true;
            }
            else
            {
                txt_fecharemision7.Enabled = false;
            }
        }

        protected void chk_horaremision7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_horaremision7.Checked == true)
            {
                txt_horaremision7.Enabled = true;
            }
            else
            {
                txt_horaremision7.Enabled = false;
            }
        }

        protected void chk_fechaacep7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fechaacep7.Checked == true)
            {
                txt_fechaaceptacion7.Enabled = true;
            }
            else
            {
                txt_fechaaceptacion7.Enabled = false;
            }
        }

        protected void chk_horaacep7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_horaacep7.Checked == true)
            {
                txt_horaaceptacion7.Enabled = true;
            }
            else
            {
                txt_horaaceptacion7.Enabled = false;
            }
        }

        protected void chk_ambubasica_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ambubasica.Checked == true)
            {
                chk_ambumedica.Checked = false;
                txt_tipoAmbulancia.Text = "1";
                txt_ambubasica8.Text = "X";
                txt_ambumedicalizada8.Text = "";
            }
        }

        protected void chk_ambumedica_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ambumedica.Checked == true)
            {
                chk_ambubasica.Checked = false;
                txt_tipoAmbulancia.Text = "2";

                txt_ambubasica8.Text = "";
                txt_ambumedicalizada8.Text = "X";
            }
        }

        protected void chk_urbana_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_urbana.Checked == true)
            {
                chk_rural.Checked = false;
                txt_zonavictima.Text = "U";
                txt_zonaurbanovictima.Text = "X";
                txt_zonaruralvictima.Text = "";
            }
        }

        protected void chk_rural_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_rural.Checked == true)
            {
                chk_urbana.Checked = false;
                txt_zonavictima.Text = "R";
                txt_zonaurbanovictima.Text = "";
                txt_zonaruralvictima.Text = "X";
            }
        }

        protected void chk_fechaingreso9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fechaingreso9.Checked == true)
            {
                txt_fechaingreso9.Enabled = true;
            }
            else
            {
                txt_fechaingreso9.Enabled = false;
            }
        }

        protected void chk_horaingreso9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_horaingreso9.Checked == true)
            {
                txt_horaingreso9.Enabled = true;
            }
            else
            {
                txt_horaingreso9.Enabled = false;
            }
        }

        protected void chk_fechasalida9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fechasalida9.Checked == true)
            {
                txt_fechasalida9.Enabled = true;
            }
            else
            {
                txt_fechasalida9.Enabled = false;
            }
        }

        protected void chk_horasalida9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_horasalida9.Checked == true)
            {
                txt_horasalida9.Enabled = true;
            }
            else
            {
                txt_horasalida9.Enabled = false;
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            //traigo el ultimo consecutivo

            string sql = "SELECT * FROM Consecutivos WHERE TipoCont='12'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txt_NumeroConsecutivo.Text = leer["NumActual"].ToString();
            }

            int consecutivo = Convert.ToInt32(txt_NumeroConsecutivo.Text);
            txt_NumeroConsecutivo.Text = (consecutivo + 1).ToString();

            //PREPARAMOS LOS DATOS PARA GUARDAR
             //VARIABLE TIPO DE DOCUMENTO VICTIMA O PACIENTE, ES LA MISMA VAINA
            if (ddl_tipodoc2.SelectedValue.ToString() == "CC")
            {
                txt_tipodocvictimacc.Text = "X";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc2.SelectedValue.ToString() == "CE")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "X";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc2.SelectedValue.ToString() == "PA")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "X";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc2.SelectedValue.ToString() == "TI")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "X";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc2.SelectedValue.ToString() == "RC")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "X";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc2.SelectedValue.ToString() == "AS")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "X";
                txt_tipodocvictimams.Text = "";
            }
            if (ddl_tipodoc2.SelectedValue.ToString() == "MS")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "X";
            }

            //CONDICION ACCIDENTADO
            if (ddl_condicion2.SelectedValue.ToString() == "1")
            {
                txt_cconductor.Text = "X";
                txt_cpeaton.Text = "";
                txt_cocupante.Text = "";
                txt_cciclista.Text = "";
            }
            if (ddl_condicion2.SelectedValue.ToString() == "2")
            {
                txt_cconductor.Text = "";
                txt_cpeaton.Text = "X";
                txt_cocupante.Text = "";
                txt_cciclista.Text = "";
            }
            if (ddl_condicion2.SelectedValue.ToString() == "3")
            {
                txt_cconductor.Text = "";
                txt_cpeaton.Text = "";
                txt_cocupante.Text = "X";
                txt_cciclista.Text = "";
            }
            if (ddl_condicion2.SelectedValue.ToString() == "4")
            {
                txt_cconductor.Text = "";
                txt_cpeaton.Text = "";
                txt_cocupante.Text = "";
                txt_cciclista.Text = "X";
            }

            //NATURALEZA EVENTO
            if (ddl_naturales3.SelectedValue.ToString() == "01")
            {
                txt_accidentetransito.Text = "X";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";

            }
            if (ddl_naturales3.SelectedValue.ToString() == "02")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "X";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "03")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "X";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "04")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "X";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "05")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "X";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "06")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "X";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "07")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "X";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "08")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "X";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "09")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "X";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "10")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "X";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "11")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "X";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "12")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "X";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "13")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "X";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "14")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "X";
                txt_ataque.Text = "";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "15")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "X";
                txt_otro.Text = "";
            }
            if (ddl_naturales3.SelectedValue.ToString() == "16")
            {
                txt_accidentetransito.Text = "";
                txt_sismo.Text = "";
                txt_maremoto.Text = "";
                txt_erupcion.Text = "";
                txt_huracan.Text = "";
                txt_inundaciones.Text = "";
                txt_avalancha.Text = "";
                txt_deslizamiento.Text = "";
                txt_incendionat.Text = "";
                txt_explosion.Text = "";
                txt_masacre.Text = "";
                txt_mina.Text = "";
                txt_combate.Text = "";
                txt_incendio.Text = "";
                txt_ataque.Text = "";
                txt_otro.Text = "X";
            }

            if (ddl_tiposerv4.SelectedValue.ToString() == "3")
            {
                TS1.Text = "X";
                TS2.Text = "";
                TS3.Text = "";
                TS4.Text = "";
                TS5.Text = "";
                TS6.Text = "";
                TS7.Text = "";
            }
            if (ddl_tiposerv4.SelectedValue.ToString() == "4")
            {
                TS1.Text = "";
                TS2.Text = "X";
                TS3.Text = "";
                TS4.Text = "";
                TS5.Text = "";
                TS6.Text = "";
                TS7.Text = "";
            }
            if (ddl_tiposerv4.SelectedValue.ToString() == "5")
            {
                TS1.Text = "";
                TS2.Text = "";
                TS3.Text = "X";
                TS4.Text = "";
                TS5.Text = "";
                TS6.Text = "";
                TS7.Text = "";
            }
            if (ddl_tiposerv4.SelectedValue.ToString() == "6")
            {
                TS1.Text = "";
                TS2.Text = "";
                TS3.Text = "";
                TS4.Text = "X";
                TS5.Text = "";
                TS6.Text = "";
                TS7.Text = "";
            }
            if (ddl_tiposerv4.SelectedValue.ToString() == "7")
            {
                TS1.Text = "";
                TS2.Text = "";
                TS3.Text = "";
                TS4.Text = "";
                TS5.Text = "X";
                TS6.Text = "";
                TS7.Text = "";
            }
            if (ddl_tiposerv4.SelectedValue.ToString() == "8")
            {
                TS1.Text = "";
                TS2.Text = "";
                TS3.Text = "";
                TS4.Text = "";
                TS5.Text = "";
                TS6.Text = "X";
                TS7.Text = "";
            }
            if (ddl_tiposerv4.SelectedValue.ToString() == "9")
            {
                TS1.Text = "";
                TS2.Text = "";
                TS3.Text = "";
                TS4.Text = "";
                TS5.Text = "";
                TS6.Text = "";
                TS7.Text = "X";
            }

             //VARIABLE TIPO DOCUMENTO PARA EL PROPIETARIO
            if (ddl_tipodoc5.SelectedValue.ToString() == "CC")
            {
                txt_tipodocpropietariocc.Text = "X";
                txt_tipodocpropietariocd.Text = "";
                txt_tipodocpropietariopa.Text = "";
                txt_tipodocpropietarionit.Text = "";
                txt_tipodocpropietarioti.Text = "";
                txt_tipodocpropietariorc.Text = "";
            }
            if (ddl_tipodoc5.SelectedValue.ToString() == "CD")
            {
                txt_tipodocpropietariocc.Text = "";
                txt_tipodocpropietariocd.Text = "X";
                txt_tipodocpropietariopa.Text = "";
                txt_tipodocpropietarionit.Text = "";
                txt_tipodocpropietarioti.Text = "";
                txt_tipodocpropietariorc.Text = "";
            }
            if (ddl_tipodoc5.SelectedValue.ToString() == "PA")
            {
                txt_tipodocpropietariocc.Text = "";
                txt_tipodocpropietariocd.Text = "";
                txt_tipodocpropietariopa.Text = "X";
                txt_tipodocpropietarionit.Text = "";
                txt_tipodocpropietarioti.Text = "";
                txt_tipodocpropietariorc.Text = "";
            }
            if (ddl_tipodoc5.SelectedValue.ToString() == "NIT")
            {
                txt_tipodocpropietariocc.Text = "";
                txt_tipodocpropietariocd.Text = "";
                txt_tipodocpropietariopa.Text = "";
                txt_tipodocpropietarionit.Text = "X";
                txt_tipodocpropietarioti.Text = "";
                txt_tipodocpropietariorc.Text = "";
            }
            if (ddl_tipodoc5.SelectedValue.ToString() == "TI")
            {
                txt_tipodocpropietariocc.Text = "";
                txt_tipodocpropietariocd.Text = "";
                txt_tipodocpropietariopa.Text = "";
                txt_tipodocpropietarionit.Text = "";
                txt_tipodocpropietarioti.Text = "X";
                txt_tipodocpropietariorc.Text = "";
            }
            if (ddl_tipodoc5.SelectedValue.ToString() == "RC")
            {
                txt_tipodocpropietariocc.Text = "";
                txt_tipodocpropietariocd.Text = "";
                txt_tipodocpropietariopa.Text = "";
                txt_tipodocpropietarionit.Text = "";
                txt_tipodocpropietarioti.Text = "";
                txt_tipodocpropietariorc.Text = "X";
            }

            //VARIABLE TIPO DOCUMENTO PARA EL CONDUCTOR 
            if (ddl_tipodoc6.SelectedValue.ToString() == "CC")
            {
                txt_tipodocconductorcc.Text = "X";
                txt_tipodocconductorce.Text = "";
                txt_tipodocconductorpa.Text = "";
                txt_tipodocconductorti.Text = "";
                txt_tipodocconductorrc.Text = "";
                txt_tipodocconductoras.Text = "";
            }
            if (ddl_tipodoc6.SelectedValue.ToString() == "CE")
            {
                txt_tipodocconductorcc.Text = "";
                txt_tipodocconductorce.Text = "X";
                txt_tipodocconductorpa.Text = "";
                txt_tipodocconductorti.Text = "";
                txt_tipodocconductorrc.Text = "";
                txt_tipodocconductoras.Text = "";
            }
            if (ddl_tipodoc6.SelectedValue.ToString() == "PA")
            {
                txt_tipodocconductorcc.Text = "";
                txt_tipodocconductorce.Text = "";
                txt_tipodocconductorpa.Text = "X";
                txt_tipodocconductorti.Text = "";
                txt_tipodocconductorrc.Text = "";
                txt_tipodocconductoras.Text = "";
            }
            if (ddl_tipodoc6.SelectedValue.ToString() == "TI")
            {
                txt_tipodocconductorcc.Text = "";
                txt_tipodocconductorce.Text = "";
                txt_tipodocconductorpa.Text = "";
                txt_tipodocconductorti.Text = "X";
                txt_tipodocconductorrc.Text = "";
                txt_tipodocconductoras.Text = "";
            }
            if (ddl_tipodoc6.SelectedValue.ToString() == "RC")
            {
                txt_tipodocconductorcc.Text = "";
                txt_tipodocconductorce.Text = "";
                txt_tipodocconductorpa.Text = "";
                txt_tipodocconductorti.Text = "";
                txt_tipodocconductorrc.Text = "X";
                txt_tipodocconductoras.Text = "";
            }
            if (ddl_tipodoc6.SelectedValue.ToString() == "AS")
            {
                txt_tipodocconductorcc.Text = "";
                txt_tipodocconductorce.Text = "";
                txt_tipodocconductorpa.Text = "";
                txt_tipodocconductorti.Text = "";
                txt_tipodocconductorrc.Text = "";
                txt_tipodocconductoras.Text = "X";
            }

             //VARIABLE TIPO DOCUMENTO PARA EL PROFESIONAL
            if (ddl_tipodoc9.SelectedValue.ToString() == "CC")
            {
                txt_tipodoccc9.Text = "X";
                txt_tipodocce9.Text = "";
                txt_tipodocpa9.Text = "";
                txt_tipodocti9.Text = "";
                txt_tipodocrc9.Text = "";
                txt_tipodocas9.Text = "";
            }
            if (ddl_tipodoc9.SelectedValue.ToString() == "CE")
            {
                 txt_tipodoccc9.Text = "";
                txt_tipodocce9.Text = "X";
                txt_tipodocpa9.Text = "";
                txt_tipodocti9.Text = "";
                txt_tipodocrc9.Text = "";
                txt_tipodocas9.Text = "";
            }
            if (ddl_tipodoc9.SelectedValue.ToString() == "PA")
            {
                 txt_tipodoccc9.Text = "";
                txt_tipodocce9.Text = "";
                txt_tipodocpa9.Text = "X";
                txt_tipodocti9.Text = "";
                txt_tipodocrc9.Text = "";
                txt_tipodocas9.Text = "";
            }
            if (ddl_tipodoc9.SelectedValue.ToString() == "TI")
            {
                 txt_tipodoccc9.Text = "";
                txt_tipodocce9.Text = "";
                txt_tipodocpa9.Text = "";
                txt_tipodocti9.Text = "X";
                txt_tipodocrc9.Text = "";
                txt_tipodocas9.Text = "";
            }
            if (ddl_tipodoc9.SelectedValue.ToString() == "RC")
            {
                 txt_tipodoccc9.Text = "";
                txt_tipodocce9.Text = "";
                txt_tipodocpa9.Text = "";
                txt_tipodocti9.Text = "";
                txt_tipodocrc9.Text = "X";
                txt_tipodocas9.Text = "";
            }
            if (ddl_tipodoc9.SelectedValue.ToString() == "AS")
            {
                 txt_tipodoccc9.Text = "";
                txt_tipodocce9.Text = "";
                txt_tipodocpa9.Text = "";
                txt_tipodocti9.Text = "";
                txt_tipodocrc9.Text = "";
                txt_tipodocas9.Text = "X";
            }

            try
            {
                string query = "INSERT INTO FURIPS(NumRadicado, FechaRadicado, RespGlosa, Consecutivo, NumRadAnt, NumFactura, RazonSocial, CodHabilitacion, Nit, Apellido1, Apellido2, Nombre1, Nombre2, TipoDoc, NumDoc, FechaNac, Sexo, Direccion, Dpto1, CodigoDpto, Telefono, Ciudad1, CodCiudad, CondicionAccidentado, TD_CC, TD_CE, TD_PA, TD_TI, TD_RC, TD_AS, TD_MS, ca_conductor, ca_peaton, ca_ocupante, ca_ciclista, NaturalezaEvento, AccidenteTransito, Sismo, Maremoto, Erupcion, Huracan, Inundaciones, Avalancha, Deslizamiento, IncendioNatural, Explosion, Masacre, MinaAntipersonal, Combate, Incendio, AtaqueMncpio, Otros, DescripEvento, DirOcurrencia, FechaOcurerncia, HoraOcurrencia, Dpto2, DptoOcurrenciaCod, Ciudad2, MuniOcurrenciaCod, Zona, ZonaU, ZonaR, DesBreve, EstadoAseg, Asegurado, NoAsegurado, Fantasma, PolizaFalsa, Fuga," +
                               "Marca, Placa, CodAseguradora, NumPolizaSOAT, IntervencionAutoridad, IA_SI, IA_NO,  FechaInicioVig, FechaFinalVig, CobroExcedente, CE_SI, CE_NO, TipoServicio, TS1, TS2, TS3, TS4, TS5, TS6, TS7, Apellido1Pro, Appelido2Pro, Nombre1Pro, Nombre2Pro, TipoDocProp, TDPV_CC, TDPV_CD, TDPV_PA, TDPV_NIT, TDPV_TI, TDPV_RC, NumDocPro, DirResPro, NomDptoResProf, CodDptoResPro, TelResPro, NomMuniresPro, CodMuniResPro, Apellido1Conductor, Apellido2Conductor, Nombre1Conductor, Nombre2Conductor, TipoDocConductor, TDC_CC, TDC_CE, TDC_PA, TDC_TI, TDC_RC, TDC_AS, NumDocConductor, DirConductor, DptoConductor, CodDptoConductor, TelResConductor, MuniConductor, CodMuniConductor, TipoReferencia, TRR, TRO, FechaRemision, HoraSalida, PrestaRemite, CodInscripcion, ProfRemite, CargoPersonaRemite, FechaIngreso, HoraIngreso, PrestadorRecibe, CodInscripcion2, ProfRecibe, CargoPersonaRecibe," +
                               "PlacaMovil, TransVictimaSitio, TransVictimaFinRecorrido, TipoAmbulancia, TT_AB, TT_AM, ZonaRecogeVictima, ZonaRV_U, ZonaRV_R, FechaIngreso2, HoraIngreso2, FechaEgreso, HoraEgreso, DxIngreso, DxEgreso, DxIngreso1, DxEgreso1, DxIngreso2, DxEgreso2, Apellido1Prof, Apellido2Prof, Nombre1Prof, Nombre2Prof, TipoDocProf, TDP_CC, TDP_CE, TDP_PA, TDP_TI, TDP_RC, TDP_AS, NumDocProf, RegistroMedico, TotalFacturado, TotalReclamado, TotalFacturadoTrans, TotalReclamadoTrans, NumFolios) VALUES('" + this.txt_numradicado.Text + "', '" + this.txt_fecharadicacion.Text + "', '" + this.txt_respglosa.Text + "', '" + this.txt_NumeroConsecutivo.Text + "', '" + this.txt_radianterior.Text + "', '" + this.txt_numfactura.Text + "', '" + this.txt_razon1.Text + "', '" + this.txt_codhabil1.Text + "', '" + this.txt_nit1.Text + "', '" + this.txt_apellido12.Text + "', '" + this.txt_apellido22.Text + "', '" + this.txt_nombre12.Text + "', '" + this.txt_nombre22.Text + "', '" + this.ddl_tipodoc2.SelectedValue + "', '" + this.txt_documento2.Text + "', '" + this.txt_fechanaci2.Text + "', '" + this.ddl_sexo2.SelectedItem + "', '" + this.txt_direccion2.Text + "', '" + this.ddl_departamento2.SelectedItem + "', '" + this.ddl_departamento2.SelectedValue + "', '" + this.txt_telefono2.Text + "', '" + this.ddl_municipio2.SelectedItem + "', '"+this.ddl_municipio2.SelectedValue+"'," +
                               " '" + this.ddl_condicion2.SelectedValue + "', '" + this.txt_tipodocvictimacc.Text + "', '" + this.txt_tipodocvictimace.Text + "', '" + this.txt_tipodocvictimapa.Text + "', '" + this.txt_tipodocvictimati.Text + "', '" + this.txt_tipodocvictimarc.Text + "', '" + this.txt_tipodocvictimaas.Text + "', '" + this.txt_tipodocvictimams.Text + "', '" + this.txt_cconductor.Text + "', '" + this.txt_cpeaton.Text + "', '" + this.txt_cocupante.Text + "', '" + this.txt_cciclista.Text + "', '" + this.ddl_naturales3.SelectedValue + "', '" + this.txt_accidentetransito.Text + "', '" + this.txt_sismo.Text + "', '" + this.txt_maremoto.Text + "', '" + this.txt_erupcion.Text + "', '" + this.txt_huracan.Text + "', '" + this.txt_inundaciones.Text + "', '" + this.txt_avalancha.Text + "', '" + this.txt_deslizamiento.Text + "'," +
                               " '" + this.txt_incendionat.Text + "', '" + this.txt_explosion.Text + "', '" + this.txt_masacre.Text + "', '" + this.txt_mina.Text + "', '" + this.txt_combate.Text + "', '" + this.txt_incendio.Text + "', '" + this.txt_ataque.Text + "', '" + this.txt_otro.Text + "', '" + this.txt_cual3.Text + "', '" + this.txt_ocurrencia3.Text + "', '" + this.txt_fechaevento3.Text + "', '" + this.txt_hora3.Text + "', '" + this.ddl_departamento3.SelectedItem + "', '" + this.ddl_departamento3.SelectedValue + "', '" + this.ddl_municipio3.SelectedItem + "', '" + this.ddl_municipio3.SelectedValue + "', '" + this.txt_zonaIII.Text + "', '" + this.txt_zonaUIII.Text + "', '" + this.txt_zonaRIII.Text + "', '" + this.txt_descripcion3.Text + "', '" + this.txt_estadoAsegurado.Text + "', '" + this.txt_asegurado.Text + "', '" + this.txt_noasegurado.Text + "', '" + this.txt_fantasma.Text + "'," +
                               " '" + this.txt_polizafalsa.Text + "', '" + this.txt_fuga.Text + "', '" + this.txt_marca4.Text + "', '" + this.txt_placa4.Text + "', '" + this.ddl_codaseguradora4.SelectedValue + "', '" + this.txt_numpoliza4.Text + "', '" + this.txt_interpolicia.Text + "', '" + this.txt_interpolsi.Text + "', '" + this.txt_interpolno.Text + "', '" + this.txt_fechadesde4.Text + "', '" + this.txt_fechahasta4.Text + "', '" + this.txt_cobroexcedente.Text + "', '" + this.txt_cobrosi4.Text + "', '" + this.txt_cobrono4.Text + "', '" + this.ddl_tiposerv4.SelectedValue + "', '" + this.TS1.Text + "', '" + this.TS2.Text + "', '" + this.TS3.Text + "', '" + this.TS4.Text + "', '" + this.TS5.Text + "', '" + this.TS6.Text + "', '" + this.TS7.Text + "', '" + this.txt_apellido15.Text + "', '" + this.txt_apellido25.Text + "', '" + this.txt_nombre15.Text + "', '" + this.txt_nombre25.Text + "'," +
                               " '" + this.ddl_tipodoc5.SelectedValue + "', '" + this.txt_tipodocpropietariocc.Text + "', '" + this.txt_tipodocpropietariocd.Text + "', '" + this.txt_tipodocpropietariopa.Text + "', '" + this.txt_tipodocpropietarionit.Text + "', '" + this.txt_tipodocpropietarioti.Text + "', '" + this.txt_tipodocpropietariorc.Text + "', '" + this.txt_numdoc5.Text + "', '" + this.txt_direccion5.Text + "', '" + this.ddl_departamento5.SelectedItem + "', '" + this.ddl_departamento5.SelectedValue + "', '" + this.txt_telefono5.Text + "', '" + this.ddl_municipio5.SelectedItem + "', '" + this.ddl_municipio5.SelectedValue + "', '" + this.txt_apellido16.Text + "', '" + this.txt_apellido26.Text + "', '" + this.txt_nombre16.Text + "', '" + this.txt_nombre26.Text + "', '" + this.ddl_tipodoc6.SelectedValue + "', '" + this.txt_tipodocconductorcc.Text + "', '" + this.txt_tipodocconductorce.Text + "'," +
                               " '" + this.txt_tipodocconductorpa.Text + "', '" + this.txt_tipodocconductorti.Text + "', '" + this.txt_tipodocconductorrc.Text + "', '" + this.txt_tipodocconductoras.Text + "', '" + this.txt_documento6.Text + "', '" + this.txt_direccion6.Text + "', '" + this.ddl_departamento6.SelectedItem + "', '" + this.ddl_departamento6.SelectedValue + "', '" + this.txt_telefono6.Text + "', '" + this.ddl_municipio6.SelectedItem + "', '" + this.ddl_municipio6.SelectedValue + "', '" + this.txt_tiporeferencia.Text + "', '" + this.txt_remision7.Text + "', '" + this.txt_orden7.Text + "', '" + this.txt_fecharemision7.Text + "', '" + this.txt_horaremision7.Text + "', '" + this.txt_prestaremite7.Text + "', '" + this.txt_codinscripcion7.Text + "', '" + this.txt_proremite7.Text + "', '" + this.txt_cargo7a.Text + "', '" + this.txt_fechaaceptacion7.Text + "', '" + this.txt_horaaceptacion7.Text + "'," +
                               " '" + this.txt_prestarecibe7.Text + "', '" + this.txt_codinscripcion7b.Text + "', '" + this.txt_prorecibe7.Text + "', '" + this.txt_cargo7b.Text + "', '" + this.txt_tipoAmbulancia.Text + "', '" + this.txt_placas8.Text + "', '" + this.txt_transdesde8.Text + "', '" + this.txt_transhasta8.Text + "', '" + this.txt_ambubasica8.Text + "', '" + this.txt_ambumedicalizada8.Text + "', '" + this.txt_zonavictima.Text + "', '" + this.txt_zonaurbanovictima.Text + "', '" + this.txt_zonaruralvictima.Text + "', '" + this.txt_fechaingreso9.Text + "', '" + this.txt_horaingreso9.Text + "', '" + this.txt_fechasalida9.Text + "', '" + this.txt_horasalida9.Text + "', '" + this.txt_coddx1ingreso9.Text + "', '" + this.txt_coddx1salida9.Text + "', '" + this.txt_otrodxingreso29.Text + "', '" + this.txt_otrodxegreso29.Text + "', '" + this.txt_otrodxingreso39.Text + "', '" + this.txt_otrodxsalida39.Text + "', '" + this.txt_apellido1medico9.Text + "', '" + this.txt_apellido2medico9.Text + "', '" + this.txt_nombre1medico9.Text + "', '" + this.txt_nombre2medico9.Text + "', '" + this.ddl_tipodoc9.SelectedValue + "', '" + this.txt_tipodoccc9.Text + "', '" + this.txt_tipodocce9.Text + "', '" + this.txt_tipodocpa9.Text + "', '" + this.txt_tipodocti9.Text + "', '" + this.txt_tipodocrc9.Text + "', '" + this.txt_tipodocas9.Text + "'," +
                               " '" + this.txt_documento9.Text + "', '" + this.txt_numregistro9.Text + "', '" + this.txt_vrfacturado10.Text + "', '" + this.txt_vrfosyga10.Text + "', '" + this.txt_vr2facturado10.Text + "', '" + this.txt_vr2fosyga10.Text + "', '" + this.txt_totalfolios.Text + "')";

                if (Datos.insertar(query))
                {
                    lbl_resultado.Text = "No se modificó la información, verifique";
                }
                else
                {
                    Response.Redirect("Furips.aspx");
                }
            }
            catch(Exception ex)
            {
                lbl_resultado.Text = ex.ToString();
            }
        }

        protected void btn_buscarVictima_Click(object sender, EventArgs e)
        {
            string sqlPaciente = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_documento2.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sqlPaciente, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txt_apellido12.Text = leer["Apellido1"].ToString();
                txt_apellido22.Text = leer["Apellido2"].ToString();
                txt_nombre12.Text = leer["Nombre1"].ToString();
                txt_nombre22.Text = leer["Nombre2"].ToString();
                ddl_tipodoc2.ClearSelection();
                ddl_tipodoc2.Items.FindByValue(leer["TipoDocumento"].ToString()).Selected = true;
                ddl_sexo2.ClearSelection();
                ddl_sexo2.Items.FindByText(leer["Sexo"].ToString()).Selected = true;
                txt_fechanaci2.Text = leer["FechaNacimiento"].ToString();
                txt_direccion2.Text = leer["Direccion"].ToString();
                txt_telefono2.Text = leer["Telefono"].ToString();
                ddl_departamento2.ClearSelection();
                ddl_departamento2.Items.FindByText(leer["Departamento"].ToString());
            }
            conexion.Close();
        }

        protected void btn_buscarPropietario_Click(object sender, EventArgs e)
        {
            string sqlPaciente = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_numdoc5.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sqlPaciente, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txt_apellido15.Text = leer["Apellido1"].ToString();
                txt_apellido25.Text = leer["Apellido2"].ToString();
                txt_nombre15.Text = leer["Nombre1"].ToString();
                txt_nombre25.Text = leer["Nombre2"].ToString();
                ddl_tipodoc5.ClearSelection();
                ddl_tipodoc5.Items.FindByValue(leer["TipoDocumento"].ToString()).Selected = true;
                ddl_tipodoc5.ClearSelection();
                txt_direccion5.Text = leer["Direccion"].ToString();
                txt_telefono5.Text = leer["Telefono"].ToString();
                
            }
            conexion.Close();
        }

        protected void btn_buscarCondulctor_Click(object sender, EventArgs e)
        {
            string sqlPaciente = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_documento6.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sqlPaciente, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txt_apellido16.Text = leer["Apellido1"].ToString();
                txt_apellido26.Text = leer["Apellido2"].ToString();
                txt_nombre16.Text = leer["Nombre1"].ToString();
                txt_nombre26.Text = leer["Nombre2"].ToString();
                ddl_tipodoc6.ClearSelection();
                ddl_tipodoc6.Items.FindByValue(leer["TipoDocumento"].ToString()).Selected = true;
                txt_direccion6.Text = leer["Direccion"].ToString();
                txt_telefono6.Text = leer["Telefono"].ToString();
               }
            conexion.Close();
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {
            ////traigo el ultimo consecutivo

            //string sql = "SELECT * FROM Consecutivos WHERE TipoCont='12'";
            //SqlConnection conexion = new SqlConnection(ruta);
            //SqlCommand comando = new SqlCommand(sql, conexion);
            //conexion.Open();

            //SqlDataReader leer = comando.ExecuteReader();

            //if (leer.Read() == true)
            //{
            //    txt_NumeroConsecutivo.Text = leer["NumActual"].ToString();
            //}

            //int consecutivo = Convert.ToInt32(txt_NumeroConsecutivo.Text);
            //txt_NumeroConsecutivo.Text = (consecutivo + 1).ToString();

            ////PREPARAMOS LOS DATOS PARA GUARDAR
            ////VARIABLE TIPO DE DOCUMENTO VICTIMA O PACIENTE, ES LA MISMA VAINA
            //if (ddl_tipodoc2.SelectedValue.ToString() == "CC")
            //{
            //    txt_tipodocvictimacc.Text = "X";
            //    txt_tipodocvictimace.Text = "";
            //    txt_tipodocvictimapa.Text = "";
            //    txt_tipodocvictimati.Text = "";
            //    txt_tipodocvictimarc.Text = "";
            //    txt_tipodocvictimaas.Text = "";
            //    txt_tipodocvictimams.Text = "";
            //}
            //if (ddl_tipodoc2.SelectedValue.ToString() == "CE")
            //{
            //    txt_tipodocvictimacc.Text = "";
            //    txt_tipodocvictimace.Text = "X";
            //    txt_tipodocvictimapa.Text = "";
            //    txt_tipodocvictimati.Text = "";
            //    txt_tipodocvictimarc.Text = "";
            //    txt_tipodocvictimaas.Text = "";
            //    txt_tipodocvictimams.Text = "";
            //}
            //if (ddl_tipodoc2.SelectedValue.ToString() == "PA")
            //{
            //    txt_tipodocvictimacc.Text = "";
            //    txt_tipodocvictimace.Text = "";
            //    txt_tipodocvictimapa.Text = "X";
            //    txt_tipodocvictimati.Text = "";
            //    txt_tipodocvictimarc.Text = "";
            //    txt_tipodocvictimaas.Text = "";
            //    txt_tipodocvictimams.Text = "";
            //}
            //if (ddl_tipodoc2.SelectedValue.ToString() == "TI")
            //{
            //    txt_tipodocvictimacc.Text = "";
            //    txt_tipodocvictimace.Text = "";
            //    txt_tipodocvictimapa.Text = "";
            //    txt_tipodocvictimati.Text = "X";
            //    txt_tipodocvictimarc.Text = "";
            //    txt_tipodocvictimaas.Text = "";
            //    txt_tipodocvictimams.Text = "";
            //}
            //if (ddl_tipodoc2.SelectedValue.ToString() == "RC")
            //{
            //    txt_tipodocvictimacc.Text = "";
            //    txt_tipodocvictimace.Text = "";
            //    txt_tipodocvictimapa.Text = "";
            //    txt_tipodocvictimati.Text = "";
            //    txt_tipodocvictimarc.Text = "X";
            //    txt_tipodocvictimaas.Text = "";
            //    txt_tipodocvictimams.Text = "";
            //}
            //if (ddl_tipodoc2.SelectedValue.ToString() == "AS")
            //{
            //    txt_tipodocvictimacc.Text = "";
            //    txt_tipodocvictimace.Text = "";
            //    txt_tipodocvictimapa.Text = "";
            //    txt_tipodocvictimati.Text = "";
            //    txt_tipodocvictimarc.Text = "";
            //    txt_tipodocvictimaas.Text = "X";
            //    txt_tipodocvictimams.Text = "";
            //}
            //if (ddl_tipodoc2.SelectedValue.ToString() == "MS")
            //{
            //    txt_tipodocvictimacc.Text = "";
            //    txt_tipodocvictimace.Text = "";
            //    txt_tipodocvictimapa.Text = "";
            //    txt_tipodocvictimati.Text = "";
            //    txt_tipodocvictimarc.Text = "";
            //    txt_tipodocvictimaas.Text = "";
            //    txt_tipodocvictimams.Text = "X";
            //}

            ////CONDICION ACCIDENTADO
            //if (ddl_condicion2.SelectedValue.ToString() == "1")
            //{
            //    txt_cconductor.Text = "X";
            //    txt_cpeaton.Text = "";
            //    txt_cocupante.Text = "";
            //    txt_cciclista.Text = "";
            //}
            //if (ddl_condicion2.SelectedValue.ToString() == "2")
            //{
            //    txt_cconductor.Text = "";
            //    txt_cpeaton.Text = "X";
            //    txt_cocupante.Text = "";
            //    txt_cciclista.Text = "";
            //}
            //if (ddl_condicion2.SelectedValue.ToString() == "3")
            //{
            //    txt_cconductor.Text = "";
            //    txt_cpeaton.Text = "";
            //    txt_cocupante.Text = "X";
            //    txt_cciclista.Text = "";
            //}
            //if (ddl_condicion2.SelectedValue.ToString() == "4")
            //{
            //    txt_cconductor.Text = "";
            //    txt_cpeaton.Text = "";
            //    txt_cocupante.Text = "";
            //    txt_cciclista.Text = "X";
            //}

            ////NATURALEZA EVENTO
            //if (ddl_naturales3.SelectedValue.ToString() == "01")
            //{
            //    txt_accidentetransito.Text = "X";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";

            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "02")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "X";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "03")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "X";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "04")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "X";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "05")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "X";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "06")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "X";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "07")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "X";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "08")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "X";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "09")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "X";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "10")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "X";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "11")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "X";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "12")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "X";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "13")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "X";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "14")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "X";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "15")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "X";
            //    txt_otro.Text = "";
            //}
            //if (ddl_naturales3.SelectedValue.ToString() == "16")
            //{
            //    txt_accidentetransito.Text = "";
            //    txt_sismo.Text = "";
            //    txt_maremoto.Text = "";
            //    txt_erupcion.Text = "";
            //    txt_huracan.Text = "";
            //    txt_inundaciones.Text = "";
            //    txt_avalancha.Text = "";
            //    txt_deslizamiento.Text = "";
            //    txt_incendionat.Text = "";
            //    txt_explosion.Text = "";
            //    txt_masacre.Text = "";
            //    txt_mina.Text = "";
            //    txt_combate.Text = "";
            //    txt_incendio.Text = "";
            //    txt_ataque.Text = "";
            //    txt_otro.Text = "X";
            //}

            //if (ddl_tiposerv4.SelectedValue.ToString() == "3")
            //{
            //    TS1.Text = "X";
            //    TS2.Text = "";
            //    TS3.Text = "";
            //    TS4.Text = "";
            //    TS5.Text = "";
            //    TS6.Text = "";
            //    TS7.Text = "";
            //}
            //if (ddl_tiposerv4.SelectedValue.ToString() == "4")
            //{
            //    TS1.Text = "";
            //    TS2.Text = "X";
            //    TS3.Text = "";
            //    TS4.Text = "";
            //    TS5.Text = "";
            //    TS6.Text = "";
            //    TS7.Text = "";
            //}
            //if (ddl_tiposerv4.SelectedValue.ToString() == "5")
            //{
            //    TS1.Text = "";
            //    TS2.Text = "";
            //    TS3.Text = "X";
            //    TS4.Text = "";
            //    TS5.Text = "";
            //    TS6.Text = "";
            //    TS7.Text = "";
            //}
            //if (ddl_tiposerv4.SelectedValue.ToString() == "6")
            //{
            //    TS1.Text = "";
            //    TS2.Text = "";
            //    TS3.Text = "";
            //    TS4.Text = "X";
            //    TS5.Text = "";
            //    TS6.Text = "";
            //    TS7.Text = "";
            //}
            //if (ddl_tiposerv4.SelectedValue.ToString() == "7")
            //{
            //    TS1.Text = "";
            //    TS2.Text = "";
            //    TS3.Text = "";
            //    TS4.Text = "";
            //    TS5.Text = "X";
            //    TS6.Text = "";
            //    TS7.Text = "";
            //}
            //if (ddl_tiposerv4.SelectedValue.ToString() == "8")
            //{
            //    TS1.Text = "";
            //    TS2.Text = "";
            //    TS3.Text = "";
            //    TS4.Text = "";
            //    TS5.Text = "";
            //    TS6.Text = "X";
            //    TS7.Text = "";
            //}
            //if (ddl_tiposerv4.SelectedValue.ToString() == "9")
            //{
            //    TS1.Text = "";
            //    TS2.Text = "";
            //    TS3.Text = "";
            //    TS4.Text = "";
            //    TS5.Text = "";
            //    TS6.Text = "";
            //    TS7.Text = "X";
            //}

            ////VARIABLE TIPO DOCUMENTO PARA EL PROPIETARIO
            //if (ddl_tipodoc5.SelectedValue.ToString() == "CC")
            //{
            //    txt_tipodocpropietariocc.Text = "X";
            //    txt_tipodocpropietariocd.Text = "";
            //    txt_tipodocpropietariopa.Text = "";
            //    txt_tipodocpropietarionit.Text = "";
            //    txt_tipodocpropietarioti.Text = "";
            //    txt_tipodocpropietariorc.Text = "";
            //}
            //if (ddl_tipodoc5.SelectedValue.ToString() == "CD")
            //{
            //    txt_tipodocpropietariocc.Text = "";
            //    txt_tipodocpropietariocd.Text = "X";
            //    txt_tipodocpropietariopa.Text = "";
            //    txt_tipodocpropietarionit.Text = "";
            //    txt_tipodocpropietarioti.Text = "";
            //    txt_tipodocpropietariorc.Text = "";
            //}
            //if (ddl_tipodoc5.SelectedValue.ToString() == "PA")
            //{
            //    txt_tipodocpropietariocc.Text = "";
            //    txt_tipodocpropietariocd.Text = "";
            //    txt_tipodocpropietariopa.Text = "X";
            //    txt_tipodocpropietarionit.Text = "";
            //    txt_tipodocpropietarioti.Text = "";
            //    txt_tipodocpropietariorc.Text = "";
            //}
            //if (ddl_tipodoc5.SelectedValue.ToString() == "NIT")
            //{
            //    txt_tipodocpropietariocc.Text = "";
            //    txt_tipodocpropietariocd.Text = "";
            //    txt_tipodocpropietariopa.Text = "";
            //    txt_tipodocpropietarionit.Text = "X";
            //    txt_tipodocpropietarioti.Text = "";
            //    txt_tipodocpropietariorc.Text = "";
            //}
            //if (ddl_tipodoc5.SelectedValue.ToString() == "TI")
            //{
            //    txt_tipodocpropietariocc.Text = "";
            //    txt_tipodocpropietariocd.Text = "";
            //    txt_tipodocpropietariopa.Text = "";
            //    txt_tipodocpropietarionit.Text = "";
            //    txt_tipodocpropietarioti.Text = "X";
            //    txt_tipodocpropietariorc.Text = "";
            //}
            //if (ddl_tipodoc5.SelectedValue.ToString() == "RC")
            //{
            //    txt_tipodocpropietariocc.Text = "";
            //    txt_tipodocpropietariocd.Text = "";
            //    txt_tipodocpropietariopa.Text = "";
            //    txt_tipodocpropietarionit.Text = "";
            //    txt_tipodocpropietarioti.Text = "";
            //    txt_tipodocpropietariorc.Text = "X";
            //}

            ////VARIABLE TIPO DOCUMENTO PARA EL CONDUCTOR 
            //if (ddl_tipodoc6.SelectedValue.ToString() == "CC")
            //{
            //    txt_tipodocconductorcc.Text = "X";
            //    txt_tipodocconductorce.Text = "";
            //    txt_tipodocconductorpa.Text = "";
            //    txt_tipodocconductorti.Text = "";
            //    txt_tipodocconductorrc.Text = "";
            //    txt_tipodocconductoras.Text = "";
            //}
            //if (ddl_tipodoc6.SelectedValue.ToString() == "CE")
            //{
            //    txt_tipodocconductorcc.Text = "";
            //    txt_tipodocconductorce.Text = "X";
            //    txt_tipodocconductorpa.Text = "";
            //    txt_tipodocconductorti.Text = "";
            //    txt_tipodocconductorrc.Text = "";
            //    txt_tipodocconductoras.Text = "";
            //}
            //if (ddl_tipodoc6.SelectedValue.ToString() == "PA")
            //{
            //    txt_tipodocconductorcc.Text = "";
            //    txt_tipodocconductorce.Text = "";
            //    txt_tipodocconductorpa.Text = "X";
            //    txt_tipodocconductorti.Text = "";
            //    txt_tipodocconductorrc.Text = "";
            //    txt_tipodocconductoras.Text = "";
            //}
            //if (ddl_tipodoc6.SelectedValue.ToString() == "TI")
            //{
            //    txt_tipodocconductorcc.Text = "";
            //    txt_tipodocconductorce.Text = "";
            //    txt_tipodocconductorpa.Text = "";
            //    txt_tipodocconductorti.Text = "X";
            //    txt_tipodocconductorrc.Text = "";
            //    txt_tipodocconductoras.Text = "";
            //}
            //if (ddl_tipodoc6.SelectedValue.ToString() == "RC")
            //{
            //    txt_tipodocconductorcc.Text = "";
            //    txt_tipodocconductorce.Text = "";
            //    txt_tipodocconductorpa.Text = "";
            //    txt_tipodocconductorti.Text = "";
            //    txt_tipodocconductorrc.Text = "X";
            //    txt_tipodocconductoras.Text = "";
            //}
            //if (ddl_tipodoc6.SelectedValue.ToString() == "AS")
            //{
            //    txt_tipodocconductorcc.Text = "";
            //    txt_tipodocconductorce.Text = "";
            //    txt_tipodocconductorpa.Text = "";
            //    txt_tipodocconductorti.Text = "";
            //    txt_tipodocconductorrc.Text = "";
            //    txt_tipodocconductoras.Text = "X";
            //}

            ////VARIABLE TIPO DOCUMENTO PARA EL PROFESIONAL
            //if (ddl_tipodoc9.SelectedValue.ToString() == "CC")
            //{
            //    txt_tipodoccc9.Text = "X";
            //    txt_tipodocce9.Text = "";
            //    txt_tipodocpa9.Text = "";
            //    txt_tipodocti9.Text = "";
            //    txt_tipodocrc9.Text = "";
            //    txt_tipodocas9.Text = "";
            //}
            //if (ddl_tipodoc9.SelectedValue.ToString() == "CE")
            //{
            //    txt_tipodoccc9.Text = "";
            //    txt_tipodocce9.Text = "X";
            //    txt_tipodocpa9.Text = "";
            //    txt_tipodocti9.Text = "";
            //    txt_tipodocrc9.Text = "";
            //    txt_tipodocas9.Text = "";
            //}
            //if (ddl_tipodoc9.SelectedValue.ToString() == "PA")
            //{
            //    txt_tipodoccc9.Text = "";
            //    txt_tipodocce9.Text = "";
            //    txt_tipodocpa9.Text = "X";
            //    txt_tipodocti9.Text = "";
            //    txt_tipodocrc9.Text = "";
            //    txt_tipodocas9.Text = "";
            //}
            //if (ddl_tipodoc9.SelectedValue.ToString() == "TI")
            //{
            //    txt_tipodoccc9.Text = "";
            //    txt_tipodocce9.Text = "";
            //    txt_tipodocpa9.Text = "";
            //    txt_tipodocti9.Text = "X";
            //    txt_tipodocrc9.Text = "";
            //    txt_tipodocas9.Text = "";
            //}
            //if (ddl_tipodoc9.SelectedValue.ToString() == "RC")
            //{
            //    txt_tipodoccc9.Text = "";
            //    txt_tipodocce9.Text = "";
            //    txt_tipodocpa9.Text = "";
            //    txt_tipodocti9.Text = "";
            //    txt_tipodocrc9.Text = "X";
            //    txt_tipodocas9.Text = "";
            //}
            //if (ddl_tipodoc9.SelectedValue.ToString() == "AS")
            //{
            //    txt_tipodoccc9.Text = "";
            //    txt_tipodocce9.Text = "";
            //    txt_tipodocpa9.Text = "";
            //    txt_tipodocti9.Text = "";
            //    txt_tipodocrc9.Text = "";
            //    txt_tipodocas9.Text = "X";
            //}

            //try
            //{
            //    string query = "INSERT INTO FURIPS(NumRadicado, FechaRadicado, RespGlosa, Consecutivo, NumRadAnt, NumFactura, RazonSocial, CodHabilitacion, Nit, Apellido1, Apellido2, Nombre1, Nombre2, TipoDoc, NumDoc, FechaNac, Sexo, Direccion, Dpto1, CodigoDpto, Telefono, Ciudad1, CodCiudad, CondicionAccidentado, TD_CC, TD_CE, TD_PA, TD_TI, TD_RC, TD_AS, TD_MS, ca_conductor, ca_peaton, ca_ocupante, ca_ciclista, NaturalezaEvento, AccidenteTransito, Sismo, Maremoto, Erupcion, Huracan, Inundaciones, Avalancha, Deslizamiento, IncendioNatural, Explosion, Masacre, MinaAntipersonal, Combate, Incendio, AtaqueMncpio, Otros, DescripEvento, DirOcurrencia, FechaOcurerncia, HoraOcurrencia, Dpto2, DptoOcurrenciaCod, Ciudad2, MuniOcurrenciaCod, Zona, ZonaU, ZonaR, DesBreve, EstadoAseg, Asegurado, NoAsegurado, Fantasma, PolizaFalsa, Fuga," +
            //                   "Marca, Placa, CodAseguradora, NumPolizaSOAT, IntervencionAutoridad, IA_SI, IA_NO,  FechaInicioVig, FechaFinalVig, CobroExcedente, CE_SI, CE_NO, TipoServicio, TS1, TS2, TS3, TS4, TS5, TS6, TS7, Apellido1Pro, Appelido2Pro, Nombre1Pro, Nombre2Pro, TipoDocProp, TDPV_CC, TDPV_CD, TDPV_PA, TDPV_NIT, TDPV_TI, TDPV_RC, NumDocPro, DirResPro, NomDptoResProf, CodDptoResPro, TelResPro, NomMuniresPro, CodMuniResPro, Apellido1Conductor, Apellido2Conductor, Nombre1Conductor, Nombre2Conductor, TipoDocConductor, TDC_CC, TDC_CE, TDC_PA, TDC_TI, TDC_RC, TDC_AS, NumDocConductor, DirConductor, DptoConductor, CodDptoConductor, TelResConductor, MuniConductor, CodMuniConductor, TipoReferencia, TRR, TRO, FechaRemision, HoraSalida, PrestaRemite, CodInscripcion, ProfRemite, CargoPersonaRemite, FechaIngreso, HoraIngreso, PrestadorRecibe, CodInscripcion2, ProfRecibe, CargoPersonaRecibe," +
            //                   "PlacaMovil, TransVictimaSitio, TransVictimaFinRecorrido, TipoAmbulancia, TT_AB, TT_AM, ZonaRecogeVictima, ZonaRV_U, ZonaRV_R, FechaIngreso2, HoraIngreso2, FechaEgreso, HoraEgreso, DxIngreso, DxEgreso, DxIngreso1, DxEgreso1, DxIngreso2, DxEgreso2, Apellido1Prof, Apellido2Prof, Nombre1Prof, Nombre2Prof, TipoDocProf, TDP_CC, TDP_CE, TDP_PA, TDP_TI, TDP_RC, TDP_AS, NumDocProf, RegistroMedico, TotalFacturado, TotalReclamado, TotalFacturadoTrans, TotalReclamadoTrans, NumFolios) VALUES('" + this.txt_numradicado.Text + "', '" + this.txt_fecharadicacion.Text + "', '" + this.txt_respglosa.Text + "', '" + this.txt_NumeroConsecutivo.Text + "', '" + this.txt_radianterior.Text + "', '" + this.txt_numfactura.Text + "', '" + this.txt_razon1.Text + "', '" + this.txt_codhabil1.Text + "', '" + this.txt_nit1.Text + "', '" + this.txt_apellido12.Text + "', '" + this.txt_apellido22.Text + "', '" + this.txt_nombre12.Text + "', '" + this.txt_nombre22.Text + "', '" + this.ddl_tipodoc2.SelectedValue + "', '" + this.txt_documento2.Text + "', '" + this.txt_fechanaci2.Text + "', '" + this.ddl_sexo2.SelectedItem + "', '" + this.txt_direccion2.Text + "', '" + this.ddl_departamento2.SelectedItem + "', '" + this.ddl_departamento2.SelectedValue + "', '" + this.txt_telefono2.Text + "', '" + this.ddl_municipio2.SelectedItem + "', '" + this.ddl_municipio2.SelectedValue + "'," +
            //                   " '" + this.ddl_condicion2.SelectedValue + "', '" + this.txt_tipodocvictimacc.Text + "', '" + this.txt_tipodocvictimace.Text + "', '" + this.txt_tipodocvictimapa.Text + "', '" + this.txt_tipodocvictimati.Text + "', '" + this.txt_tipodocvictimarc.Text + "', '" + this.txt_tipodocvictimaas.Text + "', '" + this.txt_tipodocvictimams.Text + "', '" + this.txt_cconductor.Text + "', '" + this.txt_cpeaton.Text + "', '" + this.txt_cocupante.Text + "', '" + this.txt_cciclista.Text + "', '" + this.ddl_naturales3.SelectedValue + "', '" + this.txt_accidentetransito.Text + "', '" + this.txt_sismo.Text + "', '" + this.txt_maremoto.Text + "', '" + this.txt_erupcion.Text + "', '" + this.txt_huracan.Text + "', '" + this.txt_inundaciones.Text + "', '" + this.txt_avalancha.Text + "', '" + this.txt_deslizamiento.Text + "'," +
            //                   " '" + this.txt_incendionat.Text + "', '" + this.txt_explosion.Text + "', '" + this.txt_masacre.Text + "', '" + this.txt_mina.Text + "', '" + this.txt_combate.Text + "', '" + this.txt_incendio.Text + "', '" + this.txt_ataque.Text + "', '" + this.txt_otro.Text + "', '" + this.txt_cual3.Text + "', '" + this.txt_ocurrencia3.Text + "', '" + this.txt_fechaevento3.Text + "', '" + this.txt_hora3.Text + "', '" + this.ddl_departamento3.SelectedItem + "', '" + this.ddl_departamento3.SelectedValue + "', '" + this.ddl_municipio3.SelectedItem + "', '" + this.ddl_municipio3.SelectedValue + "', '" + this.txt_zonaIII.Text + "', '" + this.txt_zonaUIII.Text + "', '" + this.txt_zonaRIII.Text + "', '" + this.txt_descripcion3.Text + "', '" + this.txt_estadoAsegurado.Text + "', '" + this.txt_asegurado.Text + "', '" + this.txt_noasegurado.Text + "', '" + this.txt_fantasma.Text + "'," +
            //                   " '" + this.txt_polizafalsa.Text + "', '" + this.txt_fuga.Text + "', '" + this.txt_marca4.Text + "', '" + this.txt_placa4.Text + "', '" + this.ddl_codaseguradora4.SelectedValue + "', '" + this.txt_numpoliza4.Text + "', '" + this.txt_interpolicia.Text + "', '" + this.txt_interpolsi.Text + "', '" + this.txt_interpolno.Text + "', '" + this.txt_fechadesde4.Text + "', '" + this.txt_fechahasta4.Text + "', '" + this.txt_cobroexcedente.Text + "', '" + this.txt_cobrosi4.Text + "', '" + this.txt_cobrono4.Text + "', '" + this.ddl_tiposerv4.SelectedValue + "', '" + this.TS1.Text + "', '" + this.TS2.Text + "', '" + this.TS3.Text + "', '" + this.TS4.Text + "', '" + this.TS5.Text + "', '" + this.TS6.Text + "', '" + this.TS7.Text + "', '" + this.txt_apellido15.Text + "', '" + this.txt_apellido25.Text + "', '" + this.txt_nombre15.Text + "', '" + this.txt_nombre25.Text + "'," +
            //                   " '" + this.ddl_tipodoc5.SelectedValue + "', '" + this.txt_tipodocpropietariocc.Text + "', '" + this.txt_tipodocpropietariocd.Text + "', '" + this.txt_tipodocpropietariopa.Text + "', '" + this.txt_tipodocpropietarionit.Text + "', '" + this.txt_tipodocpropietarioti.Text + "', '" + this.txt_tipodocpropietariorc.Text + "', '" + this.txt_numdoc5.Text + "', '" + this.txt_direccion5.Text + "', '" + this.ddl_departamento5.SelectedItem + "', '" + this.ddl_departamento5.SelectedValue + "', '" + this.txt_telefono5.Text + "', '" + this.ddl_municipio5.SelectedItem + "', '" + this.ddl_municipio5.SelectedValue + "', '" + this.txt_apellido16.Text + "', '" + this.txt_apellido26.Text + "', '" + this.txt_nombre16.Text + "', '" + this.txt_nombre26.Text + "', '" + this.ddl_tipodoc6.SelectedValue + "', '" + this.txt_tipodocconductorcc.Text + "', '" + this.txt_tipodocconductorce.Text + "'," +
            //                   " '" + this.txt_tipodocconductorpa.Text + "', '" + this.txt_tipodocconductorti.Text + "', '" + this.txt_tipodocconductorrc.Text + "', '" + this.txt_tipodocconductoras.Text + "', '" + this.txt_documento6.Text + "', '" + this.txt_direccion6.Text + "', '" + this.ddl_departamento6.SelectedItem + "', '" + this.ddl_departamento6.SelectedValue + "', '" + this.txt_telefono6.Text + "', '" + this.ddl_municipio6.SelectedItem + "', '" + this.ddl_municipio6.SelectedValue + "', '" + this.txt_tiporeferencia.Text + "', '" + this.txt_remision7.Text + "', '" + this.txt_orden7.Text + "', '" + this.txt_fecharemision7.Text + "', '" + this.txt_horaremision7.Text + "', '" + this.txt_prestaremite7.Text + "', '" + this.txt_codinscripcion7.Text + "', '" + this.txt_proremite7.Text + "', '" + this.txt_cargo7a.Text + "', '" + this.txt_fechaaceptacion7.Text + "', '" + this.txt_horaaceptacion7.Text + "'," +
            //                   " '" + this.txt_prestarecibe7.Text + "', '" + this.txt_codinscripcion7b.Text + "', '" + this.txt_prorecibe7.Text + "', '" + this.txt_cargo7b.Text + "', '" + this.txt_tipoAmbulancia.Text + "', '" + this.txt_placas8.Text + "', '" + this.txt_transdesde8.Text + "', '" + this.txt_transhasta8.Text + "', '" + this.txt_ambubasica8.Text + "', '" + this.txt_ambumedicalizada8.Text + "', '" + this.txt_zonavictima.Text + "', '" + this.txt_zonaurbanovictima.Text + "', '" + this.txt_zonaruralvictima.Text + "', '" + this.txt_fechaingreso9.Text + "', '" + this.txt_horaingreso9.Text + "', '" + this.txt_fechasalida9.Text + "', '" + this.txt_horasalida9.Text + "', '" + this.txt_coddx1ingreso9.Text + "', '" + this.txt_coddx1salida9.Text + "', '" + this.txt_otrodxingreso29.Text + "', '" + this.txt_otrodxegreso29.Text + "', '" + this.txt_otrodxingreso39.Text + "', '" + this.txt_otrodxsalida39.Text + "', '" + this.txt_apellido1medico9.Text + "', '" + this.txt_apellido2medico9.Text + "', '" + this.txt_nombre1medico9.Text + "', '" + this.txt_nombre2medico9.Text + "', '" + this.ddl_tipodoc9.SelectedValue + "', '" + this.txt_tipodoccc9.Text + "', '" + this.txt_tipodocce9.Text + "', '" + this.txt_tipodocpa9.Text + "', '" + this.txt_tipodocti9.Text + "', '" + this.txt_tipodocrc9.Text + "', '" + this.txt_tipodocas9.Text + "'," +
            //                   " '" + this.txt_documento9.Text + "', '" + this.txt_numregistro9.Text + "', '" + this.txt_vrfacturado10.Text + "', '" + this.txt_vrfosyga10.Text + "', '" + this.txt_vr2facturado10.Text + "', '" + this.txt_vr2fosyga10.Text + "', '" + this.txt_totalfolios.Text + "')";

            //    if (Datos.insertar(query))
            //    {
            //        lbl_resultado.Text = "No se modificó la información, verifique";
            //    }
            //    else
            //    {
                    string consulta = "SELECT * FROM FURIPS";
                    ImprimirFurips(consulta);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lbl_resultado.Text = ex.ToString();
            //}
        }


        private void ImprimirFurips(string sql)
        {
            string id = "PDF"; // get this from another control on your page
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "Furips.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                lbl_resultado.Text = "No se encontraron reportes por favor verifique con el administrador";
                return;
            }

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, cn);

                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);

            }

            ReportDataSource rd = new ReportDataSource("DataSet1", dt);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>14in</PageHeight>" +
            "  <MarginTop>0.19685in</MarginTop>" +
            "  <MarginLeft>0.19685in</MarginLeft>" +
            "  <MarginRight>0.19685in</MarginRight>" +
            "  <MarginBottom>0.19685in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            Response.Clear(); // we're going to override the default page response
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= INFORME-FURIPS"+this.txt_documento2.Text+"." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);

            Response.End();
        }


    }
}