using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestingClasses.Models;

namespace TestingClasses.Services
{
    public class PostDataService: BaseService
    {
        public async Task PostPresenceList(ObservableCollection<ParticipantModel> participants, int groupId)
        {
            try
            {
                var client = GetClient();
                var participantsJson = JsonConvert.SerializeObject(participants);
                StringContent content = new StringContent(participantsJson, System.Text.Encoding.UTF8,
                    "application/json");

                var httpResponse = await client.PostAsync($"/api/attendance/{groupId}", content);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    string result = await httpResponse.Content.ReadAsStringAsync();
                    throw new InvalidOperationException(result);
                }
            }
            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }

        public async Task PostPayment(PaymentModel paymentModel)
        {
            try
            {
                var client = GetClient();
                var paymentJson = JsonConvert.SerializeObject(paymentModel);
                var content = new StringContent(paymentJson, System.Text.Encoding.UTF8,
                    "application/json");

                var httpResponse = await client.PostAsync($"/api/payment", content);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    throw new InvalidOperationException(result);
                }
            }
            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }


    }
}
