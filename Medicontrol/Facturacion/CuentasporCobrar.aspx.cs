using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class WebForm4 : System.Web.UI.Page
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

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            if (txt_numFactura.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un numero de factura";
                return;
            }
            else
            {
                string consulta = "SELECT FacturaCab.NumFac AS NumFactura, FacturaCab.TipoDoc AS TipoDoc, FacturaCab.Prefijo AS Prefijo, Pacientes.Documento AS Documento, (Pacientes.Nombre1+' '+Pacientes.Nombre2+' '+Pacientes.Apellido1+' '+Pacientes.Apellido2) AS Nombre, Pacientes.Direccion AS Direccion, Pacientes.Telefono AS Telefono, FacturaCab.FechaFactura AS FechaFactura, FacturaCab.VrTotalEntidad AS ValorEntidad " +
                                  "FROM Pacientes INNER JOIN FacturaCab ON Pacientes.Documento = FacturaCab.PDocumento Where FacturaCab.TipoDoc = '1' AND FacturaCab.NumFac = '" + this.txt_numFactura.Text + "'";
                SqlConnection Conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(consulta, Conexion);
                Conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read() == true)
                {
                    lbl_resultado.Text = string.Empty;
                    txt_Documento.Text = leer["Documento"].ToString();
                    txt_nombre.Text = leer["Nombre"].ToString();
                    txt_telefono.Text = leer["Telefono"].ToString();
                    txt_direccion.Text = leer["Direccion"].ToString();
                    DateTime fecha = Convert.ToDateTime(leer["FechaFactura"].ToString());
                    txt_fecha.Text = fecha.ToString("dd/MM/yyyy");
                    txt_valor.Text = leer["ValorEntidad"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "El numero de factura no existe verifique";
                    return;
                }
                Conexion.Close();
            }
        }

        protected void btn_buscarDocumento_Click(object sender, EventArgs e)
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
                }
                else
                {
                    lbl_resultado.Text = "No existe ningun paciente con ese Documento";
                    return;
                }
                Conexion.Close();
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if(txt_numFactura.Text==string.Empty)
            {
                lbl_resultado.Text = "Falta el numero de la factura";
                return;
            }
            if (txt_Documento.Text == string.Empty)
            {
                lbl_resultado.Text = "falta el documento del paciente";
                return;
            }
            if (txt_fecha.Text==string.Empty)
            {
                lbl_resultado.Text = "Falta la fecha de la factura";
                return;
            }
            if(txt_valor.Text==string.Empty)
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

            
            DateTime fecha = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fecha.Text));
            string query = "INSERT INTO CuentasporCobrar(NumFactura, CodigoCliente, Detalle, Fecha, ValorFactura, ValorAbonos, ValorSaldo, CodigoVendedor) VALUES('" + this.txt_numFactura.Text + "', '" + this.txt_Documento.Text + "', '" + this.txt_detalle.Text + "', '" + fecha + "', '" + this.txt_valor.Text + "', '0', '" + this.txt_valor.Text + "', '" + this.CodigoSesion.Text + "')";
            if (Datos.insertar(query))
            {
                lbl_resultado.Text = "Error al guardar, Verifique";
            }
            else
            {
                lbl_resultado.Text = "Registro Guardado correctamente";
            }
        }
    }
}