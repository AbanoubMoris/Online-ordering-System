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
        public OrderUserControl(string ProductName,string Status,string Quantity,string Price,string UserName,Panel pnl) : this()
        {
            StatusLbl.Text = Status;
            this.Product.Text = ProductName;
            this.Quantity.Text = Quantity;
            this.Price.Text = Price;
            this.CustName.Text = UserName;

            panel1.Visible = true;
            panel2.Visible = true;
            this.Location = new Point(60, pnl.Controls.Count * this.Height);
            pnl.Controls.Add(this);
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
