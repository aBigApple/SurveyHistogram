<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="histogramView.aspx.cs" Inherits="FineUITest.Drill.histogramView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>钻孔柱状图预览</title>

    <script src="/js/pdfobject.js"></script>
    <script type="text/JavaScript" src="pdfobject.js"></script>


    <script type="text/javascript">
        $(function () {
        $('a.media').media({ width: 800, height: 800 });         
    });
    </script>
</head>
<body>
    <form id="form1" runat="server">
      <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" AutoScroll="false" ShowBorder="false" EnableCollapse="false"
            BodyPadding="5px" Layout="Column" ShowHeader="false" >
            <Items>
                <f:Panel ID="Panel24" ColumnWidth="50%" runat="server" 
                    ShowBorder="false" ShowHeader="false" Margin="0 5px 0 0">
                    <Items>
                        <f:Panel ID="rockWave" runat="server" AutoScroll="true" Title="岩石钻孔柱状图"  Height="800px"
                            BodyPadding="5px" ShowBorder="true" ShowHeader="true" EnableCollapse="true" Margin="0 0 5 0">
                            <Content> 
                                <br />                             
                                <div>
                                  <a class='media' href='/Images/AcosticBoreholeTable.pdf' id='PDFFile'>柱状图预览</a>
                               </div>                                
                            </Content>
                        </f:Panel>                       
                    </Items>
                </f:Panel>
                <f:Panel ID="Panel28" ColumnWidth="50%" runat="server"  RowHeight="100%" 
                    ShowBorder="false" ShowHeader="false" Margin="0 5px 0 0">
                    <Items>
                        <f:Panel ID="acosticBorehole" runat="server" AutoScroll="true" Height="800px"
                            BodyPadding="5px" ShowBorder="true" ShowHeader="true" EnableCollapse="true" Margin="0 0 5 0" 
                             Title="声波钻孔柱状图">
                            <Content>
                                <br />
                                <br />
                                <br />
                                <br />
                            </Content>
                        </f:Panel>                      
                    </Items>
                </f:Panel>               
            </Items>
        </f:Panel>    
    </form>
</body>
</html>
