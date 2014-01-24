using System.Web.Services;
using Advanced_Encryption_Standard;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]

public class AESService : System.Web.Services.WebService
{
    public AESService()
    {
    }

    [WebMethod]
    public string Decrypt(string ciphertext)
    {
        try
        {
            return AES.Decrypt(ciphertext);
        }
        catch { return ""; }
    }

    [WebMethod]
    public string Encrypt(string plaintext)
    {
        try
        {
            return AES.Encrypt(plaintext);
        }
        catch { return ""; }
    }
    
}