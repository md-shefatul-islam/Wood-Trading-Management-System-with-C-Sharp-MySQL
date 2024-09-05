namespace woodTMSystem
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btnback = new System.Windows.Forms.Button();
            this.btnlogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtuserid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lblguest = new System.Windows.Forms.Label();
            this.lblcreatacc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnback.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.Location = new System.Drawing.Point(469, 417);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(103, 42);
            this.btnback.TabIndex = 1;
            this.btnback.Text = "Back";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnlogin.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(655, 417);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(103, 42);
            this.btnlogin.TabIndex = 2;
            this.btnlogin.Text = "Log In";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(360, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "User ID";
            // 
            // txtuserid
            // 
            this.txtuserid.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtuserid.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserid.ForeColor = System.Drawing.Color.DimGray;
            this.txtuserid.Location = new System.Drawing.Point(504, 275);
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.Size = new System.Drawing.Size(285, 32);
            this.txtuserid.TabIndex = 4;
            this.txtuserid.Text = "Enter Your ID";
            this.txtuserid.Enter += new System.EventHandler(this.txtuserid_Enter);
            this.txtuserid.Leave += new System.EventHandler(this.txtuserid_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(360, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtpassword.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.Color.DimGray;
            this.txtpassword.Location = new System.Drawing.Point(504, 344);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(285, 32);
            this.txtpassword.TabIndex = 6;
            this.txtpassword.Text = "Enter Your Password";
            this.txtpassword.Enter += new System.EventHandler(this.txtpassword_Enter);
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave);
            // 
            // lblguest
            // 
            this.lblguest.AutoSize = true;
            this.lblguest.BackColor = System.Drawing.Color.Transparent;
            this.lblguest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblguest.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblguest.Location = new System.Drawing.Point(439, 496);
            this.lblguest.Name = "lblguest";
            this.lblguest.Size = new System.Drawing.Size(153, 22);
            this.lblguest.TabIndex = 7;
            this.lblguest.Text = "CONTINUE AS GUEST";
            this.lblguest.Click += new System.EventHandler(this.lblguest_Click);
            // 
            // lblcreatacc
            // 
            this.lblcreatacc.AutoSize = true;
            this.lblcreatacc.BackColor = System.Drawing.Color.Transparent;
            this.lblcreatacc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcreatacc.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcreatacc.Location = new System.Drawing.Point(629, 496);
            this.lblcreatacc.Name = "lblcreatacc";
            this.lblcreatacc.Size = new System.Drawing.Size(160, 22);
            this.lblcreatacc.TabIndex = 8;
            this.lblcreatacc.Text = "CREATE AN ACCOUNT";
            this.lblcreatacc.Click += new System.EventHandler(this.lblcreatacc_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::woodTMSystem.Properties.Resources._31;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1237, 758);
            this.Controls.Add(this.lblcreatacc);
            this.Controls.Add(this.lblguest);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtuserid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.btnback);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtuserid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label lblguest;
        private System.Windows.Forms.Label lblcreatacc;
    }
}