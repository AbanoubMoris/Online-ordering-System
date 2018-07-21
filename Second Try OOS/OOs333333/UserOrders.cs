using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOs333333
{
    class UserOrders
    {
        private List<string> UserName    = new List<string>();
        private List<string> ProductName = new List<string>();
        private List<string> Price       = new List<string>();
        private List<string> Quantity    = new List<string>();
        private List<string> status      = new List<string>();

        

       public UserOrders (List<string> UserName, List<string> ProductName, List<string> Price, List<string> Quantity, List<string> status)
        {
            this.UserName    = UserName    ;  
            this.ProductName = ProductName ;
            this.Price       = Price       ;
            this.Quantity    = Quantity    ;
            this.status      = status      ;

            ReadData();
        }


        private void SpliteLine(string Line)
        {
            string[] Token = Line.Split(',');

            ProductName.Add(Token[0]);
            status.Add(Token[1]);
            Quantity.Add(Token[2]);
            Price.Add(Token[3]);
            UserName.Add(Token[4]);
        }

        private void ReadData()
        {
            StreamReader sr = new StreamReader("AdminOrders.txt");
            while (!sr.EndOfStream)
            {
                string Line;
                Line = sr.ReadLine();
                SpliteLine(Line);
            }

            sr.Dispose();
        }
    }
}
