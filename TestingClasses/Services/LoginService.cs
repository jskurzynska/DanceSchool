using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security;
using System.Threading.Tasks;

namespace TestingClasses.Services
{
    public class LoginService : BaseService
    {
        public async Task Login(string username, string password)
        {
            try
            {
                var client = GetClient();
                var values = new Dictionary<string, string>
                {
                    ["username"] = username,
                    ["password"] = password
                };
                var requestParams = new FormUrlEncodedContent(values);
                var httpResponse = await client.PostAsync("/api/login", requestParams);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    AppService.SaveTokenInAppSettings(result);
                }
                else
                {
                    var content = await httpResponse.Content.ReadAsStringAsync();
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
