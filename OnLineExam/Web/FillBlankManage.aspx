<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FillBlankManage.aspx.cs" Inherits="Web_FillBlankManage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
        <tr>
            <td valign="top" align="left" width="960px">
                <h4 style="font-family: 楷体_GB2312">
                    >>填空题管理</h4>
                <hr />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <p align="left">
                            <asp:DropDownList ID="ddlCourse" runat="server" Width="130px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" DataSourceID="SqlDataSource1"
                            Font-Size="13px" CellPadding="4" DataKeyNames="ID" PageSize="12" AllowPaging="True"
                            AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" ForeColor="#333333"
                            GridLines="None">
                            <RowStyle ForeColor="#333333" BackColor="#F7F6F3"></RowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="序号" InsertVisible="False" SortExpression="ID">
                                    <EditItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("ID") %>' ID="Label1"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='' ID="Label1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CourseID" HeaderText="CourseID" SortExpression="CourseID"
                                    Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="FrontTitle" HeaderText="题目前部分" SortExpression="FrontTitle">
                                </asp:BoundField>
                                <asp:BoundField DataField="BackTitle" HeaderText="题目后部分" SortExpression="BackTitle">
                                </asp:BoundField>
                                <asp:BoundField DataField="Answer" HeaderText="Answer" SortExpression="Answer" Visible="False">
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="FillBlankUpdate.aspx?ID={0}"
                                    Text="详细..." HeaderText="详细"></asp:HyperLinkField>
                                <asp:CommandField DeleteText="&lt;div onclick=&quot;return confirm('确定要删除吗？')&quot;&gt;删除&lt;/div&gt;"
                                    ShowDeleteButton="True" HeaderText="删除"></asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                            <PagerStyle HorizontalAlign="Center" CssClass="pagenum"></PagerStyle>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT FillBlankProblem.* FROM FillBlankProblem" DeleteCommand="DELETE FROM FillBlankProblem WHERE (ID = @ID)">
                    <DeleteParameters>
                        <asp:Parameter Name="ID" />
                    </DeleteParameters>
                </asp:SqlDataSource>
                &nbsp; &nbsp;&nbsp;
                <br />
                <a href="FillBlankAdd.aspx" style="font-size: medium;"><font color="red" style="font-family: 楷体_GB2312">
                    <u>添加填空题</u></font></a>
            </td>
        </tr>
    </table>
</asp:Content>
