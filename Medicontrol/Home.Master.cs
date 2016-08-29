using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicontrol
{
    public partial class Home : System.Web.UI.MasterPage
    {
        string Cargo, Codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Login"] != null)
            {
                UserName.Text = " " + Request.Cookies["Login"]["name"].ToString();
                Codigo = Request.Cookies["Login"]["ID"].ToString();
                Cargo = Request.Cookies["Login"]["tipousuario"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btn_salir_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Login");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);

            Response.Redirect("Login.aspx");
        }
    }
}