using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Util;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using WebApp.Model;
using WebApp.BLL.Drill;
//using WebApp.BLL;
//using WebApp.BLL.Drill;
using FineUI;
namespace FineUITest.Drill
{
    public partial class DrillMain : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        static DataTable dtsava = new DataTable(); 

        protected void Page_Load(object sender, EventArgs e)
        {
         

       
            if (!IsPostBack)
            {
                //第一次运行时的地方（初始化）以后再不运行
                //创建DataTable并且与GridView绑定
                makeABindingTable();
             
               
            }
            //
            //dtsava = (DataTable)GridView1.DataSource;
        }

        /// <summary>
        /// 建表格
        /// </summary>
        private void makeABindingTable()
        {
            DataColumn dcl1 = new DataColumn("地层编号", System.Type.GetType("System.String")); dt.Columns.Add(dcl1);
            DataColumn dcl2 = new DataColumn("地层代号", System.Type.GetType("System.String")); dt.Columns.Add(dcl2);
            DataColumn dcl3 = new DataColumn("开始深度", System.Type.GetType("System.String")); dt.Columns.Add(dcl3);
            DataColumn dcl4 = new DataColumn("结束深度", System.Type.GetType("System.String")); dt.Columns.Add(dcl4);
            DataColumn dcl5 = new DataColumn("厚度", System.Type.GetType("System.String")); dt.Columns.Add(dcl5);
            DataColumn dcl6 = new DataColumn("层底标高", System.Type.GetType("System.String")); dt.Columns.Add(dcl6);
            DataColumn dcl7 = new DataColumn("地层描述", System.Type.GetType("System.String")); dt.Columns.Add(dcl7);
            DataColumn dcl8 = new DataColumn("图例号", System.Type.GetType("System.String")); dt.Columns.Add(dcl8);
            DataColumn dcl9 = new DataColumn("图例高度", System.Type.GetType("System.String")); dt.Columns.Add(dcl9);
            DataColumn dcl10 = new DataColumn("图例宽度", System.Type.GetType("System.String")); dt.Columns.Add(dcl10);
            DataColumn dcl11 = new DataColumn("图例说明", System.Type.GetType("System.String")); dt.Columns.Add(dcl11);
            DataColumn dcl12 = new DataColumn("接触关系", System.Type.GetType("System.String")); dt.Columns.Add(dcl12);
            DataColumn dcl13 = new DataColumn("岩芯采取", System.Type.GetType("System.String")); dt.Columns.Add(dcl13);
            DataColumn dcl14 = new DataColumn("密度", System.Type.GetType("System.String")); dt.Columns.Add(dcl14);
            DataColumn dcl15 = new DataColumn("含水量", System.Type.GetType("System.String")); dt.Columns.Add(dcl15);
            DataColumn dcl16 = new DataColumn("备注", System.Type.GetType("System.String")); dt.Columns.Add(dcl16);

            getDataBind();//数据绑定
        }

