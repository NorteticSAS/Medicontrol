using Helper;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {

        public static string consulta, sql;
        string CodigoEntidad, CodigoContrato, CodigoEstrato, CodigoTipoContrato, FamiliasAccion, DemandaInducida, CUF, CCC;
        string CodigoCliente;
        double ValorSaldo = 0;
        double EstratoPorcentaje = 0;
        double CuotaModeradoraEstrato = 0;
        double ValorProcedimiento = 0;
        double ValorTotalCopago = 0;
        double ValorTotalProcedimiento = 0;
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["Login"] != null)
            {
                username.Text = " " + Request.Cookies["Login"]["name"].ToString();
                CodigoEnSesion.Text = Request.Cookies["Login"]["ID"].ToString();
                CargoUsuario.Text = Request.Cookies["Login"]["tipousuario"].ToString();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
           
            consulta = ddl_pyp.SelectedValue;
            lbl_resultado.Text = string.Empty;
           
            txt_RNFechanacimiento.Text = DateTime.Now.ToShortDateString();
            txt_RNHoraNacimiento.Text = DateTime.Now.ToLocalTime().ToLongTimeString();
            if (!IsPostBack)
            {
                

                Datos.consultar("SELECT * FROM ProgramasPYP ORDER BY Codigo", "ProgramasPYP");
                this.ddl_pyp.DataSource = Datos.ds.Tables["ProgramasPYP"];
                this.ddl_pyp.DataTextField = "Descripcion";
                this.ddl_pyp.DataValueField = "Codigo";
                this.ddl_pyp.DataBind();
                ddl_pyp.Items.Insert(0, new ListItem("Seleccione Programa PYP"));

                Datos.consultar("SELECT * FROM IPS WHERE Estado='Activo' ORDER BY Nombre", "Entidad");
                this.ddl_ips.DataSource = Datos.ds.Tables["Entidad"];
                this.ddl_ips.DataTextField = "Nombre";
                this.ddl_ips.DataValueField = "Id";
                this.ddl_ips.DataBind();
                ddl_ips.Items.Insert(0, new ListItem("Seleccione IPS", "0"));

                Datos.consultar("SELECT * FROM Servicio ORDER BY Id", "Servicio");
                this.ddl_servicio.DataSource = Datos.ds.Tables["Servicio"];
                this.ddl_servicio.DataTextField = "Nombre";
                this.ddl_servicio.DataValueField = "Id";
                this.ddl_servicio.DataBind();
                //ddl_servicio.Items.Insert(0, new ListItem("Seleccione Servicio"));

                Datos.consultar("SELECT * FROM Profesionales WHERE Estado='0' ORDER BY NombreCompleto", "Profesionales");
                this.ddl_profesional.DataSource = Datos.ds.Tables["Profesionales"];
                this.ddl_profesional.DataTextField = "NombreCompleto";
                this.ddl_profesional.DataValueField = "CodProfesional";
                this.ddl_profesional.DataBind();
                ddl_profesional.Items.Insert(0, new ListItem("Seleccione profesional"));

                //CARGO LOS COMBOBOX DE FINALIDAD Y CAUSA EXTERNA PARA RIPS
                Datos.consultar("SELECT * FROM FinalidadConsulta ORDER BY DescFinalidadC", "FinalidadConsulta");
                this.Modal_ddlFinalidadConsulta.DataSource = Datos.ds.Tables["FinalidadConsulta"];
                this.Modal_ddlFinalidadConsulta.DataTextField = "DescFinalidadC";
                this.Modal_ddlFinalidadConsulta.DataValueField = "CodFinalidadC";
                this.Modal_ddlFinalidadConsulta.DataBind();
                Modal_ddlFinalidadConsulta.Items.Insert(0, new ListItem("Seleccione finalidad", "0"));

                Datos.consultar("SELECT * FROM FinalidadProcedimiento ORDER BY DescFinalidadP", "FinalidadProcedimiento");
                this.RPFinalidad.DataSource = Datos.ds.Tables["FinalidadProcedimiento"];
                this.RPFinalidad.DataTextField = "DescFinalidadP";
                this.RPFinalidad.DataValueField = "CodFinalidadP";
                this.RPFinalidad.DataBind();
                RPFinalidad.Items.Insert(0, new ListItem("Seleccione finalidad", "0"));

                Datos.consultar("SELECT * FROM CausaExterna ORDER BY Descripcion", "CausaExterna");
                this.Modal_ddlCausaEterna.DataSource = Datos.ds.Tables["CausaExterna"];
                this.Modal_ddlCausaEterna.DataTextField = "Descripcion";
                this.Modal_ddlCausaEterna.DataValueField = "Id";
                this.Modal_ddlCausaEterna.DataBind();
                Modal_ddlCausaEterna.Items.Insert(0, new ListItem("Seleccione Causa Externa", "0"));

                Datos.consultar("SELECT * FROM TipoDX ORDER BY Descripcion", "TipoDX");
                this.Modal_ddlTipoDX.DataSource = Datos.ds.Tables["TipoDX"];
                this.Modal_ddlTipoDX.DataTextField = "Descripcion";
                this.Modal_ddlTipoDX.DataValueField = "Id";
                this.Modal_ddlTipoDX.DataBind();
                Modal_ddlTipoDX.Items.Insert(0, new ListItem("Seleccione tipo de Dx", "0"));


                Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='54' ORDER BY Municipio", "Municipios");
                this.MP_ddl_Municipio.DataSource = Datos.ds.Tables["Municipios"];
                this.MP_ddl_Municipio.DataTextField = "Municipio";
                this.MP_ddl_Municipio.DataValueField = "CodMncpio";
                this.MP_ddl_Municipio.DataBind();
                MP_ddl_Municipio.Items.Insert(0, new ListItem("Seleccione Municipio", "0"));
            }
            txt_fecha.Text = DateTime.Now.AddHours(+2).ToString("dd/MM/yyyy HH:mm:ss");
        }

        protected void ddl_pyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_codpyp.Text = ddl_pyp.SelectedValue.ToString();
            txt_vrprocedimiento.Text = string.Empty;
            txt_copago.Text = string.Empty;
            txt_vrtotal.Text = string.Empty;
            txt_vrcuota.Text = string.Empty;
            if (txt_codpyp.Text == "7")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupFamiliasAccion();", true);
                lbl_familias.Text = "¿El usuario es del programa Familias en Acción?";
            }

            if (txt_codpyp.Text != "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupDemandaInducida();", true);
                lbl_familias.Text = "Seleccione una Opción";
            }
            if (ddl_servicio.SelectedValue != "1" && ddl_pyp.SelectedValue != "0")
            {
                lbl_resultado.Text = "Está liquidando servicios diferentes a Consulta Externa o Servicios Ambulatorios. No aplica programa PYP";
                txt_codpyp.Text = string.Empty;
                ddl_pyp.ClearSelection();
                //txt_procedimiento.ReadOnly = true;
                //btn_buscarProcedimiento.Enabled = false;
                //txt_codProcedimiento.ReadOnly = true;
                //btn_buscarProcedimientoCodigo.Enabled = false;
                return;

            }
            //txt_codProcedimiento.ReadOnly = false;
            //btn_buscarProcedimientoCodigo.Enabled = true;
            //txt_procedimiento.ReadOnly = false;
            //btn_buscarProcedimiento.Enabled = true;
            consulta = ddl_pyp.SelectedValue.ToString();

        }

        [WebMethod]
        public static string[] BuscarProcedimientos(string prefix)
        {

            if (consulta == "0")
            {
                sql = "select DescProcedimiento from Procedimientos where DescProcedimiento like '%'+@SearchText+'%' AND Estado='0'";
            }
            else
            {
                sql = "SELECT Procedimientos.CodProcedimiento, Procedimientos.DescProcedimiento, Procedimientos.Estado, ProcedPYP.CodCups, ProcedPYP.Codigo FROM Procedimientos, ProcedPYP WHERE DescProcedimiento like '%'+@SearchText+'%' AND Procedimientos.CodProcedimiento = ProcedPYP.CodCups AND ProcedPYP.Codigo = '" + consulta + "' AND ProcedPYP.Ok = 1  ORDER BY DescProcedimiento";
            }
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}", sdr["DescProcedimiento"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

        [WebMethod]
        public static string[] BuscarDiagnostico(string prefix)
        {
            sql = "SELECT DesProcedimiento FROM CIE10 WHERE DesProcedimiento like '%'+@SearchText+'%'";

            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}", sdr["DesProcedimiento"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

        protected void ddl_profesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_codprofesional.Text = ddl_profesional.SelectedValue.ToString();
        }

        protected void btn_consultarPaciente_Click(object sender, EventArgs e)
        {

            
        }

        private void fillgrilla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string sql2 = "SELECT Entidad.Codigo AS EntidadCodigo, Entidad.NombreEntidad AS EntidadNombre, Contratos.Codigo AS ContratoCodigo, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql2, cn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            gridPacienteContrato.DataSource = dt;

            gridPacienteContrato.DataBind();

        }

        private String DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);

            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }

            if (anios < 0)
            {
                return "Fecha Invalida";
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias ";

            return str;
        }

        protected void gridPacienteContrato_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridPacienteContrato, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridPacienteContrato_SelectedIndexChanged1(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridPacienteContrato.Rows)
            {

                if (row.RowIndex == gridPacienteContrato.SelectedIndex)
                {
                    SqlConnection conexion = new SqlConnection(ruta);
                    txt_entidad.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[1].Text);
                    txt_contrato.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[3].Text);
                    FacturaCodigoContrato.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[2].Text);
                    FacturaCodigoEntidad.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[0].Text);
                    FacturaTipoContrato.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[4].Text);

                    string sql6 = "SELECT CodigoCliente, SUM(ValorSaldo) AS Total FROM CuentasporCobrar WHERE CodigoCliente='" + this.txt_buscar.Text + "' AND ValorSaldo>0 GROUP BY CodigoCliente";
                    SqlCommand comando6 = new SqlCommand(sql6, conexion);
                    conexion.Open();
                    SqlDataReader leer6 = comando6.ExecuteReader();
                    if (leer6.Read() == true)
                    {
                        FacturaCodigoCliente.Text = leer6["CodigoCliente"].ToString();
                        ValorSaldo = Convert.ToDouble(leer6["Total"].ToString());
                        string SumaValor = ValorSaldo.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupDeudas();", true);
                        this.lbl_mensajedeuda.Text = "El usuario tiene una deuda pendiente de pago con la IPS de $ " + SumaValor;
                    }
                    conexion.Close(); row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }


        }

        protected void btn_familias_Click(object sender, EventArgs e)
        {
            FacturaFamiliasAccion.Text = "1";
        }

        protected void checkDemanda_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkDemanda.ClearSelection();
            FacturaDemandaInducida.Text = checkDemanda.SelectedValue.ToString();
            if (txt_codpyp.Text == "3")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRecienNacidos();", true);
            }

        }

        protected void btn_registrarRecienNacido_Click(object sender, EventArgs e)
        {
            if (txt_RNFechanacimiento.Text == string.Empty)
            {
                lbl_resultado.Text = "La fecha de Nacimiento del menor es obligatoria";
                ddl_pyp.ClearSelection();
                return;
            }
            if (txt_RNHoraNacimiento.Text == string.Empty)
            {
                lbl_resultado.Text = "La hora de Nacimiento del menor es obligatoria";
                ddl_pyp.ClearSelection();
                return;
            }
            if (txt_RNgestacional.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe ingresar la edad gestacional del menor";
                ddl_pyp.ClearSelection();
                return;
            }
            if (ddl_controlprenatal.SelectedValue == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un control prenatal";
                ddl_pyp.ClearSelection();
                return;
            }
            if (ddl_RNSexo.SelectedValue == "0")
            {
                lbl_resultado.Text = "Debe seleccionar el sexo del menor";
                ddl_pyp.ClearSelection();
                return;
            }
            if (txt_RNPeso.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar el peso del menor";
                ddl_pyp.ClearSelection();
                return;
            }
            if (txt_RNDiagnostico.Text == string.Empty)
            {
                lbl_resultado.Text = "El diagnostico del menor es obligatorio";
                ddl_pyp.ClearSelection();
                return;
            }
            txt_RNFechamuerte.Text = ViewHelper.ConvertToDate(txt_RNFechamuerte.Text);
            txt_RNFechanacimiento.Text = ViewHelper.ConvertToDate(txt_RNFechanacimiento.Text);
            string sql = "INSERT INTO RecienNacidos(MadreTipoID, MadreDocumento, RNFechaNacimiento, RNHoraNacimiento, RNEdadGestacional, RNControlGestacional, RNSexo, RNPeso, RNDiagnostico, RNDiagnosticoMuerte, RNFechaMuerte, RNHoraMuerte, CodigoEntidad, CodigoContrato, Estado) VALUES('" + this.txt_RNTipodocumento.Text + "', '" + this.txt_RNDocumento.Text + "', '" + this.txt_RNFechanacimiento.Text + "', '" + this.txt_RNHoraNacimiento.Text + "', '" + this.txt_RNgestacional.Text + "', '" + this.ddl_controlprenatal.SelectedItem + "', '" + this.ddl_RNSexo.SelectedItem + "', '" + this.txt_RNPeso.Text + "', '" + this.txt_RNDiagnostico.Text + "', '" + this.txt_RNDiagnosticoMuerte.Text + "', '" + this.txt_RNFechamuerte.Text + "', '" + this.txt_RNHoramuerte.Text + "', '" + this.txt_RNEntidad.Text + "', '" + this.txt_RNContrato.Text + "', 'Activo')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
            }
        }

        protected void btn_deudas_Click(object sender, EventArgs e)
        {
            //Response.Redirect("NuevaFactura.aspx");
        }

        protected void btn_buscarProcedimientoCodigo_Click(object sender, EventArgs e)
        {
            if (txt_codProcedimiento.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un procedimiento";
                return;
            }
            string search = "SELECT * FROM Procedimientos WHERE CodProcedimiento='" + this.txt_codProcedimiento.Text + "' AND Estado='0'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comandos = new SqlCommand(search, conexion);
            conexion.Open();

            SqlDataReader leers = comandos.ExecuteReader();

            if (leers.Read() == true)
            {
                fillgrillaRipsConsulta();
                fillgrillaRipsProcedimientos();
                fillgrillaCuerpoFactura();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupCantidad();", true);
                this.lbl_mensajeCantidad.Text = "Por favor digite la cantidad a facturar";
            }
            else
            {
                lbl_resultado.Text = "El Proedimiento no existe o se encuenta inactivo por favor verifique";
                return;
            }

        }

        protected void GridCentroCostos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridCentroCostos, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void GridCentroCostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridCentroCostos.Rows)
            {

                if (row.RowIndex == GridCentroCostos.SelectedIndex)
                {
                    FacturaCUF.Text = HttpUtility.HtmlDecode(this.GridCentroCostos.SelectedRow.Cells[0].Text);
                    FacturaCCC.Text = HttpUtility.HtmlDecode(this.GridCentroCostos.SelectedRow.Cells[2].Text);
                    FacturaDUF.Text = HttpUtility.HtmlDecode(this.GridCentroCostos.SelectedRow.Cells[1].Text);
                    FacturaDCC.Text = HttpUtility.HtmlDecode(this.GridCentroCostos.SelectedRow.Cells[3].Text);
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }

        }

        private void fillgrillaCentroCostos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string sql2 = "SELECT UnidadFuncional.CodUnidadF AS CodigoUnidad, UnidadFuncional.DescUnidadF AS DescUnidad, CentroCostos.CodCentroCostos AS CodigoCentroCostos, CentroCostos.DescCentroCosto AS DescCentroCostos, Procedimientos.CodProcedimiento, Procedimientos.DescProcedimiento FROM UnidadFuncional INNER JOIN (Procedimientos INNER JOIN (CentroCostos INNER JOIN ProcedCentroCostos ON CentroCostos.CodCentroCostos = ProcedCentroCostos.CodCentroCostos) ON Procedimientos.CodProcedimiento = ProcedCentroCostos.CodProcedimiento) ON UnidadFuncional.CodUnidadF = CentroCostos.CodUnidadF WHERE Procedimientos.CodProcedimiento= '" + this.txt_codProcedimiento.Text + "'";

                //string sql2 = "SELECT Procedimientos.CodProcedimiento AS CodProced, Procedimientos.DescProcedimiento AS DescProced, Tarifas.Valor AS ValorTarifa, Planes.CodPlan AS CodigoPlan, PlanesContratos.Porcentaje AS PorcentajePC, Entidades.Codigo AS CodigoEntidad, Contratos.Codigo AS CodContrato, Procedimientos.CodRips AS RipsProced, Procedimientos.Finalidad AS FinalidadProced, PlanesContratos.Capita AS CopagoPC, Procedimientos.TipoServicio AS TipoServProced, PlanesContratos.CodigoTarifario AS CodTarifaPC FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento WHERE Procedimientos.CodProcedimiento= '" + this.txt_codProcedimiento.Text + "' AND Contratos.Codigo= '" + CodigoContrato + "' AND Contratos.Entidad = '" + CodigoEntidad + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql2, cn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            GridCentroCostos.DataSource = dt;

            GridCentroCostos.DataBind();

        }

        protected void btn_buscarProcedimiento_Click(object sender, EventArgs e)
        {

            fillgrillaCuerpoFactura();
            fillgrillaRipsConsulta();
            fillgrillaRipsProcedimientos();
            string search = "SELECT * FROM Procedimientos WHERE DescProcedimiento='" + this.txt_procedimiento.Text + "' AND Estado='0'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comandos = new SqlCommand(search, conexion);
            conexion.Open();

            SqlDataReader leers = comandos.ExecuteReader();

            if (leers.Read() == true)
            {
                txt_codProcedimiento.Text = leers["CodProcedimiento"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupCantidad();", true);
                this.lbl_mensajeCantidad.Text = "Por favor digite la cantidad a facturar";
            }
            else
            {
                lbl_resultado.Text = "El Procedimiento no existe o se encuenta inactivo por favor verifique";
                return;
            }
            conexion.Close();

           
        }

        private void fillgrillaCuerpoFactura()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CodProced, DescProced, CantProced, Valor, ValorProced, EstratoCopago, Subtotal, CodUnidadFuncional, CodCentroC, CodRips, TipoServicio FROM FactAux WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            GridCuerpoFactura.DataSource = dt;

            GridCuerpoFactura.DataBind();

        }

        private void TotalizarFactura(string Documento)
        {
            SqlConnection conexion = new SqlConnection(ruta);
            double SumaValorProced = 0; double SumaVvalorCopago = 0; double SumaValorEntidad = 0; double SumaValorModeradora = 0;

            string sqlTotales = "SELECT SUM(ValorProced * CantProced) AS ValorTotal, SUM(EstratoCopago * CantProced) AS ValorTotalCopago FROM FactAux WHERE Documento='" + Documento + "'";
            SqlCommand comandoTotal = new SqlCommand(sqlTotales, conexion);
            conexion.Open();
            SqlDataReader leerTotal = comandoTotal.ExecuteReader();
            if (leerTotal.Read() == true)
            {
                TotalP.Text = (leerTotal["ValorTotal"].ToString());
                TotalC.Text = (leerTotal["ValorTotalCopago"].ToString());
            }
            conexion.Close();
            //VALOR TOTAL PROCEDIMIENTOS
            if (TotalP.Text == string.Empty)
            {
                SumaValorProced = 0;
            }
            else
            {
                SumaValorProced = Convert.ToDouble(TotalP.Text);
            }
            if (TotalC.Text == string.Empty)
            {
                SumaVvalorCopago = 0;
            }
            else
            {
                SumaVvalorCopago = Convert.ToDouble(TotalC.Text);
            }
            txt_vrprocedimiento.Text = SumaValorProced.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));

            SumaValorEntidad = SumaValorProced - SumaVvalorCopago;
            txt_vrtotal.Text = SumaValorEntidad.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
            valorTotalFinalCopago.Text = SumaVvalorCopago.ToString();
            valorTotalFinalProced.Text = SumaValorProced.ToString();
            ValorTotalFinalSubtotal.Text = SumaValorEntidad.ToString();
            NumLetra nl = new NumLetra();
            string numero = SumaValorEntidad.ToString();
            txt_ValorLetras.Text = nl.Convertir(numero, true);
            double suma = 0;
            if (ValorModeradoraFactura.Text != string.Empty)
            {
                txt_vrcuota.Text = Convert.ToDouble(ValorModeradoraFactura.Text).ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                txt_copago.Text = "$ 0";
                suma = SumaValorProced - Convert.ToDouble(ValorModeradoraFactura.Text);

            }
            else
            {
                txt_copago.Text = SumaVvalorCopago.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                txt_vrcuota.Text = "$ 0";
                suma = SumaValorProced - SumaVvalorCopago;
            }
            txt_vrtotal.Text = suma.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
        }


        protected void GridCuerpoFactura_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridCuerpoFactura.EditIndex = e.NewEditIndex;
            fillgrillaCuerpoFactura();
        }

        protected void GridCuerpoFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridCuerpoFactura.Rows)
            {

                if (row.RowIndex == GridCuerpoFactura.SelectedIndex)
                {
                    EliminarCelda.Visible = true;
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    //EliminarCelda.Visible = false;
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void EliminarCelda_Click(object sender, EventArgs e)
        {

            string sql = "DELETE FROM FactAux WHERE CodProced='" + this.GridCuerpoFactura.SelectedRow.Cells[0].Text + "' AND Subtotal='" + this.GridCuerpoFactura.SelectedRow.Cells[6].Text + "' AND Documento='" + this.txt_documento.Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al eliminar, Verifique";
            }
            else
            {
                fillgrillaCuerpoFactura();
                TotalizarFactura(txt_documento.Text);
                EliminarCelda.Visible = false;
            }
            
        }

        protected void GridCuerpoFactura_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridCuerpoFactura, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void btn_ripsConsulta_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRipsConsulta();", true);
        }

        protected void btn_ripsProced_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRipsProced();", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string CodigoDP, CodigoD1, CodigoD2, CodigoD3;
            //CodigoDP=Modal_CodDiagP.Text;
            //BUSCAMOS LOS CODIGOS DE LOS DIAGNOSTICOS DE HABERLOS

            if (Modal_ddlFinalidadConsulta.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "falta la finalidad de consulta en Rips Consulta";
                return;
            }
            if (Modal_ddlCausaEterna.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "falta la causa externa en Rips Consulta";
                return;
            }
            if (Modal_DescDiagP.Text == string.Empty)
            {
                if (Modal_CodDiagP.Text == string.Empty)
                {
                    CODDP.Text = string.Empty;
                    //lbl_resultado.Text = "falta el codigo de diagnostico principal";
                    //return;
                }
                else
                {
                    CODDP.Text = (Modal_CodDiagP.Text).ToUpper();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10 WHERE DesProcedimiento='" + Modal_DescDiagP.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CODDP.Text = leer["CodProcedimiento"].ToString();
                }
                conexion.Close();
            }

            if (Modal_DescD1.Text == string.Empty)
            {
                if (Modal_CodD1.Text == string.Empty)
                {
                    CODD1.Text = string.Empty;
                }
                else
                {
                    CODD1.Text = (Modal_CodD1.Text).ToUpper();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10 WHERE DesProcedimiento='" + Modal_DescD1.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CODD1.Text = leer["CodProcedimiento"].ToString();
                }
                conexion.Close();
            }

            if (Modal_DescD2.Text == string.Empty)
            {
                if (Modal_CodD2.Text == string.Empty)
                {
                    CODD2.Text = string.Empty;
                }
                else
                {
                    CODD2.Text = (Modal_CodD2.Text).ToUpper();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10 WHERE DesProcedimiento='" + Modal_DescD2.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CODD2.Text = leer["CodProcedimiento"].ToString();
                }
                conexion.Close();
            }

            if (Modal_DescD3.Text == string.Empty)
            {
                if (Modal_CodD3.Text == string.Empty)
                {
                    CODD3.Text = string.Empty;
                }
                else
                {
                    CODD3.Text = (Modal_CodD3.Text).ToUpper();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10 WHERE DesProcedimiento='" + Modal_DescD3.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CODD3.Text = leer["CodProcedimiento"].ToString();
                }
                conexion.Close();
            }
            string sql = "INSERT INTO RipsConsultaAuxiliar(Documento, CodProcedimiento, Finalidad, CausaEXT, DXPrincipal, TipoDXPrincipal, DX1, DX2, DX3) VALUES('" + this.txt_documento.Text + "', '" + Modal_CodProced.Text + "', '" + this.Modal_ddlFinalidadConsulta.SelectedValue + "', '" + this.Modal_ddlCausaEterna.SelectedValue + "', '" + this.CODDP.Text + "', '" + this.Modal_ddlTipoDX.SelectedValue + "', '" + this.CODD1.Text + "', '" + this.CODD2.Text + "', '" + this.CODD3.Text + "')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se modificó la información";
            }
            else
            {
                fillgrillaRipsConsulta();
                txt_codProcedimiento.Text = string.Empty;
                txt_procedimiento.Text = string.Empty;
            }
        }

        private void fillgrillaRipsConsulta()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CodProcedimiento, Finalidad, CausaEXT, DXPrincipal, TipoDXPrincipal, DX1, DX2, DX3 FROM RipsConsultaAuxiliar WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            GridRipsConsulta.DataSource = dt;

            GridRipsConsulta.DataBind();

        }

        private void fillgrillaRipsProcedimientos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CodProcedimiento, Ambito, Finalidad, Personal, DPX, DRX, DCX FROM RipsProcedAuxiliar WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }

            GridRipsProced.DataSource = dt;

            GridRipsProced.DataBind();

        }

        protected void GuardarRipsProced_Click(object sender, EventArgs e)
        {

            if (ddl_ambito.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "falta el ambito en RIPS Procedimientos";
                return;
            }
            if (RPFinalidad.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "falta la finalidad en RIPS Procedimientos";
                return;
            }
            if (ddl_personal.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "falta el personal que atiende en RIPS Procedimientos";
                return;
            }
            if (RPDDiangP.Text == string.Empty)
            {
                if (RPCodDiagP.Text == string.Empty)
                {
                    CDPRP.Text = string.Empty;
                }
                else
                {
                    CDPRP.Text = (RPCodDiagP.Text).ToUpper();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10 WHERE DesProcedimiento='" + RPDDiangP.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CDPRP.Text = leer["CodProcedimiento"].ToString();
                }
                conexion.Close();
            }
            if (RPDDiagR.Text == string.Empty)
            {
                if (RPCodDiaGR.Text == string.Empty)
                {
                    CDRRP.Text = string.Empty;
                }
                else
                {
                    CDRRP.Text = (RPCodDiaGR.Text).ToUpper();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10 WHERE DesProcedimiento='" + RPDDiagR.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CDRRP.Text = leer["CodProcedimiento"].ToString();
                }
                conexion.Close();
            }
            if (RPDDiagC.Text == string.Empty)
            {
                if (RPCodDiagC.Text == string.Empty)
                {
                    CDCRP.Text = string.Empty;
                }
                else
                {
                    CDCRP.Text = (RPCodDiagC.Text).ToUpper();
                }
            }
            else
            {
                string sqlDP = "SELECT * FROM CIE10 WHERE DesProcedimiento='" + RPDDiagC.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sqlDP, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    CDCRP.Text = leer["CodProcedimiento"].ToString();
                }
                conexion.Close();
            }

            string sql = "INSERT INTO RipsProcedAuxiliar(Documento, CodProcedimiento, Ambito, Finalidad, Personal, DPX, DCX, DRX) VALUES('" + this.txt_documento.Text + "', '" + this.RPCodProced.Text + "', '" + this.ddl_ambito.SelectedValue + "', '" + this.RPFinalidad.SelectedValue + "', '" + this.ddl_personal.SelectedValue + "', '" + CDPRP.Text + "', '" + CDCRP.Text + "', '" + CDRRP.Text + "')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se modificó la información";
            }
            else
            {
                fillgrillaRipsProcedimientos();
                txt_codProcedimiento.Text = string.Empty;

                txt_procedimiento.Text = string.Empty;
            }
        }

        protected void btn_eliminarRipsConsulta_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM RipsConsultaAuxiliar WHERE CodProcedimiento='" + this.GridRipsConsulta.SelectedRow.Cells[0].Text + "' AND Finalidad='" + this.GridRipsConsulta.SelectedRow.Cells[1].Text + "' AND Documento='" + this.txt_documento.Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al eliminar, Verifique";
            }
            else
            {
                fillgrillaRipsConsulta();

            }
        }

        protected void GridRipsConsulta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridRipsConsulta, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void GridRipsConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridRipsConsulta.Rows)
            {

                if (row.RowIndex == GridRipsConsulta.SelectedIndex)
                {
                    btn_eliminarRipsConsulta.Enabled = true;
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void btn_eliminarRipsProced_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM RipsProcedAuxiliar WHERE Ambito='" + this.GridRipsProced.SelectedRow.Cells[1].Text + "' AND Personal='" + this.GridRipsProced.SelectedRow.Cells[3].Text + "' AND Finalidad='" + this.GridRipsProced.SelectedRow.Cells[2].Text + "' AND Documento='" + this.txt_documento.Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al eliminar, Verifique";
            }
            else
            {
                fillgrillaRipsProcedimientos();

            }
        }

        protected void GridRipsProced_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridRipsProced, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaFactura.aspx");
        }

        protected void GridRipsProced_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridRipsProced.Rows)
            {

                if (row.RowIndex == GridRipsProced.SelectedIndex)
                {
                    btn_eliminarRipsProced.Enabled = true;
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void btn_cantidad_Click(object sender, EventArgs e)
        {
            Datos.consultar("SELECT * FROM AmbitoProced ORDER BY Descripcion", "AmbitoProced");
            this.ddl_ambito.DataSource = Datos.ds.Tables["AmbitoProced"];
            this.ddl_ambito.DataTextField = "Descripcion";
            this.ddl_ambito.DataValueField = "Codigo";
            this.ddl_ambito.DataBind();
            ddl_ambito.Items.Insert(0, new ListItem("Seleccione ambito", "0"));

            Datos.consultar("SELECT * FROM PersonalAtiende ORDER BY Descripcion", "PersonalAtiende");
            this.ddl_personal.DataSource = Datos.ds.Tables["PersonalAtiende"];
            this.ddl_personal.DataTextField = "Descripcion";
            this.ddl_personal.DataValueField = "Codigo";
            this.ddl_personal.DataBind();
            ddl_personal.Items.Insert(0, new ListItem("Seleccione personal", "0"));
            ddl_ambito.ClearSelection();
            ddl_ambito.Items.FindByValue("3").Selected = true;

           

            ddl_personal.ClearSelection();
            ddl_personal.Items.FindByValue("2").Selected = true;


            if (!Utilidades.isNumeric(txt_CantidadProcedimiento.Text))
            {
                lbl_resultado.Text = "Por favor digite una Cantidad Correcta";
                return;
            }
            if (Convert.ToDouble(txt_CantidadProcedimiento.Text) < 0)
            {
                lbl_resultado.Text = "Por favor digite una Cantidad Correcta";
                return;
            }
            bool Esta = false;
            double CantidadP = 0; double ValorP = 0; double ValorProcedP = 0; double SubTotal = 0; double CopagoP = 0; double Moderadora = 0;
            string FinalidadPYP = string.Empty; string tiposervicioNombre = string.Empty;
            string Cext = string.Empty;
            int CodRips = 0;
            string CodigoProcedimiento = string.Empty;
            double ValorCuotaModeradora = 0;
            double ValorTotalCopago = 0;
            double subtotal = 0;

            if (txt_codProcedimiento.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un código de Procedimiento";
                return;
            }
            GCFinalidadPYP.Text = string.Empty;
            GCCExterna.Text = string.Empty;
            //PARA EVITAR QUE SE DIGITEN PROCEDIMIENTOS DE URGENCIA U HOSPITALIZACION

            if (txt_codProcedimiento.Text == "39145" || txt_codProcedimiento.Text == "38111" || txt_codProcedimiento.Text == "38112" || txt_codProcedimiento.Text == "38113" || txt_codProcedimiento.Text == "38114" || txt_codProcedimiento.Text == "38121" || txt_codProcedimiento.Text == "38122" || txt_codProcedimiento.Text == "38123" || txt_codProcedimiento.Text == "38124")
            {
                lbl_resultado.Text = "Es una urgencia u hospitalización, debe ir por admisiones, asignar procedimientos.";
                return;
            }

            string sql = "SELECT ProcedPYP.Codigo, ProcedPYP.CodCups, ProcedPYP.Ok, ProcedPYP.Finalidad AS Finalidad From ProcedPYP WHERE ProcedPYP.CodCups = '" + this.txt_codProcedimiento.Text + "' AND ProcedPYP.Ok=1";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();
            
            while (leer.Read())
            {
                GCFinalidadPYP.Text = FinalidadPYP = leer["Finalidad"].ToString();      //Finalidad Procedimiento PYP
                GCCExterna.Text = Cext = "15";                                          //Causa Externa PYP
                Esta = true;
            }
            

            conexion.Close();
            if (Esta == false && txt_codpyp.Text != "0")
            {
                lbl_resultado.Text = "Código del procedimiento no corresponde al programa de PYP seleccionado";
                return;
            }
            if (Esta == false && txt_codpyp.Text != "0")
            {
                lbl_resultado.Text = "Procedimiento PYP no aplica para el programa seleccionado";
                return;
            }
            string consulta = "SELECT COUNT(*) FROM UnidadFuncional INNER JOIN (Procedimientos INNER JOIN (CentroCostos INNER JOIN ProcedCentroCostos ON CentroCostos.CodCentroCostos = ProcedCentroCostos.CodCentroCostos) ON Procedimientos.CodProcedimiento = ProcedCentroCostos.CodProcedimiento) ON UnidadFuncional.CodUnidadF = CentroCostos.CodUnidadF WHERE Procedimientos.CodProcedimiento= '" + this.txt_codProcedimiento.Text + "'";
            //string consulta = "SELECT COUNT(*) FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento WHERE Procedimientos.CodProcedimiento= '"+this.txt_codProcedimiento.Text+"' AND Contratos.Codigo= '" + CodigoContrato + "' AND Contratos.Entidad = '" +CodigoEntidad+ "'";
            SqlCommand comando2 = new SqlCommand(consulta, conexion);
            conexion.Open();
            int count = Convert.ToInt32(comando2.ExecuteScalar());

            conexion.Close();

            if (count > 1)
            {
                fillgrillaCentroCostos();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupCentroCostos();", true);
                this.lbl_centroCostos.Text = "Seleccione un Centro de Costos";
            }
            if (count == 1)
            {
                string sql5 = "SELECT UnidadFuncional.CodUnidadF AS CodigoUnidad, UnidadFuncional.DescUnidadF AS DescUnidad, CentroCostos.CodCentroCostos AS CodigoCentroCostos, CentroCostos.DescCentroCosto AS DescCentroCostos, Procedimientos.CodProcedimiento, Procedimientos.DescProcedimiento FROM UnidadFuncional INNER JOIN (Procedimientos INNER JOIN (CentroCostos INNER JOIN ProcedCentroCostos ON CentroCostos.CodCentroCostos = ProcedCentroCostos.CodCentroCostos) ON Procedimientos.CodProcedimiento = ProcedCentroCostos.CodProcedimiento) ON UnidadFuncional.CodUnidadF = CentroCostos.CodUnidadF WHERE Procedimientos.CodProcedimiento= '" + this.txt_codProcedimiento.Text + "'";
                SqlCommand comando5 = new SqlCommand(sql5, conexion);
                conexion.Open();
                SqlDataReader leer2 = comando5.ExecuteReader();
                if (leer2.Read() == true)
                {
                    FacturaCUF.Text = leer2["CodigoUnidad"].ToString();         //Codigo Unidad Funcional
                    FacturaCCC.Text = leer2["CodigoCentroCostos"].ToString();   //Codigo Centro de Costos
                    FacturaDUF.Text = leer2["DescUnidad"].ToString();           //Descripcion Unidad Funcional
                    FacturaDCC.Text = leer2["DescCentroCostos"].ToString();     //Descripcion Centro de Costos
                }
                conexion.Close();
            }
            if (count == 0)
            {
                lbl_resultado.Text = "El Procedimiento no tiene un centro de costo asociado";
                return;
            }

            string sqlp = "SELECT Procedimientos.CodProcedimiento AS CodProced, Procedimientos.DescProcedimiento AS DescProced, Tarifas.Valor AS ValorTarifa, Planes.CodPlan AS CodigoPlan, PlanesContratos.Porcentaje AS PorcentajePC, Entidad.Codigo AS CodigoEntidad, Contratos.Codigo AS CodContrato, Procedimientos.CodRips AS RipsProced, Procedimientos.Finalidad AS FinalidadProced, PlanesContratos.Capita AS CopagoPC, Procedimientos.TipoServicio AS TipoServProced, PlanesContratos.CodigoTarifario AS CodTarifaPC FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento WHERE Procedimientos.CodProcedimiento= '" + this.txt_codProcedimiento.Text + "' AND Contratos.Codigo= '" + this.FacturaCodigoContrato.Text + "' AND Contratos.Entidad = '" + this.FacturaCodigoEntidad.Text + "'";
            SqlCommand comando6 = new SqlCommand(sqlp, conexion);
            conexion.Open();
            SqlDataReader leerP = comando6.ExecuteReader();
            if (leerP.Read() == true)
            {

                lbl_resultado.Text = string.Empty;
                FacturaCodigoProcedimiento.Text = leerP["CodProced"].ToString();            //Codigo del Procedimiento
                FacturaDescProcedimiento.Text = leerP["DescProced"].ToString();             //Descripcion Procedimiento
                FacturaCantidad.Text = txt_CantidadProcedimiento.Text;

                int Cantidad = Convert.ToInt32(FacturaCantidad.Text);                       //Cantidad del Procedimiento a Facturar
                double ValorProced = 0;
                double Valor = Convert.ToDouble(leerP["ValorTarifa"].ToString());           //Valor del Procedimiento
                double PorcentajeProd = Convert.ToDouble(leerP["PorcentajePC"].ToString()); //Porcentaje del Procedimiento
                double DescuentoEstrato = Convert.ToDouble(FacturaValorPorcEstrato.Text);
                if (Valor > 0)
                {
                    ValorProced = (Valor * PorcentajeProd) / 100;
                    FacturaValorUnitario.Text = Valor.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                    FacturaValorProcedimiento.Text = ValorProced.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                    FacturaValorUnitarioSN.Text = Valor.ToString();                         //ValorUnitario del Procedimiento
                    FacturaValorProcedimientoSN.Text = ValorProced.ToString();              //Valor del Procedimiento
                    ValorProcedP = ValorProced;
                }
                else
                {
                    ValorProcedP = Valor;
                    FacturaValorUnitario.Text = Valor.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                    FacturaValorProcedimiento.Text = Valor.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                    FacturaValorUnitarioSN.Text = Valor.ToString();
                    FacturaValorProcedimientoSN.Text = Valor.ToString();
                }

                //VALIDAMOS COPAGOS

                FacturaCobraCopago.Text = leerP["CopagoPC"].ToString();
                double valorCopago = 0;

                //REGIMEN CONTRIBUTIVO

                if (FacturaTipoAfiliado.Text == "Cotizante")                                //Tipo de Afiliado en Descripcion
                {
                    if (txt_tipousuario.Text == "Contributivo" && FacturaCobraCopago.Text == "1")
                    {
                        //ValorCopagoFactura.Text = FacturaValorCuotaModeradora.Text;
                        ValorCopagoFactura.Text = FacturaValorCuotaModeradora.Text;       //Valor Cuota Moderadora
                        ValorModeradoraFactura.Text = FacturaValorCuotaModeradora.Text;

                    }
                }

                if (FacturaTipoAfiliado.Text == "Beneficiario")
                {
                    if (txt_tipousuario.Text == "Contributivo" && FacturaCobraCopago.Text == "1")
                    {

                        valorCopago = Convert.ToInt32((ValorProced * DescuentoEstrato) / 100);
                        ValorCopagoFactura.Text = valorCopago.ToString();                //Valor del Copago

                    }
                }

                //DEMAS REGIMENES SUBSIDIADO VINCULADO Y SOAT

                if (txt_tipousuario.Text != "Contributivo" && FacturaCobraCopago.Text == "1" && FacturaTipoAfiliado.Text == string.Empty)
                {
                    valorCopago = Convert.ToInt32((ValorProced * DescuentoEstrato) / 100);
                    ValorCopagoFactura.Text = valorCopago.ToString();
                }

                subtotal = ValorProcedP - valorCopago;


                FacturaRips.Text = leerP["RipsProced"].ToString();
                tiposervicioNombre = leerP["TipoServProced"].ToString();
                CodRips = Convert.ToInt32(leerP["RipsProced"].ToString());
                CodRipsP.Text = leerP["RipsProced"].ToString();
                conexion.Close();


                FacturaTipoServicio.Text = tiposervicioNombre;

                CantidadP = Convert.ToDouble(FacturaCantidad.Text);
                ValorP = Convert.ToDouble(FacturaValorUnitarioSN.Text);

                if (ValorModeradoraFactura.Text != string.Empty)
                {
                    string sqlmod = "SELECT cuotaModeradoraValor FROM FactAux WHERE Documento='" + this.txt_documento.Text + "'";
                    SqlCommand comandom = new SqlCommand(sqlmod, conexion);
                    conexion.Open();
                    SqlDataReader leerm = comandom.ExecuteReader();
                    if (leerm.Read() == true)
                    {
                        ValorCopagoFactura.Text = "0";
                    }
                    else
                    {
                        ValorCopagoFactura.Text = ValorModeradoraFactura.Text;
                    }

                    conexion.Close();
                }


                string sqlInsertar = "INSERT INTO FactAux(Documento, CodProced, DescProced, CantProced, Valor, ValorProced, EstratoCopago, Subtotal, CodUnidadFuncional, CodCentroC, CodRips, TipoServicio, cuotaModeradoraValor) VALUES('" + this.txt_documento.Text + "', '" + this.FacturaCodigoProcedimiento.Text + "', '" + FacturaDescProcedimiento.Text + "', '" + CantidadP + "', '" + ValorP + "', '" + ValorProcedP + "', '" + ValorCopagoFactura.Text + "', '" + subtotal + "', '" + FacturaCUF.Text + "', '" + FacturaCCC.Text + "', '" + this.FacturaRips.Text + "', '" + this.FacturaTipoServicio.Text + "', '" + Moderadora + "')";
                if (Datos.insertar(sqlInsertar))
                {
                    lbl_resultado.Text = "Error";
                }
                else
                {
                    fillgrillaCuerpoFactura();

                }

                TotalizarFactura(txt_documento.Text);
                //ENVIAR DATOS A RIPS CONSULTA

                if (CodRips <= 1)
                {
                    GCCodProced.Text = FacturaCodigoProcedimiento.Text;         //Codigo del Procedimiento Rips Consultas
                    GCFinalidadPYP.Text = FinalidadPYP;                         //Finalidad Rips Consultas
                    GCCExterna.Text = Cext;                                    //Causa Externa Rips Consultas
                    Modal_CodProced.Text = GCCodProced.Text;
                    Modal_ddlFinalidadConsulta.ClearSelection();
                    Modal_ddlCausaEterna.ClearSelection();
                    if (GCFinalidadPYP.Text != string.Empty)
                    {
                        Modal_ddlFinalidadConsulta.Items.FindByValue(GCFinalidadPYP.Text).Selected = true;
                    }
                    if (GCCExterna.Text != string.Empty)
                    {
                        Modal_ddlCausaEterna.Items.FindByValue(GCCExterna.Text).Selected = true;
                    }
                    btn_ripsConsulta.Enabled = true;
                    btn_ripsProced.Enabled = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRipsConsulta();", true);
                }

                //ENVIAR DATOS A RIPS PROCEDIMIENTO

                if (CodRips > 1 && CodRips <= 5)
                {
                    GPCodProced.Text = FacturaCodigoProcedimiento.Text;
                    GPAmbito.Text = "1";
                    GPFinalidad.Text = FinalidadPYP;
                    RPCodProced.Text = GPCodProced.Text;
                    //RPAmbito.Text = GPAmbito.Text;
                    RPFinalidad.ClearSelection();
                    RPFinalidad.ClearSelection();
                    if (GPFinalidad.Text != string.Empty)
                    {
                        RPFinalidad.Items.FindByValue(GPFinalidad.Text).Selected = true;
                    }
                    btn_ripsProced.Enabled = true;
                    btn_ripsConsulta.Enabled = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRipsProced();", true);
                }

                txt_codProcedimiento.Text = string.Empty;

                txt_procedimiento.Text = string.Empty;

                

            }
            else
            {
                btn_ripsConsulta.Enabled = false;
                btn_ripsProced.Enabled = false;
                lbl_resultado.Text = "Actividad primer nivel POS-S," + ddl_ips.SelectedItem + "no cubre este Procedimiento por no estar contratado en el capitado actual, debe facturarlo por evento";
                return;
            }
            conexion.Close();


        }

        protected void btn_GuardarFactura_Click(object sender, EventArgs e)
        {
            int CodigoRip = 0;
            CodigoRip = Convert.ToInt32(CodRipsP.Text);
            //ACTUALIZO LOS VALORES TOTALES
            TotalizarFactura(txt_documento.Text);

            ////PENDIENTE SECCION DE ADMISION//
            //string queryAdmision = "SELECT Admisiones.NumeroAdmision AS NumAdmision, Admisiones.TipoAdmision AS TipoAdmision, HistoricoPte.Hdocumento AS PDocumento, Admisiones.DocumentoPaciente AS DocumentoP, Admisiones.Estado AS EstadoAdmision, HistoricoPte.Hentidad AS Entidad, HistoricoPte.Hcontrato AS Contrato, HistoricoPte.Htipocontrato AS TipoContrato, HistoricoPte.Hcodproced AS CodProced, HistoricoPte.Hfechaservicio AS FechaServicio, HistoricoPte.Hcantidad AS Cantidad, HistoricoPte.Hcodprof AS CodProfesional, HistoricoPte.Hfinalidad as Finalidad, HistoricoPte.Hcausaexterna as CausaExt, HistoricoPte.hdxppal, HistoricoPte.htdxppal, HistoricoPte.hdxr1, HistoricoPte.hdxr2, HistoricoPte.hdxr3, HistoricoPte.hpatiende, HistoricoPte.hcantorden, HistoricoPte.hcantdesp, HistoricoPte.hufuncional, HistoricoPte.hccosto, HistoricoPte.hconceptoRIPS " & _
            // "FROM Admisiones INNER JOIN HistoricoPte ON (Admisiones.TipoAdm = HistoricoPte.HTipoAdmision) AND (Admisiones.NumeroAdm = HistoricoPte.HnumAdmision) " & _
            // "WHERE (((HistoricoPte.Hdocumento)= '" & txtDocumento.Text & "') AND ((Admisiones.Estado)=0 Or (Admisiones.Estado)=1))""

             string query = "SELECT Admisiones.NumeroAdmision AS NumAdmision, Admisiones.TipoAdmision AS TipoAdmision, HistoricoPte.Hdocumento, Admisiones.DocumentoPaciente, Admisiones.Estado AS Estado, HistoricoPte.Hentidad, HistoricoPte.Hcontrato, HistoricoPte.Htipocontrato, HistoricoPte.Hcodproced, HistoricoPte.Hfechaservicio, HistoricoPte.Hcantidad, HistoricoPte.Hcodprof, HistoricoPte.Hfinalidad, HistoricoPte.Hcausaexterna, HistoricoPte.Hdxppal, HistoricoPte.htdxppal, HistoricoPte.Hdr1, HistoricoPte.Hdr2, HistoricoPte.Hdr3, HistoricoPte.Hpatiende, HistoricoPte.CantidadOrden, HistoricoPte.CantidadDespachado, HistoricoPte.Hufuncional, HistoricoPte.Hcentrocostos, HistoricoPte.HconceptoRips FROM Admisiones INNER JOIN HistoricoPte ON (Admisiones.TipoAdmision = HistoricoPte.Htipoadmision) AND (Admisiones.NumeroAdmision = HistoricoPte.HnumAdmision) WHERE (((HistoricoPte.Hdocumento)= '" + this.txt_documento.Text + "') AND ((Admisiones.Estado)=0 OR (Admisiones.Estado)=1))";
                SqlConnection conexionAdmisiones = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexionAdmisiones);
                conexionAdmisiones.Open();
                SqlDataReader leerA = comandoA.ExecuteReader();
                if (leerA.Read() == true)
                {
                    if (leerA["Estado"].ToString() == "0" && Liquidara.Text == "Si")
                    {
                        lbl_resultado.Text = "No se puede generar la factura, el paciente no tiene orden de salida";
                        return;
                    }
                    else
                    {
                        NumeroAdmision.Text = leerA["NumAdmision"].ToString();
                        TipoAdmision.Text = leerA["TipoAdmision"].ToString();
                    }
                }
                conexionAdmisiones.Close();

            //****************************************
            double VTC = 0;//Valor de Copago

            int ConsecutivoFactura = 0;//CONSECUTIVO PARA NUMERO DE FACTURA

            //VALIDAMOS LOS CAMPOS DE LA FACTURA

            if (ddl_ips.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "No ha seleccionado la IPS";
                return;
            }

            if (txt_codpyp.Text == string.Empty)
            {
                lbl_resultado.Text = "No ha seleccionado un programa PYP";
                return;

            }
            if (txt_codprofesional.Text == string.Empty)
            {
                lbl_resultado.Text = "No ha seleccionado el Profesional";
                return;
            }

            //VERIFICO SI YA CARGUE LOS RIPS DE CONSULTA
            SqlConnection conexion2 = new SqlConnection(ruta);
            if (CodigoRip <= 1)
            {
                string busqueda = "SELECT * FROM RipsConsultaAuxiliar WHERE Documento='" + this.txt_documento.Text + "'";
                SqlCommand comando = new SqlCommand(busqueda, conexion2);
                conexion2.Open();
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read() == false)
                {
                    lbl_resultado.Text = "No ha cargado los Rips de Consulta";
                    return;
                }
                conexion2.Close();
            }

            //VERIFICO SI YA CARGUE LOS RIPS DE PROCEDIMIENTO
            if (CodigoRip > 1 && CodigoRip <= 5)
            {
                string busqueda2 = "SELECT * FROM RipsProcedAuxiliar WHERE Documento='" + this.txt_documento.Text + "'";
                SqlCommand comando2 = new SqlCommand(busqueda2, conexion2);
                conexion2.Open();
                SqlDataReader leer2 = comando2.ExecuteReader();
                if (leer2.Read() == false)
                {
                    lbl_resultado.Text = "No ha cargado los Rips de Procedimiento";
                    return;
                }
                conexion2.Close();
            }
           
            if (txt_tipousuario.Text == "Contributivo")
            {
                if (ddl_servicio.SelectedValue == "1")
                {
                    if (FacturaTipoAfiliado.Text == "Cotizante")
                    {
                        VTC = Convert.ToDouble(ValorModeradoraFactura.Text);
                    }
                    else
                    {
                        VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
                    }
                }
                if (ddl_servicio.SelectedValue == "2")
                {
                    VTC = 0;
                }
                if (ddl_servicio.SelectedValue == "3")
                {
                    if (FacturaTipoAfiliado.Text == "Cotizante")
                    {
                        VTC = 0;
                    }
                    else
                    {
                        VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
                    }
                }
                if (ddl_servicio.SelectedValue == "4")
                {
                    if (FacturaTipoAfiliado.Text == "Cotizante")
                    {
                        VTC = 0;
                    }
                    else
                    {
                        VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
                    }
                }
            }
            if (txt_tipousuario.Text == "Subsidiado")
            {
                VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
            }
            if (txt_tipousuario.Text == "Vinculado")
            {
                VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
            }
            if (txt_tipousuario.Text == "Particular")
            {
                VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
            }
            if (txt_tipousuario.Text == "Otro")
            {
                VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
            }
            if (txt_tipousuario.Text == "Desplazado Contributivo")
            {
                if (ddl_servicio.SelectedValue == "1")
                {
                    if (FacturaTipoAfiliado.Text == "Cotizante")
                    {
                        VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
                    }
                    else
                    {
                        VTC = Convert.ToDouble(ValorModeradoraFactura.Text);
                    }
                }
                if (ddl_servicio.SelectedValue == "2")
                {
                    VTC = 0;
                }
                if (ddl_servicio.SelectedValue == "3")
                {
                    if (FacturaTipoAfiliado.Text == "Cotizante")
                    {
                        VTC = 0;
                    }
                    else
                    {
                        VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
                    }
                }
                if (ddl_servicio.SelectedValue == "4")
                {
                    if (FacturaTipoAfiliado.Text == "Cotizante")
                    {
                        VTC = 0;
                    }
                    else
                    {
                        VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
                    }
                }
            }
            if (txt_tipousuario.Text == "Desplazado Subsidiado")
            {
                VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
            }
            if (txt_tipousuario.Text == "Desplazado Vinculado")
            {
                VTC = Convert.ToDouble(valorTotalFinalCopago.Text);
            }
            //string fechaFactura = ViewHelper.ConvertToDate(txt_fecha.Text);
            DateTime Fecha = DateTime.Now;

            string Mes = Fecha.Month.ToString();
            string Year = Fecha.Year.ToString();
             //OBTENGO EL Consecutivo de la factura
                string contrato = "SELECT * FROM Consecutivos WHERE TipoCont='" + FacturaTipoContrato.Text + "'";
                SqlCommand comandoOrden = new SqlCommand(contrato, conexion2);
                conexion2.Open();
                SqlDataReader leerO = comandoOrden.ExecuteReader();
                if (leerO.Read() == true)
                {
                    ConsecutivoFactura = Convert.ToInt32(leerO["NumActual"].ToString());
                    PrefijoFactura.Text = leerO["Prefijo"].ToString();
                }
                conexion2.Close();
                ConsecutivoFactura = ConsecutivoFactura + 1;
            try
            {
               string tipofactura=string.Empty;
               if (FacturaTipoContrato.Text == "1") tipofactura = "Factura de Venta";
               if (FacturaTipoContrato.Text == "2") tipofactura = "Orden de Servicio";
                string sqlGuardar = "INSERT INTO FacturaCab(NumFac, TipoDoc, Prefijo, CodEntidad, CodContrato, PDocumento, FechaFactura, VrTotalProced, VrTotalCopago, VrTotalEntidad, Mes, Year1, Usuario, codips, codprogpyp, codprof, observacion, FamiliasAccion, DemandaInducida, CodigoServicio, Estado, ipsNombre, ValorEnLetras, TipoFactura) VALUES('" + ConsecutivoFactura + "', '" + this.FacturaTipoContrato.Text + "', '" + this.PrefijoFactura.Text + "', '" + this.FacturaCodigoEntidad.Text + "', '" + this.FacturaCodigoContrato.Text + "', '" + this.txt_documento.Text + "', '" + Fecha + "', '" + this.valorTotalFinalProced.Text + "', '" + VTC.ToString() + "', '" + this.ValorTotalFinalSubtotal.Text + "', '" + Mes.ToString() + "', '" + Year.ToString() + "', '" + this.CodigoEnSesion.Text + "', '" + this.ddl_ips.SelectedValue + "', '" + this.ddl_pyp.SelectedValue + "', '" + this.txt_codprofesional.Text + "', '" + this.txt_observacion.Text + "', '" + this.FacturaFamiliasAccion.Text + "', '" + this.FacturaDemandaInducida.Text + "', '" + this.ddl_servicio.SelectedValue + "', '0', '" + this.ddl_ips.SelectedItem.ToString() + "', '" + this.txt_ValorLetras.Text + "', '"+tipofactura+"')";
                if (Datos.insertar(sqlGuardar))
                {
                    lbl_resultado.Text = "Error al almacenar Factura";
                    return;
                }
                else
                {
                    if (NumeroAdmision.Text != string.Empty && TipoAdmision.Text != string.Empty && Liquidara.Text == "Si")
                    {
                        string UpdateAdmisiones = "UPDATE Admisiones SET Estado='2', NumeroFactura='" + ConsecutivoFactura + "', Prefijo='" + this.PrefijoFactura.Text + "' WHERE DocumentoPaciente='" + this.txt_documento.Text + "'";
                        if (Datos.insertar(UpdateAdmisiones))
                        {
                            lbl_resultado.Text = "Error al almacenar Factura";
                            return;
                        }
                        else
                        {
                            if (TipoAdmision.Text == "1")
                            {
                                string Camas = "UPDATE Camas SET Estado='0' Estado='" + this.NumeroAdmision.Text + "'";
                                if (Datos.insertar(Camas))
                                {
                                    lbl_resultado.Text = "Error al almacenar Factura";
                                    return;
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                    foreach (GridViewRow row in GridCuerpoFactura.Rows)
                    {
                        string codproced = HttpUtility.HtmlDecode(row.Cells[0].Text);
                        string desproced = HttpUtility.HtmlDecode(row.Cells[1].Text);
                        string cantidad = HttpUtility.HtmlDecode(row.Cells[2].Text);
                        string valorproced = HttpUtility.HtmlDecode(row.Cells[3].Text);
                        string valorunit = HttpUtility.HtmlDecode(row.Cells[4].Text);
                        string valorcopago = HttpUtility.HtmlDecode(row.Cells[5].Text);
                        string valortotal = HttpUtility.HtmlDecode(row.Cells[6].Text);
                        string unidfuncional = HttpUtility.HtmlDecode(row.Cells[7].Text);
                        string controcosto = HttpUtility.HtmlDecode(row.Cells[8].Text);
                        string rips = HttpUtility.HtmlDecode(row.Cells[9].Text);
                        string tiposerv = HttpUtility.HtmlDecode(row.Cells[10].Text);
                        
                        string sqlCuerpo = "INSERT INTO FacturaDet(numfac, TipoDoc, codentidad, codcontrato, codproced, cantidad, vrproced, vrcopago, vrentidad, CodProf, CUfuncional, CCentroCosto, conceptoRips, tipoServicio, fechaproced, Mes, Year1, desproced) VALUES('" + ConsecutivoFactura + "', '" + this.FacturaTipoContrato.Text + "', '" + this.FacturaCodigoEntidad.Text + "', '" + this.FacturaCodigoContrato.Text + "', '" + codproced + "', '" + cantidad + "', '" + valorproced + "', '" + valorcopago + "', '" + valortotal + "', '" + this.txt_codprofesional.Text + "', '" + unidfuncional + "', '" + controcosto + "', '" + rips + "', '" + tiposerv + "', '" + Fecha + "', '" + Mes.ToString() + "', '" + Year.ToString() + "', '" + desproced + "')";
                        if (Datos.insertar(sqlCuerpo))
                        {
                            lbl_resultado.Text = "Error al almacenar la factura";
                            return;
                        }
                        int codRIP = Convert.ToInt32(rips);
                        if (codRIP <= 1)
                        {
                            foreach (GridViewRow Rips in GridRipsConsulta.Rows)
                            {
                                string cProced = HttpUtility.HtmlDecode(Rips.Cells[0].Text);
                                string finalidad = HttpUtility.HtmlDecode(Rips.Cells[1].Text);
                                string causaext = HttpUtility.HtmlDecode(Rips.Cells[2].Text);
                                string diagprin = HttpUtility.HtmlDecode(Rips.Cells[3].Text);
                                string tipodiag = HttpUtility.HtmlDecode(Rips.Cells[4].Text);
                                string diag1 = HttpUtility.HtmlDecode(Rips.Cells[5].Text);
                                string diag2 = HttpUtility.HtmlDecode(Rips.Cells[6].Text);
                                string diag3 = HttpUtility.HtmlDecode(Rips.Cells[7].Text);
                                int estadoRip = 0;
                                if (finalidad != "" && causaext != "" && diagprin.Length>=4 && tipodiag != "")
                                {
                                    estadoRip = 1;
                                }
                                string actRipsC = "UPDATE FacturaDet SET finalidad='" + finalidad + "', causaexterna='" + causaext + "', DxPpal='" + diagprin + "', TDxPpal='" + tipodiag + "', DxR1='" + diag1 + "', DxR2='" + diag2 + "', DxR3='" + diag3 + "', estadoRips='"+estadoRip.ToString()+"' WHERE numfac='" + ConsecutivoFactura + "' AND codproced='" + cProced + "'";
                                if (Datos.insertar(actRipsC))
                                {
                                    lbl_resultado.Text = "Error al almacenar la factura";
                                    return;
                                }
                            }
                        }
                        if (codRIP > 1 && codRIP <= 5)
                        {
                            foreach (GridViewRow Proced in GridRipsProced.Rows)
                            {
                                string cproced = HttpUtility.HtmlDecode(Proced.Cells[0].Text);
                                string ambito = HttpUtility.HtmlDecode(Proced.Cells[1].Text);
                                string finalidadProced = HttpUtility.HtmlDecode(Proced.Cells[2].Text);
                                string personaAtiende = HttpUtility.HtmlDecode(Proced.Cells[3].Text);
                                string diagPpal = HttpUtility.HtmlDecode(Proced.Cells[4].Text);
                                string diagR = HttpUtility.HtmlDecode(Proced.Cells[5].Text);
                                string diagC = HttpUtility.HtmlDecode(Proced.Cells[6].Text);
                                int estadoRip = 0;
                                if (ambito != "" && finalidadProced != "" && personaAtiende != "" && diagPpal.Length>=4)
                                {
                                    estadoRip = 1;
                                }
                                string actRipsP = "UPDATE FacturaDet SET ambitoproced='" + ambito + "', finalidad='" + finalidadProced + "', PersonaAtiende='" + personaAtiende + "', DxPpal='" + diagPpal + "', DxR1='" + diagR + "', DxR2='" + diagC + "', estadoRips='"+estadoRip+"' WHERE numfac='" + ConsecutivoFactura + "' AND codproced='" + cproced + "'";
                                if (Datos.insertar(actRipsP))
                                {
                                    lbl_resultado.Text = "Error al almacenar la factura";
                                    return;
                                }
                            }
                        }

                    }

                    ConsecutivoF.Text = ConsecutivoFactura.ToString();
                    string consec = "UPDATE Consecutivos SET NumActual='" + this.ConsecutivoF.Text + "' WHERE TipoCont='" + this.FacturaTipoContrato.Text + "'";
                    if (Datos.insertar(consec))
                    {
                        lbl_resultado.Text = "Error al almacenar Factura";
                        return;
                    }
                    else
                    {
                        if (VTC > 0)
                        {


                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupPagarCopago();", true);

                        }
                        else
                        {
                            //string sql = "SELECT E.NombreEntidad, E.NIT, c.Descripcion, FC.NumFac, FC.FechaFactura, p.TipoDocumento, FC.ValorEnLetras, FC.TipoFactura, p.Documento, p.Nombre1, p.Nombre2, p.Apellido1, p.Apellido2, fd.codproced, fd.desproced, fc.VrTotalProced, fc.VrTotalCopago, fc.VrTotalEntidad, fc.Prefijo, Proced.DescProcedimiento, fd.cantidad, fd.vrproced, fd.vrcopago, fd.vrentidad, u.Nombre, p.Edad, p.Estrato, est.Descripcion, FC.ipsNombre FROM Entidad AS e, Contratos AS c, FacturaCab AS fc, FacturaDet AS fd, Pacientes AS p, Procedimientos AS proced, Usuarios AS u, Estratos AS Est WHERE fc.NumFac = fd.numfac And fc.TipoDoc = fd.TipoDoc And p.Documento = fc.PDocumento And e.Codigo = fc.CodEntidad And e.Codigo = c.Entidad And c.Entidad = fc.CodEntidad And proced.CodProcedimiento = fd.codproced And c.Codigo = fc.CodContrato And p.Estrato = est.Descripcion And fc.Usuario = u.CodUsuario And fc.NumFac = '" + ConsecutivoF.Text + "' And fc.TipoDoc = '" + this.FacturaTipoContrato.Text + "' And fc.Estado = '0'";
                            //ImprimirFactura(sql);
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupImprimir();", true);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                lbl_resultado.Text = ex.ToString();
                string EliminarFactCab = "DELETE FROM FacturaCab WHERE NumFac='" + ConsecutivoFactura + "' AND TipoDoc='" + this.FacturaTipoContrato.Text + "'";
                if (Datos.insertarcobro(EliminarFactCab))
                {
                   
                }
                string EliminarFactDet = "DELETE FROM FacturaDet WHERE numfac='" + ConsecutivoFactura + "' AND TipoDoc='" + this.FacturaTipoContrato.Text + "'";
                if (Datos.insertarcobro(EliminarFactDet))
                {
                    
                }
            }

            
            // 'COLOCAR LA ADSION COMO FACTURADA Y NUMERO DE FACTURA CORRESPONDIENTE





        }

        public void CleanControl(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    CleanControl(control.Controls);
            }
        }
        protected void PagaCopago_Click(object sender, EventArgs e)
        {
            MPNumFactura.Text = ConsecutivoF.Text;
            MP_Nombre.Text = txt_nombre.Text;
            MP_Documento.Text = txt_documento.Text;
            MP_Fecha.Text = DateTime.Now.ToShortDateString();

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupFormCopago();", true);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            double ConsecutivoLetra = 0;
            string prefijo;
            if (MP_ddl_Municipio.SelectedValue == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un Municipio";
                return;

            }
            string sql = "SELECT * FROM Consecutivos WHERE TipoCont='17'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comandoOrden = new SqlCommand(sql, conexion2);
            conexion2.Open();
            SqlDataReader leerO = comandoOrden.ExecuteReader();
            if (leerO.Read() == true)
            {
                ConsecutivoLetra = Convert.ToDouble(leerO["NumActual"].ToString());
                prefijo = leerO["Prefijo"].ToString();
            }
            conexion2.Close();
            ConsecutivoLetra = ConsecutivoLetra + 1;
            string detalle = "Valor copago y/o cuota moderadora factura " + ConsecutivoF.Text;
            DateTime fecha = DateTime.Now.AddHours(+2);
            DateTime fvence = fecha.AddDays(30);
            string insertar = "INSERT INTO CuentasporCobrar(NumFactura, CodigoCliente, Detalle, Fecha, ValorFactura, ValorAbonos, ValorSaldo, CodigoVendedor, Ciudad, NumeroLetraCambio, FechaVence, ValorPagado) VALUES('" + this.ConsecutivoF.Text + "', '" + this.txt_documento.Text + "', '" + detalle + "', '" + fecha + "', '" + this.MP_ValordEudausuario.Text + "', '0', '" + this.MP_ValordEudausuario.Text + "', '" + this.CodigoEnSesion.Text + "', '" + this.MP_ddl_Municipio.SelectedValue + "', '" + ConsecutivoLetra + "', '" + fvence + "', '" + this.MP_ValorFacturaUsuario.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al almacenar Factura";
                return;
            }
            else
            {
                string consec = "UPDATE Consecutivos SET NumActual='" + ConsecutivoLetra + "' WHERE TipoCont='17'";
                if (Datos.insertar(consec))
                {
                    lbl_resultado.Text = "Error al almacenar Factura";
                    return;
                }
                else
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "Close Modal Popup", "();", true);

                    string sql2 = "SELECT E.NombreEntidad, E.NIT, c.Descripcion, FC.NumFac, FC.FechaFactura, p.TipoDocumento, FC.ValorEnLetras, FC.TipoFactura, p.Documento, p.Nombre1, p.Nombre2, p.Apellido1, p.Apellido2, fd.codproced, fd.desproced, fc.VrTotalProced, fc.VrTotalCopago, fc.VrTotalEntidad, fc.Prefijo, Proced.DescProcedimiento, fd.cantidad, fd.vrproced, fd.vrcopago, fd.vrentidad, u.Nombre, p.Edad, p.Estrato, est.Descripcion, FC.ipsNombre FROM Entidad AS e, Contratos AS c, FacturaCab AS fc, FacturaDet AS fd, Pacientes AS p, Procedimientos AS proced, Usuarios AS u, Estratos AS Est WHERE fc.NumFac = fd.numfac And fc.TipoDoc = fd.TipoDoc And p.Documento = fc.PDocumento And e.Codigo = fc.CodEntidad And e.Codigo = c.Entidad And c.Entidad = fc.CodEntidad And proced.CodProcedimiento = fd.codproced And c.Codigo = fc.CodContrato And p.Estrato = est.Descripcion And fc.Usuario = u.CodUsuario And fc.NumFac = '" + ConsecutivoF.Text + "' And fc.TipoDoc = '" + this.FacturaTipoContrato.Text + "' And fc.Estado = '0'";
                    ImprimirFactura(sql2);

                }
            }
        }

        protected void sipagocopago_Click(object sender, EventArgs e)
        {
            string sql2 = "SELECT E.NombreEntidad, E.NIT, c.Descripcion, FC.NumFac, FC.FechaFactura, p.TipoDocumento, FC.ValorEnLetras, FC.TipoFactura, p.Documento, p.Nombre1, p.Nombre2, p.Apellido1, p.Apellido2, fd.codproced, fd.desproced, fc.VrTotalProced, fc.VrTotalCopago, fc.VrTotalEntidad, fc.Prefijo, Proced.DescProcedimiento, fd.cantidad, fd.vrproced, fd.vrcopago, fd.vrentidad, u.Nombre, p.Edad, p.Estrato, est.Descripcion, FC.ipsNombre FROM Entidad AS e, Contratos AS c, FacturaCab AS fc, FacturaDet AS fd, Pacientes AS p, Procedimientos AS proced, Usuarios AS u, Estratos AS Est WHERE fc.NumFac = fd.numfac And fc.TipoDoc = fd.TipoDoc And p.Documento = fc.PDocumento And e.Codigo = fc.CodEntidad And e.Codigo = c.Entidad And c.Entidad = fc.CodEntidad And proced.CodProcedimiento = fd.codproced And c.Codigo = fc.CodContrato And p.Estrato = est.Descripcion And fc.Usuario = u.CodUsuario And fc.NumFac = '" + ConsecutivoF.Text + "' And fc.TipoDoc = '" + this.FacturaTipoContrato.Text + "' And fc.Estado = '0'";
            ImprimirFactura(sql2);

        }

        private void ImprimirFactura(string sql)
        {
            string id = "PDF"; // get this from another control on your page
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "Facturas.rdlc");
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
            "  <PageHeight>11in</PageHeight>" +
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
            Response.AddHeader("content-disposition", "attachment; filename= ReporteFactura." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);

            Response.End();
        }

        protected void btn_liquidaSI_Click(object sender, EventArgs e)
        {
            Liquidara.Text = "Si";
            Modal_CodProced.Text = string.Empty;
            Modal_CodD1.Text = string.Empty;
            Modal_CodD2.Text = string.Empty;
            Modal_CodD3.Text = string.Empty;
            Modal_CodDiagP.Text = string.Empty;
            Modal_ddlCausaEterna.ClearSelection();
            Modal_ddlTipoDX.ClearSelection();
            Modal_DescD1.Text = string.Empty;
            Modal_DescD2.Text = string.Empty;
            Modal_DescD3.Text = string.Empty;
            Modal_DescDiagP.Text = string.Empty;

            ddl_ambito.ClearSelection();
            RPCodDiagC.Text = string.Empty;
            RPCodDiagP.Text = string.Empty;
            RPCodDiaGR.Text = string.Empty;
            RPCodProced.Text = string.Empty;
            RPDDiagC.Text = string.Empty;
            RPDDiagR.Text = string.Empty;
            RPDDiangP.Text = string.Empty;
            RPFinalidad.ClearSelection();
            ddl_personal.ClearSelection();

            string consulta = "SELECT Admisiones.NumeroAdmision AS NUMADMISION, Admisiones.TipoAdmision AS TIPOADMISION, HistoricoPte.Hdocumento AS DocumentoPaciente, Admisiones.DocumentoPaciente AS DOCUMENTOADMISION, Admisiones.Estado AS ESTADOADMISION, HistoricoPte.Hentidad AS CodigoEntidad, HistoricoPte.Hcontrato AS CodigoContrato, HistoricoPte.htipocontrato AS TIPOCONTRATO, HistoricoPte.Hcodproced AS CodigoProced, HistoricoPte.Hfechaservicio AS FECHASERVICIO, HistoricoPte.Hcantidad AS CantidadProced, HistoricoPte.Hcodprof AS PROFESIONAL, HistoricoPte.Hfinalidad AS FINALIDAD, HistoricoPte.Hcausaexterna AS CEXTERNA, HistoricoPte.Hdxppal AS DXP, HistoricoPte.Htdxppal AS TDXP, HistoricoPte.Hdr1 AS DXR1, HistoricoPte.Hdr2 AS DXR2, HistoricoPte.Hdr3 AS DXR3, HistoricoPte.Hpatiende AS PATIENDE, HistoricoPte.CantidadOrden AS CANTORDENADA, HistoricoPte.CantidadDespachado AS CANTDESPACHADO, HistoricoPte.Hufuncional AS UFUNCIONAL, HistoricoPte.Hcentrocostos AS CENTROC, HistoricoPte.HconceptoRips AS CONCEPTORIPS, HistoricoPte.cirujano AS CIRUJANO, HistoricoPte.aneste AS ANESTE, HistoricoPte.ayudantia AS AYUDANTE, HistoricoPte.DerSalacx AS SALACX, HistoricoPte.Materiales AS MATERIALES, HistoricoPte.materialesIncruento AS MATEINCRUENTO, HistoricoPte.FormaActoQx AS FORMAACTO, HistoricoPte.Incruento AS INCRUENTO, HistoricoPte.BilateralMultiple AS BILATERAL, HistoricoPte.GrupoQx AS GRUPOQ, HistoricoPte.Codpadre AS CODPADRE, HistoricoPte.Orden AS ORDEN, HistoricoPte.PorcLiquidacion AS PORCLIQUI FROM Admisiones INNER JOIN HistoricoPte ON (Admisiones.TipoAdmision = HistoricoPte.HtipoAdmision) AND (Admisiones.NumeroAdmision = HistoricoPte.HnumAdmision) WHERE HistoricoPte.Hdocumento= '" + this.txt_buscar.Text + "' AND Admisiones.Estado='1' ORDER BY HistoricoPte.Orden, HistoricoPte.Codpadre, HistoricoPte.GrupoQx DESC, HistoricoPte.HconceptoRIPS";
            SqlConnection conexionHistorico = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(consulta, conexionHistorico);
            conexionHistorico.Open();

            SqlDataReader leerHPT = comando.ExecuteReader();

            while (leerHPT.Read())
            {
                CodContrato.Text = leerHPT["CodigoContrato"].ToString();
                CodEntidadT.Text = leerHPT["CodigoEntidad"].ToString();
                CodProcedT.Text = leerHPT["CodigoProced"].ToString();
               //PREGUNTO POR EL TIPO DE ADMISION
                CodigoTipoAdmsion.Text = leerHPT["TIPOADMISION"].ToString();
                if (CodigoTipoAdmsion.Text == "0")//AMBULATORIO
                {
                    ddl_servicio.ClearSelection();
                    ddl_servicio.Items.FindByValue("3").Selected = true;
                    ddl_pyp.ClearSelection();
                    ddl_pyp.Items.FindByValue("0").Selected = true;
                    txt_codpyp.Text = ddl_pyp.SelectedValue;
                }
                if (CodigoTipoAdmsion.Text == "1")//HOSPITALIZACION
                {
                    ddl_servicio.ClearSelection();
                    ddl_servicio.Items.FindByValue("4").Selected = true;
                    ddl_pyp.ClearSelection();
                    ddl_pyp.Items.FindByValue("0").Selected = true;
                    txt_codpyp.Text = ddl_pyp.SelectedValue;
                }
                if (CodigoTipoAdmsion.Text == "2")//URGENCIAS
                {
                    ddl_servicio.ClearSelection();
                    ddl_servicio.Items.FindByValue("2").Selected = true;
                    ddl_pyp.ClearSelection();
                    ddl_pyp.Items.FindByValue("0").Selected = true;
                    txt_codpyp.Text = ddl_pyp.SelectedValue;
                }
                if (leerHPT["DocumentoPaciente"].ToString() == leerHPT["DOCUMENTOADMISION"].ToString())
                {
                    txt_documento.Text = leerHPT["DocumentoPaciente"].ToString();
                }

                string query = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_buscar.Text + "'";
                SqlConnection conexionPaciente = new SqlConnection(ruta);
                SqlCommand comandoPacientes = new SqlCommand(query, conexionPaciente);
                conexionPaciente.Open();

                SqlDataReader Pac = comandoPacientes.ExecuteReader();

                if (Pac.Read() == true)
                {
                    lbl_resultado.Text = string.Empty;
                    txt_tipodoc.Text = Pac["TipoDocumento"].ToString();
                    string NombreCompleto = (Pac["Nombre1"].ToString()) + " " + (Pac["Nombre2"].ToString()) + " " + (Pac["Apellido1"].ToString()) + " " + (Pac["Apellido2"].ToString());
                    txt_nombre.Text = NombreCompleto;//nombre completo del paciente
                    txt_sexo.Text = Pac["Sexo"].ToString();
                    txt_zona.Text = Pac["Zona"].ToString();
                    txt_tipousuario.Text = Pac["TipoUsuario"].ToString();
                    FacturaTipoAfiliado.Text = Pac["TipoAfiliado"].ToString();
                    txt_estrato.Text = Pac["Estrato"].ToString();
                    DateTime fechaNcimiento = Convert.ToDateTime(Pac["FechaNacimiento"].ToString());
                    MP_Direccion.Text = Pac["Direccion"].ToString();
                    MP_Telefono.Text = Pac["Telefono"].ToString();
                    txt_fechanac.Text = fechaNcimiento.ToString("dd/MM/yyyy");

                    //SE BUSCA LA INFORMACION DEL ESTRATO DEL AFILIADO
                    string sql3 = "SELECT * FROM Estratos WHERE Descripcion='" + this.txt_estrato.Text + "'";
                    SqlConnection ConexionEstrato = new SqlConnection(ruta);
                    SqlCommand comando3 = new SqlCommand(sql3, ConexionEstrato);
                    ConexionEstrato.Open();
                    SqlDataReader leer3 = comando3.ExecuteReader();

                    if (leer3.Read() == true)
                    {
                        FacturaValorPorcEstrato.Text = leer3["Porcentaje"].ToString();
                        FacturaValorCuotaModeradora.Text = leer3["CuotaMderadora"].ToString();
                    }
                    ConexionEstrato.Close();
                    Edad.Text = DiferenciaFechas(DateTime.Now, fechaNcimiento);
                    //SE BUSCA EL CONTRATO Y LA ENTIDAD ASIGNADA DEL PACIENTE
                    string sql2 = "SELECT COUNT (*) FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_documento.Text + "'";
                    SqlConnection cuentaRegistro = new SqlConnection(ruta);

                    //***************************
                    //string sql2 = "SELECT COUNT(*) FROM PacientesEntidadContrato WHERE Documento='" + this.txt_buscar.Text + "'";
                    SqlCommand comando2 = new SqlCommand(sql2, cuentaRegistro);
                    cuentaRegistro.Open();
                    int count = Convert.ToInt32(comando2.ExecuteScalar());
                    cuentaRegistro.Close();

                    if (count > 1)
                    {
                        fillgrilla();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupContratos();", true);
                        this.lbl_contratos.Text = "Seleccione Contrato";
                    }

                    if (count == 1)
                    {
                        string sql5 = "SELECT Entidad.Codigo AS CodigoEntidad, Entidad.NombreEntidad AS NombreEntidad, Contratos.Codigo AS ContratoNumero, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                        SqlConnection conexionEntidad = new SqlConnection(ruta);
                        SqlCommand comando5 = new SqlCommand(sql5, conexionEntidad);
                        conexionEntidad.Open();
                        SqlDataReader leer2 = comando5.ExecuteReader();
                        if (leer2.Read() == true)
                        {
                            FacturaCodigoEntidad.Text = leer2["CodigoEntidad"].ToString();
                            txt_entidad.Text = leer2["NombreEntidad"].ToString();
                            FacturaCodigoContrato.Text = leer2["ContratoNumero"].ToString();
                            txt_contrato.Text = leer2["ContratoDescripcion"].ToString();
                            FacturaTipoContrato.Text = leer2["ContratoTipo"].ToString();

                        }
                        conexionEntidad.Close();

                    }
                    if (count == 0)
                    {
                        lbl_resultado.Text = "El Usuario no tiene empresa y contratos asignados o el contrato está anulado porque ya termino";
                        return;
                    }

                    //ME TRAIGO LOS PROCEDIMIENTOS
                    string sqlp = "SELECT Procedimientos.CodProcedimiento AS CodProced, Procedimientos.DescProcedimiento AS DescProced, Tarifas.Valor AS ValorTarifa, Planes.CodPlan AS CodigoPlan, PlanesContratos.Porcentaje AS PorcentajePC, Entidad.Codigo AS CodigoEntidad, Contratos.Codigo AS CodContrato, Procedimientos.CodRips AS RipsProced, Procedimientos.Finalidad AS FinalidadProced, PlanesContratos.Capita AS CopagoPC, Procedimientos.TipoServicio AS TipoServProced, PlanesContratos.CodigoTarifario AS CodTarifaPC FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento WHERE Procedimientos.CodProcedimiento= '" + leerHPT["CodigoProced"].ToString() + "' AND Contratos.Codigo= '" + leerHPT["CodigoContrato"].ToString() + "' AND Contratos.Entidad = '" + leerHPT["CodigoEntidad"].ToString() + "'";
                    SqlConnection conexionProcedimientos = new SqlConnection(ruta);
                    SqlCommand comandoProd = new SqlCommand(sqlp, conexionProcedimientos);
                    conexionProcedimientos.Open();
                    SqlDataReader leerProd = comandoProd.ExecuteReader();
                    if (leerProd.Read() == true)
                    {
                        FacturaCodigoProcedimiento.Text = leerProd["CodProced"].ToString();
                        FacturaDescProcedimiento.Text = leerProd["DescProced"].ToString();
                        FacturaCantidad.Text = leerHPT["CantidadProced"].ToString();

                        string ValorTarifa = leerProd["ValorTarifa"].ToString();
                        string porcentaje = leerProd["PorcentajePC"].ToString();
                        double Valor = 0;
                        double PorcentajeProd = 0;
                        double DescuentoEstrato = 0;
                        if (ValorTarifa == string.Empty || ValorTarifa == null)
                        {
                            Valor = 0;
                        }
                        else
                        {
                            Valor = Convert.ToDouble(ValorTarifa);           //Valor del Procedimiento
                        }
                        if (porcentaje == string.Empty || porcentaje == null)
                        {
                            PorcentajeProd = 0;
                        }
                        else
                        {
                            PorcentajeProd = Convert.ToDouble(porcentaje); //Porcentaje del Procedimiento
                        }
                        if (FacturaValorPorcEstrato.Text == string.Empty || FacturaValorPorcEstrato.Text == null)
                        {
                            DescuentoEstrato = 0;
                        }
                        else
                        {
                            DescuentoEstrato = Convert.ToDouble(FacturaValorPorcEstrato.Text);
                        }
                        double ValorProcedP = 0;
                        double ValorProced = 0;
                        if (Valor > 0)
                        {
                            ValorProced = (Valor * PorcentajeProd) / 100;
                            //FacturaValorUnitario.Text = Valor.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                            //FacturaValorProcedimiento.Text = ValorProced.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                            FacturaValorUnitarioSN.Text = Valor.ToString();                         //ValorUnitario del Procedimiento
                            FacturaValorProcedimientoSN.Text = ValorProced.ToString();              //Valor del Procedimiento
                            ValorProcedP = ValorProced;
                        }
                        else
                        {
                            ValorProcedP = Valor;
                            //FacturaValorUnitario.Text = Valor.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                            //FacturaValorProcedimiento.Text = Valor.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                            FacturaValorUnitarioSN.Text = Valor.ToString();
                            FacturaValorProcedimientoSN.Text = Valor.ToString();
                        }
                        double valorCopago = 0;
                        if (CodigoTipoAdmsion.Text != "2")
                        {
                            FacturaCobraCopago.Text = leerProd["CopagoPC"].ToString();

                            if (FacturaTipoAfiliado.Text == "Cotizante")                                //Tipo de Afiliado en Descripcion
                            {
                                if (txt_tipousuario.Text == "Contributivo" && FacturaCobraCopago.Text == "1")
                                {
                                    //ValorCopagoFactura.Text = FacturaValorCuotaModeradora.Text;
                                    ValorCopagoFactura.Text = FacturaValorCuotaModeradora.Text;       //Valor Cuota Moderadora
                                    ValorModeradoraFactura.Text = FacturaValorCuotaModeradora.Text;

                                }
                            }

                            if (FacturaTipoAfiliado.Text == "Beneficiario")
                            {
                                if (txt_tipousuario.Text == "Contributivo" && FacturaCobraCopago.Text == "1")
                                {

                                    valorCopago = Convert.ToInt32((ValorProced * DescuentoEstrato) / 100);
                                    ValorCopagoFactura.Text = valorCopago.ToString();                //Valor del Copago

                                }
                            }

                            if (txt_tipousuario.Text != "Contributivo" && FacturaCobraCopago.Text == "1" && FacturaTipoAfiliado.Text == string.Empty)
                            {
                                valorCopago = Convert.ToInt32((ValorProced * DescuentoEstrato) / 100);
                                ValorCopagoFactura.Text = valorCopago.ToString();
                            }
                        }

                        if (CodigoTipoAdmsion.Text == "2" && txt_tipousuario.Text == "Particular")
                        {
                            if (txt_tipousuario.Text != "Contributivo" && FacturaCobraCopago.Text == "1" && FacturaTipoAfiliado.Text == string.Empty)
                            {
                                valorCopago = Convert.ToInt32((ValorProced * DescuentoEstrato) / 100);
                                ValorCopagoFactura.Text = valorCopago.ToString();
                            }
                        }

                        double subtotal = 0;
                        subtotal = ValorProcedP - valorCopago;
                        string tiposervicioNombre;
                        double CodRips = 0;
                        FacturaRips.Text = leerProd["RipsProced"].ToString();
                        tiposervicioNombre = leerProd["TipoServProced"].ToString();
                        CodRips = Convert.ToInt32(leerProd["RipsProced"].ToString());
                        CodRipsP.Text = leerProd["RipsProced"].ToString();
                        double CantidadP = 0;
                        double ValorP = 0;
                        CantidadP = Convert.ToDouble(FacturaCantidad.Text);
                        ValorP = Convert.ToDouble(FacturaValorUnitarioSN.Text);

                        if (ValorModeradoraFactura.Text != string.Empty)
                        {
                            string sqlmod = "SELECT cuotaModeradoraValor FROM FactAux WHERE Documento='" + this.txt_documento.Text + "'";
                            SqlConnection conexionModeradora = new SqlConnection(ruta);
                            SqlCommand comandom = new SqlCommand(sqlmod, conexionModeradora);
                            conexionModeradora.Open();
                            SqlDataReader leerm = comandom.ExecuteReader();
                            if (leerm.Read() == true)
                            {
                                ValorCopagoFactura.Text = "0";
                            }
                            else
                            {
                                ValorCopagoFactura.Text = ValorModeradoraFactura.Text;
                            }

                            conexionModeradora.Close();
                        }

                        double Moderadora = 0;
                        string sqlInsertar = "INSERT INTO FactAux(Documento, CodProced, DescProced, CantProced, Valor, ValorProced, EstratoCopago, Subtotal, CodUnidadFuncional, CodCentroC, CodRips, TipoServicio, cuotaModeradoraValor, grupoQx, codpadre, orden) VALUES('" + this.txt_documento.Text + "', '" + this.FacturaCodigoProcedimiento.Text + "', '" + FacturaDescProcedimiento.Text + "', '" + CantidadP + "', '" + ValorP + "', '" + ValorProcedP + "', '" + ValorCopagoFactura.Text + "', '" + subtotal + "', '" + leerHPT["UFUNCIONAL"].ToString() + "', '" + leerHPT["CENTROC"].ToString() + "', '" + leerHPT["CONCEPTORIPS"].ToString() + "', '" + leerProd["TipoServProced"].ToString() + "', '" + Moderadora + "', '" + leerHPT["GRUPOQ"].ToString() + "', '" + leerHPT["CODPADRE"].ToString() + "', '" + leerHPT["ORDEN"].ToString() + "')";
                        if (Datos.insertar(sqlInsertar))
                        {
                            lbl_resultado.Text = "Error";
                        }
                        else
                        {
                            fillgrillaCuerpoFactura();
                        }

                        int CodigoRips = Convert.ToInt32(leerHPT["CONCEPTORIPS"].ToString());

                        //ENVIAR DATOS A RIPS CONSULTA
                        if (CodigoRips == 1)
                        {
                            string sql = "INSERT INTO RipsConsultaAuxiliar(Documento, CodProcedimiento, Finalidad, CausaEXT, DXPrincipal, TipoDXPrincipal, DX1, DX2, DX3) VALUES('" + this.txt_documento.Text + "', '" + leerHPT["CodigoProced"].ToString() + "', '" + leerHPT["FINALIDAD"].ToString() + "', '" + leerHPT["CEXTERNA"].ToString() + "', '" + leerHPT["DXP"].ToString() + "', '" + leerHPT["TDXP"].ToString() + "', '" + leerHPT["DXR1"].ToString() + "', '" + leerHPT["DXR2"].ToString() + "', '" + leerHPT["DXR3"].ToString() + "')";
                            if (Datos.insertar(sql))
                            {
                                lbl_resultado.Text = "No se modificó la información";
                            }
                            else
                            {
                                fillgrillaRipsConsulta();
                            }
                        }
                        if (CodigoRips > 1 && CodigoRips <= 5)
                        {
                            if (leerHPT["TIPOADMISION"].ToString() == "2")
                            {
                                Ambito.Text = "3";
                            }
                            else
                            {
                                Ambito.Text = "2";
                            }
                            string sql = "INSERT INTO RipsProcedAuxiliar(Documento, CodProcedimiento, Ambito, Finalidad, Personal, DPX, DCX, DRX) VALUES('" + this.txt_documento.Text + "', '" + leerHPT["CodigoProced"].ToString() + "', '" + this.Ambito.Text + "', '" + leerHPT["FINALIDAD"].ToString() + "', '" + leerHPT["PATIENDE"].ToString() + "', '" + leerHPT["DXP"].ToString() + "', '" + leerHPT["DXR1"].ToString() + "', '" + leerHPT["DXR2"].ToString() + "')";
                            if (Datos.insertar(sql))
                            {
                                lbl_resultado.Text = "No se modificó la información";
                            }
                            else
                            {
                                fillgrillaRipsProcedimientos();
                            }
                        }


                        //ENVIAR DATOS A RIPS PROCEDIMIENTO



                        TotalizarFactura(txt_documento.Text);

                    }//fin HTPTE
                    conexionProcedimientos.Close();

                }
                conexionPaciente.Close();



            }
            conexionHistorico.Close();

        }

        protected void btn_liquidaNO_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_buscar.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                Modal_CodProced.Text = string.Empty;
                Modal_CodD1.Text = string.Empty;
                Modal_CodD2.Text = string.Empty;
                Modal_CodD3.Text = string.Empty;
                Modal_CodDiagP.Text = string.Empty;
                Modal_ddlCausaEterna.ClearSelection();
                Modal_ddlTipoDX.ClearSelection();
                Modal_DescD1.Text = string.Empty;
                Modal_DescD2.Text = string.Empty;
                Modal_DescD3.Text = string.Empty;
                Modal_DescDiagP.Text = string.Empty;
                ddl_ambito.ClearSelection();
                RPCodDiagC.Text = string.Empty;
                RPCodDiagP.Text = string.Empty;
                RPCodDiaGR.Text = string.Empty;
                RPCodProced.Text = string.Empty;
                RPDDiagC.Text = string.Empty;
                RPDDiagR.Text = string.Empty;
                RPDDiangP.Text = string.Empty;
                RPFinalidad.ClearSelection();
                ddl_personal.ClearSelection();

                lbl_resultado.Text = string.Empty;

                txt_tipodoc.Text = leer["TipoDocumento"].ToString();
                txt_documento.Text = leer["Documento"].ToString();
                string NombreCompleto = (leer["Nombre1"].ToString()) + " " + (leer["Nombre2"].ToString()) + " " + (leer["Apellido1"].ToString()) + " " + (leer["Apellido2"].ToString());
                txt_nombre.Text = NombreCompleto;
                txt_sexo.Text = leer["Sexo"].ToString();
                txt_zona.Text = leer["Zona"].ToString();
                txt_tipousuario.Text = leer["TipoUsuario"].ToString();
                FacturaTipoAfiliado.Text = leer["TipoAfiliado"].ToString();
                txt_estrato.Text = leer["Estrato"].ToString();
                DateTime fechaNcimiento = Convert.ToDateTime(leer["FechaNacimiento"].ToString());
                MP_Direccion.Text = leer["Direccion"].ToString();
                MP_Telefono.Text = leer["Telefono"].ToString();
                txt_fechanac.Text = fechaNcimiento.ToShortDateString();
                conexion.Close();

                //SE BUSCA LA INFORMACION DEL ESTRATO DEL AFILIADO
                string sql3 = "SELECT * FROM Estratos WHERE Descripcion='" + this.txt_estrato.Text + "'";
                SqlCommand comando3 = new SqlCommand(sql3, conexion);
                conexion.Open();
                SqlDataReader leer3 = comando3.ExecuteReader();

                if (leer3.Read() == true)
                {
                    FacturaValorPorcEstrato.Text = leer3["Porcentaje"].ToString();
                    FacturaValorCuotaModeradora.Text = leer3["CuotaMderadora"].ToString();
                }
                conexion.Close();
                Edad.Text = DiferenciaFechas(DateTime.Now, Convert.ToDateTime(txt_fechanac.Text));

                //SE BUSCA EL CONTRATO Y LA ENTIDAD ASIGNADA DEL PACIENTE
                string sql2 = "SELECT COUNT (*) FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE  Pacientes.Documento= '" + this.txt_documento.Text + "'";


                //***************************
                //string sql2 = "SELECT COUNT(*) FROM PacientesEntidadContrato WHERE Documento='" + this.txt_buscar.Text + "'";
                SqlCommand comando2 = new SqlCommand(sql2, conexion);
                conexion.Open();
                int count = Convert.ToInt32(comando2.ExecuteScalar());
                conexion.Close();

                if (count > 1)
                {
                    fillgrilla();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupContratos();", true);
                    this.lbl_contratos.Text = "Seleccione Contrato";
                }

                if (count == 1)
                {
                    string sql5 = "SELECT Entidad.Codigo AS CodigoEntidad, Entidad.NombreEntidad AS NombreEntidad, Contratos.Codigo AS ContratoNumero, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                    SqlCommand comando5 = new SqlCommand(sql5, conexion);
                    conexion.Open();
                    SqlDataReader leer2 = comando5.ExecuteReader();
                    if (leer2.Read() == true)
                    {
                        FacturaCodigoEntidad.Text = leer2["CodigoEntidad"].ToString();
                        txt_entidad.Text = leer2["NombreEntidad"].ToString();
                        FacturaCodigoContrato.Text = leer2["ContratoNumero"].ToString();
                        txt_contrato.Text = leer2["ContratoDescripcion"].ToString();
                        FacturaTipoContrato.Text = leer2["ContratoTipo"].ToString();

                    }
                    conexion.Close();

                }
                if (count == 0)
                {
                    lbl_resultado.Text = "El Usuario no tiene empresa y contratos asignados o el contrato está anulado porque ya termino";
                    return;
                }

                string sql6 = "SELECT CodigoCliente, SUM(ValorSaldo) AS Total FROM CuentasporCobrar WHERE CodigoCliente='" + this.txt_buscar.Text + "' AND ValorSaldo>0 GROUP BY CodigoCliente";
                SqlCommand comando6 = new SqlCommand(sql6, conexion);
                conexion.Open();
                SqlDataReader leer6 = comando6.ExecuteReader();
                if (leer6.Read() == true)
                {
                    FacturaCodigoCliente.Text = leer6["CodigoCliente"].ToString();
                    ValorSaldo = Convert.ToDouble(leer6["Total"].ToString());
                    string SumaValor = ValorSaldo.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupDeudas();", true);
                    this.lbl_mensajedeuda.Text = "El usuario tiene una deuda pendiente de pago con la IPS de $ " + SumaValor;
                }
                conexion.Close();
                txt_RNTipodocumento.Text = txt_tipodoc.Text;
                txt_RNDocumento.Text = txt_documento.Text;
                txt_RNNombre.Text = txt_nombre.Text;
                txt_RNEntidad.Text = txt_entidad.Text;
                txt_RNContrato.Text = txt_contrato.Text;

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupNoexiste();", true);
                this.lbl_mensajeUsuario.Text = "El usuario no existe. ¿Desea Crearlo?";
                txt_documento.Text = string.Empty;
                txt_nombre.Text = string.Empty;
                txt_sexo.Text = string.Empty;
                txt_zona.Text = string.Empty;
                txt_tipousuario.Text = string.Empty;
                txt_estrato.Text = string.Empty;
                txt_fechanac.Text = string.Empty;
                Edad.Text = string.Empty;
                txt_entidad.Text = string.Empty;
                txt_contrato.Text = string.Empty;
                FacturaCodigoEntidad.Text = string.Empty;
                FacturaCodigoContrato.Text = string.Empty;
                lbl_resultado.Text = string.Empty;

            }
        }

        protected void btn_Nuevo_Click(object sender, EventArgs e)
        {
            Liquidara.Text = "No";
            CleanControl(this.Controls);
            ddl_ambito.ClearSelection();
            ddl_controlprenatal.ClearSelection();
            ddl_ips.ClearSelection();
            ddl_personal.ClearSelection();
            ddl_profesional.ClearSelection();
            ddl_pyp.ClearSelection();
            ddl_RNSexo.ClearSelection();
            ddl_servicio.ClearSelection();
            MP_ddl_Municipio.ClearSelection();
            fillgrillaCuerpoFactura();
            fillgrillaRipsConsulta();
            fillgrillaRipsProcedimientos();
            
        }

        protected void btn_buscarNombre_Click(object sender, EventArgs e)
        {
            if (txt_nombrePac.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Documento de Identidad";
                return;
            }

            string sqlPac = "SELECT * FROM Pacientes WHERE (Nombre1+' '+Nombre2+' '+Apellido1+' '+Apellido2)='" + this.txt_nombrePac.Text + "'";
            SqlConnection conexionCodigo = new SqlConnection(ruta);
            SqlCommand comandoPac = new SqlCommand(sqlPac, conexionCodigo);
            conexionCodigo.Open();

            SqlDataReader leerPc = comandoPac.ExecuteReader();

            if (leerPc.Read() == true)
            {
                txt_buscar.Text = leerPc["Documento"].ToString();
            }
            else
            {
                lbl_resultado.Text = "Nombre de paciente no existe";
                return;
            }

            conexionCodigo.Close();
            string sqlEliminar = "DELETE FROM FactAux WHERE Documento='" + this.txt_buscar.Text + "'";
            if (Datos.insertar(sqlEliminar))
            {

            }
            else
            {
            }

            string RIPSC = "DELETE FROM RipsConsultaAuxiliar WHERE Documento='" + this.txt_buscar.Text + "'";
            if (Datos.insertar(RIPSC))
            {

            }
            else
            {
            }
            string RIPSP = "DELETE FROM RipsProcedAuxiliar WHERE Documento='" + this.txt_buscar.Text + "'";
            if (Datos.insertar(RIPSP))
            {

            }
            else
            {
            }
            fillgrillaCuerpoFactura();
            ddl_ips.ClearSelection();
            txt_procedimiento.Text = string.Empty;
            txt_codProcedimiento.Text = string.Empty;
            ddl_profesional.ClearSelection();
            ddl_pyp.ClearSelection();

            string query = "SELECT Admisiones.NumeroAdmision, Admisiones.TipoAdmision, HistoricoPte.Hdocumento, Admisiones.DocumentoPaciente, Admisiones.Estado, HistoricoPte.Hentidad, HistoricoPte.Hcontrato, HistoricoPte.Htipocontrato, HistoricoPte.Hcodproced, HistoricoPte.Hfechaservicio, HistoricoPte.Hcantidad, HistoricoPte.Hcodprof, HistoricoPte.Hfinalidad, HistoricoPte.Hcausaexterna, HistoricoPte.Hdxppal, HistoricoPte.htdxppal, HistoricoPte.Hdr1, HistoricoPte.Hdr2, HistoricoPte.Hdr3, HistoricoPte.Hpatiende, HistoricoPte.CantidadOrden, HistoricoPte.CantidadDespachado, HistoricoPte.Hufuncional, HistoricoPte.Hcentrocostos, HistoricoPte.HconceptoRips FROM Admisiones INNER JOIN HistoricoPte ON (Admisiones.TipoAdmision = HistoricoPte.Htipoadmision) AND (Admisiones.NumeroAdmision = HistoricoPte.HnumAdmision) WHERE (((HistoricoPte.Hdocumento)= '" + txt_buscar.Text + "') AND ((Admisiones.Estado)=0 OR (Admisiones.Estado)=1))";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comandoA = new SqlCommand(query, conexion);
            conexion.Open();

            SqlDataReader leerA = comandoA.ExecuteReader();

            if (leerA.Read() == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupLiquidarAdmision();", true);
                this.lbl_liquidar.Text = "El paciente tiene una admisión por liquidar. ¿Desea hacerlo ahora?";
            }
            else
            {
                string sql = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_buscar.Text + "'";
                //SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sql, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    Modal_CodProced.Text = string.Empty;
                    Modal_CodD1.Text = string.Empty;
                    Modal_CodD2.Text = string.Empty;
                    Modal_CodD3.Text = string.Empty;
                    Modal_CodDiagP.Text = string.Empty;
                    Modal_ddlCausaEterna.ClearSelection();
                    Modal_ddlTipoDX.ClearSelection();
                    Modal_DescD1.Text = string.Empty;
                    Modal_DescD2.Text = string.Empty;
                    Modal_DescD3.Text = string.Empty;
                    Modal_DescDiagP.Text = string.Empty;
                    ddl_ambito.ClearSelection();
                    RPCodDiagC.Text = string.Empty;
                    RPCodDiagP.Text = string.Empty;
                    RPCodDiaGR.Text = string.Empty;
                    RPCodProced.Text = string.Empty;
                    RPDDiagC.Text = string.Empty;
                    RPDDiagR.Text = string.Empty;
                    RPDDiangP.Text = string.Empty;
                    RPFinalidad.ClearSelection();
                    ddl_personal.ClearSelection();
                    lbl_resultado.Text = string.Empty;
                    txt_tipodoc.Text = leer["TipoDocumento"].ToString();
                    txt_documento.Text = leer["Documento"].ToString();
                    string NombreCompleto = (leer["Nombre1"].ToString()) + " " + (leer["Nombre2"].ToString()) + " " + (leer["Apellido1"].ToString()) + " " + (leer["Apellido2"].ToString());
                    txt_nombre.Text = NombreCompleto;
                    txt_sexo.Text = leer["Sexo"].ToString();
                    txt_zona.Text = leer["Zona"].ToString();
                    txt_tipousuario.Text = leer["TipoUsuario"].ToString();
                    FacturaTipoAfiliado.Text = leer["TipoAfiliado"].ToString();
                    txt_estrato.Text = leer["Estrato"].ToString();
                    DateTime fechaNcimiento = Convert.ToDateTime(leer["FechaNacimiento"].ToString());
                    MP_Direccion.Text = leer["Direccion"].ToString();
                    MP_Telefono.Text = leer["Telefono"].ToString();
                    txt_fechanac.Text = fechaNcimiento.ToShortDateString();
                    conexion.Close();

                    //SE BUSCA LA INFORMACION DEL ESTRATO DEL AFILIADO
                    string sql3 = "SELECT * FROM Estratos WHERE Descripcion='" + this.txt_estrato.Text + "'";
                    SqlCommand comando3 = new SqlCommand(sql3, conexion);
                    conexion.Open();
                    SqlDataReader leer3 = comando3.ExecuteReader();

                    if (leer3.Read() == true)
                    {
                        FacturaValorPorcEstrato.Text = leer3["Porcentaje"].ToString();
                        FacturaValorCuotaModeradora.Text = leer3["CuotaMderadora"].ToString();
                    }
                    conexion.Close();
                    Edad.Text = DiferenciaFechas(DateTime.Now, Convert.ToDateTime(txt_fechanac.Text));

                    //SE BUSCA EL CONTRATO Y LA ENTIDAD ASIGNADA DEL PACIENTE
                    string sql2 = "SELECT COUNT (*) FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";


                    //***************************
                    //string sql2 = "SELECT COUNT(*) FROM PacientesEntidadContrato WHERE Documento='" + this.txt_buscar.Text + "'";
                    SqlCommand comando2 = new SqlCommand(sql2, conexion);
                    conexion.Open();
                    int count = Convert.ToInt32(comando2.ExecuteScalar());
                    conexion.Close();

                    if (count > 1)
                    {
                        fillgrilla();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupContratos();", true);
                        this.lbl_contratos.Text = "Seleccione Contrato";
                    }

                    if (count == 1)
                    {
                        string sql5 = "SELECT Entidad.Codigo AS CodigoEntidad, Entidad.NombreEntidad AS NombreEntidad, Contratos.Codigo AS ContratoNumero, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                        SqlCommand comando5 = new SqlCommand(sql5, conexion);
                        conexion.Open();
                        SqlDataReader leer2 = comando5.ExecuteReader();
                        if (leer2.Read() == true)
                        {
                            FacturaCodigoEntidad.Text = leer2["CodigoEntidad"].ToString();
                            txt_entidad.Text = leer2["NombreEntidad"].ToString();
                            FacturaCodigoContrato.Text = leer2["ContratoNumero"].ToString();
                            txt_contrato.Text = leer2["ContratoDescripcion"].ToString();
                            FacturaTipoContrato.Text = leer2["ContratoTipo"].ToString();

                        }
                        conexion.Close();

                    }
                    if (count == 0)
                    {
                        lbl_resultado.Text = "El Usuario no tiene empresa y contratos asignados o el contrato está anulado porque ya termino";
                        return;
                    }

                    string sql6 = "SELECT CodigoCliente, SUM(ValorSaldo) AS Total FROM CuentasporCobrar WHERE CodigoCliente='" + this.txt_buscar.Text + "' AND ValorSaldo>0 GROUP BY CodigoCliente";
                    SqlCommand comando6 = new SqlCommand(sql6, conexion);
                    conexion.Open();
                    SqlDataReader leer6 = comando6.ExecuteReader();
                    if (leer6.Read() == true)
                    {
                        FacturaCodigoCliente.Text = leer6["CodigoCliente"].ToString();
                        ValorSaldo = Convert.ToDouble(leer6["Total"].ToString());
                        string SumaValor = ValorSaldo.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupDeudas();", true);
                        this.lbl_mensajedeuda.Text = "El usuario tiene una deuda pendiente de pago con la IPS de $ " + SumaValor;
                    }
                    conexion.Close();
                    txt_RNTipodocumento.Text = txt_tipodoc.Text;
                    txt_RNDocumento.Text = txt_documento.Text;
                    txt_RNNombre.Text = txt_nombre.Text;
                    txt_RNEntidad.Text = txt_entidad.Text;
                    txt_RNContrato.Text = txt_contrato.Text;

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupNoexiste();", true);
                    this.lbl_mensajeUsuario.Text = "El usuario no existe. ¿Desea Crearlo?";

                    txt_documento.Text = string.Empty;
                    txt_nombre.Text = string.Empty;
                    txt_sexo.Text = string.Empty;
                    txt_zona.Text = string.Empty;
                    txt_tipousuario.Text = string.Empty;
                    txt_estrato.Text = string.Empty;
                    txt_fechanac.Text = string.Empty;
                    Edad.Text = string.Empty;
                    txt_entidad.Text = string.Empty;
                    txt_contrato.Text = string.Empty;
                    FacturaCodigoEntidad.Text = string.Empty;
                    FacturaCodigoContrato.Text = string.Empty;
                    lbl_resultado.Text = string.Empty;

                }
            }
            conexion.Close();

            //Sigo con la busqueda

            
        }

        [WebMethod]
        public static string[] BuscarPaciente(string prefix)
        {
            string sql = "SELECT (Nombre1+' '+Nombre2+' '+Apellido1+' '+Apellido2) AS NombreCompleto FROM Pacientes WHERE Nombre1 like '%'+@SearchText+'%'";

            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}", sdr["NombreCompleto"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

        protected void btn_buscarPaciente_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Documento de Identidad";
                return;
            }
            string sqlEliminar = "DELETE FROM FactAux WHERE Documento='" + this.txt_buscar.Text + "'";
            if (Datos.insertar(sqlEliminar))
            {

            }
            else
            {
            }

            string RIPSC = "DELETE FROM RipsConsultaAuxiliar WHERE Documento='" + this.txt_buscar.Text + "'";
            if (Datos.insertar(RIPSC))
            {

            }
            else
            {
            }
            string RIPSP = "DELETE FROM RipsProcedAuxiliar WHERE Documento='" + this.txt_buscar.Text + "'";
            if (Datos.insertar(RIPSP))
            {

            }
            else
            {
            }
            fillgrillaCuerpoFactura();
            ddl_ips.ClearSelection();
            txt_procedimiento.Text = string.Empty;
            txt_codProcedimiento.Text = string.Empty;
            ddl_profesional.ClearSelection();
            ddl_pyp.ClearSelection();

            string query = "SELECT Admisiones.NumeroAdmision, Admisiones.TipoAdmision, HistoricoPte.Hdocumento, Admisiones.DocumentoPaciente, Admisiones.Estado, HistoricoPte.Hentidad, HistoricoPte.Hcontrato, HistoricoPte.Htipocontrato, HistoricoPte.Hcodproced, HistoricoPte.Hfechaservicio, HistoricoPte.Hcantidad, HistoricoPte.Hcodprof, HistoricoPte.Hfinalidad, HistoricoPte.Hcausaexterna, HistoricoPte.Hdxppal, HistoricoPte.htdxppal, HistoricoPte.Hdr1, HistoricoPte.Hdr2, HistoricoPte.Hdr3, HistoricoPte.Hpatiende, HistoricoPte.CantidadOrden, HistoricoPte.CantidadDespachado, HistoricoPte.Hufuncional, HistoricoPte.Hcentrocostos, HistoricoPte.HconceptoRips FROM Admisiones INNER JOIN HistoricoPte ON (Admisiones.TipoAdmision = HistoricoPte.Htipoadmision) AND (Admisiones.NumeroAdmision = HistoricoPte.HnumAdmision) WHERE (((HistoricoPte.Hdocumento)= '" + txt_buscar.Text + "') AND ((Admisiones.Estado)=0 OR (Admisiones.Estado)=1))";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comandoA = new SqlCommand(query, conexion);
            conexion.Open();

            SqlDataReader leerA = comandoA.ExecuteReader();

            if (leerA.Read() == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupLiquidarAdmision();", true);
                this.lbl_liquidar.Text = "El paciente tiene una admisión por liquidar. ¿Desea hacerlo ahora?";
            }
            conexion.Close();

            //Sigo con la busqueda

            string sql = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_buscar.Text + "'";
            //SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                Modal_CodProced.Text = string.Empty;
                Modal_CodD1.Text = string.Empty;
                Modal_CodD2.Text = string.Empty;
                Modal_CodD3.Text = string.Empty;
                Modal_CodDiagP.Text = string.Empty;
                Modal_ddlCausaEterna.ClearSelection();
                Modal_ddlTipoDX.ClearSelection();
                Modal_DescD1.Text = string.Empty;
                Modal_DescD2.Text = string.Empty;
                Modal_DescD3.Text = string.Empty;
                Modal_DescDiagP.Text = string.Empty;
                ddl_ambito.ClearSelection();
                RPCodDiagC.Text = string.Empty;
                RPCodDiagP.Text = string.Empty;
                RPCodDiaGR.Text = string.Empty;
                RPCodProced.Text = string.Empty;
                RPDDiagC.Text = string.Empty;
                RPDDiagR.Text = string.Empty;
                RPDDiangP.Text = string.Empty;
                RPFinalidad.ClearSelection();
                ddl_personal.ClearSelection();
                lbl_resultado.Text = string.Empty;
                txt_tipodoc.Text = leer["TipoDocumento"].ToString();
                txt_documento.Text = leer["Documento"].ToString();
                string NombreCompleto = (leer["Nombre1"].ToString()) + " " + (leer["Nombre2"].ToString()) + " " + (leer["Apellido1"].ToString()) + " " + (leer["Apellido2"].ToString());
                txt_nombre.Text = NombreCompleto;
                txt_sexo.Text = leer["Sexo"].ToString();
                txt_zona.Text = leer["Zona"].ToString();
                txt_tipousuario.Text = leer["TipoUsuario"].ToString();
                FacturaTipoAfiliado.Text = leer["TipoAfiliado"].ToString();
                txt_estrato.Text = leer["Estrato"].ToString();
                DateTime fechaNcimiento = Convert.ToDateTime(leer["FechaNacimiento"].ToString());
                MP_Direccion.Text = leer["Direccion"].ToString();
                MP_Telefono.Text = leer["Telefono"].ToString();
                txt_fechanac.Text = fechaNcimiento.ToShortDateString();
                conexion.Close();

                //SE BUSCA LA INFORMACION DEL ESTRATO DEL AFILIADO
                string sql3 = "SELECT * FROM Estratos WHERE Descripcion='" + this.txt_estrato.Text + "'";
                SqlCommand comando3 = new SqlCommand(sql3, conexion);
                conexion.Open();
                SqlDataReader leer3 = comando3.ExecuteReader();

                if (leer3.Read() == true)
                {
                    FacturaValorPorcEstrato.Text = leer3["Porcentaje"].ToString();
                    FacturaValorCuotaModeradora.Text = leer3["CuotaMderadora"].ToString();
                }
                conexion.Close();
                Edad.Text = DiferenciaFechas(DateTime.Now, Convert.ToDateTime(txt_fechanac.Text));

                //SE BUSCA EL CONTRATO Y LA ENTIDAD ASIGNADA DEL PACIENTE
                string sql2 = "SELECT COUNT (*) FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Pacientes.Documento= '" + this.txt_buscar.Text + "'";


                //***************************
                //string sql2 = "SELECT COUNT(*) FROM PacientesEntidadContrato WHERE Documento='" + this.txt_buscar.Text + "'";
                SqlCommand comando2 = new SqlCommand(sql2, conexion);
                conexion.Open();
                int count = Convert.ToInt32(comando2.ExecuteScalar());
                conexion.Close();

                if (count > 1)
                {
                    fillgrilla();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupContratos();", true);
                    this.lbl_contratos.Text = "Seleccione Contrato";
                }

                if (count == 1)
                {
                    string sql5 = "SELECT Entidad.Codigo AS CodigoEntidad, Entidad.NombreEntidad AS NombreEntidad, Contratos.Codigo AS ContratoNumero, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                    SqlCommand comando5 = new SqlCommand(sql5, conexion);
                    conexion.Open();
                    SqlDataReader leer2 = comando5.ExecuteReader();
                    if (leer2.Read() == true)
                    {
                        FacturaCodigoEntidad.Text = leer2["CodigoEntidad"].ToString();
                        txt_entidad.Text = leer2["NombreEntidad"].ToString();
                        FacturaCodigoContrato.Text = leer2["ContratoNumero"].ToString();
                        txt_contrato.Text = leer2["ContratoDescripcion"].ToString();
                        FacturaTipoContrato.Text = leer2["ContratoTipo"].ToString();

                    }
                    conexion.Close();

                }
                if (count == 0)
                {
                    lbl_resultado.Text = "El Usuario no tiene empresa y contratos asignados o el contrato está anulado porque ya termino";
                    return;
                }

                string sql6 = "SELECT CodigoCliente, SUM(ValorSaldo) AS Total FROM CuentasporCobrar WHERE CodigoCliente='" + this.txt_buscar.Text + "' AND ValorSaldo>0 GROUP BY CodigoCliente";
                SqlCommand comando6 = new SqlCommand(sql6, conexion);
                conexion.Open();
                SqlDataReader leer6 = comando6.ExecuteReader();
                if (leer6.Read() == true)
                {
                    FacturaCodigoCliente.Text = leer6["CodigoCliente"].ToString();
                    ValorSaldo = Convert.ToDouble(leer6["Total"].ToString());
                    string SumaValor = ValorSaldo.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"));
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupDeudas();", true);
                    this.lbl_mensajedeuda.Text = "El usuario tiene una deuda pendiente de pago con la IPS de $ " + SumaValor;
                }
                conexion.Close();
                txt_RNTipodocumento.Text = txt_tipodoc.Text;
                txt_RNDocumento.Text = txt_documento.Text;
                txt_RNNombre.Text = txt_nombre.Text;
                txt_RNEntidad.Text = txt_entidad.Text;
                txt_RNContrato.Text = txt_contrato.Text;

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupNoexiste();", true);
                this.lbl_mensajeUsuario.Text = "El usuario no existe. ¿Desea Crearlo?";

                txt_documento.Text = string.Empty;
                txt_nombre.Text = string.Empty;
                txt_sexo.Text = string.Empty;
                txt_zona.Text = string.Empty;
                txt_tipousuario.Text = string.Empty;
                txt_estrato.Text = string.Empty;
                txt_fechanac.Text = string.Empty;
                Edad.Text = string.Empty;
                txt_entidad.Text = string.Empty;
                txt_contrato.Text = string.Empty;
                FacturaCodigoEntidad.Text = string.Empty;
                FacturaCodigoContrato.Text = string.Empty;
                lbl_resultado.Text = string.Empty;

            }
        }

        protected void Imprimesi_Click(object sender, EventArgs e)
        {
            string sql = "SELECT E.NombreEntidad, E.NIT, c.Descripcion, FC.NumFac, FC.FechaFactura, p.TipoDocumento, FC.ValorEnLetras, FC.TipoFactura, p.Documento, p.Nombre1, p.Nombre2, p.Apellido1, p.Apellido2, fd.codproced, fd.desproced, fc.VrTotalProced, fc.VrTotalCopago, fc.VrTotalEntidad, fc.Prefijo, Proced.DescProcedimiento, fd.cantidad, fd.vrproced, fd.vrcopago, fd.vrentidad, u.Nombre, p.Edad, p.Estrato, est.Descripcion, FC.ipsNombre FROM Entidad AS e, Contratos AS c, FacturaCab AS fc, FacturaDet AS fd, Pacientes AS p, Procedimientos AS proced, Usuarios AS u, Estratos AS Est WHERE fc.NumFac = fd.numfac And fc.TipoDoc = fd.TipoDoc And p.Documento = fc.PDocumento And e.Codigo = fc.CodEntidad And e.Codigo = c.Entidad And c.Entidad = fc.CodEntidad And proced.CodProcedimiento = fd.codproced And c.Codigo = fc.CodContrato And p.Estrato = est.Descripcion And fc.Usuario = u.CodUsuario And fc.NumFac = '" + ConsecutivoF.Text + "' And fc.TipoDoc = '" + this.FacturaTipoContrato.Text + "' And fc.Estado = '0'";
            ImprimirFactura(sql);
        }

        protected void Imprimeno_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaFactura.aspx");
        }

        protected void Cerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaFactura.aspx");
        }



    }
}