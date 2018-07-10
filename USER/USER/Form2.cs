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
using System.Net.Mail;
namespace USER
{
    public partial class Form2 : Form
    {
        public List<String> userNAME,userPASS,userEmail;
               
        public Form2(List<String>userName, List<String> userPass , List<String> userE_Mail)
        {
            InitializeComponent();
            userNAME = userName;
            userPASS = userPass;
            userEmail = userE_Mail;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkDataIfValid();
        }

        Boolean Valid = false;


        public void checkDataIfValid()
        {
            for(int i=0; i<userNAME.Count; i++)
            {
                if(userNAME[i] == textBox1.Text && userPASS[i] == textBox2.Text)
                {
                    MessageBox.Show("Welcome " + userNAME[i] + "!");
                    Valid = true;
                    break;
                }else
                {
                    Valid = false;
                }
            }
            if(!Valid)
            {
                MessageBox.Show("Wrong username or password! , Please try again.");
            }
            
        }

        
    }
}