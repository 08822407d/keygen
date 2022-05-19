using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
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

	public class AuthData
	{
		public string RSA_PrivKey { get; set; }
		public string RSA_PubKey { get; set; }

		Dictionary<string, double> AuthGroups;

		public AuthData()
		{
			RSA_PrivKey = "";
			RSA_PubKey = "";
			AuthGroups = new Dictionary<string, double>();
		}

		public void add_AuthGroup(string key, double val)
		{
			AuthGroups.Remove(key);
			AuthGroups.Add(key, val);
		}

		public void remove_AuthGroup(string key)
		{
			AuthGroups.Remove(key);
		}
	}

	public class CfgPack
	{
		const string cfgfile_dir = "./configs/";
		const string default_cfg_path = cfgfile_dir + "cfg.json";

		Dictionary<string, AuthData> Acfgs;

		public CfgPack()
		{
			if (!Directory.Exists(cfgfile_dir))
				Directory.CreateDirectory(cfgfile_dir);

			Acfgs = new Dictionary<string, AuthData>();

			reloadSelf();
		}

		public void reloadSelf()
		{
			openACfile();
		}
		private void openACfile()
		{
			string AC_path = default_cfg_path;
			Acfgs.Clear();
			if (!File.Exists(AC_path))
			{
				FileStream fs = File.Create(AC_path);
				fs.Close();
			}
			// 读取json
			StreamReader sr = new StreamReader(AC_path);
			string jsonstr = sr.ReadLine();
			sr.Close();
			// 解析json
			if (jsonstr != null && !jsonstr.Equals(""))
				Acfgs = JsonSerializer.Deserialize<Dictionary<string, AuthData>>(jsonstr);
		}

		public AuthData getAcfg(string key)
		{
			if (Acfgs.ContainsKey(key))
				return Acfgs[key];
			else
				return null;
		}
		public void addAcfg(string key, AuthData AD)
		{
			Acfgs.Remove(key);
			Acfgs.Add(key, AD);
		}
		public void removeAcfg(string key)
		{
			Acfgs.Remove(key);
		}
		public void flushAC()
		{
			string AC_path = default_cfg_path;
			Acfgs.Clear();
			if (!File.Exists(AC_path))
			{
				FileStream fs = File.Create(AC_path);
				fs.Close();
			}

			string jsonstr = JsonSerializer.Serialize(Acfgs);
			StreamWriter sw = new StreamWriter(default_cfg_path, false);
			sw.WriteLine(jsonstr);
			sw.Flush();
			sw.Close();
		}
	}
}
