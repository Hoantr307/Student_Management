namespace Student_Management
{
    partial class frmCreateAccount
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
            this.components = new System.ComponentModel.Container();
            this.cboPosition = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtRePassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnCreateAcc = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.txtDisplayName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbnotify = new System.Windows.Forms.Label();
            this.lbExist = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPosition
            // 
            this.cboPosition.BackColor = System.Drawing.Color.Transparent;
            this.cboPosition.BorderRadius = 12;
            this.cboPosition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosition.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPosition.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPosition.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPosition.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cboPosition.HoverState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.cboPosition.ItemHeight = 30;
            this.cboPosition.Items.AddRange(new object[] {
            "Giáo Viên",
            "Sinh Viên"});
            this.cboPosition.Location = new System.Drawing.Point(419, 369);
            this.cboPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(192, 36);
            this.cboPosition.TabIndex = 4;
            this.cboPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.txtPassword.BorderRadius = 12;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(261, 225);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Mật Khẩu";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(349, 50);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtUsername
            // 
            this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.txtUsername.BorderRadius = 12;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtUsername.Location = new System.Drawing.Point(261, 86);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.txtUsername.PlaceholderText = "Tên Tài Khoản";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(349, 50);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::Student_Management.Properties.Resources.logo_wide2;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(3, 2);
            this.guna2PictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(37, 38);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 9;
            this.guna2PictureBox2.TabStop = false;
            // 
            // txtRePassword
            // 
            this.txtRePassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.txtRePassword.BorderRadius = 12;
            this.txtRePassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRePassword.DefaultText = "";
            this.txtRePassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRePassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRePassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRePassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRePassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRePassword.ForeColor = System.Drawing.Color.Black;
            this.txtRePassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRePassword.Location = new System.Drawing.Point(261, 289);
            this.txtRePassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.PasswordChar = '●';
            this.txtRePassword.PlaceholderText = "Nhập Lại Mật Khẩu";
            this.txtRePassword.SelectedText = "";
            this.txtRePassword.Size = new System.Drawing.Size(349, 50);
            this.txtRePassword.TabIndex = 3;
            this.txtRePassword.UseSystemPasswordChar = true;
            this.txtRePassword.Enter += new System.EventHandler(this.txtRePassword_Enter);
            this.txtRePassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRePassword_KeyPress);
            this.txtRePassword.Leave += new System.EventHandler(this.txtRePassword_Leave);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(261, 369);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(152, 30);
            this.guna2HtmlLabel1.TabIndex = 15;
            this.guna2HtmlLabel1.Text = "Loại Tài Khoản:";
            // 
            // btnCreateAcc
            // 
            this.btnCreateAcc.Animated = true;
            this.btnCreateAcc.BorderRadius = 10;
            this.btnCreateAcc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateAcc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateAcc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreateAcc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreateAcc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCreateAcc.ForeColor = System.Drawing.Color.White;
            this.btnCreateAcc.Location = new System.Drawing.Point(263, 423);
            this.btnCreateAcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateAcc.Name = "btnCreateAcc";
            this.btnCreateAcc.Size = new System.Drawing.Size(349, 50);
            this.btnCreateAcc.TabIndex = 5;
            this.btnCreateAcc.Text = "Tạo Tài Khoản";
            this.btnCreateAcc.Click += new System.EventHandler(this.btnCreateAcc_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.DeepSkyBlue;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(815, 7);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 30);
            this.guna2ControlBox1.TabIndex = 18;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.txtDisplayName.BorderRadius = 12;
            this.txtDisplayName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDisplayName.DefaultText = "";
            this.txtDisplayName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDisplayName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDisplayName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDisplayName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDisplayName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDisplayName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDisplayName.ForeColor = System.Drawing.Color.Black;
            this.txtDisplayName.HoverState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.txtDisplayName.Location = new System.Drawing.Point(261, 160);
            this.txtDisplayName.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.PasswordChar = '\0';
            this.txtDisplayName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.txtDisplayName.PlaceholderText = "Tên Hiển Thị";
            this.txtDisplayName.SelectedText = "";
            this.txtDisplayName.Size = new System.Drawing.Size(349, 50);
            this.txtDisplayName.TabIndex = 1;
            // 
            // lbnotify
            // 
            this.lbnotify.AutoSize = true;
            this.lbnotify.BackColor = System.Drawing.Color.Transparent;
            this.lbnotify.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbnotify.Location = new System.Drawing.Point(265, 343);
            this.lbnotify.Name = "lbnotify";
            this.lbnotify.Size = new System.Drawing.Size(227, 16);
            this.lbnotify.TabIndex = 19;
            this.lbnotify.Text = "Bạn Nhập Lại Không Đúng Mật Khẩu !";
            this.lbnotify.Visible = false;
            // 
            // lbExist
            // 
            this.lbExist.AutoSize = true;
            this.lbExist.BackColor = System.Drawing.Color.Transparent;
            this.lbExist.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbExist.Location = new System.Drawing.Point(265, 140);
            this.lbExist.Name = "lbExist";
            this.lbExist.Size = new System.Drawing.Size(168, 16);
            this.lbExist.TabIndex = 19;
            this.lbExist.Text = "Tên Tài Khoản Đã Tồn Tại!";
            this.lbExist.Visible = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2PictureBox2);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(869, 44);
            this.guna2Panel1.TabIndex = 20;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.DragStartTransparencyValue = 1D;
            this.guna2DragControl1.TargetControl = this.guna2Panel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.BorderRadius = 50;
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.PeachPuff;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 8;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmCreateAccount
            // 
            this.AcceptButton = this.btnCreateAcc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 530);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lbExist);
            this.Controls.Add(this.lbnotify);
            this.Controls.Add(this.btnCreateAcc);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.cboPosition);
            this.Controls.Add(this.txtRePassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.txtUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCreateAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCreateAccount";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cboPosition;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2TextBox txtRePassword;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnCreateAcc;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtDisplayName;
        private System.Windows.Forms.Label lbnotify;
        private System.Windows.Forms.Label lbExist;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}