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
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol.Citas
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        IngresarDatos Datos = new IngresarDatos();
        private string ruta = ConfigurationManager.ConnectionStrings["System-conection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Datos.consultar("SELECT * FROM IPS ORDER BY Nombre", "IPS");
                this.ddl_ips.DataSource = Datos.ds.Tables["IPS"];
                this.ddl_ips.DataTextField = "Nombre";
                this.ddl_ips.DataValueField = "Id";
                this.ddl_ips.DataBind();
                ddl_ips.Items.Insert(0, new ListItem("Seleccione una IPS"));
            }
            DateTime FechaDia = DateTime.Now;
            txt_fechaDias.Text = FechaDia.ToString("dd/MM/yyyy");
        }

        protected void CalendarCita_SelectionChanged(object sender, EventArgs e)
        {
            txt_CedulaPaciente.ReadOnly = false;
            txt_nombrePaciente.ReadOnly = false;

            txt_fechaCita.Text = CalendarCita.SelectedDate.ToString("dd/MM/yyyy");

            SqlConnection conexion2 = new SqlConnection(ruta);
            string sql = "SELECT * FROM Cita where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
            SqlCommand comando = new SqlCommand(sql, conexion2);
            conexion2.Open();
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {
                seisam.Text = leer["seism"].ToString();
                if (seisam.Text == "")
                {
                    seisam.Text = "";
                    seisam.ForeColor = Color.White;
                    seisam.BackColor = Color.Green;
                }
                else
                {
                    seisam.ForeColor = Color.White;
                    seisam.BackColor = Color.DarkRed;
                }

                seisveinteam.Text = leer["seisveintem"].ToString();
                if (seisveinteam.Text == "")
                {
                    seisveinteam.Text = "";
                    seisveinteam.ForeColor = Color.White;
                    seisveinteam.BackColor = Color.Green;
                }
                else
                {
                    seisveinteam.ForeColor = Color.White;
                    seisveinteam.BackColor = Color.DarkRed;
                }

                seiscuarentaam.Text = leer["seiscuarentam"].ToString();
                if (seiscuarentaam.Text == "")
                {
                    seiscuarentaam.Text = "";
                    seiscuarentaam.ForeColor = Color.White;
                    seiscuarentaam.BackColor = Color.Green;
                }
                else
                {
                    seiscuarentaam.ForeColor = Color.White;
                    seiscuarentaam.BackColor = Color.DarkRed;
                }

                sieteam.Text = leer["sietem"].ToString();
                if (sieteam.Text == "")
                {
                    sieteam.Text = "";
                    sieteam.ForeColor = Color.White;
                    sieteam.BackColor = Color.Green;
                }
                else
                {
                    sieteam.ForeColor = Color.White;
                    sieteam.BackColor = Color.DarkRed;
                }

                sieteveinteam.Text = leer["sieteveintem"].ToString();
                if (sieteveinteam.Text == "")
                {
                    sieteveinteam.Text = "";
                    sieteveinteam.ForeColor = Color.White;
                    sieteveinteam.BackColor = Color.Green;
                }
                else
                {
                    sieteveinteam.ForeColor = Color.White;
                    sieteveinteam.BackColor = Color.DarkRed;
                }

                sietecuarentaam.Text = leer["sietecuarentam"].ToString();
                if (sietecuarentaam.Text == "")
                {
                    sietecuarentaam.Text = "";
                    sietecuarentaam.ForeColor = Color.White;
                    sietecuarentaam.BackColor = Color.Green;
                }
                else
                {
                    sietecuarentaam.ForeColor = Color.White;
                    sietecuarentaam.BackColor = Color.DarkRed;
                }

                ochoam.Text = leer["ochom"].ToString();
                if (ochoam.Text == "")
                {
                    ochoam.Text = "";
                    ochoam.ForeColor = Color.White;
                    ochoam.BackColor = Color.Green;
                }
                else
                {
                    ochoam.ForeColor = Color.White;
                    ochoam.BackColor = Color.DarkRed;
                }

                ochoveinteam.Text = leer["ochoveintem"].ToString();
                if (ochoveinteam.Text == "")
                {
                    ochoveinteam.Text = "";
                    ochoveinteam.ForeColor = Color.White;
                    ochoveinteam.BackColor = Color.Green;
                }
                else
                {
                    ochoveinteam.ForeColor = Color.White;
                    ochoveinteam.BackColor = Color.DarkRed;
                }
                ochocuarentaam.Text = leer["ochocuarentam"].ToString();
                if (ochocuarentaam.Text == "")
                {
                    ochocuarentaam.Text = "";
                    ochocuarentaam.ForeColor = Color.White;
                    ochocuarentaam.BackColor = Color.Green;
                }
                else
                {
                    ochocuarentaam.ForeColor = Color.White;
                    ochocuarentaam.BackColor = Color.DarkRed;
                }

                nueveam.Text = leer["nuevem"].ToString();
                if (nueveam.Text == "")
                {
                    nueveam.Text = "";
                    nueveam.ForeColor = Color.White;
                    nueveam.BackColor = Color.Green;
                }
                else
                {
                    nueveam.ForeColor = Color.White;
                    nueveam.BackColor = Color.DarkRed;
                }

                nueveveinteam.Text = leer["nueveveintem"].ToString();
                if (nueveveinteam.Text == "")
                {
                    nueveveinteam.Text = "";
                    nueveveinteam.ForeColor = Color.White;
                    nueveveinteam.BackColor = Color.Green;
                }
                else
                {
                    nueveveinteam.ForeColor = Color.White;
                    nueveveinteam.BackColor = Color.DarkRed;
                }

                nuevecuarentaam.Text = leer["nuevecuarentam"].ToString();
                if (nuevecuarentaam.Text == "")
                {
                    nuevecuarentaam.Text = "";
                    nuevecuarentaam.ForeColor = Color.White;
                    nuevecuarentaam.BackColor = Color.Green;
                }
                else
                {
                    nuevecuarentaam.ForeColor = Color.White;
                    nuevecuarentaam.BackColor = Color.DarkRed;
                }

                diezam.Text = leer["diezm"].ToString();
                if (diezam.Text == "")
                {
                    diezam.Text = "";
                    diezam.ForeColor = Color.White;
                    diezam.BackColor = Color.Green;
                }
                else
                {
                    diezam.ForeColor = Color.White;
                    diezam.BackColor = Color.DarkRed;
                }

                diezveinteam.Text = leer["diezveintem"].ToString();
                if (diezveinteam.Text == "")
                {
                    diezveinteam.Text = "";
                    diezveinteam.ForeColor = Color.White;
                    diezveinteam.BackColor = Color.Green;
                }
                else
                {
                    diezveinteam.ForeColor = Color.White;
                    diezveinteam.BackColor = Color.DarkRed;
                }

                diezcuarentaam.Text = leer["diezcuarentam"].ToString();
                if (diezcuarentaam.Text == "")
                {
                    diezcuarentaam.Text = "";
                    diezcuarentaam.ForeColor = Color.White;
                    diezcuarentaam.BackColor = Color.Green;
                }
                else
                {
                    diezcuarentaam.ForeColor = Color.White;
                    diezcuarentaam.BackColor = Color.DarkRed;
                }

                onceam.Text = leer["oncem"].ToString();
                if (onceam.Text == "")
                {
                    onceam.Text = "";
                    onceam.ForeColor = Color.White;
                    onceam.BackColor = Color.Green;
                }
                else
                {
                    onceam.ForeColor = Color.White;
                    onceam.BackColor = Color.DarkRed;
                }

                onceveinteam.Text = leer["onceveintem"].ToString();
                if (onceveinteam.Text == "")
                {
                    onceveinteam.Text = "";
                    onceveinteam.ForeColor = Color.White;
                    onceveinteam.BackColor = Color.Green;
                }
                else
                {
                    onceveinteam.ForeColor = Color.White;
                    onceveinteam.BackColor = Color.DarkRed;
                }

                oncecuarentaam.Text = leer["oncecuarentam"].ToString();
                if (oncecuarentaam.Text == "")
                {
                    oncecuarentaam.Text = "";
                    oncecuarentaam.ForeColor = Color.White;
                    oncecuarentaam.BackColor = Color.Green;
                }
                else
                {
                    oncecuarentaam.ForeColor = Color.White;
                    oncecuarentaam.BackColor = Color.DarkRed;
                }

                docepm.Text = leer["docep"].ToString();
                if (docepm.Text == "")
                {
                    docepm.Text = "";
                    docepm.ForeColor = Color.White;
                    docepm.BackColor = Color.Green;
                }
                else
                {
                    docepm.ForeColor = Color.White;
                    docepm.BackColor = Color.DarkRed;
                }

                doceveintepm.Text = leer["doceveintep"].ToString();
                if (doceveintepm.Text == "")
                {
                    doceveintepm.Text = "";
                    doceveintepm.ForeColor = Color.White;
                    doceveintepm.BackColor = Color.Green;
                }
                else
                {
                    doceveintepm.ForeColor = Color.White;
                    doceveintepm.BackColor = Color.DarkRed;
                }

                docecuarentapm.Text = leer["docecuarentap"].ToString();
                if (docecuarentapm.Text == "")
                {
                    docecuarentapm.Text = "";
                    docecuarentapm.ForeColor = Color.White;
                    docecuarentapm.BackColor = Color.Green;
                }
                else
                {
                    docecuarentapm.ForeColor = Color.White;
                    docecuarentapm.BackColor = Color.DarkRed;
                }

                unopm.Text = leer["unop"].ToString();
                if (unopm.Text == "")
                {
                    unopm.Text = "";
                    unopm.ForeColor = Color.White;
                    unopm.BackColor = Color.Green;
                }
                else
                {
                    unopm.ForeColor = Color.White;
                    unopm.BackColor = Color.DarkRed;
                }

                unoveintepm.Text = leer["unoveintep"].ToString();
                if (unoveintepm.Text == "")
                {
                    unoveintepm.Text = "";
                    unoveintepm.ForeColor = Color.White;
                    unoveintepm.BackColor = Color.Green;
                }
                else
                {
                    unoveintepm.ForeColor = Color.White;
                    unoveintepm.BackColor = Color.DarkRed;
                }

                unocuarentapm.Text = leer["unocuarentap"].ToString();
                if (unocuarentapm.Text == "")
                {
                    unocuarentapm.Text = "";
                    unocuarentapm.ForeColor = Color.White;
                    unocuarentapm.BackColor = Color.Green;
                }
                else
                {
                    unocuarentapm.ForeColor = Color.White;
                    unocuarentapm.BackColor = Color.DarkRed;
                }

                dospm.Text = leer["dosp"].ToString();
                if (dospm.Text == "")
                {
                    dospm.Text = "";
                    dospm.ForeColor = Color.White;
                    dospm.BackColor = Color.Green;
                }
                else
                {
                    dospm.ForeColor = Color.White;
                    dospm.BackColor = Color.DarkRed;
                }

                dosveintepm.Text = leer["dosveintep"].ToString();
                if (dosveintepm.Text == "")
                {
                    dosveintepm.Text = "";
                    dosveintepm.ForeColor = Color.White;
                    dosveintepm.BackColor = Color.Green;
                }
                else
                {
                    dosveintepm.ForeColor = Color.White;
                    dosveintepm.BackColor = Color.DarkRed;
                }

                doscuarentapm.Text = leer["doscuarentap"].ToString();
                if (doscuarentapm.Text == "")
                {
                    doscuarentapm.Text = "";
                    doscuarentapm.ForeColor = Color.White;
                    doscuarentapm.BackColor = Color.Green;
                }
                else
                {
                    doscuarentapm.ForeColor = Color.White;
                    doscuarentapm.BackColor = Color.DarkRed;
                }

                trespm.Text = leer["tresp"].ToString();
                if (trespm.Text == "")
                {
                    trespm.Text = "";
                    trespm.ForeColor = Color.White;
                    trespm.BackColor = Color.Green;
                }
                else
                {
                    trespm.ForeColor = Color.White;
                    trespm.BackColor = Color.DarkRed;
                }

                tresveintepm.Text = leer["tresveintep"].ToString();
                if (tresveintepm.Text == "")
                {
                    tresveintepm.Text = "";
                    tresveintepm.ForeColor = Color.White;
                    tresveintepm.BackColor = Color.Green;
                }
                else
                {
                    tresveintepm.ForeColor = Color.White;
                    tresveintepm.BackColor = Color.DarkRed;
                }

                trescuarentapm.Text = leer["trescuarentap"].ToString();
                if (trescuarentapm.Text == "")
                {
                    trescuarentapm.Text = "";
                    trescuarentapm.ForeColor = Color.White;
                    trescuarentapm.BackColor = Color.Green;
                }
                else
                {
                    trescuarentapm.ForeColor = Color.White;
                    trescuarentapm.BackColor = Color.DarkRed;
                }

                cuatropm.Text = leer["cuatrop"].ToString();
                if (cuatropm.Text == "")
                {
                    cuatropm.Text = "";
                    cuatropm.ForeColor = Color.White;
                    cuatropm.BackColor = Color.Green;
                }
                else
                {
                    cuatropm.ForeColor = Color.White;
                    cuatropm.BackColor = Color.DarkRed;
                }

                cuatroveintepm.Text = leer["cuatroveintep"].ToString();
                if (cuatroveintepm.Text == "")
                {
                    cuatroveintepm.Text = "";
                    cuatroveintepm.ForeColor = Color.White;
                    cuatroveintepm.BackColor = Color.Green;
                }
                else
                {
                    cuatroveintepm.ForeColor = Color.White;
                    cuatroveintepm.BackColor = Color.DarkRed;
                }

                cuatrocuarentapm.Text = leer["cuatrocuarentap"].ToString();
                if (cuatrocuarentapm.Text == "")
                {
                    cuatrocuarentapm.Text = "";
                    cuatrocuarentapm.ForeColor = Color.White;
                    cuatrocuarentapm.BackColor = Color.Green;
                }
                else
                {
                    cuatrocuarentapm.ForeColor = Color.White;
                    cuatrocuarentapm.BackColor = Color.DarkRed;
                }
                cincopm.Text = leer["cincop"].ToString();
                if (cincopm.Text == "")
                {
                    cincopm.Text = "";
                    cincopm.ForeColor = Color.White;
                    cincopm.BackColor = Color.Green;
                }
                else
                {
                    cincopm.ForeColor = Color.White;
                    cincopm.BackColor = Color.DarkRed;
                }

                cincoveintepm.Text = leer["cincoveintep"].ToString();
                if (cincoveintepm.Text == "")
                {
                    cincoveintepm.Text = "";
                    cincoveintepm.ForeColor = Color.White;
                    cincoveintepm.BackColor = Color.Green;
                }
                else
                {
                    cincoveintepm.ForeColor = Color.White;
                    cincoveintepm.BackColor = Color.DarkRed;
                }

                cincocuarentapm.Text = leer["cincocuarentap"].ToString();
                if (cincocuarentapm.Text == "")
                {
                    cincocuarentapm.Text = "";
                    cincocuarentapm.ForeColor = Color.White;
                    cincocuarentapm.BackColor = Color.Green;
                }
                else
                {
                    cincocuarentapm.ForeColor = Color.White;
                    cincocuarentapm.BackColor = Color.DarkRed;
                }

                seispm.Text = leer["seisp"].ToString();
                if (seispm.Text == "")
                {
                    seispm.Text = "";
                    seispm.ForeColor = Color.White;
                    seispm.BackColor = Color.Green;
                }
                else
                {
                    seispm.ForeColor = Color.White;
                    seispm.BackColor = Color.DarkRed;
                }

                seisveintepm.Text = leer["seisveintep"].ToString();
                if (seisveintepm.Text == "")
                {
                    seisveintepm.Text = "";
                    seisveintepm.ForeColor = Color.White;
                    seisveintepm.BackColor = Color.Green;
                }
                else
                {
                    seisveintepm.ForeColor = Color.White;
                    seisveintepm.BackColor = Color.DarkRed;
                }

                seiscuarentapm.Text = leer["seiscuarentap"].ToString();
                if (seiscuarentapm.Text == "")
                {
                    seiscuarentapm.Text = "";
                    seiscuarentapm.ForeColor = Color.White;
                    seiscuarentapm.BackColor = Color.Green;
                }
                else
                {
                    seiscuarentapm.ForeColor = Color.White;
                    seiscuarentapm.BackColor = Color.DarkRed;
                }

                sietepm.Text = leer["sietep"].ToString();
                if (sietepm.Text == "")
                {
                    sietepm.Text = "";
                    sietepm.ForeColor = Color.White;
                    sietepm.BackColor = Color.Green;
                }
                else
                {
                    sietepm.ForeColor = Color.White;
                    sietepm.BackColor = Color.DarkRed;
                }

                sieteveintepm.Text = leer["sieteveintep"].ToString();
                if (sieteveintepm.Text == "")
                {
                    sieteveintepm.Text = "";
                    sieteveintepm.ForeColor = Color.White;
                    sieteveintepm.BackColor = Color.Green;
                }
                else
                {
                    sieteveintepm.ForeColor = Color.White;
                    sieteveintepm.BackColor = Color.DarkRed;
                }

                sietecuarentapm.Text = leer["sietecuarentap"].ToString();
                if (sietecuarentapm.Text == "")
                {
                    sietecuarentapm.Text = "";
                    sietecuarentapm.ForeColor = Color.White;
                    sietecuarentapm.BackColor = Color.Green;
                }
                else
                {
                    sietecuarentapm.ForeColor = Color.White;
                    sietecuarentapm.BackColor = Color.DarkRed;
                }

                ochopm.Text = leer["ochop"].ToString();
                if (ochopm.Text == "")
                {
                    ochopm.Text = "";
                    ochopm.ForeColor = Color.White;
                    ochopm.BackColor = Color.Green;
                }
                else
                {
                    ochopm.ForeColor = Color.White;
                    ochopm.BackColor = Color.DarkRed;
                }

                ochoveintepm.Text = leer["ochoveintep"].ToString();
                if (ochoveintepm.Text == "")
                {
                    ochoveintepm.Text = "";
                    ochoveintepm.ForeColor = Color.White;
                    ochoveintepm.BackColor = Color.Green;
                }
                else
                {
                    ochoveintepm.ForeColor = Color.White;
                    ochoveintepm.BackColor = Color.DarkRed;
                }

                ochocuarentapm.Text = leer["ochocuarentap"].ToString();
                if (ochocuarentapm.Text == "")
                {
                    ochocuarentapm.Text = "";
                    ochocuarentapm.ForeColor = Color.White;
                    ochocuarentapm.BackColor = Color.Green;
                }
                else
                {
                    ochocuarentapm.ForeColor = Color.White;
                    ochocuarentapm.BackColor = Color.DarkRed;
                }

                nuevepm.Text = leer["nuevep"].ToString();
                if (ochopm.Text == "")
                {
                    nuevepm.Text = "";
                    nuevepm.ForeColor = Color.White;
                    nuevepm.BackColor = Color.Green;
                }
                else
                {
                    nuevepm.ForeColor = Color.White;
                    nuevepm.BackColor = Color.DarkRed;
                }

            }
            else
            {
                txt_CedulaPaciente.Text = string.Empty;
                txt_nombrePaciente.Text = string.Empty;
                manana.ClearSelection();
                tarde.ClearSelection();
                seisam.Text = string.Empty;
                seisam.ForeColor = Color.White;
                seisam.BackColor = Color.Green;

                seisveinteam.Text = string.Empty;
                seisveinteam.ForeColor = Color.White;
                seisveinteam.BackColor = Color.Green;

                seiscuarentaam.Text = string.Empty;
                seiscuarentaam.ForeColor = Color.White;
                seiscuarentaam.BackColor = Color.Green;

                sieteam.Text = string.Empty;
                sieteam.ForeColor = Color.White;
                sieteam.BackColor = Color.Green;

                sieteveinteam.Text = string.Empty;
                sieteveinteam.ForeColor = Color.White;
                sieteveinteam.BackColor = Color.Green;

                sietecuarentaam.Text = string.Empty;
                sietecuarentaam.ForeColor = Color.White;
                sietecuarentaam.BackColor = Color.Green;

                ochoam.Text = string.Empty;
                ochoam.ForeColor = Color.White;
                ochoam.BackColor = Color.Green;

                ochoveinteam.Text = string.Empty;
                ochoveinteam.ForeColor = Color.White;
                ochoveinteam.BackColor = Color.Green;

                ochocuarentaam.Text = string.Empty;
                ochocuarentaam.ForeColor = Color.White;
                ochocuarentaam.BackColor = Color.Green;

                nueveam.Text = string.Empty;
                nueveam.ForeColor = Color.White;
                nueveam.BackColor = Color.Green;

                nueveveinteam.Text = string.Empty;
                nueveveinteam.ForeColor = Color.White;
                nueveveinteam.BackColor = Color.Green;

                nuevecuarentaam.Text = string.Empty;
                nuevecuarentaam.ForeColor = Color.White;
                nuevecuarentaam.BackColor = Color.Green;

                diezam.Text = string.Empty;
                diezam.ForeColor = Color.White;
                diezam.BackColor = Color.Green;

                diezveinteam.Text = string.Empty;
                diezveinteam.ForeColor = Color.White;
                diezveinteam.BackColor = Color.Green;

                diezcuarentaam.Text = string.Empty;
                diezcuarentaam.ForeColor = Color.White;
                diezcuarentaam.BackColor = Color.Green;

                onceam.Text = string.Empty;
                onceam.ForeColor = Color.White;
                onceam.BackColor = Color.Green;

                onceveinteam.Text = string.Empty;
                onceveinteam.ForeColor = Color.White;
                onceveinteam.BackColor = Color.Green;

                oncecuarentaam.Text = string.Empty;
                oncecuarentaam.ForeColor = Color.White;
                oncecuarentaam.BackColor = Color.Green;

                docepm.Text = string.Empty;
                docepm.ForeColor = Color.White;
                docepm.BackColor = Color.Green;

                doceveintepm.Text = string.Empty;
                doceveintepm.ForeColor = Color.White;
                doceveintepm.BackColor = Color.Green;

                docecuarentapm.Text = string.Empty;
                docecuarentapm.ForeColor = Color.White;
                docecuarentapm.BackColor = Color.Green;

                unopm.Text = string.Empty;
                unopm.ForeColor = Color.White;
                unopm.BackColor = Color.Green;

                unoveintepm.Text = string.Empty;
                unoveintepm.ForeColor = Color.White;
                unoveintepm.BackColor = Color.Green;

                unocuarentapm.Text = string.Empty;
                unocuarentapm.ForeColor = Color.White;
                unocuarentapm.BackColor = Color.Green;

                dospm.Text = string.Empty;
                dospm.ForeColor = Color.White;
                dospm.BackColor = Color.Green;

                dosveintepm.Text = string.Empty;
                dosveintepm.ForeColor = Color.White;
                dosveintepm.BackColor = Color.Green;

                doscuarentapm.Text = string.Empty;
                doscuarentapm.ForeColor = Color.White;
                doscuarentapm.BackColor = Color.Green;

                trespm.Text = string.Empty;
                trespm.ForeColor = Color.White;
                trespm.BackColor = Color.Green;

                tresveintepm.Text = string.Empty;
                tresveintepm.ForeColor = Color.White;
                tresveintepm.BackColor = Color.Green;

                trescuarentapm.Text = string.Empty;
                trescuarentapm.ForeColor = Color.White;
                trescuarentapm.BackColor = Color.Green;

                cuatropm.Text = string.Empty;
                cuatropm.ForeColor = Color.White;
                cuatropm.BackColor = Color.Green;

                cuatroveintepm.Text = string.Empty;
                cuatroveintepm.ForeColor = Color.White;
                cuatroveintepm.BackColor = Color.Green;

                cuatrocuarentapm.Text = string.Empty;
                cuatrocuarentapm.ForeColor = Color.White;
                cuatrocuarentapm.BackColor = Color.Green;

                cincopm.Text = string.Empty;
                cincopm.ForeColor = Color.White;
                cincopm.BackColor = Color.Green;

                cincoveintepm.Text = string.Empty;
                cincoveintepm.ForeColor = Color.White;
                cincoveintepm.BackColor = Color.Green;

                cincocuarentapm.Text = string.Empty;
                cincocuarentapm.ForeColor = Color.White;
                cincocuarentapm.BackColor = Color.Green;

                seispm.Text = string.Empty;
                seispm.ForeColor = Color.White;
                seispm.BackColor = Color.Green;

                seisveintepm.Text = string.Empty;
                seisveintepm.ForeColor = Color.White;
                seisveintepm.BackColor = Color.Green;

                seiscuarentapm.Text = string.Empty;
                seiscuarentapm.ForeColor = Color.White;
                seiscuarentapm.BackColor = Color.Green;

                sietepm.Text = string.Empty;
                sietepm.ForeColor = Color.White;
                sietepm.BackColor = Color.Green;

                sieteveintepm.Text = string.Empty;
                sieteveintepm.ForeColor = Color.White;
                sieteveintepm.BackColor = Color.Green;

                sietecuarentapm.Text = string.Empty;
                sietecuarentapm.ForeColor = Color.White;
                sietecuarentapm.BackColor = Color.Green;

                ochopm.Text = string.Empty;
                ochopm.ForeColor = Color.White;
                ochopm.BackColor = Color.Green;

                ochoveintepm.Text = string.Empty;
                ochoveintepm.ForeColor = Color.White;
                ochoveintepm.BackColor = Color.Green;

                ochocuarentapm.Text = string.Empty;
                ochocuarentapm.ForeColor = Color.White;
                ochocuarentapm.BackColor = Color.Green;

                nuevepm.Text = string.Empty;
                nuevepm.ForeColor = Color.White;
                nuevepm.BackColor = Color.Green;
            }
            conexion2.Close();
        }

        protected void ddl_ips_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalendarCita.SelectedDates.Clear();
            ddl_profesionales.Enabled = true;
            Datos.consultar("SELECT * FROM Profesionales ORDER BY NombreCompleto", "Profesionales");
            this.ddl_profesionales.DataSource = Datos.ds.Tables["Profesionales"];
            this.ddl_profesionales.DataTextField = "NombreCompleto";
            this.ddl_profesionales.DataValueField = "CodProfesional";
            this.ddl_profesionales.DataBind();
            ddl_profesionales.Items.Insert(0, new ListItem("Seleccione una Profesional"));

            txt_CedulaPaciente.Text = string.Empty;
            txt_nombrePaciente.Text = string.Empty;
            manana.ClearSelection();
            tarde.ClearSelection();
            seisam.Text = string.Empty;
            seisam.ForeColor = Color.White;
            seisam.BackColor = Color.Green;

            seisveinteam.Text = string.Empty;
            seisveinteam.ForeColor = Color.White;
            seisveinteam.BackColor = Color.Green;

            seiscuarentaam.Text = string.Empty;
            seiscuarentaam.ForeColor = Color.White;
            seiscuarentaam.BackColor = Color.Green;

            sieteam.Text = string.Empty;
            sieteam.ForeColor = Color.White;
            sieteam.BackColor = Color.Green;

            sieteveinteam.Text = string.Empty;
            sieteveinteam.ForeColor = Color.White;
            sieteveinteam.BackColor = Color.Green;

            sietecuarentaam.Text = string.Empty;
            sietecuarentaam.ForeColor = Color.White;
            sietecuarentaam.BackColor = Color.Green;

            ochoam.Text = string.Empty;
            ochoam.ForeColor = Color.White;
            ochoam.BackColor = Color.Green;

            ochoveinteam.Text = string.Empty;
            ochoveinteam.ForeColor = Color.White;
            ochoveinteam.BackColor = Color.Green;

            ochocuarentaam.Text = string.Empty;
            ochocuarentaam.ForeColor = Color.White;
            ochocuarentaam.BackColor = Color.Green;

            nueveam.Text = string.Empty;
            nueveam.ForeColor = Color.White;
            nueveam.BackColor = Color.Green;

            nueveveinteam.Text = string.Empty;
            nueveveinteam.ForeColor = Color.White;
            nueveveinteam.BackColor = Color.Green;

            nuevecuarentaam.Text = string.Empty;
            nuevecuarentaam.ForeColor = Color.White;
            nuevecuarentaam.BackColor = Color.Green;

            diezam.Text = string.Empty;
            diezam.ForeColor = Color.White;
            diezam.BackColor = Color.Green;

            diezveinteam.Text = string.Empty;
            diezveinteam.ForeColor = Color.White;
            diezveinteam.BackColor = Color.Green;

            diezcuarentaam.Text = string.Empty;
            diezcuarentaam.ForeColor = Color.White;
            diezcuarentaam.BackColor = Color.Green;

            onceam.Text = string.Empty;
            onceam.ForeColor = Color.White;
            onceam.BackColor = Color.Green;

            onceveinteam.Text = string.Empty;
            onceveinteam.ForeColor = Color.White;
            onceveinteam.BackColor = Color.Green;

            oncecuarentaam.Text = string.Empty;
            oncecuarentaam.ForeColor = Color.White;
            oncecuarentaam.BackColor = Color.Green;

            docepm.Text = string.Empty;
            docepm.ForeColor = Color.White;
            docepm.BackColor = Color.Green;

            doceveintepm.Text = string.Empty;
            doceveintepm.ForeColor = Color.White;
            doceveintepm.BackColor = Color.Green;

            docecuarentapm.Text = string.Empty;
            docecuarentapm.ForeColor = Color.White;
            docecuarentapm.BackColor = Color.Green;

            unopm.Text = string.Empty;
            unopm.ForeColor = Color.White;
            unopm.BackColor = Color.Green;

            unoveintepm.Text = string.Empty;
            unoveintepm.ForeColor = Color.White;
            unoveintepm.BackColor = Color.Green;

            unocuarentapm.Text = string.Empty;
            unocuarentapm.ForeColor = Color.White;
            unocuarentapm.BackColor = Color.Green;

            dospm.Text = string.Empty;
            dospm.ForeColor = Color.White;
            dospm.BackColor = Color.Green;

            dosveintepm.Text = string.Empty;
            dosveintepm.ForeColor = Color.White;
            dosveintepm.BackColor = Color.Green;

            doscuarentapm.Text = string.Empty;
            doscuarentapm.ForeColor = Color.White;
            doscuarentapm.BackColor = Color.Green;

            trespm.Text = string.Empty;
            trespm.ForeColor = Color.White;
            trespm.BackColor = Color.Green;

            tresveintepm.Text = string.Empty;
            tresveintepm.ForeColor = Color.White;
            tresveintepm.BackColor = Color.Green;

            trescuarentapm.Text = string.Empty;
            trescuarentapm.ForeColor = Color.White;
            trescuarentapm.BackColor = Color.Green;

            cuatropm.Text = string.Empty;
            cuatropm.ForeColor = Color.White;
            cuatropm.BackColor = Color.Green;

            cuatroveintepm.Text = string.Empty;
            cuatroveintepm.ForeColor = Color.White;
            cuatroveintepm.BackColor = Color.Green;

            cuatrocuarentapm.Text = string.Empty;
            cuatrocuarentapm.ForeColor = Color.White;
            cuatrocuarentapm.BackColor = Color.Green;

            cincopm.Text = string.Empty;
            cincopm.ForeColor = Color.White;
            cincopm.BackColor = Color.Green;

            cincoveintepm.Text = string.Empty;
            cincoveintepm.ForeColor = Color.White;
            cincoveintepm.BackColor = Color.Green;

            cincocuarentapm.Text = string.Empty;
            cincocuarentapm.ForeColor = Color.White;
            cincocuarentapm.BackColor = Color.Green;

            seispm.Text = string.Empty;
            seispm.ForeColor = Color.White;
            seispm.BackColor = Color.Green;

            seisveintepm.Text = string.Empty;
            seisveintepm.ForeColor = Color.White;
            seisveintepm.BackColor = Color.Green;

            seiscuarentapm.Text = string.Empty;
            seiscuarentapm.ForeColor = Color.White;
            seiscuarentapm.BackColor = Color.Green;

            sietepm.Text = string.Empty;
            sietepm.ForeColor = Color.White;
            sietepm.BackColor = Color.Green;

            sieteveintepm.Text = string.Empty;
            sieteveintepm.ForeColor = Color.White;
            sieteveintepm.BackColor = Color.Green;

            sietecuarentapm.Text = string.Empty;
            sietecuarentapm.ForeColor = Color.White;
            sietecuarentapm.BackColor = Color.Green;

            ochopm.Text = string.Empty;
            ochopm.ForeColor = Color.White;
            ochopm.BackColor = Color.Green;

            ochoveintepm.Text = string.Empty;
            ochoveintepm.ForeColor = Color.White;
            ochoveintepm.BackColor = Color.Green;

            ochocuarentapm.Text = string.Empty;
            ochocuarentapm.ForeColor = Color.White;
            ochocuarentapm.BackColor = Color.Green;

            nuevepm.Text = string.Empty;
            nuevepm.ForeColor = Color.White;
            nuevepm.BackColor = Color.Green;
        }

        protected void ddl_profesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalendarCita.Enabled = true;
            CalendarCita.SelectedDates.Clear();
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
            if (txt_nombrePaciente.Text != string.Empty)
            {
                string sqlPac = "SELECT Documento, (Nombre1+' '+Nombre2+' '+Apellido1+' '+Apellido2) AS NombreCompleto FROM Pacientes WHERE (Nombre1+' '+Nombre2+' '+Apellido1+' '+Apellido2)='" + this.txt_nombrePaciente.Text + "'";
                SqlConnection conexionCodigo = new SqlConnection(ruta);
                SqlCommand comandoPac = new SqlCommand(sqlPac, conexionCodigo);
                conexionCodigo.Open();

                SqlDataReader leerPc = comandoPac.ExecuteReader();

                if (leerPc.Read() == true)
                {
                    txt_CedulaPaciente.Text = leerPc["Documento"].ToString();
                    txt_nombrePaciente.Text = leerPc["NombreCompleto"].ToString();
                    manana.Enabled = true;
                    tarde.Enabled = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupNoexiste();", true);
                    this.lbl_mensajeUsuario.Text = "El usuario no existe. ¿Desea Crearlo?";
                }
                conexionCodigo.Close();
            }

            string sql = "SELECT Documento, (Nombre1+' '+Nombre2+' '+Apellido1+' '+Apellido2) AS NombreCompleto FROM Pacientes WHERE Documento='" + this.txt_CedulaPaciente.Text + "'";
            SqlConnection conexion = new SqlConnection(ruta);
            SqlCommand comando = new SqlCommand(sql, conexion);

            conexion.Open();
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                txt_CedulaPaciente.Text = leer["Documento"].ToString();
                txt_nombrePaciente.Text = leer["NombreCompleto"].ToString();
                manana.Enabled = true;
                tarde.Enabled = true;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupNoexiste();", true);
                this.lbl_mensajeUsuario.Text = "El usuario no existe. ¿Desea Crearlo?";
            }
            conexion.Close();
        }

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Facturacion/NuevoPaciente.aspx");
        }

        protected void btn_nocrear_Click(object sender, EventArgs e)
        {
            return;
        }

        public bool Existedia(string fecha)
        {
            using (SqlConnection conn = new SqlConnection(ruta))
            {
                string query = "SELECT COUNT(*) FROM Cita WHERE fecha_cita='" + fecha + "' and CodEntidad='" + ddl_ips.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("fecha_cita", fecha);
                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                if (count == 0)
                    return false;
                else
                    return true;
            }
        }
        //SECCION DE ASIGNACION DE CITAS
        //JORNADA DE LA MAÑANA
        protected void manana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_CedulaPaciente.Text == string.Empty && txt_nombrePaciente.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe buscar un paciente para continuar";
                return;
            }
            //SI NO SELECCIONO HORA
            if (manana.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar una Hora";
                return;
            }

            //6:00 AM
            if (manana.SelectedValue == "1")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and seism !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            seisam.Text = txt_nombrePaciente.Text;
                            seisam.BackColor = Color.DarkRed;
                            seisam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET seism='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                seisam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            seisam.Text = txt_nombrePaciente.Text;
                            seisam.BackColor = Color.DarkRed;
                            seisam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seism) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                seisam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    seisam.Text = txt_nombrePaciente.Text;
                    seisam.BackColor = Color.DarkRed;
                    seisam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seism) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        seisam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //6:20 AM
            if (manana.SelectedValue == "2")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and seisveintem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            seisveinteam.Text = txt_nombrePaciente.Text;
                            seisveinteam.BackColor = Color.DarkRed;
                            seisveinteam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET seisveintem='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                seisveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            seisveinteam.Text = txt_nombrePaciente.Text;
                            seisveinteam.BackColor = Color.DarkRed;
                            seisveinteam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seisveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                seisveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    seisveinteam.Text = txt_nombrePaciente.Text;
                    seisveinteam.BackColor = Color.DarkRed;
                    seisveinteam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seisveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        seisveinteam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //6:40 AM
            if (manana.SelectedValue == "3")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and seiscuarentam !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            seiscuarentaam.Text = txt_nombrePaciente.Text;
                            seiscuarentaam.BackColor = Color.DarkRed;
                            seiscuarentaam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET seiscuarentam='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                seiscuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            seiscuarentaam.Text = txt_nombrePaciente.Text;
                            seiscuarentaam.BackColor = Color.DarkRed;
                            seiscuarentaam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seiscuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                seiscuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    seiscuarentaam.Text = txt_nombrePaciente.Text;
                    seiscuarentaam.BackColor = Color.DarkRed;
                    seiscuarentaam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seiscuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        seiscuarentaam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //7:00 AM
            if (manana.SelectedValue == "4")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and sietem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            sieteam.Text = txt_nombrePaciente.Text;
                            sieteam.BackColor = Color.DarkRed;
                            sieteam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET sietem='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                sieteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            sieteam.Text = txt_nombrePaciente.Text;
                            sieteam.BackColor = Color.DarkRed;
                            sieteam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sietem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                sieteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    sieteam.Text = txt_nombrePaciente.Text;
                    sieteam.BackColor = Color.DarkRed;
                    sieteam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sietem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        sieteam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //7:20 AM
            if (manana.SelectedValue == "5")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and sieteveintem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            sieteveinteam.Text = txt_nombrePaciente.Text;
                            sieteveinteam.BackColor = Color.DarkRed;
                            sieteveinteam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET sieteveintem='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                sieteveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            sieteveinteam.Text = txt_nombrePaciente.Text;
                            sieteveinteam.BackColor = Color.DarkRed;
                            sieteveinteam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sieteveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                sieteveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    sieteveinteam.Text = txt_nombrePaciente.Text;
                    sieteveinteam.BackColor = Color.DarkRed;
                    sieteveinteam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sieteveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        sieteveinteam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //7:40 AM
            if (manana.SelectedValue == "6")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and sietecuarentam !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            sietecuarentaam.Text = txt_nombrePaciente.Text;
                            sietecuarentaam.BackColor = Color.DarkRed;
                            sietecuarentaam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET sietecuarentam='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                sietecuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            sietecuarentaam.Text = txt_nombrePaciente.Text;
                            sietecuarentaam.BackColor = Color.DarkRed;
                            sietecuarentaam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sietecuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                sietecuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    sietecuarentaam.Text = txt_nombrePaciente.Text;
                    sietecuarentaam.BackColor = Color.DarkRed;
                    sietecuarentaam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sietecuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        sietecuarentaam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //8:00 AM
            if (manana.SelectedValue == "7")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and ochom !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            ochoam.Text = txt_nombrePaciente.Text;
                            ochoam.BackColor = Color.DarkRed;
                            ochoam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET ochom='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                ochoam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            ochoam.Text = txt_nombrePaciente.Text;
                            ochoam.BackColor = Color.DarkRed;
                            ochoam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochom) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                ochoam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    ochoam.Text = txt_nombrePaciente.Text;
                    ochoam.BackColor = Color.DarkRed;
                    ochoam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochom) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        ochoam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
            //8:20 AM
            if (manana.SelectedValue == "8")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and ochoveintem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            ochoveinteam.Text = txt_nombrePaciente.Text;
                            ochoveinteam.BackColor = Color.DarkRed;
                            ochoveinteam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET ochoveintem='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                ochoveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            ochoveinteam.Text = txt_nombrePaciente.Text;
                            ochoveinteam.BackColor = Color.DarkRed;
                            ochoveinteam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochoveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                ochoveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    ochoveinteam.Text = txt_nombrePaciente.Text;
                    ochoveinteam.BackColor = Color.DarkRed;
                    ochoveinteam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochoveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        ochoveinteam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //8:40 AM
            if (manana.SelectedValue == "9")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and ochocuarentam !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            ochocuarentaam.Text = txt_nombrePaciente.Text;
                            ochocuarentaam.BackColor = Color.DarkRed;
                            ochocuarentaam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET ochocuarentam='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                ochocuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            ochocuarentaam.Text = txt_nombrePaciente.Text;
                            ochocuarentaam.BackColor = Color.DarkRed;
                            ochocuarentaam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochocuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                ochocuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    ochocuarentaam.Text = txt_nombrePaciente.Text;
                    ochocuarentaam.BackColor = Color.DarkRed;
                    ochocuarentaam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochocuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        ochocuarentaam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //9:00 AM
            if (manana.SelectedValue == "10")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and nuevem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            nueveam.Text = txt_nombrePaciente.Text;
                            nueveam.BackColor = Color.DarkRed;
                            nueveam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET nuevem='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                nueveam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            nueveam.Text = txt_nombrePaciente.Text;
                            nueveam.BackColor = Color.DarkRed;
                            nueveam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nuevem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                nueveam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    nueveam.Text = txt_nombrePaciente.Text;
                    nueveam.BackColor = Color.DarkRed;
                    nueveam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nuevem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        nueveam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //9:00 AM
            if (manana.SelectedValue == "10")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and nuevem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            nueveam.Text = txt_nombrePaciente.Text;
                            nueveam.BackColor = Color.DarkRed;
                            nueveam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET nuevem='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                nueveam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            nueveam.Text = txt_nombrePaciente.Text;
                            nueveam.BackColor = Color.DarkRed;
                            nueveam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nuevem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                nueveam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    nueveam.Text = txt_nombrePaciente.Text;
                    nueveam.BackColor = Color.DarkRed;
                    nueveam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nuevem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        nueveam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //9:20 AM
            if (manana.SelectedValue == "11")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and nueveveintem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            nueveveinteam.Text = txt_nombrePaciente.Text;
                            nueveveinteam.BackColor = Color.DarkRed;
                            nueveveinteam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET nueveveintem='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                nueveveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            nueveveinteam.Text = txt_nombrePaciente.Text;
                            nueveveinteam.BackColor = Color.DarkRed;
                            nueveveinteam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nueveveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                nueveveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    nueveveinteam.Text = txt_nombrePaciente.Text;
                    nueveveinteam.BackColor = Color.DarkRed;
                    nueveveinteam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nueveveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        nueveveinteam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //9:40 AM
            if (manana.SelectedValue == "12")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and nuevecuarentam !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            nuevecuarentaam.Text = txt_nombrePaciente.Text;
                            nuevecuarentaam.BackColor = Color.DarkRed;
                            nuevecuarentaam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET nuevecuarentam='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                nuevecuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            nuevecuarentaam.Text = txt_nombrePaciente.Text;
                            nuevecuarentaam.BackColor = Color.DarkRed;
                            nuevecuarentaam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nuevecuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                nuevecuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    nuevecuarentaam.Text = txt_nombrePaciente.Text;
                    nuevecuarentaam.BackColor = Color.DarkRed;
                    nuevecuarentaam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nuevecuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        nuevecuarentaam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //10:00 AM
            if (manana.SelectedValue == "13")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and diezm !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            diezam.Text = txt_nombrePaciente.Text;
                            diezam.BackColor = Color.DarkRed;
                            diezam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET diezm='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                diezam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            diezam.Text = txt_nombrePaciente.Text;
                            diezam.BackColor = Color.DarkRed;
                            diezam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, diezm) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                diezam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    diezam.Text = txt_nombrePaciente.Text;
                    diezam.BackColor = Color.DarkRed;
                    diezam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, diezm) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        diezam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //10:20 AM
            if (manana.SelectedValue == "14")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and diezveintem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            diezveinteam.Text = txt_nombrePaciente.Text;
                            diezveinteam.BackColor = Color.DarkRed;
                            diezveinteam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET diezveintem='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                diezveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            diezveinteam.Text = txt_nombrePaciente.Text;
                            diezveinteam.BackColor = Color.DarkRed;
                            diezveinteam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, diezveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                diezveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    diezveinteam.Text = txt_nombrePaciente.Text;
                    diezveinteam.BackColor = Color.DarkRed;
                    diezveinteam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, diezveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        diezveinteam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //10:40 AM
            if (manana.SelectedValue == "15")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and diezcuarentam !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            diezcuarentaam.Text = txt_nombrePaciente.Text;
                            diezcuarentaam.BackColor = Color.DarkRed;
                            diezcuarentaam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET diezcuarentam='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                diezcuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            diezcuarentaam.Text = txt_nombrePaciente.Text;
                            diezcuarentaam.BackColor = Color.DarkRed;
                            diezcuarentaam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, diezcuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                diezcuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    diezcuarentaam.Text = txt_nombrePaciente.Text;
                    diezcuarentaam.BackColor = Color.DarkRed;
                    diezcuarentaam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, diezcuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        diezcuarentaam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //11:00 AM
            if (manana.SelectedValue == "16")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and oncem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            onceam.Text = txt_nombrePaciente.Text;
                            onceam.BackColor = Color.DarkRed;
                            onceam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET oncem='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                onceam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            onceam.Text = txt_nombrePaciente.Text;
                            onceam.BackColor = Color.DarkRed;
                            onceam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, oncem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                onceam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    onceam.Text = txt_nombrePaciente.Text;
                    onceam.BackColor = Color.DarkRed;
                    onceam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, oncem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        onceam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //11:20 AM
            if (manana.SelectedValue == "17")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and onceveintem !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            onceveinteam.Text = txt_nombrePaciente.Text;
                            onceveinteam.BackColor = Color.DarkRed;
                            onceveinteam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET onceveinteam='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                onceveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            onceveinteam.Text = txt_nombrePaciente.Text;
                            onceveinteam.BackColor = Color.DarkRed;
                            onceveinteam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, onceveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                onceveinteam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    onceveinteam.Text = txt_nombrePaciente.Text;
                    onceveinteam.BackColor = Color.DarkRed;
                    onceveinteam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, onceveintem) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        onceveinteam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //11:40 AM
            if (manana.SelectedValue == "18")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and oncecuarentam !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            oncecuarentaam.Text = txt_nombrePaciente.Text;
                            oncecuarentaam.BackColor = Color.DarkRed;
                            oncecuarentaam.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET oncecuarentam='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                oncecuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            oncecuarentaam.Text = txt_nombrePaciente.Text;
                            oncecuarentaam.BackColor = Color.DarkRed;
                            oncecuarentaam.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, oncecuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                oncecuarentaam.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    oncecuarentaam.Text = txt_nombrePaciente.Text;
                    oncecuarentaam.BackColor = Color.DarkRed;
                    oncecuarentaam.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, oncecuarentam) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        oncecuarentaam.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //12:00 AM
            if (manana.SelectedValue == "19")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and docep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            docepm.Text = txt_nombrePaciente.Text;
                            docepm.BackColor = Color.DarkRed;
                            docepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET docep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                docepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            docepm.Text = txt_nombrePaciente.Text;
                            docepm.BackColor = Color.DarkRed;
                            docepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, docep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                docepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    docepm.Text = txt_nombrePaciente.Text;
                    docepm.BackColor = Color.DarkRed;
                    docepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, docep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        docepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //12:20 AM
            if (manana.SelectedValue == "20")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and doceveintep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            doceveintepm.Text = txt_nombrePaciente.Text;
                            doceveintepm.BackColor = Color.DarkRed;
                            doceveintepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET doceveintep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                doceveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            doceveintepm.Text = txt_nombrePaciente.Text;
                            doceveintepm.BackColor = Color.DarkRed;
                            doceveintepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, doceveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                doceveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    doceveintepm.Text = txt_nombrePaciente.Text;
                    doceveintepm.BackColor = Color.DarkRed;
                    doceveintepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, doceveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        doceveintepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
            //12:40 AM
            if (manana.SelectedValue == "21")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and docecuarentap !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            docecuarentapm.Text = txt_nombrePaciente.Text;
                            docecuarentapm.BackColor = Color.DarkRed;
                            docecuarentapm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET docecuarentap='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                docecuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            docecuarentapm.Text = txt_nombrePaciente.Text;
                            docecuarentapm.BackColor = Color.DarkRed;
                            docecuarentapm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, docecuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                docecuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    docecuarentapm.Text = txt_nombrePaciente.Text;
                    docecuarentapm.BackColor = Color.DarkRed;
                    docecuarentapm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, docecuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        docecuarentapm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
            //01:00 PM
            if (manana.SelectedValue == "22")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and unop !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            unopm.Text = txt_nombrePaciente.Text;
                            unopm.BackColor = Color.DarkRed;
                            unopm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET unop='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                unopm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            unopm.Text = txt_nombrePaciente.Text;
                            unopm.BackColor = Color.DarkRed;
                            unopm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, unop) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                unopm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    unopm.Text = txt_nombrePaciente.Text;
                    unopm.BackColor = Color.DarkRed;
                    unopm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, unop) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        unopm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //01:20 PM
            if (manana.SelectedValue == "23")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and unoveintep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            unoveintepm.Text = txt_nombrePaciente.Text;
                            unoveintepm.BackColor = Color.DarkRed;
                            unoveintepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET unoveintep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                unoveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            unoveintepm.Text = txt_nombrePaciente.Text;
                            unoveintepm.BackColor = Color.DarkRed;
                            unoveintepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, unoveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                unoveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    unoveintepm.Text = txt_nombrePaciente.Text;
                    unoveintepm.BackColor = Color.DarkRed;
                    unoveintepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, unoveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        unoveintepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //01:40 PM
            if (manana.SelectedValue == "24")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and unocuarentap !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            unocuarentapm.Text = txt_nombrePaciente.Text;
                            unocuarentapm.BackColor = Color.DarkRed;
                            unocuarentapm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET unocuarentap='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                unocuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            unocuarentapm.Text = txt_nombrePaciente.Text;
                            unocuarentapm.BackColor = Color.DarkRed;
                            unocuarentapm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, unocuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                unocuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    unocuarentapm.Text = txt_nombrePaciente.Text;
                    unocuarentapm.BackColor = Color.DarkRed;
                    unocuarentapm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, unocuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        unocuarentapm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
        }

        //JORNADA DE LA TARDE
        protected void tarde_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_CedulaPaciente.Text == string.Empty && txt_nombrePaciente.Text == string.Empty)
            {
                lbl_resultado.Text = "Debe buscar un paciente para continuar";
                return;
            }
            //SI NO SELECCIONO HORA
            if (tarde.SelectedValue.ToString() == "0")
            {
                lbl_resultado.Text = "Debe seleccionar una Hora";
                return;
            }
            //02:00 PM
            if (tarde.SelectedValue == "25")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and dosp !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            dospm.Text = txt_nombrePaciente.Text;
                            dospm.BackColor = Color.DarkRed;
                            dospm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET dosp='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                dospm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            dospm.Text = txt_nombrePaciente.Text;
                            dospm.BackColor = Color.DarkRed;
                            dospm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, dosp) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                dospm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    dospm.Text = txt_nombrePaciente.Text;
                    dospm.BackColor = Color.DarkRed;
                    dospm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, dosp) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        dospm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //02:20 PM
            if (tarde.SelectedValue == "26")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and dosveintep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            dosveintepm.Text = txt_nombrePaciente.Text;
                            dosveintepm.BackColor = Color.DarkRed;
                            dosveintepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET dosveintep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                dosveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            dosveintepm.Text = txt_nombrePaciente.Text;
                            dosveintepm.BackColor = Color.DarkRed;
                            dosveintepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, dosveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                dosveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    dosveintepm.Text = txt_nombrePaciente.Text;
                    dosveintepm.BackColor = Color.DarkRed;
                    dosveintepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, dosveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        dosveintepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //02:40 PM
            if (tarde.SelectedValue == "27")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and doscuarentap !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            doscuarentapm.Text = txt_nombrePaciente.Text;
                            doscuarentapm.BackColor = Color.DarkRed;
                            doscuarentapm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET doscuarentap='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                doscuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            doscuarentapm.Text = txt_nombrePaciente.Text;
                            doscuarentapm.BackColor = Color.DarkRed;
                            doscuarentapm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, doscuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                doscuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    doscuarentapm.Text = txt_nombrePaciente.Text;
                    doscuarentapm.BackColor = Color.DarkRed;
                    doscuarentapm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, doscuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        doscuarentapm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //03:00 PM
            if (tarde.SelectedValue == "28")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and tresp !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            trespm.Text = txt_nombrePaciente.Text;
                            trespm.BackColor = Color.DarkRed;
                            trespm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET tresp='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                trespm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            trespm.Text = txt_nombrePaciente.Text;
                            trespm.BackColor = Color.DarkRed;
                            trespm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, tresp) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                trespm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    trespm.Text = txt_nombrePaciente.Text;
                    trespm.BackColor = Color.DarkRed;
                    trespm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, tresp) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        trespm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //03:00 PM
            if (tarde.SelectedValue == "28")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and tresp !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            trespm.Text = txt_nombrePaciente.Text;
                            trespm.BackColor = Color.DarkRed;
                            trespm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET tresp='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                trespm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            trespm.Text = txt_nombrePaciente.Text;
                            trespm.BackColor = Color.DarkRed;
                            trespm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, tresp) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                trespm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    trespm.Text = txt_nombrePaciente.Text;
                    trespm.BackColor = Color.DarkRed;
                    trespm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, tresp) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        trespm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
            //03:20 PM
            if (tarde.SelectedValue == "29")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and tresveintep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            tresveintepm.Text = txt_nombrePaciente.Text;
                            tresveintepm.BackColor = Color.DarkRed;
                            tresveintepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET tresveintep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                tresveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            tresveintepm.Text = txt_nombrePaciente.Text;
                            tresveintepm.BackColor = Color.DarkRed;
                            tresveintepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, tresveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                tresveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    tresveintepm.Text = txt_nombrePaciente.Text;
                    tresveintepm.BackColor = Color.DarkRed;
                    tresveintepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, tresveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        tresveintepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
            //03:40 PM
            if (tarde.SelectedValue == "30")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and trescuarentap !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            trescuarentapm.Text = txt_nombrePaciente.Text;
                            trescuarentapm.BackColor = Color.DarkRed;
                            trescuarentapm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET trescuarentap='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                trescuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            trescuarentapm.Text = txt_nombrePaciente.Text;
                            trescuarentapm.BackColor = Color.DarkRed;
                            trescuarentapm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, trescuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                trescuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    trescuarentapm.Text = txt_nombrePaciente.Text;
                    trescuarentapm.BackColor = Color.DarkRed;
                    trescuarentapm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, trescuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        trescuarentapm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //04:00 PM
            if (tarde.SelectedValue == "31")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and cuatrop !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            cuatropm.Text = txt_nombrePaciente.Text;
                            cuatropm.BackColor = Color.DarkRed;
                            cuatropm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET cuatrop='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                cuatropm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            cuatropm.Text = txt_nombrePaciente.Text;
                            cuatropm.BackColor = Color.DarkRed;
                            cuatropm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cuatrop) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                cuatropm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    cuatropm.Text = txt_nombrePaciente.Text;
                    cuatropm.BackColor = Color.DarkRed;
                    cuatropm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cuatrop) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        cuatropm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //04:20 PM
            if (tarde.SelectedValue == "32")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and cuatroveintep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            cuatroveintepm.Text = txt_nombrePaciente.Text;
                            cuatroveintepm.BackColor = Color.DarkRed;
                            cuatroveintepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET cuatroveintep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                cuatroveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            cuatroveintepm.Text = txt_nombrePaciente.Text;
                            cuatroveintepm.BackColor = Color.DarkRed;
                            cuatroveintepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cuatroveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                cuatroveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    cuatroveintepm.Text = txt_nombrePaciente.Text;
                    cuatroveintepm.BackColor = Color.DarkRed;
                    cuatroveintepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cuatroveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        cuatroveintepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //04:40 PM
            if (tarde.SelectedValue == "33")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and cuatrocuarentap !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            cuatrocuarentapm.Text = txt_nombrePaciente.Text;
                            cuatrocuarentapm.BackColor = Color.DarkRed;
                            cuatrocuarentapm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET cuatrocuarentap='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                cuatrocuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            cuatrocuarentapm.Text = txt_nombrePaciente.Text;
                            cuatrocuarentapm.BackColor = Color.DarkRed;
                            cuatrocuarentapm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cuatrocuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                cuatrocuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    cuatrocuarentapm.Text = txt_nombrePaciente.Text;
                    cuatrocuarentapm.BackColor = Color.DarkRed;
                    cuatrocuarentapm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cuatrocuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        cuatrocuarentapm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //05:00 PM
            if (tarde.SelectedValue == "34")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and cincop !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            cincopm.Text = txt_nombrePaciente.Text;
                            cincopm.BackColor = Color.DarkRed;
                            cincopm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET cincop='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                cincopm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            cincopm.Text = txt_nombrePaciente.Text;
                            cincopm.BackColor = Color.DarkRed;
                            cincopm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cincop) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                cincopm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    cincopm.Text = txt_nombrePaciente.Text;
                    cincopm.BackColor = Color.DarkRed;
                    cincopm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cincop) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        cincopm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //05:20 PM
            if (tarde.SelectedValue == "35")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and cincoveintep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            cincoveintepm.Text = txt_nombrePaciente.Text;
                            cincoveintepm.BackColor = Color.DarkRed;
                            cincoveintepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET cincoveintep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                cincoveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            cincoveintepm.Text = txt_nombrePaciente.Text;
                            cincoveintepm.BackColor = Color.DarkRed;
                            cincoveintepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cincoveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                cincoveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    cincoveintepm.Text = txt_nombrePaciente.Text;
                    cincoveintepm.BackColor = Color.DarkRed;
                    cincoveintepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cincoveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        cincoveintepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
            //05:40 PM
            if (tarde.SelectedValue == "36")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and cincocuarentap !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            cincocuarentapm.Text = txt_nombrePaciente.Text;
                            cincocuarentapm.BackColor = Color.DarkRed;
                            cincocuarentapm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET cincocuarentap='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                cincocuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            cincocuarentapm.Text = txt_nombrePaciente.Text;
                            cincocuarentapm.BackColor = Color.DarkRed;
                            cincocuarentapm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cincocuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                cincocuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    cincocuarentapm.Text = txt_nombrePaciente.Text;
                    cincocuarentapm.BackColor = Color.DarkRed;
                    cincocuarentapm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, cincocuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        cincocuarentapm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
            //06:00 PM
            if (tarde.SelectedValue == "37")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and seisp !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            seispm.Text = txt_nombrePaciente.Text;
                            seispm.BackColor = Color.DarkRed;
                            seispm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET seisp='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                seispm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            seispm.Text = txt_nombrePaciente.Text;
                            seispm.BackColor = Color.DarkRed;
                            seispm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seisp) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                seispm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    seispm.Text = txt_nombrePaciente.Text;
                    seispm.BackColor = Color.DarkRed;
                    seispm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seisp) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        seispm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //06:20 PM
            if (tarde.SelectedValue == "38")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and seisveintep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            seisveintepm.Text = txt_nombrePaciente.Text;
                            seisveintepm.BackColor = Color.DarkRed;
                            seisveintepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET seisveintep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                seisveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            seisveintepm.Text = txt_nombrePaciente.Text;
                            seisveintepm.BackColor = Color.DarkRed;
                            seisveintepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seisveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                seisveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    seisveintepm.Text = txt_nombrePaciente.Text;
                    seisveintepm.BackColor = Color.DarkRed;
                    seisveintepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seisveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        seisveintepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //06:40 PM
            if (tarde.SelectedValue == "39")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and seiscuarentap !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            seiscuarentapm.Text = txt_nombrePaciente.Text;
                            seiscuarentapm.BackColor = Color.DarkRed;
                            seiscuarentapm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET seiscuarentap='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                seiscuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            seiscuarentapm.Text = txt_nombrePaciente.Text;
                            seiscuarentapm.BackColor = Color.DarkRed;
                            seiscuarentapm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seiscuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                seiscuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    seiscuarentapm.Text = txt_nombrePaciente.Text;
                    seiscuarentapm.BackColor = Color.DarkRed;
                    seiscuarentapm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, seiscuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        seiscuarentapm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //07:00 PM
            if (tarde.SelectedValue == "40")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and sietep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            sietepm.Text = txt_nombrePaciente.Text;
                            sietepm.BackColor = Color.DarkRed;
                            sietepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET sietep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                sietepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            sietepm.Text = txt_nombrePaciente.Text;
                            sietepm.BackColor = Color.DarkRed;
                            sietepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sietep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                sietepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    sietepm.Text = txt_nombrePaciente.Text;
                    sietepm.BackColor = Color.DarkRed;
                    sietepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sietep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        sietepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //07:20 PM
            if (tarde.SelectedValue == "41")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and sieteveintep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            sieteveintepm.Text = txt_nombrePaciente.Text;
                            sieteveintepm.BackColor = Color.DarkRed;
                            sieteveintepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET sieteveintep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                sieteveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            sieteveintepm.Text = txt_nombrePaciente.Text;
                            sieteveintepm.BackColor = Color.DarkRed;
                            sieteveintepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sieteveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                sieteveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    sieteveintepm.Text = txt_nombrePaciente.Text;
                    sieteveintepm.BackColor = Color.DarkRed;
                    sieteveintepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sieteveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        sieteveintepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
            //07:40 PM
            if (tarde.SelectedValue == "42")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and sietecuarentap !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            sietecuarentapm.Text = txt_nombrePaciente.Text;
                            sietecuarentapm.BackColor = Color.DarkRed;
                            sietecuarentapm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET sietecuarentap='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                sietecuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            sietecuarentapm.Text = txt_nombrePaciente.Text;
                            sietecuarentapm.BackColor = Color.DarkRed;
                            sietecuarentapm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sietecuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                sietecuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    sietecuarentapm.Text = txt_nombrePaciente.Text;
                    sietecuarentapm.BackColor = Color.DarkRed;
                    sietecuarentapm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, sietecuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        sietecuarentapm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }
            //08:00 PM
            if (tarde.SelectedValue == "43")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and ochop !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            ochopm.Text = txt_nombrePaciente.Text;
                            ochopm.BackColor = Color.DarkRed;
                            ochopm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET ochop='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                ochopm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            ochopm.Text = txt_nombrePaciente.Text;
                            ochopm.BackColor = Color.DarkRed;
                            ochopm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochop) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                ochopm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    ochopm.Text = txt_nombrePaciente.Text;
                    ochopm.BackColor = Color.DarkRed;
                    ochopm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochop) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        ochopm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //08:20 PM
            if (tarde.SelectedValue == "44")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and ochoveintep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            ochoveintepm.Text = txt_nombrePaciente.Text;
                            ochoveintepm.BackColor = Color.DarkRed;
                            ochoveintepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET ochoveintep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                ochoveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            ochoveintepm.Text = txt_nombrePaciente.Text;
                            ochoveintepm.BackColor = Color.DarkRed;
                            ochoveintepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochoveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                ochoveintepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    ochoveintepm.Text = txt_nombrePaciente.Text;
                    ochoveintepm.BackColor = Color.DarkRed;
                    ochoveintepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochoveintep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        ochoveintepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //08:40 PM
            if (tarde.SelectedValue == "45")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and ochocuarentap !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            ochocuarentapm.Text = txt_nombrePaciente.Text;
                            ochocuarentapm.BackColor = Color.DarkRed;
                            ochocuarentapm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET ochocuarentap='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                ochocuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            ochocuarentapm.Text = txt_nombrePaciente.Text;
                            ochocuarentapm.BackColor = Color.DarkRed;
                            ochocuarentapm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochocuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                ochocuarentapm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    ochocuarentapm.Text = txt_nombrePaciente.Text;
                    ochocuarentapm.BackColor = Color.DarkRed;
                    ochocuarentapm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, ochocuarentap) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        ochocuarentapm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }

            //09:00 PM
            if (tarde.SelectedValue == "46")
            {
                if (Existedia((CalendarCita.SelectedDate.ToString("MM/dd/yyyy"))))
                {
                    string sql3 = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and nuevep !='' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                    if (Datos.verificarcita(sql3))
                    {
                        Response.Write("<script>alert('" + "Ya existe una cita asignada para esa hora" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                    else
                    {
                        string sqlprof = "SELECT COUNT(*) FROM Cita WHERE prof_codigo='" + this.ddl_profesionales.SelectedValue + "' and fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and CodEntidad='" + this.ddl_ips.SelectedValue + "'";
                        if (Datos.verificarcita(sqlprof))
                        {
                            nuevepm.Text = txt_nombrePaciente.Text;
                            nuevepm.BackColor = Color.DarkRed;
                            nuevepm.ForeColor = Color.White;

                            string sqlupdate = "UPDATE Cita SET nuevep='" + this.txt_nombrePaciente.Text + "', CodEntidad='" + this.ddl_ips.SelectedValue + "', cliente_name ='" + this.txt_nombrePaciente.Text + "' where fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' and prof_codigo='" + this.ddl_profesionales.SelectedValue + "'";
                            if (Datos.insertarempresa(sqlupdate))
                            {
                                nuevepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;
                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                        else
                        {
                            nuevepm.Text = txt_nombrePaciente.Text;
                            nuevepm.BackColor = Color.DarkRed;
                            nuevepm.ForeColor = Color.White;
                            DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                            string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nuevep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                            if (Datos.insertarempresa(sql))
                            {
                                nuevepm.Text = "";
                                Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                                CalendarCita.DataBind();
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty;
                                manana.ClearSelection();
                                tarde.ClearSelection();
                                txt_fechaCita.Text = string.Empty;

                            }
                            else
                            {
                                Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                                txt_CedulaPaciente.Text = string.Empty;
                                txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                                manana.ClearSelection();
                                tarde.ClearSelection();

                            }
                        }
                    }

                }
                else
                {
                    nuevepm.Text = txt_nombrePaciente.Text;
                    nuevepm.BackColor = Color.DarkRed;
                    nuevepm.ForeColor = Color.White;
                    DateTime Hoy = Convert.ToDateTime(txt_fechaDias.Text);
                    string sql = "insert into Cita (CodEntidad, prof_nombre, prof_codigo, cliente_name, cliente_documento, hora_sistema, fecha_cita, nuevep) VALUES ('" + this.ddl_ips.SelectedValue + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.ddl_profesionales.SelectedValue + "', '" + this.txt_nombrePaciente.Text + "', '" + this.txt_CedulaPaciente.Text + "', '" + Hoy + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.txt_nombrePaciente.Text + "')";
                    if (Datos.insertarempresa(sql))
                    {
                        nuevepm.Text = "";
                        Response.Write("<script>alert('" + "Error al almacenar Cita" + "');</script>");
                        CalendarCita.DataBind();
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty;
                        manana.ClearSelection();
                        tarde.ClearSelection();
                        txt_fechaCita.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('" + "Cita Almacenada Correctamente" + "');</script>");
                        txt_CedulaPaciente.Text = string.Empty;
                        txt_nombrePaciente.Text = string.Empty; manana.ClearSelection();
                        manana.ClearSelection();
                        tarde.ClearSelection();

                    }
                }
            }


        }

        //ELIMINAR CITAS
        protected void btn_delete60_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET seism='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                seisam.Text = "";
                seisam.BackColor = Color.Green;
            }
        }

        protected void btn_delete62_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET seisveintem='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                seisveinteam.Text = "";
                seisveinteam.BackColor = Color.Green;
            }
        }

        protected void btn_delete64_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET seiscuarentam='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                seiscuarentaam.Text = "";
                seiscuarentaam.BackColor = Color.Green;
            }
        }

        protected void btn_delete70_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET sietem='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                sieteam.Text = "";
                sieteam.BackColor = Color.Green;
            }
        }

        protected void btn_delete72_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET sieteveintem='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                sieteveinteam.Text = "";
                sieteveinteam.BackColor = Color.Green;
            }
        }

        protected void btn_delete74_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET sietecuarentam='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                sietecuarentaam.Text = "";
                sietecuarentaam.BackColor = Color.Green;
            }
        }

        protected void btn_delete80_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET ochom='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                ochoam.Text = "";
                ochoam.BackColor = Color.Green;
            }
        }

        protected void btn_delete82_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET ochoveintem='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                ochoveinteam.Text = "";
                ochoveinteam.BackColor = Color.Green;
            }
        }

        protected void btn_delete84_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET ochocuarentam='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                ochocuarentaam.Text = "";
                ochocuarentaam.BackColor = Color.Green;
            }
        }

        protected void btn_delete90_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET nuevem='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                nueveam.Text = "";
                nueveam.BackColor = Color.Green;
            }
        }

        protected void btn_delete92_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET nueveveintem='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                nueveveinteam.Text = "";
                nueveveinteam.BackColor = Color.Green;
            }
        }

        protected void btn_delete94_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET nuevecuarentam='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                nuevecuarentaam.Text = "";
                nuevecuarentaam.BackColor = Color.Green;
            }
        }

        protected void btn_delete1000_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET diezm='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                diezam.Text = "";
                diezam.BackColor = Color.Green;
            }
        }

        protected void btn_delete1020_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET diezveintem='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                diezveinteam.Text = "";
                diezveinteam.BackColor = Color.Green;
            }
        }

        protected void btn_delete1040_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET diezcuarentam='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                diezcuarentaam.Text = "";
                diezcuarentaam.BackColor = Color.Green;
            }
        }

        protected void btn_delete1100_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET oncem='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                onceam.Text = "";
                onceam.BackColor = Color.Green;
            }
        }

        protected void btn_delete1120_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET onceveintem='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                onceveinteam.Text = "";
                onceveinteam.BackColor = Color.Green;
            }
        }

        protected void btn_delete1140_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET oncecuarentam='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                oncecuarentaam.Text = "";
                oncecuarentaam.BackColor = Color.Green;
            }
        }

        protected void btn_delete1200_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET docep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                docepm.Text = "";
                docepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete1220_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET doceveintep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                doceveintepm.Text = "";
                doceveintepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete1240_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET docecuarentap='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedItem + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                docecuarentapm.Text = "";
                docecuarentapm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0100_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET unop='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                unopm.Text = "";
                unopm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0120_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET unoveintep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                unoveintepm.Text = "";
                unoveintepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0140_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET unocuarentap='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                unocuarentapm.Text = "";
                unocuarentapm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0200_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET dosp='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                dospm.Text = "";
                dospm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0220_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET dosveintep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                dosveintepm.Text = "";
                dosveintepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0240_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET doscuarentap='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                doscuarentapm.Text = "";
                doscuarentapm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0300_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET tresp='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                trespm.Text = "";
                trespm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0320_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET tresveintep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                tresveintepm.Text = "";
                tresveintepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0340_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET trescuarentap='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                trescuarentapm.Text = "";
                trescuarentapm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0400_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET cuatrop='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                cuatropm.Text = "";
                cuatropm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0420_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET cuatroveintep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                cuatroveintepm.Text = "";
                cuatroveintepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0440_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET cuatrocuarentap='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                cuatrocuarentapm.Text = "";
                cuatrocuarentapm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0500_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET cincop='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                cincopm.Text = "";
                cincopm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0520_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET cincoveintep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                cincoveintepm.Text = "";
                cincoveintepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0540_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET cincocuarentap='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                cincocuarentapm.Text = "";
                cincocuarentapm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0600_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET seisp='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                seispm.Text = "";
                seispm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0620_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET seisveintep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                seisveintepm.Text = "";
                seisveintepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0640_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET seiscuarentap='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                seiscuarentapm.Text = "";
                seiscuarentapm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0700_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET sietep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                sietepm.Text = "";
                sietepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0720_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET sieteveintep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                sieteveintepm.Text = "";
                sieteveintepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0740_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET sietecuarentap='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                sietecuarentapm.Text = "";
                sietecuarentapm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0800_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET ochop='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                ochopm.Text = "";
                ochopm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0820_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET ochoveintep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                ochoveintepm.Text = "";
                ochoveintepm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0840_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET ochocuarentap='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                ochocuarentapm.Text = "";
                ochocuarentapm.BackColor = Color.Green;
            }
        }

        protected void btn_delete0900_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "UPDATE Cita SET nuevep='' WHERE CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "' ";
            if (Datos.insertarempresa(sql))
            {

                Response.Write("<script>alert('" + "No se pudo eliminar la Cita, Verifique" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
            }
            else
            {
                Response.Write("<script>alert('" + "Cita Eliminada Correctamente" + "');</script>");
                manana.ClearSelection();
                tarde.ClearSelection();
                nuevepm.Text = "";
                nuevepm.BackColor = Color.Green;
            }
        }

        private void ImprimirCita(string sql)
        {
            string id = "PDF"; // get this from another control on your page
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reportes"), "Cita.rdlc");
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

            ReportDataSource rd = new ReportDataSource("DataSetCitas", dt);
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
            Response.AddHeader("content-disposition", "attachment; filename= Cita" + cedulapaciente.Text + "." + fileNameExtension);
            Response.BinaryWrite(renderedBytes);

            Response.End();
        }

        protected void btn_imprimir600_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE seism='" + this.seisam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["seism"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m60.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir620_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE seisveintem='" + this.seisveinteam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["seisveintem"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m62.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir640_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE seiscuarentam='" + this.seiscuarentaam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["seiscuarentam"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m64.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir700_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE sietem='" + this.sieteam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["sietem"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m70.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir720_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE sieteveintem='" + this.sieteveinteam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["sieteveintem"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m72.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir740_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE sietecuarentam='" + this.sietecuarentaam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["sietecuarentam"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m74.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir800_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE ochom='" + this.ochoam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["ochom"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m80.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir820_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE ochoveintem='" + this.ochoveinteam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["ochoveintem"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m82.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir840_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE ochocuarentam='" + this.ochocuarentaam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["ochocuarentam"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m84.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir900_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE nuevem='" + this.nueveam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["nuevem"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m90.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir920_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE nueveveintem='" + this.nueveveinteam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["nueveveintem"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m92.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir940_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE nuevecuarentam='" + this.nuevecuarentaam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["nuevecuarentam"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m94.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir1000_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE diezm='" + this.diezam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["diezm"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m100.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir1020_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE diezveintem='" + this.diezveinteam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["diezveintem"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m102.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir1040_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE diezcuarentam='" + this.diezcuarentaam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["diezcuarentam"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m104.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir1100_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE oncem='" + this.onceam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["oncem"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m110.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir1120_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE onceveintem='" + this.onceveinteam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["onceveintem"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m120.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir1140_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE oncecuarentam='" + this.oncecuarentaam.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["oncecuarentam"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m114.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir1200_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE docep='" + this.docepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["docep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m120.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir1220_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE doceveintep='" + this.doceveintepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["doceveintep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m122.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir1240_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE docecuarentap='" + this.docecuarentapm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["docecuarentap"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m124.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0100_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE unop='" + this.unopm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["unop"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m010.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0120_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE unoveintep='" + this.unoveintepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["unoveintep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m012.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0140_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE unocuarentap='" + this.unocuarentapm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["unocuarentap"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m014.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0200_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE dosp='" + this.dospm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["dosp"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m020.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0220_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE dosveintep='" + this.dosveintepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["dosveintep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m022.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0240_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE doscuarentap='" + this.doscuarentapm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["doscuarentap"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m024.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0300_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE tresp='" + this.trespm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["tres"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m030.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0320_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE tresveintep='" + this.tresveintepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["tresveintep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m032.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0340_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE trescuarentap='" + this.trescuarentapm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["trescuarentap"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m034.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0400_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE cuatrop='" + this.cuatropm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["cuatrop"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m040.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0420_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE cuatroveintep='" + this.cuatroveintepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["cuatroveintep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m042.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0440_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE cuatrocuarentap='" + this.cuatrocuarentapm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["cuatrocuarentap"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m044.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0500_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE cincop='" + this.cincopm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["cincop"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m050.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0520_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE cincoveintep='" + this.cincoveintepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["cincoveintep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m052.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void btn_imprimir0540_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE cincocuarentap='" + this.cincocuarentapm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["cincocuarentap"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m054.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE seisp='" + this.seispm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["seisp"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m060.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE seisveintep='" + this.seisveintepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["seisveintep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m062.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE seiscuarentap='" + this.seiscuarentapm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["seiscuarentap"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m064.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE sietep='" + this.sietepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["sietep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m070.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE sieteveintep='" + this.sieteveintepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["sieteveintep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m072.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE sietecuarentap='" + this.sietecuarentapm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["sietecuarentap"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m074.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE ochop='" + this.ochopm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["ochop"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m080.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE ochoveintep='" + this.ochoveintepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["ochoveintep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m082.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton9_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE ochocuarentap='" + this.ochocuarentapm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["ochocuarentap"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m084.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }

        protected void ImageButton10_Click(object sender, ImageClickEventArgs e)
        {
            string sql = "DELETE FROM CitasAuxiliar";
            if (Datos.insertar(sql))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string query = "SELECT * FROM Cita WHERE nuevep='" + this.nuevepm.Text + "' AND CodEntidad='" + this.ddl_ips.SelectedValue + "' AND prof_codigo='" + this.ddl_profesionales.SelectedValue + "' AND fecha_cita='" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "'";
                SqlConnection conexion = new SqlConnection(ruta);
                SqlCommand comandoA = new SqlCommand(query, conexion);
                conexion.Open();

                SqlDataReader leerA = comandoA.ExecuteReader();

                if (leerA.Read() == true)
                {
                    cedulapaciente.Text = leerA["cliente_documento"].ToString();
                    nombrepaciente.Text = leerA["nuevep"].ToString();
                }
                else
                {
                    lbl_resultado.Text = "No se Encontraron citas para imprimir";
                    return;
                }
                conexion.Close();

            }

            //IMPRIMIR LA CITA. PRIMERO INSERTAMOS EN LA TABLA LA INFO A IMPRIMIR
            string insertar = "INSERT INTO CitasAuxiliar (PacienteNombre, FechaCita, HoraCita, ips, profesional, PacienteCedula) VALUES('" + this.nombrepaciente.Text + "', '" + this.CalendarCita.SelectedDate.ToString("MM/dd/yyyy") + "', '" + this.m090.Text + "', '" + this.ddl_ips.SelectedItem + "', '" + this.ddl_profesionales.SelectedItem + "', '" + this.cedulapaciente.Text + "')";
            if (Datos.insertar(insertar))
            {
                lbl_resultado.Text = "Error al imprimir la cita";
                return;
            }
            else
            {
                string imprimir = "SELECT * FROM CitasAuxiliar";
                ImprimirCita(imprimir);
            }
        }




    }
}