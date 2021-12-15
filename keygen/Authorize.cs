using System;
using System.Text;

using System.IO;
using System.Security.Cryptography;
using System.Net.NetworkInformation;

public class Authorize
{
    private string auth_info_fname = "./cert.bin";
    private string user_AuthReq_Str;
    private string authorise_Code;

    private string RSA_pubkey = "<RSAKeyValue><Modulus>r83mkPS9x1sjGaVQPWs+pJMP2ZaLp+w4IRwAcbo0JnS8fKjV5xmaw8PL0NermCoEUCt6NNSiJT6FFm29ibt06ILRQUlFJBZEHoGMSirXDHeV2EZx5mhnH9CWYRi2GgdsFgYZU8N/nJRJ4gF5mAzA0rznETQKGDQlPa1v+FVCFPk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
    private string RSA_privkey = "<RSAKeyValue><Modulus>r83mkPS9x1sjGaVQPWs+pJMP2ZaLp+w4IRwAcbo0JnS8fKjV5xmaw8PL0NermCoEUCt6NNSiJT6FFm29ibt06ILRQUlFJBZEHoGMSirXDHeV2EZx5mhnH9CWYRi2GgdsFgYZU8N/nJRJ4gF5mAzA0rznETQKGDQlPa1v+FVCFPk=</Modulus><Exponent>AQAB</Exponent><P>zsbDIj7HYZd3VjrZc962Tj8ihDsdeIv8eSYv56s53ug5UPvech7DfXZN/Lqq25KelGezIkf7OVa+wLF7Pnxhjw==</P><Q>2aenwRoN10cHeMuA3Zn6nv4nDKkLCZf2xlt9jE5cONqZKO+Fqpo08pshHTlJYfEevKJ2EcnFX7hbBgGCtV7M9w==</Q><DP>u12+CfTrBBKU700KKAWCGmr5IurSLJ5kW37v37P3D3ZMIYbpLW2U5MXjqwOWuLol+gHxfznMekuRM9he/eMFHw==</DP><DQ>gwwZyf9I5BxFGGrW7RX/uujlVA8XsTAJCgceAXNQvX6IhwgoH773MDdM6c6LK2hFDGh41F768pYKYARa0Z8Bow==</DQ><InverseQ>GbKOIam1plYIJVa4XGTN/yOsTFt5iEvzFLNhs+gWQIoAKxIPlmg6sRNGjTayOMCUi7EeBfegL+9/4xuBIhaXdQ==</InverseQ><D>B0vkZd/CgKOnsUjLK8FnuCziW4WEBlQngDhJTG8N+wqdSA850X2ejsFxlBlfZdFYnHsxdz/b+u+9VlD3rN+62ln2AC/6vssxjI88P9glsmbrhgDDAT6tSww6b7pGmLM5szP+NBQX6ngWX658PXA8eMchQ/+7rucg5ByPe1TPkIE=</D></RSAKeyValue>";

    bool avilable = false;
    private long latest_time = 0;

	public Authorize(string progname)
	{
        this.latest_time = Environment.TickCount / 1000;

        // create the authorise request code authorise system
        user_AuthReq_Str = gen_authorise_request_str(progname);
        authorise_Code = SHA512encrypt(user_AuthReq_Str);

        this.avilable = load_avilability();
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

    public void read_certfile(string cert_fname)
    {
        if (File.Exists(cert_fname))
        {
            string[] lines = File.ReadAllLines(cert_fname);
            string authcode = lines[0];
            string extra_info = RSAdecrypt(this.RSA_privkey, hexStr_to_byteArr(lines[1]));
        }
    }

    public bool load_avilability()
    {
        bool ret_val = false;
        if (File.Exists(auth_info_fname))
        {
            BinaryReader br = new BinaryReader(File.Open(auth_info_fname, FileMode.Open));
            double time = br.ReadDouble();
            if (time > 0)
                ret_val = true;
        }
        return ret_val;
    }

    public void update_time()
    {
        long current_time = Environment.TickCount / 1000;
        long time_elapsed = current_time - this.latest_time;

        BinaryReader br = new BinaryReader(File.Open(auth_info_fname, FileMode.Open));
        double avilable_time = br.ReadDouble();
        br.Close();

        BinaryWriter bw = new BinaryWriter(File.Open(auth_info_fname, FileMode.Truncate));
        bw.Write(avilable_time - time_elapsed);
        bw.Flush();
        bw.Close();

        this.latest_time = current_time;
    }

}
