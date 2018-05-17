using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Cad.Model.Entities;

namespace BLL.module
{
    //==============================================================
    //  author：fengxiaojuan
    //  时间：2018/5/17 19:35:53  
    //  文件名：mPatternLibrary 
    //  for:根据花纹库编号将相应的花纹插入到图表中
    //==============================================================
    class mPatternLibrary
    {
        int rowIndex;
        string mrockName;//frmDrill frmD,
        public DxfModel getPattern(DxfModel model, string mrockName, double startDeep, double endDeep)
        {
            this.mrockName = mrockName;

            model.Entities.Add(getPatternHatch(44d, 53d, startDeep, endDeep));
            model.Entities.Add(getPatternHatch(55d, 64d, startDeep, endDeep));

            return model;
        }

        /// <summary>
        /// 根据花纹库编号将相应的花纹插入到图表中
        /// </summary>
        public DxfHatch getPatternHatch(double X1, double X2, double startDeep, double endDeep)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + "Drill\\patternLibrary\\";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            FileInfo[] fileInfo = directoryInfo.GetFiles("*.pat");
            //获得pat文档的个数
            int fileLength = fileInfo.Length;
            //遍历所有的已经存在的pat文件
            foreach (FileInfo file in fileInfo)
            {
                //解决中文乱码问题
                StreamReader str = new StreamReader(path + file, Encoding.Default);
                char[] s = { ',' };//定义分隔符为逗号
                StringBuilder rockName = new StringBuilder();//存储岩石名称的数组
                string readLine = str.ReadLine();//读取一行数据
                while (!string.IsNullOrEmpty(readLine))//如果数据不为空)
                {
                    string[] record = readLine.Split(s);
                    rockName.Append(record[1]);
                    string strRockName = rockName.ToString().Trim();
                    //strRockName = strRockName.Replace(" ", "");
                    if (string.Equals(strRockName, mrockName))//找到名字相同的花纹
                    {
                        //读取花纹库
                        DxfModel model = new DxfModel();
                        DxfPatternStore.Add(PatternReader.ReadPatterns(path + file));
                        DxfHatch hatch = new DxfHatch();
                        hatch.Pattern = DxfPatternStore.GetPatternWithName("" + Path.GetFileNameWithoutExtension(file.Name));
                        DxfHatch.BoundaryPath boundaryPath = new DxfHatch.BoundaryPath();
                        boundaryPath.Type = BoundaryPathType.Polyline;
                        hatch.BoundaryPaths.Add(boundaryPath);
                        boundaryPath.PolylineData =
                            new DxfHatch.BoundaryPath.Polyline(
                            new DxfHatch.BoundaryPath.Polyline.Vertex[]{
                                new DxfHatch.BoundaryPath.Polyline.Vertex(X1,-23d-startDeep),
                                new DxfHatch.BoundaryPath.Polyline.Vertex(X2,-23d-startDeep),
                                new DxfHatch.BoundaryPath.Polyline.Vertex(X2,-23d-endDeep),
                                new DxfHatch.BoundaryPath.Polyline.Vertex(X1,-23d-endDeep)}
                            );

                        boundaryPath.PolylineData.Closed = true;
                        return hatch;
                    }
                    break;
                }
            }
            return null;
        }
    }
}
