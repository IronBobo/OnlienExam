<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DundasWebChart" Namespace="Dundas.Charting.WebControl" TagPrefix="DCWC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="sqlSingle" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT SingleProblem.* FROM &#13;&#10;SingleProblem ,PaperDetail &#13;&#10;WHERE SingleProblem.ID = PaperDetail.TitleID AND PaperDetail.PaperID = @PaperID AND PaperDetail.Type = '单选题'">
            <SelectParameters>
                <asp:QueryStringParameter Name="PaperID" QueryStringField="PaperId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:SqlDataSource ID="sqlSingleMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT Mark FROM UserAnswer WHERE UserAnswer.UserID=@UserId AND UserAnswer.PaperID = @PaperId AND Type= '单选题'">
            <SelectParameters>
                <asp:QueryStringParameter Name="UserId" QueryStringField="UserId" />
                <asp:QueryStringParameter Name="PaperId" QueryStringField="PaperId" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
        单选（每题<asp:Label ID="labSingle" runat="server" Text="Label"></asp:Label>分）<br />
        <asp:Repeater ID="singleRep" runat="server" DataSourceID="sqlSingle">
            <ItemTemplate>
                <h2>
                 
                    .<%# Eval("Title") %>
                    <asp:HiddenField ID="titleId" runat="server" Value='<%# Eval("ID") %>' />
                </h2>
                <div>
                    A<asp:RadioButton ID="rbA" runat="server" GroupName="option" Text='<%# Eval("AnswerA") %>' />
                    B<asp:RadioButton ID="rbB" runat="server" GroupName="option" Text='<%# Eval("AnswerB") %>' />
                    C<asp:RadioButton ID="rbC" runat="server" GroupName="option" Text='<%# Eval("AnswerC") %>' />
                    D<asp:RadioButton ID="rbD" runat="server" GroupName="option" Text='<%# Eval("AnswerD") %>' />
                    <asp:Label runat="server" ID="ieo" Text='<%# Eval("Answer") %>'></asp:Label>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
