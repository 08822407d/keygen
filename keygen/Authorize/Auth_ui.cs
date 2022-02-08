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
        public ErrType update_Availability(string certfile)
        {
            if (File.Exists(certfile))
            {
                return parse_CertFile(certfile);
            }
            else
            {
                return ErrType.E_NoFile;
            }
        }

        public void update_time(TimeSpan ts)
        {
            double time_elapsed = ts.TotalSeconds;

            load_AvailInfo();
            this._AvailInfo.avail_time -= time_elapsed;
            if (this._AvailInfo.avail_time < 0)
                this._AvailInfo.avail_time = 0;
            save_AvailInfo();
        }
    }
}
