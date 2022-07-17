namespace AutoKiller
{
    partial class Form_Notice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Notice));
            this.pictureBox_info = new System.Windows.Forms.PictureBox();
            this.pictureBox_alert = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_alert)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_info
            // 
            this.pictureBox_info.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_info.Image")));
            this.pictureBox_info.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_info.Name = "pictureBox_info";
            this.pictureBox_info.Size = new System.Drawing.Size(66, 65);
            this.pictureBox_info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_info.TabIndex = 1;
            this.pictureBox_info.TabStop = false;
            // 
            // pictureBox_alert
            // 
            this.pictureBox_alert.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_alert.Image")));
            this.pictureBox_alert.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_alert.Name = "pictureBox_alert";
            this.pictureBox_alert.Size = new System.Drawing.Size(66, 65);
            this.pictureBox_alert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_alert.TabIndex = 2;
            this.pictureBox_alert.TabStop = false;
            this.pictureBox_alert.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "撤销修改并关闭程序";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(84, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(256, 105);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "操作所花费的时间比预期要长。";
            // 
            // Form_Notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 158);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox_alert);
            this.Controls.Add(this.pictureBox_info);
            this.Name = "Form_Notice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请耐心等待";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Notice_FormClosing);
            this.Load += new System.EventHandler(this.Form_Notice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_alert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox pictureBox_info;
        private PictureBox pictureBox_alert;
        private Button button1;
        private TextBox textBox1;
    }
}