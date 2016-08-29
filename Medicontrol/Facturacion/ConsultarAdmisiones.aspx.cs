using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            CleanControl(this.Controls);
            ddl_admision.ClearSelection();
            ddl_estado.ClearSelection();
          
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

        protected void gridAdmisiones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gridAdmisiones, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void gridAdmisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridAdmisiones.Rows)
            {

                if (row.RowIndex == gridAdmisiones.SelectedIndex)
                {
                    ddl_estado.ClearSelection();
                    btn_guardar.Visible = true;
                    ddl_estado.Items.FindByValue(gridAdmisiones.SelectedRow.Cells[6].Text).Selected = true;
                    if (gridAdmisiones.SelectedRow.Cells[1].Text == "2")
                    {
                        btn_imprimirAdmision.Visible = true;
                    }
                    else
                    {
                        btn_imprimirAdmision.Visible = false;
                    }
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

        private void fillgrillaDocumento(string Tipo, string Id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string sql2 = "SELECT Admisiones.NumeroAdmision AS NumeroADM, Admisiones.TipoAdmision AS TipoADM, Admisiones.DocumentoPaciente AS DocumentoADM, Admisiones.FechaAdmision AS FechaADM, Entidad.NombreEntidad AS EntidadADM, Contratos.Descripcion AS ContratoADM, Admisiones.Estado AS EstadoADM FROM (Entidad INNER JOIN Contratos ON Entidad.Codigo = Contratos.Entidad) INNER JOIN (Pacientes INNER JOIN Admisiones ON Pacientes.Documento = Admisiones.DocumentoPaciente) ON (Contratos.Codigo = Admisiones.CodigoContrato) AND (Contratos.Entidad = Admisiones.CodigoEntidad) WHERE Admisiones.DocumentoPaciente = '" + Id + "' AND Admisiones.TipoAdmision = '" + Tipo + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql2, cn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            gridAdmisiones.DataSource = dt;

            gridAdmisiones.DataBind();

        }

        private void fillgrillaAdmision(string Tipo, string Id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string sql2 = "SELECT Admisiones.NumeroAdmision AS NumeroADM, Admisiones.TipoAdmision AS TipoADM, Admisiones.DocumentoPaciente AS DocumentoADM, Admisiones.FechaAdmision AS FechaADM, Entidad.NombreEntidad AS EntidadADM, Contratos.Descripcion AS ContratoADM, Admisiones.Estado AS EstadoADM FROM (Entidad INNER JOIN Contratos ON Entidad.Codigo = Contratos.Entidad) INNER JOIN (Pacientes INNER JOIN Admisiones ON Pacientes.Documento = Admisiones.DocumentoPaciente) ON (Contratos.Codigo = Admisiones.CodigoContrato) AND (Contratos.Entidad = Admisiones.CodigoEntidad) WHERE Admisiones.NumeroAdmision = '" + Id + "' AND Admisiones.TipoAdmision = '" + Tipo + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql2, cn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            gridAdmisiones.DataSource = dt;

            gridAdmisiones.DataBind();

        }


        protected void btn_buscarAdmision_Click(object sender, EventArgs e)
        {
            lbl_resultado.Text = string.Empty;
            //if (ddl_admision.SelectedValue.ToString() == "0")
            //{
            //    lbl_resultado.Text = "Debe indicar un tipo de admision";
            //    return;
            //}
            if (txt_numadmision.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un numero de admision";
                return;
            }
            fillgrillaAdmision(ddl_admision.SelectedValue.ToString(), txt_numadmision.Text);
        }

        protected void btn_buscarDocumento_Click(object sender, EventArgs e)
        {
            lbl_resultado.Text = string.Empty;
            //if (ddl_admision.SelectedValue.ToString() == "0")
            //{
            //    lbl_resultado.Text = "Debe indicar un tipo de admision";
            //    return;
            //}
            if (txt_documento.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe digitar un numero de documento";
                return;
            }
            fillgrillaDocumento(ddl_admision.SelectedValue.ToString(), txt_documento.Text);
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Admisiones SET Estado='" + this.ddl_estado.SelectedValue + "' WHERE NumeroAdmision='" + this.gridAdmisiones.SelectedRow.Cells[0].Text + "' AND TipoAdmision='" + this.gridAdmisiones.SelectedRow.Cells[1].Text + "'";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "No se modificó la información, verifique";
            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupExito();", true);
                lbl_mensajeExito.Text = "Estado de admisión cambiado con exito";
            }
        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            fillgrillaAdmision(ddl_admision.SelectedValue.ToString(), txt_numadmision.Text);
            fillgrillaDocumento(ddl_admision.SelectedValue.ToString(), txt_documento.Text);
        }

        protected void btn_imprimirAdmision_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT Pacientes.Nombre1, Pacientes.Nombre2, Pacientes.Apellido1, Pacientes.Apellido2, Pacientes.TipoDocumento, Pacientes.Documento, Entidad.NombreEntidad, Estratos.Descripcion, Pacientes.Direccion, Pacientes.Telefono, Municipios.Municipio, Admisiones.NumeroAdmision, Admisiones.FechaAdmision, Pacientes.Edad, Pacientes.FechaNacimiento, Pacientes.Sexo, Admisiones.TipoAdmision, Admisiones.HoraAdmision  FROM (Municipios INNER JOIN (Estratos INNER JOIN Pacientes ON Estratos.Descripcion = Pacientes.Estrato) ON (Municipios.CodMncpio = Pacientes.Municipio) AND (Municipios.CodDpto = Pacientes.Departamento)) INNER JOIN (Entidad INNER JOIN Admisiones ON Entidad.Codigo = Admisiones.CodigoEntidad) ON Pacientes.Documento = Admisiones.DocumentoPaciente WHERE Admisiones.NumeroAdmision = '" + this.gridAdmisiones.SelectedRow.Cells[0].Text + "' AND Admisiones.TipoAdmision = '2'";
            ImprimirHojaUrgencia(consulta);
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
            Response.AddHeader("content-disposition", "attachment; filename= HojaUrgencias" + gridAdmisiones.SelectedRow.Cells[3].Text + "." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);

            Response.End();
        }

    }
}