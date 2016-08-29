using Helper;
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
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DateTime fecha = DateTime.Now;
            DateTime currentTime = new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified);
            txt_hora.Text = fecha.AddHours(+2).ToShortTimeString();
        }

        protected void btn_buscarAdmision_Click1(object sender, EventArgs e)
        {
            if (txt_buscar.Text == string.Empty)
            {
                lbl_resultado.Text = string.Empty;
                return;
            }
            //string sqle = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_documento.Text + "'";
            //SqlConnection conexion = new SqlConnection(ruta);
            //SqlCommand comandoedad = new SqlCommand(sqle, conexion);
            //conexion.Open();

            //SqlDataReader leere = comandoedad.ExecuteReader();

            //if (leere.Read() == true)
            //{
            //    fechaNacimiento.Text = leere["FechaNacimiento"].ToString();
            //    Sexopaciente.Text = leere["Sexo"].ToString();
            //    DateTime fecha = Convert.ToDateTime(fechaNacimiento.Text);
            //    int edad = DateTime.Today.AddTicks(-fecha.Ticks).Year - 1;
            //    Edad.Text = edad.ToString();
            //}
            //conexion.Close();
            SqlConnection conexion = new SqlConnection(ruta);
            string query = "SELECT Admisiones.DocumentoPaciente AS Documento, Admisiones.NumeroAdmision AS NumAdmision, Admisiones.TipoAdmision AS TipoAdmision, Admisiones.FechaAdmision AS FechaAdmision, Admisiones.HoraAdmision AS HoraAdmision, Admisiones.Estado AS Estado, (Pacientes.Nombre1+' '+Pacientes.Nombre2+' '+Pacientes.Apellido1+' '+Pacientes.Apellido2) AS Nombre, Admisiones.CodigoEntidad AS CodEntidad, Admisiones.CodigoContrato AS CodContrato FROM Pacientes INNER JOIN Admisiones ON Pacientes.Documento = Admisiones.DocumentoPaciente WHERE Admisiones.DocumentoPaciente= '" + this.txt_buscar.Text + "' AND Admisiones.Estado IN (0,5)";
            SqlCommand comando = new SqlCommand(query, conexion);
            conexion.Open();

            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txt_documento.Text = leer["Documento"].ToString();
                txt_nombre.Text = leer["Nombre"].ToString();
                txt_numAdmision.Text = leer["NumAdmision"].ToString();
                CodigoTipoAdmision.Text = leer["TipoAdmision"].ToString();
                if (CodigoTipoAdmision.Text == "0") txt_tipoadmision.Text = "Ambulatoria";
                if (CodigoTipoAdmision.Text == "1") txt_tipoadmision.Text = "Hospitalaria";
                if (CodigoTipoAdmision.Text == "2") txt_tipoadmision.Text = "Urgencias";
                string CodigoEntidads = leer["CodEntidad"].ToString();
                string CodigoContratos = leer["CodContrato"].ToString();
                string fechaAdmision = leer["FechaAdmision"].ToString();
                DateTime fechaadmin = Convert.ToDateTime(leer["FechaAdmision"].ToString());
                txt_FechaAdmision.Text = fechaadmin.ToString("dd/MM/yyyy");
                txt_admision.Text = fechaadmin.ToString("dd/MM/yyyy");
                conexion.Close();

                //busca empresa y contratos
                string sql = "SELECT Entidad.Codigo AS EntidadCodigo, Entidad.NombreEntidad AS EntidadNombre, Contratos.Codigo AS CodigoContrato, Contratos.Descripcion AS DesContrato, Contratos.TipoContrato AS TipoContrato FROM Entidad INNER JOIN Contratos ON Entidad.Codigo = Contratos.Entidad WHERE Entidad.Codigo='" + CodigoEntidads + "' AND Contratos.Codigo= '" + CodigoContratos + "'";
                SqlCommand comandoC = new SqlCommand(sql, conexion);
                conexion.Open();

                SqlDataReader leerC = comandoC.ExecuteReader();

                if (leerC.Read() == true)
                {
                    CodigoEntidad.Text = leerC["EntidadCodigo"].ToString();
                    txt_entidad.Text = leerC["EntidadNombre"].ToString();
                    CodigoContrato.Text = leerC["CodigoContrato"].ToString();
                    txt_contrato.Text = leerC["DesContrato"].ToString();
                    CodigoTipoContrato.Text = leerC["TipoContrato"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "El paciente no tiene empresa y contato asignado";
                    return;
                }
                conexion.Close();
                string consulta = "SELECT NumeroAdmision, TipoAdmision, DocumentoPaciente, Estado FROM Admisiones WHERE DocumentoPaciente='" + this.txt_buscar.Text + "' AND Estado='1'";
                SqlCommand comand = new SqlCommand(consulta, conexion);
                conexion.Open();

                SqlDataReader leerA = comand.ExecuteReader();

                if (leerA.Read() == true)
                {
                    lbl_resultado.Text = "El paciente ya tiene orden de salida";
                    return;
                }

            }
            else
            {
                lbl_resultado.Text = "El paciente no tiene una admisión abierta";
                return;
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

        protected void btn_consultar1_Click(object sender, EventArgs e)
        {
            string sqle = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_documento.Text + "'";
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
                TipoDocumento.Text = leere["TipoDocumento"].ToString();
            }
            conexion1.Close();


            int edadPaciente = Convert.ToInt32(Edad.Text);
            if (txt_cie101.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.txt_cie101.Text + "'";
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
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie101.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie101.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie101.Text = string.Empty;
                        return;
                    }
                    txt_diagnostico1.Text = leer["Nombre"].ToString();

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }

            if (txt_diagnostico1.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.txt_diagnostico1.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    int edad = ViewHelper.GetAge(fechaNacimiento.Text);
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && Sexopaciente.Text != "Masculino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie101.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie101.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie101.Text = string.Empty;
                        return;
                    }
                    txt_cie101.Text = leerdx["Codigo"].ToString();
                    ResultadoDx.Text = string.Empty;

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }

        }

        protected void btn_consultar2_Click(object sender, EventArgs e)
        {

            string sqle = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_documento.Text + "'";
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
            if (txt_cie102.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.txt_cie102.Text + "'";
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
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie102.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie102.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie102.Text = string.Empty;
                        return;
                    }
                    txt_diagnostico2.Text = leer["Nombre"].ToString();

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }

            if (txt_diagnostico2.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.txt_diagnostico2.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    int edad = ViewHelper.GetAge(fechaNacimiento.Text);
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && Sexopaciente.Text != "Masculino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie102.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie102.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie102.Text = string.Empty;
                        return;
                    }
                    txt_cie102.Text = leerdx["Codigo"].ToString();
                    ResultadoDx.Text = string.Empty;

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }
            
        }

        protected void btn_consultar3_Click(object sender, EventArgs e)
        {

            string sqle = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_documento.Text + "'";
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
            if (txt_cie103.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.txt_cie103.Text + "'";
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
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie103.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie103.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie103.Text = string.Empty;
                        return;
                    }
                    txt_diagnostico3.Text = leer["Nombre"].ToString();

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }

            if (txt_diagnostico3.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.txt_diagnostico3.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    int edad = ViewHelper.GetAge(fechaNacimiento.Text);
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && Sexopaciente.Text != "Masculino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie103.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie103.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie103.Text = string.Empty;
                        return;
                    }
                    txt_cie103.Text = leerdx["Codigo"].ToString();
                    ResultadoDx.Text = string.Empty;

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string sqle = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_documento.Text + "'";
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

            if (txt_cie104.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.txt_cie104.Text + "'";
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
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie104.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie104.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie104.Text = string.Empty;
                        return;
                    }
                    txt_diagnostico4.Text = leer["Nombre"].ToString();

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }

            if (txt_diagnostico4.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.txt_diagnostico4.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    int edad = ViewHelper.GetAge(fechaNacimiento.Text);
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && Sexopaciente.Text != "Masculino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie104.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie104.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie104.Text = string.Empty;
                        return;
                    }
                    txt_cie104.Text = leerdx["Codigo"].ToString();
                    ResultadoDx.Text = string.Empty;

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string sqle = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_documento.Text + "'";
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
            if (txt_cie105.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.txt_cie105.Text + "'";
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
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie105.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie105.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie105.Text = string.Empty;
                        return;
                    }
                    txt_diagnostico5.Text = leer["Nombre"].ToString();

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }

            if (txt_diagnostico5.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.txt_diagnostico5.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    int edad = ViewHelper.GetAge(fechaNacimiento.Text);
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && Sexopaciente.Text != "Masculino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie105.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie105.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie105.Text = string.Empty;
                        return;
                    }
                    txt_cie105.Text = leerdx["Codigo"].ToString();
                    ResultadoDx.Text = string.Empty;

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sqle = "SELECT * FROM Pacientes WHERE Documento='" + this.txt_documento.Text + "'";
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
            if (txt_cie106.Text != string.Empty)
            {
                string sql = "SELECT * FROM CIE10SEXO WHERE Codigo='" + this.txt_cie106.Text + "'";
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
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie106.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie106.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie106.Text = string.Empty;
                        return;
                    }
                    txt_diagnostico6.Text = leer["Nombre"].ToString();

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
            }

            if (txt_diagnostico6.Text != string.Empty)
            {

                string sqlDX = "SELECT * FROM CIE10SEXO WHERE Nombre='" + this.txt_diagnostico6.Text + "'";
                SqlConnection conexionDX = new SqlConnection(ruta);
                SqlCommand comandodx = new SqlCommand(sqlDX, conexionDX);
                conexionDX.Open();

                SqlDataReader leerdx = comandodx.ExecuteReader();

                if (leerdx.Read() == true)
                {
                    int edad = ViewHelper.GetAge(fechaNacimiento.Text);
                    string CodigoDX = leerdx["Codigo"].ToString();
                    int EdadIni = Convert.ToInt32(leerdx["EdadInicio"]);
                    int EdadFin = Convert.ToInt32(leerdx["EdadFin"]);
                    string SexoDx = leerdx["Sexo"].ToString();
                    if (SexoDx == "M" && Sexopaciente.Text != "Masculino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie106.Text = string.Empty;
                        return;
                    }
                    if (edadPaciente < EdadIni && edadPaciente > EdadFin)
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para la edad del Paciente";
                        txt_cie106.Text = string.Empty;
                        return;
                    }

                    if (SexoDx == "F" && Sexopaciente.Text != "Femenino")
                    {
                        ResultadoDx.Text = "Dx a la salida no aplica para el sexo del paciente";
                        txt_cie106.Text = string.Empty;
                        return;
                    }
                    txt_cie106.Text = leerdx["Codigo"].ToString();
                    ResultadoDx.Text = string.Empty;

                }
                else
                {
                    ResultadoDx.Text = "No existe un diagnostico con ese codigo";
                    return;
                }
                conexionDX.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (txt_fecha.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar la fecha de egreso";
                return;
            }
            if (ddl_estado.SelectedValue.ToString() == string.Empty)
            {
                lbl_resultado.Text = "Debe seleccionar un estado para la salida del paciente";
                return;
            }
            if (txt_tipoadmision.Text == "2" && ddl_destinosalida.SelectedValue.ToString()==string.Empty)
            {
                lbl_resultado.Text = "No ha seleccionado el destino del usuario a la salida";
                return;
            }
            DateTime FechaAdmision = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_FechaAdmision.Text));
            DateTime FechaEgreso = Convert.ToDateTime(ViewHelper.ConvertToDate(txt_fecha.Text));
            // Difference in days, hours, and minutes.
            TimeSpan ts = FechaEgreso - FechaAdmision;

            // Difference in days.
            int Dias = ts.Days;


            if (Dias < 0)
            {
                lbl_resultado.Text = "La fecha de Egreso es menor a la fecha de ingreso";
                return;
            }

            if (CodigoTipoAdmision.Text == "1")
            {
                SqlConnection conexion = new SqlConnection(ruta);
                string query = "SELECT HnumAdmision, HTipoadmision, Hcodproced, Hcantidad From HistoricoPte WHERE HnumAdmision= '" + this.txt_numAdmision.Text + "' AND HTipoAdmision ='" + this.CodigoTipoAdmision.Text + "'";
                SqlCommand comando = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leer = comando.ExecuteReader();

                if (leer.Read() == true)
                {
                    int cantDias = 0;
                    cantDias = Convert.ToInt32(leer["Hcantidad"].ToString());
                    if (leer["Hcodproced"].ToString() == "38111")
                    {
                        if (Dias != cantDias)
                        {
                            lbl_resultado.Text = "No hay concordancia entre el número de días de estancia";
                        }
                    }
                    if (leer["Hcodproced"].ToString() == "38112")
                    {
                        if (Dias != cantDias)
                        {
                            lbl_resultado.Text = "No hay concordancia entre el número de días de estancia";
                        }
                    }
                    if (leer["Hcodproced"].ToString() == "38113")
                    {
                        if (Dias != cantDias)
                        {
                            lbl_resultado.Text = "No hay concordancia entre el número de días de estancia";
                        }
                    }
                    if (leer["Hcodproced"].ToString() == "38114")
                    {
                        if (Dias != cantDias)
                        {
                            lbl_resultado.Text = "No hay concordancia entre el número de días de estancia";
                        }
                    }
                }
            }

            if (txt_documento.Text != string.Empty)
            {


                string insertar = "UPDATE Admisiones SET FechaSalida='" + FechaEgreso + "', HoraSalida='" + this.txt_hora.Text + "', DxSalida='" + txt_cie101.Text + "', DxR1Salida='" + txt_cie102.Text + "', DxR2Salida='" + this.txt_cie103.Text + "', DxR3Salida='" + txt_cie104.Text + "', DxCompliHospital='" + txt_cie105.Text + "', DxCausaMuerte='" + txt_cie106.Text + "', DestinoUsuario='" + this.ddl_destinosalida.SelectedValue + "', EstadoSalida='" + ddl_estado.SelectedValue + "', Estado='1' WHERE NumeroAdmision='" + this.txt_numAdmision.Text + "' AND DocumentoPaciente='" + this.txt_documento.Text + "'";
                if (Datos.insertar(insertar))
                {
                    lbl_resultado.Text = "No se modificó la información, verifique";
                }
                else
                {
                    if (ddl_recien.SelectedValue.ToString() == "0")
                    {
                        lbl_resultado.Text = "No ha seleccionado recien nacido";
                        return;
                    }
                    if (ddl_recien.SelectedValue.ToString() == "1")
                    {
                        
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRecienNacidos();", true);
                        txt_RNTipodocumento.Text =
                        txt_RNDocumento.Text = txt_documento.Text;
                        txt_RNNombre.Text = txt_nombre.Text;
                        txt_RNEntidad.Text = txt_entidad.Text;
                        txt_RNContrato.Text = txt_contrato.Text;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupLiquidar();", true);
                    lbl_liquidar.Text = "Orden de salida guardada exitosamente. Desea liquidar la cuenta?";

                }
            }

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

        protected void btn_registrarRecienNacido_Click(object sender, EventArgs e)
        {
            if (txt_RNFechanacimiento.Text == string.Empty)
            {
                lbl_resultado.Text = "La fecha de Nacimiento del menor es obligatoria";
                return;
            }
            if (txt_RNHoraNacimiento.Text == string.Empty)
            {
                lbl_resultado.Text = "La hora de Nacimiento del menor es obligatoria";
                return;
            }
            if (txt_RNgestacional.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe ingresar la edad gestacional del menor";
                return;
            }
            if (ddl_controlprenatal.SelectedValue == "0")
            {
                lbl_resultado.Text = "Debe seleccionar un control prenatal";
                return;
            }
            if (ddl_RNSexo.SelectedValue == "0")
            {
                lbl_resultado.Text = "Debe seleccionar el sexo del menor";
                return;
            }
            if (txt_RNPeso.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar el peso del menor";
                return;
            }
            if (txt_RNDiagnostico.Text == string.Empty)
            {
                lbl_resultado.Text = "El diagnostico del menor es obligatorio";
                return;
            }
            txt_RNFechamuerte.Text = ViewHelper.ConvertToDate(txt_RNFechamuerte.Text);
            txt_RNFechanacimiento.Text = ViewHelper.ConvertToDate(txt_RNFechanacimiento.Text);
            string sql = "INSERT INTO RecienNacidos(MadreTipoID, MadreDocumento, RNFechaNacimiento, RNHoraNacimiento, RNEdadGestacional, RNControlGestacional, RNSexo, RNPeso, RNDiagnostico, RNDiagnosticoMuerte, RNFechaMuerte, RNHoraMuerte, CodigoEntidad, CodigoContrato, Estado) VALUES('" + this.txt_RNTipodocumento.Text + "', '" + this.txt_RNDocumento.Text + "', '" + this.txt_RNFechanacimiento.Text + "', '" + this.txt_RNHoraNacimiento.Text + "', '" + this.txt_RNgestacional.Text + "', '" + this.ddl_controlprenatal.SelectedItem + "', '" + this.ddl_RNSexo.SelectedItem + "', '" + this.txt_RNPeso.Text + "', '" + this.txt_RNDiagnostico.Text + "', '" + this.txt_RNDiagnosticoMuerte.Text + "', '" + this.txt_RNFechamuerte.Text + "', '" + this.txt_RNHoramuerte.Text + "', '" + this.txt_RNEntidad.Text + "', '" + this.txt_RNContrato.Text + "', 'Activo')";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se almacenó la información";
            }
            else
            {
                ddl_destinosalida.ClearSelection();
                ddl_estado.ClearSelection();
                ddl_recien.ClearSelection();

                CleanControl(this.Controls);
            }
        }

        protected void cerrarRECIEN_Click(object sender, EventArgs e)
        {
            ddl_destinosalida.ClearSelection();
            ddl_estado.ClearSelection();
            ddl_recien.ClearSelection();

            CleanControl(this.Controls);
        }

        protected void LiquidarNo_Click(object sender, EventArgs e)
        {
            CleanControl(this.Controls);
            ddl_controlprenatal.ClearSelection();
            ddl_destinosalida.ClearSelection();
            ddl_estado.ClearSelection();
            ddl_recien.ClearSelection();
            ddl_RNSexo.ClearSelection();
            
        }

        protected void btn_aCeptar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaFactura.aspx");
        }
    }
}