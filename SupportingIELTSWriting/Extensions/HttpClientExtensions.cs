using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SupportingIELTSWriting.Extensions
{
    public static class HttpClientExtensions
    {
        public static void SetBasicAuthentication(this HttpClient client, string username, string password) => client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(username, password);
        public static void SetToken(this HttpClient client, string scheme, string token) => client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, token);
        public static void SetBearerToken(this HttpClient client, string token) => client.SetToken(JwtConstants.TokenType, token);
    }

    public class BasicAuthenticationHeaderValue : System.Net.Http.Headers.AuthenticationHeaderValue
    {
        public BasicAuthenticationHeaderValue(string username, string password) : base("Basic", EncodeCredential(username,password))
        {

        }

        private static string EncodeCredential(string username, string password)
        {
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string credential = String.Format("{0}:{1}", username, password);

            return Convert.ToBase64String(encoding.GetBytes(credential));
        }
    }
}
