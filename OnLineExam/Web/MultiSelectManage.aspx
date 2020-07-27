<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MultiSelectManage.aspx.cs" Inherits="Web_MultiSelectManage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
        <tr>
            <td valign="top" align="left" width="960px">
                <h4 style="font-family: 楷体_GB2312">
                    >>多选题管理</h4>
                <hr />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <p align="left">
                            <asp:DropDownList ID="ddlCourse" runat="server" Width="130px" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged">
                            </asp:DropDownList>
                        </p>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="12" DataKeyNames="ID" CellPadding="4" Font-Size="13px"
                            OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource1" ForeColor="#333333"
                            GridLines="None" EnableModelValidation="True">
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
                                <asp:BoundField DataField="Title" HeaderText="题目" SortExpression="Title"></asp:BoundField>
                                <asp:BoundField DataField="AnswerA" HeaderText="AnswerA" SortExpression="AnswerA"
                                    Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="AnswerB" HeaderText="AnswerB" SortExpression="AnswerB"
                                    Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="AnswerC" HeaderText="AnswerC" SortExpression="AnswerC"
                                    Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="AnswerD" HeaderText="AnswerD" SortExpression="AnswerD"
                                    Visible="False"></asp:BoundField>

                                <asp:BoundField DataField="AnswerE" HeaderText="AnswerE" SortExpression="AnswerE"
                                    Visible="False"></asp:BoundField>
                                <asp:BoundField DataField="AnswerF" HeaderText="AnswerF" SortExpression="AnswerF"
                                    Visible="False"></asp:BoundField>



                                <asp:BoundField DataField="Answer" HeaderText="Answer" SortExpression="Answer" Visible="False">
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="MultiSelectUpdate.aspx?ID={0}"
                                    Text="详细" HeaderText="详细"></asp:HyperLinkField>
                                <asp:CommandField DeleteText="&lt;div onclick=&quot;return confirm('确定要删除吗？')&quot;&gt;删除&lt;/div&gt;"
                                    ShowDeleteButton="True" HeaderText="删除"></asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                            <PagerStyle HorizontalAlign="Center" CssClass="pagenum"></PagerStyle>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                &nbsp;
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT MultiProblem.* FROM MultiProblem" DeleteCommand="DELETE FROM MultiProblem Where ID=@ID">
                    <DeleteParameters>
                        <asp:Parameter Name="ID" />
                    </DeleteParameters>
                </asp:SqlDataSource>
                <br />
                <a href="MultiSelectAdd.aspx" style="font-size: medium;"><font color="red" style="font-family: 楷体_GB2312">
                    <u>添加多选题</u></font></a>
            </td>
        </tr>
    </table>
</asp:Content>
