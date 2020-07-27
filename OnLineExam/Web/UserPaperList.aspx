<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserPaperList.aspx.cs" Inherits="Web_UserPaperList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top" align="left" width="960px">
                        <h4 style="font-family: 楷体_GB2312">
                            >>用户试卷评阅 </h4>
                        <hr />
                        <asp:GridView ID="GridView1" runat="server" Width="100%" AllowPaging="True" DataKeyNames="UserID,PaperID"
                            OnRowDataBound="GridView1_RowDataBound" PageSize="12" AutoGenerateColumns="False"
                            CellPadding="4" Font-Size="13px" OnRowDeleting="GridView1_RowDeleting" ForeColor="#333333"
                            GridLines="None" DataSourceID="SqlDataSource1" EnableModelValidation="True">
                            <RowStyle ForeColor="#333333" BackColor="#F7F6F3"></RowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <EditItemTemplate>
                                        <asp:Label runat="server" ID="Label1"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Label1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PaperID" HeaderText="PaperID" ReadOnly="True" Visible="False">
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="用户姓名">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server"><%# Eval("UserName") %></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:HyperLinkField DataNavigateUrlFields="UserID,PaperID" DataNavigateUrlFormatString="UserPaper.aspx?UserID={0}&amp;PaperID={1}"
                                    DataTextField="PaperName" HeaderText="试卷评阅(点击查看)">
                                    <ItemStyle Font-Bold="True"></ItemStyle>
                                </asp:HyperLinkField>
                                <asp:TemplateField HeaderText="考试时间">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server"><%# Eval("ExamTime") %></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:CommandField DeleteText="&lt;div onclick=&quot;return confirm('确定要删除吗？')&quot;&gt;删除&lt;/div&gt;"
                                    ShowDeleteButton="True" HeaderText="删除"></asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:Label ID="LabelPageInfo" runat="server" ForeColor="Red"></asp:Label>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="select 
u.UserName,p.PaperName,ua.ExamTime,ua.UserID,ua.PaperID
from
Users as u,Paper as p,UserAnswer as ua
where 
ua.UserID = u.UserID and ua.PaperID = p.PaperID and ua.ExamTime = ua.ExamTime and ua.UserID= ua.UserID and ua.PaperID=ua.PaperID
Group by 
u.UserName,p.PaperName,ua.ExamTime,ua.UserID,ua.PaperID"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
