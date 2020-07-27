<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaperSetup2.aspx.cs" Inherits="Web_PaperSetup2" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" border="1" bordercolor="#cccccc" style="border-collapse: collapse"
        width="100%" frame="below">
        <tr>
            <td bgcolor="#eeeeee" style="width: 100%;" colspan="4">
                <div class="title" align="left">
                    <h4 style="font-family: 楷体_GB2312">
                        >>试卷制定</h4>
                </div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                <b>考试科目：</b>
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:DropDownList ID="ddlCourse" runat="server" Font-Size="9pt" Width="88px">
                    </asp:DropDownList>
                </div>
            </td>
            <td bgcolor="#eeeeee" style="text-align: right;">
                试卷名称：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtPaperName" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPaperName"
                        ErrorMessage="不能为空！" Display="Dynamic"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                <b>单选题</b>每题分值：
            </td>
            <td style="width:80%;"  colspan="3">
                &nbsp;<div align="left"  style="float:left;">
                    <asp:TextBox ID="txtSingleFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSingleFen"
                        ValidationExpression="^([12][0-9]|30|[0-9])$" ErrorMessage="请输入&quot;0-30&quot;" 
                        Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtSingleFen" Display="Dynamic"></asp:RequiredFieldValidator>
                     <div style="display:inline-block;margin-left: 2px;">(0表示无该题型)</div>
                      </div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                <b>多选题</b>每题分值：
            </td>
            <td colspan="3">
                &nbsp;<div align="left" style="float:left;">
                    <asp:TextBox ID="txtMultiFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtMultiFen"
                        ValidationExpression="^([12][0-9]|30|[0-9])$" ErrorMessage="请输入&quot;0-30&quot;" 
                        Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtMultiFen" Display="Dynamic"></asp:RequiredFieldValidator>
                     <div style="display:inline-block;margin-left: 2px;">(0表示无该题型)</div>
                      </div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                <b>判断题</b>每题分值：
            </td>
            <td colspan="3">
                &nbsp;<div align="left" style="float:left;">
                    <asp:TextBox ID="txtJudgeFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtJudgeFen"
                        ValidationExpression="^([12][0-9]|30|[0-9])$" ErrorMessage="请输入&quot;0-30&quot;" 
                        Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtJudgeFen" Display="Dynamic"></asp:RequiredFieldValidator>
                     <div style="display:inline-block;margin-left: 2px;">(0表示无该题型)</div>
                      </div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                <b>填空题</b>每题分值：
            </td>
            <td colspan="3">
                &nbsp;<div align="left" style="float:left;">
                    <asp:TextBox ID="txtFillFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtFillFen"
                        ValidationExpression="^([12][0-9]|30|[0-9])$" ErrorMessage="请输入&quot;0-30&quot;" 
                        Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtFillFen" Display="Dynamic"></asp:RequiredFieldValidator>
                     <div style="display:inline-block;margin-left: 2px;">(0表示无该题型)</div>
                      </div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                <b>程序题</b>每题分值：
            </td>
            <td colspan="3">
                &nbsp;<div align="left" style="float:left;">
                    <asp:TextBox ID="txtQuestionFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                        ControlToValidate="txtQuestionFen" ValidationExpression="^([12][0-9]|30|[0-9])$" ErrorMessage="请输入&quot;0-30&quot;"
                        Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtQuestionFen" Display="Dynamic"></asp:RequiredFieldValidator>
                     <div style="display:inline-block;margin-left: 2px;">0表示无该题型</div>
                      </div>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table cellspacing="0" style="font-size: 12px; font-family: Tahoma; border-collapse: collapse;"
                    cellpadding="0" width="100%" bgcolor="#ffffff" border="1" bordercolor="gray">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                        CellPadding="3">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect1" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="20px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="一、单选题">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                    </asp:GridView>
                                    &nbsp; </td> </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect2" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="二、多选题">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 25px">
                                            <asp:GridView ID="GridView3" runat="server" Width="100%" AutoGenerateColumns="False"
                                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect3" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="三、判断题">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect4" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="四、填空题">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label17" runat="server" Text='<%# Eval("FrontTitle","{0}") %>'></asp:Label>
                                                            <asp:TextBox ID="TextBox1" runat="server" Width="100px" Style="border-bottom: gray   1px   solid"
                                                                BorderStyle="None"></asp:TextBox>
                                                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("BackTitle") %>'></asp:Label>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
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
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect5" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="四、问答题">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label22" runat="server" Text='<%# Eval("Title","{0}") %>'></asp:Label>
                                                            <br />
                                                            <asp:TextBox ID="txtAnswer" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                                            <asp:Label ID="Label23" runat="server" Text='<%# Eval("ID") %>' Visible="False"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                            </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <br />
                            <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" Text="全选"  CssClass="select_all"
                                OnCheckedChanged="chkSelectAll_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 31px">
                            <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="~/Images/Save.GIF" OnClick="imgBtnSave_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
