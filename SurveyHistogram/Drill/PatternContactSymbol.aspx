<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatternContactSymbol.aspx.cs" Inherits="FineUITest.Drill.PatternContectSymbol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server"></f:PageManager>
    <f:Panel ID="Panel1" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" >
        <Toolbars>
            <f:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <f:Button ID="btnClose" Text="关闭" EnablePostBack="false" runat="server" Icon="SystemClose">
                    </f:Button>
                    <f:Button ID="btnClosePostBack" OnClick="btnClosePostBack_Click" runat="server"
                        Text="关闭-回发父页面" Icon="SystemSave">
                    </f:Button>
                    <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                    </f:ToolbarSeparator>
                    <f:Button ID="btnSelect" OnClick="btnSelect_Click" runat="server" Text="选择文本输入框的值"
                        Icon="SystemSave">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:SimpleForm ID="SimpleForm1" ShowBorder="true" ShowHeader="false" Title="SimpleForm"
                 BodyPadding="5px" runat="server" EnableCollapse="True">
                <Items>
                    <f:TextBox ID="TextBox1" Label="文本输入框" runat="server" Required="True">
                    </f:TextBox>
                </Items>
            </f:SimpleForm>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
