using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Administracion
{
    public partial class Formulario_web120 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                username.Text = " " + Request.Cookies["Login"]["name"].ToString();
                CodigoEnSesion.Text = Request.Cookies["Login"]["ID"].ToString();
                CargoUsuario.Text = Request.Cookies["Login"]["tipousuario"].ToString();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }

            lbl_resultado.Text = string.Empty;

            if (!IsPostBack)
            {
                string script = "$(document).ready(function () { $('[id*=btn_registrar]').click(); });";
                ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
                Datos.consultar("SELECT * FROM Entidad ORDER BY NombreEntidad", "Entidad");
                this.ddl_entidades.DataSource = Datos.ds.Tables["Entidad"];
                this.ddl_entidades.DataTextField = "NombreEntidad";
                this.ddl_entidades.DataValueField = "Codigo";
                this.ddl_entidades.DataBind();
                ddl_entidades.Items.Insert(0, new ListItem("Seleccione Entidad"));
            }
        }

        protected void ddl_entidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_contrato.ClearSelection();
            ddl_contrato.Enabled = true;
            Datos.consultar("SELECT * FROM Contratos WHERE Estado='Activo' AND Entidad='" + this.ddl_entidades.SelectedValue + "' ORDER BY Descripcion", "Contratos");
            ddl_contrato.DataSource = Datos.ds.Tables["Contratos"];
            ddl_contrato.DataTextField = "Descripcion";
            ddl_contrato.DataValueField = "NumeroContrato";
            ddl_contrato.DataBind();
            ddl_contrato.Items.Insert(0, new ListItem("Seleccione Contrato"));
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {

            if (ddl_entidades.SelectedItem.ToString() == "Seleccione Entidad")
            {
                lbl_resultado.Text = "Debe seleccionar una Entidad";
                return;
            }
            if (ddl_contrato.SelectedItem.ToString() == "Seleccione Contrato")
            {
                lbl_resultado.Text = "Debe seleccionar un Contrato";
                return;
            }
            if (CheckBorrar.Checked == true)
            {
                string query = "TRUNCATE TABLE Capitados";

                if (Datos.insertarCap(query))
                {
                    lbl_resultado.Text = "Se presento un error con la base Capitados";
                    return;
                }
                else
                {

                }
            }
            CodEntidad.Text = ddl_entidades.SelectedValue.ToString();
            CodContrato.Text = ddl_contrato.SelectedValue.ToString();
            Server.ScriptTimeout = 1200;//20 minutos
            if (IsPostBack && FileUploadToServer.HasFile)
            {
                if (Path.GetExtension(FileUploadToServer.FileName).Equals(".xlsx"))
                {
                    try
                    {
                        var excel = new ExcelPackage(FileUploadToServer.FileContent);
                        var dt = excel.ToDataTable();
                        var table = "Capitados";
                        using (var conn = new SqlConnection(ruta))
                        {
                            var bulkCopy = new SqlBulkCopy(conn);
                            bulkCopy.DestinationTableName = table;
                            conn.Open();
                            var schema = conn.GetSchema("Columns", new[] { null, null, table, null });
                            foreach (DataColumn sourceColumn in dt.Columns)
                            {
                                foreach (DataRow row in schema.Rows)
                                {
                                    if (string.Equals(sourceColumn.ColumnName, (string)row["COLUMN_NAME"], StringComparison.OrdinalIgnoreCase))
                                    {
                                        bulkCopy.ColumnMappings.Add(sourceColumn.ColumnName, (string)row["COLUMN_NAME"]);
                                        break;
                                    }
                                }

                            }
                            bulkCopy.WriteToServer(dt);
                        }
                        lbl_resultado.Text = "Se han insertado Correctamente a Capitados " + dt.Rows.Count + " Registros";
                        btn_cargar.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        lbl_resultado.Text = "El archivo no corresponde con la configuración requerida, por favor verifique";
                        return;
                    }
                }
                else
                {
                    lbl_resultado.Text = "La extensión del archivo es incorrecta, por favor verifique";
                    return;
                }
            }

            ////Get path from web.config file to upload
            //string FilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            //string filename = string.Empty;
            ////To check whether file is selected or not to uplaod
            //if (FileUploadToServer.HasFile)
            //{
            //    try
            //    {
            //        string[] allowdFile = { ".xls", ".xlsx" };
            //        //Here we are allowing only excel file so verifying selected file pdf or not
            //        string FileExt = System.IO.Path.GetExtension(FileUploadToServer.PostedFile.FileName);
            //        //Check whether selected file is valid extension or not
            //        bool isValidFile = allowdFile.Contains(FileExt);
            //        if (!isValidFile)
            //        {
            //            lbl_resultado.Text = "Por favor debe cargar un archivo Excel";
            //            return;
            //        }
            //        else
            //        {
            //            // Get size of uploaded file, here restricting size of file
            //            int FileSize = FileUploadToServer.PostedFile.ContentLength;
            //            if (FileSize <= 20971520)//20971520 byte = 20MB
            //            {
            //                //Get file name of selected file
            //                filename = Path.GetFileName(Server.MapPath(FileUploadToServer.FileName));

            //                //Save selected file into server location
            //                FileUploadToServer.SaveAs(Server.MapPath(FilePath) + filename);
            //                //Get file path
            //                string filePath = Server.MapPath(FilePath) + filename;
            //                //Open the connection with excel file based on excel version
            //                OleDbConnection con = null;
            //                if (FileExt == ".xls")
            //                {
            //                    con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0;");

            //                }
            //                else if (FileExt == ".xlsx")
            //                {
            //                    con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;");
            //                }
            //                con.Open();
            //                //Get the list of sheet available in excel sheet
            //                DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //                //Get first sheet name
            //                string getExcelSheetName = dt.Rows[0]["Table_Name"].ToString();
            //                //Select rows from first sheet in excel sheet and fill into dataset
            //                OleDbCommand ExcelCommand = new OleDbCommand(@"SELECT * FROM [" + getExcelSheetName + @"]", con);
            //                OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
            //                DataSet ExcelDataSet = new DataSet();
            //                ExcelAdapter.Fill(ExcelDataSet);
            //                con.Close();
            //                //Bind the dataset into gridview to display excel contents
            //                GridView1.DataSource = ExcelDataSet;
            //                GridView1.DataBind();
            //            }
            //            else
            //            {
            //                lbl_resultado.Text = "El archivo debe ser menor a 20Mb";
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        lbl_resultado.Text = "Error cargando el archivo. Posible causa: " + ex.Message;
            //    }
            //}
            //else
            //{
            //    lbl_resultado.Text = "Por favor seleccione un archivo para Cargar";
            //}
            ////System.Threading.Thread.Sleep(15000);
            
        }

        protected void btn_cargar_Click(object sender, EventArgs e)
        {
            if (ddl_entidades.SelectedItem.ToString() == "Seleccione Entidad")
            {
                lbl_resultado.Text = "Debe seleccionar una Entidad";
                return;
            }
            if (ddl_contrato.SelectedItem.ToString() == "Seleccione Contrato")
            {
                lbl_resultado.Text = "Debe seleccionar un Contrato";
                return;
            }
            //if (CheckBorrar.Checked == true)
            //{
            //    string query = "Delete FROM capitados WHERE CodEntidad = '" + this.ddl_entidades.SelectedValue + "' AND codcontrato = '" + this.ddl_contrato.SelectedValue + "'";

            //    if (Datos.insertar(query))
            //    {
            //        lbl_resultado.Text = "Se presento un error con la base Capitados";
            //        return;
            //    }
            //    else
            //    {

            //    }
            //}
            //}
            //    //INSERTO LOS DATOS EN CAPITADOS
            //    foreach (GridViewRow row in GridView1.Rows)
            //    {
            //        string consecutivo = HttpUtility.HtmlDecode(row.Cells[0].Text);
            //        string CodEntidad = ddl_entidades.SelectedValue.ToString();
            //        string tipoidcabflia = HttpUtility.HtmlDecode(row.Cells[1].Text);
            //        string numidcabflia = HttpUtility.HtmlDecode(row.Cells[2].Text);
            //        string tipoidafiliado = HttpUtility.HtmlDecode(row.Cells[3].Text);
            //        string numidafiliado = HttpUtility.HtmlDecode(row.Cells[4].Text);
            //        string apellido1 = HttpUtility.HtmlDecode(row.Cells[5].Text);
            //        string apellido2 = HttpUtility.HtmlDecode(row.Cells[6].Text);
            //        string nombre1 = HttpUtility.HtmlDecode(row.Cells[7].Text);
            //        string nombre2 = HttpUtility.HtmlDecode(row.Cells[8].Text);
            //        string fechanacimiento = string.Empty;
            //        if (row.Cells[9].Text != string.Empty)
            //        {
            //            fechanacimiento = HttpUtility.HtmlDecode(row.Cells[9].Text);
            //        }
            //        string sexo = HttpUtility.HtmlDecode(row.Cells[10].Text);
            //        string tipoafiliado = string.Empty;
            //        if (row.Cells[11].Text != string.Empty)
            //        {
            //            tipoafiliado = HttpUtility.HtmlDecode(row.Cells[11].Text);
            //        }
            //        string parentesco = HttpUtility.HtmlDecode(row.Cells[12].Text);
            //        string grupopob = HttpUtility.HtmlDecode(row.Cells[13].Text);
            //        string nivelsisben = string.Empty;
            //        if (row.Cells[14].Text != string.Empty)
            //        {
            //            nivelsisben = HttpUtility.HtmlDecode(row.Cells[14].Text);
            //        }
            //        string numficha = HttpUtility.HtmlDecode(row.Cells[15].Text);
            //        string codbeneficiario = HttpUtility.HtmlDecode(row.Cells[16].Text);
            //        string coddepartamento = HttpUtility.HtmlDecode(row.Cells[17].Text);
            //        string codmunicipio = HttpUtility.HtmlDecode(row.Cells[18].Text);
            //        string zonaAfiliado = HttpUtility.HtmlDecode(row.Cells[19].Text);
            //        string fechaafsgsss = string.Empty;
            //        if (row.Cells[20].Text != string.Empty)
            //        {
            //            fechaafsgsss = HttpUtility.HtmlDecode(row.Cells[20].Text);
            //        }
            //        string fechaafepss = string.Empty;
            //        if (row.Cells[21].Text != string.Empty)
            //        {
            //            fechaafepss = HttpUtility.HtmlDecode(row.Cells[21].Text);
            //        }
            //        string numcontratoente = string.Empty;
            //        if (row.Cells[22].Text != string.Empty)
            //        {
            //            numcontratoente = HttpUtility.HtmlDecode(row.Cells[22].Text);
            //        }
            //        string fechainicontrato = string.Empty;
            //        if (row.Cells[23].Text != string.Empty)
            //        {
            //            fechainicontrato = HttpUtility.HtmlDecode(row.Cells[23].Text);
            //        }
            //        string tipocontrato = string.Empty;
            //        if (row.Cells[24].Text != string.Empty)
            //        {
            //            tipocontrato = HttpUtility.HtmlDecode(row.Cells[24].Text);
            //        }
            //        string etnia = string.Empty;
            //        if (row.Cells[25].Text != string.Empty)
            //        {
            //            etnia = HttpUtility.HtmlDecode(row.Cells[25].Text);
            //        }
            //        string modalidadsubsidio = string.Empty;
            //        if (row.Cells[26].Text != string.Empty)
            //        {
            //            modalidadsubsidio = HttpUtility.HtmlDecode(row.Cells[26].Text);
            //        }
            //        string codcontrato = ddl_contrato.SelectedValue.ToString();
            //        string codusuario = CodigoEnSesion.Text;
            //        string observacion = string.Empty;
            //        if (row.Cells[30].Text != string.Empty)
            //        {
            //            observacion = HttpUtility.HtmlDecode(row.Cells[30].Text);
            //        }

            //        string sqlCapitada = "INSERT INTO Capitados(consecutivo, TipoIdCabFlia, NumIdCabFlia, TipoIdAfil, NumIdAfil, apellido1, apellido2, nombre1, nombre2, FechaNac, sexo, TipoAfil, ParentescoCabFlia, GrupoPob, NivelSISBEN, " +
            //                             " NumFicha, CondicionBenef, CodDpto, CodMncpio, ZonaAfil, FechaAfilSGSSS, FechaAfilEPSS, NumContratoEnte, FechaIniContrato, TipoContrato, Etnia, ModalidadSubsidio, CodEntidad, codcontrato, CodUsuario, Observacion) " +
            //                             "VALUES('" + consecutivo + "', '" + tipoidcabflia + "', '" + numidcabflia + "', '" + tipoidafiliado + "', '" + numidafiliado + "', '" + apellido1 + "', '" + apellido2 + "', '" + nombre1 + "', '" + nombre2 + "', '" + fechanacimiento + "', '" + sexo + "', " +
            //                             "'" + tipoafiliado + "', '" + parentesco + "', '" + grupopob + "', '" + nivelsisben + "', '" + numficha + "', '" + codbeneficiario + "', '" + coddepartamento + "', '" + codmunicipio + "', '" + zonaAfiliado + "', '" + fechaafsgsss + "', '" + fechaafepss + "', " +
            //                             "'" + numcontratoente + "', '" + fechainicontrato + "', '" + tipocontrato + "', '" + etnia + "', '" + modalidadsubsidio + "', '" + CodEntidad + "', '" + codcontrato + "', '" + codusuario + "', '" + observacion + "')";
            //        if (Datos.insertar(sqlCapitada))
            //        {
            //            lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
            //            return;
            //        }
            //        else
            //        {
            //        }

            //    }

            //   //TRAERME LOS DATOS INSERTADOS EN CAPITADOS
            //    string QueryCap = "SELECT * FROM Capitados WHERE CodEntidad='" + this.ddl_entidades.SelectedValue + "' AND CodContrato='" + this.ddl_contrato.SelectedValue + "'";
            //    SqlConnection conexionCapitados = new SqlConnection(ruta);
            //    SqlCommand comando = new SqlCommand(QueryCap, conexionCapitados);
            //    conexionCapitados.Open();
            //    SqlDataReader leerCap = comando.ExecuteReader();

            //    while (leerCap.Read())
            //    {
            //        string RPacientes = "SELECT * FROM Pacientes WHERE Documento='" + leerCap["NumIdAfil"].ToString() + "'";
            //        SqlConnection ConexionPacientes = new SqlConnection(ruta);
            //        SqlCommand comando3 = new SqlCommand(RPacientes, ConexionPacientes);
            //        ConexionPacientes.Open();
            //        SqlDataReader leer3 = comando3.ExecuteReader();

            //        if (leer3.Read() == true)
            //        {
            //        }
            //        else
            //        {
            //            string zonaPaciente = string.Empty;
            //            if (leerCap["ZonaAfil"].ToString() == "U" || leerCap["ZonaAfil"].ToString() == "u")
            //            {
            //                zonaPaciente = "Urbano";
            //            }
            //            if (leerCap["ZonaAfil"].ToString() == "R" || leerCap["ZonaAfil"].ToString() == "r")
            //            {
            //                zonaPaciente = "Rural";
            //            }
            //            string TipodeAfiliado = string.Empty;
            //            //if(leerCap["TipoAfil"].ToString()=="1")
            //            //{
            //            //    TipodeAfiliado="Cotizante";
            //            //}
            //            //if (leerCap["TipoAfil"].ToString() == "2")
            //            //{
            //            //    TipodeAfiliado="Beneficiario";
            //            //}
            //            string estrato = string.Empty;
            //            if (leerCap["NivelSISBEN"].ToString() == "1") estrato = "Nivel I";
            //            if (leerCap["NivelSISBEN"].ToString() == "2") estrato = "Nivel II";
            //            if (leerCap["NivelSISBEN"].ToString() == "3") estrato = "Nivel III";
            //            if (leerCap["NivelSISBEN"].ToString() == "4") estrato = "Estrato I";
            //            if (leerCap["NivelSISBEN"].ToString() == "5") estrato = "Estrato II";
            //            if (leerCap["NivelSISBEN"].ToString() == "6") estrato = "Estrato III";
            //            if (leerCap["NivelSISBEN"].ToString() == "7") estrato = "Particular";
            //            if (leerCap["NivelSISBEN"].ToString() == "8") estrato = "No Aplica";
            //            string sexopac = string.Empty;
            //            if (leerCap["sexo"].ToString() == "M") sexopac = "Masculino";
            //            if (leerCap["sexo"].ToString() == "F") sexopac = "Femenino";
            //            string InsertPac = "INSERT INTO Pacientes(Documento, TipoDocumento, TipoUsuario, Apellido1, Apellido2, Nombre1, Nombre2, FechaNacimiento, Sexo, Usuario, Departamento, Municipio, Zona, NumHistoria, Estrato, Edad, Estado, TipoAfiliado, NumCarnet, Telefono, Direccion) VALUES('" + leerCap["NumIdAfil"].ToString() + "', '" + leerCap["TipoIdAfil"].ToString() + "', 'Subsidiado', '" + leerCap["apellido1"].ToString() + "', '" + leerCap["apellido2"].ToString() + "', '" + leerCap["nombre1"].ToString() + "', '" + leerCap["nombre2"].ToString() + "', '" + leerCap["FechaNac"].ToString() + "', '" + sexopac + "', '" + this.CodigoEnSesion.Text + "', '" + leerCap["CodDpto"].ToString() + "', '" + leerCap["CodMncpio"].ToString() + "', '" + zonaPaciente + "', '" + leerCap["NumIdAfil"].ToString() + "', '" + estrato + "', '0', 'Activo', '" + TipodeAfiliado + "', '0', ' ', ' ')";
            //            if (Datos.insertar(InsertPac))
            //            {
            //                lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
            //            }
            //            else
            //            {

            //            }
            //        }
            //        ConexionPacientes.Close();
            //    }
            //    conexionCapitados.Close();

            //    if (CheckBorrar.Checked == true)
            //    {

            //        string querypec = "Delete FROM PacientesEntidadContrato WHERE CodEntidad = '" + this.ddl_entidades.SelectedValue + "' AND codcontrato = '" + this.ddl_contrato.SelectedValue + "'";

            //        if (Datos.insertar(querypec))
            //        {
            //            lbl_resultado.Text = "Se presento un error con la base Capitados";
            //            return;
            //        }
            //        else
            //        {

            //        }
            //    }
            //    //TRAERME LOS DATOS INSERTADOS EN CAPITADOS
            //    string QueryCap2 = "SELECT * FROM Capitados WHERE CodEntidad='" + this.ddl_entidades.SelectedValue + "' AND CodContrato='" + this.ddl_contrato.SelectedValue + "'";
            //    SqlConnection conexionCapitados2 = new SqlConnection(ruta);
            //    SqlCommand comando2 = new SqlCommand(QueryCap2, conexionCapitados2);
            //    conexionCapitados2.Open();
            //    SqlDataReader leerCap2 = comando2.ExecuteReader();

            //    while (leerCap2.Read())
            //    {
            //        string RPEC = "SELECT * FROM PacientesEntidadContrato WHERE Documento='" + leerCap2["NumIdAfil"].ToString() + "' AND CodEntidad='" + ddl_entidades.SelectedValue + "' AND CodContrato='" + this.ddl_contrato.SelectedValue + "'";
            //        SqlConnection ConexionPEC = new SqlConnection(ruta);
            //        SqlCommand comandoPE = new SqlCommand(RPEC, ConexionPEC);
            //        ConexionPEC.Open();
            //        SqlDataReader leerPE = comandoPE.ExecuteReader();

            //        if (leerPE.Read() == true)
            //        {
            //        }
            //        else
            //        {
            //            string InsertPec = "INSERT INTO PacientesEntidadContrato(CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento) VALUES('" + this.ddl_entidades.SelectedValue + "', '" + this.ddl_entidades.SelectedItem + "', '" + this.ddl_contrato.SelectedValue + "', '" + this.ddl_contrato.SelectedItem + "', '" + leerCap2["NumIdAfil"].ToString() + "')";
            //            if (Datos.insertar(InsertPec))
            //            {
            //                lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
            //            }
            //            else
            //            {
            //                GridView1.DataSource = null;
            //                GridView1.DataBind();
            //                lbl_resultado.Text = "El archivo se ha cargado con éxito";
            //            }
            //        }
            //        ConexionPEC.Close();
            //    }

            //    conexionCapitados2.Close();
            //}

            //TRAERME LOS DATOS INSERTADOS EN CAPITADOS
            string QueryCap = "SELECT * FROM Capitados";
            SqlConnection conexionCapitados = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(QueryCap, conexionCapitados);
            comando.CommandTimeout = 1800; // 20 min...
            conexionCapitados.Open();
            SqlDataReader leerCap = comando.ExecuteReader();

            while (leerCap.Read())
            {
                string RPacientes = "SELECT * FROM Pacientes WHERE Documento='" + leerCap["NumIdAfil"].ToString() + "'";
                SqlConnection ConexionPacientes = new SqlConnection(ruta);
                SqlCommand comando3 = new SqlCommand(RPacientes, ConexionPacientes);
                comando3.CommandTimeout = 1800; // 20 min...
                ConexionPacientes.Open();
                SqlDataReader leer3 = comando3.ExecuteReader();

                if (leer3.Read() == true)
                {
                }
                else
                {
                    string zonaPaciente = string.Empty;
                    if (leerCap["ZonaAfil"].ToString() == "U" || leerCap["ZonaAfil"].ToString() == "u")
                    {
                        zonaPaciente = "Urbano";
                    }
                    if (leerCap["ZonaAfil"].ToString() == "R" || leerCap["ZonaAfil"].ToString() == "r")
                    {
                        zonaPaciente = "Rural";
                    }
                    string TipodeAfiliado = string.Empty;
                    //if(leerCap["TipoAfil"].ToString()=="1")
                    //{
                    //    TipodeAfiliado="Cotizante";
                    //}
                    //if (leerCap["TipoAfil"].ToString() == "2")
                    //{
                    //    TipodeAfiliado="Beneficiario";
                    //}
                    string estrato = string.Empty;
                    if (leerCap["NivelSISBEN"].ToString() == "1") estrato = "Nivel I";
                    if (leerCap["NivelSISBEN"].ToString() == "2") estrato = "Nivel II";
                    if (leerCap["NivelSISBEN"].ToString() == "3") estrato = "Nivel III";
                    if (leerCap["NivelSISBEN"].ToString() == "4") estrato = "Estrato I";
                    if (leerCap["NivelSISBEN"].ToString() == "5") estrato = "Estrato II";
                    if (leerCap["NivelSISBEN"].ToString() == "6") estrato = "Estrato III";
                    if (leerCap["NivelSISBEN"].ToString() == "7") estrato = "Particular";
                    if (leerCap["NivelSISBEN"].ToString() == "8") estrato = "No Aplica";
                    string sexopac = string.Empty;
                    if (leerCap["sexo"].ToString() == "M") sexopac = "Masculino";
                    if (leerCap["sexo"].ToString() == "F") sexopac = "Femenino";
                    string InsertPac = "INSERT INTO Pacientes(Documento, TipoDocumento, TipoUsuario, Apellido1, Apellido2, Nombre1, Nombre2, FechaNacimiento, Sexo, Usuario, Departamento, Municipio, Zona, NumHistoria, Estrato, Edad, Estado, TipoAfiliado, NumCarnet, Telefono, Direccion) VALUES('" + leerCap["NumIdAfil"].ToString() + "', '" + leerCap["TipoIdAfil"].ToString() + "', 'Subsidiado', '" + leerCap["apellido1"].ToString() + "', '" + leerCap["apellido2"].ToString() + "', '" + leerCap["nombre1"].ToString() + "', '" + leerCap["nombre2"].ToString() + "', '" + leerCap["FechaNac"].ToString() + "', '" + sexopac + "', '" + this.CodigoEnSesion.Text + "', '" + leerCap["CodDpto"].ToString() + "', '" + leerCap["CodMncpio"].ToString() + "', '" + zonaPaciente + "', '" + leerCap["NumIdAfil"].ToString() + "', '" + estrato + "', '0', 'Activo', '" + TipodeAfiliado + "', '0', ' ', ' ')";
                    if (Datos.insertarCap(InsertPac))
                    {
                        lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                    }
                    else
                    {

                    }
                }
                ConexionPacientes.Close();
            }
            conexionCapitados.Close();

                if (CheckBorrar.Checked == true)
                {

                    string querypec = "Delete FROM PacientesEntidadContrato WHERE CodEntidad = '" + this.ddl_entidades.SelectedValue + "' AND codcontrato = '" + this.ddl_contrato.SelectedValue + "'";

                    if (Datos.insertarCap(querypec))
                    {
                        lbl_resultado.Text = "Se presento un error con la base Capitados";
                        return;
                    }
                    else
                    {

                    }
                }
                //TRAERME LOS DATOS INSERTADOS EN CAPITADOS
                string QueryCap2 = "SELECT * FROM Capitados";
                SqlConnection conexionCapitados2 = new SqlConnection(ruta);
                SqlCommand comando2 = new SqlCommand(QueryCap2, conexionCapitados2);
                comando2.CommandTimeout = 1800; // 20 min...
                conexionCapitados2.Open();
                SqlDataReader leerCap2 = comando2.ExecuteReader();

                while (leerCap2.Read())
                {
                    string RPEC = "SELECT * FROM PacientesEntidadContrato WHERE Documento='" + leerCap2["NumIdAfil"].ToString() + "' AND CodEntidad='" + ddl_entidades.SelectedValue + "' AND CodContrato='" + this.ddl_contrato.SelectedValue + "'";
                    SqlConnection ConexionPEC = new SqlConnection(ruta);
                    SqlCommand comandoPE = new SqlCommand(RPEC, ConexionPEC);
                    comandoPE.CommandTimeout = 1800; // 20 min...
                    ConexionPEC.Open();
                    SqlDataReader leerPE = comandoPE.ExecuteReader();

                    if (leerPE.Read() == true)
                    {
                    }
                    else
                    {
                        string InsertPec = "INSERT INTO PacientesEntidadContrato(CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento) VALUES('" + this.ddl_entidades.SelectedValue + "', '" + this.ddl_entidades.SelectedItem + "', '" + this.ddl_contrato.SelectedValue + "', '" + this.ddl_contrato.SelectedItem + "', '" + leerCap2["NumIdAfil"].ToString() + "')";
                        if (Datos.insertarCap(InsertPec))
                        {
                            lbl_resultado.Text = "Error de conexion, no se pudo almacenar la información";
                        }
                        else
                        {
                           lbl_resultado.Text = "Información actualizada con exito";
                        }
                    }
                    ConexionPEC.Close();
                }

                conexionCapitados2.Close();
            }
        }
    }








