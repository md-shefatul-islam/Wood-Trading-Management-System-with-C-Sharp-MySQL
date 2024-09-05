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
    public partial class UCAddAdmin : UserControl
    {
        private UCAllMember am { set; get; }
        private DataTable Dt { get; set; }
        //private DataSet Ds { get; set; }
        private DataAccess Da { get; set; }
        string Sql { set; get; }
        public UCAddAdmin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.GenerateID();
          
        }
        public UCAddAdmin(UCAllMember a) : this ()
        {
            this.am = a;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            am.Visible = true;
            this.Visible = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtid.Text==""|| this.txtname.Text==""|| this.txtaddress.Text==""|| this.txtphone.Text==""|| this.txtpassword.Text==""|| this.txtprofession.Text=="")
                {
                    MessageBox.Show("Fill up all field with proper information");
                }
                else { 
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
            }catch(Exception ae)
            {
                MessageBox.Show("Fill up with information properly");
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
        public void GenerateID()
        {
            try
            {

                this.Sql = "select * from info where type = 'admin' order by id desc;";

            this.Dt = this.Da.ExecuteQueryTable(this.Sql);
            string id = Dt.Rows[0]["id"].ToString();

            string[] str = id.Split('a');
            int num = Convert.ToInt32(str[1]);
            string newId = 'a' + (++num).ToString("d3");

            this.txtid.Text = newId;
            this.txttype.Text = "admin";
            this.txtid.ReadOnly = true;
            this.txttype.ReadOnly = true;
            this.txtprofession.Visible = false;
            this.lblprofession.Visible = false;
        
          }catch(Exception ae)
            {
                MessageBox.Show("An exception Occured in generate id in add admin"+ae);
            }
        }
    }
}
