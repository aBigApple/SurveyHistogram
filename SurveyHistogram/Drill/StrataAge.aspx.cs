using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.BLL.Drill;

namespace FineUITest.Drill
{
    public partial class StrataAge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //第一次加载，
            if (!IsPostBack)
            {
                string param1 = Request.QueryString["param1"];

                if (!String.IsNullOrEmpty(param1))
                {
                    TextBox1.Text = param1;
                }

                btnClose.OnClientClick = ActiveWindow.GetHideReference();

                getStrataAgeName();

            }          
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(TextBox1.Text, TextBox1.Text + " - 第二个值") + ActiveWindow.GetHideReference());
        }

        protected void btnClosePostBack_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void strataJiebig_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkStrataJiebig();
            if (strataTong.Text == "" || strataTong.SelectedText == null) strataTong.Items.Clear();
            
            if (strataJie.Text == "" || strataJie.SelectedText == null) strataJie.Items.Clear();
        }

        protected void strataXi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (strataTong.Text == "" || strataTong.SelectedText == null) strataTong.Items.Clear();
            checkStrataXi();
            
            if (strataJie.Text == "" || strataJie.SelectedText == null) strataJie.Items.Clear();
        }

        protected void strataTong_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkStrataTong();
        }

        private static DataSet ds = new DataSet();
        //从数据库获得地层年代的方法
        private void getStrataAgeName()
        {
            drilBLL pjb = new drilBLL(); 
            ds = pjb.getStrataAgeName();//得到包含四个表数据的DtaSet
        } 
        
        private void checkStrataJiebig()
        {
            

            List<CustomClass> strataXiCodeNameList = new List<CustomClass>();
            int rowLength = ds.Tables[0].Rows.Count;//第一张表 系

            for (int i=0;i< rowLength;i++)
            {               
                string fatherCodeID = ds.Tables[0].Rows[i][1].ToString();
                if (fatherCodeID == strataJiebig.SelectedValue)
                {
                    strataXiCodeNameList.Add(new CustomClass( ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][2].ToString()));//父节点编号                  
                }
            }
      
            if(strataXiCodeNameList.Count!=0)
            {
                strataXi.DataValueField = "ID";
                strataXi.DataTextField = "Name";
                strataXi.DataSource = strataXiCodeNameList;
                strataXi.DataBind();
            }
            
            
        }

        //纪---统    
        private void checkStrataXi()
        {
            if(strataTong.SelectedText==null)
            {
                int rowLength = ds.Tables[1].Rows.Count;//第二张表 系
                List<CustomClass> strataCodeNameList = new List<CustomClass>();
                string id = "0";
                foreach (FineUI.ListItem item in strataXi.Items)
                {
                    if (item.Text.Replace("\n", string.Empty).Replace("\r", string.Empty) == strataXi.Text)
                    {
                        id = item.Value;
                        break;
                    }

                }
                for (int i = 0; i < rowLength; i++)
                {
                    string fatherCodeID = ds.Tables[1].Rows[i][1].ToString();

                    if (fatherCodeID == id)
                    {
                        strataCodeNameList.Add(new CustomClass(ds.Tables[1].Rows[i][0].ToString(), ds.Tables[1].Rows[i][2].ToString()));
                    }

                }
                if (strataCodeNameList.Count != 0)
                {
                    strataTong.DataValueField = "ID";
                    strataTong.DataTextField = "Name";
                    strataTong.DataSource = strataCodeNameList;
                    strataTong.DataBind();
                }
            }
        }

        //纪---统
        private void checkStrataTong()
        {
            int rowLength = ds.Tables[2].Rows.Count;//第三张表 系
            List<CustomClass> strataCodeNameList = new List<CustomClass>();
            string id = "0";
            foreach (FineUI.ListItem item in strataTong.Items)
            {
                if (item.Text == strataTong.SelectedText)
                {
                    id = item.Value;
                    break;
                }

            }
            for (int i = 0; i < rowLength; i++)
            {
                string fatherCodeID = ds.Tables[2].Rows[i][1].ToString();

                if (fatherCodeID == id)
                {
                    strataCodeNameList.Add(new CustomClass(ds.Tables[2].Rows[i][0].ToString(), ds.Tables[2].Rows[i][2].ToString()));
                }

            }
            if (strataCodeNameList.Count != 0)
            {
                strataJie.DataValueField = "ID";
                strataJie.DataTextField = "Name";
                strataJie.DataSource = strataCodeNameList;
                strataJie.DataBind();
            }
        }
    }

    #region CustomClass
    public class CustomClass
    {
        private string _id;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public CustomClass(string id, string name)
        {
            _id = id;
            _name = name;
        }
    }
    #endregion
}