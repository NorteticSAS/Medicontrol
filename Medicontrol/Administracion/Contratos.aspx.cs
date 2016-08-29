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
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Administracion
{
    public partial class Formulario_web118 : System.Web.UI.Page
    {
        public string valorMes, aux;

        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            fillgrilla();
            lbl_resultado.Text = string.Empty;

            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM Entidad ORDER BY NombreEntidad", "Entidad");
                this.ddl_entidades.DataSource = Datos.ds.Tables["Entidad"];
                this.ddl_entidades.DataTextField = "NombreEntidad";
                this.ddl_entidades.DataValueField = "Codigo";
                this.ddl_entidades.DataBind();
                ddl_entidades.Items.Insert(0, new ListItem("Seleccione Entidad"));

                Datos.consultar("SELECT * FROM Regimen ORDER BY Regimen", "Regimen");
                this.ddl_regimen.DataSource = Datos.ds.Tables["Regimen"];
                this.ddl_regimen.DataTextField = "Regimen";
                this.ddl_regimen.DataValueField = "Codigo";
                this.ddl_regimen.DataBind();
                ddl_regimen.Items.Insert(0, new ListItem("Seleccione Régimen", "0"));
            }
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Código Contrato no puede estar vacio";
                return;
            }

            if (VerificarContrato(txt_codigo.Text))
            {
                lbl_resultado.Text = "Ya existe una contrato con este código";
                return;
            }

            if (txt_numcontrato.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Número de Contrato se encuentra vacio";
                return;
            }

            if (txt_descripcion.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Descripción se encuentra vacio";
                return;
            }

            if (ddl_tipocontrato.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un tipo de Contrato";
                return;
            }

            if (txt_capita.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo %Capita se encuentra vacio";
                return;
            }

            if (txt_afiliados.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Número de Afiliados se encuentra vacio";
                return;
            }

            if (txt_inicial.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Fecha Inicial se encuentra vacio";
                return;
            }

            if (txt_final.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Fecha Final se encuentra vacio";
                return;
            }

            if (txt_valormes1.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Valor Mes se encuentra vacio";
                return;
            }

            if (ddl_regimen.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un Regimen";
                return;
            }

            if (ddl_estado.SelectedItem.ToString() == "Seleccione el Estado")
            {
                lbl_resultado.Text = "Debe seleccionar un Estado";
                return;
            }

            if (txt_municipio.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Municipio se encuentra vacio";
                return;
            }

            DateTime FechaInicial = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_inicial.Text));
            DateTime FechaFinal = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_final.Text));


            string sql = "INSERT INTO Contratos(Codigo, NumeroContrato, Descripcion, TipoContrato, PorcenCapita, Afiliados, FechaInicial, FechaFinal, ValorMes, Regimen, Estado, Municipio, Entidad) VALUES('" + this.txt_codigo.Text + "', '" + this.txt_numcontrato.Text + "', '" + this.txt_descripcion.Text + "', '" + this.ddl_tipocontrato.SelectedValue + "', '" + this.txt_capita.Text + "', '" + this.txt_afiliados.Text + "', '" + FechaInicial + "', '" + FechaFinal + "', '" + this.txt_valormes.Text + "', '" + this.ddl_regimen.SelectedItem + "', '" + this.ddl_estado.SelectedItem + "', '" + this.txt_municipio.Text + "', '" + this.ddl_entidades.SelectedValue + "')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
                fillgrilla();
            }

        }

        public bool VerificarContrato(string codigo)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Contratos WHERE Codigo='" + this.txt_codigo.Text + "' and Entidad='" + this.ddl_entidades.SelectedValue + "' and TipoContrato='" + this.ddl_tipocontrato.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("Codigo", codigo);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
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
                    string sql = "SELECT * FROM Contratos WHERE Codigo='" + this.gridContratos.SelectedRow.Cells[0].Text + "'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {

                        txt_codigo.Text = leer["Codigo"].ToString();
                        txt_numcontrato.Text = leer["NumeroContrato"].ToString();
                        txt_descripcion.Text = leer["Descripcion"].ToString();
                        ddl_tipocontrato.ClearSelection();

                        ddl_tipocontrato.Items.FindByValue(leer["TipoContrato"].ToString()).Selected = true;
                        txt_capita.Text = leer["PorcenCapita"].ToString();
                        txt_afiliados.Text = leer["Afiliados"].ToString();
                        DateTime fechaI = Convert.ToDateTime(leer["FechaInicial"].ToString());
                        DateTime fechaF = Convert.ToDateTime(leer["FechaFinal"].ToString());
                        txt_inicial.Text = fechaI.ToString("dd/MM/yyyy");
                        txt_final.Text = fechaF.ToString("dd/MM/yyyy");
                        double var = 0;
                        if (leer["ValorMes"].ToString() != string.Empty)
                        {
                            var = Convert.ToDouble(leer["ValorMes"].ToString());
                        }
                        txt_valormes1.Text = var.ToString();
                        txt_valormes.Text = var.ToString();
                        ddl_regimen.ClearSelection();
                        ddl_regimen.Items.FindByText(leer["Regimen"].ToString()).Selected = true;

                        ddl_estado.ClearSelection();
                        ddl_estado.Items.FindByText(leer["Estado"].ToString()).Selected = true;
                        txt_municipio.Text = leer["Municipio"].ToString();
                        btn_modificar.Visible = true;
                        btn_registrar.Visible = false;
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

        private void fillgrilla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Codigo, Descripcion FROM Contratos WHERE Entidad='" + this.ddl_entidades.SelectedValue.ToString() + "'", cn);
                da.Fill(dt);
            }
            gridContratos.DataSource = dt;

            gridContratos.DataBind();

        }

        [WebMethod]
        public static string[] Municipios(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT Municipio FROM Municipios where CodDpto='54' and Municipio like '%'+@SearchText+'%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}", sdr["Municipio"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

        protected void ddl_entidades_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sql = "SELECT * FROM Contratos WHERE Entidad='" + this.ddl_entidades.SelectedValue.ToString() + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                fillgrilla();
                txt_codigo.ReadOnly = true;
                txt_codigo.Text = leer["Codigo"].ToString();
                txt_numcontrato.ReadOnly = true;
                txt_numcontrato.Text = leer["NumeroContrato"].ToString();
                txt_descripcion.ReadOnly = false;
                txt_descripcion.Text = leer["Descripcion"].ToString();
                ddl_tipocontrato.ClearSelection();

                ddl_tipocontrato.Items.FindByValue(leer["TipoContrato"].ToString()).Selected = true;

                txt_capita.Text = leer["PorcenCapita"].ToString();
                txt_afiliados.Text = leer["Afiliados"].ToString();
                DateTime fechaI = Convert.ToDateTime(leer["FechaInicial"].ToString());
                DateTime fechaF = Convert.ToDateTime(leer["FechaFinal"].ToString());
                txt_inicial.Text = fechaI.ToString("dd/MM/yyyy");
                txt_final.Text = fechaF.ToString("dd/MM/yyyy");
                double var = Convert.ToDouble(leer["ValorMes"].ToString());
                txt_valormes.Text = var.ToString();
                ddl_regimen.ClearSelection();
                ddl_regimen.Items.FindByText(leer["Regimen"].ToString()).Selected = true;

                ddl_estado.ClearSelection();
                ddl_estado.Items.FindByText(leer["Estado"].ToString()).Selected = true;
                txt_municipio.Text = leer["Municipio"].ToString();
                btn_modificar.Visible = true;
                btn_nuevo.Visible = true;
                btn_registrar.Visible = false;
            }
            else
            {
                fillgrilla();
                ddl_tipocontrato.Visible = true;
                lbl_resultado.Text = "La empresa seleccionada no tiene Contratos";
                txt_codigo.ReadOnly = false;
                txt_numcontrato.ReadOnly = false;
                txt_descripcion.ReadOnly = false;
                btn_modificar.Visible = false;
                btn_registrar.Visible = true;
                txt_tipocontrato.Visible = false;
                txt_regimen.Visible = false;
                txt_estado.Visible = false;
                txt_codigo.Text = string.Empty;
                txt_numcontrato.Text = string.Empty;
                txt_descripcion.Text = string.Empty;
                ddl_tipocontrato.ClearSelection();
                txt_capita.Text = string.Empty;
                txt_afiliados.Text = string.Empty;
                txt_inicial.Text = string.Empty;
                txt_final.Text = string.Empty;
                txt_valormes.Text = string.Empty;
                ddl_regimen.ClearSelection();
                ddl_estado.ClearSelection();
                txt_municipio.Text = string.Empty;
                btn_nuevo.Visible = false;


            }
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {

            
            if (txt_capita.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo %Capita se encuentra vacio";
                return;
            }

            if (txt_afiliados.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Número de Afiliados se encuentra vacio";
                return;
            }

            if (txt_inicial.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Fecha Inicial se encuentra vacio";
                return;
            }

            if (txt_final.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Fecha Final se encuentra vacio";
                return;
            }

            if (txt_valormes.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Valor Mes se encuentra vacio";
                return;
            }

            if (ddl_regimen.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "Debe seleccionar un Regimen";
                return;
            }

            if (ddl_estado.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "Debe seleccionar un Estado";
                return;
            }

            if (txt_municipio.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo Municipio se encuentra vacio";
                return;
            }
            DateTime FechaInicial = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_inicial.Text));
            DateTime FechaFinal = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_final.Text));
            
              string ValorFinal = txt_valormes1.Text;
                
           
            try
            {
                string sql = "UPDATE Contratos SET TipoContrato='" + this.ddl_tipocontrato.SelectedValue + "', PorcenCapita='" + this.txt_capita.Text + "', Afiliados='" + this.txt_afiliados.Text + "', FechaInicial='" + FechaInicial + "', FechaFinal='" + FechaFinal + "', ValorMes='" + ValorFinal + "', Regimen='" + this.ddl_regimen.SelectedItem + "', Estado='" + this.ddl_estado.SelectedItem + "', Municipio='" + this.txt_municipio.Text + "', Descripcion='"+this.txt_descripcion.Text+"' WHERE Codigo='" + this.txt_codigo.Text + "'";
                if (Datos.insertar(sql))
                {
                    lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                }
                else
                {
                    fillgrilla();
                }
            }
            catch
            {
                lbl_resultado.Text = "Ocurrio un Error inesperado, Consulte con el administrador";
            }
        }

        protected void ddl_tipocontrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_tipocontrato.Text = ddl_tipocontrato.SelectedItem.ToString();
        }

        protected void ddl_regimen_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_regimen.Text = ddl_regimen.SelectedItem.ToString();
        }

        protected void ddl_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_estado.Text = ddl_estado.SelectedItem.ToString();
        }

        protected void btn_nuevo_Click(object sender, EventArgs e)
        {

            ddl_tipocontrato.Enabled = true;
            ddl_tipocontrato.ClearSelection();
            ddl_tipocontrato.Visible = true;
            lbl_resultado.Text = "";
            txt_codigo.ReadOnly = false;
            txt_numcontrato.ReadOnly = false;
            txt_descripcion.ReadOnly = false;
            btn_modificar.Visible = false;
            btn_registrar.Visible = true;
            txt_tipocontrato.Visible = false;
            txt_regimen.Visible = false;
            txt_estado.Visible = false;
            txt_codigo.Text = string.Empty;
            txt_numcontrato.Text = string.Empty;
            txt_descripcion.Text = string.Empty;
            ddl_tipocontrato.ClearSelection();
            txt_capita.Text = string.Empty;
            txt_afiliados.Text = string.Empty;
            txt_inicial.Text = string.Empty;
            txt_final.Text = string.Empty;
            txt_valormes.Text = string.Empty;
            ddl_regimen.ClearSelection();
            ddl_estado.ClearSelection();
            txt_municipio.Text = string.Empty;
            btn_modificar.Visible = false;
            btn_registrar.Visible = true;
            btn_nuevo.Visible = false;
        }

    }
}