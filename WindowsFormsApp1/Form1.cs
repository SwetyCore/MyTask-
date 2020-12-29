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
using System.Runtime.InteropServices;
using FantasticMusicPlayer.lib;
using System.Drawing.Text;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {

        //随机获取图片
        public List<string> lists = GetImagesPath("./sourse");
        public void ChangeBg()
        {
            
            int picnum;
            Random rd = new Random();
            picnum=rd.Next(0, lists.Count);
            SetBg(lists[picnum]);

        }

        public static List<String> GetImagesPath(String folderName)
        {

            DirectoryInfo Folder;
            FileInfo[] Images;

            Folder = new DirectoryInfo(folderName);
            Images = Folder.GetFiles();
            List<String> imagesList = new List<String>();

            for (int i = 0; i < Images.Length; i++)
            {
                string picpath = String.Format(@"{0}/{1}", folderName, Images[i].Name);
                if (picpath.Substring(picpath.Length - 3, 3)=="jpg"|| picpath.Substring(picpath.Length - 3, 3) == "png")
                imagesList.Add(picpath);
                // Console.WriteLine(String.Format(@"{0}/{1}", folderName, Images[i].Name));
            }

            return imagesList;
        }
        /*
        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint SC_MONITORPOWER = 0xF170;
        [DllImport("user32")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint wMsg, uint wParam, int lParam);

        void CloseLCD()
        {
            SendMessage(this.Handle, WM_SYSCOMMAND,
            SC_MONITORPOWER, 2); // 2 为关闭显示器， －1则打开显示器
        }

        */
        //显示器关闭
        private static IntPtr HWND_BROADCAST = new IntPtr(65535);
        [DllImport("user32.dll", EntryPoint = "PostMessageA")]
        private static extern int PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        //星期
        protected string GetDateWeek(string strYMD)
        {
            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = weekdays[Convert.ToInt32(Convert.ToDateTime(strYMD).DayOfWeek)];
            return week;
        }

        //初始化变量
        public DateTime AllTime;
        public DateTime ZeroTime;
        public string IsStart = "stop";
        public string NowText;

        //当前时间
        public void GetNowTime()
        {
            this.label_NowTime.Text = DateTime.Now.ToString("HH:mm");
            this.label_NowDate.Text = DateTime.Now.ToString("yyyy/MM/dd") + "    " + GetDateWeek(DateTime.Now.ToString("yyyy/MM/dd"));
        }

        //背景
        public void SetBg(string imagepath)
        {
            if (File.Exists(imagepath))
            {

                Image Bg = Image.FromFile(imagepath);
                this.pictureBox_default.BackgroundImage = Bg;
                BgBlur(imagepath);
            }
        }
       
        //模糊初始化
        public void BgBlur(string imagepath)
        {
            if (File.Exists(imagepath))
            {
                GaussianBlur Blur = new GaussianBlur(7);
                Image Newimage = Blur.ProcessImage(new Bitmap(Image.FromFile(imagepath), 128, 128),false);
                pictureBox_Blur.BackgroundImage = new Bitmap(Newimage);
            }
        }

        //+1s
        public void TimeAdd()
        {
            if (IsStart == "start")
            {
                AllTime = AllTime.AddSeconds(1);
                if (AllTime.ToString("HH") == "00")
                {
                    this.label_Timer.Text = AllTime.ToString("HH:ss");
                }
                else
                {
                    this.label_Timer.Text = AllTime.ToString("HH:mm");
                }
                //Console.WriteLine("+1s");

            }
        }

        //问候
        public void MyHello()
        {
            int NowHour = int.Parse(DateTime.Now.ToString("HH"));
            if (NowHour < 8 && NowHour >= 6)
            { NowText = "早上好,"; }
            else if (NowHour >= 8 && NowHour < 11)
            { NowText = "上午好,"; }
            else if (NowHour > 11 && NowHour <= 13)
            { NowText = "中午好,"; }
            else if (NowHour < 17 && NowHour > 13)
            { NowText = "下午好,"; }
            else if (NowHour < 23 && NowHour >= 17)
            { NowText = "晚上好,"; }
            else
            { NowText = "夜深了,"; }
            label_Hello.Text = NowText + Environment.UserName + "!";
            //居中
            label_Hello.Left = this.Width / 2 - label_Hello.Width / 2;
        }

        //
        public void LoadFont()
        {
            try
            {
                string path = "./sourse/timer.ttf";
                //读取字体文件
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile(path);
                //实例化字体
                Font f190 = new Font(pfc.Families[0], 190);
                Font f120 = new Font(pfc.Families[0], 120);
                //设置字体
                label_Timer.Font = f190;
                label_NowTime.Font = f120;
            }
            catch { }
        }
        public void ChangeSaying()
        {

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

                label_Saying.Left = this.Width - label_Saying.Width;


                using (StreamWriter sw = new StreamWriter("./sourse/text.txt"))
                    sw.Write("[" + Saying + "]" + "  " + Author);
            }
            catch (System.Net.WebException)
            {
                Mymessage("木有网络,名言获取失败!");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //透明
            label_Hello.Parent = pictureBox_Blur;
            label_NowTime.Parent = pictureBox_Blur;
            label_NowDate.Parent = pictureBox_Blur;
            label_Saying.Parent = pictureBox_Blur;
            label_Timer.Parent = pictureBox_Blur;
            label_Start.Parent = pictureBox_Blur;
            label_stop.Parent = pictureBox_Blur;
            label_CloseLCD.Parent = pictureBox_Blur;
            label1.Parent = pictureBox_Blur;
            pictureBox_default.Parent = pictureBox_Blur;

            //不同分辨率处理
            //背景和模糊
            pictureBox_Blur.Height = this.Height;
            pictureBox_Blur.Width = this.Width;
            pictureBox_default.Height = this.Height;
            pictureBox_default.Width = this.Width;

            //字体
            LoadFont();
            


            //计时界面和欢迎
            label_Timer.Left = this.Width/2-label_Timer.Width/2;
            label_Timer.Top = this.Height/2- label_Timer.Height / 2;
            label_Hello.Left = this.Width / 2 - label_Hello.Width / 2;
            //当前时间日期
            label_NowDate.Top = this.Height - label_NowDate.Height;
            label_NowTime.Top = this.Height - label_NowTime.Height - label_NowDate.Height;
            label_Saying.Top = this.Height - label_Saying.Height - 7;
            label_Saying.Left = this.Width - label_Saying.Width;

            //背景设置
            if (lists.Count > 0)
            { SetBg(lists[0]); }
            else
                Mymessage("没有背景!");

            //欢迎界面

            Mymessage("欢迎回来," + Environment.UserName + "!");
            GetNowTime();


            //一言获取

            ChangeSaying();

           
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
                Thread.Sleep(20);
            }
            System.Environment.Exit(0);
        }


        private void WindowStart()
        {
            while (this.Opacity < 1)
            {
                float num = 0.10f;
                this.Opacity += num;
                num += num;
                Thread.Sleep(20);
            }
            //创建窗口(废弃)

        }

        
        
        //自定义消息框
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
            //

            //时间更新
            GetNowTime();
            TimeAdd();
            MyHello();

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
            if(num1>=36)
            {
                label_msg.Top -= 16;
            }
            if(num1>40)
            {
                label_msg.Visible = false;
                timer2.Enabled = true;
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {
            //点击名言事件
            ChangeSaying();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Mymessage("关闭显示器!!!");
            //CloseLCD();
            Form1.PostMessage(Form1.HWND_BROADCAST, 274U, (IntPtr)61808, (IntPtr)2);
        }

        private void label_Hello_Click(object sender, EventArgs e)
        {
            Mymessage("github.com/SwetyCore/MyTask-");
        }

        private void pictureBox_default_Click(object sender, EventArgs e)
        {
            ChangeBg();
            Mymessage("切换背景!!");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            GaussianBlur Blur = new GaussianBlur(7);
            Image Newimage = Blur.ProcessImage(new Bitmap(pictureBox_default.BackgroundImage, 128, 128),true);
            pictureBox_Blur.BackgroundImage = new Bitmap(Newimage);
            Mymessage("深色模式");
        }
    }
}
