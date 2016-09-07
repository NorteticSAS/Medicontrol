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
    public partial class WebForm7 : System.Web.UI.Page
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
            DateTime Hoy = DateTime.Now;
            txt_hora.Text = Hoy.AddHours(+2).ToShortTimeString();
            txt_fecha.Text = Hoy.ToString("dd/MM/yyyy");
            //txt_hora.Text = currentTime.ToLongTimeString();
        }

        [WebMethod]
        public static string[] BuscarDiagnostico(string prefix)
        {
            string sql = "SELECT DesProcedimiento FROM CIE10 WHERE DesProcedimiento like '%'+@SearchText+'%'";

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
                            customers.Add(string.Format("{0}", sdr["DesProcedimiento"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
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

        protected void btn_buscarPaciente_Click(object sender, EventArgs e)
        {
            string delete = "TRUNCATE TABLE Res3047_AT3_SERVICIOS";
            if (Datos.insertar(delete))
            {
                lbl_resultado.Text = "No se modificó la información, verifique";
                return;
            }
            else
            {
            }
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
                txt_tipodoc.Text = leer["TipoDocumento"].ToString();
                txt_cedula.Text = leer["Documento"].ToString();
                txt_nombre.Text = leer["Nombre1"].ToString() + " " + leer["Nombre2"].ToString() + " " + leer["Apellido1"].ToString() + " " + leer["Apellido2"].ToString();
                txt_sexo.Text = leer["Sexo"].ToString();
                fechanacimiento.Text = leer["FechaNacimiento"].ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(leer["FechaNacimiento"].ToString());
                txt_sexo.Text = leer["Sexo"].ToString();
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
                }
                if (count == 0)
                {
                    lbl_resultado.Text = "El paciente no tiene empresa ni contrato asignado";
                    return;
                }
            }
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

        protected void gridservicios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridservicios, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridservicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridservicios.Rows)
            {
                if (row.RowIndex == gridservicios.SelectedIndex)
                {
                    btn_eliminar.Visible = true;
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

        protected void btn_codigoCups_Click(object sender, EventArgs e)
        {
            if (txt_codigoCups.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un procedimiento";
                return;
            }
            string search = "SELECT * FROM Procedimientos WHERE CodProcedimiento='" + this.txt_codigoCups.Text + "' AND Estado='0'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comandos = new SqlCommand(search, conexion);
            conexion.Open();

            SqlDataReader leers = comandos.ExecuteReader();

            if (leers.Read() == true)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupCantidad();", true);
                this.lbl_mensajeCantidad.Text = "Por favor digite la cantidad a facturar";
            }
            else
            {
                lbl_resultado.Text = "El Proedimiento no existe o se encuenta inactivo por favor verifique";
                return;
            }
            conexion.Close();
        }

        protected void btn_buscarNombre_Click(object sender, EventArgs e)
        {
            string search = "SELECT * FROM Procedimientos WHERE DescProcedimiento='" + this.txt_procedimiento.Text + "' AND Estado='0'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comandos = new SqlCommand(search, conexion);
            conexion.Open();

            SqlDataReader leers = comandos.ExecuteReader();

            if (leers.Read() == true)
            {
                txt_codigoCups.Text = leers["CodProcedimiento"].ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupCantidad();", true);
                this.lbl_mensajeCantidad.Text = "Por favor digite la cantidad a facturar";
            }
            else
            {
                lbl_resultado.Text = "El Procedimiento no existe o se encuenta inactivo por favor verifique";
                return;
            }
            conexion.Close();
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

        private void fillgrillaServicios(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                //string sql2 = "SELECT Entidad.Codigo AS EntidadCodigo, Entidad.NombreEntidad AS EntidadNombre, Contratos.Codigo AS ContratoCodigo, Contratos.Descripcion AS ContratoDescripcion, Contratos.TipoContrato AS ContratoTipo FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PacientesEntidadContrato ON (Contratos.Codigo = PacientesEntidadContrato.CodContrato) AND (Contratos.Entidad = PacientesEntidadContrato.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = PacientesEntidadContrato.Documento WHERE Contratos.Estado = 'Activo' AND Pacientes.Documento= '" + this.txt_buscar.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            gridservicios.DataSource = dt;

            gridservicios.DataBind();

        }

        protected void btn_cantidadProced_Click(object sender, EventArgs e)
        {
            if (!Utilidades.isNumeric(txt_CantidadProcedimiento.Text))
            {
                lbl_resultado.Text = "Por favor digite una Cantidad Correcta";
                return;
            }
            if (Convert.ToDouble(txt_CantidadProcedimiento.Text) < 0)
            {
                lbl_resultado.Text = "Por favor digite una Cantidad Correcta";
                return;
            }

            

            string sql = "SELECT Procedimientos.CodigoCUPS AS CodCups, Procedimientos.CodProcedimiento AS CodProced, Procedimientos.DescProcedimiento AS DescProced, Tarifas.Valor AS ValorTarifa, Planes.CodPlan AS CodigoPlan, PlanesContratos.Porcentaje AS PorcentajePC, Entidad.Codigo AS CodigoEntidad, Contratos.Codigo AS CodContrato, Procedimientos.CodRips AS RipsProced, Procedimientos.Finalidad AS FinalidadProced, PlanesContratos.Capita AS CopagoPC, Procedimientos.TipoServicio AS TipoServProced, PlanesContratos.CodigoTarifario AS CodTarifaPC FROM Procedimientos INNER JOIN ((Planes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN PlanesContratos ON (Contratos.Codigo = PlanesContratos.CodigoContrato) AND (Contratos.Entidad = PlanesContratos.CodigoEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Planes.CodPlan = PlanesContratos.CodigoPlan) INNER JOIN Tarifas ON Planes.CodPlan = Tarifas.CodPlan) ON Procedimientos.CodProcedimiento = Tarifas.CodProcedimiento WHERE Procedimientos.CodProcedimiento= '" + this.txt_codigoCups.Text + "' AND Contratos.Codigo= '" + this.CodContrato.Text + "' AND Contratos.Entidad = '" + this.CodEntidad.Text + "'";

            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                lbl_resultado.Text = string.Empty;
                FacturaCodigoProcedimiento.Text = leer["CodProced"].ToString();            //Codigo del Procedimiento
                FacturaDescProcedimiento.Text = leer["DescProced"].ToString();
                FacturaCodigoCups.Text = leer["CodCups"].ToString();//Descripcion Procedimiento
                FacturaCantidad.Text = txt_CantidadProcedimiento.Text;
                string query = "INSERT INTO Res3047_AT3_SERVICIOS(CodCups, DesCups, Cantidad, CodSoat) VALUES('" + this.FacturaCodigoProcedimiento.Text + "', '" + this.FacturaDescProcedimiento.Text + "', '" + this.FacturaCantidad.Text + "', '" + this.FacturaCodigoCups.Text + "')";
                if (Datos.insertar(query))
                {
                    lbl_resultado.Text = "No se modificó la información, verifique";
                    return;
                }
                else
                {
                    string sqlgrid = "SELECT id, CodCups, DesCups, Cantidad, CodSoat FROM Res3047_AT3_SERVICIOS";
                    fillgrillaServicios(sqlgrid);
                }
            }
            conexion.Close();
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Res3047_AT3_SERVICIOS WHERE id='" + this.gridservicios.SelectedRow.Cells[4].Text + "'";
            if (Datos.insertar(query))
            {
                lbl_resultado.Text = "No se modificó la información, verifique";
                return;
            }
            else
            {
                string sqlgrid = "SELECT id, CodCups, DesCups, Cantidad, CodSoat FROM Res3047_AT3_SERVICIOS";
                fillgrillaServicios(sqlgrid);
            }
        }

        protected void btn_principal_Click(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(fechanacimiento.Text);
            int edadPaciente = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
            if (Modal_CodDiagP.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.Modal_CodDiagP.Text + "'";
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
                    if (SexoDx == "M" && txt_sexo.Text != "Masculino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodDiagP.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para la edad del Paciente";
                        Modal_CodDiagP.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && txt_sexo.Text != "Femenino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodDiagP.Text = string.Empty;
                        return;
                    }
                    Modal_DescDiagP.Text = leer["Nombre"].ToString();

                }
                else
                {
                    lbl_resultado.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }

            if (Modal_DescDiagP.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.Modal_DescDiagP.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && txt_sexo.Text != "Masculino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodDiagP.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para la edad del Paciente";
                        Modal_CodDiagP.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && txt_sexo.Text != "Femenino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodDiagP.Text = string.Empty;
                        return;
                    }
                    Modal_CodDiagP.Text = leerdx["Codigo"].ToString();
                    lbl_resultado.Text = string.Empty;

                }
                else
                {
                    lbl_resultado.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }
        }

        protected void btn_R1_Click(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(fechanacimiento.Text);
            int edadPaciente = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
            if (Modal_CodD1.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.Modal_CodD1.Text + "'";
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
                    if (SexoDx == "M" && txt_sexo.Text != "Masculino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodD1.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para la edad del Paciente";
                        Modal_CodD1.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && txt_sexo.Text != "Femenino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodD1.Text = string.Empty;
                        return;
                    }
                    Modal_DescD1.Text = leer["Nombre"].ToString();

                }
                else
                {
                    lbl_resultado.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }

            if (Modal_DescD1.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.Modal_DescD1.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && txt_sexo.Text != "Masculino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodD1.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para la edad del Paciente";
                        Modal_CodD1.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && txt_sexo.Text != "Femenino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodD1.Text = string.Empty;
                        return;
                    }
                    Modal_CodD1.Text = leerdx["Codigo"].ToString();
                    lbl_resultado.Text = string.Empty;

                }
                else
                {
                    lbl_resultado.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }
        }

        protected void btn_R2_Click(object sender, EventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(fechanacimiento.Text);
            int edadPaciente = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
            if (Modal_CodD2.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.Modal_CodD2.Text + "'";
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
                    if (SexoDx == "M" && txt_sexo.Text != "Masculino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodD2.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para la edad del Paciente";
                        Modal_CodD2.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && txt_sexo.Text != "Femenino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodD2.Text = string.Empty;
                        return;
                    }
                    Modal_DescD2.Text = leer["Nombre"].ToString();

                }
                else
                {
                    lbl_resultado.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }

            if (Modal_DescD2.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.Modal_DescD2.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && txt_sexo.Text != "Masculino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodD2.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para la edad del Paciente";
                        Modal_CodD2.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && txt_sexo.Text != "Femenino")
                    {
                        lbl_resultado.Text = "Dx a la salida no aplica para el sexo del paciente";
                        Modal_CodD2.Text = string.Empty;
                        return;
                    }
                    Modal_CodD2.Text = leerdx["Codigo"].ToString();
                    lbl_resultado.Text = string.Empty;

                }
                else
                {
                    lbl_resultado.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }
        }

        protected void chk_hospitalizacion_CheckedChanged(object sender, EventArgs e)
        {
            txt_servicio.ReadOnly = false;
            txt_cama.ReadOnly = false;
        }

        protected void chk_urgencias_CheckedChanged(object sender, EventArgs e)
        {
            txt_servicio.ReadOnly = true;
            txt_cama.ReadOnly = true;
        }

        protected void chk_consultaExt_CheckedChanged(object sender, EventArgs e)
        {
            txt_servicio.ReadOnly = true;
            txt_cama.ReadOnly = true;
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            
            if (txt_tipodoc.Text == "CC")
            {
                txt_tipodocvictimacc.Text = "X";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "CE")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "X";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "PA")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "X";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "TI")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "X";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "RC")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "X";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "AS")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "X";
                txt_tipodocvictimams.Text = "";
            }
            if (txt_tipodoc.Text == "MS")
            {
                txt_tipodocvictimacc.Text = "";
                txt_tipodocvictimace.Text = "";
                txt_tipodocvictimapa.Text = "";
                txt_tipodocvictimati.Text = "";
                txt_tipodocvictimarc.Text = "";
                txt_tipodocvictimaas.Text = "";
                txt_tipodocvictimams.Text = "X";
            }

            if (ddl_cobertura.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar una opción de cobertura";
                return;
            }
            if (ddl_cobertura.SelectedValue.ToString() == "1")
            {
                coberturaContributivo.Text = "X";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "2")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "X";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "3")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "X";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "4")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "X";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "5")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "X";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "6")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "6";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "7")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "7";
                coberturaotro.Text = "";

            }
            if (ddl_cobertura.SelectedValue.ToString() == "8")
            {
                coberturaContributivo.Text = "";
                coberturasubsidiototal.Text = "";
                coberturasubsidioparcial.Text = "";
                coberturapobreconsisben.Text = "";
                coberturapobresinsisben.Text = "";
                coberturadesplazados.Text = "";
                coberturaplanadicional.Text = "";
                coberturaotro.Text = "X";

            }
            if(ddl_origenAtencion.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "Debe seleccionar un origen de Atención";
                return;
            }
            if (ddl_origenAtencion.SelectedValue.ToString() == "1")
            {
                enfermedadgenaral.Text = "X";
                enfermedadprofesional.Text = "";
                accidentetrabajo.Text = "";
                accidentetransito.Text = "";
                eventocatastrofico.Text = "";
            }
            if (ddl_origenAtencion.SelectedValue.ToString() == "2")
            {
                enfermedadgenaral.Text = "";
                enfermedadprofesional.Text = "X";
                accidentetrabajo.Text = "";
                accidentetransito.Text = "";
                eventocatastrofico.Text = "";
            }
            if (ddl_origenAtencion.SelectedValue.ToString() == "3")
            {
                enfermedadgenaral.Text = "";
                enfermedadprofesional.Text = "";
                accidentetrabajo.Text = "X";
                accidentetransito.Text = "";
                eventocatastrofico.Text = "";
            }
            if (ddl_origenAtencion.SelectedValue.ToString() == "4")
            {
                enfermedadgenaral.Text = "";
                enfermedadprofesional.Text = "";
                accidentetrabajo.Text = "";
                accidentetransito.Text = "X";
                eventocatastrofico.Text = "";
            }
            if (ddl_origenAtencion.SelectedValue.ToString() == "5")
            {
                enfermedadgenaral.Text = "";
                enfermedadprofesional.Text = "";
                accidentetrabajo.Text = "";
                accidentetransito.Text = "";
                eventocatastrofico.Text = "X";
            }
            if(ddl_serviciossol.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "Debe seleccionar un tipo de servicio solicitado";
                return;
            }
            if (ddl_serviciossol.SelectedValue.ToString() == "1")
            {
                posterior.Text = "X";
                electivos.Text = "";
            }
            if (ddl_serviciossol.SelectedValue.ToString() == "2")
            {
                posterior.Text = "";
                electivos.Text = "X";
            }
            if(ddl_prioridad.SelectedValue.ToString()=="0")
            {
                lbl_resultado.Text = "Debe seleccionar una prioridad";
                return;
            }
            if(ddl_prioridad.SelectedValue.ToString()=="1")
            {
                prioritariasi.Text = "X";
                prioritariano.Text = "";
            }
            if (ddl_prioridad.SelectedValue.ToString() == "2")
            {
                prioritariasi.Text = "";
                prioritariano.Text = "X";
            }
            if(chk_consultaExt.Checked==true)
            {
                opcionconsultaext.Text = "X";
                opcionurgencias.Text = "";
                opcionhospitalizacion.Text = "";
            }
            if(chk_hospitalizacion.Checked==true)
            {
                opcionconsultaext.Text = "";
                opcionurgencias.Text = "";
                opcionhospitalizacion.Text = "X";
            }
            if(chk_urgencias.Checked==true)
            {
                opcionconsultaext.Text = "";
                opcionurgencias.Text = "X";
                opcionhospitalizacion.Text = "";
            }

            string consecutivo = "SELECT * FROM Consecutivos WHERE TipoCont='21'";
            SqlConnection ConexionConsec = new SqlConnection(ruta);
            SqlCommand comando6 = new SqlCommand(consecutivo, ConexionConsec);
            ConexionConsec.Open();
            SqlDataReader leer6 = comando6.ExecuteReader();
            if (leer6.Read() == true)
            {
                int numfac = Convert.ToInt32(leer6["NumActual"].ToString());
                numfac = numfac + 1;
                txt_numInforme.Text = numfac.ToString();
            }
            ConexionConsec.Close();
            DateTime fecha = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fecha.Text));

            string query = "SELECT COUNT (*) FROM Res3047_AT3_SASS WHERE NumInforme='"+this.txt_numInforme.Text+"'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando2 = new SqlCommand(query, conexion);
            conexion.Open();
            int count = Convert.ToInt32(comando2.ExecuteScalar());
            conexion.Close();

            if (count > 0)
            {
                string update = "UPDATE Res3047_AT3_SASS SET NumInforme='"+this.txt_numInforme.Text+"', documento='"+this.txt_cedula.Text+ "', fechainforme='"+fecha+ "', TDI_RC='"+this.txt_tipodocvictimarc.Text+ "', TDI_TI='"+this.txt_tipodocvictimati.Text+ "', TDI_CC='"+this.txt_tipodocvictimacc.Text+ "', TDI_CE='"+this.txt_tipodocvictimace.Text+ "', TDI_PA='"+this.txt_tipodocvictimapa.Text+ "', TDI_AS='"+this.txt_tipodocvictimaas.Text+ "', TDI_MS='"+this.txt_tipodocvictimams.Text+ "', CS_RC='"+this.coberturaContributivo.Text+ "', CS_RST='"+this.coberturasubsidiototal.Text+ "', CS_RSP='"+this.coberturasubsidioparcial.Text+ "', CS_CONSISBEN='"+this.coberturapobreconsisben.Text+ "', CS_SINSISBEN='"+this.coberturapobresinsisben.Text+ "', CS_DESPLAZADO='"+this.coberturadesplazados.Text+ "', CS_PAS='"+this.coberturaplanadicional.Text+ "', CS_OTRO='"+this.coberturaotro.Text+ "', OA_ENFERMEDADGRAL='"+this.enfermedadgenaral.Text+ "', OA_ENFERMEDADPROF='"+this.enfermedadprofesional.Text+ "', OA_ACCIDENTETRABAJO='"+this.accidentetrabajo.Text+ "', OA_ACCIDENTETRANSITO='"+this.accidentetransito.Text+ "', OA_ACCIDENTECATASTROFICO='"+this.eventocatastrofico.Text+"', "+
                                "PA_PRIORITARIA='"+this.prioritariasi.Text+ "', PA_NOPRIORITARIA='"+this.prioritariano.Text+ "', TSS_PAIU='"+this.posterior.Text+ "', TSS_SE='"+this.electivos.Text+ "', UPMS_CONSULTAEXTERNA='"+this.opcionconsultaext.Text+ "', UPMS_URGENCIAS='"+this.opcionurgencias.Text+ "', UPMS_HOSPITALIZACION='"+this.opcionhospitalizacion.Text+ "', UPMS_SERVICIO='"+this.txt_servicio.Text+ "', CAMA='"+this.txt_cama.Text+ "', GUIAMANEJO='"+this.txt_guia.Text+"', JUSTIFICACIONCLINICA='"+this.txt_justificacion.Text+ "', DXPPAL='"+this.Modal_CodDiagP.Text+ "', DXR1='"+this.Modal_CodD1.Text+ "', DXR2='"+this.Modal_CodD2.Text+ "', DES_DXPPAL='"+this.Modal_DescDiagP.Text.ToUpper()+ "', DES_DXR1='"+this.Modal_DescD1.Text.ToUpper()+ "', DES_DXR2='"+this.Modal_DescD2.Text.ToUpper()+ "', CodEntidad='"+this.CodEntidad.Text+ "', CodUsuario='"+this.CodigoSesion.Text+ "', CoberturaSalud='"+this.ddl_cobertura.SelectedItem+ "', OrigenAtencion='"+this.ddl_origenAtencion.SelectedItem+ "', TipoServicioSolicitado='"+this.ddl_serviciossol.SelectedItem+ "', PrioridadAtencion='"+this.ddl_prioridad.SelectedItem+ "' WHERE NumInforme='"+this.txt_numInforme.Text+"'";
                if (Datos.insertar(update))
                {
                    lbl_resultado.Text = "No se modificó la información, verifique";
                    return;
                }
                else
                {
                    foreach (GridViewRow Rips in gridservicios.Rows)
                    {
                        string codigo = HttpUtility.HtmlDecode(Rips.Cells[0].Text);
                        string descripcion = HttpUtility.HtmlDecode(Rips.Cells[1].Text);
                        string cantidad = HttpUtility.HtmlDecode(Rips.Cells[2].Text);
                        string codCups = HttpUtility.HtmlDecode(Rips.Cells[3].Text);
                        string numinforme = txt_numInforme.Text;

                        string delete = "DELETE FROM Res3047_AT3_SERVICIOS";
                        if (Datos.insertar(delete))
                        {
                            lbl_resultado.Text = "No se modificó la información, verifique";
                            return;
                        }
                        else
                        {
                            string insert = "INSERT INTO Res3047_AT3_SERVICIOS(NumInforme, CodCups, DesCups, Cantidad, CodSoat) VALUES('" + numinforme + "', '" + codigo + "', '" + descripcion + "', '" + cantidad + "', '" + codCups + "')";
                            if (Datos.insertar(insert))
                            {
                                lbl_resultado.Text = "No se modificó la información, verifique";
                                return;
                            }
                            else
                            {
                                lbl_resultado.Text = "Informe actualizado correctamente";
                                txt_cedula.Text = string.Empty;
                                txt_tipodoc.Text = string.Empty;
                                txt_nombre.Text = string.Empty;
                                txt_entidad.Text = string.Empty;
                                txt_contrato.Text = string.Empty;
                                txt_estrato.Text = string.Empty;
                                txt_edad.Text = string.Empty;
                                txt_sexo.Text = string.Empty;
                                chk_consultaExt.Checked = false;
                                chk_hospitalizacion.Checked = false;
                                chk_urgencias.Checked = false;
                                txt_servicio.Text = string.Empty;
                                txt_cama.Text = string.Empty;
                                txt_guia.Text = string.Empty;
                                txt_codigoCups.Text = string.Empty;
                                txt_procedimiento.Text = string.Empty;
                                txt_justificacion.Text = string.Empty;
                                Modal_CodD1.Text = string.Empty;
                                Modal_CodD2.Text = string.Empty;
                                Modal_CodDiagP.Text = string.Empty;
                                Modal_DescD1.Text = string.Empty;
                                Modal_DescD2.Text = string.Empty;
                                Modal_DescDiagP.Text = string.Empty;
                                ddl_cobertura.ClearSelection();
                                ddl_origenAtencion.ClearSelection();
                                ddl_prioridad.ClearSelection();
                                ddl_serviciossol.ClearSelection();

                            }
                        }
                    }
                        
                }
            }
            else
            {
                string insert = "INSERT INTO Res3047_AT3_SASS(NumInforme, documento, fechainforme, TDI_RC, TDI_TI, TDI_CC, TDI_CE, TDI_PA, TDI_AS, TDI_MS, CS_RC, CS_RST, CS_RSP, CS_CONSISBEN, CS_SINSISBEN, CS_DESPLAZADO, CS_PAS, CS_OTRO, OA_ENFERMEDADGRAL, OA_ENFERMEDADPROF, OA_ACCIDENTETRABAJO, OA_ACCIDENTETRANSITO, OA_ACCIDENTECATASTROFICO, PA_PRIORITARIA, PA_NOPRIORITARIA, TSS_PAIU, TSS_SE, UPMS_CONSULTAEXTERNA, UPMS_URGENCIAS, UPMS_HOSPITALIZACION, UPMS_SERVICIO, CAMA, GUIAMANEJO, JUSTIFICACIONCLINICA, DXPPAL, DXR1, DXR2, DES_DXPPAL, DES_DXR1, DES_DXR2, CodEntidad, CodUsuario, CoberturaSalud, OrigenAtencion, TipoServicioSolicitado, PrioridadAtencion) VALUES('" + this.txt_numInforme.Text + "', '" + this.txt_cedula.Text + "', '" + fecha + "', '" + this.txt_tipodocvictimarc.Text + "', '" + this.txt_tipodocvictimati.Text + "', '" + this.txt_tipodocvictimacc.Text + "', '" + this.txt_tipodocvictimace.Text + "', '" + this.txt_tipodocvictimapa.Text + "', '" + this.txt_tipodocvictimaas.Text + "', '" + this.txt_tipodocvictimams.Text + "', '" + this.coberturaContributivo.Text + "', '" + this.coberturasubsidiototal.Text + "', '" + this.coberturasubsidioparcial.Text + "', '" + this.coberturapobreconsisben.Text + "', '" + this.coberturapobresinsisben.Text + "', '" + this.coberturadesplazados.Text + "', '" + this.coberturaplanadicional.Text + "', '" + this.coberturaotro.Text + "', '" + this.enfermedadgenaral.Text + "', '" + this.enfermedadprofesional.Text + "', '" + this.accidentetrabajo.Text + "', '" + this.accidentetransito.Text + "', '" + this.eventocatastrofico.Text + "', '" + this.prioritariasi.Text + "', '" + this.prioritariano.Text + "', '" + this.posterior.Text + "', '" + this.electivos.Text + "', '" + this.opcionconsultaext.Text + "', '" + this.opcionurgencias.Text + "', '" + this.opcionhospitalizacion.Text + "', '" + this.txt_servicio.Text + "', '" + this.txt_cama.Text + "', '" + this.txt_guia.Text + "', '" + this.txt_justificacion.Text + "', '" + this.Modal_CodDiagP.Text + "', '" + this.Modal_CodD1.Text + "', '" + this.Modal_CodD2.Text + "', '" + this.Modal_DescDiagP.Text.ToUpper() + "', '" + this.Modal_DescD1.Text.ToUpper() + "', '" + this.Modal_DescD2.Text.ToUpper() + "', '" + this.CodEntidad.Text + "', '" + this.CodigoSesion.Text + "', '" + this.ddl_cobertura.SelectedItem + "', '" + this.ddl_origenAtencion.SelectedItem + "', '" + this.ddl_serviciossol.SelectedItem + "', '" + this.ddl_prioridad.SelectedItem + "')";
                if (Datos.insertar(insert))
                {
                    lbl_resultado.Text = "No se modificó la información, verifique";
                    return;
                }
                else
                {
                    foreach (GridViewRow Rips in gridservicios.Rows)
                    {
                        string codigo = HttpUtility.HtmlDecode(Rips.Cells[0].Text);
                        string descripcion = HttpUtility.HtmlDecode(Rips.Cells[1].Text);
                        string cantidad = HttpUtility.HtmlDecode(Rips.Cells[2].Text);
                        string codCups = HttpUtility.HtmlDecode(Rips.Cells[3].Text);
                        string numinforme = txt_numInforme.Text;

                        string delete = "DELETE FROM Res3047_AT3_SERVICIOS";
                        if (Datos.insertar(delete))
                        {
                            lbl_resultado.Text = "No se modificó la información, verifique";
                            return;
                        }
                        else
                        {
                            string insert2 = "INSERT INTO Res3047_AT3_SERVICIOS(NumInforme, CodCups, DesCups, Cantidad, CodSoat) VALUES('" + numinforme + "', '" + codigo + "', '" + descripcion + "', '" + cantidad + "', '" + codCups + "')";
                            if (Datos.insertar(insert2))
                            {
                                lbl_resultado.Text = "No se modificó la información, verifique";
                                return;
                            }
                            else
                            {
                                lbl_resultado.Text = "Informe actualizado correctamente";
                                txt_cedula.Text = string.Empty;
                                txt_tipodoc.Text = string.Empty;
                                txt_nombre.Text = string.Empty;
                                txt_entidad.Text = string.Empty;
                                txt_contrato.Text = string.Empty;
                                txt_estrato.Text = string.Empty;
                                txt_edad.Text = string.Empty;
                                txt_sexo.Text = string.Empty;
                                chk_consultaExt.Checked = false;
                                chk_hospitalizacion.Checked = false;
                                chk_urgencias.Checked = false;
                                txt_servicio.Text = string.Empty;
                                txt_cama.Text = string.Empty;
                                txt_guia.Text = string.Empty;
                                txt_codigoCups.Text = string.Empty;
                                txt_procedimiento.Text = string.Empty;
                                txt_justificacion.Text = string.Empty;
                                Modal_CodD1.Text = string.Empty;
                                Modal_CodD2.Text = string.Empty;
                                Modal_CodDiagP.Text = string.Empty;
                                Modal_DescD1.Text = string.Empty;
                                Modal_DescD2.Text = string.Empty;
                                Modal_DescDiagP.Text = string.Empty;
                                ddl_cobertura.ClearSelection();
                                ddl_origenAtencion.ClearSelection();
                                ddl_prioridad.ClearSelection();
                                ddl_serviciossol.ClearSelection();

                            }
                        }
                    }

                }
            }
        }

        protected void btn_imprimir_Click(object sender, EventArgs e)
        {

        }
    }
}