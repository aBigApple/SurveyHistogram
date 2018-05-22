using FineUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineUITest.Drill
{
    public partial class frmPattrenLibrary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindImg();
                string param1 = Request.QueryString["param1"];

                if (!String.IsNullOrEmpty(param1))
                {
                    txtUrl.Text = param1;
                }

                btnClose.OnClientClick = ActiveWindow.GetHideReference();

            }
          
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(txtUrl.Text, txtUrl.Text + " - 第二个值") + ActiveWindow.GetHideReference());
        }

        protected void btnClosePostBack_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CheckSelection();
        }
        //public string imgName;
        //绑定加载图片
        public void bindImg()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("/Images/patternLibriayBMP");
            
            StringBuilder imgList = new StringBuilder();
            DirectoryInfo theFolder = new DirectoryInfo(path);
            FileInfo[] fileInfo = theFolder.GetFiles();  
            foreach (FileInfo NextFile in fileInfo)  //遍历文件
            {

                string imgNum = System.IO.Path.GetFileNameWithoutExtension(NextFile.Name).TrimStart();// 没有扩展名的文件名 “Default”      
                string imgName = geImgtName(imgNum);
                imgList.Append("<div class='worksbox' style='padding:5px; float:left;'><a href='#' ><img  width='70'  style='cursor:pointer;'  height='50' src='/Images/patternLibriayBMP/" + NextFile.Name + "' onclick='getImg(\"" + imgName + "\")'></br>" + imgName + "</img></a></div>");
            }
            setImg.InnerHtml = imgList.ToString();
        }
        //获取图片名称
        public string geImgtName(string numName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("/Images/rockName/");
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            foreach (FileInfo file in fileInfo)  //遍历文件
            {
                string imgNum = System.IO.Path.GetFileNameWithoutExtension(file.Name).Trim();
                if (imgNum == numName) 
                {
                    //解决中文乱码问题
                    StreamReader str = new StreamReader(path + file, Encoding.Default);
                    string readLine = str.ReadLine();//读取一行数据
                    return readLine;
                }
            }
            return null;
        }
       
    }
}