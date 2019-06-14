using AnimatorNS;
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
    public partial class MainViewSub1 : MetroForm
    {
        public MainViewSub1()
        {
            InitializeComponent();
            


        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (sender.Equals(pictureBox8))
            {
                Image im = pictureBox8.Image;
                
                new Member().Show();
                this.Hide();
            }
            else
           if (sender.Equals(pictureBox2))
            {
                new Plan().Show();
                this.Hide();
            }
            else if (sender.Equals(pictureBox1))
            {
                new Role().Show();
                this.Hide();
            }
            else if (sender.Equals(pictureBox6))
            {
                new Section().Show();
                this.Hide();
            }
            else if (sender.Equals(pictureBox4))
            {
                new Rack().Show();
                this.Hide();
            }
            else if (sender.Equals(pictureBox5))
            {
                new SecRacMap().Show();
                this.Hide();
            }
            else if (sender.Equals(pictureBox7))
            {
                new Book().Show();
                this.Hide();
            }
            else if (sender.Equals(pictureBox3))
            {
                new Stocks().Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show(sender.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainView().Show();
        }

        private void mouseEnter(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Width = p.Width + 15;
            p.Height = p.Height + 15;
           


            
           
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            p.Width = 107;
            p.Height = 103;
           

        }
    }
}
