using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using thinger.DataConvertLib;
using thinger.MTHHelper;

namespace KWDHTMmodels
{
    public class CommonMethod
    {
        /// <summary>
        /// 设备参数
        /// </summary>
        public static Device Deviced { get; set; }

        /// <summary>
        /// 系统委托创建日志
        /// </summary>
        public static Action<int, string> AddLog;
        /// <summary>
        /// 当前登录的用户信息
        /// </summary>

        public static SysAdmin CureenAdmin { get; set; }

        /// <summary>
        /// 通信对象
        /// </summary>
        public static ModbusTCP ModbusTCP { get; set; }

        public static DataFormat dataFormat = DataFormat.ABCD;

        /// <summary>
        /// 通过标签名称来找到变量组里面对应的Variable对象
        /// </summary>
        /// <param name="VarName"></param>
        /// <returns></returns>
        public static Variable FindVariable(string VarName)
        {
            foreach (var item in Deviced.GroupList)
            {
                var result = item.VariableList.Find(c => { return c.VarName == VarName; });
                if (result!=null)
                {
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// 通用写入方法
        /// </summary>
        /// <param name="VarName"></param>
        /// <param name="VarValue"></param>
        /// <returns></returns>
        public static bool CommonWirte(string VarName, string VarValue)
        {
            //找到变量对象    
            var Variable = FindVariable(VarName);
            if (Variable != null)
            {
                //找到变量数据类型
                DataType dataType = (DataType)Enum.Parse(typeof(DataType), Variable.DataType, true);

                //解析偏移值
                var result = MigrationLib.SetMigrationValue
                    (VarValue, dataType, Variable.Scale.ToString(), Variable.Offset.ToString());

                if (result.IsSuccess)
                {

                    try
                    {
                        //写入数据
                        switch (dataType)
                        {
                            case DataType.Bool:
                                return ModbusTCP.PreSetSingleCoil(Variable.Start, Convert.ToBoolean(result.Content));
                            case DataType.Short:
                                return ModbusTCP.PreSetSingleRegister(Variable.Start, Convert.ToInt16(result.Content));
                            case DataType.UShort:
                                return ModbusTCP.PreSetSingleRegister(Variable.Start, Convert.ToUInt16(result.Content));
                            case DataType.Int:
                                return ModbusTCP.PreSetMultiRegisters
                                    (Variable.Start, ByteArrayLib.GetByteArrayFromInt(Convert.ToInt32(result.Content), dataFormat));
                            case DataType.UInt:
                                return ModbusTCP.PreSetMultiRegisters
                                    (Variable.Start, ByteArrayLib.GetByteArrayFromUInt(Convert.ToUInt32(result.Content), dataFormat));
                            case DataType.Float:
                                return ModbusTCP.PreSetMultiRegisters
                                    (Variable.Start, ByteArrayLib.GetByteArrayFromFloat(Convert.ToSingle(result.Content), dataFormat));
                            case DataType.Double:
                                return ModbusTCP.PreSetMultiRegisters
                                    (Variable.Start, ByteArrayLib.GetByteArrayFromDouble(Convert.ToDouble(result.Content), dataFormat));
                            case DataType.Long:
                                return ModbusTCP.PreSetMultiRegisters
                                    (Variable.Start, ByteArrayLib.GetByteArrayFromLong(Convert.ToInt64(result.Content), dataFormat));
                            case DataType.ULong:
                                return ModbusTCP.PreSetMultiRegisters
                                    (Variable.Start, ByteArrayLib.GetByteArrayFromULong(Convert.ToUInt64(result.Content), dataFormat));
                            case DataType.String:
                                return ModbusTCP.PreSetMultiRegisters
                                    (Variable.Start, ByteArrayLib.GetByteArrayFromString(result.Content, Encoding.ASCII));
                            case DataType.ByteArray:
                                return ModbusTCP.PreSetMultiRegisters(Variable.Start, ByteArrayLib.GetByteArrayFromHexString(result.Content));
                            case DataType.HexString:
                                return ModbusTCP.PreSetMultiRegisters(Variable.Start, ByteArrayLib.GetByteArrayFromHexString(result.Content));
                            default:
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
