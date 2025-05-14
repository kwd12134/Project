using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL12
{
    public class DataGridViewHelper
    {
        /// <summary>
        /// 给DataGridView添加行号
        /// </summary>
        /// <param name="dgv">dgv控件</param>
        /// <param name="e">dgv参数</param>
        public static void DgvRowPostPaint(DataGridView dgv, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //添加行号 
                SolidBrush solidBrush = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
                //添加行号的数据
                string lineNo = (e.RowIndex + 1).ToString();
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(lineNo, e.InheritedRowStyle.Font, solidBrush, new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth, dgv.RowTemplate.Height), sf);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }

        /// <summary>
        /// 给DataGridView绘制边框
        /// </summary>
        /// <param name="dgv">dgv控件</param>
        /// <param name="e">dgv参数</param>
        public static void DgvRowPaint(DataGridView dgv, PaintEventArgs e, Color borderColor)
        {
            e.Graphics.DrawRectangle(new Pen(borderColor), new Rectangle(0, 0, dgv.Width - 1, dgv.Height - 1));
        }

        /// <summary>
        /// 奇偶换色
        /// </summary>        
        public static void DgvStyle(DataGridView dgv, Color defaultBackColor, Color alternatingBackColor, Color gridColor)
        {
            //奇数行的背景色
            dgv.AlternatingRowsDefaultCellStyle.BackColor = alternatingBackColor;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = alternatingBackColor;

            //默认的行样式
            dgv.RowsDefaultCellStyle.BackColor = defaultBackColor;
            dgv.RowsDefaultCellStyle.SelectionBackColor = defaultBackColor;


            dgv.RowHeadersDefaultCellStyle.BackColor = defaultBackColor;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = defaultBackColor;

            //数据网格颜色
            dgv.GridColor = gridColor;
        }
    }
}

