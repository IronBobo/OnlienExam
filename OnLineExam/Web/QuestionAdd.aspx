﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="QuestionAdd.aspx.cs" Inherits="Web_QuestionAdd" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="1" bordercolor="#cccccc" style="border-collapse: collapse"
                width="100%" frame="below">
                <tr>
                    <td bgcolor="#eeeeee" colspan="2">
                        <div class="title" align="left">
                            <h4 style="font-family: 楷体_GB2312">
                                >>程序题</h4>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right;" width="80px">
                        科目：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:DropDownList ID="ddlCourse" runat="server" Font-Size="9pt" Width="88px">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right;">
                        题目：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtTitle" runat="server" Width="100%" TextMode="MultiLine" Height="80px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right;">
                        答案
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtAnswer" runat="server" Width="100%" TextMode="MultiLine" Height="80px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnswer"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label><br />
                        <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="../Images/Save.GIF" OnClick="imgBtnSave_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:ImageButton ID="imgBtnReturn" runat="server" CausesValidation="false" ImageUrl="../Images/Return.GIF"
                            OnClick="imgBtnReturn_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
