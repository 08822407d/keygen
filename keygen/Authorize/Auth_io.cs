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
        private void load_AvailInfo()
        {
            BinaryReader br = new BinaryReader(File.Open(this._AuthInfo_File, FileMode.Open));
            read_AvailInfo(br, ref this._AvailInfo);
            br.Close();
        }

        private void save_AvailInfo()
        {
            BinaryWriter bw = new BinaryWriter(File.Open(this._AuthInfo_File, FileMode.Truncate));
            write_AvailInfo(bw, this._AvailInfo);
            bw.Flush();
            bw.Close();
        }

        private void read_AvailInfo(BinaryReader br, ref Avail_Info info)
        {
            info.avail_time = br.ReadDouble();
        }

        private void write_AvailInfo(BinaryWriter bw, Avail_Info info)
        {
            bw.Write(info.avail_time);
        }
    }
}
