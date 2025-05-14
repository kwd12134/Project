using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL12
{
    public class Helper
    {

        /// <summary>
        /// 处理从串口接收到的数据，并确保数据的完整性。
        /// </summary>
        /// <param name="data">新接收到的数据。</param>
        /// <param name="buffer">存储接收到的所有数据的缓冲区。</param>
        /// <param name="separator">消息分隔符。</param>
        /// <param name="onCompleteMessage">当接收到一条完整消息时调用的回调函数。</param>
        private void ProcessReceivedData(string data, StringBuilder buffer, char separator, Action<string> onCompleteMessage)
        {
            // 将新接收到的数据追加到缓冲区中
            buffer.Append(data);

            // 将缓冲区转换为字符串以便处理
            string bufferContent = buffer.ToString();

            // 查找分隔符的位置，以确定是否有完整的消息
            int endIndex;
            while ((endIndex = bufferContent.IndexOf(separator)) >= 0)
            {
                // 提取完整的消息（包括分隔符）
                string completeMessage = bufferContent.Substring(0, endIndex + 1);

                // 调用回调函数处理完整的消息
                onCompleteMessage(completeMessage);

                // 从缓冲区中移除已处理的消息
                bufferContent = bufferContent.Substring(endIndex + 1);
            }

            // 清空缓冲区，并保留未处理的数据
            buffer.Clear();
            buffer.Append(bufferContent);
        }

        // 示例使用方法
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
               // // 从串口读取现有的数据
               // string data = serialPort.ReadExisting();

               // // 调用通用的ProcessReceivedData函数处理数据
               // ProcessReceivedData(data, receivedDataBuffer, '\n', (completeMessage) =>
               // {
               //     // 在UI线程中显示完整的消息
               //     this.Invoke(new Action(() => textBoxReceived.AppendText(completeMessage)));
               // });
            }
            catch (Exception ex)
            {
                // 异常处理
                MessageBox.Show("Error reading from serial port: " + ex.Message);
            }
        }

    }
}
