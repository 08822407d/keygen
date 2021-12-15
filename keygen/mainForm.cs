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

namespace keygen
{
    public partial class frm_Main : Form
    {
        string pubkey = "<RSAKeyValue><Modulus>r83mkPS9x1sjGaVQPWs+pJMP2ZaLp+w4IRwAcbo0JnS8fKjV5xmaw8PL0NermCoEUCt6NNSiJT6FFm29ibt06ILRQUlFJBZEHoGMSirXDHeV2EZx5mhnH9CWYRi2GgdsFgYZU8N/nJRJ4gF5mAzA0rznETQKGDQlPa1v+FVCFPk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        string privkey = "<RSAKeyValue><Modulus>r83mkPS9x1sjGaVQPWs+pJMP2ZaLp+w4IRwAcbo0JnS8fKjV5xmaw8PL0NermCoEUCt6NNSiJT6FFm29ibt06ILRQUlFJBZEHoGMSirXDHeV2EZx5mhnH9CWYRi2GgdsFgYZU8N/nJRJ4gF5mAzA0rznETQKGDQlPa1v+FVCFPk=</Modulus><Exponent>AQAB</Exponent><P>zsbDIj7HYZd3VjrZc962Tj8ihDsdeIv8eSYv56s53ug5UPvech7DfXZN/Lqq25KelGezIkf7OVa+wLF7Pnxhjw==</P><Q>2aenwRoN10cHeMuA3Zn6nv4nDKkLCZf2xlt9jE5cONqZKO+Fqpo08pshHTlJYfEevKJ2EcnFX7hbBgGCtV7M9w==</Q><DP>u12+CfTrBBKU700KKAWCGmr5IurSLJ5kW37v37P3D3ZMIYbpLW2U5MXjqwOWuLol+gHxfznMekuRM9he/eMFHw==</DP><DQ>gwwZyf9I5BxFGGrW7RX/uujlVA8XsTAJCgceAXNQvX6IhwgoH773MDdM6c6LK2hFDGh41F768pYKYARa0Z8Bow==</DQ><InverseQ>GbKOIam1plYIJVa4XGTN/yOsTFt5iEvzFLNhs+gWQIoAKxIPlmg6sRNGjTayOMCUi7EeBfegL+9/4xuBIhaXdQ==</InverseQ><D>B0vkZd/CgKOnsUjLK8FnuCziW4WEBlQngDhJTG8N+wqdSA850X2ejsFxlBlfZdFYnHsxdz/b+u+9VlD3rN+62ln2AC/6vssxjI88P9glsmbrhgDDAT6tSww6b7pGmLM5szP+NBQX6ngWX658PXA8eMchQ/+7rucg5ByPe1TPkIE=</D></RSAKeyValue>";

        public frm_Main()
        {
            InitializeComponent();
            //BinaryWriter bw = new BinaryWriter(File.Open("./cert.bin", FileMode.Create));
            //bw.Write((double)101.202);
            //bw.Flush();
            //bw.Close();

            Authorize test = new Authorize("keygen", pubkey, privkey);
            test.read_certfile("./cert.txt");
        }

        private void btn_genRSAkeys_Click(object sender, EventArgs e)
        {
            String[] keys = Authorize.gen_RSAkeys();
            tbx_RSAprivkey.Text = keys[0];
            tbx_RSApubkey.Text = keys[1];
        }

        private void btn_genCert_Click(object sender, EventArgs e)
        {
            GUI_Utils.controls_disable(grpBx_UserAuth);

            string cert_fname = "./cert.txt";
            StreamWriter sw = new StreamWriter(cert_fname);
            // encrypt identity code for user
            string regcode = Authorize.SHA512encrypt(tbx_UserCode.Text);
            // create RSA encoder and encrypt additional information
            //string pubkey = tbx_pubkey.Text;
            byte[] exinfo = Authorize.RSAencrypt(pubkey, tbx_content.Text);
            string exi_str = BitConverter.ToString(exinfo).Replace("-", string.Empty);
            //byte[] ex_byte = Authorize.hexStr_to_byteArr(ex_str);
            //string info = Authorize.RSAdecrypt(privkey, ex_byte);

            sw.WriteLine(regcode);
            sw.WriteLine(exi_str);
            sw.Flush();
            sw.Close();

            string[] lines = File.ReadAllLines(cert_fname);
            string authinfo_line = lines[1];
            string authinfo_str = Authorize.RSAdecrypt(privkey, Authorize.hexStr_to_byteArr(authinfo_line));

            GUI_Utils.controls_enable(grpBx_UserAuth);
        }
    }
}
