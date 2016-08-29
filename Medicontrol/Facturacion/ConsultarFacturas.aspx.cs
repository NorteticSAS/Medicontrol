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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Facturacion
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        string html = string.Empty;
        string html2 = string.Empty;
        string html3 = string.Empty;
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {

                NombreUsuario.Text = " " + Request.Cookies["Login"]["name"].ToString();
                
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void ddl_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_tipo.SelectedValue == "1")
            {
                lbl_factura.Visible = true;
                lbl_orden.Visible = false;
            }
            else
            {
                lbl_factura.Visible = false;
                lbl_orden.Visible = true;
            }
        }

        protected void GridFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridFacturas, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar";
            }
        }

        protected void GridFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ruta);
            foreach (GridViewRow row in GridFacturas.Rows)
            {

                if (row.RowIndex == GridFacturas.SelectedIndex)
                {
                    string NumFactura = HttpUtility.HtmlDecode(this.GridFacturas.SelectedRow.Cells[1].Text);
                    string tipoFactura = HttpUtility.HtmlDecode(this.GridFacturas.SelectedRow.Cells[2].Text);
                    string sql2 = "SELECT E.NombreEntidad, E.NIT, c.Descripcion, FC.NumFac, FC.FechaFactura, p.TipoDocumento, FC.ValorEnLetras, FC.TipoFactura, p.Documento, p.Nombre1, p.Nombre2, p.Apellido1, p.Apellido2, fd.codproced, fd.desproced, fc.VrTotalProced, fc.VrTotalCopago, fc.VrTotalEntidad, fc.Prefijo, Proced.DescProcedimiento, fd.cantidad, fd.vrproced, fd.vrcopago, fd.vrentidad, u.Nombre, p.Edad, p.Estrato, est.Descripcion, FC.ipsNombre FROM Entidad AS e, Contratos AS c, FacturaCab AS fc, FacturaDet AS fd, Pacientes AS p, Procedimientos AS proced, Usuarios AS u, Estratos AS Est WHERE fc.NumFac = fd.numfac And fc.TipoDoc = fd.TipoDoc And p.Documento = fc.PDocumento And e.Codigo = fc.CodEntidad And e.Codigo = c.Entidad And c.Entidad = fc.CodEntidad And proced.CodProcedimiento = fd.codproced And c.Codigo = fc.CodContrato And p.Estrato = est.Descripcion And fc.Usuario = u.CodUsuario And fc.NumFac = '" + this.GridFacturas.SelectedRow.Cells[1].Text + "' And fc.TipoDoc = '" + this.GridFacturas.SelectedRow.Cells[2].Text + "' And fc.Estado = '0'";
                    ImprimirFactura(sql2);
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

        private void ImprimirFactura(string sql)
        {
            string id = "PDF"; // get this from another control on your page
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "Facturas.rdlc");
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

            ReportDataSource rd = new ReportDataSource("DataSet1", dt);
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
            Response.AddHeader("content-disposition", "attachment; filename= ReporteFactura." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);
            Response.End();
        }

        


    private DataTable GetData()
        {
            string constr = ruta;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT codproced, desproced, cantidad, vrproced, vrcopago, vrentidad FROM FacturaDet WHERE numfac='" + this.GridFacturas.SelectedRow.Cells[1].Text + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        private void fillgrillaDocumento(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(ruta))
            {
                string consulta = sql;
                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
                //SqlDataAdapter da = new SqlDataAdapter("SELECT Id, CodEntidad, NombreEntidad, CodContrato, NombreContrato, Documento FROM PacientesEntidadContrato WHERE Documento='" + this.txt_documento.Text + "'", cn);
                da.Fill(dt);
            }
            GridFacturas.DataSource = dt;

            GridFacturas.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cabezal.Text = string.Empty;
            Cuerpo.Text = string.Empty;
            Footer.Text = string.Empty;
            if (txt_factura.Text == string.Empty)
            {
                
                string sql = "SELECT FacturaCab.NumFac AS FNumero, FacturaCab.Prefijo AS FPrefijo, FacturaCab.TipoDoc AS FTipoDoc, Entidad.NombreEntidad AS FNombreEntidad, Contratos.Descripcion AS FContratoDesc, (Pacientes.Nombre1+' '+Pacientes.Nombre2+' '+Pacientes.Apellido1+' '+Pacientes.Apellido2) AS NombreCompleto, FacturaCab.FechaFactura AS FFecha, FacturaCab.VrTotalProced AS FVrTotalProced, FacturaCab.VrTotalCopago AS ValorCopago, FacturaCab.VrTotalEntidad AS FValorEntidad, FacturaCab.Estado AS FEstado, FacturaCab.Usuario AS FUsuario, FacturaCab.FechaAnulo AS FFechaAnulo, FacturaCab.CtaCobro AS FCobro FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN FacturaCab ON (Contratos.Codigo = FacturaCab.CodContrato) AND (Contratos.Entidad = FacturaCab.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = FacturaCab.PDocumento WHERE FacturaCab.PDocumento= '" + this.txt_docpaciente.Text + "' AND FacturaCab.TipoDoc= '" + this.ddl_tipo.SelectedValue + "'";
                fillgrillaDocumento(sql);
            }
           
            if (txt_docpaciente.Text == string.Empty)
            {
                string sql = "SELECT FacturaCab.NumFac AS FNumero, FacturaCab.Prefijo AS FPrefijo, FacturaCab.TipoDoc AS FTipoDoc, Entidad.NombreEntidad AS FNombreEntidad, Contratos.Descripcion AS FContratoDesc, (Pacientes.Nombre1+' '+Pacientes.Nombre2+' '+Pacientes.Apellido1+' '+Pacientes.Apellido2) AS NombreCompleto, FacturaCab.FechaFactura AS FFecha, FacturaCab.VrTotalProced AS FVrTotalProced, FacturaCab.VrTotalCopago AS ValorCopago, FacturaCab.VrTotalEntidad AS FValorEntidad, FacturaCab.Estado AS FEstado, FacturaCab.Usuario AS FUsuario, FacturaCab.FechaAnulo AS FFechaAnulo, FacturaCab.CtaCobro AS FCobro FROM Pacientes INNER JOIN (Entidad INNER JOIN (Contratos INNER JOIN FacturaCab ON (Contratos.Codigo = FacturaCab.CodContrato) AND (Contratos.Entidad = FacturaCab.CodEntidad)) ON Entidad.Codigo = Contratos.Entidad) ON Pacientes.Documento = FacturaCab.PDocumento WHERE FacturaCab.NumFac= '" + this.txt_factura.Text + "' AND FacturaCab.TipoDoc= '" + this.ddl_tipo.SelectedValue + "'";
                fillgrillaDocumento(sql);
            }
            
            if (txt_docpaciente.Text != string.Empty && txt_factura.Text != string.Empty)
            {
                lbl_resultado.Text = "Debe digitar solamente el numero de factura u orden de servicio o el documento del paciente para consultar";
                return;
            }
        }
    }
}
