using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOs333333
{
    public partial class user : Form
    {
        CMS Data;

        List< products> Pro = new List<products>();

        public List<Cate> Category = new List<Cate>();
        public List<Form> FrmProduct = new List<Form>();
        public List<Panel> ProductContainer = new List<Panel>();

        public List<TextBox> ProName = new List<TextBox>();
        public List<TextBox> ProPrice = new List<TextBox>();


        List<string> bTN_Name = new List<string>();
        List<string> CategoryID = new List<string>();
        List<Image> CategoryImg = new List<Image>();
        List<string> CateImg = new List<string>();

        List<Image> ProductImg = new List<Image>();
        List<string> ProImg = new List<string>();

        List<string> ProdName = new List<string>();
        List<string> ProductPrice = new List<string>();
        List<int> CategoryIDOfPr = new List<int>();
        List<int> ProductID = new List<int>();




        int i = 0;
        int v = 1;
        int x1 = 0;
        int y2 = 0;


        //كود مؤقت
        public List<String> username = new List<string>();
        List<String> password = new List<string>();
        List<String> userAddress = new List<string>();
        List<String> userEmail = new List<string>();
        StreamReader sr = new StreamReader("UserData.txt");

        public void readDataFromFile()
        {
            while (!sr.EndOfStream)
            {
                username.Add(sr.ReadLine());
                userEmail.Add(sr.ReadLine());
                userAddress.Add(sr.ReadLine());
                password.Add(sr.ReadLine());

            }
            sr.Close();
        }


        public int userNum;
       

        public user(int i)
        {
            readDataFromFile();
            this.userNum = i;

            InitializeComponent();

            Data = new CMS(bTN_Name, CategoryID, CategoryImg, CateImg, ProductImg, ProImg, ProdName, ProductPrice, CategoryIDOfPr, ProductID);
            ayzeft();
        }

        private void user_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public void ayzeft()
        {
           
            panel1.AutoScroll = true;
            panel1.Visible = true;

            int m = 0;

            for (i = 0; i < bTN_Name.Count; i++)
            {
                Category.Add(new Cate(bTN_Name[i]));

                if (i % 2 == 1) { x1 = 280; }
                else x1 = 0;


                if (i == 2) y2 = 155;
                if (i % 2 == 1 && i != 1)
                {
                    y2 = 155 * v;
                    v++;
                }


                Category[i].Location = new Point(x1, y2);
                //    x2 = x1;
                //    y2 = y1;

                panel1.Controls.Add(Category[i]);

                //******************************** Add Form of products for each category ************************

                FrmProduct.Add(new Form());
                FrmProduct[i].Text = bTN_Name[i];
                FrmProduct[i].StartPosition = FormStartPosition.CenterScreen;
                FrmProduct[i].Width = 400;
                FrmProduct[i].Height = 550;

                //****************************** Add products for each category **********************************


                //********************* Add Button & Panel Container to the form of Product *****************************




                ProductContainer.Add(new Panel());
                ProductContainer[i].AutoScroll = true;
                ProductContainer[i].Size = new Size(390, 350);
                FrmProduct[i].Controls.Add(ProductContainer[i]);
                ///////////////////////////////////////////

                //*****************Category images ***************
                for (int j = 0; j <= bTN_Name.Count; j++)
                {
                    if (Data.MyPic.Count > i && Data.MyPic[j] == bTN_Name[i])
                    {
                        //////////////////////////////
                        Category[i].Pic = Data.CategoryImg1[j];
                        break;
                    }
                }

                ///////////////////////////////////////////
                if (m != CategoryIDOfPr.Count)
                    while (CategoryIDOfPr[m] == int.Parse(Data.CategoryID1[i]))
                    {
                        Pro.Add(new products(ProdName[m], ProductPrice[m]));
                        //  Pro[m].Controls["textBox1"].Text = ProductName[m];
                        //  Pro[m].Controls["textBox2"].Text = ProductPrice[m];

                        Pro[m].Controls["Panel2"].Visible = true;

                        //  Pro.pic = Data.ProductImg[m];  //product image **********

                        int W = ProductContainer[i].Controls.Count;
                        Pro[m].Location = new Point(20, W * Pro[m].Height);

                        ProductContainer[i].Controls.Add(Pro[m]);
                        m++;
                        if (m == ProdName.Count) { break; }
                    }
            }


            for (int j = 0; j < bTN_Name.Count; j++) // if click the button of show products
            {
                var captured_j = j;  
                Category[j].Controls[1].Click += (s, ea) => FrmProduct[captured_j].ShowDialog();

            }


        }
    }
}
