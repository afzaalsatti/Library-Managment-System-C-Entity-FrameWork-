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
    public partial class Change_pwd : MetroForm
    {
        public Change_pwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            LogIn_Screen obj = new LogIn_Screen();
            this.Hide();
            obj.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LMSEntities model = new LMSEntities();
            string id = textBox1.Text;
            string old_pwd = textBox2.Text;
            string new_pwd = textBox3.Text;
            LogIn obj = model.LogIns.Where(s => s.Admin_Id == id && s.Admin_Password == old_pwd).FirstOrDefault();
            if (obj != null)
            {
                obj.Admin_Password = new_pwd;
                model.SaveChanges();
                this.Hide();
                MessageBox.Show("Password changed Successfully");
                new LogIn_Screen().Show();
               
            }
            else
            {
                MessageBox.Show("Invalid id or password");
            }
        }
    }
}
