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
        private List<Image> ProductImg = new List<Image>();
        private List<string> ProImge = new List<string>();


        public products()
        {
            InitializeComponent();
            ProImg x = new ProImg(ProductImg,ProImge);
        }

        public products(string Name,string Price) : this()
        {
            this.textBox1.Text = Name;
            this.textBox2.Text = Price;

            for (int i = 0; i < ProImge.Count; i++) {
                if (this.textBox1.Text == ProImge[i])
                {
                    pictureBox1.Image = ProductImg[i];
                }

                    }
 
               }

        string Line="";

        public Image pic
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

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
            
            pictureBox1.Image.Save("ProImg/" +textBox1.Text +".jpg");

       }


        private void button1_Click(object sender, EventArgs e)
        {
            

            StreamWriter sr = new StreamWriter("Orders.txt", true);
            Line = label1.Text + "," + textBox1.Text + "," + textBox2.Text + "," + numericUpDown1.Value +"," + "Pending" ;

            sr.WriteLine(Line);
            sr.Dispose();
        }
    }
}
