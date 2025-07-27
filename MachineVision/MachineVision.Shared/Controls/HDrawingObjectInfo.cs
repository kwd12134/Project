using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Shared.Controls
{
    public class HDrawingObjectInfo
    {
        public HDrawingObject HDrawingObject { get; set; }

        public HTuple[] HTuples { get; set; }

        public string Color { get; set; }
    }
}
