<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TestAnalyse.aspx.cs" Inherits="Web_QuestionAnalyse" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" Width="100%">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" border="1" bordercolor="#cccccc" style="border-collapse: collapse"
                    width="100%" frame="below" id="table1">
                    <tr>
                        <td style="text-align: right; width: 89px;">
                            试卷：
                        </td>
                        <td colspan="5">
                            &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label16" runat="server" Text="考试时间：" Width="103px"></asp:Label>
                            <asp:Label ID="lblExamtime" runat="server" Text=""></asp:Label>
                            <asp:Label ID="Xpaperid" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#eeeeee" style="text-align: right; height: 25px; width: 70px;">
                        </td>
                        <td style="height: 25px; width: 70px;">
                            &nbsp;正确
                        </td>
                        <td style="width: 70px">
                            错误
                        </td>
                        <td style="width: 70px">
                            比例
                        </td>
                        <td style="width: 70px">
                            总分
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#eeeeee" style="text-align: right; width: 70px;">
                            单选题：
                        </td>
                        <td style="width: 70px">
                            &nbsp;<div align="left">
                                &nbsp;&nbsp;
                            </div>
                        </td>
                        <td style="width: 70px">
                        </td>
                        <td style="width: 70px">
                        </td>
                        <td style="width: 70px">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#eeeeee" style="text-align: right; width: 70px;">
                            多选题：
                        </td>
                        <td style="width: 70px">
                            &nbsp;<div align="left">
                                &nbsp;&nbsp;
                            </div>
                        </td>
                        <td style="width: 70px">
                        </td>
                        <td style="width: 70px">
                        </td>
                        <td style="width: 70px">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#eeeeee" style="text-align: right; width: 70px; height: 25px;">
                            判断题：
                        </td>
                        <td style="width: 70px; height: 25px;">
                            &nbsp;<div align="left">
                                &nbsp;&nbsp;
                            </div>
                        </td>
                        <td style="width: 70px; height: 25px;">
                        </td>
                        <td style="width: 70px; height: 25px;">
                        </td>
                        <td style="width: 70px; height: 25px;">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#eeeeee" style="text-align: right; width: 70px; height: 25px">
                            填空题：
                        </td>
                        <td style="width: 70px;">
                            &nbsp;<div align="left">
                                &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </div>
                        </td>
                        <td style="width: 70px;">
                        </td>
                        <td style="width: 70px;">
                        </td>
                        <td style="width: 70px;">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#eeeeee" style="text-align: right; height: 31px; width: 70px;">
                            问答题：<br />
                        </td>
                        <td style="height: 31px; width: 70px;">
                            &nbsp; &nbsp;<div align="left">
                                &nbsp;</div>
                        </td>
                        <td style="width: 70px; height: 31px">
                        </td>
                        <td style="width: 70px; height: 31px">
                        </td>
                        <td style="width: 70px; height: 31px">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#eeeeee" style="text-align: right; width: 70px;">
                            总分：
                        </td>
                        <td style="width: 70px">
                            &nbsp; &nbsp;<div align="left">
                                &nbsp;</div>
                        </td>
                        <td style="width: 70px">
                        </td>
                        <td style="width: 70px">
                        </td>
                        <td style="width: 70px">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
