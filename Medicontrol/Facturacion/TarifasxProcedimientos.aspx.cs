using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class WebForm11 : System.Web.UI.Page
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

        [WebMethod]
        public static string[] BuscarProcedimientos(string prefix)
        {

           
             string sql = "select DescProcedimiento from Procedimientos where DescProcedimiento like '%'+@SearchText+'%' AND Estado='0'";
            
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

        protected void btn_buscarCodigo_Click(object sender, EventArgs e)
        {
            if(ddl_entidad.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "Debe seleccionar una Entidad";
                return;
            }

            if(ddl_contrato.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "Debe seleccionar un contrato";
                return;
            }

            if(txt_codProced.Text==string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un codigo de procedimiento";
                return;
            }

            string BuscarCodigo = "SELECT Procedimientos.CodProcedimiento, Procedimientos.DescProcedimiento AS Descripcion, Tarifas.Valor AS Valor, Planes.CodPlan, PlanesContratos.Porcentaje AS Porcentaje, Entidad.Codigo, Contratos.Codigo, Procedimientos.CodRips, Procedimientos.Finalidad, PlanesContratos.Capita AS cobrarcopago " +
                                  "FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento " +
                                  "WHERE Procedimientos.CodProcedimiento= '" + txt_codProced.Text + "' AND Contratos.Codigo='" + ddl_contrato.SelectedValue + "' AND Contratos.Entidad = '" + ddl_entidad.SelectedValue + "'";
            SqlConnection ConexionConsec = new SqlConnection(ruta);
            SqlCommand comando6 = new SqlCommand(BuscarCodigo, ConexionConsec);
            ConexionConsec.Open();
            SqlDataReader leer6 = comando6.ExecuteReader();
            if (leer6.Read() == true)
            {
                txt_valorProced.Text = leer6["Valor"].ToString();
                txt_desproced.Text = leer6["Descripcion"].ToString();
                double ValorReal;
                double Valor = 0;
                double Porcentaje = 0; 
                if(leer6["Porcentaje"].ToString()!=string.Empty || leer6["Porcentaje"].ToString()!=null)
                {
                    Porcentaje = Convert.ToDouble(leer6["Porcentaje"].ToString());
                }
                if(txt_valorProced.Text!=string.Empty || txt_valorProced.Text!=null)
                {
                    Valor = Convert.ToDouble(txt_valorProced.Text);
                }

                ValorReal = (Valor * Porcentaje) / 100;
                if(leer6["cobrarcopago"].ToString()=="1")
                {
                    copagonivel1.Text = (ValorReal * 0.05).ToString();
                    Entidadnivel1.Text = (ValorReal * 0.95).ToString();
                    copagonivel2.Text = (ValorReal * 0.1).ToString();
                    Entidadnivel2.Text = (ValorReal * 0.9).ToString();
                    copagonivel3.Text = (ValorReal * 0.3).ToString();
                    Entidadnivel3.Text = (ValorReal * 0.7).ToString();
                }
            }
            else
            {
                lbl_resultado.Text = "No existe un procedimiento con ese Código";
                return;
            }
            ConexionConsec.Close();
        }

        protected void btn_buscarNombre_Click(object sender, EventArgs e)
        {
            if (ddl_entidad.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar una Entidad";
                return;
            }

            if (ddl_contrato.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un contrato";
                return;
            }

            if (txt_proced.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un codigo de procedimiento";
                return;
            }

            string BuscarCodigo = "SELECT Procedimientos.CodProcedimiento, Procedimientos.DescProcedimiento AS Descripcion, Tarifas.Valor AS Valor, Planes.CodPlan, PlanesContratos.Porcentaje AS Porcentaje, Entidad.Codigo, Contratos.Codigo, Procedimientos.CodRips, Procedimientos.Finalidad, PlanesContratos.Capita AS cobrarcopago " +
                                  "FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento " +
                                  "WHERE Procedimientos.DescProcedimiento= '" + txt_proced.Text + "' AND Contratos.Codigo='" + ddl_contrato.SelectedValue + "' AND Contratos.Entidad = '" + ddl_entidad.SelectedValue + "'";
            SqlConnection ConexionConsec = new SqlConnection(ruta);
            SqlCommand comando6 = new SqlCommand(BuscarCodigo, ConexionConsec);
            ConexionConsec.Open();
            SqlDataReader leer6 = comando6.ExecuteReader();
            if (leer6.Read() == true)
            {
                txt_valorProced.Text = leer6["Valor"].ToString();
                txt_desproced.Text = leer6["Descripcion"].ToString();
                double ValorReal;
                double Valor = 0;
                double Porcentaje = 0;
                if (leer6["Porcentaje"].ToString() != string.Empty || leer6["Porcentaje"].ToString() != null)
                {
                    Porcentaje = Convert.ToDouble(leer6["Porcentaje"].ToString());
                }
                if (txt_valorProced.Text != string.Empty || txt_valorProced.Text != null)
                {
                    Valor = Convert.ToDouble(txt_valorProced.Text);
                }

                ValorReal = (Valor * Porcentaje) / 100;
                if (leer6["cobrarcopago"].ToString() == "1")
                {
                    copagonivel1.Text = (ValorReal * 0.05).ToString();
                    Entidadnivel1.Text = (ValorReal * 0.95).ToString();
                    copagonivel2.Text = (ValorReal * 0.1).ToString();
                    Entidadnivel2.Text = (ValorReal * 0.9).ToString();
                    copagonivel3.Text = (ValorReal * 0.3).ToString();
                    Entidadnivel3.Text = (ValorReal * 0.7).ToString();
                }
            }
            else
            {
                lbl_resultado.Text = "No existe un procedimiento con ese Código";
                return;
            }
            ConexionConsec.Close();
        }
    }
}