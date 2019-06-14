using MetroFramework.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS
{
    public partial class MainView : MetroForm
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void planToolStripMenuItem_Click (object sender, EventArgs e)
        {
            if (sender.ToString().Equals("Member"))
            {
                new Member().Show();
                this.Hide();
            }
            else
            if (sender.ToString().Equals("Plan"))
            {
                new Plan().Show();
                this.Hide();
            }
            else if (sender.ToString().Equals("Role"))
            {
                new Role().Show();
                this.Hide();
            }
            else if (sender.ToString().Equals("Section"))
            {
                new Section().Show();
                this.Hide();
            }
            else if (sender.ToString().Equals("Rack"))
            {
                new Rack().Show();
                this.Hide();
            }
            else if (sender.ToString().Equals("Section Rack Mapping"))
            {
                new SecRacMap().Show();
                this.Hide();
            }
            else if (sender.ToString().Equals("Book"))
            {
                new Book().Show();
                this.Hide();
            }
            else if (sender.ToString().Equals("Book Stock"))
            {
                new Stocks().Show();
                this.Hide();
            }
            else
            {
                
                MessageBox.Show(sender.ToString());
            }
           
        }

        private void memberTransactionToolStripMenuItem_Click (object sender, EventArgs e)
        {
            if (sender.ToString().Equals("Purchase"))
            {
                new Purchase().Show();
                this.Hide();
            }
            else
           if (sender.ToString().Equals("Transaction"))
            {
                new Member_Transaction().Show();
                this.Hide();
            }
            else if (sender.ToString().Equals("Book In"))
            {
                new Book_In_Register().Show();
                this.Hide();
            }
            else if (sender.ToString().Equals("Book Out"))
            {
                new Book_Out_Register().Show();
                this.Hide();
            }



        }

        
       

        private void mouseEnter(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
           
            p.Width = p.Width + 20;
            p.Height = p.Height + 20;





        }

        private void mouseLeave(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Width = 183;
            p.Height = 177;


        }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new MainViewSub1().Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new MainViewSub2().Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new test().Show();

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new test().Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LogIn_Screen().Show();
            this.Hide();
        }
    }
}
