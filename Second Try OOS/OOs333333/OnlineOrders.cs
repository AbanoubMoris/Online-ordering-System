using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOs333333
{
    class OnlineOrders
    {
        private List<string> UserName    = new List<string>();
        private List<string> ProductName = new List<string>();
        private List<int>    Price       = new List<int>();
        private List<int>    Quantity    = new List<int>();

        

       public OnlineOrders(List<string> UserName, List<string> ProductName, List<int> Price, List<int> Quantity)
        {
            ReadOrders();

            this.UserName    = UserName  ;
            this.ProductName =ProductName;
            this.Price       =Price      ;
            this.Quantity    = Quantity  ;
        }

        public void SplitOrderLine()
        {
           
        }

        public void ReadOrders() {
            StreamReader SR = new StreamReader("Orders.txt");
            while (!SR.EndOfStream)
            {
                string Line;
                Line = SR.ReadLine();
                string[] Token = Line.Split(',','$');

                UserName.Add(Token[0]);
                ProductName.Add(Token[1]);
                Price.Add(Convert.ToInt32(Token[2]));
                Quantity.Add(Convert.ToInt32(Token[4]));
            }

            SR.Dispose();
        }
        

    }
}
