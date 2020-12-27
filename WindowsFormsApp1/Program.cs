using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1
{

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void WebThread()
        {
            //获取一言
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

                if (File.Exists("./sourse/text.txt"))
                { File.Delete("./sourse/text.txt"); }
                using (StreamWriter sw = new StreamWriter("./sourse/text.txt"))
                    sw.Write("["+Saying+"]" + "  " + Author);
            }
            catch (System.Net.WebException) { }

        }

        static void Main()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            Application.EnableVisualStyles();
            if (Directory.Exists("./sourse") == false)//如果不存
            {
                //如果不存在就创建资源文件夹
                Directory.CreateDirectory("./sourse");
            }
            Application.SetCompatibleTextRenderingDefault(false);
            ThreadStart childref = new ThreadStart(WebThread);
            Thread childThread = new Thread(childref);
            childThread.Start();
            Application.Run(new Form1());
        }
    }
}
