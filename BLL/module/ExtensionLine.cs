using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Tables;
using WW.Math;

namespace BLL.module
{
    //==============================================================
    //  author：fengxiaojuan
    //  时间：2018/5/17 19:37:05  
    //  文件名：ExtensionLine 
    //  for:表格的扩展线的类,直接将线加入到成图当中(各表通用)
    //==============================================================
    class ExtensionLine
    {
        double plottingScale;
        double getTheFormerHeight;
        //重写构造函数
        public ExtensionLine(double plottingScale)
        {
            this.plottingScale = plottingScale;
        }

        public ExtensionLine()
        {
            //this.plottingScale = plottingScale;
        }
        /// <summary>
        /// 根据写入字体的总高度，计算延长线位置的方法
        /// 传入的是已经进行过比例尺换算的高度
        /// </summary>
        public double calculateHeight(string graphicTranslation)
        {
            //将扩展线的扩展宽度一致当做2mm来处理
            //得到高度
            graphicTranslation = "    " + graphicTranslation;
            double translationHeight = getExtensionLineHeight(graphicTranslation);

            return translationHeight;
        }
        /// <summary>
        /// 根据解释说明的文字来锁定扩展线的高度
        /// </summary>
        /// <param name="graphicTranslation"></param>
        /// <returns></returns>
        public double getExtensionLineHeight(string graphicTranslation)
        {
            double extensionLineHeight = 0;
            int translationWidth = 28;
            //得到换行后的字符串
            //string tempStr = BreakLongString(graphicTranslation, translationWidth);
            StringBuilder sb = new StringBuilder(graphicTranslation);
            int offset = 0;//换的行数，以此来判断高度
            ArrayList indexList = buildInsertIndexList(graphicTranslation, translationWidth);
            for (int i = 0; i < indexList.Count; i++)
            {
                sb.Insert((int)indexList[i] + offset, '\n');
                offset++;
            }
            //设置字体高度为1.5d，但是汉字达到了2d，每行之间的距离为1d
            extensionLineHeight = offset * 2d + offset * 1d;
            return extensionLineHeight;
        }

        public static string BreakLongString(string SubjectString, int lineLength)
        {
            StringBuilder sb = new StringBuilder(SubjectString);
            int offset = 0;
            ArrayList indexList = buildInsertIndexList(SubjectString, lineLength);
            for (int i = 0; i < indexList.Count; i++)
            {
                sb.Insert((int)indexList[i] + offset, '\n');
                offset++;
            }
            string str;
            return str = sb.ToString();
        }

        //返回字符串扩展后的行数
        public static int getTextNumber(string SubjectString)
        {
            int lineLength = 28;//长度设置为28
            StringBuilder sb = new StringBuilder(SubjectString);
            int offset = 0;
            ArrayList indexList = buildInsertIndexList(SubjectString, lineLength);
            for (int i = 0; i < indexList.Count; i++)
            {
                sb.Insert((int)indexList[i] + offset, '\n');
                offset++;
            }
            //string str;
            return offset;
        }


        public static bool IsChinese(char c)
        {
            //判断字符串是否是汉字，汉字长度为2
            return (int)c >= 0x4E00 && (int)c <= 0x9FA5;
        }

