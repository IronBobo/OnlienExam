<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>慧联考试系统</title>
    <link href='../bootstrap/css/bootstrap-ie6.css' rel="stylesheet" type="text/css" />  
    <link href='../bootstrap/css/bootstrap.css' rel="stylesheet" type="text/css" />
    <link href='../bootstrap/css/ie.css' rel="stylesheet" type="text/css" />
        <style type="text/css">
            div.RoundedCorner{background: #BAD4F7; width:350px;}
            b.rtop, b.rbottom{display:block;background: #FFF}
            b.rtop b, b.rbottom b{display:block;height: 1px;overflow: hidden; background: #BAD4F7}
            b.r1{margin: 0 5px}
            b.r2{margin: 0 3px}
            b.r3{margin: 0 2px}
            b.rtop b.r4, b.rbottom b.r4{margin: 0 1px;height: 2px}
            table.content{border:0px;height:100px; font-family:Tahoma; font-size:9.5pt;color:#363A36;}
            body
            {
                topmargin="0";
                bottommargin="0"; 
                leftmargin="0"; 
                rightmargin="0";
                font-size:17.5px;
            }
            #cbxRemeberUser {
                float:inherit;
            }
            label {
                /*float:right !important;*/
               
            }
            .container {
                width:100% !important;
            }
            .form-signin {
                /*background-color: #fff;
                border: 1px solid #e5e5e5;
                border-radius: 5px;
                box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05);*/
                margin: 0 auto 20px;
                max-width: 300px;
                padding: 19px 29px 29px;
            }
            h4 {
                font-size:31.5px;
            }
</style>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="imgBtnLogin">
    <div align="center"><br /><br /><br /><br /><br /><br /><br />
    <div class="container" style="background-image:url('../Images/bgrod.png') ;background-size:100%;">
 
        <div style="text-align:center;width:100%;margin-top:40px;"><img src="<%=ResolveClientUrl("../Images/logo2.png")%>"/><font color="#4D2600"><h4 style="font-family: 宋体;font-weight:bold;">慧联考试系统</h4></font></div>
              <table class="form-signin" >						
				<tr style="line-height:70px;">
					<td height="30" align="center" width=80>帐 &nbsp;号：</td>
					<td height="30"><div align="left">						
							<asp:TextBox id="txtUserID" runat="server" MaxLength="20" Width="150px" CssClass="input-block-level" placeholder="账号"></asp:TextBox>   
                        </div>                   
                       </td>
                       <td>
                           
                       </td>
				</tr>
				<TR>
					<TD align="center" height="30">密 &nbsp;码：</TD>
					<TD height="30"><div align="left">
						<asp:TextBox id="txtPwd"  runat="server" MaxLength="20" TextMode="Password" Width="150px"  CssClass="input-block-level"  placeholder="密码" ></asp:TextBox>
                       </div>
                    </TD>
                    <td>
                      <div align="center">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd"
                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                      </div>
                    </td>
				</TR>
                    <tr>
                        <td></td>
                        <td colspan="1">
                            <div align="left" >
                                <asp:CheckBox ID="cbxRemeberUser" runat="server" Text="记住用户名" Checked="True" CssClass="checkbox"  /> 
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserID"  ErrorMessage="不能为空！"></asp:RequiredFieldValidator>

                           </div>
                        </td>
                    </tr>
				<tr height=50>
					<td align=center colspan="3">
                        <asp:Label ID="lblMessage" runat="server" ForeColor=red></asp:Label>						
                        <asp:Button ID="imgBtnLogin" runat="server" Text="登  录"   CssClass="btn btn-large btn-primary" OnClick="imgBtnLogin_Click1"/>
					</td>
				</tr>
      <!--            <tr><td colspan="3" style="font-size:13px;text-align:center;">建议使用<a href="../download/firefox.zip" style="">火狐浏览器</a></td></tr>-->
			</table>
         
    </div>
    </div>
    </form>
</body>
</html>
