using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOs333333
{
    class ProImg
    {
        private List<Image> ProductImg = new List<Image>();
        private List<string> ProImge = new List<string>();

        public void LoadProductImg()
        {
            foreach (string Pic in Directory.GetFiles("ProImg"))
            {
                if (Pic == "ProImg\\Thumbs.db") continue; //end of pics
                ProductImg.Add(Image.FromFile(Pic));
                string[] Token = Pic.Split('\\', '.');
                ProImge.Add(Token[1]);
            }
        }
       public ProImg(List<Image> ProductImg , List<string> ProImge)
        {
            this.ProductImg = ProductImg;
            this.ProImge = ProImge;

            LoadProductImg();

        }

    }
}
