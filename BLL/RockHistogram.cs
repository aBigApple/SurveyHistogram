using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;
using WW.Cad.Model.Objects;
using WW.Cad.Model.Tables;
using WW.Math;

namespace BLL.module
{
    //==============================================================
    //  author：fengxiaojuan
    //  时间：2018/5/17 19:40:57  
    //  文件名：RockHistogram 
    //  for:岩石钻孔柱状图模型
    //==============================================================
    class RockHistogram
    {
        DxfModel model;
        DxfBlock block;
        double plottingScale;
        DataTable dt;

        /*public AcosticBoreholeTable()
        {
            
        }*/

        //获取随机数
        public string getRadomData(int length)
        {
            RadomData ra = new RadomData();
            string str = ra.GenerateRandomNumber(length);
            return str;
        }
        //表格中要显示的数据
        private string projectName;
        private string programName;
        private string drillCode;
        private string drillHoleStadardHeight;//孔口标高
        private string drillLocation;
        private string drillLocation1;
        private string drillLocation2;
        private string applicationCoordinateX;
        private string applicationCoordinateY;
        private string combSituTest;
        private string applicationVersion;
        private string drillStartTime;
        private string drillEndTime;
        private string waterDeep;
        private string capitalHeight;
        private string recommandBearing;
        private string uniaxialCompressiveStreth;
        private string mmodel;

        /// <summary>
        /// 为表格获取基本表数据的方法
        /// </summary>
        public void setBasicTableData(DataTable dt, double plottingScale, string projectName, string programName, string drillCode, string drillHoleStadardHeight,
             string drillLocation, string drillLocation1, string drillLocation2, string applicationCoordinateX,
               string applicationCoordinateY, string drillStartTime,
                 string drillEndTime, string waterDeep, string capitalHeight, string recommandBearing, string uniaxialCompressiveStreth)

        {
            this.dt = dt;
            this.plottingScale = plottingScale;
            this.projectName = projectName;
            this.programName = programName;
            this.drillCode = drillCode;
            this.drillHoleStadardHeight = drillHoleStadardHeight;
            this.drillLocation = drillLocation;
            this.drillLocation1 = drillLocation1;
            this.drillLocation2 = drillLocation2;
            this.applicationCoordinateX = applicationCoordinateX;
            this.applicationCoordinateY = applicationCoordinateY;
            this.drillStartTime = drillStartTime;
            this.drillEndTime = drillEndTime;
            this.waterDeep = waterDeep;
            this.capitalHeight = capitalHeight;
            this.recommandBearing = recommandBearing;
            this.uniaxialCompressiveStreth = uniaxialCompressiveStreth;

            //createOneTable();
        }

        string strataCode;//地层编号
        string strataID;//地层代号
        double startDeep;//开始深度
        double endDeep;//结束深度
        double thickness;//厚度
        double bottomElevation;//层底标高
        string strataDescription;//地层描述
        string legendNO;//图例号
        double legendHeight;//图例高度
        double legendWidth;//图例宽度
        string legendExplation;//图例说明
        string contactRelation;//接触关系
        string coreTake;//岩芯采取
        string density;//密度
        string waterInclude;//含水量
        string remarks;//备注

        /// <summary>
        /// 获得地质表数据的方法
        /// </summary>
        public void setGeologyData(string strataCode, string strataID, double startDeep, double endDeep,
            double thickness, double bottomElevation, string strataDescription, string legendNO, double legendHeight,
             double legendWidth, string legendExplation, string contactRelation, string coreTake,
               string density, string waterInclude, string remarks)
        {
            this.strataCode = strataCode;//地层编号
            this.strataID = strataID;//地层代号
            this.startDeep = startDeep;//开始深度
            this.endDeep = endDeep;//结束深度
            this.thickness = thickness;//厚度
            this.bottomElevation = bottomElevation;//层底标高
            this.strataDescription = strataDescription;//地层描述
            this.legendNO = legendNO;//图例号
            this.legendHeight = legendHeight;//图例高度
            this.legendWidth = legendWidth;//图例宽度
            this.legendExplation = legendExplation;//图例说明
            this.contactRelation = contactRelation;//接触关系
            this.coreTake = coreTake;//岩芯采取
            this.density = density;//密度
            this.waterInclude = waterInclude;//含水量
            this.remarks = remarks;//备注

            createOneTable();//直接调用建表

        }

