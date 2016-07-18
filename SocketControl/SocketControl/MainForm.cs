using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RobotKit;
using System.Threading;

namespace SocketControl
{
    public partial class MainForm : Form
    {

       // private SocketClient sc = new SocketClient("192.168.0.254");
        private SocketClient sc = null;
        private Thread tr = null;
        private string Mess = null;
        private string[] FileLine = null;


        public MainForm()
        {
            InitializeComponent();
        }

        private void BT_Start_Click(object sender, EventArgs e)
        {
            if (tr!=null&&tr.IsAlive)
            {
                tr.Abort();
            }

            tr = new Thread(new ThreadStart(SocketSend));
            tr.Start();

        }

        public  bool ReadFile(string FileName)
        {
            if (FileName == null || !File.Exists(FileName))
            {
                return false;
            }

            FileStream fs = null;
            StreamReader sr = null;
            string StrLine = null;


            try
            {


                fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);  //使用StreamReader类来读取文件 
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                int LineCount = 0;
                FileLine = new string[10000000];
                while ((StrLine = sr.ReadLine()) != null)
                {

                    StrLine = StrLine.Trim().ToUpper();
                    if (StrLine.IndexOf("MOVEL=")<0&&StrLine.IndexOf("MOVEJ=")<0&&StrLine.IndexOf("MOVEC=")<0)
                    {
                        continue;
                    }
               


                    Mess = "行数" + LineCount.ToString() + " " + StrLine;
                    FileLine[LineCount] = StrLine;
                    LineCount++;

                }
                Array.Resize(ref FileLine, LineCount);
                return true;

            }
            catch(Exception ex)
            {

                Mess = ex.Message;
                return false;

            }

            finally
            {

                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }

            }


        }




        private void SocketSend()
        {
            Mess = "开始读取文本";
            FileLine = null;

            if (!ReadFile(@"C:\Users\yye\Desktop\Recipe.txt") || FileLine == null)
            {
                //MessageBox.Show("数据错误");
                Mess = "数据错误";
                return;
            }
            Mess = "读取文本完成";
            int i = 0;
            sc  = new SocketClient("192.168.0.254", 6000);
            while (i < FileLine.Length)
            {
                Mess = "发送:" + i.ToString() + "    \n" + FileLine[i];
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                sc.SendData(FileLine[i] + asciiEncoding.GetString(new byte[]{13}));
                while (sc.ReciveData().IndexOf("success")<0)
                {
                    System.Threading.Thread.Sleep(1);
                }
                i++;
            }
                





        }

        private void BT_Stop_Click(object sender, EventArgs e)
        {
            if (tr != null && tr.IsAlive)
            {
                tr.Abort();
            }
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            BT_Stop_Click(this,null);
        }

        private void timer_Refresh_Tick(object sender, EventArgs e)
        {
            LBL.Text = "消息:" + Mess;
        }

    }
}
