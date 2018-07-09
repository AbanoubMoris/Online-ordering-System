using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class UserControl1 : UserControl
    {
        List<Status> list = new List<Status>();

        public UserControl1()
        {
            InitializeComponent();
        }

        public ComboBox Combo1{
            get { return comboBox1; }
            set { comboBox1 = value; }
            }

        public Status selectedStatus
        {
            get
            {
                return (Status)comboBox1.SelectedItem;
            }
           
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
          //  list.Add(new Status() { ID = 1, name = "Pending" });
          //  list.Add(new Status() { ID = 2, name = "In-Progress" });
          //  list.Add(new Status() { ID = 3, name = "Delivered" });
          //  comboBox1.DataSource = list;
          //  comboBox1.ValueMember = "ID";
          //  comboBox1.DisplayMember = "name";
          //  comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
          //  label7.Hide();
          //  textBox1.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        int duration = 30;

        private void button1_Click(object sender, EventArgs e)
        {
            //******************************
            StreamWriter Choosed = new StreamWriter("List.txt",true);
            Choosed.WriteLine(comboBox1.Text);
            Choosed.Dispose();



            if (button1.Text == "Cancel") { label7.Text = "Time Till Delivered"; duration = 30; textBox1.Hide(); label7.Hide(); button1.Text = "Confirm"; timer1.Stop(); comboBox1.SelectedIndex = 0; }
            else
            {
                textBox1.Text = "30s";
                textBox1.Show();
                label7.Show();
                button1.Text = "Cancel";
                timer1.Enabled = true;
                timer1.Start();
                comboBox1.SelectedIndex = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            duration--;
            textBox1.Text = duration.ToString() + "s";
            if(duration == 0) { timer1.Stop(); comboBox1.SelectedIndex = 2; textBox1.Text = ""; label7.Text = "Delivered!!"; }
        }
    }
}
