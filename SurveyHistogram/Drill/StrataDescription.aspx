<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StrataDescription.aspx.cs" Inherits="FineUITest.Drill.StrataDescription" %>

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
                    <f:TextBox ID="TextBox1" Label="岩石名称" runat="server" Required="True"> </f:TextBox>
                    <f:TextBox ID="TextBox2" Label="风化程度" runat="server" Required="True"></f:TextBox>
                    <f:TextBox ID="TextBox3" Label="节理情况" runat="server" Required="True"> </f:TextBox>
                    <f:TextBox ID="TextBox4" Label="岩芯状态" runat="server" Required="True"></f:TextBox>
                    <f:TextBox ID="TextBox5" Label="颗粒成分" runat="server" Required="True"> </f:TextBox>
                    <f:TextBox ID="TextBox6" Label="薄厚程度" runat="server" Required="True"></f:TextBox>
                    <f:TextBox ID="TextBox7" Label="颜色" runat="server" Required="True"> </f:TextBox>
                    <f:TextBox ID="TextBox8" Label="掺杂物" runat="server" Required="True"></f:TextBox>
                    <f:TextBox ID="TextBox10" Label="夹层岩石名称" runat="server" Required="True"></f:TextBox>
                
                </Items>
            </f:SimpleForm>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
