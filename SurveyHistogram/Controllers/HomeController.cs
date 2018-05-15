using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.module;
using System.Text;
using ViewModel;
using System.IO;
using System.Runtime.Serialization;

namespace SurveyHistogram.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetJson()
        {
            Pattern a = new Pattern();
            List<PatternModel> imgList = a.bindImg();
            string strJson = ObjToJson<List<PatternModel>>(imgList);       //泛泛型？    这代码怎么感觉怪怪的。
            return Content(strJson);
        }
        public static string ObjToJson<T>(T data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }
        //基本信息传值
        public ActionResult GetDrillBasicInfo(DrillBasicInfo info)
        {
            return Content(info.projectName);
        }

        //图例号传值
        public ActionResult GetLegend(Legend info)
        {
            return Content(info.legendName);
        }
        //地层描述传值
        public ActionResult GetStrataDescribeInfo(StrataDescribe info)
        {
            
            string rockName = info.rockName;
            string decencyLevel = info.decencyLevel;
            string backCondition = info.backCondition;
            string coreCondition = info.coreCondition;
            string pelletConstituent = info.pelletConstituent;
            string interbeddedRockName = info.interbeddedRockName;
            string adulterant = info.adulterant;
            string collor = info.collor;
            string thicknessConditon = info.thicknessConditon;
            //int strataID = info.strataID;
            //int drillID = info.drillID;

            //为了方便演示，我们直接输出这两个值，表示我们已经拿到了数据
            return Content(rockName + "*****" + decencyLevel);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}