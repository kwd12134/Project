using HalconDotNet;

namespace MachineVision.Core.Extensions
{
    public static class HObjectExtension
    {
        public static HObject ReduceROI(this HObject image, double row1, double column1, double row2, double column2)
        {
            HOperatorSet.GenRectangle1(out HObject rectangle, row1, column1, row2, column2);
            HOperatorSet.ReduceDomain(image, rectangle, out HObject imageReduced);
            return imageReduced;
        }

        public static HObject RgbToGray(this HObject image)
        {
            HOperatorSet.Rgb1ToGray(image, out HObject grayImage);
            return grayImage;
        }
        /// <summary>
        /// 适用于裁剪domain时,修改为裁剪之后的像素大小
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static HObject CropDomain(this HObject image)
        {
            HOperatorSet.CropDomain(image, out HObject template);
            return template;
        }

        public static HObject ReduceDomain(this HObject image, double y1, double x1, double y2, double x2)
        {
            HOperatorSet.GenRectangle1(out HObject rectangle, y1, x1, y2, x2);
            HOperatorSet.ReduceDomain(image, rectangle, out HObject template);
            return template;
        }

        public static HObject ReduceDomain(this HObject image, HObject rectangle)
        {
            HOperatorSet.ReduceDomain(image, rectangle, out HObject template);
            return template;
        }

        /// <summary>
        /// 获取图像尺寸  把hobject类型的image转换成himage类型跟方便拿到他的原始数据
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static int[] GetImageSize(this HObject image)
        {
            int width, height;
            HImage img = new HImage();
            HobjectToHimage(image, ref img);
            img.GetImageSize(out width, out height);
            return new int[] { width, height };

            static void HobjectToHimage(HObject hobject, ref HImage image)
            {
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    HTuple p, t, w, h;
                    HOperatorSet.GetImagePointer1(hobject, out p, out t, out w, out h);
                    image.GenImage1(t, w, h, p);
                }
            }
        }

        /// <summary>
        /// 保存BMP图像
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fileName"></param>
        public static void SaveIamge(this HObject image, string fileName)
        {
            HOperatorSet.WriteImage(image, "bmp", 0, fileName);
        }

        /// <summary>
        /// 移动区域
        /// </summary>
        /// <param name="image"></param>
        /// <param name="y1"></param>
        /// <param name="x1"></param>
        /// <returns></returns>
        public static HObject Move(this HObject region, double y1, double x1)
        {
            HObject ho_moveregion;
            HOperatorSet.GenEmptyObj(out ho_moveregion);
            HOperatorSet.MoveRegion(region, out ho_moveregion, y1, x1);
            return ho_moveregion;
        }

        /// <summary>
        /// 获取区域轮廓
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static HObject GetRegionContour(this HObject region)
        {
            HOperatorSet.GenContourRegionXld(region, out HObject contours, "border");
            return contours;
        }

        /// <summary>
        /// 获取面积总结
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static long GetSumArea(this HObject region)
        {
            HOperatorSet.AreaCenter(region, out HTuple area, out HTuple row, out HTuple column);

            if (area.Length == 0) return 0;

            long sum_area = 0;
            foreach (HTuple h in area.LArr)
                sum_area += h;

            area.Dispose();
            row.Dispose();
            column.Dispose();

            return sum_area;
        }

    }
}
