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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_RegCode = new System.Windows.Forms.TextBox();
            this.tbx_UserCode = new System.Windows.Forms.TextBox();
            this.btn_genRegCode = new System.Windows.Forms.Button();
            this.tabpg_Developer = new System.Windows.Forms.TabPage();
            this.main_tabctrl.SuspendLayout();
            this.tabpg_User.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_tabctrl
            // 
            this.main_tabctrl.Controls.Add(this.tabpg_User);
            this.main_tabctrl.Controls.Add(this.tabpg_Developer);
            this.main_tabctrl.Location = new System.Drawing.Point(12, 12);
            this.main_tabctrl.Name = "main_tabctrl";
            this.main_tabctrl.SelectedIndex = 0;
            this.main_tabctrl.Size = new System.Drawing.Size(776, 426);
            this.main_tabctrl.TabIndex = 0;
            // 
            // tabpg_User
            // 
            this.tabpg_User.BackColor = System.Drawing.SystemColors.Control;
            this.tabpg_User.Controls.Add(this.label2);
            this.tabpg_User.Controls.Add(this.label1);
            this.tabpg_User.Controls.Add(this.tbx_RegCode);
            this.tabpg_User.Controls.Add(this.tbx_UserCode);
            this.tabpg_User.Controls.Add(this.btn_genRegCode);
            this.tabpg_User.Location = new System.Drawing.Point(4, 25);
            this.tabpg_User.Name = "tabpg_User";
            this.tabpg_User.Padding = new System.Windows.Forms.Padding(3);
            this.tabpg_User.Size = new System.Drawing.Size(768, 397);
            this.tabpg_User.TabIndex = 0;
            this.tabpg_User.Text = "用户功能";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "生成注册码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "输入用户码：";
            // 
            // tbx_RegCode
            // 
            this.tbx_RegCode.Location = new System.Drawing.Point(127, 67);
            this.tbx_RegCode.Name = "tbx_RegCode";
            this.tbx_RegCode.Size = new System.Drawing.Size(460, 25);
            this.tbx_RegCode.TabIndex = 2;
            // 
            // tbx_UserCode
            // 
            this.tbx_UserCode.Location = new System.Drawing.Point(127, 20);
            this.tbx_UserCode.Name = "tbx_UserCode";
            this.tbx_UserCode.Size = new System.Drawing.Size(460, 25);
            this.tbx_UserCode.TabIndex = 1;
            // 
            // btn_genRegCode
            // 
            this.btn_genRegCode.Location = new System.Drawing.Point(617, 16);
            this.btn_genRegCode.Name = "btn_genRegCode";
            this.btn_genRegCode.Size = new System.Drawing.Size(123, 29);
            this.btn_genRegCode.TabIndex = 0;
            this.btn_genRegCode.Text = "生成注册码";
            this.btn_genRegCode.UseVisualStyleBackColor = true;
            this.btn_genRegCode.Click += new System.EventHandler(this.btn_genRegCode_Click);
            // 
            // tabpg_Developer
            // 
            this.tabpg_Developer.BackColor = System.Drawing.SystemColors.Control;
            this.tabpg_Developer.Location = new System.Drawing.Point(4, 25);
            this.tabpg_Developer.Name = "tabpg_Developer";
            this.tabpg_Developer.Padding = new System.Windows.Forms.Padding(3);
            this.tabpg_Developer.Size = new System.Drawing.Size(768, 397);
            this.tabpg_Developer.TabIndex = 1;
            this.tabpg_Developer.Text = "开发者功能";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.main_tabctrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Main";
            this.Text = "注册机";
            this.main_tabctrl.ResumeLayout(false);
            this.tabpg_User.ResumeLayout(false);
            this.tabpg_User.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl main_tabctrl;
        private System.Windows.Forms.TabPage tabpg_User;
        private System.Windows.Forms.TabPage tabpg_Developer;
        private System.Windows.Forms.TextBox tbx_RegCode;
        private System.Windows.Forms.TextBox tbx_UserCode;
        private System.Windows.Forms.Button btn_genRegCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

