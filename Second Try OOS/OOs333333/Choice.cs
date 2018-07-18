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
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterationForm registerForm = new RegisterationForm();
            this.Hide();
            registerForm.Show();
        }
        List<String> username = new List<string>();
        List<String> password = new List<string>();
        List<String> userAddress = new List<string>();
        List<String> userEmail = new List<string>();
        StreamReader sr = new StreamReader("UserData.txt");
        private void button2_Click(object sender, EventArgs e)
        {
            readDataFromFile();
            UserLogin f2 = new UserLogin(username, password, userAddress ,userEmail);
            this.Hide();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin f4 = new AdminLogin();
            this.Hide();
            f4.Show();
        }

        private void Choice_Load(object sender, EventArgs e)
        {

        }

        public void readDataFromFile()
        {
            while (!sr.EndOfStream)
            {
                username.Add(sr.ReadLine());
                userEmail.Add(sr.ReadLine());
                userAddress.Add(sr.ReadLine());
                password.Add(sr.ReadLine());

            }
            sr.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.BackColor = Color.Red;

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }
    }
}
