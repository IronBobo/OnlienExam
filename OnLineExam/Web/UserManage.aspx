<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserManage.aspx.cs" Inherits="Web_UserManage" Title="Untitled Page" %>
<%--不能翻页--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" border="0" class="user_manager">
                <tbody>
                    <tr>
                        <td class="">
                            <h4 style="font-family: 楷体_GB2312">
                                >>用户管理</h4>
                            <hr />
                      <!--      ※用户ID：
                            <asp:TextBox ID="tbxUserID" runat="server" Width="66px"></asp:TextBox>
                            ※姓名：
                            <asp:TextBox ID="tbxUserName" runat="server" Width="66px"></asp:TextBox>-->
                            <%--<asp:ImageButton ID="ImageButtonQuery" OnClick="ImageButtonQuery_Click" runat="server"
                                ImageUrl="../Images/BtnQuery.gif"></asp:ImageButton>--%>
                            <%--<asp:ImageButton ID="ImageButton1" OnClick="ImageButtonBack_Click" runat="server"
                                ImageUrl="../Images/BtnBack.gif"></asp:ImageButton>--%>
                     <!--       <asp:Button ID="ButtonQuery" runat="server" Text="查询"  OnClick="ButtonQuery_Click" CssClass="btn btn-large" CausesValidation="true" />
                            <asp:Button ID="ButtonBack" runat="server" Text="返回" OnClick="ButtonBack_Click" CssClass="btn btn-large" CausesValidation="true"  />
                            <br />    无语法错误，但返回值为null-->


                            <asp:GridView ID="GridView1" runat="server" Width="100%" DataSourceID="SqlDataSource1" Font-Size="13px" CellPadding="4"
                                PageSize="26" AllowPaging="True" AutoGenerateColumns="False" ForeColor="#333333"
                                GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="用户ID">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="用户姓名"><ItemTemplate>                                
                           <asp:TextBox runat="server" ID="UserName" Text = '<%# Eval("UserName") %>'></asp:TextBox>                     
                           </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="角色名"><ItemTemplate>                                
                             <asp:TextBox runat="server" ID="RoleName" Text = '<%# Eval("RoleName") %>'></asp:TextBox>
                              </ItemTemplate>
                              </asp:TemplateField>--%>
                                    <asp:BoundField DataField="UserName" SortExpression="UserName" HeaderText="姓名"></asp:BoundField>
                                    <asp:BoundField DataField="RoleName" SortExpression="RoleName" HeaderText="角色名">
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle ForeColor="#333333" BackColor="#F7F6F3"></RowStyle>
                                <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                                <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:Label ID="LabelPageInfo" runat="server"></asp:Label>&nbsp;<br />
                            &nbsp;
                            <asp:RadioButton ID="RadioButton1" runat="server"  Text="全选" OnCheckedChanged="RadioButton1_CheckedChanged"
                                AutoPostBack="true" GroupName="radio" CssClass="select_all"></asp:RadioButton>
                            <asp:RadioButton ID="RadioButton2" runat="server"  Text="反选" OnCheckedChanged="RadioButton2_CheckedChanged"
                                AutoPostBack="true" GroupName="radio" CssClass="select_all"></asp:RadioButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="select UserId,UserName,RoleName from Users,[Role]where Users.roleId  = [Role].roleId" DeleteCommand="DELETE FROM SingleProblem WHERE ID = @ID">
                    <DeleteParameters>
                        <asp:Parameter Name="ID" />
                    </DeleteParameters>
                </asp:SqlDataSource>
    <asp:HyperLink ID="HyperLinkAdd" runat="server"   NavigateUrl="UserAdd.aspx" CssClass="btn btn-large" >添加</asp:HyperLink>
 <!--   <asp:Button ID="ButtonResetPassword" runat="server" Text="重置密码"  OnClick="ButtonResetPassword_Click" CssClass="btn btn-large" CausesValidation="true" />-->
    <asp:Button ID="ButtonDelete" runat="server" Text="删除"   OnClick="ButtonDelete_Click" CssClass="btn btn-large" CausesValidation="true" />
    <%--<asp:ImageButton ID="ImageButtonResetPassword" runat="server" ImageUrl=" "
        OnClick="ImageButtonResetPassword_Click"  CssClass="btn btn-large" AlternateText="">重置密码</asp:ImageButton>&nbsp;<asp:ImageButton
            ID="ImageButtonDelete" runat="server" ImageUrl="../Images/BtnDelete.gif" OnClick="ImageButtonDelete_Click">
        </asp:ImageButton>--%>
</asp:Content>
