using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;

namespace BLL.module
{
    //==============================================================
    //  author：fengxiaojuan
    //  时间：2018/5/17 19:38:00  
    //  文件名：AcosticWave 
    //  for:只需要知道声波数据的路径
    //==============================================================
    class AcosticWave
    {
        public DxfModel getAusticWave(DxfModel model, DxfBlock block)
        {
            string wavePath = "F://模拟声波数据.xls";
            DataTable dt = new DataTable();
            dt = getDt(wavePath);

            DrawWave(dt, model, block);
            return model;
        }
        protected void DrawWave(DataTable dt, DxfModel model, DxfBlock block)
        {
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                //高度换算比例尺
                ScaleConversion dac = new ScaleConversion();

                double spY = dac.getPaintNumber(double.Parse(dt.Rows[i - 1][0].ToString()), 500);//起始点x 深度
                double spX = double.Parse(dt.Rows[i - 1][1].ToString()) / 1000;//起始点y 波速

                double epY = dac.getPaintNumber(double.Parse(dt.Rows[i][0].ToString()), 500);//结束点x
                double epX = double.Parse(dt.Rows[i][1].ToString()) / 1000;//结束点y

                DxfLineType drillCodeLineType = new DxfLineType("TestLine1" + i);
                model.LineTypes.Add(drillCodeLineType);
                DxfLine drillCodeine = new DxfLine();
                drillCodeine.Start = new Point3D(134 + spX * 5, -23 - spY, 0d);
                drillCodeine.End = new Point3D(134 + epX * 5, -23 - epY, 0d);
                //drillCodeine.Color = EntityColors.Gray;
                drillCodeine.LineType = drillCodeLineType;
                block.Entities.Add(drillCodeine);
            }

        }

        protected DataTable getDt(string wavePath)
        {

            //读取的方法
            string mystring = "Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = '" + wavePath + "';Extended Properties=Excel 8.0";

            OleDbConnection cnnxls = new OleDbConnection(mystring);
            //cnnxls.Open();//外部表不是预期的格式

            OleDbDataAdapter myDa = new OleDbDataAdapter("select * from [Sheet1$]", cnnxls);

            DataSet myDs = new DataSet();

            myDa.Fill(myDs);
            DataTable dt = new DataTable();
            dt = myDs.Tables[0];




            return dt;
        }
    }
}
