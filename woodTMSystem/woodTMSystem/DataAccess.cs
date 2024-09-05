﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace woodTMSystem
{
    class DataAccess
    {
        private SqlConnection sqlcon;
        public SqlConnection Sqlcon
        {
            get { return this.sqlcon; }
            set { this.sqlcon = value; }
        }

        private SqlCommand sqlcom;
        public SqlCommand Sqlcom
        {
            get { return this.sqlcom; }
            set { this.sqlcom = value; }
        }

        private SqlDataAdapter sda;
        public SqlDataAdapter Sda
        {
            get { return this.sda; }
            set { this.sda = value; }
        }

        private DataSet ds;
        public DataSet Ds
        {
            get { return this.ds; }
            set { this.ds = value; }
        }

        //internal DataTable dt;

        public DataAccess()
        {
            try
            {

                this.Sqlcon = new SqlConnection(@"Data Source=SHEFAT\SQLEXPRESS;Initial Catalog=projectlogin;User ID=sa;Password=shefat1234");
                this.Sqlcon.Open();
        }
            catch (Exception ae)
            {
                MessageBox.Show(" in sqlcon");
            }

}

        private void QueryText(string query)
        {
            try
            {
                this.Sqlcom = new SqlCommand(query, this.Sqlcon);
            }
            catch (Exception ae)
            {
                MessageBox.Show(" in sqlcom");
            }
        }

        public DataSet ExecuteQuery(string sql)
        {
           
                this.QueryText(sql);
                this.Sda = new SqlDataAdapter(this.Sqlcom);
                this.Ds = new DataSet();
                this.Sda.Fill(this.Ds);
                return this.Ds;
        }

        public DataTable ExecuteQueryTable(string sql)
        {
            this.QueryText(sql);
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds);
            return this.Ds.Tables[0];
        }

        public int ExecuteUpdateQuery(string sql)
        {
           
                this.QueryText(sql);
            int u = this.Sqlcom.ExecuteNonQuery();
            return u;
}
    }
}

