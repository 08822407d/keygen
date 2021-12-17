﻿using System;
using System.Text;

using System.IO;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

struct extra_info{
    public double avail_time;
}

public enum ErrType {
    E_noerr,
    E_authcode,
    E_exinfo,
};

public class Authorize
{
    private string auth_info_fname = "./cert.bin";
    private string user_AuthReq_Str;
    private string authorise_Code;

    private string RSA_pubkey = "";
    private string RSA_privkey = "";

    private extra_info exinfo;

    private long latest_time = 0;

    public bool available = false;

	public Authorize(string progname, string RSA_pubkey, string RSA_privkey)
	{
        this.RSA_pubkey = RSA_pubkey;
        this.RSA_privkey = RSA_privkey;

        this.latest_time = Environment.TickCount / 1000;

        // create the authorise request code authorise system
        user_AuthReq_Str = gen_authorise_request_str(progname);
        authorise_Code = SHA512encrypt(user_AuthReq_Str);

        this.available = get_availability();
	}
    
    static public string gen_authorise_request_str(string program_name)
    {
        // get ticks from boot till now and ticks of DateTime
        string bootticks_hex = Environment.TickCount.ToString("X");
        string dateticks_hex = DateTime.Now.Ticks.ToString("X");
        // get MAC address
        NetworkInterface ni = NetworkInterface.GetAllNetworkInterfaces()[0];
        string macaddr_hex = ni.GetPhysicalAddress().ToString();
        // convert program_name ASCII code to hex format
        string tmp_val = BitConverter.ToString(Encoding.ASCII.GetBytes(program_name));
        string progname_hex = tmp_val.Replace("-", string.Empty);

        // concatenate all these strings
        string ret_val = progname_hex + macaddr_hex + bootticks_hex + dateticks_hex;

        return ret_val;
    }

    static public string SHA512encrypt(string input)
    {
        SHA512 ident = SHA512.Create();
        byte[] reqcode = Encoding.ASCII.GetBytes(input);
        byte[] hashval = ident.ComputeHash(new MemoryStream(reqcode));
        string hv_str = BitConverter.ToString(hashval).Replace("-", string.Empty);
        return hv_str;
    }

    /// <summary>
    ///      
    /// </summary>
    /// <returns>return[0] is private key, return[1] is public key</returns>
    static public String[] gen_RSAkeys()
    {
        String[] keys = new String[2];
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        keys[0] = RSA.ToXmlString(true);
        keys[1] = RSA.ToXmlString(false);
        return keys;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pubkey"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    static public byte[] RSAencrypt(string pubkey, string content)
    {
        ASCIIEncoding byteconv = new ASCIIEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        RSA.FromXmlString(pubkey);
        return RSA.Encrypt(byteconv.GetBytes(content), false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="privkey"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    static public string RSAdecrypt(string privkey, byte[] content)
    {
        ASCIIEncoding strconv = new ASCIIEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        RSA.FromXmlString(privkey);
        return strconv.GetString(RSA.Decrypt(content, false));
    }

    static public byte[] hexStr_to_byteArr(string hexstr)
    {
        int len = hexstr.Length / 2;
        byte[] bytearr = new byte[len];

        for (int i = 0; i < len; i++)
        {
            bytearr[i] = Convert.ToByte(hexstr.Substring(i * 2, 2), 16);
        }   
        return bytearr;
    }


    public string get_authorise_code()
    {
        return authorise_Code;
    }

    public string get_userreq_code()
    {
        return user_AuthReq_Str;
    }

    private void read_exinfo()
    {
        BinaryReader br = new BinaryReader(File.Open(this.auth_info_fname, FileMode.Open));
        this.exinfo.avail_time = br.ReadDouble();
        br.Close();
    }

    private void write_exinfo()
    {
        BinaryWriter bw = new BinaryWriter(File.Open(auth_info_fname, FileMode.Truncate));
        bw.Write(this.exinfo.avail_time);
        bw.Flush();
        bw.Close();
    }

    public ErrType read_certfile(string cert_fname)
    {
        ErrType ret_val = ErrType.E_noerr;
        if (File.Exists(cert_fname))
        {
            string[] lines = File.ReadAllLines(cert_fname);
            string authcode = lines[0];
            string extra_info = RSAdecrypt(this.RSA_privkey, hexStr_to_byteArr(lines[1]));

            double avail_time = 0;
            bool parse_success = Double.TryParse(extra_info, out avail_time);
            if (parse_success)
            {
                this.exinfo.avail_time += avail_time * 3600;
            }
            else
            {
                ret_val = ErrType.E_exinfo;
            }
        }
        return ret_val;
    }

    public bool get_availability()
    {
        bool ret_val = false;
        if (File.Exists(auth_info_fname))
        {
            read_exinfo();
            if (this.exinfo.avail_time > 0)
                ret_val = true;
        }
        return ret_val;
    }

    public void update_time()
    {
        long current_time = Environment.TickCount / 1000;
        long time_elapsed = current_time - this.latest_time;

        read_exinfo();

        this.exinfo.avail_time -= time_elapsed;
        if (this.exinfo.avail_time < 0)
            this.exinfo.avail_time = 0;

        write_exinfo();

        this.latest_time = current_time;
    }

}
