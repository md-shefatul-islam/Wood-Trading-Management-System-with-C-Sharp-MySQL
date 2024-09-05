using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace woodTMSystem
{
    public partial class FormDashBoardUser : Form
    {
       
        public FormDashBoardUser()
        {
            InitializeComponent();
            this.panel3.Visible = true;
        }
      
        private void btncprofile_Click(object sender, EventArgs e)
        {
            try
            {
                this.panel3.Visible = false;
                USProfileInfo p = new USProfileInfo(this.panel3, this);
                this.panel2.Controls.Add(p);
                p.Show();
                this.panel2.Visible = true;
            }catch(Exception ae)
            {
                MessageBox.Show("excetion found in btnprofile of dashboarduser"+ae);
            }
        }

        private void FormDashBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLogin fl = new FormLogin();
            fl.Visible = true;
            this.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void btnprice_Click(object sender, EventArgs e)
        {
            try { 
            this.panel3.Visible = false;
            UCProduct up = new UCProduct(this.panel3,this);
            this.panel2.Controls.Add(up);
            up.Show();
            this.panel2.Visible = true;
            }
            catch (Exception ae)
            {
                MessageBox.Show("excetion found in btnprice of dashboarduser" + ae);
            }
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            try { 
            this.panel2.Visible = true;
            UCOrder o = new UCOrder(this.panel3, this);
             this.panel2.Controls.Add(o);
            o.Visible=true;
            this.panel3.Visible = false;
            }
            catch (Exception ae)
            {
                MessageBox.Show("excetion found in btnorder of dashboarduser" + ae);
            }
        }      
    }
}
