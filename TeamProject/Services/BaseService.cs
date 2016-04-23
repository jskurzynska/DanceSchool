using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http.Filters;
using TeamProject.Models;

namespace TeamProject.Services
{
    public abstract class BaseService
    {
        protected BaseService() { }

        public string GetServiceAddress()
        {
            return "https://vps255073.ovh.net/api";
        }

        public HttpClient GetClient()
        {

            var client = new HttpClient
            {
                Timeout = new TimeSpan(0,0,2,0),
                BaseAddress = new Uri(GetServiceAddress())
                
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            if (LoginSession.Token != null)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                    String.Format("Bearer {0}", LoginSession.Token));
            }

            return client;

        }

    }

}
