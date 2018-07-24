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
       private List<string> Category        = new List<string>();
       private List<string> CategoryID      = new List<string>();
       private List<Image>  CategoryImg     = new List<Image>();
       private List<string> CateImg         = new List<string>();

       private List<Image>  ProductImg      = new List<Image>();
       private List<string> ProImg          = new List<string>();
                                           
       private List<string> ProductName     = new List<string>();
       private List<string> ProductPrice    = new List<string>();
       private List<int>    CategoryIDOfPr  = new List<int>();
       private List<int>    ProductID       = new List<int>();


         public List<string> Category1
        {
            get{ return Category; }
            set { Category = value;}
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

        public List<Image> ProductImg1
        {
            get
            {
                return ProductImg;
            }

            set
            {
                ProductImg = value;
            }
        }

        public List<string> ProImg1
        {
            get
            {
                return ProImg;
            }

            set
            {
                ProImg = value;
            }
        }

        public List<string> ProductName1
        {
            get
            {
                return ProductName;
            }

            set
            {
                ProductName = value;
            }
        }

        public List<string> ProductPrice1
        {
            get
            {
                return ProductPrice;
            }

            set
            {
                ProductPrice = value;
            }
        }

        public List<int> CategoryIDOfPr1
        {
            get
            {
                return CategoryIDOfPr;
            }

            set
            {
                CategoryIDOfPr = value;
            }
        }

        public List<int> ProductID1
        {
            get
            {
                return ProductID;
            }

            set
            {
                ProductID = value;
            }
        }

        public CMS(List<string> bTN_Name, List<string> CategoryID, List<Image> CategoryImg, List<string> CateImg, List<Image> ProductImg,List<string> ProImg , List<string> ProductName,List<string> ProductPrice, List<int> CategoryIDOfPr,List<int> ProductID)
        {
           this.Category      = bTN_Name;
           this.CategoryID    =CategoryID   ;
           this.CategoryImg   =CategoryImg   ;
           this.CateImg       =CateImg      ;
 
           this. ProductImg1   = ProductImg   ;
           this.ProImg1        =ProImg        ;
      
           this.ProductName1   =ProductName   ;
           this.ProductPrice1  =ProductPrice  ;
           this.CategoryIDOfPr1=CategoryIDOfPr;
           this.ProductID1     =ProductID     ;

            ReadData();
            ReadProducts();
            PutProductToEachCategory();
            LoadCategoryImg();
            LoadProductImg();


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
                ProductImg1.Add(Image.FromFile(Pic));
                string[] Token = Pic.Split('\\', '.');
                ProImg1.Add(Token[1]);
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

                CategoryIDOfPr1.Add(int.Parse(token[0]));

                ProductID1.Add(Convert.ToInt32(token[1]));
                ProductName1.Add(token[2]);
                ProductPrice1.Add(token[3]);

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
            for (int i = 0; i < CategoryIDOfPr1.Count; i++)
            {
                for (int j= i+1; j < CategoryIDOfPr1.Count; j++)
                {
                    if (CategoryIDOfPr1[j] < CategoryIDOfPr1[i])
                    {
                        int x = CategoryIDOfPr1[j];
                        int y = CategoryIDOfPr1[i];
                        swap<int>(ref x, ref y);
                        CategoryIDOfPr1[j] = x;
                        CategoryIDOfPr1[i] = y;

                        x = ProductID1[j];
                        y = ProductID1[i];
                        swap<int>(ref x, ref y);
                        x = CategoryIDOfPr1[j];
                        y = CategoryIDOfPr1[i];

                        string s1 = ProductName1[j];
                        string s2 = ProductName1[i];
                        swap<string>(ref s1 , ref s2);
                        ProductName1[j]=s1;
                        ProductName1[i]=s2;

                        s1 = ProductPrice1[j];
                        s2 = ProductPrice1[i];
                        swap<string>(ref s1,ref s2);
                        ProductPrice1[j] = s1;
                        ProductPrice1[i] = s2;
                    }
                }
            }
        }

    }
    }

