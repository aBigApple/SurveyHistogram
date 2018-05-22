<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="FineUITest.Drill.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta content="IE=7.0000" http-equiv="X-UA-Compatible"/>
   <link rel="stylesheet" href="/css/bootstrap.min.css"/>
	<script src="/js/jquery/jquery-1.10.2.min.js"></script>
    
    <script src="/js/bootstrap.min.js"></script>

    <link rel="stylesheet" href="../css/lanrenzhijia.css" media="all" />
    
    <script type="text/javascript" src="../js/jquery.media.js"></script>

    <title></title>
     <script src="/js/pdfobject.js">         
         window.onload = function Ceshi() {
             var myPDF = new PDFObject({ url: "Image/AcosticBoreholeTable.pdf" }).embed();
         };
  </script>
    <script type="text/javascript">
        $(function () {
        $('a.media').media({ width: 800, height: 800 });         
    });
    </script>
  <style>
  DropDownList {
    display: inline-block;
    width: 5em;
  }
  </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server"/>

<ul id="myTab" class="nav nav-tabs">
	
	<li class="active"><a href="#base" data-toggle="tab">基本信息</a></li>
	<li>
		<a href="#inf" data-toggle="tab">地质信息 </a>
	</li>
    <li>
        <a href="#histogramType" data-toggle="tab">成图类型</a>
    </li> 
    <li>
        <a href="#caiyang" data-toggle="tab">采样</a>
    </li>  
</ul>

        <f:Panel runat="server" ID="Panel1"  Width="1200px" Height="50px"
            EnableIFrame="true" IFrameName="main" IFrameUrl="about:blank"
            EnableCollapse="true" ShowHeader="false" ShowBorder="false">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" Position="Top" >
                    <Items>
                        <f:Button runat="server" ID="Button1" Text="计算" EnablePostBack="false"
                            OnClientClick="updateIFrameUrl2('../basic/hello.aspx');">
                        </f:Button>
                        <f:Button ID="btnResetAll" EnablePostBack="false" Text="重置" runat="server">
                     </f:Button>
                        <f:Button ID="Button2" EnablePostBack="false" Text="保存" runat="server">
                     </f:Button>
                        <f:Button ID="makeHistogram" Text="成图" CssClass="marginr" runat="server" OnClick="makeHistogram_Click"
                                    ValidateForms="Form2">
                                </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Panel>
        <f:Window ID="Window3" Hidden="true" EnableIFrame="true" runat="server"
            EnableMaximize="true" EnableResize="true" Height="200px" Width="300px"
            Title="声波数据导入">
        </f:Window>
