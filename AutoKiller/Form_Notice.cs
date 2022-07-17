using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#pragma warning disable IDE1006 // 命名样式

namespace AutoKiller
{
    public partial class Form_Notice : Form
    {
        public Form_Notice()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form_Notice_Load(object sender, EventArgs e)
        {
            Form_Welcome.LongTimeActionCompleted += () => Close();
            Thread.Sleep(1000);
            timer = new(obj =>
            {
                pictureBox_info.Visible = false;
                pictureBox_alert.Visible = true;
                button1.Visible = true;
                textBox1.Text = "操作超时。您可以继续等待，程序可能会响应，完成后本窗口会自动关闭。" +
                "如果点击下方的“撤销修改并关闭程序”或关闭此窗口，将会关闭服务，保存状态并关闭程序。注意：并不保证一定能够成功撤销操作。";
            }, null, 5000, Timeout.Infinite);
        }

        private System.Threading.Timer? timer;
        public static event Action? CancelAndClose;

        private void button1_Click(object sender, EventArgs e)
        {
            CancelAndClose?.Invoke();
        }

        private void Form_Notice_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer?.Dispose();
        }
    }
}
