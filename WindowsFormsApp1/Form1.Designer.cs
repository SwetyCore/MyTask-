
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_Hello = new System.Windows.Forms.Label();
            this.label_NowTime = new System.Windows.Forms.Label();
            this.label_NowDate = new System.Windows.Forms.Label();
            this.label_Saying = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_Timer = new System.Windows.Forms.Label();
            this.label_Start = new System.Windows.Forms.Label();
            this.label_stop = new System.Windows.Forms.Label();
            this.label_msg = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label_CloseLCD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Hello
            // 
            this.label_Hello.BackColor = System.Drawing.Color.Transparent;
            this.label_Hello.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_Hello.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_Hello.Font = new System.Drawing.Font(".萍方-简", 35F);
            this.label_Hello.ForeColor = System.Drawing.Color.Snow;
            this.label_Hello.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_Hello.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Hello.Location = new System.Drawing.Point(2, 0);
            this.label_Hello.Name = "label_Hello";
            this.label_Hello.Size = new System.Drawing.Size(1920, 74);
            this.label_Hello.TabIndex = 0;
            this.label_Hello.Text = "欢迎回来,";
            this.label_Hello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_NowTime
            // 
            this.label_NowTime.BackColor = System.Drawing.Color.Transparent;
            this.label_NowTime.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.label_NowTime.Font = new System.Drawing.Font("Digiface", 120F);
            this.label_NowTime.ForeColor = System.Drawing.Color.Snow;
            this.label_NowTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_NowTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NowTime.Location = new System.Drawing.Point(1, 819);
            this.label_NowTime.Name = "label_NowTime";
            this.label_NowTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_NowTime.Size = new System.Drawing.Size(583, 201);
            this.label_NowTime.TabIndex = 1;
            this.label_NowTime.Text = "00:00";
            this.label_NowTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_NowTime.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label_NowDate
            // 
            this.label_NowDate.AutoSize = true;
            this.label_NowDate.BackColor = System.Drawing.Color.Transparent;
            this.label_NowDate.Font = new System.Drawing.Font("Digiface", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NowDate.ForeColor = System.Drawing.Color.Snow;
            this.label_NowDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_NowDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_NowDate.Location = new System.Drawing.Point(260, 1024);
            this.label_NowDate.Name = "label_NowDate";
            this.label_NowDate.Size = new System.Drawing.Size(199, 52);
            this.label_NowDate.TabIndex = 2;
            this.label_NowDate.Text = "2020/1/1";
            this.label_NowDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Saying
            // 
            this.label_Saying.BackColor = System.Drawing.Color.Transparent;
            this.label_Saying.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.label_Saying.Font = new System.Drawing.Font(".萍方-简", 15F);
            this.label_Saying.ForeColor = System.Drawing.Color.Snow;
            this.label_Saying.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Saying.Location = new System.Drawing.Point(645, 1002);
            this.label_Saying.Name = "label_Saying";
            this.label_Saying.Size = new System.Drawing.Size(1263, 50);
            this.label_Saying.TabIndex = 3;
            this.label_Saying.Text = "点我获取一言~";
            this.label_Saying.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_Saying.Click += new System.EventHandler(this.label4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 1080);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_Timer
            // 
            this.label_Timer.BackColor = System.Drawing.Color.Transparent;
            this.label_Timer.Font = new System.Drawing.Font("Digiface", 199.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Timer.ForeColor = System.Drawing.Color.Snow;
            this.label_Timer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Timer.Location = new System.Drawing.Point(0, 340);
            this.label_Timer.Name = "label_Timer";
            this.label_Timer.Size = new System.Drawing.Size(1920, 364);
            this.label_Timer.TabIndex = 5;
            this.label_Timer.Text = "00:00";
            this.label_Timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Timer.Click += new System.EventHandler(this.label5_Timer_Click);
            // 
            // label_Start
            // 
            this.label_Start.BackColor = System.Drawing.Color.Transparent;
            this.label_Start.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.label_Start.Font = new System.Drawing.Font("宋体", 30F);
            this.label_Start.ForeColor = System.Drawing.Color.Snow;
            this.label_Start.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Start.Location = new System.Drawing.Point(0, 76);
            this.label_Start.Name = "label_Start";
            this.label_Start.Size = new System.Drawing.Size(64, 65);
            this.label_Start.TabIndex = 7;
            this.label_Start.Text = "▶";
            this.label_Start.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_Start.Click += new System.EventHandler(this.label7_Start_Click);
            // 
            // label_stop
            // 
            this.label_stop.BackColor = System.Drawing.Color.Transparent;
            this.label_stop.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.label_stop.Font = new System.Drawing.Font("宋体", 22F);
            this.label_stop.ForeColor = System.Drawing.Color.Snow;
            this.label_stop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_stop.Location = new System.Drawing.Point(0, 145);
            this.label_stop.Name = "label_stop";
            this.label_stop.Size = new System.Drawing.Size(64, 64);
            this.label_stop.TabIndex = 8;
            this.label_stop.Text = "■";
            this.label_stop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_stop.Click += new System.EventHandler(this.label6_stop_Click);
            // 
            // label_msg
            // 
            this.label_msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label_msg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_msg.Font = new System.Drawing.Font(".萍方-简", 19F);
            this.label_msg.ForeColor = System.Drawing.Color.Snow;
            this.label_msg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_msg.Location = new System.Drawing.Point(70, 9);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(464, 71);
            this.label_msg.TabIndex = 10;
            this.label_msg.Text = "This is a message!";
            this.label_msg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_msg.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 30;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label_CloseLCD
            // 
            this.label_CloseLCD.BackColor = System.Drawing.Color.Transparent;
            this.label_CloseLCD.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.label_CloseLCD.Font = new System.Drawing.Font("宋体", 35F);
            this.label_CloseLCD.ForeColor = System.Drawing.Color.Snow;
            this.label_CloseLCD.Location = new System.Drawing.Point(0, 215);
            this.label_CloseLCD.Name = "label_CloseLCD";
            this.label_CloseLCD.Size = new System.Drawing.Size(64, 64);
            this.label_CloseLCD.TabIndex = 11;
            this.label_CloseLCD.Text = "☼";
            this.label_CloseLCD.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_CloseLCD.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label_CloseLCD);
            this.Controls.Add(this.label_msg);
            this.Controls.Add(this.label_stop);
            this.Controls.Add(this.label_Start);
            this.Controls.Add(this.label_Timer);
            this.Controls.Add(this.label_NowDate);
            this.Controls.Add(this.label_Saying);
            this.Controls.Add(this.label_NowTime);
            this.Controls.Add(this.label_Hello);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "Form1";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Hello;
        private System.Windows.Forms.Label label_NowTime;
        private System.Windows.Forms.Label label_NowDate;
        private System.Windows.Forms.Label label_Saying;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_Timer;
        private System.Windows.Forms.Label label_Start;
        private System.Windows.Forms.Label label_stop;
        private System.Windows.Forms.Label label_msg;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label_CloseLCD;
    }
}

