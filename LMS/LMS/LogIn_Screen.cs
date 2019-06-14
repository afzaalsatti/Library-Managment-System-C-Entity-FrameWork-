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
    public partial class LogIn_Screen : MetroForm
    {
        bool shouldPaint = false;
        public LogIn_Screen()
        {
            InitializeComponent();
            
            
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }
       

        private void login_Click(object sender, EventArgs e)
        {
            

              LMSEntities model = new LMSEntities();
              string id = textBox1.Text;
              string pwd = textBox2.Text;
          
              var obj = model.LogIns.Where(s => s.Admin_Id==id && s.Admin_Password==pwd).FirstOrDefault();
              if (obj != null)
              {
                  MainView mw = new MainView();
                  this.Hide();
                  mw.Show();
                  
              }
              else
              {
                  MessageBox.Show("Invalid id or password");
              }
        }

        private void chng_pwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

           
              
                Change_pwd chng = new Change_pwd();
                this.Hide();
                chng.Show();
            
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                new SignUp().Show();
                this.Hide();
            
           
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void LogIn_Screen_MouseMove(object sender, MouseEventArgs e)
        {
            if(shouldPaint)
            {
                Graphics graphics = CreateGraphics();

                graphics.FillEllipse(
                  new SolidBrush(Color.White),
                     e.X, e.Y, 4, 4);
            }
         
      
 
   

        }

        private void LogIn_Screen_MouseDown(object sender, MouseEventArgs e)
        {
            vat res = A.join(
                B,
                aa => aa.x,
                bb => bb.y,
                (aa, bb) =>
                select aa
                ;)
            shouldPaint = true;
        }

        private void LogIn_Screen_MouseUp(object sender, MouseEventArgs e)
        {
            shouldPaint = false;
        }
    }
}
