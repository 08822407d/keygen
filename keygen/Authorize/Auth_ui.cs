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

        public ErrType update_Availability(string cert_fname)
        {
            ErrType ret_val = ErrType.E_noerr;
            if (File.Exists(cert_fname))
            {
                string[] lines = File.ReadAllLines(cert_fname);
                string authcode = lines[0];
                string extra_info = RSAdecrypt(this._RSA_privkey, hexStr_to_byteArr(lines[1]));

                double avail_time = 0;
                bool parse_success = Double.TryParse(extra_info, out avail_time);
                if (parse_success)
                {
                    this._ExInfo.avail_time += avail_time * 3600;
                }
                else
                {
                    ret_val = ErrType.E_exinfo;
                }
            }
            return ret_val;
        }

        public void update_time(TimeSpan ts)
        {
            double time_elapsed = ts.TotalSeconds;

            load_exinfo();
            this._ExInfo.avail_time -= time_elapsed;
            if (this._ExInfo.avail_time < 0)
                this._ExInfo.avail_time = 0;
            save_exinfo();
        }
    }
}
