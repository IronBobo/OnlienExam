<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentIndex.aspx.cs" Inherits="Web_StudentIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>慧联考试系统</title>

    <script src="../JS/Morning_JS.js" type="text/javascript"></script>

    <link href="../CSS/CSS.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0px" onload="showTime();">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="250px">
        <tr>
            <td style="height: 4px;" colspan="3">
                <img src="../Images/logo.jpg" style="height:30px; left: 0px; position: relative;top: 0px;" title="" width="100%" />
            </td>
        </tr>
        <tr style="background: url(../Images/lineS2.jpg) repeat-x;">
            <td style="height: 25px;" colspan="3">
                &nbsp;&nbsp;&nbsp;欢迎您：<asp:Label ID="labUser" runat="server" Text="Label" Width="70px" style="margin-bottom:7px;margin-top:4px;"></asp:Label>&nbsp;&nbsp;姓名：<asp:Label
                    ID="lblName" runat="server" Text="Label" Width="70px"></asp:Label>

                <script type="text/javascript">                    getDate();</script>

                <span id="ShowTime"></span>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="exit" runat="server" CausesValidation="false" OnClick="exit_Click"
                    PostBackUrl="~/Web/Login.aspx">退出系统</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" border="1" bordercolor="#cccccc" style="border-collapse: collapse;margin-top:4px;"
                    width="100%" frame="below">
                    <tr>
                        <td bgcolor="#EDF1F6" style="text-align: right; width: 100%;" colspan="2">
                            <div class="title" align="left">
                                <h4 style="font-family: 楷体_GB2312">
                                    考试</h4>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#EDF1F6" style="text-align: right;">
                            科目：
                        </td>
                        <td>
                            
                            
                            <div align="left">
                                <asp:DropDownList ID="ddlPaper" runat="server" Width="127px">
                                </asp:DropDownList>
                                <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
                            </div>
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;" colspan="2">
                            <div align="center">
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="开始考试" CausesValidation="false" OnClick="Button1_Click" /></div>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#EDF1F6" style="text-align: right; width: 100%;" colspan="2">
                            <div class="title" align="left">
                                <h4>
                                    修改密码</h4>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#EDF1F6" style="text-align: right;">
                            原密码：
                        </td>
                        <td>
                            &nbsp;<div align="left">
                                <asp:TextBox ID="txtOldPwd" runat="server" Width="124px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPwd"
                                    ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#EDF1F6" style="text-align: right;">
                            新密码：
                        </td>
                        <td>
                            &nbsp;<div align="left">
                                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="124px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPwd"
                                    ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#EDF1F6" style="text-align: right;width:90px;">
                            确认密码：
                        </td>
                        <td>
                            &nbsp;<div align="left">
                                <asp:TextBox ID="txtConfirmPwd" runat="server" MaxLength="20" TextMode="password"
                                    Width="124px"></asp:TextBox>
                                <asp:CompareValidator ID="cpv_newpassword" runat="server" ErrorMessage="确认密码不一致"
                                    ControlToValidate="txtConfirmPwd" ControlToCompare="txtNewPwd"></asp:CompareValidator></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                            <asp:Label ID="lblPwd" runat="server" ForeColor="red"></asp:Label><br />
                            <asp:ImageButton ID="imgBtnModifyPwd" runat="server" ImageUrl="../Images/Update.GIF"
                                OnClick="imgBtnModifyPwd_Click1" />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:ImageButton ID="imgBtnReset" runat="server" CausesValidation="false" ImageUrl="../Images/RESET.GIF"
                                OnClick="imgBtnReset_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#EDF1F6" style="text-align: right; width: 100%; height: 25px;" colspan="2">
                            <div class="title" align="left">
                                <h4>
                                    考试记录：<asp:Label ID="lblScore" runat="server" Text="" Width="126px"></asp:Label>
                                </h4>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;" colspan="2">
                            <div align="left">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8" AutoGenerateColumns="False"
                                    DataKeyNames="ID" CellPadding="4" Font-Size="13px" Width="100%" 
                                    ForeColor="#333333" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField HeaderText="成绩编号" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server"><%# Eval("ID") %></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="姓名">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server"><%# Eval("UserName") %></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="试卷">
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server"><%# Eval("PaperName") %></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="成绩">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server"><%# Eval("Score") %></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="考试时间">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server"><%# Eval("ExamTime") %></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="False" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="阅卷时间">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server"><%# Eval("JudgeTime") %></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Wrap="False" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                    <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
                            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
