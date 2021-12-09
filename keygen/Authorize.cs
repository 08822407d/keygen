﻿using System;
using System.Text;

using System.IO;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

public class Authorize
{
    private string certificateFile_path = "./cert.txt";
    private string user_AuthReq_Str ;
    private string authorise_Code ;

	public Authorize(string progname)
	{
        // create the authorise request code authorise system
        user_AuthReq_Str = gen_authorise_request_str(progname);
        authorise_Code = SHA512encrypt(user_AuthReq_Str);
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

    public string get_authorise_code()
    {
        return authorise_Code;
    }
    public string get_userreq_code()
    {
        return user_AuthReq_Str;
    }

    static public string SHA512encrypt(string input)
    {
        SHA512 ident = SHA512.Create();
        byte[] reqcode = Encoding.ASCII.GetBytes(input);
        byte[] hashval = ident.ComputeHash(new MemoryStream(reqcode));
        string hv_str = BitConverter.ToString(hashval).Replace("-", string.Empty);
        return hv_str;
    }

    public String verify()
    {
        String ret_val = gen_authorise_request_str("testprog");
        if (File.Exists(certificateFile_path))
        {
            String[] lines = File.ReadAllLines(certificateFile_path);
            if (ret_val.Equals(lines[0]))
            {
                ret_val = null;
            }
        }
        return ret_val;
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
}
