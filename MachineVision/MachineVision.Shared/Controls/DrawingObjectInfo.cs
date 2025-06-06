﻿using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Shared.Controls
{
    public enum ShapeType
    {
        Rectangle,
        Ellipse,
        Circle,
        Region
    }
    public class DrawingObjectInfo
    {
        public ShapeType ShapeType { get; set; }

        public HObject Hobject { get; set; }

        public HTuple[] hTuples {  get; set; }

    }
}
