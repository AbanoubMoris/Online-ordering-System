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

        List<Button> Category = new List<Button>();
        List<Form> FrmProduct = new List<Form>();
        List<ListBox> Product = new List<ListBox>();
        List<Button> AddProductBtn = new List<Button>();
        //   List<Color> BtnColor = new List<Color>();

        List<TextBox> AddText = new List<TextBox>();

        CMS Data = new CMS();
        int i = 0;

        public Form2()
        {

            InitializeComponent();

            //      BtnColor.Add(new Color());

            panel1.AutoScroll = true;
            panel1.HorizontalScroll.Visible = false;



            int Num_Of_Pts = new int();
            Data.ReadData(ref Num_Of_Pts);
            Data.ReadProducts();

            for (i = 0; i < Num_Of_Pts; i++)
            {
                Category.Add(new Button());
                Point p = new Point(20, ((i + 1) * 35));
                Category[i].Location = p;
                Category[i].Width = 160;
                Category[i].Height = 30;
                Category[i].BackColor = Color.Bisque;
                //   Category[i].BackColor = BtnColor[i];
                Category[i].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                Category[i].Text = Data.BTN_Name[i];
                panel1.Controls.Add(Category[i]);

                //******************************** Add Form of products for each category ************************

                FrmProduct.Add(new Form());
                FrmProduct[i].Text = Data.BTN_Name[i];
                FrmProduct[i].StartPosition = FormStartPosition.CenterScreen;
                FrmProduct[i].Width = 400;
                FrmProduct[i].Height = 550;

                //********************* Add Button & Text Box to the form of Product *****************************

                AddProductBtn.Add(new Button());
                AddProductBtn[i].Location = new Point(290, 360);
                AddProductBtn[i].Text = "Add New Product";
                FrmProduct[i].Controls.Add(AddProductBtn[i]);


                AddText.Add(new TextBox());
                AddText[i].Location = new Point(20, 360);
                AddText[i].Width = 200;
                FrmProduct[i].Controls.Add(AddText[i]);
                //************* Add List Boxes to the form of Product whcih would be contain products ************

                Data.ProductList.Add(new ListBox());

                Data.ProductList[i].Location = new Point(20, 60);
                Data.ProductList[i].Height = 300;
                Data.ProductList[i].Width = 340;

                FrmProduct[i].Controls.Add(Data.ProductList[i]);

                //     FrmProduct[i].Controls.Add(Product[i]);


            }


            for (int j = 0; j < Data.BTN_Name.Count; j++)
            {
                var captured_j = j;  // to get the index of clicked Button
                Category[j].Click += (s, ea) => FrmProduct[captured_j].ShowDialog();

            }

            for (int j = 0; j < Data.BTN_Name.Count; j++)
            {
                var captured_j = j;  // to get the index of clicked Button
                AddProductBtn[j].Click += (s2, eao) => Data.ProductList[captured_j].Items.Add(AddText[captured_j].Text);
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
                    
                        for (int j = 0; j < Data.BTN_Name.Count; j++)
                        {
                            if (textBox1.Text == Data.BTN_Name[j])
                            {
                                MessageBox.Show("This Category Has Been Added Before", "Error");
                                AddedBefore = true;
                                break;
                            }
                        }
                  if (AddedBefore==true)
                    {
                        break;
                    }   
                  else
                   {
                        //textBox2.Click += (s, a) =>
                        //{
                        //    DialogResult Result = colorDialog1.ShowDialog();
                        //    if (Result == DialogResult.OK)
                        //    {
                        //  //      BtnColor.Add(new Color());
                        //    //    BtnColor[i] = colorDialog1.Color;
                        //    }
                        //};



                        Data.BTN_Name.Add(textBox1.Text);
                        Category.Add(new Button());
                        Category[i].Width = 160;
                        Category[i].Height = 30;
                        Category[i].BackColor = Color.Bisque;
                        //   Category[i].BackColor = BtnColor[i];
                        Category[i].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                        if (i != 0)
                        {
                            int x = Category[i - 1].Location.X;
                            int y = Category[i - 1].Location.Y + Category[i - 1].Height + 5;
                            Category[i].Location = new Point(20, y);

                        }
                        else
                        {
                            Category[i].Location = new Point(20, 35);
                        }
                        Category[i].Text = textBox1.Text;
                        panel1.Controls.Add(Category[i]);


                        //******************************** Add Form of products for each category ************************

                        FrmProduct.Add(new Form());
                        FrmProduct[i].Text = Data.BTN_Name[i];
                        FrmProduct[i].StartPosition = FormStartPosition.CenterScreen;
                        FrmProduct[i].Width = 400;
                        FrmProduct[i].Height = 550;

                        //********************* Add Button & Text Box to the form of Product *****************************
                        AddProductBtn.Add(new Button());
                        AddProductBtn[i].Location = new Point(290, 360);
                        AddProductBtn[i].Text = "Name";
                        FrmProduct[i].Controls.Add(AddProductBtn[i]);

                        
                        AddText.Add(new TextBox());
                        AddText[i].Location = new Point(20, 360);
                        AddText[i].Width = 200;
                        FrmProduct[i].Controls.Add(AddText[i]);

                        //************* Add List Boxes to the form of Product whcih would be contain products ************

                        Data.ProductList.Add(new ListBox());

                        Data.ProductList[i].Location = new Point(20, 60);
                        Data.ProductList[i].Height = 300;
                        Data.ProductList[i].Width = 340;

                        FrmProduct[i].Controls.Add(Data.ProductList[i]);


                        for (int k = 0; k < Data.BTN_Name.Count; k++)
                        {
                            var captured_j = k;  // to get the index of clicked Button
                            Category[k].Click += (s, ea) => FrmProduct[captured_j].ShowDialog();

                        }
                        for (int k = 0; k < Data.BTN_Name.Count; k++)
                        {
                            var captured_j = k;  // to get the index of clicked Button
                            AddProductBtn[k].Click += (s2, eao) => Data.ProductList[captured_j].Items.Add(AddText[captured_j].Text);
                        }



                        i++;
                        MessageBox.Show("Data Has Been Saved Successfully", "Thank U :)");
                        break;
                    } 


                    M++;

                }

                //int j;
                //for (j = 0; j <= Data.BTN_Name.Count; j++)
                //{
                //    if (j != 0)
                //    {
                        
                //        if (textBox1.Text == Data.BTN_Name[j])
                //        {
                //            MessageBox.Show("This Category Has Been Added Before", "Error");
                //            break;
                //        }
                //    }
                //    else
                //    {
                //        //textBox2.Click += (s, a) =>
                //        //{
                //        //    DialogResult Result = colorDialog1.ShowDialog();
                //        //    if (Result == DialogResult.OK)
                //        //    {
                //        //  //      BtnColor.Add(new Color());
                //        //    //    BtnColor[i] = colorDialog1.Color;
                //        //    }
                //        //};



                //        Data.BTN_Name.Add(textBox1.Text);
                //        Category.Add(new Button());
                //        Category[i].Width = 160;
                //        Category[i].Height = 30;
                //        Category[i].BackColor = Color.Bisque;
                //        //   Category[i].BackColor = BtnColor[i];
                //        Category[i].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                //        if (i != 0)
                //        {
                //            int x = Category[i - 1].Location.X;
                //            int y = Category[i - 1].Location.Y + Category[i - 1].Height + 5;
                //            Category[i].Location = new Point(20, y);

                //        }
                //        else
                //        {
                //            Category[i].Location = new Point(20, 35);
                //        }
                //        Category[i].Text = textBox1.Text;
                //        panel1.Controls.Add(Category[i]);


                //        //******************************** Add Form of products for each category ************************

                //        FrmProduct.Add(new Form());
                //        FrmProduct[i].Text = Data.BTN_Name[i];
                //        FrmProduct[i].StartPosition = FormStartPosition.CenterScreen;
                //        FrmProduct[i].Width = 400;
                //        FrmProduct[i].Height = 550;

                //        //********************* Add Button & Text Box to the form of Product *****************************
                //        AddProductBtn.Add(new Button());
                //        AddProductBtn[i].Location = new Point(290, 360);
                //        AddProductBtn[i].Text = "Name";
                //        FrmProduct[i].Controls.Add(AddProductBtn[i]);


                //        AddText.Add(new TextBox());
                //        AddText[i].Location = new Point(20, 360);
                //        AddText[i].Width = 200;
                //        FrmProduct[i].Controls.Add(AddText[i]);

                //        //************* Add List Boxes to the form of Product whcih would be contain products ************

                //        Data.ProductList.Add(new ListBox());

                //        Data.ProductList[i].Location = new Point(20, 60);
                //        Data.ProductList[i].Height = 300;
                //        Data.ProductList[i].Width = 340;

                //        FrmProduct[i].Controls.Add(Data.ProductList[i]);


                //        for (int k = 0; k < Data.BTN_Name.Count; k++)
                //        {
                //            var captured_j = k;  // to get the index of clicked Button
                //            Category[k].Click += (s, ea) => FrmProduct[captured_j].ShowDialog();

                //        }
                //        for (int k = 0; k < Data.BTN_Name.Count; k++)
                //        {
                //            var captured_j = k;  // to get the index of clicked Button
                //            AddProductBtn[k].Click += (s2, eao) => Data.ProductList[captured_j].Items.Add(AddText[captured_j].Text);
                //        }



                //        i++;
                //        MessageBox.Show("Data Has Been Saved Successfully", "Thank U :)");
                //        break;
                //    }
                //}

            }
            Data.WriteData();

        }



        private void button2_Click(object sender, EventArgs e)
        {
            Data.WriteProduct();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            //    DialogResult Result =colorDialog1.ShowDialog();
            //    if (Result == DialogResult.OK)
            //    {
            //        BtnColor.Add(new Color());
            //         BtnColor[i]=colorDialog1.Color;
            //    }
        }
    }

}
