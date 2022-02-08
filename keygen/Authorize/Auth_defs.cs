using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net.NetworkInformation;

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
        string program_name = "";


        // this code only used to verify, sended from user to developer,
        // developer generate auth-code with this code by keygen.
        public string User_AuthReq_Str { get; set; }
        // user compare this code with developer generated code.
        // two code equal means cert-file is generated for this user.
        public string Auth_Code { get; }

        private string _RSA_pubkey = "";
        private string _RSA_privkey = "";

        private Avail_Info _AvailInfo;

        public Auth(string progname, string _RSA_pubkey, string _RSA_privkey)
        {
            this.program_name = progname;
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
            gen_authorise_request_str();
            this.Auth_Code = SHA512encrypt(User_AuthReq_Str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program_name"></param>
        /// <returns></returns>
        private void gen_authorise_request_str()
        {
            // get ticks from boot till now and ticks of DateTime
            string bootticks_hex = Environment.TickCount.ToString("X");
            string dateticks_hex = DateTime.Now.Ticks.ToString("X");
            // get MAC address
            NetworkInterface ni = NetworkInterface.GetAllNetworkInterfaces()[0];
            string macaddr_hex = ni.GetPhysicalAddress().ToString();
            // convert program_name ASCII code to hex format
            string tmp_val = BitConverter.ToString(Encoding.ASCII.GetBytes(this.program_name));
            string progname_hex = tmp_val.Replace("-", string.Empty);

            // concatenate all these strings
            this.User_AuthReq_Str = progname_hex + macaddr_hex + bootticks_hex + dateticks_hex;
        }

        private void init_exinfo(ref Avail_Info exinfo)
        {
            exinfo.avail_time = 0;
        }
    }
}
