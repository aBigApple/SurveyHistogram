using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WW.Cad.Base;
using WW.Cad.Drawing;
using WW.Cad.Drawing.GDI;
using WW.Cad.IO;
using WW.Cad.Model;
using WW.Math;


namespace BLL.module
{
    //==============================================================
    //  author：fengxiaojuan
    //  时间：2018/5/17 19:39:20  
    //  文件名：ConvertFigureFormat 
    //  for:转换柱状图成图格式的类
    //==============================================================
    class ConvertFigureFormat
    {
        public ConvertFigureFormat()
        {

        }
        public void getDXFFormat(DxfModel model, string filename, string outfile)
        {
            try
            {
                string extension = System.IO.Path.GetExtension(filename);
                if (string.Compare(extension, ".dwg", true) == 0)
                {
                    model = DwgReader.Read(filename);
                }
                else
                {
                    model = DxfReader.Read(filename);
                }
            }
            catch (Exception e)
            {
                //Console.Error.WriteLine("Error occurred: " + e.Message);
                //Environment.Exit(1);
            }

            GDIGraphics3D graphics = new GDIGraphics3D(GraphicsConfig.BlackBackgroundCorrectForBackColor);
            Size maxSize = new Size(500, 500);
            Bitmap bitmap =
                ImageExporter.CreateAutoSizedBitmap(
                    model,
                    graphics,
                    Matrix4D.Identity,
                    System.Drawing.Color.Black,
                    maxSize
                );
            //string outfile = Path.GetFileNameWithoutExtension(Path.GetFullPath(filename));
            Stream stream = null;
            //string outfile = AppDomain.CurrentDomain.BaseDirectory + "Drill\\rockHistogram\\"+filename;

            BoundsCalculator boundsCalculator = new BoundsCalculator();
            boundsCalculator.GetBounds(model);
            Bounds3D bounds = boundsCalculator.Bounds;
            PaperSize paperSize = PaperSizes.GetPaperSize(PaperKind.A4);//设置为A4纸的大小
            // Lengths in inches.
            float pageWidth = (float)paperSize.Width / 100f;
            float pageHeight = (float)paperSize.Height / 100f;
            float margin = 0.2f; //值越小 model相对于pdf图幅越大
            // Scale and transform such that its fits max width/height
            // and the top left middle of the cad drawing will match the 
            // top middle of the pdf page.
            // The transform transforms to pdf pixels.
            Matrix4D to2DTransform = DxfUtil.GetScaleTransform(
                bounds.Corner1,
                bounds.Corner2,
                new Point3D(bounds.Center.X, bounds.Corner2.Y, 0d),
                new Point3D(new Vector3D(margin, margin, 0d) * PdfExporter.InchToPixel),
                new Point3D(new Vector3D(pageWidth - margin, pageHeight - margin, 0d) * PdfExporter.InchToPixel),
                new Point3D(new Vector3D(pageWidth / 2d, pageHeight - margin, 0d) * PdfExporter.InchToPixel)
            );
            using (stream = File.Create(outfile + ".pdf"))
            {
                PdfExporter pdfGraphics = new PdfExporter(stream);
                pdfGraphics.DrawPage(
                    model,
                    GraphicsConfig.WhiteBackgroundCorrectForBackColor,
                    to2DTransform,
                    paperSize
                );
                pdfGraphics.EndDocument();
            }

            /*
             * 可选的图片格式
            stream = File.Create(outfile + ".png");
            ImageExporter.EncodeImageToPng(bitmap, stream);

            stream = File.Create(outfile + ".tiff");
            ImageExporter.EncodeImageToTiff(bitmap, stream);

            stream = File.Create(outfile + ".jpg");
            ImageExporter.EncodeImageToJpeg(bitmap, stream);

            stream = File.Create(outfile + ".gif");
            ImageExporter.EncodeImageToGif(bitmap, stream);

            stream = File.Create(outfile + ".bmp");
            ImageExporter.EncodeImageToBmp(bitmap, stream);
            */

        }
    }
}
