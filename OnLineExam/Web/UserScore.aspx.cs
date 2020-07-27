using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OnLineExamBLL;
using OnLineExamModel;
using OnLineExamDAL;
using System.IO;
using System.Data.OleDb;
using System.Collections.Generic;
public partial class Web_UserScore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "成绩管理";
        if (!Page.IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string userId = Session["userID"].ToString();
                string userName = UserManager.GetUserName(userId);
                Label i1 = (Label)Page.Master.FindControl("labUser");
                i1.Text = userName;

                if (!RoleManager.IsHasDuty(userName, "HasDuty_UserPaperList"))
                {
                    Response.Redirect("noDuty.aspx");
                }
                //GridView1.DataSource = UserManager.selectAlls();
                //GridView1.DataBind();
                else
                {
                    DropDownList1.Items.Clear();
                    Scores sc = new Scores();
                    List<Scores> list = UserManager.selectAlls();
                    for (int i = 0; i < list.Count; i++)
                    {
                        ListItem item = new ListItem(list[i].PaperName.ToString(), list[i].PaperID.ToString());
                        DropDownList1.Items.Add(item);
                    }
                }
            }
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string userID = "";
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
            if (isChecked)
            {
                userID = ((Label)GridView1.Rows[i].FindControl("lblUserID")).Text;
            }
        }
        if (userID == "")
        {
            Label12.Text = "请选中要删除项！";
        }
        else
        {
            if (UserService.delScores(userID))//根据主键使用delScores方法删除用户
            {

                GridView1.DataSource = UserManager.selectAlls();
                GridView1.DataBind();
                Label12.Text = "删除成功！";
            }
            else
            {
                Response.Write("<script language=javascript>alert('" + userID + "删除失败!')</script>");
            }
        }

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        //生成将要存放结果的Excel文件的名称
        string NewFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
        //转换为物理路径
        NewFileName = Server.MapPath(NewFileName);
        //根据模板正式生成该Excel文件
        File.Copy(Server.MapPath("Module01.xlsx"), NewFileName, true);
        //建立指向该Excel文件的数据库连接
        //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + NewFileName + ";Extended Properties='Excel 8.0;'";
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + NewFileName + ";Extended Properties='Excel 12.0;'";
        OleDbConnection Conn = new OleDbConnection(strConn);
        //打开连接，为操作该文件做准备
        Conn.Open();
        OleDbCommand Cmd = new OleDbCommand("", Conn);

        //if (f)
        //{
        foreach (GridViewRow DR in GridView1.Rows)
        {
            int a = DR.Cells.Count;


            string XSqlString = "insert into [Sheet1$]";
            XSqlString += "([用户编号],[用户姓名],[试卷编号],[试卷名称],[成绩],[考试时间]) values(";
            XSqlString += "'" + (DR.Cells[0].FindControl("lblUserID") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[1].FindControl("lblUserName") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[2].FindControl("Label11") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[3].FindControl("Lbl_sjmc") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[4].FindControl("Label4") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[5].FindControl("Label5") as Label).Text + "')";
            Cmd.CommandText = XSqlString;
            Cmd.ExecuteNonQuery();
        }
        //}


        //操作结束，关闭连接
        Conn.Close();
        //打开要下载的文件，并把该文件存放在FileStream中
        System.IO.FileStream Reader = System.IO.File.OpenRead(NewFileName);
        //文件传送的剩余字节数：初始值为文件的总大小
        long Length = Reader.Length;

        Response.Buffer = false;
        Response.AddHeader("Connection", "Keep-Alive");
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("考生成绩.xlsx"));
        Response.AddHeader("Content-Length", Length.ToString());

        byte[] Buffer = new Byte[10000];		//存放欲发送数据的缓冲区
        int ByteToRead;											//每次实际读取的字节数

        while (Length > 0)
        {
            //剩余字节数不为零，继续传送
            if (Response.IsClientConnected)
            {
                //客户端浏览器还打开着，继续传送
                ByteToRead = Reader.Read(Buffer, 0, 10000);					//往缓冲区读入数据
                Response.OutputStream.Write(Buffer, 0, ByteToRead);	//把缓冲区的数据写入客户端浏览器
                Response.Flush();																		//立即写入客户端
                Length -= ByteToRead;																//剩余字节数减少
            }
            else
            {
                //客户端浏览器已经断开，阻止继续循环
                Length = -1;
            }
        }

        //关闭该文件
        Reader.Close();
        //删除该Excel文件
        File.Delete(NewFileName);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string PaperID = DropDownList1.SelectedValue;
        //GridView1.DataSource = UserManager.selectAllScore(PaperID);
        //GridView1.DataBind();

        this.GridView1.DataSourceID = null;
        string selectvaule = this.DropDownList1.SelectedValue;
        this.GridView1.DataSource = UserManager.selectAllScore(selectvaule);
        this.GridView1.DataBind();
    }

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = RadioButton1.Checked;
        }
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            if (((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked == true)
            {
                ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = false;
            }
            else
            {
                ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked = true;
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#cbe2fa'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void ImageButton2_Click1(object sender, EventArgs e)
    {
        //生成将要存放结果的Excel文件的名称
        string NewFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
        //转换为物理路径
        NewFileName = Server.MapPath(NewFileName);
        //根据模板正式生成该Excel文件
        File.Copy(Server.MapPath("Module01.xlsx"), NewFileName, true);
        //建立指向该Excel文件的数据库连接
        //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + NewFileName + ";Extended Properties='Excel 8.0;'";
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + NewFileName + ";Extended Properties='Excel 12.0;'";
        OleDbConnection Conn = new OleDbConnection(strConn);
        //打开连接，为操作该文件做准备
        Conn.Open();
        OleDbCommand Cmd = new OleDbCommand("", Conn);

        //if (f)
        //{
        foreach (GridViewRow DR in GridView1.Rows)
        {
            int a = DR.Cells.Count;


            string XSqlString = "insert into [Sheet1$]";
            XSqlString += "([用户编号],[用户姓名],[试卷编号],[试卷名称],[成绩],[考试时间]) values(";
            XSqlString += "'" + (DR.Cells[0].FindControl("lblUserID") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[1].FindControl("lblUserName") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[2].FindControl("Label11") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[3].FindControl("Lbl_sjmc") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[4].FindControl("Label4") as Label).Text + "',";
            XSqlString += "'" + (DR.Cells[5].FindControl("Label5") as Label).Text + "')";
            Cmd.CommandText = XSqlString;
            Cmd.ExecuteNonQuery();
        }
        //}


        //操作结束，关闭连接
        Conn.Close();
        //打开要下载的文件，并把该文件存放在FileStream中
        System.IO.FileStream Reader = System.IO.File.OpenRead(NewFileName);
        //文件传送的剩余字节数：初始值为文件的总大小
        long Length = Reader.Length;

        Response.Buffer = false;
        Response.AddHeader("Connection", "Keep-Alive");
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode("考生成绩.xlsx"));
        Response.AddHeader("Content-Length", Length.ToString());

        byte[] Buffer = new Byte[10000];		//存放欲发送数据的缓冲区
        int ByteToRead;											//每次实际读取的字节数

        while (Length > 0)
        {
            //剩余字节数不为零，继续传送
            if (Response.IsClientConnected)
            {
                //客户端浏览器还打开着，继续传送
                ByteToRead = Reader.Read(Buffer, 0, 10000);					//往缓冲区读入数据
                Response.OutputStream.Write(Buffer, 0, ByteToRead);	//把缓冲区的数据写入客户端浏览器
                Response.Flush();																		//立即写入客户端
                Length -= ByteToRead;																//剩余字节数减少
            }
            else
            {
                //客户端浏览器已经断开，阻止继续循环
                Length = -1;
            }
        }

        //关闭该文件
        Reader.Close();
        //删除该Excel文件
        File.Delete(NewFileName);
    }
}
