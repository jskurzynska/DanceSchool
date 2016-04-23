using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using MyWPClient;
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
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add(new HttpValue("username", username));
                query.Add(new HttpValue("password", password));

                var httpResponse = await client.PostAsync("/login", new StringContent(query.ToString(true), Encoding.UTF8));

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    LoginSession.Token = result;
                    return result;
                }
                else
                {
                    string content = await httpResponse.Content.ReadAsStringAsync();
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
