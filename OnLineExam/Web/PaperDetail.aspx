<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaperDetail.aspx.cs" Inherits="Web_PaperDetail" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" border="1" bordercolor="#cccccc" style="border-collapse: collapse"
        width="100%" frame="below">
        <tr>
            <td style="text-align: left; width: 80px;">
                试卷：
            </td>
            <td colspan="3">
                &nbsp;<div align="left">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table cellspacing="0" style="font-size: 12px; font-family: Tahoma; border-collapse: collapse;"
                    cellpadding="0" width="100%" bgcolor="#ffffff" border="1" bordercolor="gray">
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                CellPadding="3">
                                <Columns>
                                    <asp:TemplateField HeaderText="一、选择题">
                                        <ItemTemplate>
                                            <table id="table2" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                <br />
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("id") %>' Visible="False">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="35%">
                                                        <asp:RadioButton ID="RadioButton1" runat="server" Text='<%# Eval("AnswerA") %>' GroupName="Sl">
                                                        </asp:RadioButton>
                                                    </td>
                                                    <td width="35%">
                                                        <asp:RadioButton ID="RadioButton2" runat="server" Text='<%# Eval("AnswerB") %>' GroupName="Sl">
                                                        </asp:RadioButton>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="35%">
                                                        <asp:RadioButton ID="RadioButton3" runat="server" Text='<%# Eval("AnswerC") %>' GroupName="Sl">
                                                        </asp:RadioButton>
                                                    </td>
                                                    <td width="35%">
                                                        <asp:RadioButton ID="RadioButton4" runat="server" Text='<%# Eval("AnswerD") %>' GroupName="Sl">
                                                        </asp:RadioButton>
                                                    </td>
                                                    <td>
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
                                CellPadding="3">
                                <Columns>
                                    <asp:TemplateField HeaderText="二、不定向选择题">
                                        <ItemTemplate>
                                            <table id="table3" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                <br />
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="Label9" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("id") %>' Visible="False">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 22px" width="35%">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("AnswerA") %>'></asp:CheckBox>
                                                    </td>
                                                    <td style="height: 22px" width="35%">
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("AnswerB") %>'></asp:CheckBox>
                                                    </td>
                                                    <td style="height: 22px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="35%">
                                                        <asp:CheckBox ID="CheckBox3" runat="server" Text='<%# Eval("AnswerC") %>'></asp:CheckBox>
                                                    </td>
                                                    <td width="350%">
                                                        <asp:CheckBox ID="CheckBox4" runat="server" Text='<%# Eval("AnswerD") %>'></asp:CheckBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="35%">
                                                        <asp:CheckBox ID="CheckBox6" runat="server" Text='<%# Eval("AnswerE") %>'></asp:CheckBox>
                                                    </td>
                                                    <td width="350%">
                                                        <asp:CheckBox ID="CheckBox7" runat="server" Text='<%# Eval("AnswerF") %>'></asp:CheckBox>
                                                    </td>
                                                    <td>
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
                                CellPadding="3">
                                <Columns>
                                    <asp:TemplateField HeaderText="三、判断题">
                                        <ItemTemplate>
                                            <table id="table4" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                <br />
                                                <tr>
                                                    <td width="85%">
                                                        <asp:Label ID="Label19" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label20" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("id") %>' Visible="False">
                                                        </asp:Label>
                                                    </td>
                                                    <td width="15%">
                                                        <asp:CheckBox ID="CheckBox5" runat="server" Text="正确"></asp:CheckBox>
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
                            <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="四、填空题">
                                        <ItemTemplate>
                                            <table id="table5" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                <br />
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label16" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label17" runat="server" Text='<%# Eval("FrontTitle","、{0}") %>'>
                                                        </asp:Label>
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="150px" Style="border-bottom: gray   1px   solid"
                                                            BorderStyle="None"></asp:TextBox>
                                                        <asp:Label ID="Label18" runat="server" Text='<%# Eval("BackTitle") %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("id") %>' Visible="False">
                                                        </asp:Label>
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
                                    <asp:TemplateField HeaderText="四、问答题">
                                        <ItemTemplate>
                                            <table id="table6" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                <br>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label21" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label22" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                        </asp:Label>
                                                        <br />
                                                        <asp:TextBox ID="txtAnswer" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:Label ID="Label23" runat="server" Text='<%# Eval("id") %>' Visible="False">
                                                        </asp:Label>
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
                        <td align="center" style="height: 31px">
                            <asp:ImageButton ID="imgBtnReturn" runat="server" CausesValidation="false" ImageUrl="../Images/Return.GIF"
                                OnClick="imgBtnReturn_Click" />
                        </td>
                    </tr>
                </table>
</asp:Content>
