using System.Web;
using System.Web.Optimization;

namespace SurveyHistogram
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/components_js").Include(
                        "~/Content/components/select2/dist/js/select2.full.min.js",
                        "~/Content/plugins/input-mask/jquery.inputmask.js",
                        "~/Content/plugins/input-mask/jquery.inputmask.date.extensions.js",
                        "~/Content/plugins/input-mask/jquery.inputmask.extensions.js",
                        "~/Content/components/moment/min/moment.min.js",
                        "~/Content/components/bootstrap-daterangepicker/daterangepicker.js",
                        "~/Content/components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",
                        "~/Content/plugins/timepicker/bootstrap-timepicker.min.js",
                        "~/Content/components/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/Content/plugins/iCheck/icheck.min.js",
                        "~/Content/components/fastclick/lib/fastclick.js",                       
                        "~/Scripts/basejs/module.js",
                        "~/Scripts/basejs/module.form.validate.js",
                        "~/Scripts/basejs/pdfShow.js",
                        "~/Scripts/site.js"));

            //绑定地图的js
            bundles.Add(new ScriptBundle("~/bundles/map").Include(
                "~/Scripts/map/jquery.mloading.js",
                "~/Scripts/map/api.js",
                "~/Scripts/map/AreaRestriction_min.js",
                "~/Scripts/map/map-base.js"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrapValidator.js",
                      "~/Scripts/respond.js"));

            //样式绑定***********！！！
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/components/font-awesome/css/font-awesome.css",
                      "~/Content/components/Ionicons/css/ionicons.min.css",
                      "~/Content/components/bootstrap-daterangepicker/daterangepicker.css",
                      "~/Content/components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css",
                      "~/Content/plugins/iCheck/all.css",
                      "~/Content/plugins/timepicker/bootstrap-timepicker.min.css",
                      "~/Content/components/select2/dist/css/select2.min.css",
                      "~/Content/basecss/ystep.css",                    
                      "~/Content/site.css",
                      "~/Content/skins.css",
                      "~/Content/bootstrapValidator.css",
                      "~/Content/bootstrap-responsive.css",
                      "~/Content/map.css",
                      "~/Content/basecss/module.css"));

        }     
    }
}
