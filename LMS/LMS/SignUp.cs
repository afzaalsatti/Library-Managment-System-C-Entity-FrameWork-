using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class SignUp : MetroForm
    {
        LMSEntities model = new LMSEntities();
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn check = model.LogIns.Where(s => s.Admin_Id == textBox1.Text).FirstOrDefault(); ;
            if(check==null)
            {
                LogIn newUser = new LogIn();
                newUser.Admin_Id = textBox1.Text;
                newUser.Admin_Password = textBox3.Text;
                model.LogIns.Add(newUser);
                model.SaveChanges();
                this.Hide();
                new LogIn_Screen().Show();
                
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
           

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LogIn_Screen().Show();
            this.Hide();
        }
    }
}
