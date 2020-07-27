<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SingleSelectAdd.aspx.cs" Inherits="Web_SingleSelectAdd" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   
    <table cellpadding="0" cellspacing="0" border="1" bordercolor="#cccccc" style="border-collapse: collapse"
        width="100%" frame="below">
        <tr>
            <td bgcolor="#eeeeee" colspan="2">
                <div class="title" align="left">
                    <h4 style="font-family: 楷体_GB2312">
                        >>单选题</h4>
                </div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right; height: 25px;" width="80px">
                科目：</td>
            <td style="height: 25px">
                &nbsp;<div align="left">
                    <asp:DropDownList ID="ddlCourse" runat="server" Font-Size="9pt" Width="88px">
                    </asp:DropDownList></div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                题目：</td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtTitle" runat="server" Width="100%" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                答案A：</td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtAnswerA" runat="server" Width="100%" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAnswerA"
                        ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                答案B：</td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtAnswerB" runat="server" Width="100%" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAnswerB"
                        ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right; height: 24px;">
                答案C：</td>
            <td style="height: 24px">
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtAnswerC" runat="server" Width="100%" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAnswerC"
                        ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                答案D：</td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtAnswerD" runat="server" Width="100%" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAnswerD"
                        ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td bgcolor="#eeeeee" style="text-align: right;">
                答案</td>
            <td>
                &nbsp;<div align="left">
                    <asp:DropDownList ID="ddlAnswer" runat="server" Font-Size="9pt" Width="43px">
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                        <asp:ListItem Value="D">D</asp:ListItem>
                    </asp:DropDownList></div>
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
                    OnClick="imgBtnReturn_Click" /></td>
        </tr>
    </table>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
