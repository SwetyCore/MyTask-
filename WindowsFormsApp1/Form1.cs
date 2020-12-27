using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //显示器关闭
        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint SC_MONITORPOWER = 0xF170;
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, uint wParam, int lParam);

        void CloseLCD()
        {
            SendMessage(this.Handle, WM_SYSCOMMAND,
            SC_MONITORPOWER, 2); // 2 为关闭显示器， －1则打开显示器
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //透明
            label_Hello.Parent = pictureBox1;
            label_NowTime.Parent = pictureBox1;
            label_NowDate.Parent = pictureBox1;
            label_Saying.Parent = pictureBox1;
            label_Timer.Parent = pictureBox1;
            label_Start.Parent = pictureBox1;
            label_stop.Parent = pictureBox1;
            label_CloseLCD.Parent = pictureBox1;

            //不同分辨率处理(有bug)未完成
            pictureBox1.Height = this.Height;
            pictureBox1.Width = this.Width;

            label_Timer.Width = this.Width;


            if (File.Exists(@".\sourse\bg.jpg"))
            {
                //背景设置
                Image Bg= Image.FromFile(@".\sourse\bg.jpg");
                this.pictureBox1.BackgroundImage = Bg;
            }

            //欢迎界面

            //this.label1_Hello.Text = this.label1_Hello.Text + Environment.UserName+"!";
            Mymessage("欢迎回来," + Environment.UserName + "!");
            this.label_NowTime.Text= DateTime.Now.ToString("HH:mm");
            this.label_NowDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //this.label5_Timer.Text = AllTime.ToString("HH:mm:ss");

            //一言获取
            string Saying = "";
            if (File.Exists("./sourse/text.txt"))
            {
                using (StreamReader streamReader = new StreamReader("./sourse/text.txt"))
                {
                    string text2;
                    while((text2=streamReader.ReadLine())!=null)
                    { Saying = text2; }
                }
                this.label_Saying.Text = Saying;
            }

            //WindowStart();
            

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            //关闭事件
            if (IsStart != "stop")
            {
                Mymessage("计时还未结束!!!");
            }
            else
            {
                Mymessage("再会!!");
                WindowDestroy();
            }

    }

        private void WindowDestroy()
        {
            //销毁窗口
            while (this.Opacity != 0.0)
            {
                float num = 0.10f;
                this.Opacity -=num;
                num += num;
                Thread.Sleep(40);
            }
            System.Environment.Exit(0);
        }
        private void WindowStart()
        {
            //创建窗口(废弃)
            
        }

        public DateTime AllTime;
        public DateTime ZeroTime;
        public string IsStart = "stop";
        public string NowText;

        public void Mymessage(string Msg)
        {
            //消息框
            label_msg.Text = Msg;
            label_msg.Location = new Point(70, 9);
            label_msg.Visible = true;
            timer2.Enabled=true;
            num1 = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //时间更新
            this.label_NowTime.Text = DateTime.Now.ToString("HH:mm");
            this.label_NowDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            if (IsStart=="start")
            {
                AllTime = AllTime.AddSeconds(1);
                if (AllTime.ToString("HH") == "00")
                {
                    this.label_Timer.Text = AllTime.ToString("mm:ss");
                }
                else
                {
                    this.label_Timer.Text = AllTime.ToString("HH:mm");
                }
                Console.WriteLine("+1s");

            }
            int NowHour = int.Parse(DateTime.Now.ToString("HH"));
            if (NowHour<8&&NowHour>=6)
            { NowText = "早上好,"; }
            else if(NowHour>=8&&NowHour<11)
            { NowText = "上午好,"; }
            else if (NowHour > 11 && NowHour <= 13)
            { NowText = "中午好,"; }
            else if (NowHour <17 && NowHour > 13)
            { NowText = "下午好,"; }
            else if (NowHour <23  && NowHour >= 17)
            { NowText = "晚上好,"; }
            else
            { NowText = "夜深了,"; }
            label_Hello.Text=NowText + Environment.UserName + "!";

        }

        private void label7_Start_Click(object sender, EventArgs e)
        {
            //启动计时
            if (IsStart != "start")
            {
                IsStart = "start";
                label_Start.Text = "❚❚";
                Mymessage("计时开始(/≧▽≦)/!");
                this.TopMost = true;
            }
            else
            {
                IsStart = "pause";
                label_Start.Text = "▶";
                Mymessage("计时暂停惹。");
                this.TopMost = false;
            }
        }
        private void label6_stop_Click(object sender, EventArgs e)
        {
            //停止计时
            IsStart = "stop";
            label_Start.Text = "▶";
            Mymessage("计时结束,共专注"+AllTime.ToString("HH:mm:ss")+"。");
            AllTime = ZeroTime;
            label_Timer.Text = AllTime.ToString("mm:ss");
            this.TopMost = false;
        }


        private void label5_Timer_Click(object sender, EventArgs e)
        {
            //启动计时
            if (IsStart != "start")
            {
                IsStart = "start";
                label_Start.Text = "❚❚";
                Mymessage("计时开始(/≧▽≦)/!");
                this.TopMost = true;
            }
            else
            {
                IsStart = "pause";
                label_Start.Text = "▶";
                Mymessage("计时暂停惹。");
                this.TopMost = false;
            }
        }


        public int num1 = 0;//循环计数变量
        private void timer2_Tick(object sender, EventArgs e)
        {
            //信息框动画相关
            num1 += 1;
            if(num1>=26)
            {
                label_msg.Location = new Point(label_msg.Location.X, label_msg.Location.Y-16);
            }
            if(num1>30)
            {
                label_msg.Visible = false;
                timer2.Enabled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //点击名言事件
            try
            {
                string Text;
                Console.WriteLine("Child thread starts");
                string url = "https://v1.hitokoto.cn/";//设置你要访问的网址。

                WebClient wc = new WebClient();//创建WebClient对象

                Stream s = wc.OpenRead(url);//访问网址并用一个流对象来接受返回的流

                StreamReader sr = new StreamReader(s);//把流对象转换为                                                                                        StreamReader对象

                Text = sr.ReadToEnd();//把流转换为字符串
                sr.Close();//关闭资源
                s.Close();

                JObject jo = (JObject)JsonConvert.DeserializeObject(Text);
                string Saying = jo["hitokoto"].ToString();
                string Author = jo["from"].ToString();
                label_Saying.Text = "[" + Saying + "]" + "  " + Author;
                using (StreamWriter sw = new StreamWriter("./sourse/text.txt"))
                    sw.Write("[" + Saying + "]" + "  " + Author);
            }
            catch (System.Net.WebException) 
            {
                Mymessage("木有网络,名言获取失败!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Mymessage("关闭显示器!!!");
            CloseLCD();
        }

    }
}
