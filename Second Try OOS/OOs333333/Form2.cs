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

namespace OOs333333
{
    public partial class Form2 : Form
    {
        List<Cate> Category = new List<Cate>();
        List<Form> FrmProduct = new List<Form>();
        List<Panel> ProductContainer = new List<Panel>();


        //List<products> ProductUC = new List<products>();
        List<Button> AddProductBtn = new List<Button>();
        List<TextBox> ProName = new List<TextBox>();
        List<TextBox> ProPrice = new List<TextBox>();


        CMS Data = new CMS();

        int i = 0;

        public Form2()
        {

            InitializeComponent();
            
           
            panel1.AutoScroll = true;
            panel1.HorizontalScroll.Visible = false;


          
            Data.ReadData();
            Data.ReadProducts();
            Data.PutProductToEachCategory();

            int m = 0;
                        for (i = 0; i < Data.Category.Count; i++)
                        {
                            Category.Add(new Cate(Data.Category[i]));   

                            Category[i].Location = new Point(20, ((i ) * 155));
                            panel1.Controls.Add(Category[i]);

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
                if (Data.CategoryIDOfPr.Count!=0)
                    while (Data.CategoryIDOfPr[m] == int.Parse(Data.CategoryID1[i]))
                    {
                        products Pro = new products();
                        Pro.Controls[1].Text = Data.ProductName[m];
                        Pro.Controls[0].Text = Data.ProductPrice[m];

                    int W = ProductContainer[i].Controls.Count;
                    Pro.Location = new Point(20, W * Pro.Height);

                    ProductContainer[i].Controls.Add(Pro);
                    m++;
                    if (m > Data.ProductName.Count) { break; }
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
                            AddProductBtn[j].Click += (s2, eao) => {
                            int W = ProductContainer[captured_j].Controls.Count;

                                products New = new products();


                                New.Location = new Point(20, W*New.Height);

                                New.Controls[1].Text = ProName[captured_j].Text;
                                New.Controls[0].Text = ProPrice[captured_j].Text +"$";

                                ProductContainer[captured_j].Controls.Add(New);

                                StreamWriter SW = new StreamWriter("Products.txt",true);
                                SW.WriteLine((captured_j + 1000) +","+ W +","+ New.Controls[1].Text +","+ New.Controls[0].Text + "$" );

                                SW.Dispose();

                                };
                        }
                
        }


        private void button1_Click(object sender, EventArgs e)
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
                            Category[i].Location = new Point(20, y);

                        }
                        else
                        {
                            Category[i].Location = new Point(20, i * 140);
                        }

                        // Category[i].Text = textBox1.Text;
                        panel1.Controls.Add(Category[i]);


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
                        for (int j = 0; j < Data.Category.Count; j++)
                        {
                            var captured_j = j;  // to get the index of clicked Button
                            AddProductBtn[j].Click += (s2, eao) => {
                                int W = ProductContainer[captured_j].Controls.Count;

                                //ProductUC.Add(new products());

                                products New = new products();


                                New.Location = new Point(20, W * New.Height);

                                New.Controls[1].Text = ProName[captured_j].Text;
                                New.Controls[0].Text = ProPrice[captured_j].Text + "$";

                                ProductContainer[captured_j].Controls.Add(New);

                                StreamWriter SW = new StreamWriter("Products.txt", true);
                                SW.WriteLine((captured_j + 1000) + "," + W + "," + New.Controls[1].Text + "," + New.Controls[0].Text );

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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }

}
