<%--   <script language="javascript">
   var i=0;
   window.onresize=function()
   {
   i++;
    if(i=3)
    {
        
    }
   }
   </script>--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserTest.aspx.cs" Inherits="Web_UserTest" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>在线考试界面</title>
    <link href="../CSS/CSS.css" rel="stylesheet" type="text/css" />
</head>
<body onload="init(); window.setTimeout('show_secs()',1);">

    <script language="javascript" type="text/javascript">
<!--
        var ap_name = navigator.appName;
        var ap_vinfo = navigator.appVersion;
        var ap_ver = parseFloat(ap_vinfo.substring(0, ap_vinfo.indexOf('(')));
        var time_start = new Date();
        var clock_start = time_start.getTime();
        var dl_ok = false;
        function init() {
            if (ap_name == "Netscape" && ap_ver >= 3.0)
                dl_ok = true;
            return true;
        }
        function get_time_spent() {
            var time_now = new Date();
            return ((time_now.getTime() - clock_start) / 1000);
        }
        function show_secs() // show the time user spent on the side
        {
            var i_total_secs = Math.round(get_time_spent());
            var i_secs_spent = i_total_secs % 60;
            var i_mins_spent = Math.round((i_total_secs - 30) / 60);
            var s_secs_spent = "" + ((i_secs_spent > 9) ? i_secs_spent : "0" + i_secs_spent);
            var s_mins_spent = "" + ((i_mins_spent > 9) ? i_mins_spent : "0" + i_mins_spent);
            document.form1.time_spent.value = s_mins_spent + ":" + s_secs_spent;
            window.setTimeout('show_secs()', 1000);
        }

        window.onload = function() {
            test();
        }
        var sec = 0;
        var miu = 0;
        var hour = 0;
        function test() {
            var time = document.getElementById("<%=timeBox.ClientID %>");
            if (time.value == "") {
                sec += 1;
                if (sec == 60) {
                    miu += 1;
                    sec = 0;
                }
                if (miu == 60) {
                    hour += 1;
                    miu = 0;
                }
                time.value = hour + ":" + miu + ":" + sec;
            } else {
                var ts = time.value.split(':');
                sec = parseInt(ts[2]);
                miu = parseInt(ts[1]);
                hour = parseInt(ts[0]);

                sec += 1;
                if (sec == 60) {
                    miu += 1;
                    sec = 0;
                }
                if (miu == 60) {
                    hour += 1;
                    miu = 0;
                }
                time.value = hour + ":" + miu + ":" + sec;

            }

            window.setTimeout("test()", 1000);
        }
