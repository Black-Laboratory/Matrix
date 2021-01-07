namespace Learn3DMatrix
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.xRotate = new System.Windows.Forms.CheckBox();
            this.yRotate = new System.Windows.Forms.CheckBox();
            this.zRotate = new System.Windows.Forms.CheckBox();
            this.mesh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 12);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Minimum = 250;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(151, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 250;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(169, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // xRotate
            // 
            this.xRotate.AutoSize = true;
            this.xRotate.Location = new System.Drawing.Point(14, 63);
            this.xRotate.Name = "xRotate";
            this.xRotate.Size = new System.Drawing.Size(66, 16);
            this.xRotate.TabIndex = 2;
            this.xRotate.Text = "X轴旋转";
            this.xRotate.UseVisualStyleBackColor = true;
            // 
            // yRotate
            // 
            this.yRotate.AutoSize = true;
            this.yRotate.Location = new System.Drawing.Point(86, 63);
            this.yRotate.Name = "yRotate";
            this.yRotate.Size = new System.Drawing.Size(66, 16);
            this.yRotate.TabIndex = 3;
            this.yRotate.Text = "Y轴旋转";
            this.yRotate.UseVisualStyleBackColor = true;
            // 
            // zRotate
            // 
            this.zRotate.AutoSize = true;
            this.zRotate.Location = new System.Drawing.Point(158, 63);
            this.zRotate.Name = "zRotate";
            this.zRotate.Size = new System.Drawing.Size(66, 16);
            this.zRotate.TabIndex = 4;
            this.zRotate.Text = "Z轴旋转";
            this.zRotate.UseVisualStyleBackColor = true;
            // 
            // mesh
            // 
            this.mesh.AutoSize = true;
            this.mesh.Location = new System.Drawing.Point(230, 63);
            this.mesh.Name = "mesh";
            this.mesh.Size = new System.Drawing.Size(48, 16);
            this.mesh.TabIndex = 5;
            this.mesh.Text = "Mesh";
            this.mesh.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.mesh);
            this.Controls.Add(this.zRotate);
            this.Controls.Add(this.yRotate);
            this.Controls.Add(this.xRotate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox xRotate;
        private System.Windows.Forms.CheckBox yRotate;
        private System.Windows.Forms.CheckBox zRotate;
        private System.Windows.Forms.CheckBox mesh;
    }
}

