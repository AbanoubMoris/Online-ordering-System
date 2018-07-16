using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOs333333
{
    public partial class user : Form
    {
        CMS Data;
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

        List<string> ProductName = new List<string>();
        List<string> ProductPrice = new List<string>();
        List<int> CategoryIDOfPr = new List<int>();
        List<int> ProductID = new List<int>();




        int i = 0;
        int v = 1;
        int x1 = 0;
        int y2 = 0;




        public user()
        {
            InitializeComponent();
            Data = new CMS(bTN_Name, CategoryID, CategoryImg, CateImg, ProductImg, ProImg, ProductName, ProductPrice, CategoryIDOfPr, ProductID);
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
            Data.ReadData();
            Data.ReadProducts();
            Data.PutProductToEachCategory();
            Data.LoadCategoryImg();
            Data.LoadProductImg();


            panel1.AutoScroll = true;
            panel1.Visible = true;




            int m = 0;

            for (i = 0; i < Data.Category.Count; i++)
            {
                Category.Add(new Cate(Data.Category[i]));

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
                FrmProduct[i].Text = Data.Category[i];
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
                for (int j = 0; j <= Data.Category.Count; j++)
                {
                    if (Data.MyPic.Count > i && Data.MyPic[j] == Data.Category[i])
                    {
                        //////////////////////////////
                        Category[i].Pic = Data.CategoryImg1[j];
                        break;
                    }
                }

                ///////////////////////////////////////////
                if (m != Data.CategoryIDOfPr.Count)
                    while (Data.CategoryIDOfPr[m] == int.Parse(Data.CategoryID1[i]))
                    {
                        products Pro = new products();
                        Pro.Controls[1].Text = Data.ProductName[m];
                        Pro.Controls[0].Text = Data.ProductPrice[m];


                        //  Pro.pic = Data.ProductImg[m];  //product image **********

                        int W = ProductContainer[i].Controls.Count;
                        Pro.Location = new Point(20, W * Pro.Height);

                        ProductContainer[i].Controls.Add(Pro);
                        m++;
                        if (m == Data.ProductName.Count) { break; }
                    }

            }


            for (int j = 0; j < Data.Category.Count; j++)
            {
                var captured_j = j;  // to get the index of clicked Button
                Category[j].Controls[1].Click += (s, ea) => FrmProduct[captured_j].ShowDialog();

            }

          

            //File.Delete("img//" + Data.Category[0] +".jpg");

            

        }
    }
}
