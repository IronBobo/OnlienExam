<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Role.aspx.cs" Inherits="Web_Role" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
        <tr>
            <td valign="top" align="left">
                <h4 style="font-family: 楷体_GB2312">
                    >>角色管理</h4><!-- 未启用，调试中-->
                <hr />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                    PageSize="12" CellPadding="4" Font-Size="13px" Width="100%" DataKeyNames="RoleId"
                    ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                    <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                    <Columns>
                        <asp:TemplateField HeaderText="编号">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("RoleId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="角色">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtRoleName" runat="server" Text='<%# Eval("RoleName") %>' Width="80"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server"><%# Eval("RoleName") %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <br />
                <a href="RoleAdd.aspx" style="font-size: medium;"><font color="red" style="font-family: 楷体_GB2312"><u>添加角色</u></font></a>
            </td>
        </tr>
    </table>
</asp:Content>
