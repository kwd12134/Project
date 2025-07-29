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

    }
}
