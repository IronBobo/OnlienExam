using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_TestBtn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>alert('ttt');</script>", true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

       // this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>countDown_Show();</script>");
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "", "<script>aa();</script>");
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "myscript", myscript, true);
    }
}   