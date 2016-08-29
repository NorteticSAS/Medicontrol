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
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_buscarPro_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor digite un Código";
                return;
            }

            string busqueda = "SELECT * FROM Profesionales WHERE CodProfesional ='" + this.txt_buscar.Text + "'";
            SqlConnection conexion2 = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(busqueda, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
             
                lbl_codigo.Visible = true;
                txt_codigo.Visible = true;
                lbl_primernombre.Visible = true;
                txt_primernombre.Visible = true;
                lbl_segundonombre.Visible = true;
                txt_segundonombre.Visible = true;
                lbl_primerapellido.Visible = true;
                txt_primerapellido.Visible = true;
                lbl_segundoapellido.Visible = true;
                txt_segundoapellido.Visible = true;
                lbl_tipopersona.Visible = true;
                txt_codigo.ReadOnly = true;
                txt_primernombre.ReadOnly = true;
                txt_segundonombre.ReadOnly = true;
                txt_primerapellido.ReadOnly = true;
                txt_segundoapellido.ReadOnly = true;
                ddl_estado.ClearSelection();
                ddl_tipopersona.Enabled = false;
                lbl_estado.Visible = true;
                ddl_estado.Visible = true;
                ddl_tipopersona.Visible = true;
                ddl_estado.ClearSelection();
                btn_Actualizar.Enabled = true;
                btn_Eliminar.Enabled = true;
                txt_codigo.Text = leer["CodProfesional"].ToString();
                txt_primernombre.Text = leer["NomProfesional"].ToString();
                txt_segundonombre.Text = leer["NomProfesional2"].ToString();
                txt_primerapellido.Text = leer["ApeProfesional"].ToString();
                txt_segundoapellido.Text = leer["ApeProfesional2"].ToString();
                ddl_tipopersona.ClearSelection();
                ddl_tipopersona.Items.FindByValue(leer["TipoPersonal"].ToString()).Selected = true;
                ddl_estado.ClearSelection();
                ddl_estado.Items.FindByValue(leer["Estado"].ToString()).Selected = true;
                lbl_resultado.Text = string.Empty;

            }
            else
            {
                lbl_resultado.Text = "No se Encontro Profesional";
                lbl_codigo.Visible = false;
                txt_codigo.Visible = false;
                lbl_primernombre.Visible = false;
                txt_primernombre.Visible = false;
                lbl_segundonombre.Visible = false;
                txt_segundonombre.Visible = false;
                lbl_primerapellido.Visible = false;
                txt_primerapellido.Visible = false;
                lbl_segundoapellido.Visible = false;
                txt_segundoapellido.Visible = false;
                lbl_tipopersona.Visible = false;
                ddl_tipopersona.Visible = false;
                lbl_estado.Visible = false;
                ddl_estado.ClearSelection(); ;
                ddl_tipopersona.ClearSelection();
                ddl_estado.ClearSelection();
            }
            conexion2.Close();
        }

      
        protected void btn_Eliminar_Click1(object sender, EventArgs e)
        {
            string sql4 = "DELETE FROM Profesionales WHERE CodProfesional='" + this.txt_codigo.Text + "'";

            if (Datos.insertar(sql4))
            {
                lbl_resultado.Text = "Error de conexión, no se pudo Eliminar la información";
            }
            else
            {
                lbl_resultado.Text = "El profesional ha sido eliminado correctamente";
                Response.Redirect("BuscarProfesional.aspx");
            }
        }
    }
}