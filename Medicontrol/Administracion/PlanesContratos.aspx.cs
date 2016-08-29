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

namespace Medicontrol.Administracion
{
    public partial class Formulario_web119 : System.Web.UI.Page
    {
        string copago, copago1;
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_resultado.Text = string.Empty;

            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM Entidad ORDER BY NombreEntidad", "Entidad");
                this.ddl_entidades.DataSource = Datos.ds.Tables["Entidad"];
                this.ddl_entidades.DataTextField = "NombreEntidad";
                this.ddl_entidades.DataValueField = "Codigo";
                this.ddl_entidades.DataBind();
                ddl_entidades.Items.Insert(0, new ListItem("Seleccione Entidad"));

                Datos.consultar("SELECT * FROM Planes ORDER BY Descripcion", "Planes");
                this.ddl_planes.DataSource = Datos.ds.Tables["Planes"];
                this.ddl_planes.DataTextField = "Descripcion";
                this.ddl_planes.DataValueField = "CodPlan";
                this.ddl_planes.DataBind();
                ddl_planes.Items.Insert(0, new ListItem("Selecciona plan"));

                Datos.consultar("SELECT * FROM Tarifarios ORDER BY DescTarifarios", "Tarifarios");
                this.ddl_tarifarios.DataSource = Datos.ds.Tables["Tarifarios"];
                this.ddl_tarifarios.DataTextField = "DescTarifarios";
                this.ddl_tarifarios.DataValueField = "CodTarifarios";
                this.ddl_tarifarios.DataBind();
                ddl_tarifarios.Items.Insert(0, new ListItem("Seleccione Tarifario"));
                               
            }
        }

        protected void ddl_entidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillgrilla();
            ddl_tarifarios.ClearSelection();
            ddl_planes.ClearSelection();
            txt_tarifario.Text = string.Empty;
            check_copago.Checked = false;
            ddl_contrato.Enabled = true;
            Datos.consultar("SELECT * FROM Contratos WHERE Entidad='"+ddl_entidades.SelectedValue+"' AND Estado='Activo' ORDER BY Descripcion", "Contratos");
            this.ddl_contrato.DataSource = Datos.ds.Tables["Contratos"];
            this.ddl_contrato.DataTextField = "Descripcion";
            this.ddl_contrato.DataValueField = "Codigo";
            this.ddl_contrato.DataBind();
            ddl_contrato.Items.Insert(0, new ListItem("Seleccione Contrato"));
        }

        protected void ddl_contrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_tarifarios.ClearSelection();
            ddl_planes.ClearSelection();
            txt_tarifario.Text = string.Empty;
            check_copago.Checked = false;
            ddl_planes.Enabled = true;
            ddl_tarifarios.Enabled = true;
            string copago;
            string sql = "SELECT * FROM PlanesContratos WHERE CodigoEntidad='"+this.ddl_entidades.SelectedValue.ToString()+"' AND CodigoContrato='"+this.ddl_contrato.SelectedValue.ToString()+"'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                fillgrilla();
                btn_modificar.Visible = false;
                btn_registrar.Visible = false;
                btn_eliminar.Visible = false;
                ddl_tarifarios.ClearSelection();
                //ddl_tarifarios.SelectedItem.Text = leer["DescripcionTarifario"].ToString();
                //ddl_planes.SelectedItem.Text = leer["NombrePlan"].ToString();
                ddl_planes.ClearSelection();
                txt_tarifario.Text = leer["Porcentaje"].ToString();
                string Porcopago = leer["Capita"].ToString();
                if (Porcopago == "0")
                {
                    check_copago.Checked = false;
                }
                else
                {
                    check_copago.Checked = true;
                }
                btn_registrar.Visible = true;
               // btn_modificar.Visible = true;
                //btn_eliminar.Visible = true;
            }
            else
            {
                fillgrilla();
                lbl_resultado.Text = "La Entidad y Contrato seleccionados no tienen planes asignados";
                txt_tarifario.Text = string.Empty;
                check_copago.Checked = false;
                ddl_tarifarios.ClearSelection();
                ddl_planes.ClearSelection();
                btn_registrar.Visible = true;
                btn_modificar.Visible = false;
                btn_eliminar.Visible = false;
            }
        }

        private void fillgrilla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodigoPlan, NombrePlan, CodigoTarifario, DescripcionTarifario, Porcentaje, Capita FROM PlanesContratos WHERE CodigoEntidad='" + this.ddl_entidades.SelectedValue.ToString() + "' AND CodigoContrato='"+this.ddl_contrato.SelectedValue.ToString()+"'", cn);
                da.Fill(dt);
            }
            gridContratos.DataSource = dt;

            gridContratos.DataBind();

        }


        protected void gridContratos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridContratos, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridContratos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridContratos.Rows)
            {
                if (row.RowIndex == gridContratos.SelectedIndex)
                {
                    string sql = "SELECT * FROM PlanesContratos WHERE Id='" + this.gridContratos.SelectedRow.Cells[0].Text + "'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {

                        btn_registrar.Visible = false;
                        btn_modificar.Visible = true;
                        btn_eliminar.Visible = true;
                        fillgrilla();
                        txt_tarifario.Text = leer["Porcentaje"].ToString();
                        string Porcopago = leer["Capita"].ToString();
                        if (Porcopago == "0")
                        {
                            check_copago.Checked = false;
                        }
                        else
                        {
                            check_copago.Checked = true;
                        }
                    }
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click para seleccionar este Registro";
                }
            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            
            if (check_copago.Checked == true) copago = "1";
            if (check_copago.Checked == false) copago = "0";
            if (ddl_tarifarios.SelectedItem.ToString() == "Seleccione Tarifario")
            {
                lbl_resultado.Text = "Debe seleccionar un Tarifario";
                return;
            }
            if (ddl_planes.SelectedItem.ToString() == "Selecciona plan")
            {
                lbl_resultado.Text = "Debe seleccionar un Plan";
                return;
            }
            if (txt_tarifario.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe Introducor un Porcentaje de Tarifario";
                return;
            }


            string sql = "INSERT INTO PlanesContratos(CodigoEntidad, CodigoContrato, CodigoTarifario, DescripcionTarifario, CodigoPlan, NombrePlan, Porcentaje, Capita) VALUES('"+this.ddl_entidades.SelectedValue+"', '"+this.ddl_contrato.SelectedValue+"', '"+this.ddl_tarifarios.SelectedValue+"', '"+this.ddl_tarifarios.SelectedItem+"', '"+this.ddl_planes.SelectedValue+"', '"+this.ddl_planes.SelectedItem+"', '"+this.txt_tarifario.Text+"', '"+copago+"')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
                fillgrilla();
                //Response.Redirect("PlanesContratos.aspx");
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM PlanesContratos WHERE Id='"+ this.gridContratos.SelectedRow.Cells[0].Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al eliminar, Verifique";
            }
            else
            {
                fillgrilla();
                //Response.Redirect("PlanesContratos.aspx");
            }
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            if (check_copago.Checked == true) copago1 = "1";
            if (check_copago.Checked == false) copago1 = "0";
            if (ddl_tarifarios.SelectedItem.ToString() == "Seleccione Tarifario")
            {
                lbl_resultado.Text = "Debe seleccionar un Tarifario";
                return;
            }
            if (ddl_planes.SelectedItem.ToString() == "Selecciona plan")
            {
                lbl_resultado.Text = "Debe seleccionar un Plan";
                return;
            }
            if (txt_tarifario.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe Introducor un Porcentaje de Tarifario";
                return;
            }
            try
            {
                string sql = "UPDATE PlanesContratos SET CodigoTarifario='" + this.ddl_tarifarios.SelectedValue + "', DescripcionTarifario='" + this.ddl_tarifarios.SelectedItem + "', CodigoPlan='" + this.ddl_planes.SelectedValue + "', NombrePlan='" + this.ddl_planes.SelectedItem + "', Porcentaje='" + this.txt_tarifario.Text + "', Capita='" + copago1 + "' WHERE Id='" + this.gridContratos.SelectedRow.Cells[0].Text + "'";
                if (Datos.insertar(sql))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    fillgrilla();
                    //Response.Redirect("PlanesContratos.aspx");
                }
            }
            catch(Exception ex)
            {
                lbl_resultado.Text = "Ocurrio un Error inesperado, Consulte con el administrador";
            }
        }
    }
}