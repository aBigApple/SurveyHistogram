using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    //==============================================================
    //  author：fengxiaojuan
    //  时间：2018/5/5 11:15:04
    //  文件名：editting...
    //==============================================================

    class DrillModel
    {        
        
    }


    //工程
    class Project
    {
        public Project()
        { }
        private string projectName;//工程名称
        private string startTime;//开始时间
        private string endTime;//结束时间

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }

        }
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }

        }
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }

        }

    }

    public class DrillBasicInfo
    {
        public string projectName { get; set; }//工程名称
        public string programName { get; set; }//项目名称
        public string drillCode { get; set; }//钻孔编号
        public double drillHoleHeight { get; set; }//孔口标高
        public string drillLocation { get; set; }//钻孔位置
        public string location1 { get; set; }//钻孔位置
        public string location2 { get; set; }//钻孔位置
        public double coordinateX { get; set; }//钻孔坐标X
        public double coordinateY { get; set; }//钻孔坐标Y
        public string situTest { get; set; }//原位测试
        public string instrumentType { get; set; }//仪器型号
        public string startDate { get; set; }//开始日期
        public string endDate { get; set; }//结束日期
        public double waterDepth { get; set; }//水位深度
        public double infrastructureElevation { get; set; }//基建面高程
        public string recommandBearing { get; set; }//推荐承载力
        public string uniaxialPressure { get; set; }//单轴抗压强
        public string model { get; set; }//模型     

    }

    public class DrillStrata
    {
        public string strataAge { get; set; }//地层年代
        public double startDepth { get; set; }//开始深度
        public double endDepth { get; set; }//结束深度
        public double thinckness { get; set; }//厚度
        public double bottonElevation { get; set; }//层底标高
        public string strataDescribe { get; set; }//地层描述
        public string legendName { get; set; }//图例号
        public string legendExplation { get; set; }//图例说明
        public string contactRelation { get; set; }//接触关系
        public string coreTake { get; set; }//岩芯采取
        public string density { get; set; }//密度
        public string waterInclude { get; set; }//含水量
        public string remarks { get; set; }//备注
    }

    public class StrataDescribe
    {
        public string rockName{ get; set; }
        public string decencyLevel { get; set; }
        public string backCondition { get; set; }
        public string coreCondition { get; set; }
        public string pelletConstituent { get; set; }
        public string interbeddedRockName { get; set; }
        public string adulterant { get; set; }
        public string collor { get; set; }
        public string thicknessConditon { get; set; }
        public int strataID { get; set; }
        public int drillID { get; set; }

    }

    public class Legend
    {
        public int legendID { get; set; }
        public string legendName { get; set; }
        public string legendCode { get; set; }
        public string patternPngPath { get; set; }
        public string patternPatPath { get; set; }
        public int drillID { get; set; }
        public int strataID { get; set; }

    }

    public class DrillHistogram
    {
        //public int drillHistogramID { get; set; }//
        //public int drillID { get; set; }//
        //public int histogramTypeID { get; set; }//
        public double histogramScale { get; set; }//比例尺
        
    }
    public class DillHistogramType
    {
        public string type { get; set; }
    }
}
