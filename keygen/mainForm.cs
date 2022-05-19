using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Authorize;
using Utils;

namespace keygen
{
    public partial class frm_Main : Form
    {
        string pubkey = "<RSAKeyValue><Modulus>r83mkPS9x1sjGaVQPWs+pJMP2ZaLp+w4IRwAcbo0JnS8fKjV5xmaw8PL0NermCoEUCt6NNSiJT6FFm29ibt06ILRQUlFJBZEHoGMSirXDHeV2EZx5mhnH9CWYRi2GgdsFgYZU8N/nJRJ4gF5mAzA0rznETQKGDQlPa1v+FVCFPk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        string privkey = "<RSAKeyValue><Modulus>r83mkPS9x1sjGaVQPWs+pJMP2ZaLp+w4IRwAcbo0JnS8fKjV5xmaw8PL0NermCoEUCt6NNSiJT6FFm29ibt06ILRQUlFJBZEHoGMSirXDHeV2EZx5mhnH9CWYRi2GgdsFgYZU8N/nJRJ4gF5mAzA0rznETQKGDQlPa1v+FVCFPk=</Modulus><Exponent>AQAB</Exponent><P>zsbDIj7HYZd3VjrZc962Tj8ihDsdeIv8eSYv56s53ug5UPvech7DfXZN/Lqq25KelGezIkf7OVa+wLF7Pnxhjw==</P><Q>2aenwRoN10cHeMuA3Zn6nv4nDKkLCZf2xlt9jE5cONqZKO+Fqpo08pshHTlJYfEevKJ2EcnFX7hbBgGCtV7M9w==</Q><DP>u12+CfTrBBKU700KKAWCGmr5IurSLJ5kW37v37P3D3ZMIYbpLW2U5MXjqwOWuLol+gHxfznMekuRM9he/eMFHw==</DP><DQ>gwwZyf9I5BxFGGrW7RX/uujlVA8XsTAJCgceAXNQvX6IhwgoH773MDdM6c6LK2hFDGh41F768pYKYARa0Z8Bow==</DQ><InverseQ>GbKOIam1plYIJVa4XGTN/yOsTFt5iEvzFLNhs+gWQIoAKxIPlmg6sRNGjTayOMCUi7EeBfegL+9/4xuBIhaXdQ==</InverseQ><D>B0vkZd/CgKOnsUjLK8FnuCziW4WEBlQngDhJTG8N+wqdSA850X2ejsFxlBlfZdFYnHsxdz/b+u+9VlD3rN+62ln2AC/6vssxjI88P9glsmbrhgDDAT6tSww6b7pGmLM5szP+NBQX6ngWX658PXA8eMchQ/+7rucg5ByPe1TPkIE=</D></RSAKeyValue>";

		public CfgPack Cfgs = null;

		AuthData currAD = null;
		string currADname = null;

        public frm_Main()
        {
            InitializeComponent();
			Cfgs = new CfgPack();

			cmbbx_Acfgs.SelectedItem = this.currADname;
        }

        private void btn_genCert_Click(object sender, EventArgs e)
        {
            string cert_fname = "./cert.txt";
            StreamWriter sw = new StreamWriter(cert_fname);
            // encrypt identity code for user
            string regcode = Auth.SHA512encrypt(tbx_UserCode.Text);
            // create RSA encoder and encrypt additional information
            //string pubkey = tbx_pubkey.Text;
            byte[] exinfo = Auth.RSAencrypt(pubkey, tbx_content.Text);
            string exi_str = BitConverter.ToString(exinfo).Replace("-", string.Empty);
            //byte[] ex_byte = Authorize.hexStr_to_byteArr(ex_str);
            //string info = Authorize.RSAdecrypt(privkey, ex_byte);

            sw.WriteLine(regcode);
            sw.WriteLine(exi_str);
            sw.Flush();
            sw.Close();

            string[] lines = File.ReadAllLines(cert_fname);
            string authinfo_line = lines[1];
            string authinfo_str = Auth.RSAdecrypt(privkey, Auth.hexStr_to_byteArr(authinfo_line));
        }

		private void btn_RefreshRSA_Click(object sender, EventArgs e)
		{
            String[] keys = Auth.gen_RSAkeys();
			this.currAD.RSA_PrivKey =
			tbx_RSApriv.Text = keys[0];
			this.currAD.RSA_PubKey =
			tbx_RSApub.Text = keys[1];

			resetDataGrid();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{

		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{

		}

		private void btn_NewCfg_Click(object sender, EventArgs e)
		{
			frmTXTInput wTI = new frmTXTInput();
			wTI.ShowDialog();

			string newName = wTI.ret_val;
			if (newName == null)
			{
				MessageBox.Show("未输入名称, 取消新建配置");
				return;
			}
			else
			{
				this.currAD = new AuthData();
				this.currADname = newName;
				Cfgs.addAcfg(this.currADname, this.currAD);
				cmbbx_Acfgs.Items.Add(this.currADname + " （新建）");

				MessageBox.Show("新建配置:" + this.currADname + ", 采用默认配置模板");
			}
		}

		private void resetDataGrid()
		{
			dgv_regdata.Rows.Clear();
		}

		private void cmbbx_Acfgs_SelectedIndexChanged(object sender, EventArgs e)
		{
			string name = cmbbx_Acfgs.SelectedItem.ToString();
			AuthData acfg = Cfgs.getAcfg(name);
			if (acfg != null)
			{
				this.currADname = name;
				this.currAD = acfg;

				gbx_rsa.Enabled = true;
				gbx_authgroup.Enabled = true;
			}
			else
			{
				gbx_rsa.Enabled = false;
				gbx_rsa.Enabled = false;
			}
		}
	}
}
