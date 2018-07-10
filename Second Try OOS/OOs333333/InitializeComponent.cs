using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOs333333
{
    class InitializeComponent
    {
         public List<Cate> Category = new List<Cate>();
         public List<Form> FrmProduct = new List<Form>();
         public List<Panel> ProductContainer = new List<Panel>();
         
         public List<Button> AddProductBtn = new List<Button>();
         public List<TextBox> ProName = new List<TextBox>();
         public List<TextBox> ProPrice = new List<TextBox>();


       public CMS Data = new CMS();

        //        int i = 0;
        public InitializeComponent(Panel panel2)
        {
           // panel2 = new Panel();

            Data.ReadData();
            Data.ReadProducts();
            Data.PutProductToEachCategory();
            Data.LoadCategoryImg();
            Data.LoadProductImg();

            int m = 0;
            for (int i = 0; i < Data.Category.Count; i++)
            {
                Category.Add(new Cate(Data.Category[i]));

                Category[i].Location = new Point(150, ((i) * 155));
                
                panel2.Controls.Add(Category[i]);

                //******************************** Add Form of products for each category ************************

                FrmProduct.Add(new Form());
                FrmProduct[i].Text = Data.Category[i];
                FrmProduct[i].StartPosition = FormStartPosition.CenterScreen;
                FrmProduct[i].Width = 400;
                FrmProduct[i].Height = 550;

                //****************************** Add products for each category **********************************


                //********************* Add Button & Panel Container to the form of Product *****************************



                AddProductBtn.Add(new Button());
                AddProductBtn[i].Location = new Point(300, 400);
                AddProductBtn[i].Text = "Add new Product";
                FrmProduct[i].Controls.Add(AddProductBtn[i]);

                ProName.Add(new TextBox());
                ProPrice.Add(new TextBox());
                ProName[i].Location = new Point(10, 400);
                ProPrice[i].Location = new Point(10, 430);
                FrmProduct[i].Controls.Add(ProName[i]);
                FrmProduct[i].Controls.Add(ProPrice[i]);

                ProductContainer.Add(new Panel());
                ProductContainer[i].AutoScroll = true;
                ProductContainer[i].Size = new Size(390, 350);
                FrmProduct[i].Controls.Add(ProductContainer[i]);
                ///////////////////////////////////////////

                //*****************Category images ***************//

                if (Data.MyPic.Count > i && Data.MyPic[i] == Data.Category[i])
                {
                    //////////////////////////////
                    Category[i].Pic = Data.CategoryImg1[i];

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

            for (int j = 0; j < Data.Category.Count; j++)
            {
                var captured_j = j;  // to get the index of clicked Button
                AddProductBtn[j].Click += (s2, eao) =>
                {
                    int W = ProductContainer[captured_j].Controls.Count;  //to know how many product in this panel(Product container)

                    products New = new products();
                    New.Location = new Point(20, W * New.Height);
                    New.Controls[1].Text = ProName[captured_j].Text;
                    New.Controls[0].Text = ProPrice[captured_j].Text + "$";
                    ProductContainer[captured_j].Controls.Add(New);

                    StreamWriter SW = new StreamWriter("Products.txt", true);
                    SW.WriteLine((captured_j + 1000) + "," + W + "," + New.Controls[1].Text + "," + New.Controls[0].Text + "$");

                    SW.Dispose();

                };
            }

            //File.Delete("img//" + Data.Category[0] +".jpg");

            for (int T = 0; T < Data.Category.Count; T++)
            {

                var captured_T = T;  // to get the index of clicked Button
                Category[T].Controls["pictureBox1"].Click += (a, s) =>
                {
                    OpenFileDialog Of = new OpenFileDialog();
                    Of.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                    if (Of.ShowDialog() == DialogResult.OK)
                    {
                        Category[captured_T].Pic = Image.FromFile(Of.FileName);
                    }
                    Of.Dispose();

                    if (!Directory.Exists("img"))
                    {
                        Directory.CreateDirectory("img");
                    }

                    Category[captured_T].Pic.Save("img/" + Data.Category[captured_T] + ".jpg");

                    // MessageBox.Show("Data has been succefully saved ", textBox1.Text);

                };
            }


        }

        public InitializeComponent(TextBox textBox1, Panel panel1)
        {
            int i = Data.Category.Count ;
            if (textBox1.Text == "Name")
            {
                MessageBox.Show("Please Enter Name of Category", "Error");
            }
            else
            {
                int M = 0;
                bool AddedBefore = false;
                while (true)
                {
                    for (int j = 0; j < Data.Category.Count; j++)
                    {
                        if (textBox1.Text == Data.Category[j])
                        {
                            MessageBox.Show("This Category Has Been Added Before", "Error");
                            AddedBefore = true;
                            break;
                        }
                    }
                    if (AddedBefore == true)
                    {
                        break;
                    }
                    else
                    {
                        Data.Category.Add(textBox1.Text);
                        Category.Add(new Cate(Data.Category[i]));

                        if (i != 0)
                        {
                            int x = Category[i - 1].Location.X;
                            int y = Category[i - 1].Location.Y + Category[i - 1].Height;
                            Category[i].Location = new Point(20, y);

                        }
                        else
                        {
                            Category[i].Location = new Point(150, (i+1) * 140);
                        }

                        // Category[i].Text = textBox1.Text;
                        panel1.Controls.Add(Category[i]);


                        //******************************** Save image into file************************************************



                        //******************************** Add Form of products for each category ************************

                        FrmProduct.Add(new Form());
                        FrmProduct[i].Text = Data.Category[i];
                        FrmProduct[i].StartPosition = FormStartPosition.CenterScreen;
                        FrmProduct[i].Width = 400;
                        FrmProduct[i].Height = 550;

                        //********************* Add Button & Text Box to the form of Product *****************************

                        AddProductBtn.Add(new Button());
                        AddProductBtn[i].Location = new Point(300, 400);
                        AddProductBtn[i].Text = "Add new Product";
                        FrmProduct[i].Controls.Add(AddProductBtn[i]);

                        ProName.Add(new TextBox());
                        ProPrice.Add(new TextBox());
                        ProName[i].Location = new Point(10, 400);
                        ProPrice[i].Location = new Point(10, 430);
                        FrmProduct[i].Controls.Add(ProName[i]);
                        FrmProduct[i].Controls.Add(ProPrice[i]);

                        ProductContainer.Add(new Panel());
                        ProductContainer[i].AutoScroll = true;
                        ProductContainer[i].Size = new Size(390, 350);
                        FrmProduct[i].Controls.Add(ProductContainer[i]);


                        //************* Add List Boxes to the form of Product whcih would be contain products *************
                        if (Category[i].Pic == null)
                        {
                            Category[i].Pic = Image.FromFile("111.png");
                            if (!Directory.Exists("img"))
                            {
                                Directory.CreateDirectory("img");
                            }
                            Category[i].Pic.Save("img/" + Data.Category[i] + ".jpg");
                        }

                        for (int T = 0; T < Data.Category.Count; T++)
                        {
                            var captured_T = T;  // to get the index of clicked Button
                            Category[T].Controls["pictureBox1"].Click += (a, s) =>
                            {
                                Category[captured_T].Pic = null;
                                OpenFileDialog Of = new OpenFileDialog();
                                Of.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                                if (Of.ShowDialog() == DialogResult.OK)
                                {
                                    Category[captured_T].Pic = Image.FromFile(Of.FileName);
                                }
                                Of.Dispose();

                                if (!Directory.Exists("img"))
                                {
                                    Directory.CreateDirectory("img");
                                }
                                Category[captured_T].Pic.Save("img/" + Data.Category[captured_T] + ".jpg");
                                // MessageBox.Show("Data has been succefully saved ", textBox1.Text);

                            };


                        }
                        for (int j = 0; j < Data.Category.Count; j++)
                        {
                            var captured_j = j;  // to get the index of clicked Button
                            AddProductBtn[j].Click += (s2, eao) =>
                            {
                                int W = ProductContainer[captured_j].Controls.Count;

                                //ProductUC.Add(new products());

                                products New = new products();
                                New.Location = new Point(20, W * New.Height);
                                New.Controls[1].Text = ProName[captured_j].Text;
                                New.Controls[0].Text = ProPrice[captured_j].Text + "$";
                                ProductContainer[captured_j].Controls.Add(New);

                                StreamWriter SW = new StreamWriter("Products.txt", true);
                                SW.WriteLine((captured_j + 1000) + "," + W + "," + New.Controls[1].Text + "," + New.Controls[0].Text);
                                SW.Dispose();
                            };
                        }
                        for (int j = 0; j < Data.Category.Count; j++)
                        {
                            var captured_j = j;  // to get the index of clicked Button
                            Category[j].Controls[1].Click += (s, ea) => FrmProduct[captured_j].ShowDialog();  //if click on the button or first user control
                        }
                        i++;
                        MessageBox.Show("Data Has Been Saved Successfully", "Thank U :)");
                        break;
                    }
                    M++;
                }
            }
            Data.WriteData();
        }

    }
}
