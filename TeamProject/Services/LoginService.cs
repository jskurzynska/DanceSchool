using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamProject.Models;

namespace TeamProject.Services
{
    public class LoginService: BaseService
    {
        public async Task<string> Login(string username, string password)
        {
            try
            {
                var client = GetClient();
                var values = new Dictionary<string,string>
                {
                    { "username", username },
                    { "password", password }
                };
                var requestParams = new FormUrlEncodedContent(values);
                var httpResponse = await client.PostAsync("/api/login", requestParams);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    LoginSession.Token = result;
                    return result;
                }
                else
                {
                    string content = await httpResponse.Content.ReadAsStringAsync();
                    if (content == string.Empty)
                    {
                        content = "Invalid username or password.";
                    }
                    
                    throw new InvalidOperationException(content);
                }
            }
            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }

       }
}