        /// <summary>
        /// 初始化是数据绑定
        /// </summary>
        private void getDataBind()
        {
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
            }
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                int colnumcount = dt.Columns.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = colnumcount;
                GridView1.Rows[0].Cells[0].Text = "没有相关记录";
                GridView1.Rows[0].Cells[0].Style.Add("color", "red");
            }

        }
        /// <summary>
        /// 再次填写数据是数据绑定
        /// </summary>
        private void getDataBind2()
        {
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }
        /// <summary>
        /// Gridview中添加数据的方法
        /// </summary>
        public void addDataToGridview()
        {
            if (ViewState["dt"] != null)
            {
                dt = ViewState["dt"] as DataTable;//将viewState保存的值给datatable
            }
            else
            {
                makeABindingTable();

            }
            try
            {
                string strataCode = this.strataCode.Text.ToString();//地层编号
                string strataID = this.strataID.Text.ToString();//地层代号
                double startDeep = double.Parse(this.startDeep.Text.ToString());//开始深度
                double endDeep = double.Parse(this.endDeep.Text.ToString());//结束深度
                double thickness = double.Parse(this.thickness.Text.ToString());//厚度
                double bottomElevation = double.Parse(this.bottomElevation.Text.ToString());//层底标高
                string strataDescription = this.strataDescription.Text.ToString();//地层描述
                string legendNO = this.legendNO.Text.ToString();//图例号
                double legendHeight = double.Parse(this.legendHeight.Text.ToString());//图例高度
                double legendWidth = double.Parse(this.legendWidth.Text.ToString());//图例宽度
                string legendExplation = this.legendExplation.Text.ToString();//图例说明
                string contactRelation = this.contactRelation.Text.ToString();//接触关系
                string coreTake = this.coreTake.Text.ToString();//岩芯采取
                string density = this.density.Text.ToString();//密度
                string waterInclude = this.waterInclude.Text.ToString();//含水量
                string remarks = this.remarks.Text.ToString();//备注

                //TableRow tr = new TableRow();
                dt.Rows.Add(dt.NewRow());
                int rl = GridView1.Rows.Count;
                DataRow row = dt.Rows[rl - 1];

                row["地层编号"] = strataCode;
                row["地层代号"] = strataID;
                row["开始深度"] = startDeep;
                row["结束深度"] = endDeep;
                row["厚度"] = thickness;
                row["层底标高"] = bottomElevation;
                row["地层描述"] = strataDescription;
                row["图例号"] = legendNO;
                row["图例高度"] = legendHeight;
                row["图例宽度"] = legendWidth;
                row["图例说明"] = legendExplation;
                row["接触关系"] = contactRelation;
                row["岩芯采取"] = coreTake;
                row["密度"] = density;
                row["含水量"] = waterInclude;
                row["备注"] = remarks;
                //dt.Rows.Add(row);

                getDataBind2();

                // dt.Rows.Add(dt.NewRow());                
                ViewState["dt"] = dt;//用ViewState保存一个DataTable

            }
            catch (Exception ex)
            {
                //throw ex;
                Response.Write("<script>alert('数量只能为数字，请输入数字信息，谢谢合作！')</script>");
            }
        }
        //成图事件
        protected void btnMakingFigure_Click(object sender, EventArgs e)
        {
            DrillUsing dd = new DrillUsing();
            DataTable datatable = getDataTable();
            //double plottingScale=double.Parse( this.scale.Text.ToString());
            //dd.setGeologyTableData(dt);
            //string saying = dd.setData(dtsava, plottingScale, this.projectName.Text, this.programName.Text, this.drillCode.Text, this.drillHoleStadardHeight.Text,
             //this.drillLocation.Text, this.drillLocation1.Text, this.drillLocation2.Text, this.applicationCoordinateX.Text,
             //  this.applicationCoordinateY.Text, this.combSituTest.Text, this.applicationVersion.Text, this.drillStartTime.Text,
             //    this.drillEndTime.Text, this.waterDeep.Text, this.capitalHeight.Text, this.recommandBearing.Text, this.uniaxialCompressiveStreth.Text,
             //      this.mmodel.Text);
            //string saying = dd.getTableData();
           // Response.Write("<script language=javascript>alert('"+saying+"')</script>" );
            
        }

        /// <summary>
        /// 将GridView中的值赋给DataTable
        /// </summary>
        public DataTable getDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn dcl1 = new DataColumn("地层编号", System.Type.GetType("System.String")); dt.Columns.Add(dcl1);
            DataColumn dcl2 = new DataColumn("地层代号", System.Type.GetType("System.String")); dt.Columns.Add(dcl2);
            DataColumn dcl3 = new DataColumn("开始深度", System.Type.GetType("System.String")); dt.Columns.Add(dcl3);
            DataColumn dcl4 = new DataColumn("结束深度", System.Type.GetType("System.String")); dt.Columns.Add(dcl4);
            DataColumn dcl5 = new DataColumn("厚度", System.Type.GetType("System.String")); dt.Columns.Add(dcl5);
            DataColumn dcl6 = new DataColumn("层底标高", System.Type.GetType("System.String")); dt.Columns.Add(dcl6);
            DataColumn dcl7 = new DataColumn("地层描述", System.Type.GetType("System.String")); dt.Columns.Add(dcl7);
            DataColumn dcl8 = new DataColumn("图例号", System.Type.GetType("System.String")); dt.Columns.Add(dcl8);
            DataColumn dcl9 = new DataColumn("图例高度", System.Type.GetType("System.String")); dt.Columns.Add(dcl9);
            DataColumn dcl10 = new DataColumn("图例宽度", System.Type.GetType("System.String")); dt.Columns.Add(dcl10);
            DataColumn dcl11 = new DataColumn("图例说明", System.Type.GetType("System.String")); dt.Columns.Add(dcl11);
            DataColumn dcl12 = new DataColumn("接触关系", System.Type.GetType("System.String")); dt.Columns.Add(dcl12);
            DataColumn dcl13 = new DataColumn("岩芯采取", System.Type.GetType("System.String")); dt.Columns.Add(dcl13);
            DataColumn dcl14 = new DataColumn("密度", System.Type.GetType("System.String")); dt.Columns.Add(dcl14);
            DataColumn dcl15 = new DataColumn("含水量", System.Type.GetType("System.String")); dt.Columns.Add(dcl15);
            DataColumn dcl16 = new DataColumn("备注", System.Type.GetType("System.String")); dt.Columns.Add(dcl16);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                dt.Rows.Add(GridView1.Rows[i]);
            }
            return dt;
        }

        protected void addMessageToGridview_Click(object sender, EventArgs e)
        {
            addDataToGridview();

        }

        protected void HiddenField1_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         
        }
    }
}