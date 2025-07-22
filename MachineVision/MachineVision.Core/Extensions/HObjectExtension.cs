using HalconDotNet;

namespace MachineVision.Core.Extensions
{
    public static class HObjectExtension
    {
        public static HObject ReduceROI(this HObject image,double row1,double column1,double row2,double column2)
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

    }
}
