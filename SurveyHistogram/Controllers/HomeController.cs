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
using System.Net;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        //地层信息传值
        public ActionResult GetDrillStrataModel(drillStrata info)
        {
            List<drillStrata> strata = new List<drillStrata>();
            strata.Add(info);
            return Content(info.strataDescribe);
        }

        //地层数据
        [HttpPost]    
        public ActionResult SetDrillStrataInfo()
        {        
            List<drillStrata> stratas =new List<drillStrata>();
            var sr = new StreamReader(Request.InputStream);
            string stream = sr.ReadToEnd() ;//获得json数据流
        
            var js = new System.Web.Script.Serialization.JavaScriptSerializer();
            var jarr = js.Deserialize<Dictionary<string, drillStrata>>(stream);
            foreach (var j in jarr)
            {
                var strata = j.Value;
                drillStrata getinfo = new drillStrata();
                getinfo.strataAge = strata.strataAge;
                getinfo.strataDepth = strata.strataDepth;
                getinfo.endDepth = strata.endDepth;
                getinfo.thinckness = strata.thinckness;
                getinfo.bottonElevation = strata.bottonElevation;
                getinfo.strataDescribe = strata.strataDescribe;
                getinfo.legendName = strata.legendName;
                getinfo.legendExplation = strata.legendExplation;
                getinfo.contactRelation = strata.contactRelation;
                getinfo.coreTake = strata.coreTake;
                getinfo.density = strata.density;
                getinfo.waterInclude = strata.waterInclude;
                getinfo.remarks = strata.remarks;
                stratas.Add(getinfo);
                //Console.WriteLine(string.Format("{0}:{1}", j.Key, j.Value));
            }
            
            return null;
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