        private static ArrayList buildInsertIndexList(string str, int maxLen)
        {
            double nowLen = 0;
            ArrayList List = new ArrayList();
            try
            {
                for (int i = 1; i < str.Length; i++)
                {
                    if (IsChinese(str[i]))
                    {
                        nowLen += 2;
                    }
                    else { nowLen += 1.2; }
                    if (nowLen > maxLen)
                    {
                        nowLen = 0;
                        List.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw ex;
            }

            return List;
        }
        //右边扩展线
        public static DxfModel getRightExtensionLeader(double textHeight, double startDeep, double endHeight, DxfModel model,
            string graphicTranslation, string graphicCoreExtration, double extensionLineHeight, double thick,
            double TtextHeight, double formerExtensionLineHeight)
        {
            string str = getRadomData(6);
            //DxfModel model = new DxfModel(DxfVersion.Dxf14);
            //先在两条扩展线之间加一条链接的直线
            DxfLineType line11Type = new DxfLineType("line1" + endHeight + str);
            model.LineTypes.Add(line11Type);
            DxfLine drillHoleStadHeightLine = new DxfLine();
            drillHoleStadHeightLine.Start = new Point3D(55, -endHeight - 23, 0d);
            drillHoleStadHeightLine.End = new Point3D(64, -endHeight - 23, 0d);
            drillHoleStadHeightLine.LineType = line11Type;
            model.Entities.Add(drillHoleStadHeightLine);

            DxfLineType line12Type = new DxfLineType("line2" + endHeight + str);
            model.LineTypes.Add(line12Type);
            DxfLine drillHoleStadHeightLine2 = new DxfLine();
            drillHoleStadHeightLine2.Start = new Point3D(44, -endHeight - 23, 0d);
            drillHoleStadHeightLine2.End = new Point3D(53, -endHeight - 23, 0d);
            drillHoleStadHeightLine2.LineType = line12Type;
            model.Entities.Add(drillHoleStadHeightLine2);

            //竖直分线
            DxfLineType line13Type = new DxfLineType("verticalLine1" + endHeight + str);
            model.LineTypes.Add(line13Type);
            DxfLine drillHoleStadHeightLine3 = new DxfLine();
            drillHoleStadHeightLine3.Start = new Point3D(53, -startDeep - 23, 0d);
            drillHoleStadHeightLine3.End = new Point3D(53, -endHeight - 23, 0d);
            drillHoleStadHeightLine3.LineType = line13Type;
            model.Entities.Add(drillHoleStadHeightLine3);

            DxfLineType line14Type = new DxfLineType("verticalLine2" + endHeight + str);
            model.LineTypes.Add(line14Type);
            DxfLine drillHoleStadHeightLine4 = new DxfLine();
            drillHoleStadHeightLine4.Start = new Point3D(55, -startDeep - 23, 0d);
            drillHoleStadHeightLine4.End = new Point3D(55, -endHeight - 23, 0d);
            drillHoleStadHeightLine4.LineType = line14Type;
            model.Entities.Add(drillHoleStadHeightLine4);

            DxfLeader leader = new DxfLeader(model);
            leader.ArrowHeadEnabled = false;
            leader.Vertices.AddRange(
                 new Point3D[] {
                     new Point3D(64, -endHeight-23, 0),
                     new Point3D(66, extensionLineHeight, 0),
                     new Point3D(119,extensionLineHeight, 0)
                 }
            );
            model.Entities.Add(leader);

            //为直线时候,远大于的时候，可以将描述文字放在花纹的中间
            double middleHeight = formerExtensionLineHeight - extensionLineHeight;//上下上下两条扩展线之间的距离

            if (((textHeight * 2 + 3) <= middleHeight))
            {
                double lastLine = extensionLineHeight + 1 + middleHeight / 2;
                // double lastLine = -endHeight - 23 + middleHeight / 2 + textHeight / 2;
                //地层描述
                graphicTranslation = "    " + graphicTranslation;
                graphicTranslation = BreakLongString(graphicTranslation, 28);
                DxfMText graphicTranslationText = new DxfMText(
                        @"" + graphicTranslation,     // - textHeight + textHeight 
                        new Point3D(67d, lastLine, 0d),
                        1.5d
                        );
                model.Entities.Add(graphicTranslationText);
            }
            else  //有多行描述,折线
            {
                //地层描述
                graphicTranslation = "    " + graphicTranslation;
                graphicTranslation = BreakLongString(graphicTranslation, 28);
                DxfMText graphicTranslationText = new DxfMText(
                        @"" + graphicTranslation,     // - textHeight + textHeight 
                        new Point3D(67d, extensionLineHeight + textHeight + 1, 0d),
                        1.5d
                        );
                model.Entities.Add(graphicTranslationText);
            }

            //岩芯采取率
            DxfMText graphicCoreExtrationText = new DxfMText(
                    @"" + graphicCoreExtration,
                    new Point3D(106d, extensionLineHeight + 2, 0d),
                    1.5d
                    );
            model.Entities.Add(graphicCoreExtrationText);
            return model;
            //DxfWriter.Write("Leader Example.dxf", model, false);
        }
        //左边扩展线,需要判断地质时代这一行
        /*string graphicCode;//地层编号 0
        string graphicMark;//地层代号 1,,为表格中的地层时代
        double graphicStartDeep;//开始深度 2
        double graphicEndDeep;//结束深度 3
        double graphicThick;//层厚 4
        double graphicButtomHeight;//层底标高 5
        string graphicTranslation;//地层描述 6
        string graphicCoreExtration;//岩芯采取率 12
        string graphicRemark;//备注 15*/
        public double getLeftExtensionLeader(DxfModel model, string graphicMark,
            double graphicStartDeep, double graphicEndDeep, double graphicThick, double graphicButtomHeight, string graphicTranslation,
            string graphicCoreExtration, double formerExtensionLineHeight)
        {
            //theFormer是前一个花纹的描述高度，用来确定下一个花纹地层描述扩展线的位置
            //DxfModel model = new DxfModel(DxfVersion.Dxf14);
            DxfLeader leader = new DxfLeader(model);
            leader.ArrowHeadEnabled = false;

            //计算地层表述字体的高度
            double textHeight = calculateHeight(graphicTranslation);

            //用来确定扩展线的开始深度和结束深度比例换算后的值
            double startDeep = calculateDataValue(graphicStartDeep);
            double endDeep = calculateDataValue(graphicEndDeep);
            double thick = calculateDataValue(graphicThick);//深度与字体高度的比较值，用来确定延长线的高度

            int jugleData;
            double extensionLineHeight = 0;//扩展线高
            double TtextHeight = formerExtensionLineHeight - 1.5;//填入表格文字高度的位置

            switch (jugleData = jugleExtesionLineLocation(textHeight, thick, formerExtensionLineHeight, endDeep, startDeep, graphicTranslation))
            {
                case 1: //折线

                    extensionLineHeight = formerExtensionLineHeight - textHeight - 3;//-1是字体与线之间的距离
                    break;
                case 2:  //直线
                    extensionLineHeight = -endDeep - 23;
                    break;
                case 3:
                    extensionLineHeight = 2 + textHeight;//花纹高度高于字体高度
                    break;
            }

            if (graphicMark == "")
            {
                leader.Vertices.AddRange(
                    new Point3D[] {
                        new Point3D(9, extensionLineHeight, 0),
                        new Point3D(42,extensionLineHeight, 0),
                        new Point3D(44, -endDeep-23, 0)
                    }
                 );
                //层底深度
                DxfMText graphicEndDeepText = new DxfMText(
                    @"" + graphicEndDeep,
                    new Point3D(11d, extensionLineHeight + 2, 0d),
                    1.5d
                    );
                model.Entities.Add(graphicEndDeepText);

                //层厚
                DxfMText graphicThickText = new DxfMText(
                    @"" + graphicThick,
                    new Point3D(24d, extensionLineHeight + 2, 0d),
                    1.5d
                    );
                model.Entities.Add(graphicThickText);

                //层底标高
                DxfMText graphicButtomHeightText = new DxfMText(
                    @"" + graphicButtomHeight,
                    new Point3D(33d, extensionLineHeight + 2, 0d),
                    1.5d
                    );
                model.Entities.Add(graphicButtomHeightText);

            }
            else
            {
                leader.Vertices.AddRange(
                    new Point3D[] {
                        new Point3D(0, extensionLineHeight, 0),
                        new Point3D(42,extensionLineHeight, 0),
                        new Point3D(44, -endDeep-23, 0)
                    }
                 );
                //地层代号
                DxfMText graphicMarkText = new DxfMText(
                    @"" + graphicMark,
                    new Point3D(1d, extensionLineHeight + 2, 0d),
                    1.5d
                    );
                model.Entities.Add(graphicMarkText);

                //层底深度
                DxfMText graphicEndDeepText = new DxfMText(
                    @"" + graphicEndDeep,
                    new Point3D(11d, extensionLineHeight + 2, 0d),
                    1.5d
                    );
                model.Entities.Add(graphicEndDeepText);

                //层厚
                DxfMText graphicThickText = new DxfMText(
                    @"" + graphicThick,
                    new Point3D(24d, extensionLineHeight + 2, 0d),
                    1.5d
                    );
                model.Entities.Add(graphicThickText);

                //层底标高
                DxfMText graphicButtomHeightText = new DxfMText(
                    @"" + graphicButtomHeight,
                    new Point3D(33d, extensionLineHeight + 2, 0d),
                    1.5d
                    );
                model.Entities.Add(graphicButtomHeightText);

            }
            getRightExtensionLeader(textHeight, startDeep, endDeep, model, graphicTranslation, graphicCoreExtration, extensionLineHeight, thick, TtextHeight, formerExtensionLineHeight);
            model.Entities.Add(leader);
            double forNext = extensionLineHeight;
            return forNext;//返回上一条扩展线的最低位置

        }

        /// <summary>
        /// 用来计算比例尺换算后的数值
        /// </summary>
        /// <param name="orignalData"></param>
        /// <returns></returns>
        public double calculateDataValue(double orignalData)
        {
            double data;
            ScaleConversion scale = new ScaleConversion();
            return data = scale.getPaintNumber(orignalData, plottingScale);
        }

        /// <summary>
        /// 根据花纹的高度和岩层描述字体的高度，判断扩展线与填充花纹的关系
        /// </summary>  判断花纹的扩展线是折线还是直线的方法
        /// <param name="textHeight"></param>
        /// <param name="patternThick"></param>
        /// <returns></returns>
        public int jugleExtesionLineLocation(double textHeight, double patternThick, double formerExtensionLineHeight, double endDeep,
            double startDeep, string graphicTranslation)
        {
            //第一个花纹  formerExtensionLineHeight为负值  多加 2 mm 用来做为线与字体之间的距离
            if (formerExtensionLineHeight >= -23)
            {
                int num = getTextNumber(graphicTranslation);
                //if (num = 1) { }
                if (textHeight + 2 < patternThick)
                {
                    return 2;//直线
                }
                else
                {
                    return 1;//折线
                }
            }
            else
            {
                int num = getTextNumber(graphicTranslation) - 1;
                startDeep = -startDeep - 23;//转换过的高度
                if (formerExtensionLineHeight >= startDeep)//注意负值,扩展线没有占用到下一个花纹位置的情况
                {//上一个扩展线没有占用下一个花纹的高度

                    if ((textHeight + 3) <= patternThick)//上一个线的高度距离该花纹库底的距离>=字体的高度
                    {
                        return 2;//直线
                    }
                    else
                    {
                        return 1;//折线
                    }
                }
                else //占用到下一个花纹的情况
                {
                    endDeep = -endDeep - 23;//(formerExtensionLineHeight-endDeep)>(textHeight+2-num*2)
                    if (formerExtensionLineHeight > endDeep)
                    {
                        if ((formerExtensionLineHeight - endDeep) >= textHeight + 4)//按照平行时候的计算字体高度高于高于上一个花纹库的线，则折线
                        {//(endDeep + 2 + textHeight) >= formerExtensionLineHeight
                            return 2;//直线
                        }
                        else
                        {
                            return 1;//折线
                        }
                    }
                    else
                    {
                        return 1;//折线 ，该种情况已经占用到下个花纹了，所以直接折线                    
                    }
                }
            }

        }

        public double setFormerHeight(double getTheFormerHeight)
        {
            this.getTheFormerHeight = getTheFormerHeight;
            return getTheFormerHeight;
        }

        //获取随机数
        public static string getRadomData(int length)
        {
            RadomData ra = new RadomData();
            string str = ra.GenerateRandomNumber(length);
            return str;
        }
    }
}
