using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using McmqApi;
using Microsoft.Extensions.DependencyInjection;
using SendReceiveCom.com;
using SendReceiveCom.Entity;
using SendReceiveCom.Helper;
using SendReceiveCom.Properties;
using SendReceiveCom.Service;
using thinger.DataConvertLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Management;
using System.Net.NetworkInformation;

namespace SendReceiveCom
{

    public partial class ComAssistance : Form
    {

        public ComAssistance()
        {
            this.InitializeComponent();
            ComAssistance.frmmain = this;
            LogMethod.log("******************START********************");
            this.DoubleBuffered = true;

            // 创建服务集合   这就是我们的IoC容器  控制反转   mcmq模块解耦防止卡顿导致程序卡顿
            //ServiceCollection services = new ServiceCollection();

            //services.AddSingleton<IMcmq, Mcmq>();
            //// 构建服务提供者
            //var serviceProvider = services.BuildServiceProvider();
            //// 初始化服务定位器
            //ServiceLocator.Init(serviceProvider);

        }


        #region 界面事件部分

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.button2.Enabled)
            {
                if (this.textBox11.Text == tc.SampleSN)
                {
                    but_spotCheck_Click(null, null);
                }
                else
                {
                    button2_Click(null, null);
                }
                //but_spotCheck_Click(null, null);
            }
        }

        /// <summary>
        /// 连接ASIL板按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            ComAssistance.tc.Display();
            this.openport();
        }

        private void ComAssistance_Shown(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(this.start))
            {
                IsBackground = true
            }.Start();

            //Task.Factory.StartNew(start);
        }

        #endregion

        #region 初始化开始部分

        public void start()
        {
            try
            {
                this.Setbutton2("N");
                ComAssistance.tc.random_number = ComAssistance.GetRandomList(1).ToString();
                ComAssistance.tc.Display();
                SpotCheckLoad();
                this.Invoke(new Action(() => { LoadSerialPort(); }));
                this.Invoke(new Action(SetLimit));
                this.openport();
                this.Setlabel15("测试机通信侦听中...");
                LogMethod.log("测试机通信侦听中...");
                this.JConnect();
                //string path = Environment.CurrentDirectory + "\\config\\AsilTest.xml";
                //byte[] asil = this.FileTOByte(path);
                this.Setlabel15("PIS2通信连接中...");
                LogMethod.log("PIS2通信连接中...");
                SetPositionPanelID();
                //this.ConectCMMQ(ComAssistance.tc.SendQueue, ComAssistance.tc.ReplyQueue, ComAssistance.tc.pis2Ip, ComAssistance.tc.pis2Port, asil, null);
                this.Setbutton2("Y");
                Task.Run(() =>
                {
                    while (true)
                    {
                        LoopMonitorTime();
                        Thread.Sleep(5000);
                    }
                });
                Task.Run(() =>
                {
                    while (true)
                    {
                        this.TestPort();
                        this.ReceiveMsg();
                        Thread.Sleep(30);
                    }
                });
            }
            catch (Exception ex)
            {
                this.Setlabel15(ex.Message);
                this.Setbutton2("Y");
                LogMethod.log(ex.Message);
            }
        }



        public void TestPort()
        {
            try
            {
                bool flag = !string.IsNullOrWhiteSpace(this.com) && this.com != ComAssistance.tc.comId;
                if (flag)
                {
                    this.OP.ClosePort();
                    this.asil1 = " ";
                    this.asil2 = " ";
                    this.asil3 = " ";
                    this.asil4 = " ";
                    this.asil5 = " ";
                    this.asil6 = " ";
                    this.asil7 = " ";
                    this.asil8 = " ";
                    this.frequent1 = " ";
                    this.frequent2 = " ";
                    this.appendText(" A A A A A A A A A ");
                    bool flag2 = this.OP.OpenPort(ComAssistance.tc.comId, ComAssistance.tc.baudRate, ComAssistance.tc.stopBit.ToString(), ComAssistance.tc.dataBits, ComAssistance.tc.parity.ToString());
                    if (flag2)
                    {
                        this.OP.SP.DataReceived += this.SP_DataReceived;
                        this.SetpictureBox1("green");
                        this.Setlabel19("ASIL板已连接");
                        LogMethod.log("ASIL板已连接");
                        this.Setlabel15("ASIL板已连接");
                        this.sendport("B");
                        this.com = ComAssistance.tc.comId;
                    }
                }
                bool flag3 = !this.OP.SP.IsOpen;
                if (flag3)
                {
                    this.SetpictureBox1("red");
                    this.Setlabel19("ASIL板未连接");
                    this.asil1 = " ";
                    this.asil2 = " ";
                    this.asil3 = " ";
                    this.asil4 = " ";
                    this.asil5 = " ";
                    this.asil6 = " ";
                    this.asil7 = " ";
                    this.asil8 = " ";
                    this.frequent1 = " ";
                    this.frequent2 = " ";
                    this.appendText(" A A A A A A A A A ");
                }
            }
            catch (Exception)
            {
                this.SetpictureBox1("red");
                this.Setlabel19("ASIL板未连接");
                this.asil1 = " ";
                this.asil2 = " ";
                this.asil3 = " ";
                this.asil4 = " ";
                this.asil5 = " ";
                this.asil6 = " ";
                this.asil7 = " ";
                this.asil8 = " ";
                this.frequent1 = " ";
                this.frequent2 = " ";
            }
        }

        #endregion

        #region 测试机上抛部分

        /// <summary>
        /// 连接到客户端实时读取
        /// </summary>
        public void ReceiveMsg()
        {
            Dictionary<string, MySession> obj = this.dic_ClientSocket;
            lock (obj)
            {
                try
                {
                    foreach (KeyValuePair<string, MySession> item in this.dic_ClientSocket.ToArray<KeyValuePair<string, MySession>>())
                    {
                        bool flag2 = item.Key != null;
                        if (flag2)
                        {
                            bool flag3 = this.dic_ClientSocket.TryGetValue(item.Key.ToString(), out this.cMySession);
                            if (flag3)
                            {
                                byte[] myReceByte = this.cMySession.GetBuffer(0, this.cMySession.m_Buffer.Count);
                                bool flag4 = myReceByte.Length != 0;
                                if (flag4)
                                {
                                    //StringBuilder builder = new StringBuilder();
                                    long received_count = 0L;
                                    received_count += (long)myReceByte.Length;
                                    //builder.Clear();
                                    this.myBy = myReceByte;
                                    this.myByLenth = myReceByte.Length;
                                    bool flag5 = myReceByte != null && myReceByte.Length != 0;
                                    if (flag5)
                                    {
                                        this.myStr = Encoding.ASCII.GetString(myReceByte);
                                        LogMethod.log("recive jince:" + this.myStr);
                                        ComAssistance.tc.JinceConmond = this.praseXmlData(this.myStr, "/Request/Command");
                                        string StreamNo = this.praseXmlData(this.myStr, "/Request/StreamNo");
                                        bool flag6 = ComAssistance.tc.JinceConmond == "SET_LOT_NO";
                                        if (flag6)
                                        {
                                            this.TestFlag = true;
                                            this.Setbutton2("N");

                                            //接收到jince的sn数据
                                            ComAssistance.tc.JinceSN = this.praseXmlData(this.myStr, "/Request/Param1");

                                            string senddata = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Response><Result>OK</Result><Param1></Param1><Param2></Param2><Param3></Param3><Param4></Param4>" +
                                                "<Param5></Param5><Param6></Param6><Param7></Param7><Param8></Param8><Param9></Param9></Response>";
                                            this.tcpsend(senddata);
                                            this.sendport("B");
                                            this.SetText11(ComAssistance.tc.JinceSN);
                                        }
                                        //string Model = this.praseXmlData(this.myStr, "/Request/Param2");

                                        //this.Invoke(new Action(() =>
                                        //{
                                        //    if (!(Model == label24.Text))
                                        //    {
                                        //        if (File.Exists(Application.StartupPath + $"\\Recipe\\{Model}.ini"))
                                        //        {
                                        //            UpdateRecipe(Application.StartupPath + $"\\Recipe\\{Model}.ini", Model);
                                        //            SetLimit();
                                        //        }
                                        //        else
                                        //        {

                                        //            MessageBox.Show($"当前无该参数配方名称,请新建 :{Model}");
                                        //            return;
                                        //        }
                                        //    }
                                        //}));
                                        if (!IsSpotCheck)
                                        {
                                            this.Invoke(new Action(() =>
                                            {
                                                MessageBox.Show("未进行点检");
                                                this.Send = false;
                                                this.Setbutton2("Y");
                                                return;
                                            }));
                                        }
                                        bool flag7 = ComAssistance.tc.JinceConmond == "ASIL" && this.label19.Text.Length > 0;
                                        if (flag7)
                                        {
                                            if (JudgeCheckTime())
                                            {
                                                Thread.Sleep(1000);
                                                this.AsilSend();
                                                this.Send = false;
                                                this.Setbutton2("Y");
                                            }
                                            else
                                            {
                                                this.Setlabel27("请进行点检");
                                                this.Setlabel15("经过指定班次时间,请进行首次点检");
                                                this.Invoke(new Action(() =>
                                                {
                                                    this.pictureBox4.Image = Resources.red;
                                                    MessageBox.Show("请进行点检");
                                                    this.Setbutton2("N");
                                                    return;
                                                }));
                                            }
                                        }
                                        else
                                        {
                                            bool flag8 = ComAssistance.tc.JinceConmond == "AG" && this.label19.Text.Length > 0;
                                            if (flag8)
                                            {
                                                Thread.Sleep(1000);
                                                this.AsilSend();
                                                this.Send = false;
                                                this.Setbutton2("Y");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    this.Setbutton2("Y");
                }
            }
        }

        private void UpdateRecipe(string path, string Model)
        {
            string[] recipe = IniConfigHelper.ReadIniData("RecipeParam", "Parameter", "", path).Split(',');

            Asil.ASIL1_check = recipe[31] == "True" ? true : false;
            Asil.ASIL2_check = recipe[30] == "True" ? true : false;
            Asil.ASIL3_check = recipe[29] == "True" ? true : false;
            Asil.ASIL4_check = recipe[28] == "True" ? true : false;
            Asil.ASIL5_check = recipe[27] == "True" ? true : false;
            Asil.ASIL6_check = recipe[26] == "True" ? true : false;
            Asil.ASIL7_check = recipe[25] == "True" ? true : false;
            Asil.ASIL8_check = recipe[24] == "True" ? true : false;
            Asil.frequency1_check = recipe[23] == "True" ? true : false;
            Asil.frequency2_check = recipe[22] == "True" ? true : false;

            Asil.ASIL1_Min = double.Parse(recipe[21]);
            Asil.ASIL1_Max = double.Parse(recipe[20]);

            Asil.ASIL2_Min = double.Parse(recipe[19]);
            Asil.ASIL2_Max = double.Parse(recipe[18]);

            Asil.ASIL3_Min = double.Parse(recipe[17]);
            Asil.ASIL3_Max = double.Parse(recipe[16]);

            Asil.ASIL4_Min = double.Parse(recipe[15]);
            Asil.ASIL4_Max = double.Parse(recipe[14]);

            Asil.ASIL5_Min = double.Parse(recipe[13]);
            Asil.ASIL5_Max = double.Parse(recipe[12]);

            Asil.ASIL6_Min = double.Parse(recipe[11]);
            Asil.ASIL6_Max = double.Parse(recipe[10]);

            Asil.ASIL7_Min = double.Parse(recipe[9]);
            Asil.ASIL7_Max = double.Parse(recipe[8]);

            Asil.ASIL8_Min = double.Parse(recipe[7]);
            Asil.ASIL8_Max = double.Parse(recipe[6]);

            Asil.frequency1_Min = double.Parse(recipe[5]);
            Asil.frequency1_Max = double.Parse(recipe[4]);

            Asil.frequency2_Min = double.Parse(recipe[3]);
            Asil.frequency2_Max = double.Parse(recipe[2]);

        }

        public void ReceiveJinceMsg(byte[] myReceByte)
        {
            try
            {
                Dictionary<string, MySession> obj = this.dic_ClientSocket;
                lock (obj)
                {
                    foreach (KeyValuePair<string, MySession> item in this.dic_ClientSocket.ToArray<KeyValuePair<string, MySession>>())
                    {
                        this.cMySession = item.Value;
                        bool flag2 = item.Key != null;
                        if (flag2)
                        {
                            myReceByte = this.cMySession.GetBuffer(0, this.cMySession.m_Buffer.Count);
                            bool flag3 = myReceByte.Length != 0;
                            if (flag3)
                            {
                                StringBuilder builder = new StringBuilder();
                                long received_count = 0L;
                                received_count += (long)myReceByte.Length;
                                builder.Clear();
                                this.myBy = myReceByte;
                                this.myByLenth = myReceByte.Length;
                                bool flag4 = myReceByte != null && myReceByte.Length != 0;
                                if (flag4)
                                {
                                    this.myStr = Encoding.ASCII.GetString(myReceByte);
                                    LogMethod.log("recive jince:" + this.myStr);
                                    ComAssistance.tc.JinceConmond = this.praseXmlData(this.myStr, "/Request/Command");
                                    string StreamNo = this.praseXmlData(this.myStr, "/Request/StreamNo");
                                    bool flag5 = ComAssistance.tc.JinceConmond == "SET_LOT_NO";
                                    if (flag5)
                                    {
                                        this.TestFlag = true;
                                        this.Setbutton2("N");
                                        ComAssistance.tc.JinceSN = this.praseXmlData(this.myStr, "/Request/Param1");
                                        string senddata = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Response><Result>OK</Result>" +
                                            "<Param1></Param1><Param2></Param2><Param3></Param3><Param4></Param4><Param5></Param5><Param6></Param6><Param7></Param7><Param8></Param8><Param9></Param9></Response>";
                                        this.tcpsend(senddata);
                                        this.SetText11(ComAssistance.tc.JinceSN);
                                    }
                                    bool flag6 = ComAssistance.tc.JinceConmond == "ASIL" && this.label19.Text.Length > 0;
                                    if (flag6)
                                    {
                                        Thread.Sleep(1000);
                                        this.AsilSend();
                                        this.Send = false;
                                        this.Setbutton2("Y");
                                    }
                                    else
                                    {
                                        bool flag7 = ComAssistance.tc.JinceConmond == "AG" && this.label19.Text.Length > 0;
                                        if (flag7)
                                        {
                                            Thread.Sleep(1000);
                                            this.AsilSend();
                                            this.Send = false;
                                            this.Setbutton2("Y");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                this.Setbutton2("Y");
            }
        }





        #endregion

        #region Random

        private static string GetRandomList(int count)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                int num;
                do
                {
                    num = rnd.Next(10000, 1000000);
                }
                while (list.Contains(num));
                list.Add(num);
            }
            string result = "";
            for (int j = 0; j < list.Count; j++)
            {
                result += list[j].ToString();
            }
            return result;
        }

        #endregion

        #region ASIL串口连接



        public void openport()
        {
            try
            {
                bool flag = !this.OP.SP.IsOpen;
                if (flag)
                {
                    this.Setlabel15("ASIL板连接中...");
                    LogMethod.log("ASIL板连接中...");
                    bool flag2 = this.OP.OpenPort(ComAssistance.tc.comId, ComAssistance.tc.baudRate, ComAssistance.tc.stopBit.ToString(), ComAssistance.tc.dataBits, ComAssistance.tc.parity.ToString());
                    if (flag2)
                    {
                        this.OP.SP.ReceivedBytesThreshold = 1;
                        this.OP.SP.DataReceived += this.SP_DataReceived;
                        this.SetpictureBox1("green");
                        this.Setlabel19("ASIL板已连接");
                        LogMethod.log("ASIL板已连接");
                        this.Setlabel15("ASIL板已连接");
                        Thread.Sleep(1000);
                        this.sendport("B");
                        this.com = ComAssistance.tc.comId;
                    }
                }
                else
                {
                    bool flag3 = this.OP.ClosePort();
                    if (flag3)
                    {
                        this.OP.SP.DataReceived -= this.SP_DataReceived;
                        this.SetpictureBox1("red");
                        this.Setlabel19("ASIL板未连接");
                        LogMethod.log("ASIL板未连接");
                        this.Setlabel15("ASIL板未连接");
                        Thread.Sleep(1000);
                        this.sendport("A");
                    }
                }
            }
            catch (Exception ex)
            {
                LogMethod.log(ex.Message);
            }
        }

        #endregion

        #region button按钮使能

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin = new FrmAdmin();
            if (frmAdmin.ShowDialog() == DialogResult.OK)
            {
                Setbutton2("Y");
            }
        }

        private void Setbutton2(string text)
        {
            bool invokeRequired = this.button2.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.Setbutton2);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                bool flag = text == "N";
                if (flag)
                {
                    this.button2.Enabled = false;
                }
                else
                {
                    bool flag2 = text == "Y";
                    if (flag2)
                    {
                        this.button2.Enabled = true;
                    }
                }
            }
        }

        #endregion

        #region TextBox返回数据设置


        /// <summary>
        /// 设置返回数据TextBox填充
        /// </summary>
        /// <param name="text"></param>
        private void appendText(string text)
        {
            try
            {
                bool flag = !this.Send;
                if (flag)
                {
                    string[] arr = text.Split(new char[]
                    {
                        this.split
                    });
                    bool flag2 = arr.Length != 8;
                    if (flag2)
                    {
                    }
                    bool flag3 = arr != null && 1 <= arr.Length;
                    if (flag3)
                    {
                        this.asil1 = arr[0];
                    }
                    else
                    {
                        this.asil1 = " ";
                    }
                    bool flag4 = arr != null && 2 <= arr.Length;
                    if (flag4)
                    {
                        this.asil2 = arr[1];
                    }
                    else
                    {
                        this.asil2 = " ";
                    }
                    bool flag5 = arr != null && 3 <= arr.Length;
                    if (flag5)
                    {
                        this.asil3 = arr[2];
                    }
                    else
                    {
                        this.asil3 = " ";
                    }
                    bool flag6 = arr != null && 4 <= arr.Length;
                    if (flag6)
                    {
                        this.asil4 = arr[3];
                    }
                    else
                    {
                        this.asil4 = " ";
                    }
                    bool flag7 = arr != null && 5 <= arr.Length;
                    if (flag7)
                    {
                        this.asil5 = arr[4];
                    }
                    else
                    {
                        this.asil5 = " ";
                    }
                    bool flag8 = arr != null && 6 <= arr.Length;
                    if (flag8)
                    {
                        this.asil6 = arr[5];
                    }
                    else
                    {
                        this.asil6 = " ";
                    }
                    bool flag9 = arr != null && 7 <= arr.Length;
                    if (flag9)
                    {
                        this.asil7 = arr[6];
                    }
                    else
                    {
                        this.asil7 = " ";
                    }
                    bool flag10 = arr != null && 8 <= arr.Length;
                    if (flag10)
                    {
                        this.asil8 = arr[7];
                    }
                    else
                    {
                        this.asil8 = " ";
                    }
                    bool flag111 = arr != null && 10 <= arr.Length;
                    if (flag111)
                    {
                        this.frequent1 = arr[8];
                    }
                    else
                    {
                        this.frequent1 = " ";
                    }
                    bool flag1111 = arr != null && 10 <= arr.Length;
                    if (flag1111)
                    {
                        this.frequent2 = arr[9];
                    }
                    else
                    {
                        this.frequent2 = " ";
                    }
                    string result = this.Judge(this.asil1, ComAssistance.tc.ASIL1_Min, ComAssistance.tc.ASIL1_Max, ComAssistance.tc.ASIL1_check);
                    string result2 = this.Judge(this.asil2, ComAssistance.tc.ASIL2_Min, ComAssistance.tc.ASIL2_Max, ComAssistance.tc.ASIL2_check);
                    string result3 = this.Judge(this.asil3, ComAssistance.tc.ASIL3_Min, ComAssistance.tc.ASIL3_Max, ComAssistance.tc.ASIL3_check);
                    string result4 = this.Judge(this.asil4, ComAssistance.tc.ASIL4_Min, ComAssistance.tc.ASIL4_Max, ComAssistance.tc.ASIL4_check);
                    string result5 = this.Judge(this.asil5, ComAssistance.tc.ASIL5_Min, ComAssistance.tc.ASIL5_Max, ComAssistance.tc.ASIL5_check);
                    string result6 = this.Judge(this.asil6, ComAssistance.tc.ASIL6_Min, ComAssistance.tc.ASIL6_Max, ComAssistance.tc.ASIL6_check);
                    string result7 = this.Judge(this.asil7, ComAssistance.tc.ASIL7_Min, ComAssistance.tc.ASIL7_Max, ComAssistance.tc.ASIL7_check);
                    string result8 = this.Judge(this.asil8, ComAssistance.tc.ASIL8_Min, ComAssistance.tc.ASIL8_Max, ComAssistance.tc.ASIL8_check);
                    string result9 = this.Judge(this.frequent1, ComAssistance.tc.frequency1_Min, ComAssistance.tc.frequency1_Max, ComAssistance.tc.frequency1_check);
                    string result10 = this.Judge(this.frequent2, ComAssistance.tc.frequency2_Min, ComAssistance.tc.frequency2_Max, ComAssistance.tc.frequency2_check);
                    string value = this.asil1;
                    bool flag11 = !this.TestFlag || !ComAssistance.tc.ASIL1_check;
                    if (flag11)
                    {
                        bool flag12 = !ComAssistance.tc.ASIL1_check;
                        if (flag12)
                        {
                            this.asil1 = "N";
                        }
                        result = " ";
                        value = " ";
                    }
                    bool invokeRequired = this.textBox1.InvokeRequired;
                    if (invokeRequired)
                    {
                        this.SetText1(value);
                    }
                    else
                    {
                        this.textBox1.Text = value;
                    }
                    bool invokeRequired2 = this.textBox12.InvokeRequired;
                    if (invokeRequired2)
                    {
                        this.SetText12(result);
                    }
                    else
                    {
                        this.textBox12.Text = result;
                    }
                    value = this.asil2;
                    bool flag13 = !this.TestFlag || !ComAssistance.tc.ASIL2_check;
                    if (flag13)
                    {
                        bool flag14 = !ComAssistance.tc.ASIL2_check;
                        if (flag14)
                        {
                            this.asil2 = "N";
                        }
                        result2 = " ";
                        value = " ";
                    }
                    bool invokeRequired3 = this.textBox2.InvokeRequired;
                    if (invokeRequired3)
                    {
                        this.SetText2(value);
                    }
                    else
                    {
                        this.textBox2.Text = value;
                    }
                    bool invokeRequired4 = this.textBox13.InvokeRequired;
                    if (invokeRequired4)
                    {
                        this.SetText13(result2);
                    }
                    else
                    {
                        this.textBox13.Text = result2;
                    }
                    value = this.asil3;
                    bool flag15 = !this.TestFlag || !ComAssistance.tc.ASIL3_check;
                    if (flag15)
                    {
                        bool flag16 = !ComAssistance.tc.ASIL3_check;
                        if (flag16)
                        {
                            this.asil3 = "N";
                        }
                        result3 = " ";
                        value = " ";
                    }
                    bool invokeRequired5 = this.textBox3.InvokeRequired;
                    if (invokeRequired5)
                    {
                        this.SetText3(value);
                    }
                    else
                    {
                        this.textBox3.Text = value;
                    }
                    bool invokeRequired6 = this.textBox14.InvokeRequired;
                    if (invokeRequired6)
                    {
                        this.SetText14(result3);
                    }
                    else
                    {
                        this.textBox14.Text = result3;
                    }
                    value = this.asil4;
                    bool flag17 = !this.TestFlag || !ComAssistance.tc.ASIL4_check;
                    if (flag17)
                    {
                        bool flag18 = !ComAssistance.tc.ASIL4_check;
                        if (flag18)
                        {
                            this.asil4 = "N";
                        }
                        result4 = "  ";
                        value = " ";
                    }
                    bool invokeRequired7 = this.textBox4.InvokeRequired;
                    if (invokeRequired7)
                    {
                        this.SetText4(value);
                    }
                    else
                    {
                        this.textBox4.Text = value;
                    }
                    bool invokeRequired8 = this.textBox15.InvokeRequired;
                    if (invokeRequired8)
                    {
                        this.SetText15(result4);
                    }
                    else
                    {
                        this.textBox15.Text = result4;
                    }
                    value = this.asil5;
                    bool flag19 = !this.TestFlag || !ComAssistance.tc.ASIL5_check;
                    if (flag19)
                    {
                        bool flag20 = !ComAssistance.tc.ASIL5_check;
                        if (flag20)
                        {
                            this.asil5 = "N";
                        }
                        result5 = " ";
                        value = " ";
                    }
                    bool invokeRequired9 = this.textBox5.InvokeRequired;
                    if (invokeRequired9)
                    {
                        this.SetText5(value);
                    }
                    else
                    {
                        this.textBox5.Text = value;
                    }
                    bool invokeRequired10 = this.textBox16.InvokeRequired;
                    if (invokeRequired10)
                    {
                        this.SetText16(result5);
                    }
                    else
                    {
                        this.textBox16.Text = result5;
                    }
                    value = this.asil6;
                    bool flag21 = !this.TestFlag || !ComAssistance.tc.ASIL6_check;
                    if (flag21)
                    {
                        bool flag22 = !ComAssistance.tc.ASIL6_check;
                        if (flag22)
                        {
                            this.asil6 = "N";
                        }
                        result6 = " ";
                        value = " ";
                    }
                    bool invokeRequired11 = this.textBox6.InvokeRequired;
                    if (invokeRequired11)
                    {
                        this.SetText6(value);
                    }
                    else
                    {
                        this.textBox6.Text = value;
                    }
                    bool invokeRequired12 = this.textBox17.InvokeRequired;
                    if (invokeRequired12)
                    {
                        this.SetText17(result6);
                    }
                    else
                    {
                        this.textBox17.Text = result6;
                    }
                    value = this.asil7;
                    bool flag23 = !this.TestFlag || !ComAssistance.tc.ASIL7_check;
                    if (flag23)
                    {
                        bool flag24 = !ComAssistance.tc.ASIL7_check;
                        if (flag24)
                        {
                            this.asil7 = "N";
                        }
                        result7 = " ";
                        value = " ";
                    }
                    bool invokeRequired13 = this.textBox7.InvokeRequired;
                    if (invokeRequired13)
                    {
                        this.SetText7(value);
                    }
                    else
                    {
                        this.textBox7.Text = value;
                    }

                    bool invokeRequired14 = this.textBox18.InvokeRequired;
                    if (invokeRequired14)
                    {
                        this.SetText18(result7);
                    }
                    else
                    {
                        this.textBox18.Text = result7;
                    }

                    value = this.asil8;
                    bool flag25 = !this.TestFlag || !ComAssistance.tc.ASIL8_check;
                    if (flag25)
                    {
                        bool flag26 = !ComAssistance.tc.ASIL8_check;
                        if (flag26)
                        {
                            this.asil8 = "N";
                        }
                        result8 = " ";
                        value = " ";
                    }
                    bool invokeRequired15 = this.textBox8.InvokeRequired;
                    if (invokeRequired15)
                    {
                        this.SetText8(value);
                        this.SetText19(result8);
                    }
                    else
                    {
                        this.textBox8.Text = value;
                    }

                    this.Invoke(new Action(() =>
                    {
                        value = this.frequent1;
                        bool f1 = !this.TestFlag || !Asil.frequency1_check;
                        if (f1)
                        {
                            bool f2 = !Asil.frequency1_check;
                            if (f2)
                            {
                                this.frequent1 = "N";
                            }
                            result9 = " ";
                            value = " ";
                        }

                        this.textBox9.Text = value;
                        this.textBox20.Text = result9;
                    }));


                    this.Invoke(new Action(() =>
                    {
                        value = this.frequent2;
                        bool f1 = !this.TestFlag || !Asil.frequency2_check;
                        if (f1)
                        {
                            bool f2 = !Asil.frequency2_check;
                            if (f2)
                            {
                                this.frequent2 = "N";
                            }
                            result10 = " ";
                            value = " ";
                        }

                        this.textBox10.Text = value;
                        this.textBox21.Text = result10;
                    }));


                }
            }
            catch (Exception ex)
            {
                LogMethod.log(ex.Message);
            }
        }

        /// <summary>
        /// 设置返回数据TextBox填充
        /// </summary>
        /// <param name="text"></param>
        private void appendText1(string text)
        {
            try
            {
                bool flag = !this.Send;
                if (flag)
                {
                    string[] arr = text.Split(new char[]
                    {
                        this.split
                    });
                    bool flag2 = arr.Length != 8;
                    if (flag2)
                    {
                    }
                    bool flag3 = arr != null && 1 <= arr.Length;
                    if (flag3)
                    {
                        this.asil1 = arr[0];
                    }
                    else
                    {
                        this.asil1 = " ";
                    }
                    bool flag4 = arr != null && 2 <= arr.Length;
                    if (flag4)
                    {
                        this.asil2 = arr[1];
                    }
                    else
                    {
                        this.asil2 = " ";
                    }
                    bool flag5 = arr != null && 3 <= arr.Length;
                    if (flag5)
                    {
                        this.asil3 = arr[2];
                    }
                    else
                    {
                        this.asil3 = " ";
                    }
                    bool flag6 = arr != null && 4 <= arr.Length;
                    if (flag6)
                    {
                        this.asil4 = arr[3];
                    }
                    else
                    {
                        this.asil4 = " ";
                    }
                    bool flag7 = arr != null && 5 <= arr.Length;
                    if (flag7)
                    {
                        this.asil5 = arr[4];
                    }
                    else
                    {
                        this.asil5 = " ";
                    }
                    bool flag8 = arr != null && 6 <= arr.Length;
                    if (flag8)
                    {
                        this.asil6 = arr[5];
                    }
                    else
                    {
                        this.asil6 = " ";
                    }
                    bool flag9 = arr != null && 7 <= arr.Length;
                    if (flag9)
                    {
                        this.asil7 = arr[6];
                    }
                    else
                    {
                        this.asil7 = " ";
                    }
                    bool flag10 = arr != null && 8 <= arr.Length;
                    if (flag10)
                    {
                        this.asil8 = arr[7];
                    }
                    else
                    {
                        this.asil8 = " ";
                    }
                    bool flag111 = arr != null && 10 <= arr.Length;
                    if (flag111)
                    {
                        this.frequent1 = arr[8];
                    }
                    else
                    {
                        this.frequent1 = " ";
                    }
                    bool flag1111 = arr != null && 10 <= arr.Length;
                    if (flag1111)
                    {
                        this.frequent2 = arr[9];
                    }
                    else
                    {
                        this.frequent2 = " ";
                    }
                    string result = this.Judge(this.asil1, Asil.ASIL1_Min, Asil.ASIL1_Max, Asil.ASIL1_check);
                    string result2 = this.Judge(this.asil2, Asil.ASIL2_Min, Asil.ASIL2_Max, Asil.ASIL2_check);
                    string result3 = this.Judge(this.asil3, Asil.ASIL3_Min, Asil.ASIL3_Max, Asil.ASIL3_check);
                    string result4 = this.Judge(this.asil4, Asil.ASIL4_Min, Asil.ASIL4_Max, Asil.ASIL4_check);
                    string result5 = this.Judge(this.asil5, Asil.ASIL5_Min, Asil.ASIL5_Max, Asil.ASIL5_check);
                    string result6 = this.Judge(this.asil6, Asil.ASIL6_Min, Asil.ASIL6_Max, Asil.ASIL6_check);
                    string result7 = this.Judge(this.asil7, Asil.ASIL7_Min, Asil.ASIL7_Max, Asil.ASIL7_check);
                    string result8 = this.Judge(this.asil8, Asil.ASIL8_Min, Asil.ASIL8_Max, Asil.ASIL8_check);
                    string result9 = this.Judge(this.frequent1, ComAssistance.tc.frequency1_Min, ComAssistance.tc.frequency1_Max, ComAssistance.tc.frequency1_check);
                    string result10 = this.Judge(this.frequent2, ComAssistance.tc.frequency2_Min, ComAssistance.tc.frequency2_Max, ComAssistance.tc.frequency2_check);

                    string value = this.asil1;
                    bool flag11 = !this.TestFlag || !Asil.ASIL1_check;
                    if (flag11)
                    {
                        bool flag12 = !Asil.ASIL1_check;
                        if (flag12)
                        {
                            this.asil1 = "N";
                        }
                        result = " ";
                        value = " ";
                    }
                    bool invokeRequired = this.textBox1.InvokeRequired;
                    if (invokeRequired)
                    {
                        this.SetText1(value);
                    }
                    else
                    {
                        this.textBox1.Text = value;
                    }
                    bool invokeRequired2 = this.textBox12.InvokeRequired;
                    if (invokeRequired2)
                    {
                        this.SetText12(result);
                    }
                    else
                    {
                        this.textBox12.Text = result;
                    }
                    value = this.asil2;
                    bool flag13 = !this.TestFlag || !Asil.ASIL2_check;
                    if (flag13)
                    {
                        bool flag14 = !Asil.ASIL2_check;
                        if (flag14)
                        {
                            this.asil2 = "N";
                        }
                        result2 = " ";
                        value = " ";
                    }
                    bool invokeRequired3 = this.textBox2.InvokeRequired;
                    if (invokeRequired3)
                    {
                        this.SetText2(value);
                    }
                    else
                    {
                        this.textBox2.Text = value;
                    }
                    bool invokeRequired4 = this.textBox13.InvokeRequired;
                    if (invokeRequired4)
                    {
                        this.SetText13(result2);
                    }
                    else
                    {
                        this.textBox13.Text = result2;
                    }
                    value = this.asil3;
                    bool flag15 = !this.TestFlag || !Asil.ASIL3_check;
                    if (flag15)
                    {
                        bool flag16 = !Asil.ASIL3_check;
                        if (flag16)
                        {
                            this.asil3 = "N";
                        }
                        result3 = " ";
                        value = " ";
                    }
                    bool invokeRequired5 = this.textBox3.InvokeRequired;
                    if (invokeRequired5)
                    {
                        this.SetText3(value);
                    }
                    else
                    {
                        this.textBox3.Text = value;
                    }
                    bool invokeRequired6 = this.textBox14.InvokeRequired;
                    if (invokeRequired6)
                    {
                        this.SetText14(result3);
                    }
                    else
                    {
                        this.textBox14.Text = result3;
                    }
                    value = this.asil4;
                    bool flag17 = !this.TestFlag || !Asil.ASIL4_check;
                    if (flag17)
                    {
                        bool flag18 = !Asil.ASIL4_check;
                        if (flag18)
                        {
                            this.asil4 = "N";
                        }
                        result4 = "  ";
                        value = " ";
                    }
                    bool invokeRequired7 = this.textBox4.InvokeRequired;
                    if (invokeRequired7)
                    {
                        this.SetText4(value);
                    }
                    else
                    {
                        this.textBox4.Text = value;
                    }
                    bool invokeRequired8 = this.textBox15.InvokeRequired;
                    if (invokeRequired8)
                    {
                        this.SetText15(result4);
                    }
                    else
                    {
                        this.textBox15.Text = result4;
                    }
                    value = this.asil5;
                    bool flag19 = !this.TestFlag || !Asil.ASIL5_check;
                    if (flag19)
                    {
                        bool flag20 = !Asil.ASIL5_check;
                        if (flag20)
                        {
                            this.asil5 = "N";
                        }
                        result5 = " ";
                        value = " ";
                    }
                    bool invokeRequired9 = this.textBox5.InvokeRequired;
                    if (invokeRequired9)
                    {
                        this.SetText5(value);
                    }
                    else
                    {
                        this.textBox5.Text = value;
                    }
                    bool invokeRequired10 = this.textBox16.InvokeRequired;
                    if (invokeRequired10)
                    {
                        this.SetText16(result5);
                    }
                    else
                    {
                        this.textBox16.Text = result5;
                    }
                    value = this.asil6;
                    bool flag21 = !this.TestFlag || !Asil.ASIL6_check;
                    if (flag21)
                    {
                        bool flag22 = !Asil.ASIL6_check;
                        if (flag22)
                        {
                            this.asil6 = "N";
                        }
                        result6 = " ";
                        value = " ";
                    }
                    bool invokeRequired11 = this.textBox6.InvokeRequired;
                    if (invokeRequired11)
                    {
                        this.SetText6(value);
                    }
                    else
                    {
                        this.textBox6.Text = value;
                    }
                    bool invokeRequired12 = this.textBox17.InvokeRequired;
                    if (invokeRequired12)
                    {
                        this.SetText17(result6);
                    }
                    else
                    {
                        this.textBox17.Text = result6;
                    }
                    value = this.asil7;
                    bool flag23 = !this.TestFlag || !Asil.ASIL7_check;
                    if (flag23)
                    {
                        bool flag24 = !Asil.ASIL7_check;
                        if (flag24)
                        {
                            this.asil7 = "N";
                        }
                        result7 = " ";
                        value = " ";
                    }
                    bool invokeRequired13 = this.textBox7.InvokeRequired;
                    if (invokeRequired13)
                    {
                        this.SetText7(value);
                    }
                    else
                    {
                        this.textBox7.Text = value;
                    }
                    bool invokeRequired14 = this.textBox18.InvokeRequired;
                    if (invokeRequired14)
                    {
                        this.SetText18(result7);
                    }
                    else
                    {
                        this.textBox18.Text = result7;
                    }
                    value = this.asil8;
                    bool flag25 = !this.TestFlag || !Asil.ASIL8_check;
                    if (flag25)
                    {
                        bool flag26 = !Asil.ASIL8_check;
                        if (flag26)
                        {
                            this.asil8 = "N";
                        }
                        result8 = " ";
                        value = " ";
                    }
                    bool invokeRequired15 = this.textBox8.InvokeRequired;
                    if (invokeRequired15)
                    {
                        this.SetText8(value);
                    }
                    else
                    {
                        this.textBox8.Text = value;
                    }
                    bool invokeRequired16 = this.textBox19.InvokeRequired;
                    if (invokeRequired16)
                    {
                        this.SetText19(result8);
                    }
                    else
                    {
                        this.textBox19.Text = result8;
                    }

                    this.Invoke(new Action(() =>
                    {
                        value = this.frequent1;
                        bool f1 = !this.TestFlag || !Asil.frequency1_check;
                        if (f1)
                        {
                            bool f2 = !Asil.frequency1_check;
                            if (f2)
                            {
                                this.frequent1 = "N";
                            }
                            result9 = " ";
                            value = " ";
                        }

                        this.textBox9.Text = value;
                        this.textBox20.Text = result9;
                    }));


                    this.Invoke(new Action(() =>
                    {
                        value = this.frequent2;
                        bool f1 = !this.TestFlag || !Asil.frequency2_check;
                        if (f1)
                        {
                            bool f2 = !Asil.frequency2_check;
                            if (f2)
                            {
                                this.frequent2 = "N";
                            }
                            result10 = " ";
                            value = " ";
                        }

                        this.textBox10.Text = value;
                        this.textBox21.Text = result10;
                    }));

                }
            }
            catch (Exception ex)
            {
                LogMethod.log(ex.Message);
            }
        }

        /// <summary>
        /// 判断返回数据是否在其设置的上下限
        /// </summary>
        /// <param name="value"></param>
        /// <param name="narmalMin"></param>
        /// <param name="narmalMax"></param>
        /// <param name="check"></param>
        /// <returns></returns>
        private string Judge(string value, double narmalMin, double narmalMax, bool check)
        {
            try
            {
                if (!check)
                {
                    return "OK";
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    return "NG";
                }
                double var = Convert.ToDouble(value);
                if (var >= narmalMin && var <= narmalMax)
                {
                    return "OK";
                }
                else
                {
                    return "NG";
                }
            }
            catch
            {
                return "NG";
            }
        }

        #endregion

        #region TextBox文本框跨线程显示与Label跨线程显示

        // 界面文字框显示
        private void Setlabel15(string text)
        {
            bool invokeRequired = this.label15.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.Setlabel15);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.label15.Text = text;
            }
        }


        private void SetOKTEXT(string text)
        {
            bool invokeRequired = this.OKTEXT.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetOKTEXT);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.OKTEXT.Text = text;
            }
        }


        private void SetNG_Text(string text)
        {
            bool invokeRequired = this.NG_Text.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetNG_Text);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.NG_Text.Text = text;
            }
        }


        private void Setlabel16(string text)
        {
            bool invokeRequired = this.label16.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.Setlabel16);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.label16.Text = text;
            }
        }

        private void Setlabel27(string text)
        {
            bool invokeRequired = this.label27.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.Setlabel27);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.label27.Text = text;
            }
        }

        private void SetPIS2_label(string text)
        {
            bool invokeRequired = this.PIS2_label.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetPIS2_label);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.PIS2_label.Text = text;
            }
        }


        private void Setlabel19(string text)
        {
            bool invokeRequired = this.label19.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.Setlabel19);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.label19.Text = text;
            }
        }


        private void Setlabel20(string text)
        {
            bool invokeRequired = this.label20.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.Setlabel20);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.label20.Text = text;
            }
        }


        private void SetText1(string text)
        {
            bool invokeRequired = this.textBox1.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText1);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }


        private void SetText12(string text)
        {
            bool invokeRequired = this.textBox12.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText12);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox12.Text = text;
            }
        }


        private void SetText2(string text)
        {
            bool invokeRequired = this.textBox2.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText2);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox2.Text = text;
            }
        }


        private void SetText13(string text)
        {
            bool invokeRequired = this.textBox13.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText13);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox13.Text = text;
            }
        }


        private void SetText3(string text)
        {
            bool invokeRequired = this.textBox3.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText3);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox3.Text = text;
            }
        }


        private void SetText14(string text)
        {
            bool invokeRequired = this.textBox14.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText14);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox14.Text = text;
            }
        }


        private void SetText4(string text)
        {
            bool invokeRequired = this.textBox4.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText4);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox4.Text = text;
            }
        }


        private void SetText15(string text)
        {
            bool invokeRequired = this.textBox15.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText15);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox15.Text = text;
            }
        }


        private void SetText5(string text)
        {
            bool invokeRequired = this.textBox5.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText5);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox5.Text = text;
            }
        }


        private void SetText16(string text)
        {
            bool invokeRequired = this.textBox15.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText16);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox16.Text = text;
            }
        }


        private void SetText6(string text)
        {
            bool invokeRequired = this.textBox5.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText6);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox6.Text = text;
            }
        }


        private void SetText17(string text)
        {
            bool invokeRequired = this.textBox17.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText17);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox17.Text = text;
            }
        }


        private void SetText7(string text)
        {
            bool invokeRequired = this.textBox5.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText7);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox7.Text = text;
            }
        }


        private void SetText18(string text)
        {
            bool invokeRequired = this.textBox18.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText18);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox18.Text = text;
            }
        }


        private void SetText8(string text)
        {
            bool invokeRequired = this.textBox5.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText8);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox8.Text = text;
            }
        }


        private void SetText19(string text)
        {
            bool invokeRequired = this.textBox19.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText19);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox19.Text = text;
            }
        }


        private void SetText11(string text)
        {
            bool invokeRequired = this.textBox5.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetText11);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                this.textBox11.Text = text;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin = new FrmAdmin();
            if (frmAdmin.ShowDialog() == DialogResult.OK)
            {
                SettingForm setting = new SettingForm();
                setting.ShowDialog();
                SetLimit();
                SetPositionPanelID();
            }
        }
        public void SetLimit()
        {
            this.label24.Text = ComAssistance.tc.CurrentRecipeName;

            if (ComAssistance.tc.ASIL1_check)
            {
                this.ASIL1MIN.Text = ComAssistance.tc.ASIL1_Min.ToString();
                this.ASIL1MAX.Text = ComAssistance.tc.ASIL1_Max.ToString();
            }
            else
            {
                this.ASIL1MIN.Text = "null";
                this.ASIL1MAX.Text = "null";
            }
            if (ComAssistance.tc.ASIL2_check)
            {
                this.ASIL2MIN.Text = ComAssistance.tc.ASIL2_Min.ToString();
                this.ASIL2MAX.Text = ComAssistance.tc.ASIL2_Max.ToString();
            }
            else
            {
                this.ASIL2MIN.Text = "null";
                this.ASIL2MAX.Text = "null";
            }
            if (ComAssistance.tc.ASIL3_check)
            {
                this.ASIL3MIN.Text = ComAssistance.tc.ASIL3_Min.ToString();
                this.ASIL3MAX.Text = ComAssistance.tc.ASIL3_Max.ToString();
            }
            else
            {
                this.ASIL3MIN.Text = "null";
                this.ASIL3MAX.Text = "null";
            }
            if (ComAssistance.tc.ASIL4_check)
            {
                this.ASIL4MIN.Text = ComAssistance.tc.ASIL4_Min.ToString();
                this.ASIL4MAX.Text = ComAssistance.tc.ASIL4_Max.ToString();
            }
            else
            {
                this.ASIL4MIN.Text = "null";
                this.ASIL4MAX.Text = "null";
            }
            if (ComAssistance.tc.ASIL5_check)
            {
                this.ASIL5MIN.Text = ComAssistance.tc.ASIL5_Min.ToString();
                this.ASIL5MAX.Text = ComAssistance.tc.ASIL5_Max.ToString();
            }
            else
            {
                this.ASIL5MIN.Text = "null";
                this.ASIL5MAX.Text = "null";
            }
            if (ComAssistance.tc.ASIL6_check)
            {
                this.ASIL6MIN.Text = ComAssistance.tc.ASIL6_Min.ToString();
                this.ASIL6MAX.Text = ComAssistance.tc.ASIL6_Max.ToString();
            }
            else
            {
                this.ASIL6MIN.Text = "null";
                this.ASIL6MAX.Text = "null";
            }
            if (ComAssistance.tc.ASIL7_check)
            {
                this.ASIL7MIN.Text = ComAssistance.tc.ASIL7_Min.ToString();
                this.ASIL7MAX.Text = ComAssistance.tc.ASIL7_Max.ToString();
            }
            else
            {
                this.ASIL7MIN.Text = "null";
                this.ASIL7MAX.Text = "null";
            }
            if (ComAssistance.tc.ASIL8_check)
            {
                this.ASIL8MIN.Text = ComAssistance.tc.ASIL8_Min.ToString();
                this.ASIL8MAX.Text = ComAssistance.tc.ASIL8_Max.ToString();
            }
            else
            {
                this.ASIL8MIN.Text = "null";
                this.ASIL8MAX.Text = "null";
            }
            if (ComAssistance.tc.frequency1_check)
            {
                this.Frequency1MIN.Text = ComAssistance.tc.frequency1_Min.ToString();
                this.Frequency1MAX.Text = ComAssistance.tc.frequency1_Max.ToString();
            }
            else
            {
                this.Frequency1MIN.Text = "null";
                this.Frequency1MAX.Text = "null";
            }
            if (ComAssistance.tc.frequency2_check)
            {
                this.Frequency2MIN.Text = ComAssistance.tc.frequency2_Min.ToString();
                this.Frequency2MAX.Text = ComAssistance.tc.frequency2_Max.ToString();
            }
            else
            {
                this.Frequency2MIN.Text = "null";
                this.Frequency2MAX.Text = "null";
            }
        }
        public string DayShift { get; set; }

        public string NightShift { get; set; }

        public bool DayShiftSpotCheck { get; set; }

        public bool NightShiftSpotCheck { get; set; }

        public string LoginTime { get; set; }

        public int NGcount { get; set; } = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = !string.IsNullOrEmpty(this.textBox11.Text) && this.textBox11.Text.Length == 11;
                if (!IsSpotCheck)
                {
                    this.Setlabel27("量测失败,请重新点检");
                    this.pictureBox4.Image = Resources.red;
                    MessageBox.Show("未进行点检,请进行点检!");
                    return;
                }
                if (!JudgeCheckTime())
                {
                    return;
                }
                if (flag)
                {
                    this.button2.Enabled = false;
                    this.Manual_Auto = true;
                    this.TestFlag = true;
                    ComAssistance.tc.JinceSN = this.textBox11.Text;
                }
                else
                {
                    MessageBox.Show("请检查输入的Serial No:!");
                }
            }
            catch (Exception ex)
            {
                this.Setlabel15(ex.Message);
                this.Manual_Auto = false;
                this.TestFlag = false;
                this.button2.Enabled = true;
            }
        }

        #endregion

        #region 连接状态图像显示

        public void JConnect()
        {
            bool flag = this.label20.Text == "测试机未启动侦听";
            if (flag)
            {
                this.Setlabel20("测试机启动侦听");
                this.pictureBox2.Image = Resources.green;
                this.OpenServer(ComAssistance.tc.jinceIp, ComAssistance.tc.jincePort);
                LogMethod.log("测试机启动侦听");
            }
            else
            {
                this.Setlabel20("测试机未启动侦听");
                this.pictureBox2.Image = Resources.red;
                this.CloseServer();
                LogMethod.log("测试机未启动侦听");
            }
        }

        /// <summary>
        /// 连接状态图片
        /// </summary>
        /// <param name="text"></param>
        private void SetpictureBox1(string text)
        {
            bool invokeRequired = this.pictureBox1.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetpictureBox1);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                bool flag = text == "red";
                if (flag)
                {
                    this.pictureBox1.Image = Resources.red;
                }
                else
                {
                    this.pictureBox1.Image = Resources.green;
                }
            }
        }

        private void SetpictureBox3(string text)
        {
            bool invokeRequired = this.pictureBox3.InvokeRequired;
            if (invokeRequired)
            {
                ComAssistance.SetTextCallBack stcb = new ComAssistance.SetTextCallBack(this.SetpictureBox1);
                base.Invoke(stcb, new object[]
                {
                    text
                });
            }
            else
            {
                bool flag = text == "red";
                if (flag)
                {

                    this.pictureBox3.Image = Resources.red;
                }
                else
                {
                    this.pictureBox3.Image = Resources.green;
                }
            }
        }


        #endregion

        #region XML修改config底下的xml文件信息

        public QueueLock queueLock { get; set; } = new QueueLock();

        // 修改节点
        public void ModifyNode(string path)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(path);
                XmlNodeList nodeList = xmlDocument.SelectSingleNode("trx").ChildNodes;
                foreach (object obj in nodeList)
                {
                    XmlNode xn = (XmlNode)obj;
                    XmlElement xe = (XmlElement)xn;
                    bool flag = xe.Name == "message_id";
                    if (flag)
                    {
                        xe.InnerText = "ictest_result_report";
                    }
                    bool flag2 = xe.Name == "type_id";
                    if (flag2)
                    {
                        xe.InnerText = this.asilData.type_id;
                    }
                    bool flag3 = xe.Name == "log_id";
                    if (flag3)
                    {
                        xe.InnerText = this.asilData.log_id;
                    }
                    bool flag4 = xe.Name == "unique_id";
                    if (flag4)
                    {
                        xe.InnerText = ComAssistance.tc.unique_id;
                        xe.InnerText = this.asilData.unique_id;
                    }
                    bool flag5 = xe.Name == "station_id";
                    if (flag5)
                    {
                        xe.InnerText = ComAssistance.tc.Station_ID;
                    }
                    bool flag6 = xe.Name == "test_result";
                    if (flag6)
                    {
                        xe.InnerText = ComAssistance.tc.test_result;
                    }
                    bool flag7 = xe.Name == "test_time";
                    if (flag7)
                    {
                        xe.InnerText = this.asilData.test_time;
                    }
                    bool flag8 = xe.Name == "measure_type";
                    if (flag8)
                    {
                        xe.InnerText = "ASIL_FBIO";
                    }
                    bool flag9 = xe.Name == "fw_version";
                    if (flag9)
                    {
                        xe.InnerText = ComAssistance.tc.fw_version;
                    }
                    bool flag10 = xe.Name == "model_no";
                    if (flag10)
                    {
                        xe.InnerText = ComAssistance.tc.model_no;
                    }
                    bool flag11 = xe.Name == "trx_name";
                    if (flag11)
                    {
                        xe.InnerText = ComAssistance.tc.type1;
                    }
                    bool flag12 = xe.Name == "lot_no";
                    if (flag12)
                    {
                        xe.InnerText = this.asilData.unique_id;
                    }
                    bool flag13 = xe.Name == "lm_user";
                    if (flag13)
                    {
                        xe.InnerText = computerName;
                    }
                    bool flag14 = xe.Name == "lm_time";
                    if (flag14)
                    {
                        xe.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    }
                    bool flag15 = xe.Name == "spc_control_result";
                    if (flag15)
                    {
                        XmlNodeList nodelist = xe.ChildNodes;
                        foreach (object obj2 in nodelist)
                        {
                            XmlNode xn2 = (XmlNode)obj2;
                            XmlElement xe2 = (XmlElement)xn2;
                            bool flag16 = xe2.Name == "part_no";
                            if (flag16)
                            {
                                xe2.InnerText = ComAssistance.tc.part_no;
                            }
                            bool flag17 = xe2.Name == "feedback_io_01";
                            if (flag17)
                            {
                                xe2.InnerText = this.asilData.feedback_io_01;
                            }
                            bool flag18 = xe2.Name == "feedback_io_02";
                            if (flag18)
                            {
                                xe2.InnerText = this.asilData.feedback_io_02;
                            }
                            bool flag19 = xe2.Name == "feedback_io_03";
                            if (flag19)
                            {
                                xe2.InnerText = this.asilData.feedback_io_03;
                            }
                            bool flag20 = xe2.Name == "feedback_io_04";
                            if (flag20)
                            {
                                xe2.InnerText = this.asilData.feedback_io_04;
                            }
                            bool flag21 = xe2.Name == "feedback_io_05";
                            if (flag21)
                            {
                                xe2.InnerText = this.asilData.feedback_io_05;
                            }
                            bool flag22 = xe2.Name == "feedback_io_06";
                            if (flag22)
                            {
                                xe2.InnerText = this.asilData.feedback_io_06;
                            }
                            bool flag23 = xe2.Name == "feedback_io_07";
                            if (flag23)
                            {
                                xe2.InnerText = this.asilData.feedback_io_07;
                            }
                            bool flag24 = xe2.Name == "feedback_io_08";
                            if (flag24)
                            {
                                xe2.InnerText = this.asilData.feedback_io_08;
                            }
                            bool flag25 = xe2.Name == "status";
                            if (flag25)
                            {
                                xe2.InnerText = this.testresult;
                            }
                        }
                    }
                    bool flag26 = xe.Name == "iary_infos";
                    if (flag26)
                    {
                        XmlNodeList nodelist2 = xe.ChildNodes;
                        foreach (object obj3 in nodelist2)
                        {
                            XmlNode item = (XmlNode)obj3;
                            bool flag27 = item.Name == "iary";
                            bool state = false;
                            if (flag27)
                            {
                                XmlNodeList xnl = item.ChildNodes;
                                foreach (object obj4 in xnl)
                                {
                                    XmlNode xn3 = (XmlNode)obj4;
                                    XmlElement xe3 = (XmlElement)xn3;
                                    bool flag28 = xe3.Name == "ccd_type";
                                    if (flag28)
                                    {
                                        xe3.InnerText = ComAssistance.tc.CurrentType;
                                    }
                                    bool flag29 = xe3.Name == "max_lumi";
                                    if (flag29)
                                    {
                                        xe3.InnerText = ComAssistance.tc.max_lumi;
                                    }
                                    bool flag30 = xe3.Name == "unifomity";
                                    if (flag30)
                                    {
                                        xe3.InnerText = ComAssistance.tc.unifomity;
                                    }
                                    bool flag31 = xe3.Name == "jig_id";
                                    if (flag31)
                                    {
                                        xe3.InnerText = ComAssistance.tc.Operator;
                                    }
                                    bool flag32 = xe3.Name == "eqp_id";
                                    if (flag32)
                                    {
                                        xe3.InnerText = ComAssistance.tc.EQP_ID;
                                    }
                                    bool flag33 = xe3.Name == "judge";
                                    if (flag33)
                                    {
                                        xe3.InnerText = this.testresult;
                                    }
                                    bool flag34 = xe3.Name == "lm_user";
                                    if (flag34)
                                    {
                                        xe3.InnerText = this.computerName;
                                    }

                                    bool flag35 = xe3.Name == "panel_position";
                                    if (flag35 && !ComAssistance.tc.PanelPositionState && !state)
                                    {
                                        item.RemoveChild(xe3);
                                        state = true;
                                    }

                                    if (flag35 && ComAssistance.tc.PanelPositionState && !state)
                                    {
                                        xe3.InnerText = ComAssistance.tc.PanelPosition;
                                        state = true;
                                    }

                                    if (ComAssistance.tc.PanelPositionState && !state && xnl.Count == 6)
                                    {
                                        XmlNode rootNode = xmlDocument.CreateElement("panel_position");
                                        rootNode.InnerText = ComAssistance.tc.PanelPosition;
                                        item.AppendChild(rootNode);
                                        state = true;
                                    }
                                }
                            }
                        }
                    }
                }
                xmlDocument.Save(path);
            }
            catch (Exception ex)
            {
                LogMethod.log(ex.Message);
            }
            finally
            {
            }
        }
        /// <summary>
        /// 计算机名称
        /// </summary>
        public string computerName { get; set; } = Environment.MachineName;

        /// <summary>
        /// XML转换
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public string praseXmlData(string xmlStr, string node)
        {
            string nodevalue = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlStr);
                XmlNodeList rowNoteList = doc.SelectNodes(node);
                bool flag = rowNoteList != null;
                if (flag)
                {
                    foreach (object obj in rowNoteList)
                    {
                        XmlNode rowNode = (XmlNode)obj;
                        XmlNodeList fieldNodeList = rowNode.ChildNodes;
                        foreach (object obj2 in fieldNodeList)
                        {
                            XmlNode courseNode = (XmlNode)obj2;
                            nodevalue = courseNode.Value;
                        }
                    }
                }
            }
            catch
            {
            }
            return nodevalue;
        }


        #endregion

        #region MCMQ

        private QueueLock McmqQueueLock = new QueueLock();

        private int handle = 0;

        private StringBuilder replyQueueHandle = new StringBuilder(100);

        private StringBuilder QueueHandles = new StringBuilder(100);



        // Token: 0x0600002E RID: 46 RVA: 0x000050C8 File Offset: 0x000032C8
        private async void ConectCMMQ(string sendQueue, string replyQueue, string IP, int port, byte[] message1, byte[] message2)
        {
            await Task.Run(() =>
            {
                McmqQueueLock.Enter();
                string returnCode = "";
                string result;
                try
                {
                    Console.WriteLine("start to Connect MCMQ");
                    LogMethod.log("start to Connect MCMQ");
                    //returnCode = this.mcmq.connectMCMQ(IP, port, false);
                    //var mcmq = ServiceLocator.GetService<IMcmq>();
                    returnCode = Mcmq.connectMCMQ(ref handle, IP, port.ToString()).ToString();
                    bool flag = !returnCode.Equals("0");
                    if (flag)
                    {
                        string str = "Connect MCMQ Error Code=" + returnCode;
                        LogMethod.log(str);
                        this.Setlabel15(str);
                        this.sendport("B");
                        result = returnCode;
                    }
                    else
                    {
                        string str = "Connect MCMQ Success, returnCode =" + returnCode;
                        LogMethod.log(str);
                        this.Setlabel16("PIS2已连接");
                        this.SetpictureBox1("green");
                        this.Setlabel15(str);
                        LogMethod.log(str);
                        returnCode = Mcmq.openQueue(handle, replyQueue, 1000000, 5000, 500000, 2500, 0, 0, replyQueue, replyQueueHandle, 0).ToString();
                        LogMethod.log("OpenreplyQueue " + replyQueue + "returnCode=" + returnCode);
                        returnCode = Mcmq.openQueue(handle, sendQueue, 1000000, 5000, 500000, 2500, 0, 0, sendQueue, QueueHandles, 0).ToString();
                        LogMethod.log("OpensendQueue " + sendQueue + "returnCode=" + returnCode);
                        //this.mcmq.cleanQueue(this.mcmq.strQueueHandle);
                        this.panel1.BackColor = Color.Green;
                        this.SetPIS2_label("向PIS2数据传输中");
                        string MessageA = Encoding.UTF8.GetString(message1);
                        byte[] asilA = Encoding.UTF8.GetBytes(MessageA);
                        string MessageB = null;
                        byte[] asilB = null;

                        if (message2 != null)
                        {
                            MessageB = Encoding.UTF8.GetString(message2);
                            asilB = Encoding.UTF8.GetBytes(MessageB);
                            this.SendMcmq(ComAssistance.tc.SendQueue_ictest, replyQueue, MessageB, asilB);
                        }

                        this.SendMcmq(ComAssistance.tc.SendQueue, replyQueue, MessageA, asilA);
                        Mcmq.disconnect(ref handle);
                        this.Setlabel16("PIS2已断开");
                        LogMethod.log("MCMQ disconnect");
                        this.pictureBox3.Image = Resources.red;
                        this.panel1.BackColor = Color.MidnightBlue;
                        this.SetPIS2_label("");
                        this.sendport("B");
                        result = returnCode;
                    }
                }
                catch (Exception e)
                {
                    this.Setlabel16("PIS2已断开");
                    LogMethod.log(e.Message);
                    this.pictureBox3.Image = Resources.red;
                    this.panel1.BackColor = Color.MidnightBlue;
                    this.SetPIS2_label("");
                    this.sendport("B");
                    result = returnCode;
                }
                finally
                {
                    McmqQueueLock.Leave();
                }
            });
        }


        private byte[] replyData = new byte[1024 * 10]; // 用于接收的缓冲区

        // Token: 0x0600002F RID: 47 RVA: 0x00005350 File Offset: 0x00003550
        private void SendMcmq(string sendQueue, string replyQueue, string message, byte[] asil)
        {

            // string returnCode = this.mcmq.putQueue(sendQueue, asil, replyQueue, "CorrelationId", cMcmqCommApi.McmqMsgEncrypted.NONE);
            StringBuilder timeStamp = new StringBuilder(16);
            int dataLength = 0;
            string correlationId = Guid.NewGuid().ToString("N").ToUpper();
            StringBuilder correlationId1 = new StringBuilder(32);
            //var mcmq = ServiceLocator.GetService<IMcmq>();
            string returnCode = Mcmq.putQueue(handle, sendQueue, replyQueue, correlationId, asil, asil.Length).ToString();
            LogMethod.log(string.Concat(new string[]
            {
                "Send MCMQ sendQueue=",
                sendQueue,
                " replyQueue =",
                replyQueue,
                "returnCode=",
                returnCode
            }));
            LogMethod.log("Send MCMQ:" + message);
            this.Setlabel15("Send MCMQ sendQueue=" + sendQueue);
            returnCode = Mcmq.getQueue(handle, replyQueueHandle.ToString(), replyQueue, timeStamp, correlationId1, 2500, replyData.Length, replyData, ref dataLength).ToString();
            string returnMessage = Encoding.UTF8.GetString(replyData, 0, dataLength);
            LogMethod.log("Recive MCMQ returnCode:" + returnCode);
            this.Setlabel15("Recive MCMQ returnCode:" + returnCode);
            LogMethod.log("Recive MCMQ returnMessage:" + returnMessage);

        }

        #endregion

        #region 串口通信返回数据触发事件


        //     设备会循环发送信息,所以会一直接收,卡死的问题可能在这边
        /// <summary>
        /// 串口通信返回数据触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SP_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(200);
                byte[] dataTemp = new byte[this.OP.SP.BytesToRead];
                this.OP.SP.Read(dataTemp, 0, dataTemp.Length);
                string str = Encoding.ASCII.GetString(dataTemp);
                string i = string.Empty;
                bool flag1 = !string.IsNullOrEmpty(str);
                if (flag1)
                {
                    bool flag2 = str.StartsWith("T");
                    if (flag2)
                    {
                        foreach (char c in str)
                        {
                            bool flag3 = c.ToString() == "E";
                            if (flag3)
                            {
                                break;
                            }
                            bool flag4 = c.ToString() != "T";
                            if (flag4)
                            {
                                i += c.ToString();
                            }
                        }
                        if (this.TestFlag)
                        {
                            if (SpotCheck)
                            {
                                this.appendText1(i);
                                asil();
                            }
                            else
                            {
                                this.appendText(i);
                            }

                            bool manual_Auto = this.Manual_Auto;
                            if (manual_Auto)
                            {
                                this.AsilSend();
                            }

                        }
                        else
                        {
                            this.appendText(i);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 发送串口信息

        /// <summary>
        /// 往串口发送信息
        /// </summary>
        /// <param name="message"></param>
        public void sendport(string message)
        {
            try
            {
                bool flag = string.IsNullOrWhiteSpace(this.asil1) && string.IsNullOrWhiteSpace(this.asil2) && string.IsNullOrWhiteSpace(this.asil3) &&
                    string.IsNullOrWhiteSpace(this.asil4) && string.IsNullOrWhiteSpace(this.asil5) && string.IsNullOrWhiteSpace(this.asil6) && string.IsNullOrWhiteSpace(this.asil7) && string.IsNullOrWhiteSpace(this.asil8);
                if (!flag)
                {
                    this.OP.SP.WriteLine(message);
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 读取XML文件并转换成Byte[]数组


        /// <summary>
        /// 读取XML文件并转换成Byte[]数组
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] FileTOByte(string path)
        {
            string mess = this.ReadFile(path);
            return Encoding.UTF8.GetBytes(mess);
        }

        /// <summary>
        ///  读取XML文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string ReadFile(string fileName)
        {
            string varr = "";
            string[] fileStrArray = File.ReadAllLines(fileName);
            foreach (string item in fileStrArray)
            {
                bool flag = string.IsNullOrEmpty(item);
                if (!flag)
                {
                    string itemNew = item.TrimStart(new char[0]);
                    itemNew = itemNew.TrimEnd(new char[0]);
                    char[] arrayList = itemNew.ToCharArray();
                    foreach (char itema in arrayList)
                    {
                        varr += itema.ToString();
                    }
                }
            }
            return varr;
        }

        #endregion

        #region Socket连接部分


        public bool OpenServer(string ip, int port)
        {
            bool result;
            try
            {
                ServicePointManager.Expect100Continue = false;
                this.Flag_Listen = true;
                this.ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //开启TcpServer

                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                try
                {
                    this.ServerSocket.Bind(endPoint);

                }
                catch
                {
                    return false;
                }
                this.ServerSocket.Listen(100);
                //new Thread(new ThreadStart(this.ListenConnecting))
                //{
                //    IsBackground = true
                //}.Start();
                Task.Run(() =>
                {
                    ListenConnecting();
                });
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }


        public void CloseServer()
        {
            Dictionary<string, MySession> obj = this.dic_ClientSocket;
            lock (obj)
            {
                foreach (KeyValuePair<string, MySession> item in this.dic_ClientSocket)
                {
                    item.Value.Close();
                }
                this.dic_ClientSocket.Clear();
            }
            Dictionary<string, Thread> obj2 = this.dic_ClientThread;
            lock (obj2)
            {
                foreach (KeyValuePair<string, Thread> item2 in this.dic_ClientThread)
                {
                    item2.Value.Abort();
                }
                this.dic_ClientThread.Clear();
            }
            this.Flag_Listen = false;
            bool flag3 = this.ServerSocket != null;
            if (flag3)
            {
                this.ServerSocket.Close();
            }
        }

        /// <summary>
        /// 测试机上抛Socket绑定
        /// </summary>
        private void ListenConnecting()
        {
            while (this.Flag_Listen)
            {
                try
                {

                    Socket sokConnection = this.ServerSocket.Accept();
                    string str_EndPoint = sokConnection.RemoteEndPoint.ToString();
                    MySession myTcpClient = new MySession
                    {
                        TcpSocket = sokConnection
                    };
                    Thread th_ReceiveData = new Thread(new ParameterizedThreadStart(this.ReceiveData));
                    th_ReceiveData.IsBackground = true;
                    th_ReceiveData.Start(myTcpClient);
                    this.dic_ClientThread.Add(str_EndPoint, th_ReceiveData);
                    this.dic_ClientSocket.Add(str_EndPoint, myTcpClient);
                }
                catch
                {
                }
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sokConnectionparn"></param>
        private void ReceiveData(object sokConnectionparn)
        {
            MySession tcpClient = sokConnectionparn as MySession;
            Socket socketClient = tcpClient.TcpSocket;
            bool Flag_Receive = true;
            while (Flag_Receive)
            {
                try
                {
                    byte[] arrMsgRec = new byte[1024];
                    int length = -1;
                    try
                    {
                        length = socketClient.Receive(arrMsgRec);
                    }
                    catch
                    {
                        Flag_Receive = false;
                        string keystr = socketClient.RemoteEndPoint.ToString();
                        this.dic_ClientSocket.Remove(keystr);
                        this.dic_ClientThread[keystr].Abort();
                        this.dic_ClientThread.Remove(keystr);
                        tcpClient = null;
                        socketClient = null;
                        break;
                    }
                    byte[] buf = new byte[length];
                    Array.Copy(arrMsgRec, buf, length);
                    List<byte> buffer = tcpClient.m_Buffer;
                    lock (buffer)
                    {
                        tcpClient.AddQueue(buf);
                    }
                }
                catch
                {
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Socket连接部分
        /// </summary>
        /// <param name="_endPoint"></param>
        /// <param name="_buf"></param>
        /// <returns></returns>
        public bool SendData(string _endPoint, byte[] _buf)
        {
            MySession myT = new MySession();
            bool flag = this.dic_ClientSocket.TryGetValue(_endPoint, out myT);
            bool result;
            if (flag)
            {
                myT.Send(_buf);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        private void tcpsend(string senddata)
        {
            try
            {
                int m_length = senddata.Length;
                byte[] data = new byte[m_length];
                data = Encoding.UTF8.GetBytes(senddata);
                Dictionary<string, MySession> obj = this.dic_ClientSocket;
                lock (obj)
                {
                    foreach (KeyValuePair<string, MySession> item in this.dic_ClientSocket)
                    {
                        this.SendData(item.Key.ToString(), data);
                    }
                    LogMethod.log("send to jince:" + senddata);
                }
            }
            catch (Exception ex)
            {
                LogMethod.log("send to jince:" + ex.Message);
            }
        }


        #endregion

        #region 无用部分

        public static Encoding GetType(FileStream fs)
        {
            byte[] array = new byte[]
            {
                byte.MaxValue,
                254,
                65
            };
            byte[] array2 = new byte[3];
            array2[0] = 254;
            array2[1] = byte.MaxValue;
            byte[] array3 = new byte[]
            {
                239,
                187,
                191
            };
            Encoding reVal = Encoding.Default;
            BinaryReader r = new BinaryReader(fs, Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);
            bool flag = ComAssistance.IsUTF8Bytes(ss) || (ss[0] == 239 && ss[1] == 187 && ss[2] == 191);
            if (flag)
            {
                reVal = Encoding.UTF8;
            }
            else
            {
                bool flag2 = ss[0] == 254 && ss[1] == byte.MaxValue && ss[2] == 0;
                if (flag2)
                {
                    reVal = Encoding.BigEndianUnicode;
                }
                else
                {
                    bool flag3 = ss[0] == byte.MaxValue && ss[1] == 254 && ss[2] == 65;
                    if (flag3)
                    {
                        reVal = Encoding.Unicode;
                    }
                }
            }
            r.Close();
            return reVal;
        }


        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;
            byte bytes;
            foreach (byte curByte in data)
            {
                bool flag = charByteCounter == 1;
                if (flag)
                {
                    bool flag2 = curByte >= 128;

                    if (flag2)
                    {
                        while (((bytes = (byte)(curByte << 1)) & 128) > 0)
                        {
                            charByteCounter++;
                        }
                        bool flag3 = charByteCounter == 1 || charByteCounter > 6;
                        if (flag3)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    bool flag4 = (curByte & 192) != 128;
                    if (flag4)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            bool flag5 = charByteCounter > 1;
            if (flag5)
            {
                throw new Exception("非预期的byte格式");
            }
            return true;
        }

        #endregion

        #region Property

        //public event ComAssistance.settext settextevent;

        private char split { get; set; } = 'A';

        /// <summary>
        /// 端口连接与关闭
        /// </summary>
        private OpenSP OP { get; set; } = new OpenSP();


        public bool TestFlag { get; set; } = false;


        public bool Send { get; set; } = false;


        public static TcClass tc { get; set; } = new TcClass();


        private string sn_no { get; set; } = "";


        public byte[] myBy { get; set; }


        public int myByLenth { get; set; } = 0;


        public string myStr { get; set; }


        public bool myThreadStop { get; set; } = true;


        public int send_count { get; set; } = 0;


        public int recv_count { get; set; } = 0;


        private MySession cMySession = new MySession();


        public bool Manual_Auto { get; set; } = false;


        private string testresult { get; set; } = "";


        private string asil1 { get; set; } = " ";


        private string asil2 { get; set; } = " ";


        private string asil3 { get; set; } = " ";


        private string asil4 { get; set; } = " ";


        private string asil5 { get; set; } = " ";


        private string asil6 { get; set; } = " ";


        private string asil7 { get; set; } = " ";


        private string asil8 { get; set; } = " ";

        private string frequent1 { get; set; } = " ";

        private string frequent2 { get; set; } = " ";




        public string com { get; set; } = " ";


        public static ComAssistance frmmain { get; set; } = null;


        private trx asilData { get; set; } = null;


        private int ok_count { get; set; } = 0;


        private int ng_count { get; set; } = 0;



        private Socket ServerSocket { get; set; } = null;


        public Dictionary<string, MySession> dic_ClientSocket { get; set; } = new Dictionary<string, MySession>();


        private Dictionary<string, Thread> dic_ClientThread { get; set; } = new Dictionary<string, Thread>();

        private bool Flag_Listen { get; set; } = true;


        private delegate void AppendReceivedText(string text);


        private delegate void SetTextCallBack(string text);


        public delegate void settext(string text);



        #endregion

        private string ExtractUpperLower(string value, double narmalMin, double narmalMax, bool check)
        {
            if (check)
            {
                return "LowerUpper:" + narmalMin.ToString() + "/" + narmalMax.ToString() + $" Value:{value}";
            }
            else
            {
                return "";
            }
        }



        public bool SpotCheck { get; set; } = false;

        public bool IsSpotCheck { get; set; } = false;

        public ASIL Asil { get; set; } = new ASIL();

        public void asil()
        {
            try
            {
                this.Send = true;
                this.asilData = new trx();
                bool flag = string.IsNullOrWhiteSpace(this.asil1) && string.IsNullOrWhiteSpace(this.asil2) && string.IsNullOrWhiteSpace(this.asil3) && string.IsNullOrWhiteSpace(this.asil4) && string.IsNullOrWhiteSpace(this.asil5) && string.IsNullOrWhiteSpace(this.asil6) && string.IsNullOrWhiteSpace(this.asil7) && string.IsNullOrWhiteSpace(this.asil8);
                if (flag)
                {
                    MessageBox.Show("未收到采集数据，请检查串口！", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                LogMethod.log(string.Concat(new string[]
                {
                    "recive spot check ASIL:T",
                    this.asil1,
                    "A",
                    this.asil2,
                    "A",
                    this.asil3,
                    "A",
                    this.asil4,
                    "A",
                    this.asil5,
                    "A",
                    this.asil6,
                    "A",
                    this.asil7,
                    "A",
                    this.asil8,
                    "E",
                     this.frequent1,
                     "end",
                     this.frequent2,
                }));

                //判断模块
                string result1 = this.Judge(this.asil1, Asil.ASIL1_Min, Asil.ASIL1_Max, Asil.ASIL1_check);
                string result2 = this.Judge(this.asil2, Asil.ASIL2_Min, Asil.ASIL2_Max, Asil.ASIL2_check);
                string result3 = this.Judge(this.asil3, Asil.ASIL3_Min, Asil.ASIL3_Max, Asil.ASIL3_check);
                string result4 = this.Judge(this.asil4, Asil.ASIL4_Min, Asil.ASIL4_Max, Asil.ASIL4_check);
                string result5 = this.Judge(this.asil5, Asil.ASIL5_Min, Asil.ASIL5_Max, Asil.ASIL5_check);
                string result6 = this.Judge(this.asil6, Asil.ASIL6_Min, Asil.ASIL6_Max, Asil.ASIL6_check);
                string result7 = this.Judge(this.asil7, Asil.ASIL7_Min, Asil.ASIL7_Max, Asil.ASIL7_check);
                string result8 = this.Judge(this.asil8, Asil.ASIL8_Min, Asil.ASIL8_Max, Asil.ASIL8_check);
                string result9 = this.Judge(this.frequent1, ComAssistance.tc.frequency1_Min, ComAssistance.tc.frequency1_Max, ComAssistance.tc.frequency1_check);
                string result0 = this.Judge(this.frequent2, ComAssistance.tc.frequency2_Min, ComAssistance.tc.frequency2_Max, ComAssistance.tc.frequency2_check);

                string UpperLower = ExtractUpperLower(this.asil1, Asil.ASIL1_Min, Asil.ASIL1_Max, Asil.ASIL1_check);
                UpperLower += ExtractUpperLower(this.asil2, Asil.ASIL2_Min, Asil.ASIL2_Max, Asil.ASIL2_check);
                UpperLower += ExtractUpperLower(this.asil3, Asil.ASIL3_Min, Asil.ASIL3_Max, Asil.ASIL3_check);
                UpperLower += ExtractUpperLower(this.asil4, Asil.ASIL4_Min, Asil.ASIL4_Max, Asil.ASIL4_check);
                UpperLower += ExtractUpperLower(this.asil5, Asil.ASIL5_Min, Asil.ASIL5_Max, Asil.ASIL5_check);
                UpperLower += ExtractUpperLower(this.asil6, Asil.ASIL6_Min, Asil.ASIL6_Max, Asil.ASIL6_check);
                UpperLower += ExtractUpperLower(this.asil7, Asil.ASIL7_Min, Asil.ASIL7_Max, Asil.ASIL7_check);
                UpperLower += ExtractUpperLower(this.asil8, Asil.ASIL8_Min, Asil.ASIL8_Max, Asil.ASIL8_check);

                string[] test = new string[]
                {
                    result1,
                    result2,
                    result3,
                    result4,
                    result5,
                    result6,
                    result7,
                    result8,
                    result9,
                    result0
                };
                this.Send = false;
                this.SetText11("");
                this.SpotCheck = false;
                Thread.Sleep(1000);
                this.TestFlag = false;
                if (test.Contains("NG"))
                {
                    this.Invoke(new Action(() =>
                    {
                        but_spotCheck.Enabled = true;
                        IsSpotCheck = false;
                        this.Setlabel27("点检失败,请重新点检");
                        this.pictureBox4.Image = Resources.red;
                        IniConfigHelper.WriteIniData("CheckTime", "DayShiftSpotCheck", "0");
                        IniConfigHelper.WriteIniData("CheckTime", "NightShiftSpotCheck", "0");
                        MessageBox.Show("点检结果为NG");
                    }));
                    LogMethod.SpotChecklog($"SN:{ComAssistance.tc.JinceSN} {UpperLower} Status:NG");
                }
                else
                {
                    this.Setlabel27($"点检成功：{asil1}{asil2}{asil3}{asil4}{asil5}{asil6}{asil7}{asil8}{frequent1}{frequent2}".Replace("N", ""));
                    IniConfigHelper.WriteIniData("CheckTime", "CheckSuccessFul", $"点检成功：{asil1}{asil2}{asil3}{asil4}{asil5}{asil6}{asil7}{asil8}{frequent1}{frequent2}".Replace("N", ""));
                    this.Setlabel15("OK,点检成功");
                    DuringSpotCheckQualified();
                    this.pictureBox4.Tag = 0;
                    Thread.Sleep(500);
                    IniConfigHelper.WriteIniData("CheckTime", "CurrentSpotCheckTime", DateTime.Now.ToString());
                    LastDateTime = DateTime.Now;
                    IsSpotCheck = true;
                    LogMethod.SpotChecklog($"SN:{ComAssistance.tc.JinceSN} {UpperLower} Status:OK");
                    this.Invoke(new Action(() =>
                    {
                        but_spotCheck.Enabled = true;
                        this.pictureBox4.Image = Resources.green;
                        MessageBox.Show("OK,点检成功.可启用测试机!");
                    }));
                }
                this.asil1 = " ";
                this.asil2 = " ";
                this.asil3 = " ";
                this.asil4 = " ";
                this.asil5 = " ";
                this.asil6 = " ";
                this.asil7 = " ";
                this.asil8 = " ";
                this.frequent1 = " ";
                this.frequent2 = " ";
            }
            catch (Exception ex)
            {
                this.SpotCheck = false;
                but_spotCheck.Enabled = true;
                this.IsSpotCheck = false;
                this.TestFlag = false;
                this.Send = false;
                this.Setlabel15(ex.Message);
                LogMethod.log(ex.Message);
            }
        }


        /// <summary>
        /// 数据判断与发送
        /// </summary>
        public void AsilSend()
        {
            try
            {
                this.Send = true;
                this.asilData = new trx();
                this.asilData.message_id = "Asil_test_result_report";
                this.asilData.type_id = "I";
                this.asilData.log_id = "0" + DateTime.Now.ToString("yyyyMMddhhss") + this.sn_no;
                this.asilData.unique_id = ComAssistance.tc.JinceSN;
                this.asilData.station_id = Dns.GetHostName();
                this.asilData.test_result = this.testresult;
                this.asilData.test_time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                this.asilData.feedback_io_01 = this.asil1;
                this.asilData.feedback_io_02 = this.asil2;
                this.asilData.feedback_io_03 = this.asil3;
                this.asilData.feedback_io_04 = this.asil4;
                this.asilData.feedback_io_05 = this.asil5;
                this.asilData.feedback_io_06 = this.asil6;
                this.asilData.feedback_io_07 = this.asil7;
                this.asilData.feedback_io_08 = this.asil8;
                bool flag = string.IsNullOrWhiteSpace(this.asil1) && string.IsNullOrWhiteSpace(this.asil2) && string.IsNullOrWhiteSpace(this.asil3) && string.IsNullOrWhiteSpace(this.asil4) && string.IsNullOrWhiteSpace(this.asil5) && string.IsNullOrWhiteSpace(this.asil6) && string.IsNullOrWhiteSpace(this.asil7) && string.IsNullOrWhiteSpace(this.asil8);
                if (flag)
                {
                    MessageBox.Show("未收到采集数据，请检查串口！", "出错了", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                LogMethod.log(string.Concat(new string[]
                {
                    "recive ASIL:T",
                    this.asil1,
                    "A",
                    this.asil2,
                    "A",
                    this.asil3,
                    "A",
                    this.asil4,
                    "A",
                    this.asil5,
                    "A",
                    this.asil6,
                    "A",
                    this.asil7,
                    "A",
                    this.asil8,
                    "E",
                    this.frequent1,
                    "End",
                    this.frequent2
                }));

                //判断模块

                string result1 = this.Judge(this.asil1, ComAssistance.tc.ASIL1_Min, ComAssistance.tc.ASIL1_Max, ComAssistance.tc.ASIL1_check);
                string result2 = this.Judge(this.asil2, ComAssistance.tc.ASIL2_Min, ComAssistance.tc.ASIL2_Max, ComAssistance.tc.ASIL2_check);
                string result3 = this.Judge(this.asil3, ComAssistance.tc.ASIL3_Min, ComAssistance.tc.ASIL3_Max, ComAssistance.tc.ASIL3_check);
                string result4 = this.Judge(this.asil4, ComAssistance.tc.ASIL4_Min, ComAssistance.tc.ASIL4_Max, ComAssistance.tc.ASIL4_check);
                string result5 = this.Judge(this.asil5, ComAssistance.tc.ASIL5_Min, ComAssistance.tc.ASIL5_Max, ComAssistance.tc.ASIL5_check);
                string result6 = this.Judge(this.asil6, ComAssistance.tc.ASIL6_Min, ComAssistance.tc.ASIL6_Max, ComAssistance.tc.ASIL6_check);
                string result7 = this.Judge(this.asil7, ComAssistance.tc.ASIL7_Min, ComAssistance.tc.ASIL7_Max, ComAssistance.tc.ASIL7_check);
                string result8 = this.Judge(this.asil8, ComAssistance.tc.ASIL8_Min, ComAssistance.tc.ASIL8_Max, ComAssistance.tc.ASIL8_check);
                string result9 = this.Judge(this.frequent1, ComAssistance.tc.frequency1_Min, ComAssistance.tc.frequency1_Max, ComAssistance.tc.frequency1_check);
                string result10 = this.Judge(this.frequent2, ComAssistance.tc.frequency2_Min, ComAssistance.tc.frequency2_Max, ComAssistance.tc.frequency2_check);
                string[] test = new string[]
                {
                    result1,
                    result2,
                    result3,
                    result4,
                    result5,
                    result6,
                    result7,
                    result8,
                    result9,
                    result10
                };
                LogMethod.log(string.Concat(new string[]
                {
                    "test result",
                    result1,
                    result2,
                    result3,
                    result4,
                    result5,
                    result6,
                    result7,
                    result8,
                    result9,
                    result10
                }));
                bool flag2 = test.Contains("NG");
                if (flag2)
                {
                    if (!this.Manual_Auto)
                    {
                        string senddata = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Response><Result>ERR</Result><Param1></Param1>" +
                            "<Param2></Param2><Param3></Param3><Param4></Param4><Param5></Param5><Param6></Param6><Param7></Param7><Param8></Param8><Param9></Param9></Response>";
                        this.tcpsend(senddata);
                        this.sendport("C");
                        ComAssistance.tc.test_result = "FAIL";
                        this.SetNG_Text(this.ng_count.ToString());
                    }
                    this.testresult = "NG";
                    NGcount += 1;
                    this.sendport("C");
                    ComAssistance.tc.test_result = "FAIL";
                    this.ng_count++;
                    this.SetNG_Text(this.ng_count.ToString());
                }
                else
                {
                    if (!this.Manual_Auto)
                    {
                        string senddata2 = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Response><Result>OK</Result>" +
                            "<Param1></Param1><Param2></Param2><Param3></Param3><Param4></Param4><Param5></Param5><Param6></Param6><Param7></Param7><Param8></Param8><Param9></Param9></Response>";
                        this.tcpsend(senddata2);
                    }
                    this.testresult = "PASS";
                    this.sendport("D");
                    NGcount = 0;
                    ComAssistance.tc.test_result = "PASS";
                    this.ok_count++;
                    this.SetOKTEXT(this.ok_count.ToString());
                }
                //修改XML发送消息

                bool[] judge = new bool[]
                {
                    ComAssistance.tc.ASIL1_check,
                    ComAssistance.tc.ASIL2_check,
                    ComAssistance.tc.ASIL3_check,
                    ComAssistance.tc.ASIL4_check,
                    ComAssistance.tc.ASIL5_check,
                    ComAssistance.tc.ASIL6_check,
                    ComAssistance.tc.ASIL7_check,
                    ComAssistance.tc.ASIL8_check,
                    ComAssistance.tc.frequency1_check,
                    ComAssistance.tc.frequency2_check
                };

                int index = 0;

                string[] AssembleType = ComAssistance.tc.type2.Split(',');

                int OptionCount = AssembleType.Length - 2;

                string[] data = new string[]
                {
                    asil1, asil2, asil3, asil4, asil5, asil6, asil7, asil8,frequent1,frequent2
                };

                foreach (var item in judge)
                {
                    ComAssistance.tc.unifomity = data[index++];
                    if (item)
                    {
                        ComAssistance.tc.CurrentType = AssembleType[OptionCount--];
                        this.ModifyNode(Environment.CurrentDirectory + "\\config\\CCDData.xml");
                        //this.ModifyNode(Environment.CurrentDirectory + "\\config\\Ictest.xml");
                        byte[] asilA = this.FileTOByte(Environment.CurrentDirectory + "\\config\\CCDData.xml");
                        //byte[] asilB = this.FileTOByte(Environment.CurrentDirectory + "\\config\\Ictest.xml");
                        byte[] asilB = null;
                        this.Setlabel15("PIS2通信连接中...");
                        this.ConectCMMQ(ComAssistance.tc.SendQueue, ComAssistance.tc.ReplyQueue, ComAssistance.tc.pis2Ip, ComAssistance.tc.pis2Port, asilA, asilB);
                    }
                }
                this.Send = false;
                this.SetText11("");
                this.Manual_Auto = false;
                Thread.Sleep(1500);
                this.Setbutton2("Y");
                this.TestFlag = false;
                if (NGcount >= 3)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Setlabel27("连续三次测试失败，请重新点检");
                        this.pictureBox4.Image = Resources.red;
                        MessageBox.Show("连续三次测试失败，请重新点检");
                        IniConfigHelper.WriteIniData("CheckTime", "NightShiftSpotCheck", "0");
                        IniConfigHelper.WriteIniData("CheckTime", "DayShiftSpotCheck", "0");
                        DayShiftSpotCheck = false;
                        NightShiftSpotCheck = false;
                        IsSpotCheck = false;
                    }));
                    NGcount = 0;
                }
                this.asil1 = " ";
                this.asil2 = " ";
                this.asil3 = " ";
                this.asil4 = " ";
                this.asil5 = " ";
                this.asil6 = " ";
                this.asil7 = " ";
                this.asil8 = " ";
                this.frequent1 = " ";
                this.frequent2 = " ";
            }
            catch (Exception ex)
            {
                this.Manual_Auto = false;
                this.TestFlag = false;
                this.Setbutton2("Y");
                this.Send = false;
                this.Setlabel15(ex.Message);
                LogMethod.log(ex.Message);
            }
        }

        private void but_spotCheck_Click(object sender, EventArgs e)
        {
            if (this.textBox11.Text == tc.SampleSN)
            {
                UpdateRecipe(Application.StartupPath + $"\\Recipe\\{tc.ModelName}.ini", tc.ModelName);
                but_spotCheck.Enabled = false;
                this.SpotCheck = true;
                this.TestFlag = true;
                ComAssistance.tc.JinceSN = this.textBox11.Text;
            }
            else
            {
                MessageBox.Show("输入SN与点检SN不一致,请检查");
            }
        }

        private void LoadSerialPort()
        {
            this.comboBox2.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++)
            {
                this.comboBox2.Items.Add(portNames[i]);
                bool flag = tc.comId.ToString() == portNames[i];
                if (flag)
                {
                    this.comboBox2.SelectedValue = portNames[i];
                }
            }
            foreach (object item in this.comboBox2.Items)
            {
                bool flag2 = item.ToString() == tc.comId;
                if (flag2)
                {
                    this.comboBox2.SelectedItem = item;
                    break;
                }
            }
        }

        public void SetParameter()
        {
            try
            {
                foreach (object obj in tc.xnlist)
                {
                    XmlNode xnf = (XmlNode)obj;
                    XmlElement xe = (XmlElement)xnf;
                    bool flag_1 = xe.GetAttribute("name") == "COM_PortNum";
                    if (flag_1)
                    {
                        xe.SetAttribute("value", this.comboBox2.SelectedItem.ToString());
                    }
                }
                tc.xmlDoc.Save(tc.path);
                ComAssistance.tc.Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "保存错误！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++)
            {
                this.comboBox2.Items.Add(portNames[i]);
                bool flag = tc.comId.ToString() == portNames[i];
                if (flag)
                {
                    this.comboBox2.SelectedValue = portNames[i];
                }
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetParameter();
        }

        #region spotcheck


        private string UniqueMachineId = GenerateUniqueMachineId();

        private void SpotCheckLoad()
        {
            IniConfigHelper.IniPath = Application.StartupPath + "\\Setting.ini";

            if (UniqueMachineId == IniConfigHelper.ReadIniData("CheckTime", "UniqueMachineId", "null"))
            {
                DateTime NowDataTime = DateTime.Now;
                DateTime dateTimeDayShift = DateTime.Now;
                DateTime dateTimeNightShift = DateTime.Now;
                DateTime LastDateTime = DateTime.Now;
                try
                {
                    dateTimeDayShift = DateTime.Parse(ComAssistance.tc.DayShift);
                    dateTimeNightShift = DateTime.Parse(ComAssistance.tc.NightShift);
                    LastDateTime = DateTime.Parse(IniConfigHelper.ReadIniData("CheckTime", "CurrentSpotCheckTime", "19:50"));
                }
                catch (Exception)
                {
                    MessageBox.Show("Check Time格式输入错误,请参照 7:50 该格式进行填写");
                    return;
                }
                DateTime endOfDateTimeDayShift = dateTimeDayShift.AddDays(1);
                DayShiftSpotCheck = IniConfigHelper.ReadIniData("CheckTime", "DayShiftSpotCheck", "") == "1";
                NightShiftSpotCheck = IniConfigHelper.ReadIniData("CheckTime", "NightShiftSpotCheck", "") == "1";
                string CheckSuccessFul = IniConfigHelper.ReadIniData("CheckTime", "CheckSuccessFul", "点检成功");
                if (NowDataTime >= dateTimeDayShift && NowDataTime <= dateTimeNightShift)
                {
                    if (dateTimeDayShift >= LastDateTime)
                    {
                        this.pictureBox4.Image = Resources.red;
                        MessageBox.Show("请进行点检");
                        IsSpotCheck = false;
                        return;
                    }
                    if (DayShiftSpotCheck)
                    {
                        this.Setlabel27(CheckSuccessFul);
                        IsSpotCheck = true;
                        this.pictureBox4.Image = Resources.green;
                        this.Setlabel15("点检成功");
                        return;
                    }
                    else
                    {
                        IsSpotCheck = false;
                        return;
                    }
                }
                else
                {
                    if (DateTime.Parse("00:00") <= NowDataTime && NowDataTime <= dateTimeDayShift)
                    {
                        if (dateTimeNightShift.AddDays(-1) <= LastDateTime)
                        {
                            if (!NightShiftSpotCheck)
                            {
                                Setlabel27("请进行点检");
                                MessageBox.Show("请进行点检");
                                IsSpotCheck = false;
                                return;
                            }
                            else
                            {
                                this.Setlabel27(CheckSuccessFul);
                                this.pictureBox4.Image = Resources.green;
                                IsSpotCheck = true;
                                this.Setlabel15("点检成功");
                                return;
                            }
                        }
                        else
                        {
                            Setlabel27("请进行点检");
                            this.pictureBox4.Image = Resources.red;
                            MessageBox.Show("请进行点检");
                            this.pictureBox4.Tag = 1;
                            IsSpotCheck = false;
                            return;
                        }
                    }
                    if (dateTimeNightShift <= LastDateTime)
                    {
                        if (NightShiftSpotCheck)
                        {
                            this.Setlabel27(CheckSuccessFul);
                            this.pictureBox4.Image = Resources.green;
                            IsSpotCheck = true;
                            this.Setlabel15("点检成功");
                            return;
                        }
                    }
                    else
                    {
                        IsSpotCheck = false;
                        return;
                    }
                }
            }
            else
            {
                IniConfigHelper.WriteIniData("CheckTime", "UniqueMachineId", UniqueMachineId);
                IsSpotCheck = false;
                return;
            }
        }

        private static string GenerateUniqueMachineId()
        {
            string macAddress = GetMACAddress();
            string unique = Environment.MachineName;
            return $"{unique}-{macAddress}";
        }


        private static string GetMACAddress()
        {
            try
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        return nic.GetPhysicalAddress().ToString();
                    }
                }
                return "unknown";
            }
            catch
            {
                return "unknown";
            }
        }

        private bool JudgeCheckTime()
        {
            DateTime NowDataTime = DateTime.Now;
            DateTime dateTimeDayShift = DateTime.Now;
            DateTime dateTimeNightShift = DateTime.Now;
            LastDateTime = DateTime.Now;
            try
            {
                dateTimeDayShift = DateTime.Parse(ComAssistance.tc.DayShift);
                dateTimeNightShift = DateTime.Parse(ComAssistance.tc.NightShift);
                LastDateTime = DateTime.Parse(IniConfigHelper.ReadIniData("CheckTime", "CurrentSpotCheckTime", "19:55"));
            }
            catch (Exception)
            {
                MessageBox.Show("Check Time格式输入错误,请参照 7:50 该格式进行填写");
                return false;
            }

            DayShiftSpotCheck = IniConfigHelper.ReadIniData("CheckTime", "DayShiftSpotCheck", "7:50") == "1" ? true : false;
            NightShiftSpotCheck = IniConfigHelper.ReadIniData("CheckTime", "NightShiftSpotCheck", "19:50") == "1" ? true : false;

            LogMethod.log($"DayShiftSpotCheck:{DayShiftSpotCheck},NightShiftSpotCheck:{NightShiftSpotCheck},LastDateTime{LastDateTime}");

            if (NowDataTime >= dateTimeDayShift && NowDataTime <= dateTimeNightShift)
            {
                if (dateTimeDayShift >= LastDateTime)
                {
                    this.pictureBox4.Image = Resources.red;
                    MessageBox.Show("请进行点检");
                    IsSpotCheck = false;
                    LogMethod.log($"dateTimeDayShift >= LastDateTime({LastDateTime})");
                    return false;
                }
                if (!DayShiftSpotCheck)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.pictureBox4.Image = Resources.red;
                        Setlabel27("请进行点检");
                        MessageBox.Show("请进行点检");
                    }));
                    IsSpotCheck = false;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (DateTime.Parse("00:00") <= NowDataTime && NowDataTime <= dateTimeDayShift)
                {
                    if (dateTimeNightShift.AddDays(-1) <= LastDateTime)
                    {
                        if (!NightShiftSpotCheck)
                        {
                            Setlabel27("请进行点检");
                            this.pictureBox4.Image = Resources.red;
                            MessageBox.Show("请进行点检");
                            this.pictureBox4.Tag = 1;
                            IsSpotCheck = false;
                            LogMethod.log("NightShiftSpotCheck Loop Monitor");
                            return false;
                        }
                        return true;
                    }
                    else
                    {
                        Setlabel27("请进行点检");
                        this.pictureBox4.Image = Resources.red;
                        MessageBox.Show("请进行点检");
                        this.pictureBox4.Tag = 1;
                        IsSpotCheck = false;
                        LogMethod.log($"dateTimeDayShift >= LastDateTime({LastDateTime})");
                        return false;
                    }
                }
                if (dateTimeNightShift >= LastDateTime)
                {
                    this.pictureBox4.Image = Resources.red;
                    MessageBox.Show("请进行点检");
                    IsSpotCheck = false;
                    LogMethod.log($"dateTimeNightShift >= LastDateTime({LastDateTime})");
                    return false;
                }
                if (!NightShiftSpotCheck)
                {
                    this.Invoke(new Action(() =>
                    {
                        Setlabel27("请进行点检");
                        this.pictureBox4.Image = Resources.red;
                        MessageBox.Show("请进行点检");
                    }));
                    IsSpotCheck = false;
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public void DuringSpotCheckQualified()
        {
            DateTime NowDataTime = DateTime.Now;
            DateTime dateTimeDayShift = DateTime.Now;
            DateTime dateTimeNightShift = DateTime.Now;
            try
            {
                dateTimeDayShift = DateTime.Parse(ComAssistance.tc.DayShift);
                dateTimeNightShift = DateTime.Parse(ComAssistance.tc.NightShift);
            }
            catch (Exception)
            {
                MessageBox.Show("Check Time格式输入错误,请参照 7:50 该格式进行填写");
                return;
            }

            if (NowDataTime >= dateTimeDayShift && NowDataTime <= dateTimeNightShift)
            {
                IniConfigHelper.WriteIniData("CheckTime", "DayShiftSpotCheck", "1");
                IniConfigHelper.WriteIniData("CheckTime", "NightShiftSpotCheck", "0");
                LogMethod.log("早班点检成功");
                DayShiftSpotCheck = true;
                NightShiftSpotCheck = false;
            }
            else
            {
                IniConfigHelper.WriteIniData("CheckTime", "NightShiftSpotCheck", "1");
                IniConfigHelper.WriteIniData("CheckTime", "DayShiftSpotCheck", "0");
                LogMethod.log("晚班点检成功");
                DayShiftSpotCheck = false;
                NightShiftSpotCheck = true;
            }
        }


        #endregion

        private void ComAssistance_Load(object sender, EventArgs e)
        {
            IniConfigHelper.IniPath = Application.StartupPath + "\\Setting.ini";
        }

        private void SetPositionPanelID()
        {
            this.Invoke(new Action(() =>
            {
                if (ComAssistance.tc.PanelPositionState)
                {
                    this.panel3.BackColor = Color.Lime;
                    this.label30.Text = ComAssistance.tc.PanelPosition;
                }
                else
                {
                    this.panel3.BackColor = Color.Silver;
                    this.label30.Text = "";
                }
            }));
        }

        private DateTime LastDateTime { get; set; } = DateTime.Now;

        private void LoopMonitorTime()
        {
            DateTime NowDataTime = DateTime.Now;
            DateTime dateTimeDayShift = DateTime.Now;
            DateTime dateTimeNightShift = DateTime.Now;
            try
            {
                dateTimeDayShift = DateTime.Parse(ComAssistance.tc.DayShift);
                dateTimeNightShift = DateTime.Parse(ComAssistance.tc.NightShift);

            }
            catch (Exception)
            {
                return;
            }
            if (NowDataTime >= dateTimeDayShift && NowDataTime <= dateTimeNightShift)
            {
                this.Invoke(new Action(() =>
                {
                    if (this.pictureBox4.Tag.ToString() == "1")
                    {
                        return;
                    }
                    if (dateTimeDayShift >= LastDateTime)
                    {
                        Setlabel27("请进行点检");
                        this.pictureBox4.Image = Resources.red;
                        this.pictureBox4.Tag = 1;
                        IsSpotCheck = false;
                        LogMethod.log($"dateTimeDayShift >= LastDateTime({LastDateTime})");
                        return;
                    }
                    if (!DayShiftSpotCheck)
                    {
                        Setlabel27("请进行点检");
                        this.pictureBox4.Image = Resources.red;
                        this.pictureBox4.Tag = 1;
                        IsSpotCheck = false;
                        LogMethod.log("DayShiftSpotCheck Loop Monitor");
                        return;
                    }
                }));
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    if (this.pictureBox4.Tag.ToString() == "1")
                    {
                        return;
                    }
                    if (DateTime.Parse("00:00") <= NowDataTime && NowDataTime <= dateTimeDayShift)
                    {

                        if (dateTimeNightShift.AddDays(-1) <= LastDateTime)
                        {
                            if (!NightShiftSpotCheck)
                            {
                                Setlabel27("请进行点检");
                                this.pictureBox4.Image = Resources.red;
                                this.pictureBox4.Tag = 1;
                                IsSpotCheck = false;
                                LogMethod.log("NightShiftSpotCheck Loop Monitor");
                            }
                        }
                        else
                        {
                            Setlabel27("请进行点检");
                            this.pictureBox4.Image = Resources.red;
                            this.pictureBox4.Tag = 1;
                            IsSpotCheck = false;
                            LogMethod.log($"dateTimeDayShift >= LastDateTime({LastDateTime})");
                        }
                        return;
                    }
                    if (dateTimeNightShift <= LastDateTime)
                    {
                        if (!NightShiftSpotCheck)
                        {
                            Setlabel27("请进行点检");
                            this.pictureBox4.Image = Resources.red;
                            this.pictureBox4.Tag = 1;
                            IsSpotCheck = false;
                            LogMethod.log("NightShiftSpotCheck Loop Monitor");
                        }
                    }
                    else
                    {
                        Setlabel27("请进行点检");
                        this.pictureBox4.Image = Resources.red;
                        this.pictureBox4.Tag = 1;
                        IsSpotCheck = false;
                        LogMethod.log($"dateTimeDayShift >= LastDateTime({LastDateTime})");
                    }

                }));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (JudgeCheckTime())
            {
                MessageBox.Show("ture");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.asilData = new trx();
            this.asilData.unique_id = "111111111111111111";
            ComAssistance.tc.CurrentType = "1111";
            this.testresult = "1111";
            this.ModifyNode(Environment.CurrentDirectory + "\\config\\CCDData.xml");
        }
    }
}

