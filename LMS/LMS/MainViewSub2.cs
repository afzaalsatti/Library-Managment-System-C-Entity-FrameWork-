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
    public partial class MainViewSub2 : MetroForm
    {
        public MainViewSub2()
        {
            InitializeComponent();
        }

        private void MainViewSub2_Load(object sender, EventArgs e)
        {

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
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (sender.Equals(pictureBox7))
            {
                new Purchase().Show();
                this.Hide();
            }
            else
        if (sender.Equals(pictureBox2))
            {
                new Member_Transaction().Show();
                this.Hide();
            }
            else if (sender.Equals(pictureBox3))
            {
                new Book_In_Register().Show();
                this.Hide();
            }
            else if (sender.Equals(pictureBox6))
            {
                new Book_Out_Register().Show();
                this.Hide();
            }

        }
    }
}
