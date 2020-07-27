<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserPaper.aspx.cs" Inherits="Web_UserPaper" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
            <asp:Panel ID="Panel1" runat="server" Width="100%">
                <table style="border-collapse: collapse" bordercolor="#cccccc" cellspacing="0" cellpadding="0"
                    width="100%" border="1" frame="below">
                    <tbody>
                        <tr>
                            <td style="text-align: right" bgcolor="#eeeeee">
                                试卷：</td>
                            <td colspan="3">
                                &nbsp; &nbsp; &nbsp; 
                                <asp:Label ID="Xpaperid" runat="server" Text="" Width="100"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="Label16" runat="server" Width="70px" Text="考试时间："></asp:Label>
                                <asp:Label ID="lblExamtime" runat="server" ></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <b>评卷说明：单选题、多选题、判断题是系统自动判分的，填空题、程序题需要在每道题后面输入分数。</b></td>
                        </tr>
                        <tr>
                            <td style="text-align: right" bgcolor="#eeeeee">
                                单选题得分：</td>
                            <td>
                                &nbsp;<div align="left">
                                    &nbsp;&nbsp;<asp:Label ID="sinScore" runat="server" Text="0" Font-Bold="true"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" bgcolor="#eeeeee">
                                多选题得分：</td>
                            <td>
                                &nbsp;<div align="left">
                                    &nbsp;&nbsp;<asp:Label ID="mulScore" runat="server" Text="0" Font-Bold="True"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" bgcolor="#eeeeee">
                                判断题得分：</td>
                            <td>
                                &nbsp;<div align="left">
                                    &nbsp;&nbsp;<asp:Label ID="judScore" runat="server" Text="0" Font-Bold="true"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" bgcolor="#eeeeee">
                                填空题得分：</td>
                            <td>
                                &nbsp;<div align="left">
                                    &nbsp;&nbsp;<asp:Label ID="filScore" runat="server" Text="(>>请在下面对填空题进行判分<<)" Font-Bold="true"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" bgcolor="#eeeeee">
                                程序题得分：</td>
                            <td>
                                &nbsp;<div align="left">
                                    <asp:Label ID="queScore" runat="server" Font-Bold="true"></asp:Label>
                                    &nbsp; &nbsp;<asp:Label ID="lblQuestion" runat="server" Text="(>>请在下面对问答题进行判分<<)"
                                        Font-Bold="true"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 25px; text-align: right" bgcolor="#eeeeee">
                                总分：</td>
                            <td style="height: 25px">
                                <div align="left">
                                    <asp:Label ID="sumScore" runat="server" Font-Bold="true"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#eeeeee">
                            </td>
                            <td>
                                &nbsp;<div align="left">
                                    <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="../Images/Save.GIF" OnClick="imgBtnSave_Click" CausesValidation="False">
                                    </asp:ImageButton>
                                    <asp:Label ID="lblMessage" runat="server" Width="100px" ForeColor="Red"></asp:Label>
                                    <asp:ImageButton ID="imgBtnLook" OnClick="imgBtnLook_Click" runat="server" CausesValidation="false"
                                        ImageUrl="~/Images/QUERY.GIF"></asp:ImageButton>
                                    <asp:Label ID="Label37" runat="server" Width="100px" ForeColor="Red"></asp:Label>
                                    <asp:ImageButton ID="imgBtnReturn" OnClick="imgBtnReturn_Click" runat="server" CausesValidation="false"
                                        ImageUrl="../Images/Return.GIF"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="Label58" runat="server" ForeColor="Red" 
                                    Text="统计总分请点击&quot;保存&quot;将数据插入数据库"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            &nbsp;
            <asp:Panel ID="Panel2" runat="server" Width="100%">
                <table style="border-collapse: collapse" id="table1" bordercolor="#cccccc" cellspacing="0"
                    cellpadding="0" width="100%" border="1" frame="below">
                    <tbody>
                        <tr>
                            <td style="width: 89px; text-align: right" bgcolor="#eeeeee">
                                试卷：</td>
                            <td colspan="5">
                                <asp:Label ID="Label35" runat="server" Text=""></asp:Label>
                                <asp:Label ID="Label36" runat="server" Text="" Visible="false"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 70px; height: 25px; text-align: right" bgcolor="#eeeeee">
                            </td>
                            <td style="width: 70px; height: 25px">
                                &nbsp;<strong>正确</strong></td>
                            <td style="width: 70px">
                                <strong>错误</strong></td>
                            <td style="width: 70px">
                                <strong>错率比</strong></td>
                            <td style="width: 70px">
                                <strong>总分</strong></td>
                        </tr>
                        <tr>
                            <td style="width: 70px; text-align: right" bgcolor="#eeeeee">
                                单选题：</td>
                            <td style="width: 70px">
                                &nbsp;<asp:Label ID="Label34" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px">
                                <asp:Label ID="Label38" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px">
                                <asp:Label ID="Label42" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px">
                                <asp:Label ID="Label53" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 70px; text-align: right" bgcolor="#eeeeee">
                                多选题：</td>
                            <td style="width: 70px">
                                &nbsp;<asp:Label ID="Label39" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px">
                                <asp:Label ID="Label40" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px">
                                <asp:Label ID="Label43" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px">
                                <asp:Label ID="Label54" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 70px; height: 25px; text-align: right" bgcolor="#eeeeee">
                                判断题：</td>
                            <td style="width: 70px; height: 25px">
                                &nbsp;<asp:Label ID="Label52" runat="server" Text="0" Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                            </td>
                            <td style="width: 70px; height: 25px">
                                <asp:Label ID="Label51" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px; height: 25px">
                                <asp:Label ID="Label44" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px; height: 25px">
                                <asp:Label ID="Label55" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 70px; height: 25px; text-align: right" bgcolor="#eeeeee">
                                填空题：</td>
                            <td style="width: 70px">
                                &nbsp;<asp:Label ID="Label49" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px">
                                <asp:Label ID="Label50" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px">
                                <asp:Label ID="Label45" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                            <td style="width: 70px">
                                <asp:Label ID="Label56" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 70px; text-align: right" bgcolor="#eeeeee">
                                总成绩：</td>
                            <td style="width: 70px">
                            </td>
                            <td style="width: 70px">
                            </td>
                            <td style="width: 70px">
                            </td>
                            <td style="width: 70px">
                                <asp:Label ID="Label57" runat="server" Text="0" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 70px; text-align: right" bgcolor="#eeeeee">
                            </td>
                            <td colspan="4">
                                <asp:ImageButton ID="ImageButton1" OnClick="imgBtnReturn_Click" runat="server" CausesValidation="false"
                                    ImageUrl="../Images/Return.GIF"></asp:ImageButton></td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
        </contenttemplate>
    </asp:UpdatePanel>
    <table cellspacing="0" style="font-size: 12px; font-family: Tahoma; border-collapse: collapse;"
        cellpadding="0" width="100%" bgcolor="#ffffff" border="1" bordercolor="gray">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" OnRowDataBound="GridView1_RowDataBound1">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label24" runat="server" Text="一、单选题(每题"></asp:Label>
                                <asp:Label ID="Label27" runat="server"></asp:Label>
                                <asp:Label ID="Label25" runat="server" Text="分)"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table2" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br />
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("UserAnswer") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            <asp:RadioButton ID="A" runat="server" Text='<%# Eval("AnswerA") %>'  Enabled="false" GroupName="Sl">
                                            </asp:RadioButton></td>
                                        <td width="35%">
                                            <asp:RadioButton ID="B" runat="server" Text='<%# Eval("AnswerB") %>' Enabled="false" GroupName="Sl">
                                            </asp:RadioButton></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            <asp:RadioButton ID="C" runat="server" Text='<%# Eval("AnswerC") %>' Enabled="false" GroupName="Sl">
                                            </asp:RadioButton></td>
                                        <td width="35%">
                                            <asp:RadioButton ID="D" runat="server" Text='<%# Eval("AnswerD") %>' Enabled="false" GroupName="Sl">
                                            </asp:RadioButton></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            参考答案：
                                            <asp:Label ID="Label23" runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" OnRowDataBound="GridView2_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label22" runat="server" Text="二、多选题(每题"></asp:Label>
                                <asp:Label ID="Label28" runat="server"></asp:Label>
                                <asp:Label ID="Label23" runat="server" Text="分)"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table3" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br />
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="Label5" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("UserAnswer") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 22px" width="35%">
                                            <asp:CheckBox ID="A" runat="server" Enabled="false" Text='<%# Eval("AnswerA") %>'></asp:CheckBox></td>
                                        <td style="height: 22px" width="35%">
                                            <asp:CheckBox ID="B" runat="server" Enabled="false" Text='<%# Eval("AnswerB") %>'></asp:CheckBox></td>
                                        <td style="height: 22px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            <asp:CheckBox ID="C" runat="server" Enabled="false" Text='<%# Eval("AnswerC") %>'></asp:CheckBox></td>
                                        <td width="350%">
                                            <asp:CheckBox ID="D" Enabled="false" runat="server" Text='<%# Eval("AnswerD") %>'></asp:CheckBox></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            参考答案：<asp:Label ID="Label27" runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView3" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" OnRowDataBound="GridView3_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label20" runat="server" Text="三、判断题(每题"></asp:Label>
                                <asp:Label ID="Label29" runat="server"></asp:Label>
                                <asp:Label ID="Label21" runat="server" Text="分)"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table4" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br />
                                    <tr>
                                        <td width="85%">
                                            <asp:Label ID="Label9" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("UserAnswer")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
                                        </td>
                                        <td width="15%">
                                            <asp:CheckBox ID="CheckBox5" runat="server" Text="正确"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            参考答案：
                                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("Answer").ToString()=="True"?"正确":"错误" %>'></asp:Label>
                                            <asp:Label ID="Label41" runat="server" Text='<%# Eval("Answer")%>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False"
                    OnRowDataBound="GridView4_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label18" runat="server" Text="四、填空题(每题"></asp:Label>
                                <asp:Label ID="Label30" runat="server"></asp:Label>
                                <asp:Label ID="Label19" runat="server" Text="分)"> </asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table5" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br />
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label13" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label14" runat="server" Text='<%# Eval("FrontTitle","、{0}") %>'>
                                            </asp:Label>

                                            (本题得分：<asp:TextBox ID="tbxfilScore" runat="server" Width="50px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxfilScore"
                                                ValidationExpression="^\d+$" ErrorMessage="只能为正整数或0" Display="dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                                                ControlToValidate="tbxfilScore" Display="dynamic"></asp:RequiredFieldValidator>)
                                            <br />
                                            <%--<asp:TextBox ID="TextBox1" Text='<%# Eval("UserAnswer") %>' runat="server" Width="150px"
                                                Style="border-bottom: gray   1px   solid" BorderStyle="None"></asp:TextBox>--%>

                                            <asp:Label ID="Label15" runat="server" Text='<%# Eval("BackTitle") %>'>
                                            </asp:Label>
                                            <asp:TextBox ID="TextBox2" runat="server" TextMode="multiLine" ReadOnly="true" Width="100%"
                                                Text='<%# Eval("UserAnswer") %>'></asp:TextBox>
                                            <asp:Label ID="Label17" runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            参考答案：
                                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView5" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label32" runat="server" Text="五、程序题(每题"></asp:Label>
                                <asp:Label ID="Label31" runat="server"></asp:Label>
                                <asp:Label ID="Label33" runat="server" Text="分)"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table6" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label18" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label19" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                            (本题得分：<asp:TextBox ID="tbxqueScore" runat="server" Width="50px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxqueScore"
                                                ValidationExpression="^\d+$" ErrorMessage="只能为正整数或0" Display="dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                                                ControlToValidate="tbxqueScore" Display="dynamic"></asp:RequiredFieldValidator>)
                                            <br />
                                            <asp:TextBox ID="TextBox2" runat="server" TextMode="multiLine" ReadOnly="true" Width="100%"
                                                Text='<%# Eval("UserAnswer") %>'></asp:TextBox>
                                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            参考答案：
                                            <br />
                                            <asp:TextBox ID="TextBox3" runat="server" TextMode="multiLine" Width="100%" Height="60px"
                                                ReadOnly="true" Text='<%#Eval("Answer") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <center>
                    <asp:Button ID="Button1" runat="server" Text="人工判题计分" OnClick="Button1_Click" CausesValidation="true" />
                </center>
            </td>
        </tr>
    </table>
</asp:Content>
