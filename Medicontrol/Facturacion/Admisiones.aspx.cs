using Helper;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["Login"] != null)
            {
                CodigoEnSesion.Text = Request.Cookies["Login"]["ID"].ToString();
                NombreSesion.Text = " " + Request.Cookies["Login"]["name"].ToString();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }


            DateTime currentTime = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);


            DateTime Hoy = DateTime.Now;
            txt_hora.Text = Hoy.AddHours(+2).ToShortTimeString();
            txt_fecha.Text = Hoy.ToString("dd/MM/yyyy");
            //txt_hora.Text = currentTime.ToLongTimeString();
            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM CausaExterna ORDER BY Descripcion", "CausaExterna");
                this.ddl_causas.DataSource = Datos.ds.Tables["CausaExterna"];
                this.ddl_causas.DataTextField = "Descripcion";
                this.ddl_causas.DataValueField = "Id";
                this.ddl_causas.DataBind();
                ddl_causas.Items.Insert(0, new ListItem("Seleccione causa externa"));

                Datos.consultar("SELECT * FROM Especialidades ORDER BY Nombre", "Especialidades");
                this.ddl_especialidad.DataSource = Datos.ds.Tables["Especialidades"];
                this.ddl_especialidad.DataTextField = "Nombre";
                this.ddl_especialidad.DataValueField = "Codigo";
                this.ddl_especialidad.DataBind();
                ddl_especialidad.Items.Insert(0, new ListItem("Seleccione causa especialidad"));


            }
        }

        protected void btn_buscarAdmision_Click(object sender, EventArgs e)
        {
            EstadoAdmision.Text = "99";
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un documento de paciente";
                return;

            }

            string sqlPaciente = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_buscar.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sqlPaciente, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txt_cedula.Text = leer["Documento"].ToString();
                txt_nombre.Text = leer["Nombre1"].ToString() + " " + leer["Nombre2"].ToString() + " " + leer["Apellido1"].ToString() + " " + leer["Apellido2"].ToString();
                txt_sexo.Text = leer["Sexo"].ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(leer["FechaNacimiento"].ToString());
                txt_sexo.Text = leer["Sexo"].ToString();
                txt_zona.Text = leer["Zona"].ToString();
                txt_estrato.Text = leer["Estrato"].ToString();
                FechaNacimientoPac.Text = fechaNacimiento.ToString("dd/MM/yyyy");
                DateTime fechanaci = Convert.ToDateTime(ViewHelper.ConvertToDate(FechaNacimientoPac.Text));
                txt_edad.Text = DiferenciaFechas(DateTime.Now, fechanaci);
                conexion.Close();


                //PARA BUSCAR LA EMPRESA Y CONTRATO DEL PACIENTE

                //SE BUSCA EL CONTRATO Y LA ENTIDAD ASIGNADA DEL PACIENTE
                string sql2 = "SELECT COUNT (*) FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado='Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";


                //***************************
                //string sql2 = "SELECT COUNT(*) FROM PacientesEntidadContrato WHERE Documento='" + this.txt_buscar.Text + "'";
                SqlCommand comando2 = new SqlCommand(sql2, conexion);
                conexion.Open();
                int count = Convert.ToInt32(comando2.ExecuteScalar());
                conexion.Close();

                if (count > 1)
                {
                    fillgrilla();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupContratos();", true);
                    this.lbl_contratos.Text = "Seleccione Contrato";
                }

                if (count == 1)
                {
                    string sql5 = "SELECT Entidad.Codigo AS CodigoEntidad, Entidad.NombreEntidad AS NombreEntidad, Contratos.Codigo AS ContratoNumero, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                    SqlCommand comando5 = new SqlCommand(sql5, conexion);
                    conexion.Open();
                    SqlDataReader leer2 = comando5.ExecuteReader();
                    if (leer2.Read() == true)
                    {
                        CodEntidad.Text = leer2["CodigoEntidad"].ToString();
                        txt_entidad.Text = leer2["NombreEntidad"].ToString();
                        CodContrato.Text = leer2["ContratoNumero"].ToString();
                        txt_contrato.Text = leer2["ContratoDescripcion"].ToString();
                        CodTipoContrato.Text = leer2["ContratoTipo"].ToString();

                    }
                    conexion.Close();
                    string admision = "SELECT * FROM Admisiones WHERE Estado <=1 AND DocumentoPaciente='" + this.txt_buscar.Text + "'";
                    SqlCommand comandoAd = new SqlCommand(admision, conexion);
                    conexion.Open();
                    SqlDataReader leerA = comandoAd.ExecuteReader();
                    if (leerA.Read() == true)
                    {
                        EstadoA.Text = leerA["Estado"].ToString();
                        int Estado = Convert.ToInt32(EstadoA.Text);
                        if (Estado == 0)//ABIERTA
                        {
                            EstadoAdmision.Text = "0";
                            DateTime FechaAdm = Convert.ToDateTime(leerA["FechaAdmision"].ToString());
                            txt_fecha.Text = FechaAdm.ToString("dd/MM/yyyy");
                            txt_hora.Text = leerA["HoraAdmision"].ToString();
                            txt_numAdmision.Text = leerA["NumeroAdmision"].ToString();
                            TipoAdmi.Text = leerA["TipoAdmision"].ToString();
                            ddl_TipoAdmisiones.ClearSelection();
                            ddl_TipoAdmisiones.Items.FindByValue(TipoAdmi.Text).Selected = true;
                            lbl_resultado.Text = "El paciente tiene una admision abierta";
                        }
                        if (Estado == 1)//ORDEN DE SALIDA
                        {
                            lbl_resultado.Text = "El paciente tiene una admision con orden de salida";
                            return;
                        }
                        if (Estado == 5)//HOSPITALIZADA
                        {
                            lbl_resultado.Text = "El paciente tiene una admision en hospitalización";
                            return;
                        }

                    }
                    conexion.Close();

                }
                if (count == 0)
                {
                    lbl_resultado.Text = "El Usuario no tiene empresa y contratos asignados o el contrato está anulado porque ya termino";
                    return;
                }
              
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupNoexiste();", true);
                this.lbl_mensajeUsuario.Text = "El usuario no existe. ¿Desea Crearlo?";
            }

            lbl_resultado.Text = string.Empty;

        }

        private void fillgrilla()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string sql2 = "SELECT Entidad.Codigo AS EntidadCodigo, Entidad.NombreEntidad AS EntidadNombre, Contratos.Codigo AS ContratoCodigo, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql2, cn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            gridPacienteContrato.DataSource = dt;

            gridPacienteContrato.DataBind();

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

            if (anios < 0)
            {
                return "Fecha Invalida";
            }
            if (anios > 0)
                str = str + anios.ToString() + " años ";
            if (meses > 0)
                str = str + meses.ToString() + " meses ";
            if (dias > 0)
                str = str + dias.ToString() + " dias ";

            return str;
        }

        protected void ddl_TipoAdmisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_TipoAdmisiones.SelectedValue.ToString() == "1")
            {
                ddl_viaingreso.ClearSelection();
                ddl_especialidad.ClearSelection();
                ddl_viaingreso.Enabled = true;
                txt_cie10.ReadOnly = false;
                txt_dximgreso.ReadOnly = false;
                btn_buscardx.Enabled = true;
                ddl_especialidad.Enabled = true;
                ddl_cama.Enabled = true;
            }
            else
            {
                ddl_viaingreso.Enabled = false;
                txt_cie10.ReadOnly = true;
                txt_dximgreso.ReadOnly = true;
                btn_buscardx.Enabled = false;
                ddl_especialidad.Enabled = false;
                ddl_cama.Enabled = false;
            }
        }

        [WebMethod]
        public static string[] BuscarDiagnostico(string prefix)
        {
            string sql = "SELECT Nombre FROM CIE10SEXO WHERE Nombre like '%'+@SearchText+'%'";

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
                            customers.Add(string.Format("{0}", sdr["Nombre"]));
                        }
                    }
                    conn.Close();
                }
            }
            
            return customers.ToArray();
        }


        protected void btn_buscardx_Click(object sender, EventArgs e)
        {
            string sqle = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_cedula.Text + "'";
            SqlConnection conexion1 = new SqlConnection(ruta);
            SqlCommand comandoedad = new SqlCommand(sqle, conexion1);
            conexion1.Open();

            SqlDataReader leere = comandoedad.ExecuteReader();

            if (leere.Read() == true)
            {
                fechaNacimiento.Text = leere["FechaNacimiento"].ToString();
                Sexopaciente.Text = leere["Sexo"].ToString();
                DateTime fecha = Convert.ToDateTime(fechaNacimiento.Text);
                int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
                Edad.Text = edad.ToString();
            }
            conexion1.Close();


            int edadPaciente = Convert.ToInt32(Edad.Text);

            if (txt_cie10.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.txt_cie10.Text + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comando = new SqlCommand(sql, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    string CodigoDX = leer["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leer["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leer["EdadFin"]);
                    string SexoDx = leer["Sexo"].ToString();
                    if (SexoDx == "M" && Sexopaciente.Text != "Masculino")
                    {
                        lbl_resultadoDx.Text = "Dx aplica para el sexo del paciente";
                        txt_cie10.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        lbl_resultadoDx.Text = "Dx no aplica para la edad del Paciente";
                        txt_cie10.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        lbl_resultadoDx.Text = "Dx no aplica para el sexo del paciente";
                        txt_cie10.Text = string.Empty;
                        return;
                    }
                    txt_dximgreso.Text = leer["Nombre"].ToString();
                    lbl_resultadoDx.Text = string.Empty;
                }
                else
                {
                    lbl_resultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }
            if (txt_dximgreso.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.txt_dximgreso.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    int edad = ViewHelper.GetAge(FechaNacimientoPac.Text);
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && Sexopaciente.Text != "Masculino")
                    {
                        lbl_resultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie10.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        lbl_resultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie10.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        lbl_resultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie10.Text = string.Empty;
                        return;
                    }
                    txt_cie10.Text = leerdx["Codigo"].ToString();
                    lbl_resultadoDx.Text = string.Empty;

                }
                else
                {
                    lbl_resultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }
            conexion1.Close();

        }

        protected void ddl_cama_SelectedIndexChanged(object sender, EventArgs e)
        {
            CodigoCama.Text = ddl_cama.SelectedValue.ToString();
        }

        protected void ddl_especialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CodEspecialidad.Text = ddl_especialidad.SelectedValue.ToString();
            Datos.consultar("SELECT * FROM Camas WHERE CodEsp='" + this.ddl_especialidad.SelectedValue + "' AND Estado='0' ORDER BY DesCama", "Camas");
            this.ddl_cama.DataSource = Datos.ds.Tables["Camas"];
            this.ddl_cama.DataTextField = "DesCama";
            this.ddl_cama.DataValueField = "CodCama";
            this.ddl_cama.DataBind();
            ddl_cama.Items.Insert(0, new ListItem("Seleccione cama", "0"));
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
                    SqlConnection conexion = new SqlConnection(ruta);
                    txt_entidad.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[1].Text);
                    txt_contrato.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[3].Text);
                    CodContrato.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[2].Text);
                    CodEntidad.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[0].Text);
                    CodTipoContrato.Text = HttpUtility.HtmlDecode(this.gridPacienteContrato.SelectedRow.Cells[4].Text);
                    string admision = "SELECT * FROM Admisiones WHERE Estado <=1 AND DocumentoPaciente='" + this.txt_buscar.Text + "'";
                    SqlCommand comandoAd = new SqlCommand(admision, conexion);
                    conexion.Open();
                    SqlDataReader leerA = comandoAd.ExecuteReader();
                    if (leerA.Read() == true)
                    {
                        EstadoA.Text = leerA["Estado"].ToString();
                        int Estado = Convert.ToInt32(EstadoA.Text);
                        if (Estado == 0)//ABIERTA
                        {
                            EstadoAdmision.Text = "0";
                            DateTime FechaAdm = Convert.ToDateTime(leerA["FechaAdmision"].ToString());
                            txt_fecha.Text = FechaAdm.ToString("dd/MM/yyyy");
                            txt_hora.Text = leerA["HoraAdmision"].ToString();
                            txt_numAdmision.Text = leerA["NumeroAdmision"].ToString();
                            TipoAdmi.Text = leerA["TipoAdmision"].ToString();
                            ddl_TipoAdmisiones.ClearSelection();
                            ddl_TipoAdmisiones.Items.FindByValue(TipoAdmi.Text).Selected = true;
                            lbl_resultado.Text = "El paciente tiene una admision abierta";
                        }
                        if (Estado == 1)//ORDEN DE SALIDA
                        {
                            lbl_resultado.Text = "El paciente tiene una admision con orden de salida";
                            return;
                        }
                        if (Estado == 5)//HOSPITALIZADA
                        {
                            lbl_resultado.Text = "El paciente tiene una admision en hospitalización";
                            return;
                        }

                    }
                    conexion.Close();

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

        protected void btn_errorsexo_Click(object sender, EventArgs e)
        {
            txt_cie10.Text = string.Empty;
            txt_dximgreso.Text = string.Empty;
        }

        public void CleanControl(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    CleanControl(control.Controls);
            }
        }


        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_fecha.Text == string.Empty)
            {
                lbl_resultado.Text = "Falta la fecha de ingreso";
                return;
            }
            if (txt_hora.Text == string.Empty)
            {
                lbl_resultado.Text = "Falta la hora de ingreso";
                return;
            }



            if (EstadoAdmision.Text == "99")
            {
                if (ddl_TipoAdmisiones.SelectedValue.ToString() == "0")//AMBULATORIO
                {
                    string consulta = "SELECT * FROM Consecutivos WHERE TipoCont='4'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        int NumAdmision = Convert.ToInt32(leer["NumActual"].ToString());
                        txt_numAdmision.Text = (NumAdmision + 1).ToString();
                    }
                    conexion.Close();
                }
                if (ddl_TipoAdmisiones.SelectedValue.ToString() == "1")//HOSPITALIZACION
                {
                    string consulta = "SELECT * FROM Consecutivos WHERE TipoCont='5'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        int NumAdmision = Convert.ToInt32(leer["NumActual"].ToString());
                        txt_numAdmision.Text = (NumAdmision + 1).ToString();
                    }
                    conexion.Close();
                }
                if (ddl_TipoAdmisiones.SelectedValue.ToString() == "2")//URGENCIAS
                {
                    string consulta = "SELECT * FROM Consecutivos WHERE TipoCont='3'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    if (leer.Read() == true)
                    {
                        int NumAdmision = Convert.ToInt32(leer["NumActual"].ToString());
                        txt_numAdmision.Text = (NumAdmision + 1).ToString();
                    }
                    conexion.Close();
                }
                //NumAdmision.Text = txt_numAdmision.Text;
            }
            if (EstadoAdmision.Text == "99")
            {

                if (txt_cedula.Text != string.Empty)
                {

                    if (ddl_TipoAdmisiones.SelectedValue.ToString() != "1")//SI ES AMBULATORIA O URGENCIAS
                    {
                        DateTime fechaAdmision = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fecha.Text));
                        string insertar = "INSERT INTO Admisiones(NumeroAdmision, TipoAdmision, DocumentoPaciente, FechaAdmision, HoraAdmision, CausaExternaAdmision, AutorizacionAdmision, NombreAcompanante, DireccionAcompanante, TelefonoAcompanante, CodigoEntidad, CodigoContrato, Estado, CodigoUsuario) VALUES('" + this.txt_numAdmision.Text + "', '" + this.ddl_TipoAdmisiones.SelectedValue + "', '" + this.txt_cedula.Text + "', '" + fechaAdmision + "', '" + this.txt_hora.Text + "', '" + this.ddl_causas.SelectedValue + "', '" + this.txt_autorizacion.Text + "', '" + this.txt_acompanante.Text + "', '" + this.txt_direccion.Text + "', '" + this.txt_telefono.Text + "', '" + this.CodEntidad.Text + "', '" + this.CodContrato.Text + "', '0', '" + this.CodigoEnSesion.Text + "')";
                        if (Datos.insertar(insertar))
                        {
                            lbl_resultado.Text = "No se modificó la información, verifique";
                        }
                        else
                        {
                            if (ddl_TipoAdmisiones.SelectedValue.ToString() == "0")//AMBULATORIO
                            {
                                ActConsecutivo.Text = "UPDATE Consecutivos SET NumActual='" + this.txt_numAdmision.Text + "' WHERE TipoCont='4'";
                            }
                            if (ddl_TipoAdmisiones.SelectedValue.ToString() == "2")//URGENCIAS
                            {
                                ActConsecutivo.Text = "UPDATE Consecutivos SET NumActual='" + this.txt_numAdmision.Text + "' WHERE TipoCont='3'";
                            }
                            if (Datos.insertar(ActConsecutivo.Text))
                            {
                                lbl_resultado.Text = "No se modificó la información, verifique";
                            }
                            else
                            {
                                if (ddl_TipoAdmisiones.SelectedValue.ToString() == "2" && CodTipoContrato.Text == "1")
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupAdverUrgencias();", true);
                                    mensajeUrgencias.Text = NombreSesion.Text + " no olvide notificar a la EPS la urgencia dentro de las 24 horas siguientes, de no hacerlo, la glosa que se reciba será de su responsabilidad. Atte. Gerente.";
                                }
                                //PREGUNTO SI IMPRIMIR LA HOJA DE URGENCIAS
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupHojaUrgencias();", true);
                                mensajeHojaUrgencias.Text = NombreSesion.Text + "¿Desea imprimir la hoja de urgencias?";
                            }
                        }
                    }
                    else//HOSPITALIZACION
                    {

                        string insertar = "INSERT INTO Admisiones(NumeroAdmision, TipoAdmision, CodigoEntidad, CodigoContrato, DocumentoPaciente, FechaAdmision, HoraAdmision, CausaExternaAdmision, AutorizacionAdmision, NombreAcompanante, DireccionAcompanante, TelefonoAcompanante, ViaIngresoHospital, DxIngresoHospital, EspecialidadHospital, CamaHospital, Estado, CodigoUsuario) VALUES('" + this.txt_numAdmision.Text + "', '" + ddl_TipoAdmisiones.SelectedValue + "', '" + this.CodEntidad.Text + "', '" + this.CodContrato.Text + "', '" + this.txt_cedula.Text + "', '" + this.txt_fecha.Text + "', '" + this.txt_hora.Text + "', '" + this.ddl_causas.SelectedValue + "', '" + this.txt_autorizacion.Text + "', '" + this.txt_acompanante.Text + "', '" + this.txt_direccion.Text + "', '" + this.txt_telefono.Text + "', '" + this.ddl_viaingreso.SelectedValue + "', '" + this.txt_cie10.Text + "', '" + this.ddl_especialidad.SelectedValue + "', '" + this.CodigoCama.Text + "', '0', '" + this.CodigoEnSesion.Text + "')";
                        if (Datos.insertar(insertar))
                        {
                            lbl_resultado.Text = "No se modificó la información, verifique";
                        }
                        else
                        {
                            ActConsecutivo.Text = "UPDATE Consecutivos SET NumActual='" + this.txt_numAdmision.Text + "' WHERE TipoCont='5'";
                            if (Datos.insertar(ActConsecutivo.Text))
                            {
                                lbl_resultado.Text = "No se modificó la información, verifique";
                            }
                            else
                            {
                                if (ddl_cama.SelectedValue.ToString() != "0")
                                {
                                    ActConsecutivo.Text = "UPDATE Camas SET Estado='" + this.txt_numAdmision.Text + "' WHERE CodCama='" + this.ddl_cama.SelectedValue + "'";
                                    if (Datos.insertar(ActConsecutivo.Text))
                                    {
                                        lbl_resultado.Text = "No se modificó la información, verifique";
                                    }
                                    else
                                    {
                                    }
                                }
                                //PREGUNTO SI IMPRIMIR LA HOJA DE URGENCIAS
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupHojaUrgencias();", true);
                                mensajeHojaUrgencias.Text = NombreSesion.Text + "¿Desea imprimir la hoja de urgencias?";
                            }
                        }

                    }


                }


            }

            else
            {
                if (ddl_TipoAdmisiones.SelectedValue.ToString() == "1")//SI EL ESTADO DE LA ADMISION ES URGENCIAS
                {
                    string consulta = "SELECT * FROM Admisiones WHERE NumeroAdmision='" + this.txt_numAdmision.Text + "' AND TipoAdmision='2'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    //ACTUALIZO EL ESTADO DE LA ADMISION
                    if (leer.Read() == true)
                    {
                        string ActAdmision = "UPDATE Admisiones SET TipoAdmision='1', AutorizacionAdmision='" + this.txt_autorizacion.Text + "', NombreAcompanante='" + this.txt_nombre.Text + "', DireccionAcompanante='" + this.txt_direccion.Text + "', TelefonoAcompanante='" + this.txt_telefono.Text + "', ViaIngresoHospital='" + this.ddl_viaingreso.SelectedValue + "', EspecialidadHospital='" + this.ddl_especialidad.SelectedValue + "', CamaHospital='" + this.ddl_cama.SelectedValue + "', Estado='5' WHERE NumeroAdmision='" + leer["NumeroAdmision"].ToString() + "'";
                        if (Datos.insertar(ActAdmision))
                        {
                            lbl_resultado.Text = "No se modificó la información, verifique";
                            return;
                        }
                        else
                        {
                            //ACTUALIZAR EL ESTADO DE LA CAMA ASIGNADA
                            if (ddl_cama.SelectedValue.ToString() != "0")
                            {
                                ActConsecutivo.Text = "UPDATE Camas SET Estado='" + this.txt_numAdmision.Text + "' WHERE CodCama='" + this.ddl_cama.SelectedValue + "'";
                                if (Datos.insertar(ActConsecutivo.Text))
                                {
                                    lbl_resultado.Text = "No se modificó la información, verifique";
                                    return;
                                }
                                else
                                {
                                }
                            }
                            conexion.Close();
                            //ACTUALIZAR ADMISION EN TALA HISTORICO PACIENTE
                            string ActHP = "SELECT * FROM HistoricoPte WHERE HnumAdmision='" + this.txt_numAdmision.Text + "' AND Htipoadmision='2'";

                            SqlCommand comandoP = new SqlCommand(ActHP, conexion);
                            conexion.Open();

                            SqlDataReader leerh = comandoP.ExecuteReader();

                            if (leerh.Read() == true)
                            {
                                string Actualizar = "UPDATE HistoricoPte SET Htipoadmision='1' WHERE HnumAdmision='" + leer["HnumAdmision"].ToString() + "' AND Htipodmision='" + leerh["Htipodmision"].ToString() + "'";
                                if (Datos.insertar(Actualizar))
                                {
                                    lbl_resultado.Text = "No se modificó la información, verifique";
                                    return;
                                }
                                else
                                {
                                }
                            }
                            conexion.Close();
                        }

                        //paciente hospitalizado listo
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupHospitalizado();", true);
                        lbl_mensajehospitalizado.Text = NombreSesion.Text + "Paciente hospitalizado con exito!.";
                        lbl_mensajeasignarProced.Text = "Desea asignar Procedimientos";

                    }
                }
                if (ddl_TipoAdmisiones.SelectedValue.ToString() == "0")
                {
                    string consulta = "SELECT * FROM Admisiones WHERE NumeroAdmision='" + this.txt_numAdmision.Text + "' AND TipoAdmision='2'";
                    SqlConnection conexion = new SqlConnection(ruta);
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    conexion.Open();

                    SqlDataReader leer = comando.ExecuteReader();

                    //ACTUALIZO EL ESTADO DE LA ADMISION
                    if (leer.Read() == true)
                    {
                        string ActAdmision = "UPDATE Admisiones SET TipoAdmision='0' WHERE NumeroAdmision='" + leer["NumeroAdmision"].ToString() + "'";
                        if (Datos.insertar(ActAdmision))
                        {
                            lbl_resultado.Text = "No se modificó la información, verifique";
                        }
                        else
                        {
                            //paciente hospitalizado listo
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupAmbulatorio;", true);
                            lbl_mensajeambulatorio.Text = NombreSesion.Text + "Paciente hospitalizado con exito!.";

                        }
                    }
                    conexion.Close();
                }

                else
                {
                    lbl_resultado.Text = "El usuario tiene una admision ABIERTA. No se puede generar otra admisión del mismo tipo";
                    return;
                }

            }
            lbl_resultado.Text = string.Empty;

        }

        protected void HojaUrgenciasSi_Click(object sender, EventArgs e)
        {
            if (ddl_TipoAdmisiones.SelectedValue.ToString() == "2")//URGENCIAS
            {
                string consulta = "SELECT Pacientes.Nombre1, Pacientes.Nombre2, Pacientes.Apellido1, Pacientes.Apellido2, Pacientes.TipoDocumento, Pacientes.Documento, Entidad.NombreEntidad, Contratos.TipoContrato, Estratos.Descripcion, Pacientes.Direccion, Pacientes.Telefono, Municipios.Municipio, Admisiones.NumeroAdmision, Admisiones.FechaAdmision, Pacientes.Edad, Pacientes.FechaNacimiento, Pacientes.Sexo, Admisiones.TipoAdmision, Admisiones.HoraAdmision, Admisiones.NombreAcompanante FROM (Municipios INNER JOIN (Estratos INNER JOIN Pacientes ON Estratos.Descripcion = Pacientes.Estrato) ON (Municipios.CodMncpio = Pacientes.Municipio) AND (Municipios.CodDpto = Pacientes.Departamento)) INNER JOIN (Entidad INNER JOIN (Admisiones INNER JOIN Contratos ON Admisiones.CodigoContrato=Contratos.Codigo) ON Entidad.Codigo = Admisiones.CodigoEntidad)  ON Pacientes.Documento = Admisiones.DocumentoPaciente WHERE Admisiones.NumeroAdmision = '" + this.txt_numAdmision.Text + "' AND Admisiones.TipoAdmision = '2'";
                ImprimirHojaUrgencia(consulta);
            }
            else
            {
                CleanControl(this.Controls);
                ddl_cama.ClearSelection();
                ddl_causas.ClearSelection();
                ddl_especialidad.ClearSelection();
                ddl_TipoAdmisiones.ClearSelection();
                ddl_viaingreso.ClearSelection();
            }

        }

        protected void HojaUrgenciasNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarProcedimientos.aspx");
        }

        private void ImprimirHojaUrgencia(string sql)
        {
            string id = "PDF"; // get this from another control on your page
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "HojaUrgenciasTemp.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                lbl_resultado.Text = "No se encontraron reportes por favor verifique con el administrador";
                return;
            }

            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, cn);

                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);

            }

            ReportDataSource rd = new ReportDataSource("DataSet2", dt);
            lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.19685in</MarginTop>" +
            "  <MarginLeft>0.19685in</MarginLeft>" +
            "  <MarginRight>0.19685in</MarginRight>" +
            "  <MarginBottom>0.19685in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            Response.Clear(); // we're going to override the default page response
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= HojaUrgencias" + txt_cedula.Text + "." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);

            Response.End();
        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            //PREGUNTO SI IMPRIMIR LA HOJA DE URGENCIAS
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupHojaUrgencias();", true);
            mensajeHojaUrgencias.Text = NombreSesion.Text + "¿Desea imprimir la hoja de urgencias?";
        }

        protected void btn_aceptarHosp_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarProcedimientos.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignarProcedimientos.aspx");
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            CleanControl(this.Controls);
            ddl_cama.ClearSelection();
            ddl_causas.ClearSelection();
            ddl_especialidad.ClearSelection();
            ddl_TipoAdmisiones.ClearSelection();
            ddl_viaingreso.ClearSelection();

        }

        protected void btn_Nuevo_Click(object sender, EventArgs e)
        {
            CleanControl(this.Controls);
            CleanControl(this.Controls);
            ddl_cama.ClearSelection();
            ddl_causas.ClearSelection();
            ddl_especialidad.ClearSelection();
            ddl_TipoAdmisiones.ClearSelection();
            ddl_viaingreso.ClearSelection();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoPaciente.aspx");
        }
    }
}