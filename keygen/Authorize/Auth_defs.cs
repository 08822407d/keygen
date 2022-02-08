using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Authorize
{
    struct Avail_Info {
        //public Avail_Info()
        //{
        //    avail_time = 0;
        //}
        // all time counted by seconds
        public double avail_time;

        public void Add(Avail_Info adder)
        {
            avail_time += adder.avail_time;
        }
    }

    public enum ErrType {
        E_NoErr,
        E_NoFile,
        E_AuthCode,
        E_AvailInfo,
    };

    public partial class Auth
    {
        private string _AuthInfo_File = "./cert.bin";
        public string User_AuthReq_Str { get; }
        public string Auth_Code { get; }

        private string _RSA_pubkey = "";
        private string _RSA_privkey = "";

        private Avail_Info _AvailInfo;

        public Auth(string progname, string _RSA_pubkey, string _RSA_privkey)
        {
            this._RSA_pubkey = _RSA_pubkey;
            this._RSA_privkey = _RSA_privkey;

            init_exinfo(ref this._AvailInfo);
            if (!File.Exists(_AuthInfo_File))
            {
                FileStream fs = File.Create(_AuthInfo_File);
                fs.Close();
                save_AvailInfo();
            }
            // create the authorise request code authorise system
            this.User_AuthReq_Str = gen_authorise_request_str(progname);
            this.Auth_Code = SHA512encrypt(User_AuthReq_Str);
        }

        private void init_exinfo(ref Avail_Info exinfo)
        {
            exinfo.avail_time = 0;
        }
    }
}
