using System;
using System.Text;

using System.IO;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

public class Authorize
{
    private String certificateFile_path = "./cert.txt";
    private String Auth_Req_str;
    private String authorise_code;
        

	public Authorize(String program_name)
	{
        // create the authorise request code authorise system
        // 
        NetworkInterface ni = NetworkInterface.GetAllNetworkInterfaces()[0];
        string mac_str = ni.GetPhysicalAddress().ToString();
        String tmp_val = BitConverter.ToString(Encoding.ASCII.GetBytes(program_name));
        String prog_name_val = tmp_val.Replace("-", String.Empty);
        Auth_Req_str = prog_name_val + mac_str;

        authorise_code = SHA512encrypt(Auth_Req_str);
	}
    
    public String get_authorise_request_str()
    {
        return Auth_Req_str;
    }

    static public string SHA512encrypt(string input)
    {
        SHA512 ident = SHA512.Create();
        byte[] reqcode = Encoding.ASCII.GetBytes(input);
        byte[] hashval = ident.ComputeHash(new MemoryStream(reqcode));
        string hv_str = BitConverter.ToString(hashval).Replace("-", string.Empty);
        return hv_str;
    }

    public String get_authorise_code()
    {
        return authorise_code;
    }

    public String verify()
    {
        String ret_val = get_authorise_request_str();
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
