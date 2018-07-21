﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace OOs333333
{
    public partial class Form1 : Form
    {
        CMS Data;
       public List<Cate> Category = new List<Cate>();
       public List<Form> FrmProduct = new List<Form>();
       public List<Panel> ProductContainer = new List<Panel>();
      
       public List<Button> AddProductBtn = new List<Button>();
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



        
        

        OnlineOrders GetOrders;




        int i = 0;
        int v = 1;
        int x1=0;
        int y2=0;



        public Form1()
        {
            InitializeComponent();



            Data = new CMS( bTN_Name,  CategoryID, CategoryImg, CateImg, ProductImg, ProImg,  ProductName, ProductPrice, CategoryIDOfPr,ProductID);

            Data.ReadData();
            Data.ReadProducts();
            Data.PutProductToEachCategory();
            Data.LoadCategoryImg();
            Data.LoadProductImg();
          



        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button1.BackColor = Color.FromArgb(44, 146, 234);

            //Form2 CMS = new Form2();
            //   this.Hide();
            //CMS.ShowDialog();
            ShowUser.Visible = false;
            OnlineOrderPanel.Visible = false;

            panel6.Visible = true;
            panel5.AutoScroll = true;
            panel5.Visible = true;




            int m = 0;

            for (i = 0; i < Data.Category.Count; i++)
            {
                Category.Add(new Cate(Data.Category[i]));

                if (i % 2 == 1) { x1 = 280; }
                else x1 = 0;


                if (i == 2) y2 = 155;
                if (i%2==1 && i!=1){
                    y2 = 155 * v;
                    v++;
                }


                Category[i].Location = new Point(x1, y2);
            //    x2 = x1;
            //    y2 = y1;

                panel5.Controls.Add(Category[i]);

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
                        Pro.Controls["textBox1"].Text = Data.ProductName[m];
                        Pro.Controls["textBox2"].Text = Data.ProductPrice[m];


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
                    New.Controls["textBox1"].Text = ProName[captured_j].Text;
                    New.Controls["textBox2"].Text = ProPrice[captured_j].Text + "$";


                    ProductContainer[captured_j].Controls.Add(New);

                    StreamWriter SW = new StreamWriter("Products.txt", true);
                    SW.WriteLine((captured_j + 1000) + "," + W + "," + New.Controls["textBox1"].Text + "," + New.Controls["textBox2"].Text);
                    

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

        private void button3_Click(object sender, EventArgs e) // online order button
        {
            List<OrderUserControl> Order = new List<OrderUserControl>();


            List<string> UserName = new List<string>();
            List<string> ProNam = new List<string>();
            List<int> Price = new List<int>();
            List<int> Quantity = new List<int>();

            GetOrders = new OnlineOrders(UserName, ProNam, Price, Quantity);



            panel5.Visible = false;
            ShowUser.Visible = false;
            OnlineOrderPanel.Visible = true;
            OnlineOrderPanel.AutoScroll = true;

            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.FromArgb(44, 146, 234);

            for (int j=0;j < UserName.Count; j++)
            {
                //****************Intialize OrderUserControl *****************************
                Order.Add(new OrderUserControl());
                Order[j].Controls["CustName"].Text = UserName[j];

                //UserName, ProNam, Price, Quantity

                Order[j].Controls["Product"].Text = ProNam[j];

                Order[j].Controls["Quantity"].Text = Quantity[j].ToString();
                Order[j].Controls["Price"].Text = (Price[j] * Convert.ToUInt32(Order[j].Controls["Quantity"].Text)).ToString(); //total price

                Order[j].Location = new Point(60, OnlineOrderPanel.Controls.Count * Order[j].Height);

                OnlineOrderPanel.Controls.Add(Order[j]); 

            } 




        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> UserName = new List<string>();
            List<string> ProductName = new List<string>();
            List<string> Price = new List<string>();
            List<string> Quantity = new List<string>();
            List<string> status = new List<string>();

            List<OrderUserControl> UserControl = new List<OrderUserControl>();

            UserOrders ShowOrders = new UserOrders(UserName, ProductName, Price, Quantity, status);


            panel5.Visible = false;
            OnlineOrderPanel.Visible = false;

            ShowUser.Visible = true;
            ShowUser.AutoScroll = true;

             for (int j = 0; j < UserName.Count; j++)
            {
                //****************Intialize OrderUserControl *****************************
                UserControl.Add(new OrderUserControl(status[j]));
                //UserControl.Add(new OrderUserControl());

                //    UserControl[j].Controls["CustName"].Text = UserName[j];
                //
                //    //UserName, ProNam, Price, Quantity
                //
                //    UserControl[j].Controls["Product"].Text = ProductName[j];
                //    UserControl[j].Controls["Quantity"].Text = Quantity[j].ToString();
                //    UserControl[j].Controls["Price"].Text =  //total price
                UserControl[j].Location = new Point(60, 300);

                ShowUser.Controls.Add(UserControl[j]);
 
            }



            button1.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button2.BackColor = Color.FromArgb(44, 146, 234);

           

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

                          
                           
                           
        private void button4_Click(object sender, EventArgs e)
        {
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
                            //int y = panel5.Controls.Count/2 * 155;
                            Category[i].Location = new Point(150, y);



                            }
                        else
                        {
                            Category[i].Location = new Point(150, i * 140);
                        }

                        // Category[i].Text = textBox1.Text;
                        panel5.Controls.Add(Category[i]);


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
                                New.Controls["textBox1"].Text = ProName[captured_j].Text;
                                New.Controls["textBox2"].Text = ProPrice[captured_j].Text + "$";

                                StreamWriter SW = new StreamWriter("Products.txt", true);
                                SW.WriteLine((captured_j + 1000) + "," + W + "," + ProName[captured_j].Text + "," + New.Controls["textBox2"].Text);
                                SW.Dispose();

                                ProductContainer[captured_j].Controls.Add(New);

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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
