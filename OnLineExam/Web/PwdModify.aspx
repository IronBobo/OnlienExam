<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PwdModify.aspx.cs" Inherits="Web_PwdModify1" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse"
                width="100%" frame="below">
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right; width: 100%;" colspan="2">
                        <div class="title" align="left">
                            <h4 style="font-family: 楷体_GB2312">
                                >>修改密码</h4>
                        </div>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right;">
                        原密码：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtOldPwd" runat="server" Width="124px"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPwd"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right; height: 25px;">
                        新密码：
                    </td>
                    <td style="height: 25px">
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="124px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPwd"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right;">
                        确认密码：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtConfirmPwd" runat="server" MaxLength="20" TextMode="password"
                                Width="124px"></asp:TextBox>&nbsp;
                            <asp:CompareValidator ID="cpv_newpassword" runat="server" ControlToCompare="txtNewPwd"
                                ControlToValidate="txtConfirmPwd" ErrorMessage="确认密码不一致"></asp:CompareValidator></div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label><br />
                        <asp:ImageButton ID="imgBtnModifyPwd" runat="server" ImageUrl="~/Images/Update.GIF"
                            OnClick="imgBtnModifyPwd_Click1" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:ImageButton ID="imgBtnReset" runat="server" CausesValidation="false" ImageUrl="~/Images/RESET.GIF"
                            OnClick="imgBtnReset_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
