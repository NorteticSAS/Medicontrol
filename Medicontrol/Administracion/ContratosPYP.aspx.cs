using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Administracion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_resultado.Text = string.Empty;

            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM Entidad ORDER BY NombreEntidad", "Entidad");
                ddl_entidades.DataSource = Datos.ds.Tables["Entidad"];
                ddl_entidades.DataTextField = "NombreEntidad";
                ddl_entidades.DataValueField = "Codigo";
                ddl_entidades.DataBind();
                ddl_entidades.Items.Insert(0, new ListItem("Seleccione Entidad"));

                Datos.consultar("SELECT * FROM ProgramasPYP ORDER BY Descripcion", "ProgramasPYP");
                ddl_programapyp.DataSource = Datos.ds.Tables["ProgramasPYP"];
                ddl_programapyp.DataTextField = "Descripcion";
                ddl_programapyp.DataValueField = "Codigo";
                ddl_programapyp.DataBind();
                ddl_programapyp.Items.Insert(0, new ListItem("Seleccione Programa"));
            }
        }

        protected void ddl_entidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!VerificarContrato())
            {
                lbl_resultado.Text = "La entidad no tiene Contratos asociados";
                ddl_contrato.Enabled = false;
                btn_registrar.Enabled = false;
                return;
            }
            else
            {
                btn_registrar.Enabled = true;
                ddl_contrato.ClearSelection();
                ddl_contrato.Enabled = true;
                Datos.consultar("SELECT * FROM Contratos WHERE Estado='Activo' AND Entidad='" + this.ddl_entidades.SelectedValue + "' ORDER BY Descripcion", "Contratos");
                ddl_contrato.DataSource = Datos.ds.Tables["Contratos"];
                ddl_contrato.DataTextField = "Descripcion";
                ddl_contrato.DataValueField = "NumeroContrato";
                ddl_contrato.DataBind();
                ddl_contrato.Items.Insert(0, new ListItem("Seleccione Contrato"));
            }
        }

        public bool VerificarContrato()
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Contratos WHERE Entidad='" + this.ddl_entidades.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("Entidad", ddl_entidades.SelectedValue);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

        protected void ddl_programapyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_procedimiento.Enabled = true;
            ddl_procedimiento.ClearSelection();
            Datos.consultar("SELECT * FROM ProcedPYP WHERE Codigo='" + this.ddl_programapyp.SelectedValue + "' AND Ok=1 ORDER BY DesCups", "ProcedPYP");
            ddl_procedimiento.DataSource = Datos.ds.Tables["ProcedPYP"];
            ddl_procedimiento.DataTextField = "DesCups";
            ddl_procedimiento.DataValueField = "CodCups";
            ddl_procedimiento.DataBind();
            ddl_procedimiento.Items.Insert(0, new ListItem("Seleccione Procedimiento"));
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            if(ddl_entidades.SelectedItem.ToString()== "Seleccione Entidad")
            {
                lbl_resultado.Text = "Debe seleccionar una Entidad";
                return;
            }
            if(ddl_contrato.SelectedItem.ToString()== "Seleccione Contrato")
            {
                lbl_resultado.Text = "Debe seleccionar un Contrato";
                return;
            }
            if(ddl_programapyp.SelectedItem.ToString()=="Seleccione Programa")
            {
                lbl_resultado.Text = "Debe seleccionar un Programa PYP";
                return;
            }
            if(ddl_procedimiento.SelectedItem.ToString()== "Seleccione Procedimiento")
            {
                lbl_resultado.Text = "Debe seleccionar un Procedimiento";
                return;
            }
            if (txt_primerTri.Text == string.Empty) txt_primerTri.Text = "0";
            if (txt_segundoTri.Text == string.Empty) txt_segundoTri.Text = "0";
            if (txt_tercerTri.Text == string.Empty) txt_tercerTri.Text = "0";
            if (txt_cuartoTri.Text == string.Empty) txt_cuartoTri.Text = "0";
            if (txt_metaAnual.Text == string.Empty) txt_metaAnual.Text = "0";

            string sql = "INSERT INTO ControlMetasPYP(CodigoEntidad, CodigoContrato, CodigoPYP, CodigoProcedimiento, MetaPYP1, MetaPYP2, MetaPYP3, MetaPYP4, MetaAnual) VALUES('"+this.ddl_entidades.SelectedValue+ "', '"+this.ddl_contrato.SelectedValue+ "', '"+this.ddl_programapyp.SelectedValue+ "', '"+this.ddl_procedimiento.SelectedValue+ "', '"+this.txt_primerTri.Text+ "', '"+this.txt_segundoTri.Text+ "', '"+this.txt_tercerTri.Text+ "', '"+this.txt_cuartoTri.Text+ "', '"+this.txt_metaAnual.Text+"')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
                Response.Redirect("ContratosPYP.aspx");
            }
        }
    }
}