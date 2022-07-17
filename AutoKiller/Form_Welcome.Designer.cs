namespace AutoKiller
{
    partial class Form_Welcome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Welcome));
            this.button_new = new System.Windows.Forms.Button();
            this.listView_rules = new System.Windows.Forms.ListView();
            this.columnHeader_Name = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Content = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Count = new System.Windows.Forms.ColumnHeader();
            this.label_tips = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox_output = new System.Windows.Forms.RichTextBox();
            this.button_hide = new System.Windows.Forms.Button();
            this.notifyIcon_show = new System.Windows.Forms.NotifyIcon(this.components);
            this.button_deleterule = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_new
            // 
            this.button_new.Location = new System.Drawing.Point(12, 12);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(75, 23);
            this.button_new.TabIndex = 0;
            this.button_new.Text = "新建规则";
            this.button_new.UseVisualStyleBackColor = true;
            this.button_new.Click += new System.EventHandler(this.button_new_Click);
            // 
            // listView_rules
            // 
            this.listView_rules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_rules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Name,
            this.columnHeader_Content,
            this.columnHeader_Count});
            this.listView_rules.Location = new System.Drawing.Point(6, 22);
            this.listView_rules.Name = "listView_rules";
            this.listView_rules.Size = new System.Drawing.Size(600, 340);
            this.listView_rules.TabIndex = 1;
            this.listView_rules.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader_Name
            // 
            this.columnHeader_Name.Text = "名称";
            this.columnHeader_Name.Width = 300;
            // 
            // columnHeader_Content
            // 
            this.columnHeader_Content.Text = "规则";
            this.columnHeader_Content.Width = 200;
            // 
            // columnHeader_Count
            // 
            this.columnHeader_Count.Text = "拦截启动次数";
            this.columnHeader_Count.Width = 100;
            // 
            // label_tips
            // 
            this.label_tips.AutoSize = true;
            this.label_tips.Location = new System.Drawing.Point(12, 48);
            this.label_tips.Name = "label_tips";
            this.label_tips.Size = new System.Drawing.Size(538, 17);
            this.label_tips.TabIndex = 2;
            this.label_tips.Text = "今天共禁止了_____个进程自启动，启用以来共禁止了_____个程序恶意自启动，明天也要好好努力哦！";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.richTextBox_output);
            this.groupBox1.Controls.Add(this.listView_rules);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1047, 368);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // richTextBox_output
            // 
            this.richTextBox_output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_output.Location = new System.Drawing.Point(614, 22);
            this.richTextBox_output.Name = "richTextBox_output";
            this.richTextBox_output.Size = new System.Drawing.Size(427, 340);
            this.richTextBox_output.TabIndex = 2;
            this.richTextBox_output.Text = "";
            // 
            // button_hide
            // 
            this.button_hide.Location = new System.Drawing.Point(93, 12);
            this.button_hide.Name = "button_hide";
            this.button_hide.Size = new System.Drawing.Size(75, 23);
            this.button_hide.TabIndex = 4;
            this.button_hide.Text = "隐藏窗口";
            this.button_hide.UseVisualStyleBackColor = true;
            this.button_hide.Click += new System.EventHandler(this.button_hide_Click);
            // 
            // notifyIcon_show
            // 
            this.notifyIcon_show.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_show.Icon")));
            this.notifyIcon_show.Text = "AutoKiller (万叶限定版）";
            this.notifyIcon_show.Visible = true;
            this.notifyIcon_show.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_show_MouseDoubleClick);
            // 
            // button_deleterule
            // 
            this.button_deleterule.Location = new System.Drawing.Point(174, 12);
            this.button_deleterule.Name = "button_deleterule";
            this.button_deleterule.Size = new System.Drawing.Size(92, 23);
            this.button_deleterule.TabIndex = 5;
            this.button_deleterule.Text = "删除所选规则";
            this.button_deleterule.UseVisualStyleBackColor = true;
            this.button_deleterule.Click += new System.EventHandler(this.button_deleterule_Click);
            // 
            // Form_Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 450);
            this.Controls.Add(this.button_deleterule);
            this.Controls.Add(this.button_hide);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_tips);
            this.Controls.Add(this.button_new);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Welcome";
            this.Text = "AutoKiller（万叶限定版）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Welcome_FormClosing);
            this.Load += new System.EventHandler(this.Form_Welcome_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_new;
        private ListView listView_rules;
        private Label label_tips;
        private GroupBox groupBox1;
        private RichTextBox richTextBox_output;
        private ColumnHeader columnHeader_Name;
        private ColumnHeader columnHeader_Content;
        private ColumnHeader columnHeader_Count;
        private Button button_hide;
        private NotifyIcon notifyIcon_show;
        private Button button_deleterule;
    }
}