using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace OOs333333
{
    class CMS
    {
        public List<string> BTN_Name = new List<string>();
        public List<string> Items = new List<string>();
        public List<ListBox> ProductList = new List<ListBox>();
        public List<Color> BtnColor = new List<Color>();
        private List<string> Y = new List<string>();

        public void ReadData(ref int Num_Pts)
        {
            StreamReader Data = new StreamReader("BTNS.txt");

            while (!Data.EndOfStream)
            {
                BTN_Name.Add(Data.ReadLine());
                Num_Pts++;
            }
            Data.Dispose();

        }



        public void WriteData()
        {
            StreamWriter BTNS = new StreamWriter("BTNS.txt");
            for (int i = 0; i < BTN_Name.Count; i++)
            {
                BTNS.WriteLine(BTN_Name[i]);
          //      BTNS.WriteLine(BtnColor[i]);
            }
            BTNS.Dispose();
        }

        public void ReadProducts()
        {
            StreamReader Products = new StreamReader("Products.txt");

            while (!Products.EndOfStream)
            {

                Items.Add(Products.ReadLine());
             
            }
            Products.Dispose();
            int i = 0;
            int j = 0;
            while (i < Items.Count && j<Items.Count) 
            {
               
                
                ProductList.Add(new ListBox());
                ProductList[i].Location = new Point(20, 60);
                ProductList[i].Height = 300;
                ProductList[i].Width = 340;



                while (Items[j]!= "*************")
                {
                    ProductList[i].Items.Add(Items[j]);
                j++;
                }
                j++;
                i++;
            }
            Products.Dispose();
        }

        public void WriteProduct()
        {
            StreamWriter Products = new StreamWriter("Products.txt");
            for (int i = 0; i < ProductList.Count; i++)
            {
                for (int j = 0; j < ProductList[i].Items.Count; j++)
                {
                    Products.WriteLine(ProductList[i].Items[j]);
                }
                Products.WriteLine("*************");
            }
            Products.Dispose();
        }





        //private List<string> Y = new List<string>();
        //private List<int> Py = new List<int>();
        //private List<string> BTN_Name = new List<string>();
        //private int Num_Pts = 0;

        //public CMS(List<string> Y , List<int> Py ,List<string> BTN_Name , ref int Num_Pts)
        //{
        //this.Y = Y;
        //this.Py = Py;
        //this.BTN_Name = BTN_Name;
        //this.Num_Pts = Num_Pts;


        //StreamReader Data = new StreamReader("BTNS.txt");

        //while (!Data.EndOfStream)
        //{
        //string Line;
        //int Cov;

        //Line = Data.ReadLine();
        //Y.Add(Line);
        //Cov = int.Parse(Line);  //ToString convert Line into string
        //Py.Add(Cov);

        //Line = Data.ReadLine();
        //BTN_Name.Add(Line)

        //Num_Pts++;
        //}
        //}
        //******************************************************************************************


    }
    }

