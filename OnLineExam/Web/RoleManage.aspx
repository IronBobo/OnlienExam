<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RoleManage.aspx.cs" Inherits="Web_RoleManage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
                <tr>
                    <td valign="top" align="left" width="960px">
                        <h4 style="font-family: 楷体_GB2312">
                            >>权限管理</h4><!-- 未启用，调试中-->
                        <hr />
                        <asp:GridView ID="GV" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            PageSize="12" OnPageIndexChanging="GV_PageIndexChanging" OnRowDataBound="GV_RowDataBound"
                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3" Font-Size="13px" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="RoleId" HeaderText="编号" />
                                <asp:BoundField DataField="RoleName" HeaderText="角色" />
                                <asp:TemplateField HeaderText="角色信息管理">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkRoleManage" Visible="True" runat="server"></asp:CheckBox></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户信息管理">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkUserManage" Visible="True" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="考试科目管理">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkCourseManage" Visible="True" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="试卷制定维护">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkPaperSetup" Visible="True" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户试卷管理">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkUserPaperList" Visible="True" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="试题类别管理">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkTypeManage" Visible="True" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <br />
                        <p align="center">
                              <asp:LinkButton runat="server" ID="Giant" CssClass="btn btn-large btn-info"  OnClick="Giant_Click" >授 权</asp:LinkButton>
                        </p>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
