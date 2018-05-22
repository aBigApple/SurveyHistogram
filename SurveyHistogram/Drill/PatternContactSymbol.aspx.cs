using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUITest.Drill
{
    public partial class PatternContectSymbol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string param1 = Request.QueryString["param1"];

            if (!String.IsNullOrEmpty(param1))
            {
                TextBox1.Text = param1;
            }

            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(TextBox1.Text, TextBox1.Text + " - 第二个值") + ActiveWindow.GetHideReference());
        }

        protected void btnClosePostBack_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
    }
}