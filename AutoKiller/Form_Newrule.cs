using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoKiller
{
    public partial class Form_Newrule : Form
    {
        public Form_Newrule()
        {
            InitializeComponent();
        }

        private void Form_Newrule_Load(object sender, EventArgs e)
        {
            
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static event Action<string, string> NewruleCompleted;

        private void button_complete_Click(object sender, EventArgs e)
        {
            NewruleCompleted(textBox_content.Text, textbox_description.Text);
            Close();
        }
    }
}
