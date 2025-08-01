using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Extensions
{
    public static class HDrawingObjectExtensions
    {
        public static HTuple[] GetTuples(this HDrawingObject hDrawingObject,string type)
        {
            HTuple[] hTuple = null;
            switch (type)
            {
                case "rectangle1" :
                    {
                        hTuple = new HTuple[4];
                        hTuple[0] = hDrawingObject.GetDrawingObjectParams("row1");
                        hTuple[1] = hDrawingObject.GetDrawingObjectParams("column1");
                        hTuple[2] = hDrawingObject.GetDrawingObjectParams("row2");
                        hTuple[3] = hDrawingObject.GetDrawingObjectParams("column2");
                        break;
                    }
            }
            return hTuple;
        }
    }
}
