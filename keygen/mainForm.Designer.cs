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
			this.grpBx_UserAuth = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbx_content = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbx_pubkey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbx_UserCode = new System.Windows.Forms.TextBox();
			this.btn_genCert = new System.Windows.Forms.Button();
			this.dgv_regdata = new System.Windows.Forms.DataGridView();
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.btn_Save = new System.Windows.Forms.Button();
			this.btn_RefreshRSA = new System.Windows.Forms.Button();
			this.cmbbx_Acfgs = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_NewCfg = new System.Windows.Forms.Button();
			this.grpBx_UserAuth.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_regdata)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpBx_UserAuth
			// 
			this.grpBx_UserAuth.Controls.Add(this.label5);
			this.grpBx_UserAuth.Controls.Add(this.tbx_content);
			this.grpBx_UserAuth.Controls.Add(this.label2);
			this.grpBx_UserAuth.Controls.Add(this.tbx_pubkey);
			this.grpBx_UserAuth.Controls.Add(this.label1);
			this.grpBx_UserAuth.Controls.Add(this.tbx_UserCode);
			this.grpBx_UserAuth.Controls.Add(this.btn_genCert);
			this.grpBx_UserAuth.Location = new System.Drawing.Point(12, 12);
			this.grpBx_UserAuth.Name = "grpBx_UserAuth";
			this.grpBx_UserAuth.Size = new System.Drawing.Size(679, 213);
			this.grpBx_UserAuth.TabIndex = 0;
			this.grpBx_UserAuth.TabStop = false;
			this.grpBx_UserAuth.Text = "用户授权";
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
			this.tbx_content.Location = new System.Drawing.Point(121, 122);
			this.tbx_content.Name = "tbx_content";
			this.tbx_content.Size = new System.Drawing.Size(539, 25);
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
			this.tbx_pubkey.Location = new System.Drawing.Point(121, 78);
			this.tbx_pubkey.Name = "tbx_pubkey";
			this.tbx_pubkey.Size = new System.Drawing.Size(539, 25);
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
			this.tbx_UserCode.Location = new System.Drawing.Point(121, 33);
			this.tbx_UserCode.Name = "tbx_UserCode";
			this.tbx_UserCode.Size = new System.Drawing.Size(539, 25);
			this.tbx_UserCode.TabIndex = 6;
			// 
			// btn_genCert
			// 
			this.btn_genCert.Location = new System.Drawing.Point(266, 166);
			this.btn_genCert.Name = "btn_genCert";
			this.btn_genCert.Size = new System.Drawing.Size(123, 29);
			this.btn_genCert.TabIndex = 5;
			this.btn_genCert.Text = "生成证书";
			this.btn_genCert.UseVisualStyleBackColor = true;
			this.btn_genCert.Click += new System.EventHandler(this.btn_genCert_Click);
			// 
			// dgv_regdata
			// 
			this.dgv_regdata.AllowUserToAddRows = false;
			this.dgv_regdata.AllowUserToDeleteRows = false;
			this.dgv_regdata.AllowUserToResizeRows = false;
			this.dgv_regdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv_regdata.Location = new System.Drawing.Point(19, 63);
			this.dgv_regdata.Name = "dgv_regdata";
			this.dgv_regdata.RowTemplate.Height = 27;
			this.dgv_regdata.Size = new System.Drawing.Size(641, 131);
			this.dgv_regdata.TabIndex = 1;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.Location = new System.Drawing.Point(502, 207);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(158, 29);
			this.btn_Cancel.TabIndex = 8;
			this.btn_Cancel.Text = "放弃更改";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// btn_Save
			// 
			this.btn_Save.Location = new System.Drawing.Point(315, 207);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(158, 29);
			this.btn_Save.TabIndex = 7;
			this.btn_Save.Text = "保存更改";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// btn_RefreshRSA
			// 
			this.btn_RefreshRSA.Location = new System.Drawing.Point(19, 207);
			this.btn_RefreshRSA.Name = "btn_RefreshRSA";
			this.btn_RefreshRSA.Size = new System.Drawing.Size(158, 29);
			this.btn_RefreshRSA.TabIndex = 6;
			this.btn_RefreshRSA.Text = "刷新RSA";
			this.btn_RefreshRSA.UseVisualStyleBackColor = true;
			this.btn_RefreshRSA.Click += new System.EventHandler(this.btn_RefreshRSA_Click);
			// 
			// cmbbx_Acfgs
			// 
			this.cmbbx_Acfgs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbbx_Acfgs.FormattingEnabled = true;
			this.cmbbx_Acfgs.Location = new System.Drawing.Point(166, 27);
			this.cmbbx_Acfgs.Name = "cmbbx_Acfgs";
			this.cmbbx_Acfgs.Size = new System.Drawing.Size(307, 23);
			this.cmbbx_Acfgs.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(16, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(123, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "选择注册信息";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_NewCfg);
			this.groupBox1.Controls.Add(this.dgv_regdata);
			this.groupBox1.Controls.Add(this.btn_Cancel);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btn_Save);
			this.groupBox1.Controls.Add(this.cmbbx_Acfgs);
			this.groupBox1.Controls.Add(this.btn_RefreshRSA);
			this.groupBox1.Location = new System.Drawing.Point(12, 231);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(679, 252);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "开发者选项";
			// 
			// btn_NewCfg
			// 
			this.btn_NewCfg.Location = new System.Drawing.Point(502, 25);
			this.btn_NewCfg.Name = "btn_NewCfg";
			this.btn_NewCfg.Size = new System.Drawing.Size(158, 29);
			this.btn_NewCfg.TabIndex = 9;
			this.btn_NewCfg.Text = "或新建模板";
			this.btn_NewCfg.UseVisualStyleBackColor = true;
			this.btn_NewCfg.Click += new System.EventHandler(this.btn_NewCfg_Click);
			// 
			// frm_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(704, 502);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpBx_UserAuth);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frm_Main";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "注册机";
			this.grpBx_UserAuth.ResumeLayout(false);
			this.grpBx_UserAuth.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv_regdata)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpBx_UserAuth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_UserCode;
        private System.Windows.Forms.Button btn_genCert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_pubkey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_content;
		private System.Windows.Forms.DataGridView dgv_regdata;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbbx_Acfgs;
		private System.Windows.Forms.Button btn_RefreshRSA;
		private System.Windows.Forms.Button btn_Cancel;
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn_NewCfg;
	}
}

