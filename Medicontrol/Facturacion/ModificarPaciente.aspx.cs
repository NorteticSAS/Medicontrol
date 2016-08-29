using Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_resultado.Text = string.Empty;
           
            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM TipoDocumento ORDER BY NomDocumento", "TipoDocumento");
                this.ddl_tipodoc.DataSource = Datos.ds.Tables["TipoDocumento"];
                this.ddl_tipodoc.DataTextField = "NomDocumento";
                this.ddl_tipodoc.DataValueField = "CodDocumento";
                this.ddl_tipodoc.DataBind();
                ddl_tipodoc.Items.Insert(0, new ListItem("Seleccione Tipo de Documento"));

                Datos.consultar("SELECT * FROM TipoUsuario ORDER BY Tipo", "TipoUsuario");
                this.ddl_tipousuario.DataSource = Datos.ds.Tables["TipoUsuario"];
                this.ddl_tipousuario.DataTextField = "Tipo";
                this.ddl_tipousuario.DataValueField = "Id";
                this.ddl_tipousuario.DataBind();
                ddl_tipousuario.Items.Insert(0, new ListItem("Seleccione Tipo de Usuario"));

                Datos.consultar("SELECT * FROM Departamentos ORDER BY Departamento", "Departamentos");
                this.ddl_departamento.DataSource = Datos.ds.Tables["Departamentos"];
                this.ddl_departamento.DataTextField = "Departamento";
                this.ddl_departamento.DataValueField = "CodDpto";
                this.ddl_departamento.DataBind();
                ddl_departamento.Items.Insert(0, new ListItem("Seleccione Departamento"));

                Datos.consultar("SELECT * FROM Estratos ORDER BY Descripcion", "Estratos");
                this.ddl_estrato.DataSource = Datos.ds.Tables["Estratos"];
                this.ddl_estrato.DataTextField = "Descripcion";
                this.ddl_estrato.DataValueField = "Id";
                this.ddl_estrato.DataBind();
                ddl_estrato.Items.Insert(0, new ListItem("Seleccione Estrato"));

                Datos.consultar("SELECT * FROM Entidad ORDER BY NombreEntidad", "Entidad");
                this.ddl_entidad.DataSource = Datos.ds.Tables["Entidad"];
                this.ddl_entidad.DataTextField = "NombreEntidad";
                this.ddl_entidad.DataValueField = "Codigo";
                this.ddl_entidad.DataBind();
                ddl_entidad.Items.Insert(0, new ListItem("Seleccione Entidad"));
            }
        }

        [WebMethod]
        public static string[] BuscarPaciente(string prefix)
        {
            string sql = "SELECT (Nombre1+' '+Nombre2+' '+Apellido1+' '+Apellido2) AS NombreCompleto FROM Pacientes WHERE Nombre1 like '%'+@SearchText+'%'";

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
                            customers.Add(string.Format("{0}", sdr["NombreCompleto"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

        protected void btn_buscarPaciente_Click(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe ingresar un código para realizar la búsqueda";
                return;
            }

            string sql = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_buscar.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                ddl_tipodoc.ClearSelection();
                ddl_tipousuario.ClearSelection();
                ddl_tipoafiliado.ClearSelection();
                ddl_sexo.ClearSelection();
                ddl_departamento.ClearSelection();
                ddl_municipio.ClearSelection();
                ddl_zona.ClearSelection();
                ddl_estrato.ClearSelection();
                ddl_estado.ClearSelection();
                lbl_resultado.Text = string.Empty;
                lbl_documento.Visible = true;
                txt_documento.Visible = true;               
                lbl_numhistoria.Visible = true;
                txt_numhistoria.Visible = true;
                lbl_numcarnet.Visible = true;
                txt_numcarnet.Visible = true;
                lbl_nombre1.Visible = true;
                txt_nombre1.Visible = true;
                lbl_nombre2.Visible = true;
                txt_nombre2.Visible = true;
                lbl_apellido1.Visible = true;
                txt_apellido1.Visible = true;
                lbl_apellido2.Visible = true;
                txt_apellido2.Visible = true;
                lbl_tipoafiliado.Visible = true;
                lbl_Fechanaci.Visible = true;
                txt_fechanaci.Visible = true;
                lbl_direccion.Visible = true;
                txt_direccion.Visible = true;
                lbl_telefono.Visible = true;
                txt_telefono.Visible = true;
                txt_documento.Text = leer["Documento"].ToString();
                ddl_tipodoc.Items.FindByValue(leer["TipoDocumento"].ToString()).Selected=true;
                txt_numhistoria.Text = leer["NumHistoria"].ToString();
                txt_numcarnet.Text = leer["NumCarnet"].ToString();
                txt_nombre1.Text = leer["Nombre1"].ToString();
                txt_nombre2.Text = leer["Nombre2"].ToString();
                txt_apellido1.Text = leer["Apellido1"].ToString();
                txt_apellido2.Text = leer["Apellido2"].ToString();
                ddl_tipousuario.Items.FindByText(leer["TipoUsuario"].ToString()).Selected = true;
                ddl_sexo.Items.FindByText(leer["Sexo"].ToString()).Selected = true;
                DateTime fechaN = Convert.ToDateTime(leer["FechaNacimiento"].ToString());
                txt_fechanaci.Text = fechaN.ToString("dd/MM/yyyy");
                ddl_departamento.Items.FindByValue(leer["Departamento"].ToString()).Selected = true;
                ddl_zona.Items.FindByText(leer["Zona"].ToString()).Selected = true;
                ddl_estrato.Items.FindByText(leer["Estrato"].ToString()).Selected = true;
                txt_direccion.Text = leer["Direccion"].ToString();
                txt_telefono.Text = leer["Telefono"].ToString();
                ddl_estado.Items.FindByText(leer["Estado"].ToString()).Selected = true;
                if (ddl_tipousuario.SelectedItem.ToString() == "Contributivo")
                {
                    ddl_tipoafiliado.Enabled = true;
                    Datos.consultar("SELECT * FROM TipoAfiliado ORDER BY Descripcion", "TipoAfiliado");
                    ddl_tipoafiliado.DataSource = Datos.ds.Tables["TipoAfiliado"];
                    ddl_tipoafiliado.DataTextField = "Descripcion";
                    ddl_tipoafiliado.DataValueField = "Id";
                    ddl_tipoafiliado.DataBind();
                    ddl_tipoafiliado.Items.Insert(0, new ListItem("Seleccione Tipo de Afiliado"));
                    ddl_tipoafiliado.ClearSelection();
                    ddl_tipoafiliado.Items.FindByText(leer["TipoAfiliado"].ToString()).Selected = true;
                }
                else
                {
                    ddl_tipoafiliado.Enabled = false;
                    ddl_tipoafiliado.Items.Insert(0, new ListItem("","0"));
                }
                    Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento.SelectedValue + "' ORDER BY Municipio", "Municipios");
                    this.ddl_municipio.DataSource = Datos.ds.Tables["Municipios"];
                    this.ddl_municipio.DataTextField = "Municipio";
                    this.ddl_municipio.DataValueField = "CodMncpio";
                    this.ddl_municipio.DataBind();
                    ddl_municipio.Items.Insert(0, new ListItem("Seleccione Municipio"));
                    ddl_municipio.ClearSelection();
                    ddl_municipio.Items.FindByValue(leer["Municipio"].ToString()).Selected = true;
                    fillgrilla();
            }
            else
            {
                lbl_resultado.Text = "No existe un paciente con este documento";
            }

            fillgrilla();
            gridPacienteContrato.Visible = true;
        }

        private String DiferenciaFechas(DateTime newdt, DateTime olddt)
        {
            Int32 anios;
            Int32 meses;
            Int32 dias;
            String str = "";

            anios = (newdt.Year - olddt.Year);
            meses = (newdt.Month - olddt.Month);
            dias = (newdt.Day - olddt.Day);


            if (meses < 0)
            {
                anios -= 1;
                meses += 12;
            }
            if (dias < 0)
            {
                meses -= 1;
                dias += DateTime.DaysInMonth(newdt.Year, newdt.Month);
            }

            if (anios > 0)
            {
                str = anios.ToString();
                umEdad.Text = "años";
            }
            if (anios <= 0 && meses > 0)
            {
                str = meses.ToString();
                umEdad.Text = "meses";
            }
            if (anios <= 0 && meses <= 0)
            {
                str = dias.ToString();
                umEdad.Text = "dias";
            }
            //if (anios < 0)
            //{
            //    return "Fecha Invalida";
            //}
            //if (anios > 0)
            //    str = str + anios.ToString() + " años ";
            //if (meses > 0)
            //    str = str + meses.ToString() + " meses ";
            //if (dias > 0)
            //    str = str + dias.ToString() + " dias ";

            return str;
        }


        private void fillgrilla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            gridPacienteContrato.DataSource = dt;

            gridPacienteContrato.DataBind();

        }


        private void fillgrillaDocumento()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            gridPacienteContrato.DataSource = dt;

            gridPacienteContrato.DataBind();

        }


        protected void gridPacienteContrato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridPacienteContrato, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridPacienteContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridPacienteContrato.Rows)
            {
                if (row.RowIndex == gridPacienteContrato.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click para seleccionar";
                }
            }
        }

        protected void ddl_tipousuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            Datos.consultar("SELECT * FROM TipoAfiliado ORDER BY Descripcion", "TipoAfiliado");
            ddl_tipoafiliado.DataSource = Datos.ds.Tables["TipoAfiliado"];
            ddl_tipoafiliado.DataTextField = "Descripcion";
            ddl_tipoafiliado.DataValueField = "Id";
            ddl_tipoafiliado.DataBind();
            ddl_tipoafiliado.Items.Insert(0, new ListItem("", "0"));

            if (ddl_tipousuario.SelectedItem.ToString() == "Contributivo")
            {
                ddl_tipoafiliado.Enabled = true;
            }
            else
            {
                ddl_tipoafiliado.ClearSelection();
                ddl_tipoafiliado.Enabled = false;
            }
        }

        protected void ddl_departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_municipio.Enabled = true;
            Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento.SelectedValue + "' ORDER BY Municipio", "Municipios");
            this.ddl_municipio.DataSource = Datos.ds.Tables["Municipios"];
            this.ddl_municipio.DataTextField = "Municipio";
            this.ddl_municipio.DataValueField = "CodMncpio";
            this.ddl_municipio.DataBind();
            ddl_municipio.Items.Insert(0, new ListItem("Seleccione Municipio"));
        }

        protected void ddl_entidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_contrato.Enabled = true;
            Datos.consultar("SELECT * FROM Contratos WHERE Entidad='"+this.ddl_entidad.SelectedValue.ToString()+"'", "Contratos");
            this.ddl_contrato.DataSource = Datos.ds.Tables["Contratos"];
            this.ddl_contrato.DataTextField = "Descripcion";
            this.ddl_contrato.DataValueField = "Codigo";
            this.ddl_contrato.DataBind();
            ddl_contrato.Items.Insert(0, new ListItem("Seleccione Contrato"));
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            if (txt_documento.Text == string.Empty)
            {
                lbl_mensajecontrato.Text = "Debe digitar un documento";
            }
            if (ddl_entidad.SelectedItem.ToString() == "Seleccione Entidad")
            {
                lbl_mensajecontrato.Text = "Seleccione la entidad";
                return;
            }

            if (ddl_contrato.SelectedItem.ToString() == "Seleccione Contrato")
            {
                lbl_mensajecontrato.Text = "Seleccione el contrato";
                return;
            }
            String sql = "INSERT INTO PacientesEntidadContrato(CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento) VALUES('" + this.ddl_entidad.SelectedValue + "','" + this.ddl_entidad.SelectedItem + "', '" + this.ddl_contrato.SelectedValue + "', '" + this.ddl_contrato.SelectedItem + "', '" + this.txt_documento.Text + "')";
            if (Datos.insertar(sql))
            {
                lbl_mensajecontrato.Text = "Error al asignar contrato al paciente, Verifique";
            }
            else
            {
                gridPacienteContrato.Visible = true;
                fillgrilla();
                ddl_entidad.ClearSelection();
                ddl_contrato.ClearSelection();
            }
        }

        protected void btn_eliminarcontrato_Click(object sender, EventArgs e)
        {
            String sql = "DELETE FROM PacientesEntidadContrato WHERE CodEntidad='" + this.gridPacienteContrato.SelectedRow.Cells[1].Text + "' AND CodContrato='" + this.gridPacienteContrato.SelectedRow.Cells[3].Text + "' AND Documento='" + this.txt_documento.Text + "' AND Id='" + this.gridPacienteContrato.SelectedRow.Cells[0].Text + "'";

            if (Datos.insertar(sql))
            {
                lbl_mensajecontrato.Text = "Error al eliminar contrato al paciente, Verifique";
            }
            else
            {
                fillgrilla();
                //ddl_eapb.ClearSelection();
                //ddl_contrato.ClearSelection();
            }
        }

        public bool VerificarPlanes(string Documento)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM PacientesEntidadContrato WHERE Documento='" + Documento + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("Documento", Documento);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ddl_tipodoc.SelectedItem.ToString() == "Seleccionar")
            {
                lbl_resultado.Text = "Seleccione un tipo de documento";
                return;
            }

            if (txt_numhistoria.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo número de historia se encuentra vacío";
                return;
            }

            //if (txt_numcarnet.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "El campo número de carnet se encuentra vacío";
            //    return;
            //}

            if (txt_nombre1.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo primer nombre se encuentra vacío";
                return;
            }

            //if (txt_nombre2.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "El campo segundo nombre se encuentra vacío";
            //    return;
            //}

            if (txt_apellido1.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo primer apellido se encuentra vacío";
                return;
            }

            //if (txt_apellido2.Text == string.Empty)
            //{
            //    lbl_resultado.Text = "El campo segundo apellido se encuentra vacío";
            //    return;
            //}

            if (ddl_tipousuario.SelectedItem.ToString() == "Seleccione Tipo de Usuario")
            {
                lbl_resultado.Text = "Seleccione un el tipo de usuario";
                return;
            }

            if (ddl_tipousuario.SelectedItem.ToString()=="Contributivo" && ddl_tipoafiliado.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un tipo de afiliado si el tipo de usuario es Contributivo";
                return;
            }

            if (ddl_sexo.SelectedItem.ToString() == "Seleccionar")
            {
                lbl_resultado.Text = "Seleccione el sexo";
                return;
            }

            if (txt_fechanaci.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo fecha de nacimiento se encuentra vacío";
                return;
            }

            if (ddl_departamento.SelectedItem.ToString() == "Seleccione Departamento")
            {
                lbl_resultado.Text = "Seleccione el departamento";
                return;
            }

            if (ddl_municipio.SelectedItem.ToString() == "Seleccione Municipio")
            {
                lbl_resultado.Text = "Seleccione el municipio";
                return;
            }

            if (ddl_zona.SelectedItem.ToString() == "Seleccione Zona")
            {
                lbl_resultado.Text = "Seleccione la zona residencial";
                return;
            }

            if (ddl_estrato.SelectedItem.ToString() == "Seleccione Estrato")
            {
                lbl_resultado.Text = "Seleccione el estrato";
                return;
            }

            if (txt_direccion.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo direccion se encuentra vacío";
                return;
            }

            if (txt_telefono.Text == string.Empty)
            {
                lbl_resultado.Text = "El campo teléfono se encuentra vacío";
                return;
            }

            if (ddl_estado.SelectedItem.ToString() == "Seleccionar")
            {
                lbl_resultado.Text = "Seleccione el estado";
                return;
            }

            if (!VerificarPlanes(txt_documento.Text))
            {
                lbl_resultado.Text = "El Paciente no tiene asignado un contrato";
                return;
            }

            try
            {
                DateTime fechanaci = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fechanaci.Text));
                txt_edad.Text = DiferenciaFechas(DateTime.Now, fechanaci);
                string sql = "UPDATE Pacientes SET TipoDocumento='" + this.ddl_tipodoc.SelectedValue.ToString() + "', NumHistoria='" + this.txt_numhistoria.Text + "', NumCarnet='" + this.txt_numcarnet.Text + "', Nombre1='" + this.txt_nombre1.Text + "', Nombre2='" + this.txt_nombre2.Text + "', Apellido1='" + this.txt_apellido1.Text + "', Apellido2='" + this.txt_apellido2.Text + "', TipoUsuario='" + this.ddl_tipousuario.SelectedItem + "', TipoAfiliado='" + this.ddl_tipoafiliado.SelectedItem + "', FechaNacimiento='" + fechanaci + "', Sexo='" + this.ddl_sexo.SelectedItem + "', Departamento='" + this.ddl_departamento.SelectedValue + "', Municipio='" + this.ddl_municipio.SelectedValue + "', Zona='" + this.ddl_zona.SelectedItem + "', Estrato='" + this.ddl_estrato.SelectedItem + "', Direccion='" + this.txt_direccion.Text + "', Telefono='" + this.txt_telefono.Text + "', Estado='" + this.ddl_estado.SelectedItem + "', Edad='"+this.txt_edad.Text+"', umEdad='"+this.umEdad.Text+"' WHERE Documento='" + this.txt_documento.Text + "'";
                if (Datos.insertar(sql))
                {
                    lbl_resultado.Text = "No se modificó la información";
                }
                else
                {
                    String sql2 = "DELETE FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'";
                    if (Datos.insertar(sql2))
                    {
                        lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                    }
                    else
                    {
                        foreach (GridViewRow row in gridPacienteContrato.Rows)
                        {
                            string cEntidad = row.Cells[1].Text;
                            string nEntidad = row.Cells[2].Text;
                            string cContrato = row.Cells[3].Text;
                            string nContrato = row.Cells[4].Text;
                            string documento = row.Cells[5].Text;
                            string sql5 = "INSERT INTO PacientesEntidadContrato(CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento) VALUES('" + cEntidad + "', '" + nEntidad + "', '" + cContrato + "', '" + nContrato + "', '" + documento + "')";
                            if (Datos.insertar(sql5))
                            {
                                lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                            }

                        }
                        Response.Redirect("ModificarPaciente.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_resultado.Text = ex.ToString();
            }
        }

        protected void btn_buscarNombre_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text == string.Empty)
            {
                lbl_resultado.Text = "Por favor ingrese un Nombre Paciente";
                return;
            }

            string sql = "SELECT * FROM Pacientes WHERE (Nombre1+' '+Nombre2+' '+Apellido1+' '+Apellido2)='" + this.txt_nombre.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                ddl_tipodoc.ClearSelection();
                ddl_tipousuario.ClearSelection();
                ddl_tipoafiliado.ClearSelection();
                ddl_sexo.ClearSelection();
                ddl_departamento.ClearSelection();
                ddl_municipio.ClearSelection();
                ddl_zona.ClearSelection();
                ddl_estrato.ClearSelection();
                ddl_estado.ClearSelection();
                lbl_resultado.Text = string.Empty;
                lbl_documento.Visible = true;
                txt_documento.Visible = true;
                lbl_numhistoria.Visible = true;
                txt_numhistoria.Visible = true;
                lbl_numcarnet.Visible = true;
                txt_numcarnet.Visible = true;
                lbl_nombre1.Visible = true;
                txt_nombre1.Visible = true;
                lbl_nombre2.Visible = true;
                txt_nombre2.Visible = true;
                lbl_apellido1.Visible = true;
                txt_apellido1.Visible = true;
                lbl_apellido2.Visible = true;
                txt_apellido2.Visible = true;
                lbl_tipoafiliado.Visible = true;
                lbl_Fechanaci.Visible = true;
                txt_fechanaci.Visible = true;
                lbl_direccion.Visible = true;
                txt_direccion.Visible = true;
                lbl_telefono.Visible = true;
                txt_telefono.Visible = true;
                txt_documento.Text = leer["Documento"].ToString();
                ddl_tipodoc.Items.FindByValue(leer["TipoDocumento"].ToString()).Selected = true;
                txt_numhistoria.Text = leer["NumHistoria"].ToString();
                txt_numcarnet.Text = leer["NumCarnet"].ToString();
                txt_nombre1.Text = leer["Nombre1"].ToString();
                txt_nombre2.Text = leer["Nombre2"].ToString();
                txt_apellido1.Text = leer["Apellido1"].ToString();
                txt_apellido2.Text = leer["Apellido2"].ToString();
                ddl_tipousuario.Items.FindByText(leer["TipoUsuario"].ToString()).Selected = true;
                ddl_sexo.Items.FindByText(leer["Sexo"].ToString()).Selected = true;
                DateTime fechaN = Convert.ToDateTime(leer["FechaNacimiento"].ToString());
                txt_fechanaci.Text = fechaN.ToString("dd/MM/yyyy");
                ddl_departamento.Items.FindByValue(leer["Departamento"].ToString()).Selected = true;
                ddl_zona.Items.FindByText(leer["Zona"].ToString()).Selected = true;
                ddl_estrato.Items.FindByText(leer["Estrato"].ToString()).Selected = true;
                txt_direccion.Text = leer["Direccion"].ToString();
                txt_telefono.Text = leer["Telefono"].ToString();
                ddl_estado.Items.FindByText(leer["Estado"].ToString()).Selected = true;
                if (ddl_tipousuario.SelectedItem.ToString() == "Contributivo")
                {
                    ddl_tipoafiliado.Enabled = true;
                    Datos.consultar("SELECT * FROM TipoAfiliado ORDER BY Descripcion", "TipoAfiliado");
                    ddl_tipoafiliado.DataSource = Datos.ds.Tables["TipoAfiliado"];
                    ddl_tipoafiliado.DataTextField = "Descripcion";
                    ddl_tipoafiliado.DataValueField = "Id";
                    ddl_tipoafiliado.DataBind();
                    ddl_tipoafiliado.Items.Insert(0, new ListItem("Seleccione Tipo de Afiliado"));
                    ddl_tipoafiliado.ClearSelection();
                    ddl_tipoafiliado.Items.FindByText(leer["TipoAfiliado"].ToString()).Selected = true;
                }
                else
                {
                    ddl_tipoafiliado.Enabled = false;
                    ddl_tipoafiliado.Items.Insert(0, new ListItem("", "0"));
                }
                Datos.consultar("SELECT * FROM Municipios WHERE CodDpto='" + this.ddl_departamento.SelectedValue + "' ORDER BY Municipio", "Municipios");
                this.ddl_municipio.DataSource = Datos.ds.Tables["Municipios"];
                this.ddl_municipio.DataTextField = "Municipio";
                this.ddl_municipio.DataValueField = "CodMncpio";
                this.ddl_municipio.DataBind();
                ddl_municipio.Items.Insert(0, new ListItem("Seleccione Municipio"));
                ddl_municipio.ClearSelection();
                ddl_municipio.Items.FindByValue(leer["Municipio"].ToString()).Selected = true;
                fillgrillaDocumento();
                gridPacienteContrato.Visible = true;

            }
            else
            {
                lbl_resultado.Text = "No existe un paciente con este documento";
            }

            fillgrillaDocumento();
            gridPacienteContrato.Visible = true;

        }

       
    }
}