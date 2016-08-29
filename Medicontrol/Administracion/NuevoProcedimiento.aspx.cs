using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Administracion
{
    public partial class Formulario_web19 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        string html = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

       

        protected void ddl_rips_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                this.ddl_finalidad.Items.Insert(0, new ListItem("Seleccione una Finalidad"));
            }
            if (CodigoRips > 6)
            {
                ddl_finalidad.Items.Clear();
                this.ddl_finalidad.Items.Insert(0, new ListItem("Seleccione una Finalidad"));
                this.ddl_finalidad.Items.Insert(1, new ListItem("No Aplica"));
            }
        }

        protected void ddl_unidadfuncional_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_UnidadFuncional.Text = ddl_unidadfuncional.SelectedItem.Text;
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

        protected void btn_nuevatarifa_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultadoTarifas.Text = "Digite un Codigo de Procedimiento";
                return;
            }
            if (ddl_planes.SelectedItem.ToString() == "Seleccione un Plan" && txt_nombreplan.Text==string.Empty)
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
            string text2 = txt_puntos.Text;
            int num2;
            if (int.TryParse(text2, out num2))
            {
                txt_puntos.Text = num2.ToString();
            }
            else
            {
                lbl_resultadoTarifas.Text = "Digite una cantidad correcta";
                return;
            }
            if (txt_valor.Text == string.Empty)
            {
                lbl_resultadoTarifas.Text = "El campo Valor no puede estar vacío";
                return;
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

            string sql = "INSERT INTO Tarifas(CodPlan, DescPlan, CodProcedimiento, Puntos, Valor, ValorAnt) VALUES('" +this.ddl_planes.SelectedValue+ "', '"+this.txt_nombreplan.Text+"', '"+this.txt_codigo.Text+"', '"+this.txt_puntos.Text+"', '"+this.txt_valor.Text+"', '0')";
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
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    txt_nombreplan.Text = HttpUtility.HtmlDecode(gridTarifas.SelectedRow.Cells[2].Text);
                    txt_puntos.Text = HttpUtility.HtmlDecode(gridTarifas.SelectedRow.Cells[3].Text);
                    txt_valor.Text = HttpUtility.HtmlDecode(gridTarifas.SelectedRow.Cells[4].Text);
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void btn_acttarifa_Click(object sender, EventArgs e)
        {
            if (gridTarifas.SelectedRow==null)
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
            if (ddl_planes.SelectedItem.ToString() == "Seleccione un Plan" && txt_nombreplan.Text==string.Empty)
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
            string sql = "UPDATE Tarifas SET CodPlan='" + this.ddl_planes.SelectedValue + "', DescPlan='" + this.txt_nombreplan.Text + "', Puntos='" + this.txt_puntos.Text + "', Valor='" + this.txt_valor.Text + "' WHERE CodProcedimiento='" + this.txt_codigo.Text + "' AND Id='" + this.gridTarifas.SelectedRow.Cells[0].Text + "'";
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
                    gridTarifas.Visible = true;
                    fillgrilla();
                }
            }
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
                    txt_UnidadFuncional.Text = HttpUtility.HtmlDecode(GridViewCostos.SelectedRow.Cells[1].Text);
                    txt_CentroCostos.Text = HttpUtility.HtmlDecode(GridViewCostos.SelectedRow.Cells[3].Text);

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

            string sql = "INSERT INTO ProcedCentroCostos(CodProcedimiento, CodCentroCostos) VALUES('" + this.txt_codigo.Text + "', '"+this.ddl_centrocostos.SelectedValue+"')";
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

        private void fillgrillaCostos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT UnidadFuncional.CodUnidadF, UnidadFuncional.DescUnidadF, ProcedCentroCostos.CodCentroCostos, CentroCostos.DescCentroCosto FROM UnidadFuncional INNER JOIN CentroCostos ON UnidadFuncional.CodUnidadF = CentroCostos.CodUnidadF INNER JOIN ProcedCentroCostos ON CentroCostos.CodCentroCostos = ProcedCentroCostos.CodCentroCostos WHERE ProcedCentroCostos.CodProcedimiento='"+this.txt_codigo.Text+"'", cn);
                da.Fill(dt);
            }
            GridViewCostos.DataSource = dt;

            GridViewCostos.DataBind();

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

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultado.Text = "No ha digitado el código del Procedimiento";
                return;
            }
            if (VerificarProcedimiento(txt_codigo.Text))
            {
                lbl_resultado.Text = "Ya existe un Procedimiento con ese Código";
                return;
            }
            if (ddl_tarifarios.SelectedItem.ToString() == "Seleccione tarifario")
            {
                lbl_resultado.Text = "No ha seleccionado un manual Tarifario";
                return;
            }
            if (txt_descripcion.Text == string.Empty)
            {
                lbl_resultado.Text = "No ha asignado una descripcion para el Procedimiento";
                return;
            }
            if(ddl_grupoQx.SelectedItem.ToString()=="Seleccione un Grupo")
            {
                lbl_resultado.Text="Debe seleccionar un GrupoQX";
                return;
            }
            if (ddl_rips.SelectedItem.ToString() == "Seleccione un concepto Rips")
            {
                lbl_resultado.Text = "Seleccione un concepto Rips";
                return;
            }
            if (ddl_finalidad.SelectedItem.ToString() == "Seleccione una Finalidad")
            {
                lbl_resultado.Text = "No ha seleccionado la finalidad del Procedimiento";
                return;
            }
            if (ddl_grupoQx.SelectedItem.ToString() == "Seleccione un Grupo")
            {
                lbl_resultado.Text = "No ha seleccionado el grupo QX del Procedimiento";
                return;
            }
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
            string sql = "INSERT INTO Procedimientos(MCodManual, CodProcedimiento, DescProcedimiento, GrupoQX, CodRips, TipoServicio, Finalidad, CodigoCUPS, Estado) VALUES('" + this.ddl_tarifarios.SelectedValue + "', '" + this.txt_codigo.Text + "', '"+this.txt_descripcion.Text+"', '"+this.ddl_grupoQx.SelectedValue+"', '"+ddl_rips.SelectedValue+"', '"+this.ddl_tiposervicio.SelectedValue+"', '"+this.ddl_finalidad.SelectedValue+"', '"+this.txt_codigocups.Text+"', '"+this.ddl_estado.SelectedValue+"')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
            }
            else
            {
                string sql2 = "DELETE FROM Tarifas WHERE CodProcedimiento='"+this.txt_codigo.Text+"'";
                if (Datos.insertar(sql2))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    string sql3 = "DELETE FROM ProcedCentroCostos WHERE CodProcedimiento='"+this.txt_codigo.Text+"'";
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
                            string sql4 = "INSERT INTO Tarifas(CodPlan, DescPlan, CodProcedimiento, Puntos, Valor, ValorAnt) VALUES('" +cplan+ "', '" +dplan+ "', '" + this.txt_codigo.Text + "', '"+cpuntos+"', '" +valor+ "', 0)";
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
                            string cprod = row.Cells[0].Text;
                            string ccentro = row.Cells[2].Text;
                            string sql5 = "INSERT INTO ProcedCentroCostos(CodProcedimiento, CodCentroCostos) VALUES('"+this.txt_codigo.Text+"', '"+ccentro+"')";
                            if (Datos.insertar(sql5))
                            {
                                lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                            }
                            //else
                            //{
                            //}
                        }

                        Response.Redirect("NuevoProcedimiento.aspx");
                    }
                }
            }

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

        protected void ddl_planes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_nombreplan.Text = ddl_planes.SelectedItem.Text;
        }

        protected void ddl_centrocostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_CentroCostos.Text = ddl_centrocostos.SelectedItem.Text;
        }
       
    }
}