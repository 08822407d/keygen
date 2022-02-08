using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Authorize
{
    struct extra_info{
        //public extra_info()
        //{
        //    avail_time = 0;
        //}
        // all time counted by seconds
        public double avail_time;
    }

    public enum ErrType {
        E_noerr,
        E_authcode,
        E_exinfo,
    };

    public partial class Auth
    {
        private string _AuthInfo_File = "./cert.bin";

        private string _AuthReq_Code;
        private string _Auth_Code;

        private string _RSA_pubkey = "";
        private string _RSA_privkey = "";

        private extra_info _ExInfo;

        public Auth(string progname, string _RSA_pubkey, string _RSA_privkey)
        {
            this._RSA_pubkey = _RSA_pubkey;
            this._RSA_privkey = _RSA_privkey;

            init_exinfo(ref this._ExInfo);
            if (!File.Exists(_AuthInfo_File))
            {
                FileStream fs = File.Create(_AuthInfo_File);
                fs.Close();
                save_exinfo();
            }
            // create the authorise request code authorise system
            this._AuthReq_Code = gen_authorise_request_str(progname);
            this._Auth_Code = SHA512encrypt(_AuthReq_Code);
        }
        
        public string User_AuthReq_Str
        {
            get => _AuthReq_Code;
        }

        public string get_userreq_code()
        {
            return _AuthReq_Code;
        }

        private void init_exinfo(ref extra_info exinfo)
        {
            exinfo.avail_time = 0;
        }
    }
}
