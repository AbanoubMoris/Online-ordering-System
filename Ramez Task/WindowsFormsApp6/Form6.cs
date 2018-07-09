using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp6
{
    public partial class Form6 : Form
    {
        List<Status> S = new List<Status>();
        List<UserControl1> list = new List<UserControl1>();

        public Form6()
        {
            InitializeComponent();
            panel1.AutoScroll = true;


            StreamReader SR = new StreamReader("List.txt");
            int i = 0;
            while (!SR.EndOfStream)
            {
               S.Add(new Status());
               S[i].ID = i;

               S[i].name = SR.ReadLine();
               S[i].ID = Int32.Parse(SR.ReadLine());

               


               i++;
            }
            SR.Dispose();



            for (int j = 0; j < i; j++)
                 {
               list.Add(new UserControl1());
               list[j].Location = new Point(10, j * list[0].Height+15);
               //*********************************************************
               //combobox1.selectedindex=index
               list[j].Combo1.DataSource = S;
               list[j].Combo1.ValueMember = "ID";
               list[j].Combo1.DisplayMember = "name";
               list[j].Combo1.DropDownStyle = ComboBoxStyle.DropDownList;

                //**********************************************************
                panel1.Controls.Add(list[j]);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            this.Hide();
            f5.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}
