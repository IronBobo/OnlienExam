<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="true" CodeFile="ExampaperMaster.aspx.cs" Inherits="Web_ExampaperMaster" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        $(function () {
            var countDownTime = parseInt(<%=examtime%>);    //在这里设置每道题的答题时长
            function countDown(countDownTime) {
                var timer = setInterval(function () {
                    if (countDownTime >= 0) {
                        showTime(countDownTime);
                        countDownTime--;
                    } else {
                        clearInterval(timer);
                        //__doPostBack('Button2', '');//一定要用dopostback的方式，否则有可能不成功
                        doSubmit();
                        
                    }
                }, 1000);
            }

            countDown(countDownTime);

            function showTime(countDownTime) {      //这段是计算分和秒的具体数
                var minute = Math.floor(countDownTime / 60);
                var second = countDownTime - minute * 60;
                $("#countDownTime").text(minute + ":" + second);
            }

            function doSubmit() {
                document.getElementById("ctl00_ContentPlaceHolder1_Button3").click();
                //$.ajax({
                //    type: 'get',
                //    url: 'ExampaperMaster.aspx?action=NewMethod',
                //    async: true,
                //    success: function (result) {
                //        alert("提交成功！");
                       
                //        window.location = "ExamFinish.aspx";
                //    },
                //    error: function () {
                //        alert("错误");
                //    }
                //});
            }

           
        });
       
    </script>
    <div oncontextmenu="return false" onselectstart="return false">
        <table class="exampaper_tbl" cellspacing="0" style="" cellpadding="0" align="center" border="1">
              <tr>
                <td align="center">
                    <a id="top"></a>
                    <%--<font color="#4D2600" size="5" style="font-family: 楷体_GB2312">
                        <asp:Label ID="Label7" runat="server" Text="试卷科目：" />
                        <asp:Label ID="lblPaperName" runat="server"></asp:Label>   
                        <span id="countDownTime" class="countTime"></span>
                    </font>--%>
                    <div style="" class="header_exampaper_tbl">
                         <asp:Label ID="Label1" runat="server" Text="试卷科目：" />
                        <asp:Label ID="lblPaperName" runat="server"></asp:Label>   
                        
                    </div>
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
                        SelectCommand="SELECT JudgeProblem.* FROM &#13;&#10;JudgeProblem ,PaperDetail &#13;&#10;WHERE JudgeProblem.ID = PaperDetail.TitleID AND PaperDetail.PaperID = @PaperID AND PaperDetail.Type = '判断题'">
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

                    <%--获取分值--%>
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
                    <asp:SqlDataSource ID="SqlJudgeMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM PaperDetail WHERE PaperDetail.PaperID = @PaperId AND Type='判断题'">
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
                    
                    <asp:SqlDataSource ID="SqlQuestionMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM PaperDetail WHERE PaperDetail.PaperID = @PaperId AND Type= '问答题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="PaperId" QueryStringField="PaperId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />

                    
                   <!-- 定时器-->
                   <%-- <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
                    </asp:Timer>--%>
                   
                    <a id="dxt1" style="" runat="server" class="TXName_exampaper_tbl">
                        <span id="tihao1" runat="server">一</span>.单选题（每题<asp:Label ID="labSingle" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                
                    <asp:Repeater runat="server" ID="singleRep" DataSourceID="sqlSingle">
                        <ItemTemplate>
                            <a>
                               &nbsp; <%# singeCount++ %>
                                .<%# Eval("Title") %><asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
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
                    <a id="dxt2" style="" runat="server"  class="TXName_exampaper_tbl" >
                    <br />
                        <span id="tihao2" runat="server">二</span>.不定项选择题（每题<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                    
                    <asp:Repeater runat="server" ID="Repeater2" DataSourceID="sqlMulti">
                        <ItemTemplate>
                            <a>
                                &nbsp;<%# multiCount++ %>.<%# Eval("Title") %><asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <div id="4_mul" >&nbsp; &nbsp;&nbsp; &nbsp;A.<asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("AnswerA") %>'></asp:CheckBox>
                                <br /></div>
                                <div id="5_mul" >&nbsp; &nbsp;&nbsp; &nbsp;B.<asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("AnswerB") %>'></asp:CheckBox>
                                <br /></div>
                                <div id="6_mul" >&nbsp; &nbsp;&nbsp; &nbsp;C.<asp:CheckBox ID="CheckBox3" runat="server" Text='<%# Eval("AnswerC") %>'></asp:CheckBox>
                                <br /></div>
                                
                               <div id="1_mul" >&nbsp; &nbsp;&nbsp; &nbsp;D.<asp:CheckBox ID="CheckBox4" runat="server" Text='<%# Eval("AnswerD") %>'></asp:CheckBox>
                                <br /></div>
                               <div id="2_mul" > &nbsp; &nbsp;&nbsp; &nbsp;E.<asp:CheckBox ID="CheckBox5" runat="server" Text='<%# Eval("AnswerE") %>'></asp:CheckBox>
                                <br /></div>
                                <div id="3_mul">&nbsp; &nbsp;&nbsp; &nbsp;F.<asp:CheckBox ID="CheckBox6" runat="server" Text='<%# Eval("AnswerF") %>'></asp:CheckBox></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <script type="text/javascript">
                        $(function () {
                            $("div[id$=_mul]").each(function () {
                                var tmp = $(this).children("label").html();
                                if ( $.trim(tmp)=="-") {
                                    $(this).hide();
                                }
                            });
                        });

                    </script>
                    <a id="pdt" style="" runat="server"  class="TXName_exampaper_tbl">
                    <br />
                        <span id="tihao3" runat="server">三</span>.判断选（每题<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater3" DataSourceID="sqlJudge">
                        <ItemTemplate>
                            <a>
                                &nbsp;<%# judgeCount++ %>.<%# Eval("Title") %><asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <%--<asp:Label ID="Label10" runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>--%>
                                &nbsp; &nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rbA" GroupName="option" runat="server" Text="正确" />
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rbB" GroupName="option" runat="server" Text="错误" />
                                <%--<asp:CheckBox ID="CheckBox5" runat="server" Text="正确"></asp:CheckBox>--%>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a id="tkt" style="" runat="server"  class="TXName_exampaper_tbl">
                    <br />
                        <span id="tihao4" runat="server">四</span>.填空题（每题<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater1" DataSourceID="sqlFillBlank">
                        <ItemTemplate>
                            <a>
                                &nbsp;<%# fillbkCount++ %>.<%# Eval("FrontTitle") %><asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <asp:TextBox ID="TextBox1" runat="server" Width="1000px" Style="border-bottom: gray   1px   solid"  onpaste="return false" ondragenter="return false"
                                    BorderStyle="None"></asp:TextBox>
                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("BackTitle") %>'>
                                </asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a id="wdt" style=" " runat="server"  class="TXName_exampaper_tbl">
                    <br />
                        <span id="tihao5" runat="server">五</span>.问答选（每题<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>分）
                    </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater4" DataSourceID="sqlQuestion">
                        <ItemTemplate>
                            <a>
                                &nbsp;<%# questiCount++ %>.<%# Eval("Title") %><asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <asp:TextBox ID="TextBox2" runat="server" Width="1000px" height="150px" TextMode="MultiLine"  onpaste="return false" ondragenter="return false"></asp:TextBox>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <br />
                    <div align="center"><a href="#top">返回顶端</a> &nbsp; &nbsp;
                       
                        <asp:Button ID="Button2" runat="server" Text="确定提交" CausesValidation="false"  CssClass="btn btn-success" OnClick="Button2_Click"/>
                       
                        <asp:Button ID="Button3" runat="server" CausesValidation="false" OnClick="Button3_Click" CssClass="hidebtn" Text="Button" />
                       
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="toolbar">       
       <div id="countDownTime" class="toolbar-item-DownTime" ></div>
       <a href="javascript:scroll(0,0)" id="A1" class="toolbar-item toolbar-item-top"></a>
</div>
</asp:Content>

