<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DrillMain.aspx.cs" Inherits="FineUITest.Drill.DrillMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>钻孔柱状图数据输入</title>
    <link rel="stylesheet" href="/js/jquery/jquery-ui-1.10.4/themes/base/jquery-ui.css"/>
     <script src="/js/jquery/jquery-1.10.2.min.js"></script>

	 <script src="/js/jquery/jquery-ui-1.10.4/ui/jquery.ui.core.js"></script>
	 <script src="/js/jquery/jquery-ui-1.10.4/ui/jquery.ui.widget.js"></script>
	 <script src="/js/jquery/jquery-ui-1.10.4/ui/jquery.ui.tabs.js"></script>
    <link rel="stylesheet" href="http://www.runoob.com/try/demo_source/jqueryui/style.css"/>

    <script type="text/javascript" >
        $(document).ready(function () {
            $("#tabs").tabs();
        })
        </script>
</head>
<body>
    <form id="form1" runat="server"  >
        <f:PageManager ID="PageManager1" runat="server"/>
        <div id="tabs"/>
    <ul>
    <li><a href="#tabs-1">基本</a></li>
    <li><a href="#tabs-2">地质</a></li>
    <li><a href="#tabs-3">采样</a></li>
   </ul>
   <div id="tabs-1">
        <asp:Label ID="Label17" runat="server" Text="工程名称"></asp:Label>
        <asp:TextBox ID="projectName" runat="server"></asp:TextBox>
        <asp:Label ID="Label18" runat="server" Text="项目名称"></asp:Label>
        <asp:TextBox ID="programName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label19" runat="server" Text="钻孔编号"></asp:Label>
        <asp:TextBox ID="drillCode" runat="server"></asp:TextBox>
        <asp:Label ID="Label20" runat="server" Text="孔口标高"></asp:Label>
        <asp:TextBox ID="drillHoleStadardHeight" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label21" runat="server" Text="钻孔位置"></asp:Label>
        <asp:TextBox ID="drillLocation" runat="server"></asp:TextBox>
        <asp:TextBox ID="drillLocation1" runat="server"></asp:TextBox>
        <asp:TextBox ID="drillLocation2" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label22" runat="server" Text="钻孔坐标X"></asp:Label>
        <asp:TextBox ID="applicationCoordinateX" runat="server"></asp:TextBox>
        <asp:Label ID="Label23" runat="server" Text="钻孔坐标Y"></asp:Label>
        <asp:TextBox ID="applicationCoordinateY" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label24" runat="server" Text="原位测试"></asp:Label>
        <asp:TextBox ID="combSituTest" runat="server"></asp:TextBox>
        <asp:Label ID="Label25" runat="server" Text="仪器型号"></asp:Label>
        <asp:TextBox ID="applicationVersion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label26" runat="server" Text="钻孔日期"></asp:Label>
        <asp:TextBox ID="drillStartTime" runat="server"></asp:TextBox>
        <asp:TextBox ID="drillEndTime" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label27" runat="server" Text="水位深度"></asp:Label>
        <asp:TextBox ID="waterDeep" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label28" runat="server" Text="基建面高程"></asp:Label>
        <asp:TextBox ID="capitalHeight" runat="server"></asp:TextBox>
        <asp:Label ID="Label29" runat="server" Text="推荐承载力"></asp:Label>
        <asp:TextBox ID="recommandBearing" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label30" runat="server" Text="单轴抗压强"></asp:Label>
        <asp:TextBox ID="uniaxialCompressiveStreth" runat="server"></asp:TextBox>
        <asp:Label ID="Label31" runat="server" Text="模型"></asp:Label>
        <asp:TextBox ID="mmodel" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label32" runat="server" Text="比例尺"></asp:Label>
        <asp:TextBox ID="scale" runat="server"></asp:TextBox><br />
  
 
    


            
  </div>
  <div id="tabs-2">
    <asp:Label ID="Label1" runat="server" Text="地层编号:"></asp:Label>
        <asp:TextBox ID="strataCode" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="地层代号:"></asp:Label>
        <asp:TextBox ID="strataID" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server" Text="开始深度:"></asp:Label>
        <asp:TextBox ID="startDeep" runat="server"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="结束深度:"></asp:Label>
        <asp:TextBox ID="endDeep" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label5" runat="server" Text="厚度:"></asp:Label>
        <asp:TextBox ID="thickness" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="层底标高:"></asp:Label>
        <asp:TextBox ID="bottomElevation" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label7" runat="server" Text="地层描述:"></asp:Label>
        <asp:TextBox ID="strataDescription" runat="server"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="图例号:"></asp:Label>
        <asp:TextBox ID="legendNO" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label9" runat="server" Text="图例高度:"></asp:Label>
        <asp:TextBox ID="legendHeight" runat="server"></asp:TextBox>
        <asp:Label ID="Label10" runat="server" Text="图例宽度:"></asp:Label>
        <asp:TextBox ID="legendWidth" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label11" runat="server" Text="图例说明:"></asp:Label>
        <asp:TextBox ID="legendExplation" runat="server"></asp:TextBox>
        <asp:Label ID="Label12" runat="server" Text="接触关系:"></asp:Label>
        <asp:TextBox ID="contactRelation" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label13" runat="server" Text="岩芯采取:"></asp:Label>
        <asp:TextBox ID="coreTake" runat="server"></asp:TextBox>
        <asp:Label ID="Label14" runat="server" Text="密度:"></asp:Label>
        <asp:TextBox ID="density" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label15" runat="server" Text="含水量:"></asp:Label>
        <asp:TextBox ID="waterInclude" runat="server"></asp:TextBox>
        <asp:Label ID="Label16" runat="server" Text="备注:"></asp:Label>
        <asp:TextBox ID="remarks" runat="server"></asp:TextBox>
        <br />
    
        <asp:Button ID="addMessageToGridview" runat="server" Text="添加" OnClick="addMessageToGridview_Click" />
      
      <asp:HiddenField ID="HiddenField1" runat="server" OnValueChanged="HiddenField1_ValueChanged" />     
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">           
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />                   
        </asp:GridView>  
        
        <asp:Button ID="btnMakingFigure" runat="server" Text="成图" OnClick="btnMakingFigure_Click" />
      

     </div>           
    <div id="tabs-3">

        </div>
   </form>
</body>
</html>
