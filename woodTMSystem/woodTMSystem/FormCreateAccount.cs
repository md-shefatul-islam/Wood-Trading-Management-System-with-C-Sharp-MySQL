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
    public partial class FormCreateAccount : Form
    {
        private DataTable Dt { get; set; }
        //private DataSet Ds { get; set; }
        private DataAccess Da { get; set; }
        string Sql { set; get; }
        private FormLogin fl { set; get; }
        public FormCreateAccount()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.GenerateID();
            this.txttype.Text = "user";
            this.txttype.ReadOnly = true;
            this.txttype.Visible = false;    
        }
        public FormCreateAccount(FormLogin f) : this ()
        {
            this.fl = f;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            fl.Visible = true;
        }

        public void GenerateID()
        {
            this.Sql = "select * from info order by id desc;";

            this.Dt = this.Da.ExecuteQueryTable(this.Sql);
            string id = Dt.Rows[0]["id"].ToString();

            string[] str = id.Split('c');
            int num = Convert.ToInt32(str[1]);
            string newId = 'c' + (++num).ToString("d3");

            this.txtid.Text = newId;
            this.txtid.ReadOnly = true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.txtname.Text == "" || this.txtaddress.Text == "" || this.txtphone.Text == "" || this.txtpassword.Text == "" || this.txtprofession.Text == "")
                {
                    MessageBox.Show("Please, Fill up all the field");
                }
                else
                {
                    this.Sql = @"insert into info
                    values('" + this.txtid.Text + "', '" + this.txtname.Text + "', '" + this.txtaddress.Text + "', " + this.txtphone.Text + ", '" + this.txtpassword.Text + "','" + this.txttype.Text + "','" + this.txtprofession.Text + "'); ";

                    int count = Da.ExecuteUpdateQuery(this.Sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Data Inserted");
                        this.ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("Data Insertion failed");
                    }    
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("i see" + a);
            }
        }
        public void ClearAll()
        {
            this.txtid.Clear();
            this.txtname.Clear();
            this.txtaddress.Clear();
            this.txtphone.Clear();
            this.txtpassword.Clear();
            this.txtprofession.Clear();
            this.GenerateID();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void FormCreateAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
