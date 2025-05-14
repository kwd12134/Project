using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HorizontalAlignment = NPOI.SS.UserModel.HorizontalAlignment;

namespace Helper
{
    public class ExcelHelper
    {
        #region 1.从DataTable/List导出到excel文件中，支持xls和xlsx格式


        /// <summary>
        ///  DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">数据源</param>
        /// <param name="strHeaderText">表名</param>
        /// <param name="strFileName">excel文件名</param>
        /// <param name="dir">datatable和excel列名对应字典</param>
        /// <param name="sheetRow">每个sheet存放的行数</param>
        public static void DataTableToExcel(DataTable dtSource, string strHeaderText, string strFileName, Dictionary<string, string> dir, bool isNew, int sheetRow = 50000)
        {
            int currentSheetCount = GetSheetNumber(strFileName);//现有的页数sheetnum
            if (sheetRow <= 0)
            {
                sheetRow = dtSource.Rows.Count;
            }
            string[] temp = strFileName.Split('.');
            string fileExtens = temp[temp.Length - 1];
            int sheetCount = (int)Math.Ceiling((double)dtSource.Rows.Count / sheetRow);//sheet数目
            if (temp[temp.Length - 1] == "xls" && dtSource.Columns.Count < 256 && sheetRow < 65536)
            {
                if (isNew)
                {
                    currentSheetCount = 0;
                }
                for (int i = currentSheetCount; i < currentSheetCount + sheetCount; i++)
                {
                    DataTable pageDataTable = dtSource.Clone();
                    int hasRowCount = dtSource.Rows.Count - sheetRow * (i - currentSheetCount) < sheetRow ? dtSource.Rows.Count - sheetRow * (i - currentSheetCount) : sheetRow;
                    for (int j = 0; j < hasRowCount; j++)
                    {
                        pageDataTable.ImportRow(dtSource.Rows[(i - currentSheetCount) * sheetRow + j]);
                    }

                    using (MemoryStream ms = ExportDataTable(strFileName, pageDataTable, strHeaderText, dir, i))
                    {
                        using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                        {

                            byte[] data = ms.ToArray();
                            fs.Write(data, 0, data.Length);
                            fs.Flush();
                        }
                    }
                }
            }
            else
            {
                if (temp[temp.Length - 1] == "xls")
                    strFileName = strFileName + "x";
                if (isNew)
                {
                    currentSheetCount = 0;
                }
                for (int i = currentSheetCount; i < currentSheetCount + sheetCount; i++)
                {
                    DataTable pageDataTable = dtSource.Clone();
                    int hasRowCount = dtSource.Rows.Count - sheetRow * (i - currentSheetCount) < sheetRow ? dtSource.Rows.Count - sheetRow * (i - currentSheetCount) : sheetRow;
                    for (int j = 0; j < hasRowCount; j++)
                    {
                        pageDataTable.ImportRow(dtSource.Rows[(i - currentSheetCount) * sheetRow + j]);
                    }
                    FileStream readfs = new FileStream(strFileName, FileMode.OpenOrCreate, FileAccess.Read);
                    MemoryStream readfsm = new MemoryStream();
                    readfs.CopyTo(readfsm);
                    readfs.Close();
                    using (FileStream writefs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                    {

                        ExportDataTable(pageDataTable, strHeaderText, writefs, readfsm, dir, i);
                    }
                    readfsm.Close();
                }
            }
        }

        /// <summary>
        /// 将List集合导出到Excel文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="strHeaderText"></param>
        /// <param name="strFileName"></param>
        /// <param name="dir"></param>
        /// <param name="isNew"></param>
        /// <param name="sheetRow"></param>
        public static void ListToExcel<T>(List<T> list, string strHeaderText, string strFileName, Dictionary<string, string> dir, bool isNew, int sheetRow = 50000)
        {
            DataTable dataTable = ListToDataTable<T>(list);

            DataTableToExcel(dataTable, strHeaderText, strFileName, dir, isNew, sheetRow);
        }


        /// <summary>
        /// 导出为xls文件内部方法
        /// </summary>
        /// <param name="strFileName">excel文件名</param>
        /// <param name="dtSource">datatabe源数据</param>
        /// <param name="strHeaderText">表名</param>
        /// <param name="sheetnum">sheet的编号</param>
        /// <returns></returns>
        private static MemoryStream ExportDataTable(string strFileName, DataTable dtSource, string strHeaderText, Dictionary<string, string> dir, int sheetnum)
        {
            //创建工作簿和sheet
            IWorkbook workbook = new HSSFWorkbook();
            using (Stream writefile = new FileStream(strFileName, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (writefile.Length > 0 && sheetnum > 0)
                {
                    workbook = WorkbookFactory.Create(writefile);
                }
            }

            ISheet sheet = null;
            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 0)
                {
                    string sheetName = strHeaderText + (sheetnum == 0 ? "" : sheetnum.ToString());
                    if (workbook.GetSheetIndex(sheetName) >= 0)
                    {
                        workbook.RemoveSheetAt(workbook.GetSheetIndex(sheetName));
                    }
                    sheet = workbook.CreateSheet(sheetName);
                    #region 表头及样式
                    {
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.IsBold = true;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;

                        rowIndex = 1;
                    }
                    #endregion

                    #region 列头及样式

                    if (rowIndex == 1)
                    {
                        IRow headerRow = sheet.CreateRow(1);//第二行设置列名
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.IsBold = true;
                        headStyle.SetFont(font);
                        //写入列标题
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(dir[column.ColumnName]);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256 * 2);
                        }
                        rowIndex = 2;
                    }
                    #endregion
                }
                #endregion

