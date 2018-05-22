using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace FineUITest.Drill
{
    public partial class histogramTypeChoose : System.Web.UI.Page
    {
        /// <summary>
        /// 用来选择柱状图成图类型的web窗体类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnPostBackClose.OnClientClick = ActiveWindow.GetHidePostBackReference();
                acosticWave.OnClientClick = Confirm.GetShowReference("确认制作声波钻孔柱状图？", String.Empty, MessageBoxIcon.Question, acosticWave.GetPostBackEventReference(), acosticWave.GetPostBackEventReference("Cancel"));
                rock.OnClientClick = Confirm.GetShowReference("确认制作岩石钻孔柱状图？", String.Empty, MessageBoxIcon.Question, rock.GetPostBackEventReference(), rock.GetPostBackEventReference("Cancel"));

            }
        }

        protected void btnPostBackClose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        
        protected void acosticWave_Click(object sender, EventArgs e)
        {
            if (GetRequestEventArgument() == "Cancel")
            {

                Alert.Show("取消执行操作三！");
            }
            else
            {

                Alert.Show("执行了操作三！");
            }

        }
        protected void rock_Click(object sender, EventArgs e)
        {
            if (GetRequestEventArgument() == "Cancel")
            {
                Alert.Show("取消执行操作三！");
            }
            else
            {
                Alert.Show("执行了操作三！");
            }

        }
        public string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            string path;
            path = getAcusticWaveDt();
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(path) + ActiveWindow.GetHideReference());
        }


        //上传excel表格
        protected string getAcusticWaveDt()
        {
            string strPath = "F://WorkSpace//" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";  //生成新表的路径

            File1.PostedFile.SaveAs(strPath);

            //读取的方法
            string mystring = "Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = '" + strPath + "';Extended Properties=Excel 8.0";

            OleDbConnection cnnxls = new OleDbConnection(mystring);
            cnnxls.Open();//外部表不是预期的格式
            OleDbDataAdapter myDa = new OleDbDataAdapter("select * from [Sheet1$]", cnnxls);

            DataSet myDs = new DataSet();

            myDa.Fill(myDs);

            DataGrid1.DataSource = myDs.Tables[0];

            DataGrid1.DataBind();
            return strPath;
        }
    }
}