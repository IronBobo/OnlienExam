<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="noDuty.aspx.cs" Inherits="Web_noDuty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <script type="text/javascript">
           function jump() {
               location = './userManage.aspx';
           }
           setTimeout('jump()', 3000);
     </script>
     <div>
        <h1 class="big_title" style="margin: 30px 340px 0px; padding: 0px; font-size: 36px; color: rgb(51, 51, 51); font-weight: bold; font-family: 微软雅黑; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">无权访问！</h1>
    </div>
</asp:Content>

