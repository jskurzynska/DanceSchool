using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http.Filters;
using WindowsRuntime.HttpClientFilters;
using TeamProject.Models;

namespace TeamProject.Services
{
    public abstract class BaseService
    {
        protected BaseService() { }

        public string GetServiceAddress()
        {
            return "https://vps255073.ovh.net/";
        }

        public HttpClient GetClient()
        {
            //nie walidować certyfikatu który jest wyexpirowany
            var filter = new HttpBaseProtocolFilter();
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.RevocationFailure);

            var client = new HttpClient(new WinRtHttpClientHandler(filter))
            {
                Timeout = new TimeSpan(0,0,2,0),
                BaseAddress = new Uri(GetServiceAddress())          
            };

            if (LoginSession.Token != null)
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                    String.Format("Bearer {0}", LoginSession.Token));
            }
            return client;
        }
    }
}
