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
    class AddControlsToFrmProduct
    {
        private List<Button> AddProductBtn = new List<Button>();
        private List<TextBox> ProName = new List<TextBox>();
        private List<TextBox> ProPrice = new List<TextBox>();
        private List<Panel> ProductContainer = new List<Panel>();

        public List<Button> AddProductBtn1
        {
            get { return AddProductBtn; }
            set { AddProductBtn = value; }
        }
        public List<TextBox> ProName1
        {
            get { return ProName; }
            set { ProName = value; }
        }

        public List<TextBox> ProPrice1
        {
            get { return ProPrice; }
            set { ProPrice = value; }
        }

        public List<Panel> ProductContainer1
        {
            get
            {
                return ProductContainer;
            }

            set
            {
                ProductContainer = value;
            }
        }

        public void AddControls(Form F , int i)
        {
            AddProductBtn1.Add(new Button());
            AddProductBtn[i].Location = new Point(300, 400);
            AddProductBtn[i].Text = "Add new Product";
            F.Controls.Add(AddProductBtn[i]);

            ProName.Add(new TextBox());
            ProPrice.Add(new TextBox());
            ProName[i].Location = new Point(10, 400);
            ProPrice[i].Location = new Point(10, 430);
            F.Controls.Add(ProName[i]);
            F.Controls.Add(ProPrice[i]);

            ProductContainer.Add(new Panel());
            ProductContainer[i].AutoScroll = true;
            ProductContainer[i].Size = new Size(390, 350);
            F.Controls.Add(ProductContainer[i]);
        }
    }
}
