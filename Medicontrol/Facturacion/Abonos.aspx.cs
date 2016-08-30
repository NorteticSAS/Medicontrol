using Helper;
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

namespace Medicontrol.Facturacion
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                CodigoSesion.Text = Request.Cookies["Login"]["ID"].ToString();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        private void fillgrilla(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
            }
            gridAbonos.DataSource = dt;

            gridAbonos.DataBind();

        }

        protected void gridAbonos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridAbonos, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridAbonos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridAbonos.Rows)
            {
                if (row.RowIndex == gridAbonos.SelectedIndex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupAbonar();", true);
                    this.lbl_mensajeUsuario.Text = "Por favor digite la Cantidad a abonar";
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

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            if (txt_Documento.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un documento para consultar";
                return;
            }
            else
            {
                string consulta = "SELECT Documento, (Nombre1+' '+Nombre2+' '+Apellido1+' '+Apellido2) AS Nombre, Telefono, Direccion FROM Pacientes WHERE Documento='" + this.txt_Documento.Text + "'";
                SqlConnection Conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(consulta, Conexion);
                Conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read() == true)
                {
                    lbl_resultado.Text = string.Empty;
                    txt_nombre.Text = leer["Nombre"].ToString();
                    txt_telefono.Text = leer["Telefono"].ToString();
                    txt_direccion.Text = leer["Direccion"].ToString();

                    string query = "SELECT CodigoCliente, SUM(ValorSaldo) AS Total FROM CuentasporCobrar WHERE CodigoCliente = '" + this.txt_Documento.Text + "' AND ValorSaldo > 0 GROUP BY CodigoCliente";
                    SqlConnection ConexionSaldo = new SqlConnection(ruta);
                    SqlCommand comandoSaldo = new SqlCommand(query, ConexionSaldo);
                    ConexionSaldo.Open();
                    SqlDataReader leerS = comandoSaldo.ExecuteReader();
                    if (leerS.Read() == true)
                    {
                        txt_saldo.Text = leerS["Total"].ToString();
                        lbl_resultado.Text = string.Empty;
                        string consultaGrid = "SELECT NumFactura, Detalle, Fecha, ValorFactura, ValorAbonos, ValorSaldo FROM CuentasporCobrar WHERE CodigoCliente = '" + this.txt_Documento.Text + "' AND ValorSaldo > 0 ORDER BY NumFactura";
                        fillgrilla(consultaGrid);
                    }
                    ConexionSaldo.Close();
                }
                else
                {
                    lbl_resultado.Text = "No existe ningun paciente con ese Documento";
                    return;
                }
                Conexion.Close();
            }
        }

        protected void btn_abonar_Click(object sender, EventArgs e)
        {
            if (txt_valor.Text == string.Empty)
            {
                lbl_resultado.Text = "Falta el valor de la factura";
                return;
            }

            if (!Utilidades.isNumeric(txt_valor.Text))
            {
                lbl_resultado.Text = "Digite una cantidad correcta";
                return;
            }
            if (Convert.ToDouble(txt_valor.Text) < 0)
            {
                lbl_resultado.Text = "Digite una cantidad correcta";
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
                lbl_resultado.Text = "Digite una cantidad correcta";
                return;
            }

            //REGISTRAMOS EL ABONO DE LA FACTURA
            string query = "SELECT * FROM CuentasporCobrar WHERE NumFactura='" + HttpUtility.HtmlDecode(this.gridAbonos.SelectedRow.Cells[0].Text) + "'";
            SqlConnection Conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(query, Conexion);
            Conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {
                double ValorAbono = Convert.ToDouble(leer["ValorAbonos"].ToString());
                double ValorSaldo = Convert.ToDouble(leer["ValorSaldo"].ToString());
                double Abonado = Convert.ToDouble(txt_valor.Text);

                txt_abono.Text = (ValorAbono + Abonado).ToString();
                txt_saldos.Text = (ValorSaldo - Abonado).ToString();

                string updateCuentas = "UPDATE CuentasporCobrar SET ValorAbonos='" + this.txt_abono.Text + "', ValorSaldo='" + this.txt_saldos.Text + "' WHERE NumFactura='" + this.gridAbonos.SelectedRow.Cells[0].Text + "'";
                if (Datos.insertar(updateCuentas))
                {
                    lbl_resultado.Text = "No se modificó la información, verifique";
                }
                else
                {
                    DateTime hoy = DateTime.Now;
                    string diahoy = hoy.ToString("dd/MM/yyyy");
                    DateTime fecha = Convert.ToDateTime(ViewHelper.ConvertToDate(diahoy));
                    string abono = "INSERT INTO Abonos(NumFactura, Fecha, Valor, CodigoUsuario) VALUES('" + this.gridAbonos.SelectedRow.Cells[0].Text + "', '" + fecha + "', '" + this.txt_valor.Text + "', '" + this.CodigoSesion.Text + "')";
                    if (Datos.insertar(abono))
                    {
                        lbl_resultado.Text = "No se modificó la información, verifique";
                    }
                    else
                    {
                        lbl_resultado.Text = string.Empty;
                        string consultaGrid = "SELECT NumFactura, Detalle, Fecha, ValorFactura, ValorAbonos, ValorSaldo FROM CuentasporCobrar WHERE CodigoCliente = '" + this.txt_Documento.Text + "' AND ValorSaldo > 0 ORDER BY NumFactura";
                        fillgrilla(consultaGrid);
                    }
                    Conexion.Close();
                }
            }
        }
    }
}