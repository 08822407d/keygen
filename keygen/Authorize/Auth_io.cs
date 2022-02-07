using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Authorize
{
    public partial class Auth
    {
        private void load_exinfo()
        {
            BinaryReader br = new BinaryReader(File.Open(this.auth_info_fname, FileMode.Open));
            this.exinfo.avail_time = br.ReadDouble();
            br.Close();
        }

        private void save_exinfo()
        {
            BinaryWriter bw = new BinaryWriter(File.Open(auth_info_fname, FileMode.Truncate));
            bw.Write(this.exinfo.avail_time);
            bw.Flush();
            bw.Close();
        }
    }
}