<div id="myTabContent" class="tab-content">   
	<div class="tab-pane fade in active" id="base">
        <f:Panel ID="Panel3" runat="server"  BodyPadding="0px" showheader="false" Layout="Fit" ShowBorder="false" Height="800px"  Width="1200px">
            <Items>
        <f:Form Width="600px" BodyPadding="5px" ID="Form2"  EnableCollapse="true" ShowBorder="false" 
            runat="server" showheader="false"   >       
            <Rows>
                <f:FormRow ColumnWidths="10%">
                    <Items>
                        <f:DropDownList ID="projectName" Label="工程名称" runat="server" ForceSelection="false" Required="true" ShowRedStar="True" EmptyText="" >                          
                        </f:DropDownList>                        
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:TextBox ID="programName" ShowRedStar="true" runat="server" Label="项目名称" Required="true"
                            Text="">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:DropDownList ID="drillCode" Label="钻孔编号" runat="server" ForceSelection="true" Required="true" ShowRedStar="True">
                            <f:ListItem Text="CK1" Value="0"></f:ListItem>
                            <f:ListItem Text="CK2" Value="1"></f:ListItem>                            
                        </f:DropDownList>    
                        <f:TextBox ID="drillHoleStandardHeight" ShowRedStar="true" runat="server" Label="孔口标高" Required="true"
                            Text="">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:DropDownList ID="locationIdentify" Label="钻孔位置" runat="server" ForceSelection="false" Required="true" ShowRedStar="True">
                            <f:ListItem Text="Y" Value="0"></f:ListItem>
                            <f:ListItem Text="Z" Value="1"></f:ListItem>                            
                        </f:DropDownList>         
                        <f:TextBox ID="mileagePile" ShowRedStar="true" runat="server" Label="" Required="true"
                            Text="">
                        </f:TextBox>
                        <f:TextBox ID="deviationDistance" ShowRedStar="true" runat="server" Label="" Required="true"
                            Text="">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:TextBox ID="coordinateX" ShowRedStar="true" runat="server" Label="钻孔坐标  X" Required="true"
                            Text="">
                        </f:TextBox>
                        <f:TextBox ID="coordinateY" ShowRedStar="true" runat="server" Label="Y" Required="true"
                            Text="">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
          
                
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>                        
                      <f:DatePicker  ID="startDate" runat="server" Label="开始日期" CssStyle="form-control"  Required="true" AutoPostBack="true" OnTextChanged="DatePicker1_TextChanged"
                           EmptyText="请选择开始日期" ShowRedStar="True"  >
                        </f:DatePicker>                    			
                          <f:DatePicker ID="endDate" Label="结束日期"  CssStyle="form-control"  Required="true" Readonly="false" CompareControl="DatePicker1"
                          DateFormatString="yyyy-MM-dd" CompareOperator="GreaterThan" CompareMessage="结束日期应该大于开始日期"
                         runat="server" ShowRedStar="True" >
                        </f:DatePicker>           
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:NumberBox Label="水位深度" EmptyText="水位深度" ID="waterDepth" NoDecimal="false" runat="server"  Required="true"/>      
                         <f:NumberBox Label="基建面高程" EmptyText="基建面高程" ID="capitalHeight" NoDecimal="false" runat="server"  Required="true"/>      
                                    
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:DropDownList ID="recommandBearing" Label="推荐承载力" runat="server" ForceSelection="false" Required="true" ShowRedStar="True">
                            <f:ListItem Text="test1" Value="0"></f:ListItem>
                            <f:ListItem Text="test2" Value="1"></f:ListItem>
                        </f:DropDownList>         
                                             
                        <f:TextBox ID="uniaxialCompressiveStreth" ShowRedStar="true" runat="server" Label="单轴抗压强" Required="true"
                            Text="">
                        </f:TextBox>
                       
                    </Items>
                </f:FormRow>
               <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:NumberBox Label="柱状图比例尺" EmptyText="请输入比例尺分母值，如：1:500，输入500" ID="scale" NoDecimal="true" NoNegative="True"  runat="server"  Required="true"/>      
                                    
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
            </Items>
        </f:Panel>
        <br />
        </div>

    <style type="text/css">
        .bgbtn {
            background-image: url(../images/acosticWave.png) !important;
            width: 200px;
            height: 30px;
            border-width: 0;
            background-color: transparent;
            margin-right:10px;
            margin-bottom:20px;
            
        }
        .bgbtn1 {
            background-image: url(../images/rock.png) !important;
            width: 200px;
            height: 30px;
            border-width: 0;
            background-color: transparent;
            margin-right:10px;
            margin-bottom:20px;
        }

        .bgbtn .x-frame-ml, .bgbtn .x-frame-mc, .bgbtn .x-frame-mr,
        .bgbtn .x-frame-tl, .bgbtn .x-frame-tc, .bgbtn .x-frame-tr,
        .bgbtn .x-frame-bl, .bgbtn .x-frame-bc, .bgbtn .x-frame-br {
            background-image: none;
            background-color: transparent;
        }
    </style>
    <div class="tab-pane fade in active" id="histogramType">
        <input type="text" onshow="false" id="url"  runat="server" />
        <f:Panel ID="type" runat="server" Height="600px"  Width="1200px"
            AutoScroll="false" ShowBorder="false" EnableCollapse="false"
            BodyPadding="5px" Layout="Column" ShowHeader="false" Title="柱状图类型选择">                          
            <Items>                
               <f:Label ID="Label1" runat="server" Text="请选择钻孔柱状图类型："  >
                </f:Label>                      
                <f:Button ID="btnWave" Text="声波钻孔柱状图" CssClass="bgbtn" runat="server" OnClick="btnWave_Click" />
                <f:Button ID="btnRock" Text="岩石钻孔柱状图" CssClass="bgbtn1" runat="server" OnClick="btnWave_Click"  />
                <f:TextBox ID="tbxProvince" Text="安徽" runat="server" ShowLabel="false" >
                </f:TextBox>
            </Items>
             <Items>
                <f:Panel ID="Panel25" runat="server" Width="1200px"  ShowBorder="true" ShowHeader="false" EnableCollapse="false" >
             </f:Panel>
            </Items>
            
        </f:Panel>               
    </div>


    <script type="text/javascript" src="../js/drillStrataTable.js"></script>
	<div class="tab-pane fade" id="inf">
		<table class="table table-border" id="myDrillTable" runat="server">
            <thead>
                <tr>
                    <th>序号</th>
                  
                    <th>地层代号</th>
                    <th>开始深度</th>
                    <th>结束深度</th>
                    <th>厚度</th>
                    <th>层底标高</th>
                    <th>地层描述</th>
                    <th>图例号</th>
                    <th>图例说明</th>
                    <th>接触关系</th>
                    <th>岩芯采取</th>
                    <th>含水量</th>
                    <th>备注</th>
                    </tr>
                </thead>
            <tr>
                <td>
                   <label style="width:40px">1</label>
                    </td>
                 

                 <td>
         
                        <f:TriggerBox ID="strataAge1" EnableEdit="false"   EmptyText="请选择" EnablePostBack="false" runat="server" width ="70px"   Height="30px" Label="strataAge" ShowLabel="false">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField1" runat="server">
                        </f:HiddenField>
                       
                         <br />
                  
                    </td>

                 <td>
                      <f:NumberBox EmptyText="开始深度" ID="startDepth1" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>                   
                    </td>
                 <td>
                     <f:NumberBox EmptyText="结束深度" ID="endDepth1" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                           <f:NumberBox EmptyText="厚度" ID="thickness1" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                          <f:NumberBox EmptyText="层底标高" ID="bottomElevation1" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
              
                      <td>     
                          <div>
                        <f:TriggerBox ID="strataDescription1" EnableEdit="false"  EmptyText="请输入地层描述" EnablePostBack="false" runat="server"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField2" runat="server">
                        </f:HiddenField>
                        
                         <br />
                          </div>
                      </td>

                      <td>                      
                          <div>
                        <f:TriggerBox ID="legendNO1" EnableEdit="false"  EmptyText="请选择" EnablePostBack="false" runat="server" width ="80px"   Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField3" runat="server">
                        </f:HiddenField>
                       
                         <br />
                          </div>
                    </td>

                      <td>
                           <div>
                               <f:TriggerBox ID="legendExplationSymbol1" EnableEdit="false"  EmptyText="请选择图例说明" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField4" runat="server">
                        </f:HiddenField>
                     
                          </div>
                    </td>
                      <td>
                            <div>
                              <f:TriggerBox ID="contactRelationSymbol1" EnableEdit="false"  EmptyText="请选择接触关系" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField5" runat="server">
                        </f:HiddenField>
                      
                          </div>
                    </td>
                      <td>                        
                          <f:TextBox ID="coreTake1" runat="server" EmptyText="岩芯采取"  Text=""
                               width ="70px" height="30px"   >
                        </f:TextBox>
                    </td>
 
                       <td>
                        <f:TextBox ID="waterInclude1"  runat="server" EmptyText="含水量" Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>
                  <td>
                         <f:TextBox ID="remarks1" runat="server" EmptyText="备注"  Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>

               
                </tr>
              <tr>
               <td>
                   <label style="width:40px">2</label>
                    </td>
                 

                 
                 <td>
         
                        <f:TriggerBox ID="strataAge2" EnableEdit="false"   EmptyText="请选择" EnablePostBack="false" runat="server" width ="70px"   Height="30px" >
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField6" runat="server">
                        </f:HiddenField>
                       
                         <br />
                  
                    </td>

                 <td>
                      <f:NumberBox EmptyText="开始深度" ID="startDepth2" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>                   
                    </td>
                 <td>
                     <f:NumberBox EmptyText="结束深度" ID="endDepth2" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                           <f:NumberBox EmptyText="厚度" ID="thickness2" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                          <f:NumberBox EmptyText="层底标高" ID="bottomElevation2" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
              
                      <td>     
                          <div>
                        <f:TriggerBox ID="strataDescription2" EnableEdit="false"  EmptyText="请输入地层描述" EnablePostBack="false" runat="server"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField7" runat="server">
                        </f:HiddenField>
                        
                         <br />
                          </div>
                      </td>

                      <td>                      
                          <div>
                        <f:TriggerBox ID="legendNO2" EnableEdit="false"  EmptyText="请选择" EnablePostBack="false" runat="server" width ="80px"   Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField8" runat="server">
                        </f:HiddenField>
                       
                         <br />
                          </div>
                    </td>

                      <td>
                           <div>
                               <f:TriggerBox ID="legendExplationSymbol2" EnableEdit="false"  EmptyText="请选择图例说明" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField9" runat="server">
                        </f:HiddenField>
                     
                          </div>
                    </td>
                      <td>
                            <div>
                              <f:TriggerBox ID="contactRelationSymbol2" EnableEdit="false"  EmptyText="请选择接触关系" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField10" runat="server">
                        </f:HiddenField>
                      
                          </div>
                    </td>
                      <td>                        
                          <f:TextBox ID="coreTake2" runat="server" EmptyText="岩芯采取"  Text=""
                               width ="70px" height="30px"   >
                        </f:TextBox>
                    </td>
 
                       <td>
                        <f:TextBox ID="waterInclude2"  runat="server" EmptyText="含水量" Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>
                  <td>
                         <f:TextBox ID="remarks2" runat="server" EmptyText="备注"  Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>


                </tr>
              <tr>
               <td>
                   <label style="width:40px">3</label>
                    </td>
                 

                 <td>
         
                        <f:TriggerBox ID="strataAge3" EnableEdit="false"   EmptyText="请选择" EnablePostBack="false" runat="server" width ="70px"   Height="30px" >
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField11" runat="server">
                        </f:HiddenField>
                       
                         <br />
                  
                    </td>

                 <td>
                      <f:NumberBox EmptyText="开始深度" ID="startDepth3" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>                   
                    </td>
                 <td>
                     <f:NumberBox EmptyText="结束深度" ID="endDepth3" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                           <f:NumberBox EmptyText="厚度" ID="thickness3" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                          <f:NumberBox EmptyText="层底标高" ID="bottomElevation3" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
              
                      <td>     
                          <div>
                        <f:TriggerBox ID="strataDescription3" EnableEdit="false"  EmptyText="请输入地层描述" EnablePostBack="false" runat="server"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField12" runat="server">
                        </f:HiddenField>
                        
                         <br />
                          </div>
                      </td>

                      <td>                      
                          <div>
                        <f:TriggerBox ID="legendNO3" EnableEdit="false"  EmptyText="请选择" EnablePostBack="false" runat="server" width ="80px"   Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField13" runat="server">
                        </f:HiddenField>
                       
                         <br />
                          </div>
                    </td>


                      <td>
                           <div>
                               <f:TriggerBox ID="legendExplationSymbol3" EnableEdit="false"  EmptyText="请选择图例说明" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField14" runat="server">
                        </f:HiddenField>
                       
                          </div>
                    </td>
                      <td>
                            <div>
                              <f:TriggerBox ID="contactRelationSymbol3" EnableEdit="false"  EmptyText="请选择接触关系" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField15" runat="server">
                        </f:HiddenField>
                      
                          </div>
                    </td>
                      <td>                        
                          <f:TextBox ID="coreTake3" runat="server" EmptyText="岩芯采取"  Text=""
                               width ="70px" height="30px"   >
                        </f:TextBox>
                    </td>
                    
                       <td>
                        <f:TextBox ID="waterInclude3"  runat="server" EmptyText="含水量" Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>
                  <td>
                         <f:TextBox ID="remarks3" runat="server" EmptyText="备注"  Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>

               
                </tr>
            <tr>
                <td>
                   <label style="width:40px">4</label>
                    </td>
                 

                 <td>
         
                        <f:TriggerBox ID="strataAge4" EnableEdit="false"   EmptyText="请选择" EnablePostBack="false" runat="server" width ="70px"   Height="30px" >
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField16" runat="server">
                        </f:HiddenField>
                       
                         <br />
                  
                    </td>

                 <td>
                      <f:NumberBox EmptyText="开始深度" ID="startDepth4" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>                   
                    </td>
                 <td>
                     <f:NumberBox EmptyText="结束深度" ID="endDepth4" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                           <f:NumberBox EmptyText="厚度" ID="thickness4" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                          <f:NumberBox EmptyText="层底标高" ID="bottomElevation4" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
              
                      <td>     
                          <div>
                        <f:TriggerBox ID="strataDescription4" EnableEdit="false"  EmptyText="请输入地层描述" EnablePostBack="false" runat="server"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField17" runat="server">
                        </f:HiddenField>
                        
                         <br />
                          </div>
                      </td>

                      <td>                      
                          <div>
                        <f:TriggerBox ID="legendNO4" EnableEdit="false"  EmptyText="请选择" EnablePostBack="false" runat="server" width ="80px"   Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField18" runat="server">
                        </f:HiddenField>
                       
                         <br />
                          </div>
                    </td>

                      <td>
                           <div>
                               <f:TriggerBox ID="legendExplationSymbol4" EnableEdit="false"  EmptyText="请选择图例说明" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField19" runat="server">
                        </f:HiddenField>
                      
                          </div>
                    </td>
                      <td>
                            <div>
                              <f:TriggerBox ID="contactRelationSymbol4" EnableEdit="false"  EmptyText="请选择接触关系" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField20" runat="server">
                        </f:HiddenField>
                    
                          </div>
                    </td>
                      <td>                        
                          <f:TextBox ID="coreTake4" runat="server" EmptyText="岩芯采取"  Text=""
                               width ="70px" height="30px"   >
                        </f:TextBox>
                    </td>
              
                       <td>
                        <f:TextBox ID="waterInclude4"  runat="server" EmptyText="含水量" Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>
                  <td>
                         <f:TextBox ID="remarks4" runat="server" EmptyText="备注"  Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>

            </tr>
            <tr>
                <td>
                   <label style="width:40px">5</label>
                    </td>
                 

                 <td>
         
                        <f:TriggerBox ID="strataAge5" EnableEdit="false"   EmptyText="请选择" EnablePostBack="false" runat="server" width ="70px"   Height="30px" >
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField21" runat="server">
                        </f:HiddenField>
                       
                         <br />
                  
                    </td>

                 <td>
                      <f:NumberBox EmptyText="开始深度" ID="startDepth5" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>                   
                    </td>
                 <td>
                     <f:NumberBox EmptyText="结束深度" ID="endDepth5" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                           <f:NumberBox EmptyText="厚度" ID="thickness5" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                          <f:NumberBox EmptyText="层底标高" ID="bottomElevation5" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
              
                      <td>     
                          <div>
                        <f:TriggerBox ID="strataDescription5" EnableEdit="false"  EmptyText="请输入地层描述" EnablePostBack="false" runat="server"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField22" runat="server">
                        </f:HiddenField>
                        
                         <br />
                          </div>
                      </td>

                      <td>                      
                          <div>
                        <f:TriggerBox ID="legendNO5" EnableEdit="false"  EmptyText="请选择" EnablePostBack="false" runat="server" width ="80px"   Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField23" runat="server">
                        </f:HiddenField>
                     
                         <br />
                          </div>
                    </td>

                      <td>
                           <div>
                               <f:TriggerBox ID="legendExplationSymbol5" EnableEdit="false"  EmptyText="请选择图例说明" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField24" runat="server">
                        </f:HiddenField>
                       
                          </div>
                    </td>
                      <td>
                            <div>
                              <f:TriggerBox ID="contactRelationSymbol5" EnableEdit="false"  EmptyText="请选择接触关系" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField25" runat="server">
                        </f:HiddenField>
                       
                          </div>
                    </td>
                      <td>                        
                          <f:TextBox ID="coreTake5" runat="server" EmptyText="岩芯采取"  Text=""
                               width ="70px" height="30px"   >
                        </f:TextBox>
                    </td>
          
                       <td>
                        <f:TextBox ID="waterInclude5"  runat="server" EmptyText="含水量" Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>
                  <td>
                         <f:TextBox ID="remarks5" runat="server" EmptyText="备注"  Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>

            </tr>
            <tr>
                <td>
                   <label style="width:40px">6</label>
                    </td>
                 

                 <td>
         
                        <f:TriggerBox ID="strataAge6" EnableEdit="false"   EmptyText="请选择" EnablePostBack="false" runat="server" width ="70px"   Height="30px" >
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField26" runat="server">
                        </f:HiddenField>
                       
                         <br />
                  
                    </td>

                 <td>
                      <f:NumberBox EmptyText="开始深度" ID="startDepth6" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>                   
                    </td>
                 <td>
                     <f:NumberBox EmptyText="结束深度" ID="endDepth6" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                           <f:NumberBox EmptyText="厚度" ID="thickness6" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
                      <td>
                          <f:NumberBox EmptyText="层底标高" ID="bottomElevation6" NoDecimal="false" runat="server"  width ="70px" height="30px" Required="true"/>      
                   
                    </td>
              
                      <td>     
                          <div>
                        <f:TriggerBox ID="strataDescription6" EnableEdit="false"  EmptyText="请输入地层描述" EnablePostBack="false" runat="server"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField27" runat="server">
                        </f:HiddenField>
                        
                         <br />
                          </div>
                      </td>

                      <td>                      
                          <div>
                        <f:TriggerBox ID="legendNO6" EnableEdit="false"  EmptyText="请选择" EnablePostBack="false" runat="server" width ="80px"   Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField28" runat="server">
                        </f:HiddenField>
                       
                         <br />
                          </div>
                    </td>
                      <td>
                           <div>
                               <f:TriggerBox ID="legendExplationSymbol6" EnableEdit="false"  EmptyText="请选择图例说明" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField29" runat="server">
                        </f:HiddenField>
                      
                          </div>
                    </td>
                      <td>
                            <div>
                              <f:TriggerBox ID="contactRelationSymbol6" EnableEdit="false"  EmptyText="请选择接触关系" EnablePostBack="false" runat="server"  width ="70px"  Height="30px">
                         </f:TriggerBox>           
                         <f:HiddenField ID="HiddenField30" runat="server">
                        </f:HiddenField>
                       
                          </div>
                    </td>
                      <td>                        
                          <f:TextBox ID="coreTake6" runat="server" EmptyText="岩芯采取"  Text=""
                               width ="70px" height="30px"   >
                        </f:TextBox>
                    </td>         
                       <td>
                        <f:TextBox ID="waterInclude6"  runat="server" EmptyText="含水量" Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>
                  <td>
                         <f:TextBox ID="remarks6" runat="server" EmptyText="备注"  Text="" width ="70px" height="30px">
                        </f:TextBox>
                    </td>

            </tr>
            </table>	
        <!--其他选项窗体-->
        <f:Window ID="Window1" Title="编辑" Hidden="true" EnableIFrame="true" runat="server"
                              EnableMaximize="true" EnableResize="true" Target="Parent" OnClose="Window1_Close"
                                   IsModal="True" Width="650px" Height="450px">
                         </f:Window>
        <!--花纹库窗体-->
         <f:Window ID="Window2" Title="编辑" Hidden="true" EnableIFrame="true" runat="server"
                              EnableMaximize="true" EnableResize="true" Target="Parent" OnClose="Window1_Close"
                                   IsModal="True" Width="550px" Height="350px">
                         </f:Window>
      </div>
	<div class="tab-pane fade" id="caiyang">
		
         <f:NumberBox ID="cStaDepth" runat="server" EmptyText="精度为 2" Label="开始深度" NoDecimal="false" NoNegative="True" Margin="5px" DecimalPrecision="2" Required="True" ShowRedStar="True">
                </f:NumberBox>
        <f:NumberBox ID="cEndDepth" runat="server" EmptyText="精度为 2" Label="结束深度" NoDecimal="false" NoNegative="True" Margin="5px" DecimalPrecision="2" Required="True" ShowRedStar="True" >
                </f:NumberBox>
        <f:TextBox ID="cCaiyangCoding" runat="server" Label="采样编号"  Margin="5px"  EmptyText="输入字符后点击提交按钮，会触发TextChanged事件">
                </f:TextBox>
        <f:Button ID="btnSubmit" runat="server" Text="添加" OnClick="btnSubmit_Click">
                </f:Button>
        <f:Panel ID="Panel2" ShowHeader="false"  ShowBorder="true" Width="1200px" Height="1px"
                    Layout="Column" runat="server">
                    <Items>
                        </Items>
                </f:Panel>


        <style type="text/css">

 .GridViewStyle

{  
     border-right: 10px solid #A7A6AA;

     border-bottom: 2px solid #A7A6AA;

     border-left: 10px solid white;

     border-top: 2px solid white;

     padding: 4px;
     margin-top:5px;

   

}

    </style>

        
        <asp:HiddenField ID="HiddenField31" runat="server" />     
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">           
            
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />                   
        </asp:GridView>  
       <f:Grid ID="Grid1" Width="800px" DataKeyNames="Id,Name" runat="server" Title="表格">
            
        </f:Grid>
        
        <br />


	</div>

    
</div>
       
    
	

    <div id="main" runat="server"></div>

</form>
    <!--选择花纹selectPatternLibrary-->
    
    
</body>
</html>
