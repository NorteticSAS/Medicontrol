using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            if(ddl_contrato.SelectedValue.ToString() != "0")
            {
                consulta = "SELECT DISTINCT  FacturaCab.NumFac AS NumFactura FROM FacturaCab INNER JOIN FacturaDet ON FacturaCab.NumFac = FacturaDet.numfac WHERE FacturaCab.CodEntidad = '" +this.ddl_entidad.SelectedValue+ "'"+
                           " AND FacturaDet.codcontrato= '"+this.ddl_contrato.SelectedValue+"' AND FacturaCab.Estado = '0' AND FacturaCab.FechaFactura Between '"+ Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechaini.Text)) +"' AND '"+ Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechafin.Text)) + "' AND facturacab.TipoDoc = 1";
            }
            else
            {
                consulta = "SELECT DISTINCT  FacturaCab.NumFac AS NumFactura FROM FacturaCab INNER JOIN FacturaDet ON FacturaCab.NumFac = FacturaDet.numfac WHERE FacturaCab.CodEntidad = '" + this.ddl_entidad.SelectedValue + "'"+
                           " AND FacturaCab.Estado=0 AND FacturaCab.FechaFactura Between '" + Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechaini.Text)) + "' AND '" + Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechafin.Text)) + "' AND facturacab.TipoDoc = 1";
            }

            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            while (leer.Read())
            {
                string facturaNum = leer[0].ToString();
                DataTable dt = new DataTable();

                dt.Columns.Add("1");
                dt.Columns.Add("2");
                dt.Columns.Add("3");
                dt.Columns.Add("4");
                dt.Columns.Add("5");
                foreach (DataRow row in dt.Rows)
                {
                    row["1"] = facturaNum;
                }

                var arreglo = dt;
            }
            
        }
    }
}