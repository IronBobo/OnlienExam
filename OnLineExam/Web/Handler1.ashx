<%@ WebHandler Language="C#" Class="OnlineExam.Handler1" %>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OnlineExam
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        //string str;
        string strC;
        string read;
        string[] sArrayok;
        string[] sArray;
        public void ProcessRequest(HttpContext context)
        {
            //string strOutput2 = "hello world";
            string strOutput2;
            context.Response.ContentType = "text/html;charset=utf-8";
            
            //str = context.Request.Form["txt"];
            strC = context.Request.Form["C"];
            System.IO.File.WriteAllText("C:/Users/Derrick.Deep/Desktop/gcc/gcc/bin/test.c", strC);
            //Console.WriteLine(str);

            strOutput2 = prc();
            strOutput2 = prc();
            if (read == "")
            {
                sArray = strOutput2.Split(new string[] { "a.exe" }, StringSplitOptions.RemoveEmptyEntries);
                sArrayok = sArray[1].Split(new string[] { "C:" }, StringSplitOptions.RemoveEmptyEntries);
                context.Response.Write("你的程序结果为：" + sArrayok[0]);
            }else
            {
            //prc();
            //TextBox TextBox1 = new TextBox();
            //TextBox1.AppendText(sArrayok);
            context.Response.Write("你的程序结果为："+read);
            }
            
        }


       public  string prc()
        {
            //string strOutput;
            //string _strName = str;
            /*Process prc = new Process();
            prc.StartInfo.FileName = "C:/Users/Derrick.Deep/AppData/Local/Google/Chrome/Application/chrome.exe";
            prc.StartInfo.FileName = "cmd.exe";
            prc.StartInfo.Arguments = "F:/c/"+_strName+".exe";
            //prc.StartInfo.Arguments = _strName;
            //prc.StartInfo.WorkingDirectory = "C:/Users/Derrick.Deep/Desktop/gcc/gcc/bin";
            prc.StartInfo.UseShellExecute = false;
            prc.StartInfo.RedirectStandardInput = true;
            prc.StartInfo.RedirectStandardOutput = true;
            prc.StartInfo.RedirectStandardError = true;
            prc.StartInfo.CreateNoWindow = false;
            prc.Start();*/
            Process p = new Process(); 
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = "C:/Users/Derrick.Deep/Desktop/gcc/gcc/bin";
            p.StartInfo.UseShellExecute = false; 
            p.StartInfo.RedirectStandardInput = true; 
            p.StartInfo.RedirectStandardOutput = true; 
            p.StartInfo.CreateNoWindow = false; 
            p.Start(); //向cmd.exe输入command 

            p.StandardInput.WriteLine("gcc "+"test.c>;1.txt 2>;2.txt");
            read = System.IO.File.ReadAllText("C:/Users/Derrick.Deep/Desktop/gcc/gcc/bin/2.txt");

            if (read == "")
            {
                p.StandardInput.WriteLine("a.exe");
                p.StandardInput.WriteLine("exit"); //需要有这句，不然程序会挂机
            }
            else
            { p.StandardInput.WriteLine("exit"); }
            string output = p.StandardOutput.ReadToEnd(); 
            //这句可以用来获取执行命令的输出结果
            //p.StandardInput.WriteLine("exit");
            //strOutput = prc.StandardOutput.ReadToEnd();
            //prc.Close();

            return output;    
           

        } 



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }



        public char strOutput { get; set; }
    }
}