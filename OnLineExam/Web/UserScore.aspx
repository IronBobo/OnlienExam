<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserScore.aspx.cs" Inherits="Web_UserScore" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top" align="left" width="750px">
                        <h4 style="font-family: 楷体_GB2312">
                            >>成绩管理</h4>
                        <hr />
                        请选择试卷的编号：<asp:DropDownList ID="DropDownList1" runat="server" 
                            DataTextField="PaperID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                            SelectCommand="SELECT DISTINCT [PaperID] FROM [Score]"></asp:SqlDataSource>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label12" runat="server" ForeColor="Red"></asp:Label>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="12" AutoGenerateColumns="False"
                            DataKeyNames="ID" CellPadding="4" Font-Size="13px" Width="100%" OnRowDeleting="GridView1_RowDeleting"
                            ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                            DataSourceID="SqlDataSource2" EnableModelValidation="True">
                            <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户编号">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserID" Text='<%# Eval("UserID") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户姓名">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" Text='<%# Eval("UserName") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="试卷编号">
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" Text='<%# Eval("PaperID") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="试卷名称">
                                    <ItemTemplate>
                                        <asp:Label ID="Lbl_sjmc" Text='<%# Eval("PaperName") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="成绩">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" Text='<%# Eval("Score") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="考试时间">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" Text='<%# Eval("ExamTime") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="评卷时间">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" Text='<%# Eval("JudgeTime") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" HeaderText="删除">
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server"    ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                    SelectCommand="SELECT ID,Score.UserID,Score.PaperID,Paper.PaperName,Score,ExamTime,JudgeTime,Users.UserName  FROM Score inner join Users on  Score.UserID=Users.UserID inner join Paper on Paper.PaperID=Score.PaperID  order by Score.ExamTime desc"></asp:SqlDataSource>
                        <br />
                        <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="true" GroupName="radio"
                            OnCheckedChanged="RadioButton1_CheckedChanged" Text="全选" CssClass="select_all" /><asp:RadioButton
                                ID="RadioButton2" runat="server" AutoPostBack="true" GroupName="radio" OnCheckedChanged="RadioButton2_CheckedChanged"
                                Text="反选" CssClass="select_all" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
   <%-- <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Excel.GIF" OnClick="ImageButton2_Click" />--%>
     <asp:Button ID="ImageButton2" runat="server" Text="导出Excel文件"   OnClick="ImageButton2_Click1" CssClass="btn btn-large" CausesValidation="true" />
</asp:Content>
