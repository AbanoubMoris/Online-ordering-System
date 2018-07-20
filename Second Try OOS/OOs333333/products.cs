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
    public partial class products : UserControl
    {
        public products()
        {
            InitializeComponent();
            //panel2.AutoScroll = true;
        }

        string Line="";

        public Image pic
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

      //  public products(string UserName) : this()
      //  {
      //      Line = UserName + "," + textBox1.Text + "," + textBox2.Text + "," + numericUpDown1.Value ;
      //
      //  }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Of = new OpenFileDialog();
            Of.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (Of.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(Of.FileName);
            }
            Of.Dispose();
            if (!Directory.Exists("ProImg"))
            {
                Directory.CreateDirectory("ProImg");
            }
            //int fCount = Directory.GetFiles("ProImg","*", SearchOption.AllDirectories).Length;


            pictureBox1.Image.Save("ProImg/" +textBox1.Text +".jpg");

       }


        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter("Orders.txt", true);
            Line = label1.Text + "," + textBox1.Text + "," + textBox2.Text + "," + numericUpDown1.Value ;

            sr.WriteLine(Line);
            sr.Dispose();
        }
    }
}
