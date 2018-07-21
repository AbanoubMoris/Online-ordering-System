using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OOs333333
{
    public partial class OrderUserControl : UserControl
    {
        public OrderUserControl()
        {
            InitializeComponent();
        }
        public OrderUserControl(string Status) : this()
        {
            StatusLbl.Text = Status;
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter("AdminOrders.txt", true);
            string Line = Product.Text + "," + comboBox1.Text + "," + Quantity.Text + "," + Price.Text + "," + CustName.Text;
            sr.WriteLine(Line);
            sr.Dispose();
        }
    }
}
