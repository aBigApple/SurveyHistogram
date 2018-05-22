<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PattrenLibrary.aspx.cs" Inherits="FineUITest.Drill.frmPattrenLibrary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <style type="text/css">
.worksbox{width:114px;height:114px;position:relative;}
.worksbox a{border:1px solid #F0F0E8;background-color:#FFF;padding:6px;display:block;}
.worksbox a:hover{border:1px solid #000;background-color:#6699FF;text-decoration: none;}

</style>
</head>
<body>
    <script type="text/javascript">
        function getImg(getValue) {
            var JSONObject = {
                "name": getValue                
            };
            alert("您所选择的花纹库是：" +"\n"+ JSONObject.name + "");          
            F('<%=txtUrl.ClientID %>').setValue(JSONObject.name);
            
        }
    </script>
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
                    <f:Button ID="btnSelect" OnClick="btnSelect_Click" runat="server" Text="确定"
                        Icon="SystemSave">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
           <f:SimpleForm ID="SimpleForm1" ShowBorder="true" ShowHeader="false" Title="SimpleForm"
                 BodyPadding="5px" runat="server" EnableCollapse="True">

                <Items>
                    
                    <f:DropDownList runat="server" ID="DropDownList1" Required="True">
                    <f:ListItem Text="可选项1" Value="Value1" />
                    <f:ListItem Text="可选项2（不可选择）" Value="Value2" EnableSelect="false" />
                    <f:ListItem Text="可选项3（不可选择）" Value="Value3" EnableSelect="false" />
                    <f:ListItem Text="可选项4" Value="Value4" />
                    <f:ListItem Text="可选项5" Value="Value5" />
                    <f:ListItem Text="可选项6" Value="Value6" />
                    <f:ListItem Text="可选择项7" Value="Value7" />
                    <f:ListItem Text="可选择项8" Value="Value8" />
                    <f:ListItem Text="普通型1 < L > 1.5" Value="普通型1 < L > 1.5" />
                </f:DropDownList>
                    <f:TextBox runat="server"  Label="花纹名称" ID="txtUrl" Required="true" ShowRedStar="true">
                </f:TextBox>

                    <f:ContentPanel ID="ContentPanel2"  ShowBorder="false" Height="450px"
                    BodyPadding="0px" EnableCollapse="true" ShowHeader="false"
                    runat="server" AutoScroll="true" >
                  
                
                         <div  runat="server"  id="setImg" class="" ></div>
                  
                </f:ContentPanel>
                        
            
                </Items>
              
           
      
            </f:SimpleForm>
            
        </Items>
            


    </f:Panel>
     
    <asp:Label runat="server" ID="labTest"></asp:Label>
       
    <div id="outputContainer">
        
    </div>
    </form>
</body>
</html>
