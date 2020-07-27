<%@ Page Title="" Language="C#" MasterPageFile="~/StudentMaster.master" AutoEventWireup="true" CodeFile="UserPaperAnswer.aspx.cs" Inherits="Web_UserPaperAnswer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="0" style="font-size: 12px; font-family: Tahoma; border-collapse: collapse;"
        cellpadding="0" width="60%" bgcolor="#ffffff" border="1" bordercolor="gray">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" OnRowDataBound="GridView1_RowDataBound">
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
                                <asp:Label ID="Label5" runat="server" Text="分)"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table3" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br />
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="Label6" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("UserAnswer") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 22px" width="35%">
                                            <div id="4_mul" ><asp:CheckBox ID="A" runat="server" Enabled="false" Text='<%# Eval("AnswerA") %>'></asp:CheckBox></div></td>
                                        <td style="height: 22px" width="35%">
                                           <div id="5_mul" > <asp:CheckBox ID="B" runat="server" Enabled="false" Text='<%# Eval("AnswerB") %>'></asp:CheckBox></div></td>
                                        <td style="height: 22px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            <div id="6_mul" ><asp:CheckBox ID="C" runat="server" Enabled="false" Text='<%# Eval("AnswerC") %>'></asp:CheckBox></div></td>
                                        <td width="350%">
                                            <div id="1_mul" ><asp:CheckBox ID="D" Enabled="false" runat="server" Text='<%# Eval("AnswerD") %>'></asp:CheckBox></div></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            <div id="2_mul" ><asp:CheckBox ID="E" runat="server" Enabled="false" Text='<%# Eval("AnswerE") %>'></asp:CheckBox></div></td>
                                        <td width="350%">
                                            <div id="3_mul" ><asp:CheckBox ID="F" Enabled="false" runat="server" Text='<%# Eval("AnswerF") %>'></asp:CheckBox></div></td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            参考答案：<asp:Label ID="Label10" runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                </asp:GridView>
                <script type="text/javascript">
                    $(function () {
                        $("div[id$=_mul]").each(function () {
                            var tmp = $(this).find("label").html();
                            if ($.trim(tmp) == "-") {
                                $(this).hide();
                            }
                        });
                    });

                    </script>
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
                                            <asp:Label ID="Label11" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label13" runat="server" Text='<%# Eval("UserAnswer")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="Label14" runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
                                        </td>
                                        <td width="15%">
                                            <asp:CheckBox ID="CheckBox5" runat="server" Text="正确"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            参考答案：
                                            <asp:Label ID="Label15" runat="server" Text='<%# Eval("Answer").ToString()=="True"?"正确":"错误" %>'></asp:Label>
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
                                            <asp:Label ID="Label16" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label17" runat="server" Text='<%# Eval("FrontTitle","、{0}") %>'>
                                            </asp:Label>
                                            <asp:TextBox ID="TextBox1" Text='<%# Eval("UserAnswer") %>' runat="server" Width="150px"
                                                Style="border-bottom: gray   1px   solid" BorderStyle="None"></asp:TextBox>
                                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("BackTitle") %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label31" runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            参考答案：
                                            <asp:Label ID="Label32" runat="server" Text='<%# Eval("Answer") %>'></asp:Label>
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
                                <asp:Label ID="Label33" runat="server" Text="五、问答题(每题"></asp:Label>
                                <asp:Label ID="Label34" runat="server"></asp:Label>
                                <asp:Label ID="Label35" runat="server" Text="分)"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table6" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label36" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label37" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                            </asp:Label>
                                            <%--(本题得分：<asp:TextBox ID="tbxqueScore" runat="server" Width="50px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxqueScore"
                                                ValidationExpression="^\d+$" ErrorMessage="只能为正整数或0" Display="dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                                                ControlToValidate="tbxqueScore" Display="dynamic"></asp:RequiredFieldValidator>)--%>
                                            <br />
                                            <asp:TextBox ID="TextBox2" runat="server" TextMode="multiLine" ReadOnly="true" Width="100%"
                                                Text='<%# Eval("UserAnswer") %>'></asp:TextBox>
                                            <asp:Label ID="Label38" runat="server" Text='<%# Eval("Mark") %>' Visible="false"></asp:Label>
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
                    <%--<asp:Button ID="Button1" runat="server" Text="返回" OnClick="Button1_Click" CausesValidation="true"  CssClass="btn btn-info" />--%>
                    <a href="StudentIndex2.aspx" class="btn btn-info">返 回</a> 
                </center>
            </td>
        </tr>
    </table>

</asp:Content>

