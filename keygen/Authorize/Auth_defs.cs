using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorize
{
    struct extra_info{
        public double avail_time;
    }

    public enum ErrType {
        E_noerr,
        E_authcode,
        E_exinfo,
    };

    public partial class Auth
    {
        private string auth_info_fname = "./cert.bin";
        private string user_AuthReq_Str;
        private string authorise_Code;

        private string RSA_pubkey = "";
        private string RSA_privkey = "";

        private extra_info exinfo;

        private long latest_time = 0;

        public bool available = false;

        public Auth(string progname, string RSA_pubkey, string RSA_privkey)
        {
            this.RSA_pubkey = RSA_pubkey;
            this.RSA_privkey = RSA_privkey;

            this.latest_time = Environment.TickCount / 1000;

            // create the authorise request code authorise system
            user_AuthReq_Str = gen_authorise_request_str(progname);
            authorise_Code = SHA512encrypt(user_AuthReq_Str);

            this.available = get_availability();
        }
    }
}