// -->
    </script>

    <form id="form1" runat="server">
    <div>
        <table cellspacing="0" style="font-size: 12px; font-family: Tahoma; border-collapse: collapse;
            width: 100%; height: 100%;" cellpadding="0" align="center" border="1">
            <tr>
                <td style="height: 4px;" colspan="3">
                    <img src="../Images/logo.jpg" style="border: 0px; left: 0px; position: relative;
                        top: 0px;" title="" alt="" />
                </td>
            </tr>
            <tr style="background: url(../Images/lineS.jpg) repeat-x;">
                <td style="height: 25;" colspan="3">
                    &nbsp;&nbsp;&nbsp;欢迎您：<asp:Label ID="labUser" runat="server" Text="Label" Width="70px"></asp:Label>&nbsp;&nbsp;
                    <%--<input type="text" name="time_spent" id="timeBox" runat="server" onfocus="this.blur()" />--%>
                    <asp:TextBox ID="timeBox" runat="server" BackColor="White" BorderColor="White" 
                        BorderStyle="None"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <a id="top"></a><font color="#4D2600" size="5" style="font-family: 楷体_GB2312">
                        <asp:Label ID="Label7" runat="server" Text="考试试题：" /><asp:Label ID="Label1" runat="server"
                            Text="<<" /><asp:Label ID="lblPaperName" runat="server"></asp:Label><asp:Label ID="Label12"
                                runat="server" Text=">>" /></font>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="sqlQuestion" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT QuestionProblem.* FROM &#13;&#10;QuestionProblem,PaperDetail &#13;&#10;WHERE QuestionProblem.ID = PaperDetail.TitleID AND PaperDetail.PaperID = @PaperID AND PaperDetail.Type = '问答题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperID" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlJudge" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT JudgeProblem.* FROM &#13;&#10;JudgeProblem ,PaperDetail &#13;&#10;WHERE JudgeProblem.ID = PaperDetail.TitleID AND PaperDetail.PaperID = @PaperID AND PaperDetail.Type = '填空题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperID" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlFillBlank" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT FillBlankProblem.* FROM &#13;&#10;FillBlankProblem ,PaperDetail &#13;&#10;WHERE FillBlankProblem.ID = PaperDetail.TitleID AND PaperDetail.PaperID = @PaperID AND PaperDetail.Type = '填空题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperID" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlMulti" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT MultiProblem.* FROM &#13;&#10;MultiProblem ,PaperDetail &#13;&#10;WHERE MultiProblem.ID = PaperDetail.TitleID AND PaperDetail.PaperID = @PaperID AND PaperDetail.Type = '多选题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperID" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlSingle" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT SingleProblem.* FROM &#13;&#10;SingleProblem ,PaperDetail &#13;&#10;WHERE SingleProblem.ID = PaperDetail.TitleID AND PaperDetail.PaperID = @PaperID AND PaperDetail.Type = '单选题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperID" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlSingleMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM PaperDetail WHERE PaperDetail.PaperID = @PaperId AND Type= '单选题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperId" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlMultiMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM PaperDetail WHERE PaperDetail.PaperID = @PaperId AND Type= '多选题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperId" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlFillMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM PaperDetail WHERE PaperDetail.PaperID = @PaperId AND Type='填空题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperId" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlJudgeMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM PaperDetail WHERE PaperDetail.PaperID = @PaperId AND Type='判断题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperId" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlQuestionMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM PaperDetail WHERE PaperDetail.PaperID = @PaperId AND Type= '问答题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperId" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
                    </asp:Timer>
                   
                    <a style="font-family: 楷体_GB2312; font-size: 15px;font-weight: bold;">
                        一.单选（每题<asp:Label ID="labSingle" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                
                    <asp:Repeater runat="server" ID="singleRep" DataSourceID="sqlSingle">
                        <ItemTemplate>
                            <a>
                               &nbsp; <%# singeCount++ %>
                                .<%# Eval("Title") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                &nbsp; &nbsp;&nbsp; &nbsp;A.<asp:RadioButton ID="rbA" GroupName="option" runat="server" Text='<%# Eval("AnswerA") %>' />
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;B.<asp:RadioButton ID="rbB" GroupName="option" runat="server" Text='<%# Eval("AnswerB") %>' />
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;C.<asp:RadioButton ID="rbC" GroupName="option" runat="server" Text='<%# Eval("AnswerC") %>' />
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;D.<asp:RadioButton ID="rbD" GroupName="option" runat="server" Text='<%# Eval("AnswerD") %>' />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a style="font-family: 楷体_GB2312; font-size: 15px;font-weight: bold;">
                    <br />
                        二.多单选（每题<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                    
                    <asp:Repeater runat="server" ID="Repeater2" DataSourceID="sqlMulti">
                        <ItemTemplate>
                            <a>
                                &nbsp;<%# singeCount++ %>
                                .<%# Eval("Title") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                &nbsp; &nbsp;&nbsp; &nbsp;A.<asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("AnswerA") %>'></asp:CheckBox>
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;B.<asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("AnswerB") %>'></asp:CheckBox>
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;C.<asp:CheckBox ID="CheckBox3" runat="server" Text='<%# Eval("AnswerC") %>'></asp:CheckBox>
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;D.<asp:CheckBox ID="CheckBox4" runat="server" Text='<%# Eval("AnswerD") %>'></asp:CheckBox>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a style="font-family: 楷体_GB2312; font-size: 15px;font-weight: bold;">
                    <br />
                        三.判断选（每题<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater3" DataSourceID="sqlJudge">
                        <ItemTemplate>
                            <a>
                                &nbsp;<%# singeCount++ %>
                                .<%# Eval("Title") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <%--<asp:Label ID="Label10" runat="server" Text='<%# Eval("Title","{0}") %>'>--%>
                                &nbsp; &nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rbA" GroupName="option" runat="server" Text="正确" />
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rbB" GroupName="option" runat="server" Text="错误" />
                                <%--<asp:CheckBox ID="CheckBox5" runat="server" Text="正确"></asp:CheckBox>--%>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a style="font-family: 楷体_GB2312; font-size: 15px;font-weight: bold;">
                    <br />
                        四.填空选（每题<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater1" DataSourceID="sqlFillBlank">
                        <ItemTemplate>
                            <a>
                                &nbsp;<%# singeCount++ %>
                                .<%# Eval("FrontTitle") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <asp:TextBox ID="TextBox1" runat="server" Width="1000px" Style="border-bottom: gray   1px   solid"
                                    BorderStyle="None"></asp:TextBox>
                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("BackTitle") %>'>
                                </asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a style="font-family: 楷体_GB2312; font-size: 15px;font-weight: bold;">
                    <br />
                        五.问答选（每题<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater4" DataSourceID="sqlQuestion">
                        <ItemTemplate>
                            <a>
                                &nbsp;<%# singeCount++ %>
                                .<%# Eval("Title") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <asp:TextBox ID="TextBox2" runat="server" Width="1000px" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <br />
                    <div align="center"><a href="#top">返回顶端</a> &nbsp; &nbsp;<asp:ImageButton ID="imgBtnSubmit" runat="server"
                        ImageUrl="~/Images/Submit.GIF" OnClick="imgBtnSubmit_Click"  align="center"/></div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
