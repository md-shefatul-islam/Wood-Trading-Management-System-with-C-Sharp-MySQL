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
    public partial class UCAllMemberEdit : UserControl
    {
        private UCAllMember am { set; get; }
        private DataTable Dt { get; set; }
        //private DataSet Ds { get; set; }
        private DataAccess Da { get; set; }
        private string Sql { set; get; }
        public UCAllMemberEdit()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            //this.GenerateID();
            if (this.txtid.Text.Contains('a'))
            {
                this.txttype.Text = "admin";
                this.txttype.ReadOnly = true;
            }
            else
            {
                this.txttype.Text = "user";
                this.txttype.ReadOnly = true;
            }
        }
        public UCAllMemberEdit(string id, UCAllMember p) : this()
        {
            this.txtid.Text = id;
            this.am = p;
            this.ShowDetails();
            this.btnsave.Visible = false;
            this.btnsave.Enabled = false;
        }
        public UCAllMemberEdit(UCAllMember p) : this()
        {
            this.am = p;
            this.ShowDetails();
            this.GenerateID();
            this.txtid.ReadOnly = true;
            this.btnupdate.Visible = false;
            this.btnupdate.Enabled = false;
        }
        public UCAllMemberEdit(double r, UCAllMember p) : this()
        {
            this.am = p;
            this.ShowDetails();
            this.GenerateID();
            this.txtid.ReadOnly = true;
            this.btnupdate.Visible = false;
            this.btnupdate.Enabled = false;
        }

        public void ShowDetails()
        {
            this.Sql = @"select * from info where id = '" + this.txtid.Text + "';";
            this.Dt = Da.ExecuteQueryTable(this.Sql);
            if (this.Dt.Rows.Count == 1)
            {
                this.txtid.Text = this.Dt.Rows[0]["id"].ToString();
                this.txtname.Text = this.Dt.Rows[0]["name"].ToString();
                this.txtaddress.Text = this.Dt.Rows[0]["address"].ToString();
                this.txtphone.Text = this.Dt.Rows[0]["phone"].ToString();
                this.txtpassword.Text = this.Dt.Rows[0]["password"].ToString();
                if (this.txtid.Text.Contains('a'))
                {

                    this.txtprofession.Visible = false;
                    this.lblprofession.Visible = false;
                }
                else
                {
                    this.txtprofession.Text = this.Dt.Rows[0]["profession"].ToString();
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtname.Text == "" || this.txtaddress.Text == "" || this.txtphone.Text == "" || this.txtpassword.Text == "" || this.txtprofession.Text == "")
                {
                        MessageBox.Show("fill up with required information properly");
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

                    this.ShowDetails();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("i see" + a);
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            am.Visible = true;
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

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtid.Text==""|| this.txtname.Text==""|| this.txtaddress.Text==""|| this.txtphone.Text==""|| this.txtpassword.Text==""|| this.txttype.Text==""|| this.txtprofession.Text=="")
                {
                    MessageBox.Show("fill up with required information properly");
                }
                else
                {
                    this.Sql = @"update info
            set name= '" + this.txtname.Text + @"',
            address = '" + this.txtaddress.Text + @"', 
            phone = " + this.txtphone.Text + @",
            password='" + this.txtpassword.Text + @"'
            type = " + this.txttype.Text + @",
            profession = " + this.txtprofession.Text + @",
                where id = '" + this.txtid.Text + @"';";

                    int count = this.Da.ExecuteUpdateQuery(this.Sql);
                    if (count == 1)
                    {
                        MessageBox.Show(" Data updated");
                        this.Visible = false;
                        am.Show();
                    }
                    else
                    {
                        MessageBox.Show("Data updated failed");
                    }
                }
            }catch(Exception ae)
            {
                MessageBox.Show("fill up with required information properly");
            }
        }

        public void ClearAll()
        {
            this.txtid.Clear();
            this.txtname.Clear();
            this.txtaddress.Clear();
            this.txtphone.Clear();
            this.txtpassword.Clear();
            this.txttype.Clear();
            this.txtprofession.Clear();
            this.GenerateID();
        }
    }
}
