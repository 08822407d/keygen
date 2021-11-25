using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keygen
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_genRegCode_Click(object sender, EventArgs e)
        {
            Authorize auth = new Authorize("testprog");
            String regcode = auth.compute_authorise_code(tbx_UserCode.Text);
            tbx_RegCode.Text = regcode;
        }
    }
}
