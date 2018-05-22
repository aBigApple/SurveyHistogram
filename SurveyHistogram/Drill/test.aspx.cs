using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Data;
using WebApp.Model;
using WebApp.BLL;
using WebApp.BLL.Drill;

namespace FineUITest.Drill
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                btnResetAll.OnClientClick =  Form2.GetResetReference();
                startDate.MaxDate = DateTime.Now;
                endDate.MaxDate = DateTime.Now;
                bindData();
                Button2.OnClientClick = Confirm.GetShowReference("确认执行操作三？", String.Empty, MessageBoxIcon.Question, Button2.GetPostBackEventReference(), String.Empty);

                string openUrl = String.Format("./histogramTypeChoose.aspx?selected=<script>encodeURIComponent({0})</script>", tbxProvince.GetValueReference());
                btnWave.OnClientClick = Window1.GetSaveStateReference(tbxProvince.ClientID)
                    + Window1.GetShowReference(openUrl);

                makeHistogram.OnClientClick = Window3.GetShowReference("./histogramTypeChoose.aspx");
                Button2.OnClientClick = Window3.GetShowReference("./histogramTypeChoose.aspx");


                //柱状图预览
                /*
                StringBuilder listBuilder = new StringBuilder();
                listBuilder.Append("<a class='media' href='/Images/AcosticBoreholeTable.pdf' id='PDFFile'>柱状图预览</a>");
                main.InnerHtml = listBuilder.ToString(); */

                makeABindingTable();

            }
            //makeABindingTable();
            bindWindow();
            
        }

        #region BindGrid

        private void bindData()
        {
            //WebApp.Model.Drill.ProjectModel projMod = new WebApp.Model.Drill.ProjectModel();
            ProjecBLL pjb=new ProjecBLL ();
           // List<WebApp.Model.Drill.ProjectModel> projectNameList = new List<WebApp.Model.Drill.ProjectModel>();
            List<string> projNameList = new List<string>();
            projNameList = pjb.getProjectName();
            projectName.DataSource = projNameList;
            projectName.DataBind();
        }



        #endregion


        protected void dizhi_ServerClick1(object sender, EventArgs e)
        {

            Alert.ShowInTop("您好！");
        }

        protected void DatePicker1_TextChanged(object sender, EventArgs e)
        {
            if (startDate.SelectedDate.HasValue)
            {
                endDate.SelectedDate = startDate.SelectedDate.Value.AddDays(3);
            }
        }
        //成图
        protected void makeHistogram_Click(object sender, EventArgs e)
        {
            
            bindDataTable();
            DrillUsing dd = new DrillUsing();
            //DataTable datatable = getDataTable();
            double plottingScale = double.Parse(this.scale.Text.ToString());
          
            string saying = dd.makeFigure(dt, plottingScale, this.projectName.Text, this.programName.Text, this.drillCode.Text, this.drillHoleStandardHeight.Text,
             this.locationIdentify.Text, this.mileagePile.Text, this.deviationDistance.Text, this.coordinateX.Text,
               this.coordinateY.Text, this.startDate.Text,
                 this.endDate.Text, this.waterDepth.Text, this.capitalHeight.Text, this.recommandBearing.Text, this.uniaxialCompressiveStreth.Text);
            

            Alert.Show("执行了操作一！");
          
        }
        protected void btnWave_Click(object sender, EventArgs e)
        {
            if(drillCode.Text!=""|| drillCode.SelectedText!="")
            {
                string openUrl = String.Format("./histogramTypeChoose.aspx?selected=<script>encodeURIComponent({0})</script>", tbxProvince.GetValueReference());
                btnRock.OnClientClick = Window1.GetSaveStateReference(tbxProvince.ClientID)
                    + Window1.GetShowReference(openUrl);

                if(tbxProvince.Text!=null||tbxProvince.Text!="")
                {

                }


                Alert.ShowInTop("点击了自定义按钮");
            }
            else
            {
                Alert.ShowInTop("请选择或输入钻孔编号");
            }
            
        }
        private delegate void ProcessFormField(Field field);

        private void ResolveFormField(ProcessFormField process)
        {
            
        }
        public static void Priview(System.Web.UI.Page p, string inFilePath)
        {
            //p.Visible = true;

            /* p.Page.Response.ContentType = "Application/pdf";
             string fileName = inFilePath.Substring(inFilePath.LastIndexOf('\\') + 1);
             p.Page.Response.AddHeader("content-disposition", "filename=" + fileName);
             p.Page.Response.WriteFile(inFilePath);
             p.Page.Response.End(); */
            p.Response.ContentType = "Application/pdf";
            HttpContext.Current.Response.ContentType = "Application/pdf";
                string fileName = inFilePath.Substring(inFilePath.LastIndexOf('\\') + 1);
                HttpContext.Current.Response.AddHeader("content-disposition", "filename=" + fileName);
                HttpContext.Current.Response.WriteFile(inFilePath);
                HttpContext.Current.Response.End(); 
        }

        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            Alert.ShowInTop("触发了 Window1 的关闭事件！");
        }
        protected void Window2_Close(object sender, WindowCloseEventArgs e)
        {
            Alert.ShowInTop("触发了 Window2 的关闭事件！");
        }

        protected void Window3_Close(object sender, WindowCloseEventArgs e)
        {
            Alert.ShowInTop("触发了 Window1 的关闭事件！");
        }
        protected void Window4_Close(object sender, WindowCloseEventArgs e)
        {
            Alert.ShowInTop("触发了 Window2 的关闭事件！");
        }
      
        //绑定弹出窗体
        private void bindWindow()
        {
            strataAge1.OnClientTriggerClick = Window1.GetSaveStateReference(strataAge1.ClientID, HiddenField1.ClientID)
                + Window1.GetShowReference("./StrataAge.aspx");
            strataAge2.OnClientTriggerClick = Window1.GetSaveStateReference(strataAge2.ClientID, HiddenField2.ClientID)
                + Window1.GetShowReference("./StrataAge.aspx");
            strataAge3.OnClientTriggerClick = Window1.GetSaveStateReference(strataAge3.ClientID, HiddenField3.ClientID)
                + Window1.GetShowReference("./StrataAge.aspx");
            strataAge4.OnClientTriggerClick = Window1.GetSaveStateReference(strataAge4.ClientID, HiddenField4.ClientID)
                + Window1.GetShowReference("./StrataAge.aspx");
            strataAge5.OnClientTriggerClick = Window1.GetSaveStateReference(strataAge5.ClientID, HiddenField5.ClientID)
                + Window1.GetShowReference("./StrataAge.aspx");
            strataAge6.OnClientTriggerClick = Window1.GetSaveStateReference(strataAge6.ClientID, HiddenField6.ClientID)
                + Window1.GetShowReference("./StrataAge.aspx");

            strataDescription1.OnClientTriggerClick = Window1.GetSaveStateReference(strataDescription1.ClientID, HiddenField7.ClientID)
                + Window1.GetShowReference("./StrataDescription.aspx");
            strataDescription2.OnClientTriggerClick = Window1.GetSaveStateReference(strataDescription2.ClientID, HiddenField8.ClientID)
                + Window1.GetShowReference("./StrataDescription.aspx");
            strataDescription3.OnClientTriggerClick = Window1.GetSaveStateReference(strataDescription3.ClientID, HiddenField9.ClientID)
                + Window1.GetShowReference("./StrataDescription.aspx");
            strataDescription4.OnClientTriggerClick = Window1.GetSaveStateReference(strataDescription4.ClientID, HiddenField10.ClientID)
                + Window1.GetShowReference("./StrataDescription.aspx");
            strataDescription5.OnClientTriggerClick = Window1.GetSaveStateReference(strataDescription5.ClientID, HiddenField11.ClientID)
                + Window1.GetShowReference("./StrataDescription.aspx");
            strataDescription6.OnClientTriggerClick = Window1.GetSaveStateReference(strataDescription6.ClientID, HiddenField12.ClientID)
                + Window1.GetShowReference("./StrataDescription.aspx");


            legendNO1.OnClientTriggerClick = Window2.GetSaveStateReference(legendNO1.ClientID, HiddenField13.ClientID)
               + Window2.GetShowReference("./PattrenLibrary.aspx");
            legendNO2.OnClientTriggerClick = Window2.GetSaveStateReference(legendNO2.ClientID, HiddenField14.ClientID)
               + Window2.GetShowReference("./PattrenLibrary.aspx");
            legendNO3.OnClientTriggerClick = Window2.GetSaveStateReference(legendNO3.ClientID, HiddenField15.ClientID)
               + Window2.GetShowReference("./PattrenLibrary.aspx");
            legendNO4.OnClientTriggerClick = Window2.GetSaveStateReference(legendNO4.ClientID, HiddenField16.ClientID)
               + Window2.GetShowReference("./PattrenLibrary.aspx");
            legendNO5.OnClientTriggerClick = Window2.GetSaveStateReference(legendNO5.ClientID, HiddenField17.ClientID)
               + Window2.GetShowReference("./PattrenLibrary.aspx");
            legendNO6.OnClientTriggerClick = Window2.GetSaveStateReference(legendNO6.ClientID, HiddenField18.ClientID)
               + Window2.GetShowReference("./PattrenLibrary.aspx");

            legendExplationSymbol1.OnClientTriggerClick = Window2.GetSaveStateReference(legendExplationSymbol1.ClientID, HiddenField19.ClientID)
                + Window1.GetShowReference("./PatternException.aspx");
            legendExplationSymbol2.OnClientTriggerClick = Window2.GetSaveStateReference(legendExplationSymbol2.ClientID, HiddenField20.ClientID)
                + Window1.GetShowReference("./PatternException.aspx");
            legendExplationSymbol3.OnClientTriggerClick = Window2.GetSaveStateReference(legendExplationSymbol3.ClientID, HiddenField21.ClientID)
                + Window1.GetShowReference("./PatternException.aspx");
            legendExplationSymbol4.OnClientTriggerClick = Window2.GetSaveStateReference(legendExplationSymbol4.ClientID, HiddenField22.ClientID)
                + Window1.GetShowReference("./PatternException.aspx");
            legendExplationSymbol5.OnClientTriggerClick = Window2.GetSaveStateReference(legendExplationSymbol5.ClientID, HiddenField23.ClientID)
                + Window1.GetShowReference("./PatternException.aspx");
            legendExplationSymbol6.OnClientTriggerClick = Window2.GetSaveStateReference(legendExplationSymbol6.ClientID, HiddenField24.ClientID)
                + Window1.GetShowReference("./PatternException.aspx");


            contactRelationSymbol1.OnClientTriggerClick = Window2.GetSaveStateReference(contactRelationSymbol1.ClientID, HiddenField25.ClientID)
               + Window2.GetShowReference("./PatternContectSymbol.aspx");
            contactRelationSymbol2.OnClientTriggerClick = Window2.GetSaveStateReference(contactRelationSymbol2.ClientID, HiddenField26.ClientID)
               + Window2.GetShowReference("./PatternContectSymbol.aspx");
            contactRelationSymbol3.OnClientTriggerClick = Window2.GetSaveStateReference(contactRelationSymbol3.ClientID, HiddenField27.ClientID)
               + Window2.GetShowReference("./PatternContectSymbol.aspx");
            contactRelationSymbol4.OnClientTriggerClick = Window2.GetSaveStateReference(contactRelationSymbol4.ClientID, HiddenField28.ClientID)
               + Window2.GetShowReference("./PatternContectSymbol.aspx");
            contactRelationSymbol5.OnClientTriggerClick = Window2.GetSaveStateReference(contactRelationSymbol5.ClientID, HiddenField29.ClientID)
               + Window2.GetShowReference("./PatternContectSymbol.aspx");
            contactRelationSymbol6.OnClientTriggerClick = Window2.GetSaveStateReference(contactRelationSymbol6.ClientID, HiddenField30.ClientID)
               + Window2.GetShowReference("./PatternContectSymbol.aspx");         

        }
        
        //获取地质表中的值
        public void getTableData()
        {
            //DataView dv = 
            int rowCount = myDrillTable.Rows.Count;
            for (int i = 0; i < rowCount;i++ )
            {
                //myDrillTable.Rows[i][1]
            }
            foreach(TableRow tr in myDrillTable.Rows)
            {
                //tr.Cells[1].
            }
        }

        public DataTable dt = new DataTable("DrillStrataTable");
        //
        public void bindDataTable()
        {
            //DataTable tblDatas = new DataTable("Datas");
            DataColumn dc = null;

            //赋值给dc，是便于对每一个datacolumn的操作
            dc = dt.Columns.Add("ID", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = false;//

            dc = dt.Columns.Add("地层年代", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("开始深度", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("结束深度", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("厚度", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("层底标高", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("地层描述", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("图例号", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("图例说明", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("接触关系", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("岩芯采取", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("含水量", System.Type.GetType("System.String"));
            dc = dt.Columns.Add("备注", System.Type.GetType("System.String"));

            DataRow row1 = dt.NewRow();
            row1["地层年代"] = strataAge1.Text;
            row1["开始深度"] = startDepth1.Text;
            row1["结束深度"] = endDepth1.Text;
            row1["厚度"] = thickness1.Text;
            row1["层底标高"] = bottomElevation1.Text;
            row1["地层描述"] = strataDescription1.Text;
            row1["图例号"] = legendNO1.Text;
            row1["图例说明"] = legendExplationSymbol1.Text;
            row1["接触关系"] = contactRelationSymbol1.Text;
            row1["岩芯采取"] = coreTake1.Text;
            row1["含水量"] = waterInclude1.Text;
            row1["备注"] = remarks1.Text;           
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["地层年代"] = strataAge2.Text;
            row2["开始深度"] = startDepth2.Text;
            row2["结束深度"] = endDepth2.Text;
            row2["厚度"] = thickness2.Text;
            row2["层底标高"] = bottomElevation2.Text;
            row2["地层描述"] = strataDescription2.Text;
            row2["图例号"] = legendNO2.Text;
            row2["图例说明"] = legendExplationSymbol2.Text;
            row2["接触关系"] = contactRelationSymbol2.Text;
            row2["岩芯采取"] = coreTake2.Text;
            row2["含水量"] = waterInclude2.Text;
            row2["备注"] = remarks2.Text;
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["地层年代"] = strataAge3.Text;
            row3["开始深度"] = startDepth3.Text;
            row3["结束深度"] = endDepth3.Text;
            row3["厚度"] = thickness3.Text;
            row3["层底标高"] = bottomElevation3.Text;
            row3["地层描述"] = strataDescription3.Text;
            row3["图例号"] = legendNO3.Text;
            row3["图例说明"] = legendExplationSymbol3.Text;
            row3["接触关系"] = contactRelationSymbol3.Text;
            row3["岩芯采取"] = coreTake3.Text;
            row3["含水量"] = waterInclude3.Text;
            row3["备注"] = remarks3.Text;
            dt.Rows.Add(row3);

            DataRow row4 = dt.NewRow();
            row1["地层年代"] = strataAge4.Text;
            row4["开始深度"] = startDepth4.Text;
            row4["结束深度"] = endDepth4.Text;
            row4["厚度"] = thickness4.Text;
            row4["层底标高"] = bottomElevation4.Text;
            row4["地层描述"] = strataDescription4.Text;
            row4["图例号"] = legendNO4.Text;
            row4["图例说明"] = legendExplationSymbol4.Text;
            row4["接触关系"] = contactRelationSymbol4.Text;
            row4["岩芯采取"] = coreTake4.Text;
            row4["含水量"] = waterInclude4.Text;
            row4["备注"] = remarks4.Text;
            dt.Rows.Add(row4);

            DataRow row5 = dt.NewRow();
            row5["地层年代"] = strataAge5.Text;
            row5["开始深度"] = startDepth5.Text;
            row5["结束深度"] = endDepth5.Text;
            row5["厚度"] = thickness5.Text;
            row5["层底标高"] = bottomElevation5.Text;
            row5["地层描述"] = strataDescription5.Text;
            row5["图例号"] = legendNO5.Text;
            row5["图例说明"] = legendExplationSymbol5.Text;
            row5["接触关系"] = contactRelationSymbol5.Text;
            row5["岩芯采取"] = coreTake5.Text;
            row5["含水量"] = waterInclude5.Text;
            row5["备注"] = remarks5.Text;
            dt.Rows.Add(row5);

            DataRow row6 = dt.NewRow();
            row6["地层年代"] = strataAge6.Text;
            row6["开始深度"] = startDepth6.Text;
            row6["结束深度"] = endDepth6.Text;
            row6["厚度"] = thickness6.Text;
            row6["层底标高"] = bottomElevation6.Text;
            row6["地层描述"] = strataDescription6.Text;
            row6["图例号"] = legendNO6.Text;
            row6["图例说明"] = legendExplationSymbol6.Text;
            row6["接触关系"] = contactRelationSymbol6.Text;
            row6["岩芯采取"] = coreTake6.Text;
            row6["含水量"] = waterInclude6.Text;
            row6["备注"] = remarks6.Text;
            dt.Rows.Add(row6);
        }

        //动态创建采样页面的控件
        protected void createCaiYangContr()
        {
            if (ViewState["dtc"] != null)
            {
                dtc = ViewState["dtc"] as DataTable;//将viewState保存的值给datatable
            }
            else
            {
                makeABindingTable();

            }
            try
            {
                double startDeep = double.Parse(this.cStaDepth.Text.ToString());//开始深度
                double endDeep = double.Parse(this.cEndDepth.Text.ToString());//结束深度               
                string cCaiyangCoding = this.cCaiyangCoding.Text.ToString();//采样编号

                //TableRow tr = new TableRow();
                dtc.Rows.Add(dtc.NewRow());
                int rl = GridView1.Rows.Count;
                DataRow row = dtc.Rows[rl - 1];

                row["开始深度"] = startDeep;
                row["结束深度"] = endDeep;
                row["采样编号"] = cCaiyangCoding;
                //dtc.Rows.Add(row);

                getDataBind();

                // dt.Rows.Add(dt.NewRow());                
                ViewState["dtc"] = dtc;//用ViewState保存一个DataTable

            }
            catch (Exception ex)
            {
                //throw ex;
                Response.Write("<script>alert('数量只能为数字，请输入数字信息，谢谢合作！')</script>");
            }

        }
        DataTable dtc = new DataTable("caiYang");

        protected void Page_Init(object sender, EventArgs e)
        {
            //InitGrid();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            createCaiYangContr();
            Alert.ShowInTop("表单验证成功");
        }

        private void getDataBind2()
        {
            GridView1.DataSource = dtc;
            GridView1.DataBind();

        }
        /// <summary>
        /// 采样数据表绑定
        /// </summary>
        private void makeABindingTable()
        {         
              
            DataColumn dcl1 = new DataColumn("开始深度", System.Type.GetType("System.String")); dtc.Columns.Add(dcl1);
            DataColumn dcl2 = new DataColumn("结束深度", System.Type.GetType("System.String")); dtc.Columns.Add(dcl2);
            DataColumn dcl3 = new DataColumn("采样编号", System.Type.GetType("System.String")); dtc.Columns.Add(dcl3);          
            getDataBind();//数据绑定
        }
        //初始化采样表
        private void intCaiyangTable()
        {
            FineUI.BoundField bf;

            bf = new FineUI.BoundField();
            bf.DataField = "aStartDepth";
            bf.DataFormatString = "{0}";
            bf.HeaderText = "开始深度";
           


        }
        private void getDataBind()
        {
            if (dtc.Rows.Count == 0)
            {
                dtc.Rows.Add(dtc.NewRow());
            }
            this.GridView1.DataSource = dtc;
            this.GridView1.DataBind();
            
        }
    }
}