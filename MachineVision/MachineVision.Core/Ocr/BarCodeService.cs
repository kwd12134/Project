using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Core.TemplateMatch.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Core.Ocr
{
    public class BarCodeService
    {
        public BarCodeService()
        {
            HOperatorSet.CreateBarCodeModel(new HTuple(), new HTuple(), out hv_BarCodeHandle);

            Info = new MethodInfo()
            {
                Name = "find_bar_code",
                Description = "Detect and read bar code symbols in an image.",
                Parameters = new List<MethodParameter>()
                {
                   new MethodParameter(){ Name="Image", Description="Input image. If the image has a reduced domain, the barcode search is reduced to that domain. This usually reduces the runtime of the operator. However, if the barcode is not fully inside the domain, the barcode cannot be decoded correctly." },
                   new MethodParameter(){ Name="SymbolRegions", Description="Regions of the successfully decoded bar code symbols." },
                   new MethodParameter(){ Name="BarCodeHandle", Description="Handle of the bar code model." },
                   new MethodParameter(){ Name="CodeType", Description="Type of the searched bar code." },
                   new MethodParameter(){ Name="DecodedDataStrings ", Description="Data strings of all successfully decoded bar codes." },
                },
                Predecessors = new List<string>()
                {
                     "get_bar_code_result",
                     "get_bar_code_object",
                     "clear_bar_code_model",
                }
            };
        }

        HObject ho_SymbolRegions = null;
        HTuple hv_BarCodeHandle = new HTuple();
        HTuple hv_I = new HTuple(), hv_DecodedDataStrings = new HTuple();
        HTuple hv_Reference = new HTuple(), hv_String = new HTuple();
        HTuple hv_J = new HTuple(), hv_Char = new HTuple();

        public MethodInfo Info { get; set; }
        public RoiParameter Roi { get; set; }
        public MatchResultSetting Setting { get; set; }

        public OcrResult Run(HObject image)
        {
            var timeSpan = SetTimerHelper.SetTimer(() =>
            {
                HOperatorSet.FindBarCode(image, out ho_SymbolRegions, hv_BarCodeHandle, "Code 128", out hv_DecodedDataStrings);
                HOperatorSet.GetBarCodeResult(hv_BarCodeHandle, 0, "decoded_reference", out hv_Reference);
            });
            hv_String.Dispose();
            hv_String = "";
            HTuple end_val15 = (hv_DecodedDataStrings.TupleStrlen()) - 1;
            HTuple step_val15 = 1;
            for (hv_J = 0; hv_J.Continue(end_val15, step_val15); hv_J = hv_J.TupleAdd(step_val15))
            {
                if ((int)(new HTuple(((((hv_DecodedDataStrings.TupleStrBitSelect(hv_J))).TupleOrd())).TupleLess(32))) != 0)
                {
                    hv_Char.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Char = "\\x" + (((((hv_DecodedDataStrings.TupleStrBitSelect(hv_J))).TupleOrd())).TupleString("02x"));
                    }
                }
                else
                {
                    hv_Char.Dispose();
                    using (HDevDisposeHelper dh = new HDevDisposeHelper())
                    {
                        hv_Char = hv_DecodedDataStrings.TupleStrBitSelect(hv_J);
                    }
                }
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    HTuple ExpTmpLocalVar_String = hv_String + hv_Char;
                    hv_String.Dispose();
                    hv_String = ExpTmpLocalVar_String;
                }
            }
            if(!String.IsNullOrEmpty(hv_String))  
            {
                return new OcrResult() { Message = $"{DateTime.Now}:匹配耗时:{timeSpan} ms 匹配结果:{hv_String}",IsSuccess=true,TimeSpan= timeSpan };
            }
            else
                return new OcrResult() { Message = $"{DateTime.Now}:匹配耗时:{timeSpan} ms 匹配结果:{hv_String}", IsSuccess =false , TimeSpan = timeSpan };

        }
    }
}