                #region 填充内容

                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    ICell newCell = dataRow.CreateCell(column.Ordinal);
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String": //字符串类型
                            double result;
                            if (isNumeric(drValue, out result))
                            {
                                //数字字符串
                                double.TryParse(drValue, out result);
                                newCell.SetCellValue(result);
                                break;
                            }
                            else
                            {
                                newCell.SetCellValue(drValue);
                                break;
                            }

                        case "System.DateTime": //日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle; //格式化显示
                            break;
                        case "System.Boolean": //布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16": //整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal": //浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull": //空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue(drValue.ToString());
                            break;
                    }

                }
                #endregion
                rowIndex++;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                return ms;
            }

        }

        /// <summary>
        /// 导出为xlsx文件内部方法
        /// </summary>
        /// <param name="dtSource">datatable数据源</param>
        /// <param name="strHeaderText">表名</param>
        /// <param name="fs">文件流</param>
        /// <param name="readfs">内存流</param>
        /// <param name="sheetnum">sheet索引</param>
        private static void ExportDataTable(DataTable dtSource, string strHeaderText, FileStream fs, MemoryStream readfs, Dictionary<string, string> dir, int sheetnum)
        {

            IWorkbook workbook = new XSSFWorkbook();
            if (readfs.Length > 0 && sheetnum > 0)
            {
                workbook = WorkbookFactory.Create(readfs);
            }
            ISheet sheet = null;
            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式

                if (rowIndex == 0)
                {
                    #region 表头及样式
                    {
                        string sheetName = strHeaderText + (sheetnum == 0 ? "" : sheetnum.ToString());
                        if (workbook.GetSheetIndex(sheetName) >= 0)
                        {
                            workbook.RemoveSheetAt(workbook.GetSheetIndex(sheetName));
                        }
                        sheet = workbook.CreateSheet(sheetName);
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.IsBold = true;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                    }
                    #endregion

                    #region 列头及样式
                    {
                        IRow headerRow = sheet.CreateRow(1);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.IsBold = true;
                        headStyle.SetFont(font);


                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(dir[column.ColumnName]);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256 * 2);
                        }
                    }

                    #endregion

                    rowIndex = 2;
                }
                #endregion

                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    ICell newCell = dataRow.CreateCell(column.Ordinal);
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String": //字符串类型
                            double result;
                            if (isNumeric(drValue, out result))
                            {

                                double.TryParse(drValue, out result);
                                newCell.SetCellValue(result);
                                break;
                            }
                            else
                            {
                                newCell.SetCellValue(drValue);
                                break;
                            }
                        case "System.DateTime": //日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle; //格式化显示
                            break;
                        case "System.Boolean": //布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16": //整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal": //浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull": //空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue(drValue.ToString());
                            break;
                    }
                }
                #endregion
                rowIndex++;
            }
            workbook.Write(fs);
            fs.Close();
        }

        private static DataTable ListToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();

            var dt = new DataTable();

            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());

            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();

                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }

                    object[] array = tempList.ToArray();

                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        /// <summary>
        /// 判断内容是否是数字
        /// </summary>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static bool isNumeric(String message, out double result)
        {
            Regex rex = new Regex(@"^[-]?\d+[.]?\d*$");
            result = -1;
            if (rex.IsMatch(message))
            {
                result = double.Parse(message);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 获取excel文件的sheet数目
        /// </summary>
        /// <param name="outputFile"></param>
        /// <returns></returns>
        private static int GetSheetNumber(string outputFile)
        {
            int number = 0;
            using (FileStream readfile = new FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if (readfile.Length > 0)
                {
                    IWorkbook wb = WorkbookFactory.Create(readfile);
                    number = wb.NumberOfSheets;
                }
            }
            return number;
        }

        #endregion

        #region  2.从excel文件中将数据导出到DataTable/List

        /// <summary>
        /// 读取Excel文件特定名字sheet的内容到DataTable
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <param name="dir">excel列名和DataTable列名的对应字典</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string strFileName, Dictionary<string, string> dir, string SheetName, int HeaderRowIndex = 1)
        {
            DataTable table = new DataTable();
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                if (file.Length > 0)
                {
                    IWorkbook wb = WorkbookFactory.Create(file);
                    ISheet isheet = wb.GetSheet(SheetName);
                    table = ImportExcel(isheet, HeaderRowIndex, dir);
                    isheet = null;
                }
            }
            return table;
        }

        /// <summary>
        /// 读取Excel文件某一索引sheet的内容到DataTable
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet序号</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <param name="dir">excel列名和DataTable列名的对应字典</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string strFileName, Dictionary<string, string> dir, int SheetIndex = 0, int HeaderRowIndex = 1)
        {
            DataTable table = new DataTable();
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                if (file.Length > 0)
                {
                    IWorkbook wb = WorkbookFactory.Create(file);
                    ISheet isheet = wb.GetSheetAt(SheetIndex);
                    table = ImportExcel(isheet, HeaderRowIndex, dir);
                    isheet = null;
                }
            }
            return table;

        }

        /// <summary>
        /// 读取Excel文件特定名字sheet的内容到List集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strFileName"></param>
        /// <param name="dir"></param>
        /// <param name="SheetName"></param>
        /// <param name="HeaderRowIndex"></param>
        /// <returns></returns>
        public static List<T> ExcelToList<T>(string strFileName, Dictionary<string, string> dir, string SheetName, int HeaderRowIndex = 1)
        {
            DataTable dataTable = ExcelToDataTable(strFileName, dir, SheetName, HeaderRowIndex);

            return DataTableToList<T>(dataTable);
        }


        /// <summary>
        /// 读取Excel文件某一索引sheet的内容到List集合
        /// </summary>
        /// <param name="strFileName">excel文件路径</param>
        /// <param name="sheet">需要导出的sheet序号</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <param name="dir">excel列名和DataTable列名的对应字典</param>
        /// <returns></returns>
        public static List<T> ExcelToList<T>(string strFileName, Dictionary<string, string> dir, int SheetIndex, int HeaderRowIndex = 1)
        {
            DataTable dataTable = ExcelToDataTable(strFileName, dir, SheetIndex, HeaderRowIndex);

            return DataTableToList<T>(dataTable);
        }

        /// <summary>
        /// 将制定sheet中的数据导出到datatable中
        /// </summary>
        /// <param name="sheet">需要导出的sheet</param>
        /// <param name="HeaderRowIndex">列头所在行号，-1表示没有列头</param>
        /// <param name="dir">excel列名和DataTable列名的对应字典</param>
        /// <returns></returns>
        private static DataTable ImportExcel(ISheet sheet, int HeaderRowIndex, Dictionary<string, string> dir)
        {
            DataTable table = new DataTable();
            IRow headerRow;
            int cellCount;
            try
            {
                //没有标头或者不需要表头用excel列的序号（1,2,3..）作为DataTable的列名
                if (HeaderRowIndex < 0)
                {
                    headerRow = sheet.GetRow(0);
                    cellCount = headerRow.LastCellNum;

                    for (int i = headerRow.FirstCellNum; i <= cellCount; i++)
                    {
                        DataColumn column = new DataColumn(Convert.ToString(i));
                        table.Columns.Add(column);
                    }
                }
                //有表头，使用表头做为DataTable的列名
                else
                {
                    headerRow = sheet.GetRow(HeaderRowIndex);
                    cellCount = headerRow.LastCellNum;
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        //如果excel某一列列名不存在：以该列的序号作为Datatable的列名，如果DataTable中包含了这个序列为名的列，那么列名为重复列名+序号
                        if (headerRow.GetCell(i) == null)
                        {
                            if (table.Columns.IndexOf(Convert.ToString(i)) > 0)
                            {
                                DataColumn column = new DataColumn(Convert.ToString("重复列名" + i));
                                table.Columns.Add(column);
                            }
                            else
                            {
                                DataColumn column = new DataColumn(Convert.ToString(i));
                                table.Columns.Add(column);
                            }

                        }
                        //excel中的某一列列名不为空，但是重复了：对应的Datatable列名为“重复列名+序号”
                        else if (table.Columns.IndexOf(headerRow.GetCell(i).ToString()) > 0)
                        {
                            DataColumn column = new DataColumn(Convert.ToString("重复列名" + i));
                            table.Columns.Add(column);
                        }
                        else
                        //正常情况，列名存在且不重复：用excel中的列名作为datatable中对应的列名
                        {
                            string colName = dir.Where(s => s.Value == headerRow.GetCell(i).ToString()).First().Key;
                            DataColumn column = new DataColumn(colName);
                            table.Columns.Add(column);
                        }
                    }
                }
                int rowCount = sheet.LastRowNum;
                for (int i = (HeaderRowIndex + 1); i <= sheet.LastRowNum; i++)//excel行遍历
                {
                    try
                    {
                        IRow row;
                        if (sheet.GetRow(i) == null)//如果excel有空行，则添加缺失的行
                        {
                            row = sheet.CreateRow(i);
                        }
                        else
                        {
                            row = sheet.GetRow(i);
                        }

                        DataRow dataRow = table.NewRow();

                        for (int j = row.FirstCellNum; j <= cellCount; j++)//excel列遍历
                        {
                            try
                            {
                                if (row.GetCell(j) != null)
                                {
                                    switch (row.GetCell(j).CellType)
                                    {
                                        case CellType.String://字符串
                                            string str = row.GetCell(j).StringCellValue;
                                            if (str != null && str.Length > 0)
                                            {
                                                dataRow[j] = str.ToString();
                                            }
                                            else
                                            {
                                                dataRow[j] = default(string);
                                            }
                                            break;
                                        case CellType.Numeric://数字
                                            if (DateUtil.IsCellDateFormatted(row.GetCell(j)))//时间戳数字
                                            {
                                                dataRow[j] = DateTime.FromOADate(row.GetCell(j).NumericCellValue);
                                            }
                                            else
                                            {
                                                dataRow[j] = Convert.ToDouble(row.GetCell(j).NumericCellValue);
                                            }
                                            break;
                                        case CellType.Boolean:
                                            dataRow[j] = Convert.ToString(row.GetCell(j).BooleanCellValue);
                                            break;
                                        case CellType.Error:
                                            dataRow[j] = ErrorEval.GetText(row.GetCell(j).ErrorCellValue);
                                            break;
                                        case CellType.Formula://公式
                                            switch (row.GetCell(j).CachedFormulaResultType)
                                            {
                                                case CellType.String:
                                                    string strFORMULA = row.GetCell(j).StringCellValue;
                                                    if (strFORMULA != null && strFORMULA.Length > 0)
                                                    {
                                                        dataRow[j] = strFORMULA.ToString();
                                                    }
                                                    else
                                                    {
                                                        dataRow[j] = null;
                                                    }
                                                    break;
                                                case CellType.Numeric:
                                                    dataRow[j] = Convert.ToString(row.GetCell(j).NumericCellValue);
                                                    break;
                                                case CellType.Boolean:
                                                    dataRow[j] = Convert.ToString(row.GetCell(j).BooleanCellValue);
                                                    break;
                                                case CellType.Error:
                                                    dataRow[j] = ErrorEval.GetText(row.GetCell(j).ErrorCellValue);
                                                    break;
                                                default:
                                                    dataRow[j] = "";
                                                    break;
                                            }
                                            break;
                                        default:
                                            dataRow[j] = "";
                                            break;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        table.Rows.Add(dataRow);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }


        private static List<T> DataTableToList<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }
            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        private static List<T> ConvertTo<T>(IList<DataRow> rows)
        {
            List<T> list = null;
            if (rows != null)
            {

                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }

            }
            return list;

        }

        private static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);

            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)

                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);

                    try
                    {
                        object value = row[column.ColumnName];

                        SetObjectPropertyValue(obj, column.ColumnName, value.ToString());
                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return obj;
        }

        /// <summary>
        /// 通过属性名称设置值
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="value">值</param>
        /// <returns>是否成功</returns>
        private static bool SetObjectPropertyValue<T>(T obj, string propertyName, string value)
        {
            try
            {
                Type type = typeof(T);

                object t = Convert.ChangeType(value, type.GetProperty(propertyName).PropertyType);

                type.GetProperty(propertyName).SetValue(obj, t, null);

                return true;

            }
            catch (Exception )
            {
                return false;
            }
        }

        #endregion

        #region Excel导入导出到DataGridView

        /// <summary>
        /// DataGridView导出到Excel
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dataGridView"></param>
        /// <param name="isAppend"></param>
        /// <returns></returns>
        public static bool DataGridViewToExcel(string filePath, DataGridView dataGridView, bool isAppend = false)
        {
            if (isAppend)
            {
                return DataGridViewToExcelAdd(filePath, dataGridView);
            }
            else
            {
                return DataGridViewToExcelNew(filePath, dataGridView);
            }
        }

        //------------【函数：将表格控件保存至Excel文件(新建/替换)】------------    

        //filePath要保存的目标Excel文件路径名
        //datagGridView要保存至Excel的表格控件
        //------------------------------------------------------------------------
        private static bool DataGridViewToExcelNew(string filePath, DataGridView dataGridView)
        {
            bool result = true;

            FileStream fs = null;//创建一个新的文件流
            HSSFWorkbook workbook = null;//创建一个新的Excel文件
            ISheet sheet = null;//为Excel创建一张工作表

            //定义行数、列数、与当前Excel已有行数
            int rowCount = dataGridView.RowCount;//记录表格中的行数
            int colCount = dataGridView.ColumnCount;//记录表格中的列数

            //判断文件夹是否存在
            if (CheckAndCreatPath(DecomposePathAndName(filePath, DecomposePathEnum.PathOnly)) == "error")
            {
                result = false;
                return result;
            }

            //创建工作表
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                workbook = new HSSFWorkbook();
                sheet = workbook.CreateSheet("Sheet1");
                IRow row = sheet.CreateRow(0);
                for (int j = 0; j < colCount; j++)  //列循环
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Rows[0].Cells[j].Value != null)
                    {
                        ICell cell = row.CreateCell(j);//创建列
                        cell.SetCellValue(dataGridView.Columns[j].HeaderText.ToString());//更改单元格值                  
                    }
                }
            }
            catch
            {
                result = false;
                return result;
            }

            for (int i = 0; i < rowCount; i++)      //行循环
            {
                //防止行数超过Excel限制
                if (i >= 65536)
                {
                    result = false;
                    break;
                }
                IRow row = sheet.CreateRow(1 + i);  //创建行
                for (int j = 0; j < colCount; j++)  //列循环
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        ICell cell = row.CreateCell(j);//创建列
                        cell.SetCellValue(dataGridView.Rows[i].Cells[j].Value.ToString());//更改单元格值                  
                    }
                }
            }
            try
            {
                workbook.Write(fs);
            }
            catch
            {
                result = false;
                return result;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
                workbook = null;
            }
            return result;
        }

        //------------【函数：将表格控件保存至Excel文件(添加/新建)】------------    
        //filePath要保存的目标Excel文件路径名
        //datagGridView要保存至Excel的表格控件
        //------------------------------------------------
        private static bool DataGridViewToExcelAdd(string filePath, DataGridView dataGridView)
        {
            bool result = true;

            FileStream fs = null;//创建一个新的文件流
            HSSFWorkbook workbook = null;//创建一个新的Excel文件
            ISheet sheet = null;//为Excel创建一张工作表

            //定义行数、列数、与当前Excel已有行数
            int rowCount = dataGridView.RowCount;//记录表格中的行数
            int colCount = dataGridView.ColumnCount;//记录表格中的列数
            int numCount = 0;//Excell最后一行序号

            //判断文件夹是否存在
            if (CheckAndCreatPath(DecomposePathAndName(filePath, DecomposePathEnum.PathOnly)) == "error")
            {
                result = false;
                return result;
            }
            //判断文件是否存在
            if (!File.Exists(filePath))
            {
                try
                {
                    fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    workbook = new HSSFWorkbook();
                    sheet = workbook.CreateSheet("Sheet1");
                    IRow row = sheet.CreateRow(0);
                    for (int j = 0; j < colCount; j++)  //列循环
                    {
                        if (dataGridView.Columns[j].Visible && dataGridView.Rows[0].Cells[j].Value != null)
                        {
                            ICell cell = row.CreateCell(j);//创建列
                            cell.SetCellValue(dataGridView.Columns[j].HeaderText.ToString());//更改单元格值                  
                        }
                    }
                    workbook.Write(fs);
                }
                catch
                {
                    result = false;
                    return result;
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                        fs.Dispose();
                        fs = null;
                    }
                    workbook = null;
                }
            }
            //创建指向文件的工作表
            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workbook = new HSSFWorkbook(fs);//.xls
                sheet = workbook.GetSheetAt(0);
                if (sheet == null)
                {
                    result = false;
                    return result;
                }
                numCount = sheet.LastRowNum + 1;
            }
            catch
            {
                result = false;
                return result;
            }

            for (int i = 0; i < rowCount; i++)      //行循环
            {
                //防止行数超过Excel限制
                if (numCount + i >= 65536)
                {
                    result = false;
                    break;
                }
                IRow row = sheet.CreateRow(numCount + i);  //创建行
                for (int j = 0; j < colCount; j++)  //列循环
                {
                    if (dataGridView.Columns[j].Visible && dataGridView.Rows[i].Cells[j].Value != null)
                    {
                        ICell cell = row.CreateCell(j);//创建列
                        cell.SetCellValue(dataGridView.Rows[i].Cells[j].Value.ToString());//更改单元格值                  
                    }
                }
            }
            try
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workbook.Write(fs);
            }
            catch
            {
                result = false;
                return result;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
                workbook = null;
            }
            return result;
        }


        //------------【函数：从Excel文件读取数据到表格控件】------------    
        //filePath为Excel文件路径名
        //datagGridView要显示数据的表格控件
        //------------------------------------------------
        public static bool ExcelToDataGridView(string filePath, DataGridView dataGridView, bool hastitle = false)
        {
            bool result = true;

            FileStream fs = null;//创建一个新的文件流
            HSSFWorkbook workbook = null;//创建一个新的Excel文件
            ISheet sheet = null;//为Excel创建一张工作表

            //定义行数、列数
            int rowCount = 0;//记录Excel中的行数
            int colCount = 0;//记录Excel中的列数

            //判断文件是否存在
            if (!File.Exists(filePath))
            {
                result = false;
                return result;
            }
            //创建指向文件的工作表
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                workbook = new HSSFWorkbook(fs);//.xls
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
                sheet = workbook.GetSheetAt(0);
                if (sheet == null)
                {
                    result = false;
                    return result;
                }
                rowCount = sheet.LastRowNum;
                colCount = sheet.GetRow(0).LastCellNum;
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                for (int j = 0; j < colCount; j++)  //列循环
                {
                    ICell cell = sheet.GetRow(0).GetCell(j);//获取列
                    dataGridView.Columns.Add(j.ToString() + cell.ToString(), cell.ToString());
                }

                for (int i = 1; i <= rowCount; i++)      //行循环
                {
                    IRow row = sheet.GetRow(i);  //获取行
                    int index = dataGridView.Rows.Add();
                    colCount = row.LastCellNum;
                    for (int j = 0; j < colCount; j++)  //列循环
                    {
                        ICell cell = row.GetCell(j);//获取列
                        dataGridView.Rows[index].Cells[j].Value = cell.ToString();
                    }
                }
            }
            catch (Exception )
            {
                result = false;
                return result;
            }
            return result;
        }


        //分解路径用枚举
        public enum DecomposePathEnum
        {
            PathOnly = 0,//仅返回路径
            NameAndExtension = 1,//返回文件名+扩展名
            NameOnly = 2,//仅返回文件名
            ExtensionOnly = 3,//仅返回扩展名(带.)

        }

        //------------【函数：将文件路径分解】------------  

        //filePath文件路径
        //DecomposePathEnum返回类型
        //------------------------------------------------
        private static string DecomposePathAndName(string filePath, DecomposePathEnum decomposePathEnum)
        {
            string result = "";
            switch (decomposePathEnum)
            {
                case DecomposePathEnum.PathOnly://仅返回路径
                    result = filePath.Substring(0, filePath.LastIndexOf("\\"));
                    break;
                case DecomposePathEnum.NameAndExtension://返回文件名+扩展名
                    result = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    break;
                case DecomposePathEnum.NameOnly://仅返回文件名
                    result = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.LastIndexOf(".") - filePath.LastIndexOf("\\") - 1);
                    break;
                case DecomposePathEnum.ExtensionOnly://仅返回扩展名(带.)
                    result = filePath.Substring(filePath.LastIndexOf("."));
                    break;
                default://
                    result = "";
                    break;
            }
            return result;
        }


        //------------【函数：判断文件路径是否存在，不存在则创建】------------  

        //filePath文件夹路径
        //DecomposePathEnum返回类型
        //---------------------------------------------------------------------
        private static string CheckAndCreatPath(string path)
        {
            if (Directory.Exists(path))
            {
                return path;
            }
            else
            {
                if (path.LastIndexOf("\\") <= 0)
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                        return path;
                    }
                    catch
                    {
                        return "error";
                    }
                }
                else
                {
                    if (CheckAndCreatPath(DecomposePathAndName(path, DecomposePathEnum.PathOnly)) == "error")
                    {
                        return "error";
                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                        return path;
                    }
                }
            }
        }


        #endregion

    }
}
