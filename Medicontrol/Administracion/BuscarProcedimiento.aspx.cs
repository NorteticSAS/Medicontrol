using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Administracion
{
    public partial class Formulario_web110 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_resultado.Text = string.Empty;
            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM Tarifarios ORDER BY DescTarifarios", "Tarifarios");
                this.ddl_tarifarios.DataSource = Datos.ds.Tables["Tarifarios"];
                this.ddl_tarifarios.DataTextField = "DescTarifarios";
                this.ddl_tarifarios.DataValueField = "CodTarifarios";
                this.ddl_tarifarios.DataBind();
                this.ddl_tarifarios.Items.Insert(0, new ListItem("Seleccione tarifario"));

                Datos.consultar("SELECT * FROM UnidadFuncional ORDER BY DescUnidadF", "UnidadFuncional");
                this.ddl_unidadfuncional.DataSource = Datos.ds.Tables["UnidadFuncional"];
                this.ddl_unidadfuncional.DataTextField = "DescUnidadF";
                this.ddl_unidadfuncional.DataValueField = "CodUnidadF";
                this.ddl_unidadfuncional.DataBind();
                this.ddl_unidadfuncional.Items.Insert(0, new ListItem("Seleccione Unidad Funcional"));

                Datos.consultar("SELECT * FROM Planes ORDER BY Descripcion", "Planes");
                this.ddl_planes.DataSource = Datos.ds.Tables["Planes"];
                this.ddl_planes.DataTextField = "Descripcion";
                this.ddl_planes.DataValueField = "CodPlan";
                this.ddl_planes.DataBind();
                this.ddl_planes.Items.Insert(0, new ListItem("Seleccione un Plan"));

                Datos.consultar("SELECT * FROM ConceptosRips ORDER BY DescConceptoRips", "ConceptosRips");
                this.ddl_rips.DataSource = Datos.ds.Tables["ConceptosRips"];
                this.ddl_rips.DataTextField = "DescConceptoRips";
                this.ddl_rips.DataValueField = "CodConceptoRips";
                this.ddl_rips.DataBind();
                this.ddl_rips.Items.Insert(0, new ListItem("Seleccione un concepto Rips"));
            }
        }
        string CodigoTarifario, CodRips, CodGrupoQX, CodcUPS, CodTipoSer, CodFinalidad, CodEstado;

        [WebMethod]
        public static string[] BuscarProcedimiento(string prefix)
        {
            string sql = "SELECT DescProcedimiento FROM Procedimientos WHERE DescProcedimiento like '%'+@SearchText+'%'";

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

        protected void btn_buscarUsuario_Click(object sender, EventArgs e)
        {
            string tarifa, costo;
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor digite un Código";
                return;
            }

            string busqueda = "SELECT * FROM Procedimientos WHERE CodProcedimiento='" + this.txt_buscar.Text + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {
                txt_codigo.Text = leer["CodProcedimiento"].ToString();
                txt_descripcion.Text = leer["DescProcedimiento"].ToString();
                
                string grupoqx = leer["GrupoQX"].ToString();
                if (grupoqx.Length > 0)
                {
                    ddl_grupoQx.ClearSelection();
                    ddl_grupoQx.Items.FindByValue(leer["GrupoQX"].ToString()).Selected = true; 
                }
                
                txt_codigocups.Text = leer["CodigoCUPS"].ToString();
                txt_tiposervicios.Text = leer["TipoServicio"].ToString();
                txt_finalidad.Text = leer["Finalidad"].ToString();
                txt_estados.Text = leer["Estado"].ToString();
                codtarifario.Text = leer["MCodManual"].ToString();
                string tarifar = leer["MCodManual"].ToString();
                if (tarifar.Length > 0)
                {
                    ddl_tarifarios.ClearSelection();
                    ddl_tarifarios.Items.FindByValue(leer["MCodManual"].ToString()).Selected = true;
                }
                
                int codrips = Convert.ToInt32(leer["CodRips"].ToString());
                if (codrips > 0)
                {
                    ddl_rips.ClearSelection();
                    ddl_rips.Items.FindByValue(leer["CodRips"].ToString()).Selected = true;
                }
                else
                {
                    
                }
                string TipoServicio = leer["TipoServicio"].ToString();
                if (TipoServicio.Length > 0)
                {
                    ddl_tiposervicio.ClearSelection();
                    ddl_tiposervicio.Items.FindByValue(leer["TipoServicio"].ToString()).Selected = true;
                }
                string state = leer["Estado"].ToString();
                if (state.Length > 0)
                {
                    ddl_estado.ClearSelection();
                    ddl_estado.Items.FindByValue(leer["Estado"].ToString()).Selected = true;
                }
                
                codigorips.Text = leer["CodRips"].ToString();
                btn_Actualizar.Enabled = true;
                btn_Eliminar.Enabled = true;
            }
            else
            {
                lbl_resultado.Text = "No existe ningun procedimiento asociado a este Código";
                return;
            }
            conexion2.Close();

            //string sql = "SELECT * FROM Tarifarios WHERE CodTarifarios='" + this.codtarifario.Text + "'";
            //SqlCommand comando2 = new SqlCommand(sql, conexion2);
            //conexion2.Open();
            //SqlDataReader leer2 = comando2.ExecuteReader();

            //if (leer2.Read() == true)
            //{
            //    txt_tarifarios.Text = leer2["DescTarifarios"].ToString();
            //}
            conexion2.Close();
            string sql2 = "SELECT * FROM ConceptosRips WHERE CodConceptoRips='" + this.codigorips.Text + "'";
            SqlCommand comando3 = new SqlCommand(sql2, conexion2);
            conexion2.Open();
            SqlDataReader leer3 = comando3.ExecuteReader();

            if (leer3.Read() == true)
            {
                txt_rips.Text = leer3["DescConceptoRips"].ToString();
            }
            conexion2.Close();

            string sql3 = "SELECT * FROM Tarifas WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
            SqlCommand comando4 = new SqlCommand(sql3, conexion2);
            conexion2.Open();
            SqlDataReader leer4 = comando4.ExecuteReader();

            if (leer4.Read() == true)
            {
                tarifa = leer4["Id"].ToString();
            }
            else
            {
                tarifa = string.Empty;
            }
            conexion2.Close();
            string sql4 = "SELECT * FROM ProcedCentroCostos WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
            SqlCommand comando5 = new SqlCommand(sql4, conexion2);
            conexion2.Open();
            SqlDataReader leer5 = comando5.ExecuteReader();

            if (leer5.Read() == true)
            {
                costo = leer5["Id"].ToString();
            }
            else
            {
                costo = string.Empty;
            }

            if (tarifa == string.Empty && costo.Length > 0)
            {
                lbl_resultado.Text = "El Procedimiento no tiene Tarifas Asociadas";
            }
            if (costo == string.Empty && tarifa.Length > 0)
            {
                lbl_resultado.Text = "El Procedimiento no tiene Centro de Costos Asociado";
            }
            if (tarifa == string.Empty && costo == string.Empty)
            {
                lbl_resultado.Text = "El Procedimiento no tiene Tarifas ni Centro de Costos Asociado";
            }
            gridTarifas.Visible = true;
            fillgrilla();

            GridViewCostos.Visible = true;
            fillgrillaCostos();
        }

        private void fillgrilla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodPlan, DescPlan, Puntos, Valor FROM Tarifas WHERE CodProcedimiento='" + this.txt_codigo.Text + "'", cn);
                da.Fill(dt);
            }
            gridTarifas.DataSource = dt;

            gridTarifas.DataBind();

        }

        private void fillgrillaCostos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT UnidadFuncional.CodUnidadF, UnidadFuncional.DescUnidadF, ProcedCentroCostos.CodCentroCostos, CentroCostos.DescCentroCosto FROM UnidadFuncional INNER JOIN CentroCostos ON UnidadFuncional.CodUnidadF = CentroCostos.CodUnidadF INNER JOIN ProcedCentroCostos ON CentroCostos.CodCentroCostos = ProcedCentroCostos.CodCentroCostos WHERE ProcedCentroCostos.CodProcedimiento='" + this.txt_codigo.Text + "'", cn);
                da.Fill(dt);
            }
            GridViewCostos.DataSource = dt;

            GridViewCostos.DataBind();

        }

        protected void btn_Actualizar_Click(object sender, EventArgs e)
        {
            ddl_estado.Enabled = true;
            ddl_tiposervicio.Enabled = true;
            ddl_finalidad.Enabled = true;
            ddl_tarifarios.Enabled = true;
            ddl_grupoQx.Enabled = true;
            ddl_rips.Enabled = true;
            txt_codigo.ReadOnly = false;
            txt_descripcion.ReadOnly = false;
            ddl_tarifarios.Visible = true;
            ddl_grupoQx.Visible = true;
            ddl_grupoQx.Enabled = true;
            txt_codigocups.ReadOnly = false;
            ddl_finalidad.Visible = true;
            ddl_finalidad.Enabled = true;
            ddl_rips.Visible = true;
            ddl_rips.Enabled = true;
            ddl_tiposervicio.Visible = true;
            ddl_estado.Visible = true;
            ddl_planes.Enabled = true;
            txt_puntos.ReadOnly = false;
            txt_valor.ReadOnly = false;
            btn_nuevatarifa.Visible = true;


        }

        protected void ddl_rips_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_rips.Text = ddl_rips.SelectedItem.ToString();
            int CodigoRips = 0;
            string busqueda = "SELECT * FROM ConceptosRips WHERE DescConceptoRips ='" + this.ddl_rips.SelectedItem + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                CodigoRips = Convert.ToInt32(leer["CodConceptoRips"]);
            }
            conexion2.Close();
            if (CodigoRips < 3)
            {
                ddl_finalidad.Items.Clear();
                Datos.consultar("SELECT * FROM FinalidadConsulta ORDER BY DescFinalidadC", "FinalidadConsulta");
                this.ddl_finalidad.DataSource = Datos.ds.Tables["FinalidadConsulta"];
                this.ddl_finalidad.DataTextField = "DescFinalidadC";
                this.ddl_finalidad.DataValueField = "CodFinalidadC";
                this.ddl_finalidad.DataBind();
                this.ddl_finalidad.Items.Insert(0, new ListItem("Seleccione una Finalidad"));
            }
            if (CodigoRips >= 3 && CodigoRips <= 6)
            {
                ddl_finalidad.Items.Clear();
                Datos.consultar("SELECT * FROM FinalidadProcedimiento ORDER BY DescFinalidadP", "FinalidadProcedimiento");
                this.ddl_finalidad.DataSource = Datos.ds.Tables["FinalidadProcedimiento"];
                this.ddl_finalidad.DataTextField = "DescFinalidadP";
                this.ddl_finalidad.DataValueField = "CodFinalidadP";
                this.ddl_finalidad.DataBind();
                this.ddl_finalidad.Items.Insert(0, new ListItem("Seleccione una Finalidad2"));
            }
            if (CodigoRips > 6)
            {
                ddl_finalidad.Items.Clear();
                this.ddl_finalidad.Items.Insert(0, new ListItem("Seleccione una Finalidad"));
                this.ddl_finalidad.Items.Insert(1, new ListItem("No Aplica"));
            }
        }

        protected void ddl_finalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_finalidad.Text = ddl_finalidad.SelectedItem.ToString();
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("BuscarProcedimiento.aspx");
        }

        protected void ddl_tiposervicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_tiposervicios.Text = ddl_tiposervicio.SelectedItem.ToString();
        }

        protected void ddl_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_estados.Text = ddl_estado.SelectedItem.ToString();
        }

        protected void GridViewCostos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridViewCostos, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void GridViewCostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridViewCostos.Rows)
            {

                if (row.RowIndex == GridViewCostos.SelectedIndex)
                {
                    txt_CentroCostos.Text = HttpUtility.HtmlDecode(GridViewCostos.SelectedRow.Cells[3].Text);
                    ddl_unidadfuncional.ClearSelection();
                    ddl_unidadfuncional.Items.FindByText(GridViewCostos.SelectedRow.Cells[1].Text).Selected = true;

                    //txt_UnidadFuncional.Text = HttpUtility.HtmlDecode(GridViewCostos.SelectedRow.Cells[1].Text);
                    //txt_CentroCostos.Text = HttpUtility.HtmlDecode(GridViewCostos.SelectedRow.Cells[3].Text);

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

        protected void gridTarifas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridTarifas, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridTarifas_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridTarifas.Rows)
            {

                if (row.RowIndex == gridTarifas.SelectedIndex)
                {
                    ddl_planes.ClearSelection();
                    ddl_planes.Items.FindByText(gridTarifas.SelectedRow.Cells[2].Text).Selected = true;
                    txt_puntos.Text = HttpUtility.HtmlDecode(gridTarifas.SelectedRow.Cells[3].Text);
                    txt_valor.Text = HttpUtility.HtmlDecode(gridTarifas.SelectedRow.Cells[4].Text);
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

        protected void ddl_planes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txt_nombreplan.Text = ddl_planes.SelectedItem.Text;
        }

        protected void ddl_centrocostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_CentroCostos.Text = ddl_centrocostos.SelectedItem.Text;
        }

        protected void btn_nuevatarifa_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultadoTarifas.Text = "Digite un Codigo de Procedimiento";
                return;
            }
            if (ddl_planes.SelectedItem.ToString() == "Seleccione un Plan")
            {
                lbl_resultadoTarifas.Text = "Debe seleccionar un plan";
                return;
            }
            if (txt_puntos.Text == string.Empty)
            {
                lbl_resultadoTarifas.Text = "El campo Puntos no puede estar vacío";
                return;
            }
            if (!Utilidades.isNumeric(txt_puntos.Text))
            {
                lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                return;
            }
            if (Convert.ToDouble(txt_puntos.Text) < 0)
            {
                lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                return;
            }
            if (txt_valor.Text == string.Empty)
            {
                lbl_resultadoTarifas.Text = "El campo Valor no puede estar vacío";
            }
            if (!Utilidades.isNumeric(txt_valor.Text))
            {
                lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                return;
            }
            if (Convert.ToDouble(txt_valor.Text) < 0)
            {
                lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                return;
            }
            NumberStyles style;
            CultureInfo culture;
            double number;
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            string value = txt_valor.Text;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            if (Double.TryParse(value, style, culture, out number))
            {
                txt_valor.Text = number.ToString();
            }
            else
            {
                lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                return;
            }
            string sql = "INSERT INTO Tarifas(CodPlan, DescPlan, CodProcedimiento, Puntos, Valor, ValorAnt) VALUES('" + this.ddl_planes.SelectedValue + "', '" + this.ddl_planes.SelectedItem + "', '" + this.txt_codigo.Text + "', '" + this.txt_puntos.Text + "', '" + this.txt_valor.Text + "', '0')";
            if (Datos.insertar(sql))
            {
                lbl_resultadoTarifas.Text = "Error al crear la Tarifa, Verifique";
            }
            else
            {
                ddl_planes.ClearSelection();
                txt_puntos.Text = string.Empty;
                txt_valor.Text = string.Empty;
                lbl_resultadoTarifas.Text = string.Empty;
                gridTarifas.Visible = true;
                fillgrilla();
            }
        }

        protected void btn_acttarifa_Click(object sender, EventArgs e)
        {
            if (gridTarifas.SelectedRow == null)
            {
                lbl_resultadoTarifas.Text = "Debe seleccionar una tarifa";
                return;
            }
            else
            {
                if (txt_codigo.Text == string.Empty)
                {
                    lbl_resultadoTarifas.Text = "Digite un Codigo de Procedimiento";
                    return;
                }
                if (ddl_planes.SelectedItem.ToString() == "Seleccione un Plan")
                {
                    lbl_resultadoTarifas.Text = "Debe seleccionar un plan";
                    return;
                }
                if (txt_puntos.Text == string.Empty)
                {
                    lbl_resultadoTarifas.Text = "El campo Puntos no puede estar vacío";
                    return;
                }
                if (!Utilidades.isNumeric(txt_puntos.Text))
                {
                    lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                    return;
                }
                if (Convert.ToDouble(txt_puntos.Text) < 0)
                {
                    lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                    return;
                }
                if (txt_valor.Text == string.Empty)
                {
                    lbl_resultadoTarifas.Text = "El campo Valor no puede estar vacío";
                }
                if (!Utilidades.isNumeric(txt_valor.Text))
                {
                    lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                    return;
                }
                if (Convert.ToDouble(txt_valor.Text) < 0)
                {
                    lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                    return;
                }
                NumberStyles style;
                CultureInfo culture;
                double number;
                style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                string value = txt_valor.Text;
                culture = CultureInfo.CreateSpecificCulture("en-US");
                if (Double.TryParse(value, style, culture, out number))
                {
                    txt_valor.Text = number.ToString();
                }
                else
                {
                    lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                    return;
                }
                string sql = "UPDATE Tarifas SET CodPlan='" + this.ddl_planes.SelectedValue + "', DescPlan='" + this.ddl_planes.SelectedItem + "', Puntos='" + this.txt_puntos.Text + "', Valor='" + this.txt_valor.Text + "' WHERE CodProcedimiento='" + this.txt_codigo.Text + "' AND Id='" + this.gridTarifas.SelectedRow.Cells[0].Text + "'";
                if (Datos.insertar(sql))
                {
                    lbl_resultadoTarifas.Text = "Error al Actualizar la Tarifa, Verifique";
                }
                else
                {
                    ddl_planes.ClearSelection();
                    txt_puntos.Text = string.Empty;
                    txt_valor.Text = string.Empty;
                    gridTarifas.Visible = true;
                    fillgrilla();
                    lbl_resultadoTarifas.Text = string.Empty;
                }
            }
        }

        protected void btn_elimtarifa_Click(object sender, EventArgs e)
        {
            if (gridTarifas.SelectedRow == null)
            {
                lbl_resultadoTarifas.Text = "Debe seleccionar una tarifa";
                return;
            }
            else
            {
                string sql = "DELETE FROM Tarifas WHERE CodProcedimiento='" + this.txt_codigo.Text + "' AND Id='" + this.gridTarifas.SelectedRow.Cells[0].Text + "'";
                if (Datos.insertar(sql))
                {
                    lbl_resultadoTarifas.Text = "Error al Eliminar la Tarifa, Verifique";
                }
                else
                {
                    ddl_planes.ClearSelection();
                    txt_puntos.Text = string.Empty;
                    txt_valor.Text = string.Empty;
                    //lbl_resultadoTarifas.Text = "Tarifa Eliminada";
                    gridTarifas.Visible = true;
                    fillgrilla();
                }
            }
        }

        protected void btn_agregarunidad_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultadocentro.Text = "Digite un Codigo de Procedimiento";
                return;
            }
            if (ddl_unidadfuncional.SelectedItem.ToString() == "Seleccione Unidad Funcional")
            {
                lbl_resultadocentro.Text = "Seleccione una Unidad Funcional";
                return;
            }
            if (ddl_centrocostos.SelectedItem.ToString() == "Seleccione un Centro de Costos")
            {
                lbl_resultadocentro.Text = "Seleccione un Centro de Costos";
                return;
            }

            string sql = "INSERT INTO ProcedCentroCostos(CodProcedimiento, CodCentroCostos) VALUES('" + this.txt_codigo.Text + "', '" + this.ddl_centrocostos.SelectedValue + "')";
            if (Datos.insertar(sql))
            {
                lbl_resultadocentro.Text = "Error al almacenar, Verifique";
            }
            else
            {
                ddl_unidadfuncional.ClearSelection();
                ddl_centrocostos.ClearSelection();
                lbl_resultadocentro.Text = string.Empty;
                GridViewCostos.Visible = true;
                fillgrillaCostos();
            }
        }

        protected void btn_eliminarunidad_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM ProcedCentroCostos WHERE CodProcedimiento='" + this.txt_codigo.Text + "' AND CodCentroCostos='" + this.GridViewCostos.SelectedRow.Cells[2].Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultadocentro.Text = "Error al eliminar, Verifique";
            }
            else
            {
                ddl_unidadfuncional.ClearSelection();
                ddl_centrocostos.ClearSelection();
                lbl_resultadocentro.Text = string.Empty;
                GridViewCostos.Visible = true;
                fillgrillaCostos();
            }
        }

        protected void ddl_unidadfuncional_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CodigoUnidadFuncional = 0;
            string busqueda = "SELECT * FROM UnidadFuncional WHERE DescUnidadF ='" + this.ddl_unidadfuncional.SelectedItem + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                CodigoUnidadFuncional = Convert.ToInt32(leer["CodUnidadF"]);
            }
            conexion2.Close();

            ddl_centrocostos.Items.Clear();
            Datos.consultar("SELECT * FROM CentroCostos WHERE CodUnidadF='" + CodigoUnidadFuncional + "' ORDER BY DescCentroCosto", "CentroCostos");
            this.ddl_centrocostos.DataSource = Datos.ds.Tables["CentroCostos"];
            this.ddl_centrocostos.DataTextField = "DescCentroCosto";
            this.ddl_centrocostos.DataValueField = "CodCentroCostos";
            this.ddl_centrocostos.DataBind();
            this.ddl_centrocostos.Items.Insert(0, new ListItem("Seleccione un Centro de Costos"));
        }

        public bool VerificarProcedimiento(string codigo)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Procedimientos WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("CodProcedimiento", codigo);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion2 = new SqlConnection(ruta);
            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultado.Text = "No ha digitado el código del Procedimiento";
                return;
            }

            if (ddl_tarifarios.SelectedItem.ToString() == "Seleccione Tarifario")
            {
                lbl_resultado.Text = "No ha seleccionado un manual Tarifario";
                return;
            }
            if (txt_descripcion.Text == string.Empty)
            {
                lbl_resultado.Text = "No ha asignado una descripcion para el Procedimiento";
                return;
            }
            //if (ddl.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "Debe seleccionar un GrupoQX";
            //    return;
            //}
            if (ddl_rips.SelectedItem.ToString() == "Seleccione un concepto Rips")
            {
                lbl_resultado.Text = "Seleccione un concepto Rips";
                return;
            }
            if (txt_finalidad.Text==string.Empty)
            {
                lbl_resultado.Text = "No ha seleccionado la finalidad del Procedimiento";
                return;
            }
            //if (ddl_grupoQx.SelectedItem.ToString() == "Seleccione un Grupo")
            //{
            //    lbl_resultado.Text = "No ha seleccionado el grupo QX del Procedimiento";
            //    return;
            //}
            if (ddl_tiposervicio.SelectedItem.ToString() == "Seleccione tipo Servicio")
            {
                lbl_resultado.Text = "No ha seleccionado el tipo de servicio";
                return;
            }
            if (ddl_estado.SelectedItem.ToString() == "Selesccione Estado")
            {
                lbl_resultado.Text = "No ha seleccionado el estado del procedimiento";
                return;
            }


            string sql7 = "SELECT * FROM ConceptosRips WHERE DescConceptoRips='" + this.txt_rips.Text + "'";
            SqlCommand comando = new SqlCommand(sql7, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                CodRips = leer["CodConceptoRips"].ToString();
            }
            conexion2.Close();

            //string sql8 = "SELECT * FROM Tarifarios WHERE DescTarifarios='" + this.txt_tarifarios.Text + "'";
            //SqlCommand comando2 = new SqlCommand(sql8, conexion2);
            //conexion2.Open();
            //SqlDataReader Lector = comando2.ExecuteReader();

            //if (Lector.Read() == true)
            //{
            //    CodigoTarifario = Lector["CodTarifarios"].ToString();
            //}
            //conexion2.Close();

            string sql = "UPDATE Procedimientos SET MCodManual='" + ddl_tarifarios.SelectedValue + "', DescProcedimiento='" + this.txt_descripcion.Text + "', GrupoQX='" + this.ddl_grupoQx.SelectedValue + "', CodRips='" + ddl_rips.SelectedValue + "', TipoServicio='" + this.ddl_tiposervicio.SelectedValue + "', Finalidad='" + this.txt_finalidad.Text + "', CodigoCUPS='" + this.txt_codigocups.Text + "', Estado='" + this.ddl_estado.SelectedValue + "' WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
            }
            else
            {
                string sql2 = "DELETE FROM Tarifas WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
                if (Datos.insertar(sql2))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    string sql3 = "DELETE FROM ProcedCentroCostos WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
                    if (Datos.insertar(sql3))
                    {
                        lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                    }
                    else
                    {
                        foreach (GridViewRow row in gridTarifas.Rows)
                        {
                            string cplan = row.Cells[1].Text;
                            string dplan = row.Cells[2].Text;
                            string cpuntos = row.Cells[3].Text;
                            string valor = row.Cells[4].Text;
                            string sql4 = "INSERT INTO Tarifas(CodPlan, DescPlan, CodProcedimiento, Puntos, Valor, ValorAnt) VALUES('" + cplan + "', '" + dplan + "', '" + this.txt_codigo.Text + "', '" + cpuntos + "', '" + valor + "', 0)";
                            if (Datos.insertar(sql4))
                            {
                                lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                            }
                            //else
                            //{
                            //}
                        }
                        foreach (GridViewRow row in GridViewCostos.Rows)
                        {
                            int cprod = Convert.ToInt32(row.Cells[0].Text);
                            int ccentro = Convert.ToInt32(row.Cells[2].Text);
                            string sql5 = "INSERT INTO ProcedCentroCostos(CodProcedimiento, CodCentroCostos) VALUES('" + this.txt_codigo.Text + "', '" + ccentro + "')";
                            if (Datos.insertar(sql5))
                            {
                                lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                            }
                            //else
                            //{
                            //}
                        }
                        Response.Redirect("BuscarProcedimiento.aspx");
                    }
                }
            }
        }

        protected void btn_Eliminar_Click(object sender, EventArgs e)
        {
            string eliminar1 = "DELETE FROM Procedimientos WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
            if (Datos.insertar(eliminar1))
            {
                lbl_resultadocentro.Text = "Error al eliminar, Verifique";
            }
            else
            {
                string eliminar2 = "DELETE FROM ProcedCentroCostos WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
                if (Datos.insertar(eliminar2))
                {
                    lbl_resultadocentro.Text = "Error al eliminar, Verifique";
                }
                else
                {
                    string eliminar3 = "DELETE FROM Tarifas WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
                    if (Datos.insertar(eliminar3))
                    {
                        lbl_resultadoTarifas.Text = "Error al Eliminar la Tarifa, Verifique";
                    }
                    else
                    {
                        Response.Redirect("BuscarProcedimiento.aspx");
                    }
                }
             }


        }

        protected void btn_porNombre_Click(object sender, EventArgs e)
        {
            string buscarPro = "SELECT * FROM Procedimientos WHERE DescProcedimiento='" + txt_nompro.Text + "'";
            SqlConnection ConexionPorNombre = new SqlConnection(ruta);
            SqlCommand comandoNombre = new SqlCommand(buscarPro, ConexionPorNombre);
            ConexionPorNombre.Open();
            SqlDataReader leerNombre = comandoNombre.ExecuteReader();

            if (leerNombre.Read() == true)
            {
                txt_buscar.Text = leerNombre["CodProcedimiento"].ToString();
            }
            ConexionPorNombre.Close();

            string tarifa, costo;
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor digite un Código";
                return;
            }

            string busqueda = "SELECT * FROM Procedimientos WHERE CodProcedimiento='" + this.txt_buscar.Text + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {
                txt_codigo.Text = leer["CodProcedimiento"].ToString();
                txt_descripcion.Text = leer["DescProcedimiento"].ToString();

                string grupoqx = leer["GrupoQX"].ToString();
                if (grupoqx.Length > 0)
                {
                    ddl_grupoQx.ClearSelection();
                    ddl_grupoQx.Items.FindByValue(leer["GrupoQX"].ToString()).Selected = true;
                }

                txt_codigocups.Text = leer["CodigoCUPS"].ToString();
                txt_tiposervicios.Text = leer["TipoServicio"].ToString();
                txt_finalidad.Text = leer["Finalidad"].ToString();
                txt_estados.Text = leer["Estado"].ToString();
                codtarifario.Text = leer["MCodManual"].ToString();
                string tarifar = leer["MCodManual"].ToString();
                if (tarifar.Length > 0)
                {
                    ddl_tarifarios.ClearSelection();
                    ddl_tarifarios.Items.FindByValue(leer["MCodManual"].ToString()).Selected = true;
                }

                int codrips = Convert.ToInt32(leer["CodRips"].ToString());
                if (codrips > 0)
                {
                    ddl_rips.ClearSelection();
                    ddl_rips.Items.FindByValue(leer["CodRips"].ToString()).Selected = true;
                }
                else
                {

                }
                string TipoServicio = leer["TipoServicio"].ToString();
                if (TipoServicio.Length > 0)
                {
                    ddl_tiposervicio.ClearSelection();
                    ddl_tiposervicio.Items.FindByValue(leer["TipoServicio"].ToString()).Selected = true;
                }
                string state = leer["Estado"].ToString();
                if (state.Length > 0)
                {
                    ddl_estado.ClearSelection();
                    ddl_estado.Items.FindByValue(leer["Estado"].ToString()).Selected = true;
                }

                codigorips.Text = leer["CodRips"].ToString();
                btn_Actualizar.Enabled = true;
                btn_Eliminar.Enabled = true;
            }
            else
            {
                lbl_resultado.Text = "No existe ningun procedimiento asociado a este Código";
                return;
            }
            conexion2.Close();

            //string sql = "SELECT * FROM Tarifarios WHERE CodTarifarios='" + this.codtarifario.Text + "'";
            //SqlCommand comando2 = new SqlCommand(sql, conexion2);
            //conexion2.Open();
            //SqlDataReader leer2 = comando2.ExecuteReader();

            //if (leer2.Read() == true)
            //{
            //    txt_tarifarios.Text = leer2["DescTarifarios"].ToString();
            //}
            conexion2.Close();
            string sql2 = "SELECT * FROM ConceptosRips WHERE CodConceptoRips='" + this.codigorips.Text + "'";
            SqlCommand comando3 = new SqlCommand(sql2, conexion2);
            conexion2.Open();
            SqlDataReader leer3 = comando3.ExecuteReader();

            if (leer3.Read() == true)
            {
                txt_rips.Text = leer3["DescConceptoRips"].ToString();
            }
            conexion2.Close();

            string sql3 = "SELECT * FROM Tarifas WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
            SqlCommand comando4 = new SqlCommand(sql3, conexion2);
            conexion2.Open();
            SqlDataReader leer4 = comando4.ExecuteReader();

            if (leer4.Read() == true)
            {
                tarifa = leer4["Id"].ToString();
            }
            else
            {
                tarifa = string.Empty;
            }
            conexion2.Close();
            string sql4 = "SELECT * FROM ProcedCentroCostos WHERE CodProcedimiento='" + this.txt_codigo.Text + "'";
            SqlCommand comando5 = new SqlCommand(sql4, conexion2);
            conexion2.Open();
            SqlDataReader leer5 = comando5.ExecuteReader();

            if (leer5.Read() == true)
            {
                costo = leer5["Id"].ToString();
            }
            else
            {
                costo = string.Empty;
            }

            if (tarifa == string.Empty && costo.Length > 0)
            {
                lbl_resultado.Text = "El Procedimiento no tiene Tarifas Asociadas";
            }
            if (costo == string.Empty && tarifa.Length > 0)
            {
                lbl_resultado.Text = "El Procedimiento no tiene Centro de Costos Asociado";
            }
            if (tarifa == string.Empty && costo == string.Empty)
            {
                lbl_resultado.Text = "El Procedimiento no tiene Tarifas ni Centro de Costos Asociado";
            }
            gridTarifas.Visible = true;
            fillgrilla();

            GridViewCostos.Visible = true;
            fillgrillaCostos();
        }

    }
}