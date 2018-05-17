using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.module
{
    //==============================================================
    //  author：fengxiaojuan
    //  时间：2018/5/17 19:35:11  
    //  文件名：ScaleConversion 
    //  for:用来进行比例尺换算的类
    //==============================================================
    class ScaleConversion
    {
        public double getPaintNumber(double originalNumber, double scale)
        {
            double m = originalNumber * 1000 / scale;
            return m;
        }

        //波速长度比例尺转换
        public double getWave(double originalNumber)
        {
            //double w1= getPaintNumber(originalNumber, scale);//按照比例尺转换后的
            double w2;//波速不需要比例尺转换？？？
            w2 = originalNumber;
            return w2;

        }
    }
}
