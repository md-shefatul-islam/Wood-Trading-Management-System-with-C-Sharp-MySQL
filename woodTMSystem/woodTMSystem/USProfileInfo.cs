using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace woodTMSystem
{
    public partial class USProfileInfo : UserControl
    {
        private FormDashBoardUser Fd { set; get; }
        private FormDashBoardAdmin Fa { set; get; }
        private DataAccess Da { get; set; }
        private DataSet Ds { get; set; }
        private FormLogin fl { set; get; }
        private string Sql { set; get; }
        private string LoginId { set; get; }
        private Panel pl { set; get; }
        public USProfileInfo()
        {
            InitializeComponent();
            this.Da = new DataAccess();
             this.ShowInfo();
           // MessageBox.Show("me"+ FormLogin.ID);            
        }
        public void ShowInfo()
        {
            this.Sql = @"select * from info where id='" + FormLogin.ID + "';";
            this.Ds = Da.ExecuteQuery(this.Sql);
            this.ShowDetails();
        }

        private void ShowDetails()
        {
            this.txtcid.ReadOnly = true;
            this.txttype.ReadOnly = true;
            this.txtcid.Text = Ds.Tables[0].Rows[0]["id"].ToString();
            this.txtcname.Text = Ds.Tables[0].Rows[0][1].ToString();
            this.txtcaddress.Text = Ds.Tables[0].Rows[0][2].ToString();
            this.txtphoneno.Text = Ds.Tables[0].Rows[0][3].ToString();
            this.txtpassword.Text = Ds.Tables[0].Rows[0][4].ToString();
            this.txttype.Text = Ds.Tables[0].Rows[0][5].ToString();
            this.txtprofession.Visible = false;
            this.lblprofession.Visible = false;
        }

        public USProfileInfo(Panel p,FormDashBoardUser f) : this()
        { 
               pl=p;
            this.Fd = f;
        }
        public USProfileInfo(Panel p,FormDashBoardAdmin f) : this()
        {
            pl = p;
            this.Fa = f;
        }
        
        private void FormProfileInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btncsave_Click(object sender, EventArgs e)
        {
            try {
                if (txtcid.Text==""||this.txtcname.Text=="" || this.txtcaddress.Text==""|| this.txtphoneno.Text =="" || this.txtpassword.Text =="" || this.txtprofession.Text =="")
                {
                    MessageBox.Show(" Fill Up all field with required information");
                }
                else {
                    this.Sql = @"update info
            set name= '" + this.txtcname.Text + @"',
            address = '" + this.txtcaddress.Text + @"', 
            phone = " + this.txtphoneno.Text + @",
            password='" + this.txtpassword.Text + @"',
            profession='" + this.txtprofession.Text + @"'
            where id = '" + this.txtcid.Text + "'";

                    int count = this.Da.ExecuteUpdateQuery(this.Sql);
                    if (count == 1)
                    {
                        MessageBox.Show(" Data updated");
                        this.ShowInfo();
                    }
                    else
                    {
                        MessageBox.Show("Data updated failed");

                    }
                }
            }
            catch (Exception ae)
            {
                MessageBox.Show("Update Failed, Enter correct information");
                this.ShowInfo();
            }
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (FormLogin.ID.Contains("a"))
                {
                    this.Visible = false;
                    this.pl.Visible = true;
                    this.Fa.Visible = true;
                }
                else
                {
                    this.Visible = false;
                    this.pl.Visible = true;
                    this.Fd.Visible = true;
                }
            }
            catch(Exception ae)
            {
                MessageBox.Show("An exception happend in btnback in profile info"+ae);
            }
        }      
    }
}



