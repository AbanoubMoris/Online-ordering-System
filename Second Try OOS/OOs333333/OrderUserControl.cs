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
        private List<Image> ProductImg = new List<Image>();
        private List<string> ProImge = new List<string>();
        string status = "Pending";


        List<string> Line = new List<string>();
        public void ReadOrders()
        {
            int i = 0;

            StreamReader sr = new StreamReader("Orders.txt");
            while (!sr.EndOfStream)
            {
                Line.Add(sr.ReadLine());
                string[] Token = Line[i].Split(',');

                if (Token[4] == "Delivered" || Token[4] == "In-Progress")
                {
                    Line.RemoveAt(i);
                }
                else
                    i++;
            }

            sr.Dispose();
        }

        public void WriteOrders()
        {
            ReadOrders();
            StreamWriter sw = new StreamWriter("Orders.txt");
            for (int i = 0; i < Line.Count; i++)
            {
                sw.WriteLine(Line[i]);
            }
            sw.Dispose();
        }
        public OrderUserControl()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

            ProImg x = new ProImg(ProductImg, ProImge);
            

        }
        public OrderUserControl(string ProductName) : this()
        {
            this.Product.Text = ProductName;

            for (int i = 0; i < ProImge.Count; i++)
            {
                if (ProductName == ProImge[i])
                {
                    pictureBox1.Image = ProductImg[i];
                }

            }
        }

        public OrderUserControl(string UserName, string ProductName, string Price, string Quantity, string Status,Panel pnl) : this()
        {
            StatusLbl.Text = Status;
            this.Product.Text = ProductName;
            this.Quantity.Text = Quantity;
            this.Price.Text = Price;
            this.CustName.Text = UserName;

            for (int i = 0; i < ProImge.Count; i++)
            {
                if (ProductName == ProImge[i])
                {
                    pictureBox1.Image = ProductImg[i];
                }

            }


        

            panel1.Visible = true;
            panel2.Visible = true;
            this.Location = new Point(60, pnl.Controls.Count * this.Height);
            pnl.Controls.Add(this);
        }

       
    
    

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();
            timer1.Enabled = true;
          
        }

        int duration = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
                Time.Text = duration.ToString();
            duration--;
            Time.Show();
            comboBox1.SelectedIndex = 1;
                if(duration == -1 )
                {
                
                    status = "Delivered";
                comboBox1.SelectedIndex = 2;
                //   this.Hide();

              //  StreamWriter sr = new StreamWriter("AdminOrders.txt");
                Line.Add(CustName.Text + ","+Product.Text + "," + Price.Text +","+ Quantity.Text + ","  + status);
            //    sr.WriteLine(Line);
              //  sr.Dispose();

                WriteOrders();
                
                timer1.Stop();
                
                }
            
        }
    }
}
