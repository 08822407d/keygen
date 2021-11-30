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

        authorise_code = compute_authorise_code(Auth_Req_str);
	}
    
    public String get_authorise_request_str()
    {
        return Auth_Req_str;
    }

    public String compute_authorise_code(String input)
    {
        SHA512 ident = SHA512.Create();
        return BitConverter.ToString(Encoding.ASCII.GetBytes(input)).Replace("-", String.Empty);
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
    /// return[0] is private key
    /// return[1] is public key
    /// </summary>
    /// <returns></returns>
    static public String[] gen_RSAkeys()
    {
        String[] keys = new String[2];
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        keys[0] = RSA.ToXmlString(true);
        keys[1] = RSA.ToXmlString(false);
        return keys;
    }
}
