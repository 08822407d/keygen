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
            this.exinfo = read_exinfo(br);
            br.Close();
        }

        private void save_exinfo()
        {
            BinaryWriter bw = new BinaryWriter(File.Open(auth_info_fname, FileMode.Truncate));
            write_exinfo(bw, this.exinfo);
            bw.Flush();
            bw.Close();
        }

        private extra_info read_exinfo(BinaryReader br)
        {
            extra_info ret_val;
            ret_val.avail_time = br.ReadDouble();
            return ret_val;
        }

        private void write_exinfo(BinaryWriter bw, extra_info exi)
        {
            bw.Write(exi.avail_time);
        }
    }
}
