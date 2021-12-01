namespace keygen
{
    partial class frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.main_tabctrl = new System.Windows.Forms.TabControl();
            this.tabpg_User = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_content = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_pubkey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_UserCode = new System.Windows.Forms.TextBox();
            this.btn_genCert = new System.Windows.Forms.Button();
            this.tabpg_Developer = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_RSAprivkey = new System.Windows.Forms.TextBox();
            this.tbx_RSApubkey = new System.Windows.Forms.TextBox();
            this.btn_genRSAkeys = new System.Windows.Forms.Button();
            this.main_tabctrl.SuspendLayout();
            this.tabpg_User.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabpg_Developer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_tabctrl
            // 
            this.main_tabctrl.Controls.Add(this.tabpg_User);
            this.main_tabctrl.Controls.Add(this.tabpg_Developer);
            this.main_tabctrl.Location = new System.Drawing.Point(13, 12);
            this.main_tabctrl.Name = "main_tabctrl";
            this.main_tabctrl.SelectedIndex = 0;
            this.main_tabctrl.Size = new System.Drawing.Size(776, 254);
            this.main_tabctrl.TabIndex = 0;
            // 
            // tabpg_User
            // 
            this.tabpg_User.BackColor = System.Drawing.SystemColors.Control;
            this.tabpg_User.Controls.Add(this.groupBox2);
            this.tabpg_User.Location = new System.Drawing.Point(4, 25);
            this.tabpg_User.Name = "tabpg_User";
            this.tabpg_User.Padding = new System.Windows.Forms.Padding(3);
            this.tabpg_User.Size = new System.Drawing.Size(768, 225);
            this.tabpg_User.TabIndex = 0;
            this.tabpg_User.Text = "用户功能";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbx_content);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbx_pubkey);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbx_UserCode);
            this.groupBox2.Controls.Add(this.btn_genCert);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 213);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户授权";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "加密内容：";
            // 
            // tbx_content
            // 
            this.tbx_content.Location = new System.Drawing.Point(131, 122);
            this.tbx_content.Name = "tbx_content";
            this.tbx_content.Size = new System.Drawing.Size(597, 25);
            this.tbx_content.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "RSA公钥：";
            // 
            // tbx_pubkey
            // 
            this.tbx_pubkey.Location = new System.Drawing.Point(131, 78);
            this.tbx_pubkey.Name = "tbx_pubkey";
            this.tbx_pubkey.Size = new System.Drawing.Size(597, 25);
            this.tbx_pubkey.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "用户码：";
            // 
            // tbx_UserCode
            // 
            this.tbx_UserCode.Location = new System.Drawing.Point(131, 33);
            this.tbx_UserCode.Name = "tbx_UserCode";
            this.tbx_UserCode.Size = new System.Drawing.Size(597, 25);
            this.tbx_UserCode.TabIndex = 6;
            // 
            // btn_genCert
            // 
            this.btn_genCert.Location = new System.Drawing.Point(314, 165);
            this.btn_genCert.Name = "btn_genCert";
            this.btn_genCert.Size = new System.Drawing.Size(123, 29);
            this.btn_genCert.TabIndex = 5;
            this.btn_genCert.Text = "生成证书";
            this.btn_genCert.UseVisualStyleBackColor = true;
            this.btn_genCert.Click += new System.EventHandler(this.btn_genCert_Click);
            // 
            // tabpg_Developer
            // 
            this.tabpg_Developer.BackColor = System.Drawing.SystemColors.Control;
            this.tabpg_Developer.Controls.Add(this.groupBox1);
            this.tabpg_Developer.Location = new System.Drawing.Point(4, 25);
            this.tabpg_Developer.Name = "tabpg_Developer";
            this.tabpg_Developer.Padding = new System.Windows.Forms.Padding(3);
            this.tabpg_Developer.Size = new System.Drawing.Size(768, 225);
            this.tabpg_Developer.TabIndex = 1;
            this.tabpg_Developer.Text = "开发者功能";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbx_RSAprivkey);
            this.groupBox1.Controls.Add(this.tbx_RSApubkey);
            this.groupBox1.Controls.Add(this.btn_genRSAkeys);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "生成秘钥对";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "私钥：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "公钥：";
            // 
            // tbx_RSAprivkey
            // 
            this.tbx_RSAprivkey.Location = new System.Drawing.Point(102, 75);
            this.tbx_RSAprivkey.Name = "tbx_RSAprivkey";
            this.tbx_RSAprivkey.Size = new System.Drawing.Size(499, 25);
            this.tbx_RSAprivkey.TabIndex = 3;
            // 
            // tbx_RSApubkey
            // 
            this.tbx_RSApubkey.Location = new System.Drawing.Point(102, 28);
            this.tbx_RSApubkey.Name = "tbx_RSApubkey";
            this.tbx_RSApubkey.Size = new System.Drawing.Size(499, 25);
            this.tbx_RSApubkey.TabIndex = 2;
            // 
            // btn_genRSAkeys
            // 
            this.btn_genRSAkeys.Location = new System.Drawing.Point(635, 28);
            this.btn_genRSAkeys.Name = "btn_genRSAkeys";
            this.btn_genRSAkeys.Size = new System.Drawing.Size(104, 25);
            this.btn_genRSAkeys.TabIndex = 0;
            this.btn_genRSAkeys.Text = "生成";
            this.btn_genRSAkeys.UseVisualStyleBackColor = true;
            this.btn_genRSAkeys.Click += new System.EventHandler(this.btn_genRSAkeys_Click);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 278);
            this.Controls.Add(this.main_tabctrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Main";
            this.Text = "注册机";
            this.main_tabctrl.ResumeLayout(false);
            this.tabpg_User.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabpg_Developer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl main_tabctrl;
        private System.Windows.Forms.TabPage tabpg_User;
        private System.Windows.Forms.TabPage tabpg_Developer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_genRSAkeys;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_RSAprivkey;
        private System.Windows.Forms.TextBox tbx_RSApubkey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_UserCode;
        private System.Windows.Forms.Button btn_genCert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_pubkey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_content;
    }
}

