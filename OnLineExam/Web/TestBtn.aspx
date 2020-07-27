<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestBtn.aspx.cs" Inherits="Web_TestBtn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../JS/jquery-1.7.2.min.js" type="text/javascript" ></script>
    <script type="text/javascript">
        function aa() {
            alert("aaa");
        }
        //$(document).ready(function () {
        //    function aa() {
        //        alert("aaa");
        //    }
        //});



       

        //$(function () {
            var countDownTime = parseInt(90);    //在这里设置每道题的答题时长
            function countDown(countDownTime) {
                var timer = setInterval(function () {
                    if (countDownTime >= 0) {
                        showTime(countDownTime);
                        countDownTime--;
                    } else {
                        clearInterval(timer);
                        alert("计时结束,给出提示");
                    }
                }, 1000);
            }
            //countDown(countDownTime);
            function showTime(countDownTime) {      //这段是计算分和秒的具体数
                var minute = Math.floor(countDownTime / 60);
                var second = countDownTime - minute * 60;
                $("#countDownTime").text(minute + ":" + second);
            }
        //})

        function countDown_Show() {
            countDown(countDownTime);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <div></div> <div style="padding-left:20px;" id="countDownTime">
                            00：90：00
                        </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
