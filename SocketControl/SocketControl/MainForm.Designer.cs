namespace SocketControl
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BT_Start = new System.Windows.Forms.Button();
            this.BT_Stop = new System.Windows.Forms.Button();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.LBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_Start
            // 
            this.BT_Start.Location = new System.Drawing.Point(90, 52);
            this.BT_Start.Name = "BT_Start";
            this.BT_Start.Size = new System.Drawing.Size(75, 23);
            this.BT_Start.TabIndex = 0;
            this.BT_Start.Text = "开始";
            this.BT_Start.UseVisualStyleBackColor = true;
            this.BT_Start.Click += new System.EventHandler(this.BT_Start_Click);
            // 
            // BT_Stop
            // 
            this.BT_Stop.Location = new System.Drawing.Point(90, 115);
            this.BT_Stop.Name = "BT_Stop";
            this.BT_Stop.Size = new System.Drawing.Size(75, 23);
            this.BT_Stop.TabIndex = 1;
            this.BT_Stop.Text = "停止";
            this.BT_Stop.UseVisualStyleBackColor = true;
            this.BT_Stop.Click += new System.EventHandler(this.BT_Stop_Click);
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Enabled = true;
            this.timer_Refresh.Tick += new System.EventHandler(this.timer_Refresh_Tick);
            // 
            // LBL
            // 
            this.LBL.AutoSize = true;
            this.LBL.Location = new System.Drawing.Point(3, 198);
            this.LBL.Name = "LBL";
            this.LBL.Size = new System.Drawing.Size(34, 13);
            this.LBL.TabIndex = 2;
            this.LBL.Text = "消息:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.LBL);
            this.Controls.Add(this.BT_Stop);
            this.Controls.Add(this.BT_Start);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_Start;
        private System.Windows.Forms.Button BT_Stop;
        private System.Windows.Forms.Timer timer_Refresh;
        private System.Windows.Forms.Label LBL;
    }
}

