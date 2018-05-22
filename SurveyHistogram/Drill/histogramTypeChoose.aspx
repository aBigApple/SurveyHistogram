<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="histogramTypeChoose.aspx.cs" Inherits="FineUITest.Drill.histogramTypeChoose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>钻孔柱状图类型选择 </title>

    <script src="/js/jquery/jquery-1.10.2.min.js"></script>
     
</head>
<body>
    <form id="form1" runat="server">

        
        <input id="File1" type="file" name="File1" runat="server"/>
        <br />
<asp:Button id="Button1" runat="server" Text="确认添加" OnClick="Button1_Click"></asp:Button>
<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid> 

    <f:PageManager AutoSizePanelID="formPanel" ID="PageManager1" runat="server"></f:PageManager>
        <f:Panel ID="formPanel" ShowBorder="false" ShowHeader="false"
            runat="server" Height="50px">
            <Items>
                <f:Button Text="操作三（OnClientClick，点击取消按钮也回发）" runat="server" ID="acosticWave" EnablePostBack="false"
            OnClick="acosticWave_Click">
        </f:Button>
                <f:Button Text="操作三（OnClientClick，点击取消按钮也回发）" runat="server" ID="rock" EnablePostBack="false"
            OnClick="rock_Click">
        </f:Button>

            </Items>
                    
        </f:Panel>
        <f:Window ID="Window1" Hidden="true" EnableIFrame="true" runat="server"
            EnableMaximize="true" EnableResize="true" Height="300px" Width="600px"
            Title="窗体三">
        </f:Window>
        <f:Window ID="Window2" Hidden="true" EnableIFrame="true" runat="server"
            EnableMaximize="true" EnableResize="true" Target="Parent" Height="300px" Width="600px"
            CloseAction="HidePostBack" Title="窗体四">
        </f:Window>


    </form>
</body>
</html>
