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
    public partial class FormLogin : Form
    {
        private FormWelcome F { set; get; }
        private DataAccess Da { set; get; }
        private DataSet Ds { get; set; }
        // private DataTable Dt { get; set; }
        private string Sql { get; set; }

        public static string ID;

        public FormLogin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        public FormLogin(FormWelcome fw) : this()
        {
            this.F = fw;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.F.Visible=true;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if ((this.txtuserid.Text == ""|| this.txtuserid.Text == "Enter Your ID" )&& (this.txtpassword.Text == "" || this.txtpassword.Text == "Enter Your Password"))
            {
                if(this.txtuserid.Text == "" && this.txtuserid.Text == "Enter Your ID")
                {
                    MessageBox.Show("Enter Your User Id");
                }
                else if(this.txtpassword.Text == ""&& this.txtpassword.Text == "Enter Your Password")
                {
                   MessageBox.Show("Enter Your Password");
                }
                else
                {
                    MessageBox.Show("Enter Your User Id and Password");
                }
            }
            else
            {
                string id = this.txtuserid.Text;
                id.Split();
                string[] str = id.Split('0');

                this.Sql = @"select * from info where id = '" + this.txtuserid.Text + "' and password = '" + this.txtpassword.Text + "';";
                this.Ds = Da.ExecuteQuery(this.Sql);

                if (Ds.Tables[0].Rows.Count == 1)
                {
                    if (str[0] == "c")
                    {
                        MessageBox.Show("Login approved for " + this.Ds.Tables[0].Rows[0][1].ToString());
                        ID = this.txtuserid.Text;
                        FormDashBoardUser dsh = new FormDashBoardUser();
                        dsh.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Login approved for " + this.Ds.Tables[0].Rows[0][1].ToString());
                        ID = this.txtuserid.Text;
                        FormDashBoardAdmin dha = new FormDashBoardAdmin();
                        dha.Visible = true;
                        this.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Login Invalid");
                }
            }
        }


        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblguest_Click(object sender, EventArgs e)
        {
            FormGuest fg = new FormGuest(this);
            fg.Visible = true;
            this.Visible = false;

        }

        private void lblcreatacc_Click(object sender, EventArgs e)
        {

            FormCreateAccount ca = new FormCreateAccount(this);
            ca.Visible = true;
            this.Visible = false;
        }

        private void txtuserid_Enter(object sender, EventArgs e)
        {
            if (this.txtuserid.Text == "Enter Your ID")
            {
                this.txtuserid.Text = "";
                this.txtuserid.ForeColor = Color.Black;
            }
        }
        private void txtuserid_Leave(object sender, EventArgs e)
        {
            if (this.txtuserid.Text == "")
            {
                this.txtuserid.Text = "Enter Your ID";
                this.txtuserid.ForeColor = Color.DimGray;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if(this.txtpassword.Text== "Enter Your Password")
            {
                this.txtpassword.Text = "";
                this.txtpassword.PasswordChar = '*';
                this.txtpassword.ForeColor = Color.Black;
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            if (this.txtpassword.Text == "")
            {
                //this.txtpassword.Text = "Enter Your Password";
                
                this.txtpassword.ForeColor = Color.DimGray;
            }
        }
    }
}



    