        /// <summary>
        /// 创建一张表格的方法
        /// </summary>
        public void createOneTable()
        {
            string str = getRadomData(6);
            model = new DxfModel();
            //创建一个图层
            DxfLayer layerTable = new DxfLayer("" + str + programName);
            model.Layers.Add(layerTable);
            //创建一个块
            block = new DxfBlock("AcosticBoreHoleTable_Block" + str);
            model.Blocks.Add(block);

            DxfInsert insert = new DxfInsert(block, new Point3D(0, 0, 0));
            insert.Layer = layerTable;
            model.Entities.Add(insert);
            {
                DxfTableStyle tableStyle1 = new DxfTableStyle("Single1 bordered" + str);
                tableStyle1.DataCellStyle.SetAllBordersBorderType(BorderType.Single);
                //tableStyle1.DataCellStyle.SetAllBordersColor(Colors.DarkGray);
                tableStyle1.TitleCellStyle.SetAllBordersBorderType(BorderType.Single);
                tableStyle1.HeaderCellStyle.SetAllBordersBorderType(BorderType.Single);
                //tableStyle1.HeaderCellStyle.ContentColor = Colors.DarkGray;
                model.TableStyles.Add(tableStyle1);


                DxfTable table1 = new DxfTable(tableStyle1);
                //表格插入点的位置
                table1.InsertionPoint = new Point3D(0d, 0d, 0d);

                //设置表格的行数和列数
                table1.RowCount = 3;
                table1.ColumnCount = 9;
                table1.Rows.ElementAt<DxfTableRow>(0).Height = 18d;
                table1.Rows.ElementAt<DxfTableRow>(1).Height = 5d;
                table1.Rows.ElementAt<DxfTableRow>(2).Height = 255;

                /*foreach (DxfTableColumn column in table1.Columns)
                {
                    column.Width = 25d;
                }*/
                table1.Columns.ElementAt<DxfTableColumn>(0).Width = 9;
                table1.Columns.ElementAt<DxfTableColumn>(1).Width = 13;
                table1.Columns.ElementAt<DxfTableColumn>(2).Width = 9;
                table1.Columns.ElementAt<DxfTableColumn>(3).Width = 13;
                table1.Columns.ElementAt<DxfTableColumn>(4).Width = 20;
                table1.Columns.ElementAt<DxfTableColumn>(5).Width = 40;
                table1.Columns.ElementAt<DxfTableColumn>(6).Width = 15;
                table1.Columns.ElementAt<DxfTableColumn>(7).Width = 20;
                table1.Columns.ElementAt<DxfTableColumn>(8).Width = 33;

                //table1.Rows[0].Cells[0].Contents.Add(new DxfValueFormat.String(), "地层时代");
                DxfMText drillHoleStadHeight = new DxfMText(
                    @"地" + '\n' + "层" + '\n' + "时" + '\n' + "代",
                    new Point3D(2.5d, -2d, 0d),
                    2d
                    ); block.Entities.Add(drillHoleStadHeight);
                //table1.Rows[0].Cells[1].Contents.Add(new DxfValueFormat.String(), "层底厚度"+'\n'+"（米）");
                drillHoleStadHeight = new DxfMText(
                    @"层 底" + '\n' + "厚 度" + '\n' + "(米)",
                    new Point3D(12.5d, -2d, 0d),
                    2d
                    ); block.Entities.Add(drillHoleStadHeight);
                //table1.Rows[0].Cells[2].Contents.Add(new DxfValueFormat.String(), "层厚（米）");
                drillHoleStadHeight = new DxfMText(
                    @" 层 " + '\n' + " 厚 " + '\n' + "(米)",
                    new Point3D(24d, -2d, 0d),
                    2d
                    ); block.Entities.Add(drillHoleStadHeight);
                //table1.Rows[0].Cells[3].Contents.Add(new DxfValueFormat.String(), "层底标高");
                drillHoleStadHeight = new DxfMText(
                    @"层 底" + '\n' + "标 高" + '\n' + "(米)",
                    new Point3D(33d, -2d, 0d),
                    2d
                    ); block.Entities.Add(drillHoleStadHeight);
                //table1.Rows[0].Cells[4].Contents.Add(new DxfValueFormat.String(), "柱状剖面"+'\n'+"（比例尺）1:500");
                drillHoleStadHeight = new DxfMText(
                    @" 柱 状 剖 面" + '\n' + "  (比例尺)" + '\n' + "   1:" + plottingScale,
                    new Point3D(46d, -2d, 0d),
                    2d
                    ); block.Entities.Add(drillHoleStadHeight);
                //table1.Rows[0].Cells[5].Contents.Add(new DxfValueFormat.String(), "所通过岩层的描述"+'\n'+"（颗粒成分、状态、"+'\n'+"颜色、掺杂物等）");
                drillHoleStadHeight = new DxfMText(
                    @" 所  通  过  岩  层  的  描  述" + '\n',
                    new Point3D(66d, -3.5d, 0d),
                    2d
                    ); block.Entities.Add(drillHoleStadHeight);
                drillHoleStadHeight = new DxfMText(
                    @"(颗粒成分、状态、 颜色、掺杂物等)",
                    new Point3D(66d, -9d, 0d),
                    1.5d
                    ); block.Entities.Add(drillHoleStadHeight);
                //table1.Rows[0].Cells[6].Contents.Add(new DxfValueFormat.String(), "岩芯采取率"+"（%）");
                drillHoleStadHeight = new DxfMText(
                   @"岩芯" + '\n' + "采取率" + '\n' + "（%）",
                   new Point3D(106d, -2d, 0d),
                   2d
                   ); block.Entities.Add(drillHoleStadHeight);
                //table1.Rows[0].Cells[7].Contents.Add(new DxfValueFormat.String(), "原位测试");
                drillHoleStadHeight = new DxfMText(
                  @"原 位 测 试",
                  new Point3D(121d, -2d, 0d),
                  2d
                  ); block.Entities.Add(drillHoleStadHeight);
                //table1.Rows[0].Cells[8].Contents.Add(new DxfValueFormat.String(), "声波曲线");
                drillHoleStadHeight = new DxfMText(
                 @"       声  波  曲  线" + '\n' + "            (km/s)",
                 new Point3D(141d, -3.5d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);

                //table1.Rows[1].Cells[0].Contents.Add(new DxfValueFormat.String(), "1");
                drillHoleStadHeight = new DxfMText(
                 @"1",
                 new Point3D(3d, -19d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);

                //table1.Rows[1].Cells[1].Contents.Add(new DxfValueFormat.String(), "2");
                drillHoleStadHeight = new DxfMText(
                 @"2",
                 new Point3D(14.5d, -19d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);

                //table1.Rows[1].Cells[2].Contents.Add(new DxfValueFormat.String(), "3");
                drillHoleStadHeight = new DxfMText(
                 @"3",
                 new Point3D(25d, -19d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);

                //table1.Rows[1].Cells[3].Contents.Add(new DxfValueFormat.String(), "4");
                drillHoleStadHeight = new DxfMText(
                 @"4",
                 new Point3D(37.5d, -19d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);

                //table1.Rows[1].Cells[4].Contents.Add(new DxfValueFormat.String(), "5");
                drillHoleStadHeight = new DxfMText(
                 @"5",
                 new Point3D(52.5d, -19d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);

                //table1.Rows[1].Cells[5].Contents.Add(new DxfValueFormat.String(), "6");
                drillHoleStadHeight = new DxfMText(
                 @"6",
                 new Point3D(85d, -19d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);

                //table1.Rows[1].Cells[6].Contents.Add(new DxfValueFormat.String(), "7");
                drillHoleStadHeight = new DxfMText(
                 @"7",
                 new Point3D(109.5d, -19d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);

                //table1.Rows[1].Cells[7].Contents.Add(new DxfValueFormat.String(), "8");
                drillHoleStadHeight = new DxfMText(
                 @"8",
                 new Point3D(127d, -19d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);

                //table1.Rows[1].Cells[8].Contents.Add(new DxfValueFormat.String(), "9");
                drillHoleStadHeight = new DxfMText(
                 @"9",
                 new Point3D(153.5d, -19d, 0d),
                 2d
                 ); block.Entities.Add(drillHoleStadHeight);


                //table1.Rows[0].Cells[0].CellStyleOverrides.ContentColor = Colors.DarkGray;
                //在某一行获取当前时间的方法
                //table1.Rows[2].Cells[8].Contents.Add(DxfValueFormat.Date.CreateRegionalLongDateTime(), DateTime.Now);
                //*********下面这一句是用来干嘛的？？？？？？？？？？？
                //用来给单元格赋值为数字类型
                //table1.Rows[2].Cells[7].Contents.Add(new DxfValueFormat.DecimalNumber(LinearUnitFormat.Decimal), 123.45d);

                // Merge the title row cells.  融合标题行
                //table.MergedCellRanges.Add(new DxfTableCellRange(0, 0, 0, 2));
                // This demonstrates a merged cell block of 3 by 2 cells.
                //table.MergedCellRanges.Add(new DxfTableCellRange(2, 0, 3, 2));
                //model.Entities.Add(table1);
                block.Entities.Add(table1);
            }

            {
                //************table2*************tableStyle2**************
                //set table borderStyle 此处DxfTableStyle括号中的名字，每个table的都不能相同
                DxfTableStyle dxfTableStyle2 = new DxfTableStyle("Single2 bordered" + str);

                dxfTableStyle2.DataCellStyle.SetAllBordersBorderType(BorderType.Single);
                dxfTableStyle2.DataCellStyle.SetAllBordersColor(Colors.DarkGray);
                dxfTableStyle2.TitleCellStyle.SetAllBordersBorderType(BorderType.Single);
                dxfTableStyle2.HeaderCellStyle.SetAllBordersBorderType(BorderType.Single);
                dxfTableStyle2.HeaderCellStyle.SetAllBordersColor(Colors.DarkGray);
                //有该行的时候两个表格不能同时生成???***但是没有该行生成的图形文件又不完整
                model.TableStyles.Add(dxfTableStyle2);
                //model.TableStyles.Insert(1,dxfTableStyle2);


                //定义一个拥有给定格式的表格
                DxfTable table2 = new DxfTable(dxfTableStyle2);
                //表格插入点的位置
                table2.InsertionPoint = new Point3D(-2d, 25d, 0d);

                table2.RowCount = 1;
                table2.ColumnCount = 1;
                table2.Rows.ElementAt<DxfTableRow>(0).Height = 305;
                foreach (DxfTableColumn column in table2.Columns)
                {
                    column.Width = 176d;
                }

                //table2.Rows[0].Cells[0].Contents.Add(new DxfValueFormat.String(), "钻孔柱状剖面图");
                //table2.Rows[0].Cells[0].CellStyleOverrides.ContentColor = Colors.Red;       
                //model.Entities.Add(table2);
                block.Entities.Add(table2);
            }

            {
                //标题下划线
                //定义线的长度
                // A complex line type.
                DxfLineType lineType = new DxfLineType("titleLine" + str);
                model.LineTypes.Add(lineType);
                DxfLine line = new DxfLine();
                line.Start = new Point3D(44d, 10d, 0d);
                line.End = new Point3D(113d, 10d, 0d);
                line.LineType = lineType;
                block.Entities.Add(line);
                //标题名
                DxfMText mText = new DxfMText(
                    @"钻孔柱状剖面图",
                    new Point3D(46d, 18d, 0d),
                    6d
                );
                block.Entities.Add(mText);

            }
            //定义标题栏中的其他部分
            {
                //定义输入钻孔***X***坐标位置
                DxfMText mText1 = new DxfMText(
                    @"坐标   X=",
                    new Point3D(135d, 20d, 0d),
                    2.5d
                    );
                block.Entities.Add(mText1);
                DxfLineType lineType1 = new DxfLineType("applicanceX" + str);
                model.LineTypes.Add(lineType1);
                DxfLine lineX = new DxfLine();
                lineX.Start = new Point3D(149d, 17.5d, 0d);
                lineX.End = new Point3D(172d, 17.5d, 0d);
                lineX.LineType = lineType1;
                block.Entities.Add(lineX);
                DxfMText mText11 = new DxfMText(
                    @"" + applicationCoordinateX,
                    new Point3D(151d, 20d, 0d),
                    2d
                    );

                block.Entities.Add(mText11);

                //定义输入钻孔***Y***坐标位置********一块填写部分开始
                DxfMText mText2 = new DxfMText(
                    @"Y=",
                    new Point3D(145d, 10d, 0d),
                    2.5d
                    );
                block.Entities.Add(mText2);
                DxfLineType lineType2 = new DxfLineType("applicanceY" + str);
                model.LineTypes.Add(lineType2);
                DxfLine lineY = new DxfLine();
                lineY.Start = new Point3D(149d, 7.5d, 0d);
                lineY.End = new Point3D(172d, 7.5d, 0d);
                lineY.LineType = lineType2;
                block.Entities.Add(lineY);
                DxfMText mText21 = new DxfMText(
                    @"" + applicationCoordinateY,
                    new Point3D(151d, 10d, 0d),
                    2d
                    );
                block.Entities.Add(mText21);
                //********************************** 一块填写部分结束**********************
            }
            {
                //原位测试的长线条
                DxfLineType drillCodeLineType = new DxfLineType("TestLine1" + str);
                model.LineTypes.Add(drillCodeLineType);
                DxfLine drillCodeine = new DxfLine();
                drillCodeine.Start = new Point3D(124d, -23d, 0d);
                drillCodeine.End = new Point3D(124d, -278d, 0d);
                drillCodeine.Color = EntityColors.Gray;
                drillCodeine.LineType = drillCodeLineType;
                block.Entities.Add(drillCodeine);

                DxfLineType drillCodeLineType1 = new DxfLineType("TestLine2" + str);
                model.LineTypes.Add(drillCodeLineType1);
                DxfLine drillCodeine1 = new DxfLine();
                drillCodeine1.Start = new Point3D(129d, -23d, 0d);
                drillCodeine1.End = new Point3D(129d, -278d, 0d);
                drillCodeine1.Color = EntityColors.Gray;
                drillCodeine1.LineType = drillCodeLineType1;
                block.Entities.Add(drillCodeine1);

                DxfLineType drillCodeLineType2 = new DxfLineType("TestLine3" + str);
                model.LineTypes.Add(drillCodeLineType2);
                DxfLine drillCodeine2 = new DxfLine();
                drillCodeine2.Start = new Point3D(134d, -23d, 0d);
                drillCodeine2.End = new Point3D(134d, -278d, 0);
                drillCodeine2.Color = EntityColors.Gray;
                drillCodeine2.LineType = drillCodeLineType2;
                block.Entities.Add(drillCodeine2);
            }

            {
                //声波曲线的长线条
                DxfLineType drillCodeLineType = new DxfLineType("TestLine11" + str);
                model.LineTypes.Add(drillCodeLineType);
                {
                    //长线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(144d, -23d, 0d);
                    drillCodeine.End = new Point3D(144d, -278d, 0d);
                    drillCodeine.Color = EntityColors.Gray;
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }
                {
                    DxfMText mtext = new DxfMText(
                    @"2",
                    new Point3D(143.5d, -13.5d, 0d),
                    2d
                    );
                    model.Entities.Add(mtext);
                    //长短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(144d, -16d, 0d);
                    drillCodeine.End = new Point3D(144d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }
                {
                    //短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(141.5d, -17d, 0d);
                    drillCodeine.End = new Point3D(141.5d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }


                DxfLineType drillCodeLineType1 = new DxfLineType("TestLine12" + str);
                model.LineTypes.Add(drillCodeLineType1);
                {
                    DxfLine drillCodeine1 = new DxfLine();
                    drillCodeine1.Start = new Point3D(149d, -23d, 0d);
                    drillCodeine1.End = new Point3D(149d, -278d, 0d);
                    drillCodeine1.Color = EntityColors.Gray;
                    drillCodeine1.LineType = drillCodeLineType1;
                    block.Entities.Add(drillCodeine1);
                }
                {
                    DxfMText mtext = new DxfMText(
                    @"3",
                    new Point3D(148.5d, -13.5d, 0d),
                    2d
                    );
                    model.Entities.Add(mtext);
                    //长短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(149d, -16d, 0d);
                    drillCodeine.End = new Point3D(149d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }
                {
                    //短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(146.5d, -17d, 0d);
                    drillCodeine.End = new Point3D(146.5d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }

                DxfLineType drillCodeLineType2 = new DxfLineType("TestLine13" + str);
                model.LineTypes.Add(drillCodeLineType2);
                {
                    DxfLine drillCodeine2 = new DxfLine();
                    drillCodeine2.Start = new Point3D(154d, -23d, 0d);
                    drillCodeine2.End = new Point3D(154d, -278d, 0);
                    drillCodeine2.Color = EntityColors.Gray;
                    drillCodeine2.LineType = drillCodeLineType2;
                    block.Entities.Add(drillCodeine2);
                }
                {
                    DxfMText mtext = new DxfMText(
                    @"4",
                    new Point3D(153.5d, -13.5d, 0d),
                    2d
                    );
                    model.Entities.Add(mtext);
                    //长短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(154d, -16d, 0d);
                    drillCodeine.End = new Point3D(154d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }
                {
                    //短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(151.5d, -17d, 0d);
                    drillCodeine.End = new Point3D(151.5d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }

                DxfLineType drillCodeLineType3 = new DxfLineType("TestLine14" + str);
                model.LineTypes.Add(drillCodeLineType3);
                {
                    DxfLine drillCodeine3 = new DxfLine();
                    drillCodeine3.Start = new Point3D(159d, -23d, 0d);
                    drillCodeine3.End = new Point3D(159d, -278d, 0d);
                    drillCodeine3.Color = EntityColors.Gray;
                    drillCodeine3.LineType = drillCodeLineType3;
                    block.Entities.Add(drillCodeine3);
                }
                {
                    DxfMText mtext = new DxfMText(
                    @"5",
                    new Point3D(158.5d, -13.5d, 0d),
                    2d
                    );
                    model.Entities.Add(mtext);
                    //长短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(159d, -16d, 0d);
                    drillCodeine.End = new Point3D(159d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }
                {
                    //短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(156.5d, -17d, 0d);
                    drillCodeine.End = new Point3D(156.5d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }

                DxfLineType drillCodeLineType4 = new DxfLineType("TestLine15" + str);
                model.LineTypes.Add(drillCodeLineType4);
                {
                    DxfLine drillCodeine4 = new DxfLine();
                    drillCodeine4.Start = new Point3D(164d, -23d, 0d);
                    drillCodeine4.End = new Point3D(164d, -278d, 0d);
                    drillCodeine4.Color = EntityColors.Gray;
                    drillCodeine4.LineType = drillCodeLineType4;
                    block.Entities.Add(drillCodeine4);
                }
                {
                    DxfMText mtext = new DxfMText(
                    @"6",
                    new Point3D(163.5d, -13.5d, 0d),
                    2d
                    );
                    model.Entities.Add(mtext);
                    //长短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(164d, -16d, 0d);
                    drillCodeine.End = new Point3D(164d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }
                {
                    //短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(161.5d, -17d, 0d);
                    drillCodeine.End = new Point3D(161.5d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }

                DxfLineType drillCodeLineType5 = new DxfLineType("TestLine16" + str);
                model.LineTypes.Add(drillCodeLineType5);
                {
                    DxfLine drillCodeine5 = new DxfLine();
                    drillCodeine5.Start = new Point3D(169d, -23d, 0d);
                    drillCodeine5.End = new Point3D(169d, -278d, 0);
                    drillCodeine5.Color = EntityColors.Gray;
                    drillCodeine5.LineType = drillCodeLineType5;
                    block.Entities.Add(drillCodeine5);
                }
                {
                    DxfMText mtext = new DxfMText(
                    @"7",
                    new Point3D(168.5d, -13.5d, 0d),
                    2d
                    );
                    model.Entities.Add(mtext);
                    //长短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(169d, -16d, 0d);
                    drillCodeine.End = new Point3D(169d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }
                {
                    //短线
                    DxfLine drillCodeine = new DxfLine();
                    drillCodeine.Start = new Point3D(166.5d, -17d, 0d);
                    drillCodeine.End = new Point3D(166.5d, -18d, 0d);
                    drillCodeine.LineType = drillCodeLineType;
                    block.Entities.Add(drillCodeine);
                }
            }

            //需要填入表中的其他部分的内容
            {
                //钻孔编号*****************************************************************
                DxfMText drillCodeText = new DxfMText(
                    @"钻孔编号",
                    new Point3D(0d, 5d, 0d),
                    2.5d
                    );
                block.Entities.Add(drillCodeText);
                DxfLineType drillCodeLineType = new DxfLineType("zkbhLine" + str);
                model.LineTypes.Add(drillCodeLineType);
                DxfLine drillCodeine = new DxfLine();
                drillCodeine.Start = new Point3D(15d, 1d, 0d);
                drillCodeine.End = new Point3D(33d, 1d, 0d);
                drillCodeine.LineType = drillCodeLineType;
                block.Entities.Add(drillCodeine);
                DxfMText drillCodeWriteIn = new DxfMText(
                    @"" + drillCode,
                    new Point3D(17d, 4d, 0d),
                    2d
                );
                block.Entities.Add(drillCodeWriteIn);
                //***********************************************************************

                //钻孔位置***************************************************************
                DxfMText drillLocation = new DxfMText(
                    @"钻孔位置",
                    new Point3D(35d, 5d, 0d),
                    2.5d
                    );
                block.Entities.Add(drillLocation);
                DxfLineType drillLocationLineType = new DxfLineType("drillLocationLine" + str);
                model.LineTypes.Add(drillLocationLineType);
                DxfLine drillLocationLine = new DxfLine();
                drillLocationLine.Start = new Point3D(52d, 1, 0d);
                drillLocationLine.End = new Point3D(77d, 1d, 0d);
                drillLocationLine.LineType = drillLocationLineType;
                block.Entities.Add(drillLocationLine);
                DxfMText drillLocationWriteIn = new DxfMText(
                    @"" + drillLocation + drillLocation1 + drillLocation2,
                    new Point3D(54d, 4d, 0d),
                    2d
                );
                block.Entities.Add(drillLocationWriteIn);
                //*****************************************************************************

                //********施钻起止日期*********************************************************
                DxfMText drillDate = new DxfMText(
                    @"施钻起止日期",
                    new Point3D(79d, 5d, 0d),
                2.5d
                );
                block.Entities.Add(drillDate);
                DxfLineType drillDateLineType = new DxfLineType("drillDateLine" + str);
                model.LineTypes.Add(drillDateLineType);
                DxfLine drillDateLine = new DxfLine();
                drillDateLine.Start = new Point3D(101, 1d, 0d);
                drillDateLine.End = new Point3D(133, 1d, 0d);
                drillDateLine.LineType = drillDateLineType;
                block.Entities.Add(drillDateLine);
                DxfMText drillDateWriteIn = new DxfMText(
                    @"" + drillStartTime + "--" + drillEndTime,
                    new Point3D(102d, 4d, 0d),
                    2d
                );
                block.Entities.Add(drillDateWriteIn);
                //***********************************************************************

                //**********孔口标高*****************************************************
                DxfMText drillHoleStadHeight = new DxfMText(
                    @"孔口标高",
                    new Point3D(136d, 5d, 0d),
                    2.5d
                    );
                block.Entities.Add(drillHoleStadHeight);
                DxfLineType drillHoleStadHeightLineType = new DxfLineType("drillHoleStaHeight" + str);
                model.LineTypes.Add(drillHoleStadHeightLineType);
                DxfLine drillHoleStadHeightLine = new DxfLine();
                drillHoleStadHeightLine.Start = new Point3D(151d, 1d, 0d);
                drillHoleStadHeightLine.End = new Point3D(172d, 1d, 0d);
                drillHoleStadHeightLine.LineType = drillHoleStadHeightLineType;
                block.Entities.Add(drillHoleStadHeightLine);
                DxfMText drillHoleStadHeightWriteIn = new DxfMText(
                    @"" + drillHoleStadardHeight,
                    new Point3D(152d, 4d, 0d),
                    2d
                    );
                block.Entities.Add(drillHoleStadHeightWriteIn);
                //**********************************************************************************            
            }
            //addPattern();
            addExtension();//设置值的同时画出扩展线           
                           //string path = Server.MapPath(@"~/DrillTable/AcosticBoreholeTable.dxf");
                           //using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                           //{
                           //file.WriteLine(model.UserName.ToString());
                           // DxfWriter.Write("AcosticBoreholeTable.dxf", model,true);
                           //}

            AcosticWave aw = new AcosticWave();
            aw.getAusticWave(model, block);

            DxfWriter.Write(@"/DrillTable/AcosticBoreholeTable.dxf", model, true);
            //DxfWriter.Write("AcosticBoreholeTable.dxf", model);
            //return "AcosticBoreholeTable.dxf";

            ConvertFigureFormat cf = new ConvertFigureFormat();
            string stream = "C://DrillTable/AcosticBoreholeTable.dxf";
            cf.getDXFFormat(model, stream);
        }

        /// <summary> 
        /// 添加花纹库的方法
        /// </summary>
        public void addPattern(string mrockName, double startDeep, double endDeep)
        {
            mPatternLibrary pattern = new mPatternLibrary();

            ScaleConversion scale = new ScaleConversion();
            startDeep = scale.getPaintNumber(startDeep, plottingScale);
            endDeep = scale.getPaintNumber(endDeep, plottingScale);
            //调用添加花纹的方法
            pattern.getPattern(model, mrockName, startDeep, endDeep);
        }

        /// <summary>
        /// 添加扩展线的方法
        /// </summary>
        public void addExtension()
        {
            string mstr;
            double formerExtensionLineHeight = -23;//上一个花纹扩展线的位置
            double end = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[2] == null || dr[2].ToString() == "" ||
                    dr[3] == null || dr[3].ToString() == "")
                {
                    end = -scaleConversionForLastPattern(end) - 23;//比例尺转换
                    //竖直分线  
                    string str = getRadomData(6);
                    DxfLineType line13Type = new DxfLineType("lastLine1" + str);
                    model.LineTypes.Add(line13Type);
                    DxfLine drillHoleStadHeightLine3 = new DxfLine();
                    drillHoleStadHeightLine3.Start = new Point3D(53, end, 0d);
                    drillHoleStadHeightLine3.End = new Point3D(55, end, 0d);
                    drillHoleStadHeightLine3.LineType = line13Type;
                    model.Entities.Add(drillHoleStadHeightLine3);

                    break;
                }
                else
                {
                    string graphicMark;//地层代号 1
                    double graphicStartDeep;//开始深度 2
                    double graphicEndDeep;//结束深度 3
                    double graphicThick;//层厚 4
                    double graphicButtomHeight;//层底标高 5
                    string graphicTranslation;//地层描述 6
                    string coreTake;//岩芯采取率 12
                    //string graphicRemark;//备注 15
                    try
                    {
                        if (dr[1] == null || dr[1].ToString() == "")
                        {
                            graphicMark = "";
                        }
                        else
                        {
                            graphicMark = dr[0].ToString();
                        }
                        if (dr[10] == null || dr[10].ToString() == "")
                        {
                            coreTake = "";
                        }
                        else
                        {
                            coreTake = dr[10].ToString();
                        }
                        graphicStartDeep = double.Parse(dr[2].ToString());
                        graphicEndDeep = double.Parse(dr[3].ToString());
                        graphicThick = double.Parse(dr[4].ToString());
                        graphicButtomHeight = double.Parse(dr[5].ToString());
                        graphicTranslation = dr[6].ToString();
                        coreTake = dr[10].ToString();
                        //graphicRemark = item.Cells[15].Value.ToString();

                        ExtensionLine extLine = new ExtensionLine(plottingScale);

                        formerExtensionLineHeight = extLine.getLeftExtensionLeader(model, graphicMark,
                                graphicStartDeep, graphicEndDeep, graphicThick, graphicButtomHeight, graphicTranslation,
                                coreTake, formerExtensionLineHeight);

                        end = graphicEndDeep;

                        if ((dr[7] != null) && (dr[7].ToString() != ""))
                        {
                            string mrockName = dr[7].ToString();
                            addPattern(mrockName, graphicStartDeep, graphicEndDeep);
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message + '\n' + "您有值未正确填入表格中！" + '\n' + "（请注意漏填，数据格式等问题）", "提示");
                        throw ex;
                    }
                    //ExtensionLine extLine = new ExtensionLine(plottingScale);
                    mstr = '\n' + "您有值未正确填入表格中！" + '\n' + "（请注意漏填，数据格式等问题";

                }
            }
            //return mstr;
        }

        /// <summary>
        /// 给最后一行花纹库进行比例尺转换
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public double scaleConversionForLastPattern(double height)
        {
            ScaleConversion scale = new ScaleConversion();
            height = scale.getPaintNumber(height, plottingScale);
            return height;
        }
    }
}
