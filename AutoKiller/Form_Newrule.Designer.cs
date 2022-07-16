namespace AutoKiller
{
    partial class Form_Newrule
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
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_content = new System.Windows.Forms.TextBox();
            this.button_complete = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // textbox_description
            // 
            this.textbox_description.Location = new System.Drawing.Point(62, 12);
            this.textbox_description.Name = "textbox_description";
            this.textbox_description.Size = new System.Drawing.Size(201, 23);
            this.textbox_description.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "规则：";
            // 
            // textBox_content
            // 
            this.textBox_content.Location = new System.Drawing.Point(62, 41);
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(201, 23);
            this.textBox_content.TabIndex = 3;
            // 
            // button_complete
            // 
            this.button_complete.Location = new System.Drawing.Point(152, 73);
            this.button_complete.Name = "button_complete";
            this.button_complete.Size = new System.Drawing.Size(75, 23);
            this.button_complete.TabIndex = 4;
            this.button_complete.Text = "完成";
            this.button_complete.UseVisualStyleBackColor = true;
            this.button_complete.Click += new System.EventHandler(this.button_complete_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(48, 73);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form_Newrule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 108);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_complete);
            this.Controls.Add(this.textBox_content);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textbox_description);
            this.Controls.Add(this.label1);
            this.Name = "Form_Newrule";
            this.Text = "Form_Newrule";
            this.Load += new System.EventHandler(this.Form_Newrule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textbox_description;
        private Label label2;
        private TextBox textBox_content;
        private Button button_complete;
        private Button button_cancel;
    }
}