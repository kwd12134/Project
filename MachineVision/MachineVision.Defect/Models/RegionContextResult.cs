using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Models
{
   public  class RegionContextResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public string Name { get; set; }

        public LightAndDarkRegion Render {  get; set; }

        public RectangleLocation Location { get; set; }
        
    }
}
