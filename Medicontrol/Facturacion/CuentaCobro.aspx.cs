using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class Formulario_web111 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM Entidad WHERE Estado='Activo' ORDER BY NombreEntidad", "Entidad");
                this.ddl_entidad.DataSource = Datos.ds.Tables["Entidad"];
                this.ddl_entidad.DataTextField = "NombreEntidad";
                this.ddl_entidad.DataValueField = "Codigo";
                this.ddl_entidad.DataBind();
                ddl_entidad.Items.Insert(0, new ListItem("Seleccione Entidad", "0"));

            }
            DateTime hoy = DateTime.Today;
            DateTime fecha = new DateTime(hoy.Year, hoy.Month, 1);
            txt_fechaini.Text = fecha.ToString("dd/MM/yyyy");
            txt_fechafin.Text = hoy.ToString("dd/MM/yyyy");
        }

        protected void ddl_entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_contrato.Enabled = true;
            Datos.consultar("SELECT * FROM Contratos WHERE Entidad='" + this.ddl_entidad.SelectedValue + "' AND Estado='Activo' AND TipoContrato='1' ORDER BY Descripcion", "Contratos");
            this.ddl_contrato.DataSource = Datos.ds.Tables["Contratos"];
            this.ddl_contrato.DataTextField = "Descripcion";
            this.ddl_contrato.DataValueField = "Codigo";
            this.ddl_contrato.DataBind();
            ddl_contrato.Items.Insert(0, new ListItem("Seleccione Contrato", "0"));
        }

        protected void btn_cargar_Click(object sender, EventArgs e)
        {
            string consulta = string.Empty;
            if (ddl_contrato.SelectedValue.ToString() != "0")
            {
                consulta = "SELECT DISTINCT FacturaCab.NumFac AS NumFactura, FacturaCab.PDocumento AS FacturaDoc FROM FacturaCab INNER JOIN FacturaDet ON FacturaCab.NumFac = FacturaDet.numfac WHERE FacturaCab.CodEntidad = '" + this.ddl_entidad.SelectedValue + "'" +
                           " AND FacturaDet.codcontrato= '" + this.ddl_contrato.SelectedValue + "' AND FacturaCab.Estado = '0' AND FacturaCab.FechaFactura Between '" + Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechaini.Text)) + "' AND '" + Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechafin.Text)) + "' AND facturacab.TipoDoc = 1";
            }
            else
            {
                consulta = "SELECT DISTINCT FacturaCab.NumFac AS NumFactura, FacturaCab.PDocumento AS FacturaDoc FROM FacturaCab INNER JOIN FacturaDet ON FacturaCab.NumFac = FacturaDet.numfac WHERE FacturaCab.CodEntidad = '" + this.ddl_entidad.SelectedValue + "'" +
                           " AND FacturaCab.Estado=0 AND FacturaCab.FechaFactura Between '" + Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechaini.Text)) + "' AND '" + Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechafin.Text)) + "' AND facturacab.TipoDoc = 1";
            }

            fillgrilla(consulta);

        }

        private void fillgrilla(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            gridPacienteFactura.DataSource = dt;

            gridPacienteFactura.DataBind();

        }

        protected void gridPacienteFactura_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridPacienteFactura, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridPacienteFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridPacienteFactura.Rows)
            {
                if (row.RowIndex == gridPacienteFactura.SelectedIndex)
                {
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

        protected void btn_generarSi_Click(object sender, EventArgs e)
        {
            

           
            try
            {
                string query = "SELECT FacturaCab.NumFac, FacturaCab.FechaFactura, FacturaCab.CodEntidad, Entidad.NombreEntidad, FacturaCab.CodContrato, Contratos.Descripcion, FacturaCab.VrTotalCopago, FacturaCab.VrTotalEntidad, FacturaCab.CtaCobro " +
                         "FROM Entidad INNER JOIN (Contratos INNER JOIN FacturaCab ON (Contratos.Codigo = FacturaCab.CodContrato) AND (Contratos.Entidad = FacturaCab.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad " +
                         "WHERE FacturaCab.NumFac = '" + this.gridPacienteFactura.SelectedRow.Cells[0].Text + "'";

                SqlConnection ConexionVerificar = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(query, ConexionVerificar);
                ConexionVerificar.Open();
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read() == true)
                {
                    string update = "UPDATE FacturaCab SET CtaCobro='" + this.NumCuentaCobro.Text + "' WHERE NumFac='" + this.gridPacienteFactura.SelectedRow.Cells[0].Text + "' AND TipoDoc='1'";
                    if (Datos.insertar(update))
                    {
                        lbl_resultado.Text = "Error al generar la cuenta de cobro";
                        return;
                    }
                    else
                    {
                        lbl_resultado.Text = "Cuenta de cobro generada correctamente";
                    }
                }
                ConexionVerificar.Close();
                
            }
            catch(Exception ex)
            {
                lbl_resultado.Text = "Se ha presentado un error al generar cuenta de cobro. El error es el siguiente: " + ex.ToString();
                return;
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string consecutivo = "SELECT * FROM Consecutivos WHERE TipoCont='6'";
            SqlConnection ConexionConsec = new SqlConnection(ruta);
            SqlCommand comando6 = new SqlCommand(consecutivo, ConexionConsec);
            ConexionConsec.Open();
            SqlDataReader leer6 = comando6.ExecuteReader();
            if (leer6.Read() == true)
            {
                int numfac = Convert.ToInt32(leer6["NumActual"].ToString());
                numfac = numfac + 1;
                NumCuentaCobro.Text = numfac.ToString();
            }
            ConexionConsec.Close();
            try
            {
                foreach (GridViewRow Rips in gridPacienteFactura.Rows)
                {
                    string NumFactura = HttpUtility.HtmlDecode(Rips.Cells[0].Text);
                    string query = "SELECT FacturaCab.NumFac, FacturaCab.FechaFactura, FacturaCab.CodEntidad, Entidad.NombreEntidad, FacturaCab.CodContrato, Contratos.Descripcion, FacturaCab.VrTotalCopago, FacturaCab.VrTotalEntidad, FacturaCab.CtaCobro " +
                        "FROM Entidad INNER JOIN (Contratos INNER JOIN FacturaCab ON (Contratos.Codigo = FacturaCab.CodContrato) AND (Contratos.Entidad = FacturaCab.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad " +
                        "WHERE FacturaCab.NumFac = '" + NumFactura + "'";

                    SqlConnection ConexionVerificar = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(query, ConexionVerificar);
                    ConexionVerificar.Open();
                    SqlDataReader leer = comando.ExecuteReader();
                    if (leer.Read() == true)
                    {
                        string update = "UPDATE FacturaCab SET CtaCobro='" + this.NumCuentaCobro.Text + "' WHERE NumFac='" + NumFactura + "' AND TipoDoc='1'";
                        if (Datos.insertar(update))
                        {
                            lbl_resultado.Text = "Error al generar la cuenta de cobro";
                            return;
                        }
                        else
                        {
                            string updateC = "UPDATE Consecutivos SET NumActual='" + this.NumCuentaCobro.Text + "' WHERE TipoCont='6'";
                            if (Datos.insertar(updateC))
                            {
                                lbl_resultado.Text = "Error al generar la cuenta de cobro";
                                return;
                            }
                            else
                            {
                                lbl_resultado.Text = "Cuenta de cobro generada correctamente";
                            }
                        }
                    }
                    ConexionVerificar.Close();
                }
            }
            catch(Exception ex)
            {
                lbl_resultado.Text = "Se ha presentado el siguiente error: " + ex.ToString();
                return;
            }

        }
    }
}