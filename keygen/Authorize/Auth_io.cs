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
        private ErrType parse_CertFile(string certfile)
        {
            ErrType ret_val = ErrType.E_NoErr;

            string[] lines = File.ReadAllLines(certfile);
            string authcode = lines[0];
            if (authcode.Equals(this.Auth_Code))
            {
                string info = RSAdecrypt(this._RSA_privkey, hexStr_to_byteArr(lines[1]));

                double avail_time = 0;
                bool parse_success = Double.TryParse(info, out avail_time);
                if (parse_success)
                {
                    load_AvailInfo();
                    this._AvailInfo.avail_time += avail_time * 3600;
                    save_AvailInfo();

                    this.gen_authorise_request_str();
                }
                else
                {
                    ret_val = ErrType.E_AvailInfo;
                }
            }    
            else
            {
                ret_val = ErrType.E_AuthCode;
            }
            return ret_val;
        }

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
