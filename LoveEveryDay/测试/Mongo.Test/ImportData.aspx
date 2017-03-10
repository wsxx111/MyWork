<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportData.aspx.cs" Inherits="Mongo.Test.InportData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <p>本程序使用的数据库的MongoDB连接字符串是：<b style="font-size: 12pt">server=127.0.0.1</b></p>
                <p>本程序使用的数据库的SqlServer连接字符串是：<b style="font-size: 12pt">Data Source=HP680G1\WK;Initial Catalog=northwind;Integrated Security=True;</b></p>
            </div>
            <span>点击按钮从SqlServer导入数据到MongoDB</span>
            <asp:Button ID="importDataBtn" OnClientClick="return isConfirm()" runat="server" Text="开始导入" OnClick="importDataBtn_Click" />
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function isConfirm() {
        if (confirm("是否开始导入？")) {
            return true;
        }
        return false;
    }
</script>
