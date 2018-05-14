using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization.Json;
using ViewModel;

namespace BLL.module
{
    //==============================================================
    //  author：fengxiaojuan
    //  时间：2018/5/2 9:40:05
    //  文件名：pattern     
    //==============================================================
    public class Pattern
    {
        //public string imgName;
        //绑定加载图片
        public List<PatternModel> bindImg()
        {

            string path = @"F:\drillHistogramFileStore\legend\patternLibriay";  //程序运行时先在F盘下配置，保证该文件存在

            List<PatternModel> imgList = new List<PatternModel>();
            //StringBuilder imgList = new StringBuilder();
            DirectoryInfo theFolder = new DirectoryInfo(path);
            FileInfo[] fileInfo = theFolder.GetFiles();
            foreach (FileInfo NextFile in fileInfo)  //遍历文件
            {

                string imgNum = System.IO.Path.GetFileNameWithoutExtension(NextFile.Name).TrimStart();// 没有扩展名的文件名 “Default”      
                string imgName = geImgtName(imgNum);
                string imgShow= "../../Content/img/patternLibriay/" + NextFile.Name;
                imgList.Add(new PatternModel() { Name= imgName ,Code=imgNum,Show=imgShow});
            }
            return imgList;
        }
        //获取图片名称
        public string geImgtName(string numName)
        {
            string path = @"F:\drillHistogramFileStore\legend\rockName\";//程序运行时先在F盘下配置，保证该文件存在
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
