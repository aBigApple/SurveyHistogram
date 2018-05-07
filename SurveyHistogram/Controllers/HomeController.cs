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
            //List<Person> list = new List<Person>();
            //list.Add(new Person(1, "张飞", 21));
            //list.Add(new Person(2, "关羽", 22));
            //list.Add(new Person(3, "刘备", 23));
            //return Json(list,JsonRequestBehavior.AllowGet);     //.Net还是很威武的，这行代码是可以运行并得到正确结果的，然后注释来看看前辈们的List<T>转Json的代码//
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