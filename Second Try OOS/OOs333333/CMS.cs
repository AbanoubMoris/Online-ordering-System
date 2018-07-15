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
        private List<string> bTN_Name = new List<string>();
        private List<string> CategoryID = new List<string>();
        private List<Image> CategoryImg = new List<Image>();
        private List<string> CateImg = new List<string>();

        public List<Image> ProductImg = new List<Image>();
        public List<string> ProImg = new List<string>();

        public List<string> ProductName = new List<string>();
        public List<string> ProductPrice = new List<string>();
        public List<int> CategoryIDOfPr = new List<int>();
        public List<int> ProductID = new List<int>();

      


        public List<string> Category
        {
            get{ return bTN_Name; }
            set { bTN_Name = value;}
        }

        public List<string> CategoryID1
        {
            get { return CategoryID; }
            set{ CategoryID = value; }
        }

        public List<Image> CategoryImg1
        {
            get { return CategoryImg;}
            set{ CategoryImg = value;}
        }

        public List<string> MyPic
        {
            get{ return CateImg; }
            set{ CateImg = value;}
        }

        public void LoadCategoryImg()
        {
             foreach (string Pic in Directory.GetFiles("img"))
            {
                if (Pic == "img\\Thumbs.db") continue; //end of pics
                CategoryImg1.Add(Image.FromFile(Pic));
                string[] Token = Pic.Split('\\', '.');
                CateImg.Add(Token[1]);
            }
        }
        public void LoadProductImg()
        {
            foreach (string Pic in Directory.GetFiles("ProImg"))
            {
                if (Pic == "ProImg\\Thumbs.db") continue ; //end of pics
                ProductImg.Add(Image.FromFile(Pic));
                string[] Token = Pic.Split('\\', '.');
                ProImg.Add(Token[1]);
            }
        }
        public void SplitCategoryName()
        {
            for (int i = 0; i < Category.Count; i++)
            {
                string Line = Category[i];
                string []Token=Line.Split(',');
                Category[i] = Token[0];
                CategoryID1.Add(Token[1]);
            }
        }
        public void ReadData()
        {
            StreamReader Data = new StreamReader("CategoryName.txt");

            while (!Data.EndOfStream)
            {
                Category.Add(Data.ReadLine());
            }
            Data.Dispose();
            SplitCategoryName();
        }
        public void WriteData()
        {
            StreamWriter CategoryName = new StreamWriter("CategoryName.txt");
            for (int i = 0; i < Category.Count; i++)
            {
                string Line = "," +(i+1000).ToString();
                CategoryName.WriteLine(Category[i] + Line);
            }
            CategoryName.Dispose();
        }
        public void ReadProducts()
        {
            StreamReader SR = new StreamReader("Products.txt");

            while (!SR.EndOfStream)
            {
                string Line;
                Line = SR.ReadLine();
                string[] token = Line.Split(',');

                CategoryIDOfPr.Add(int.Parse(token[0]));

                ProductID.Add(Convert.ToInt32(token[1]));
                ProductName.Add(token[2]);
                ProductPrice.Add(token[3]);

            }
            SR.Dispose();
        }
        public static void swap<T>(ref T lhs,ref  T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public void PutProductToEachCategory()
        {
            for (int i = 0; i < CategoryIDOfPr.Count; i++)
            {
                for (int j= i+1; j < CategoryIDOfPr.Count; j++)
                {
                    if (CategoryIDOfPr[j] < CategoryIDOfPr[i])
                    {
                        int x = CategoryIDOfPr[j];
                        int y = CategoryIDOfPr[i];
                        swap<int>(ref x, ref y);
                        CategoryIDOfPr[j] = x;
                        CategoryIDOfPr[i] = y;

                        x = ProductID[j];
                        y = ProductID[i];
                        swap<int>(ref x, ref y);
                        x = CategoryIDOfPr[j];
                        y = CategoryIDOfPr[i];

                        string s1 = ProductName[j];
                        string s2 = ProductName[i];
                        swap<string>(ref s1 , ref s2);
                        ProductName[j]=s1;
                        ProductName[i]=s2;

                        s1 = ProductPrice[j];
                        s2 = ProductPrice[i];
                        swap<string>(ref s1,ref s2);
                        ProductPrice[j] = s1;
                        ProductPrice[i] = s2;
                    }
                }
            }
        }

    }
    }

