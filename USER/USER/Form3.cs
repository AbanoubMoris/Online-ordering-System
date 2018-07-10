using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USER
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show(); 
        }
        List<String> username = new List<string>();
        List<String> password = new List<string>();
        List<String> userEmail = new List<string>();
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(username,password, userEmail);
            this.Hide();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.Show();
        }
    }
}
