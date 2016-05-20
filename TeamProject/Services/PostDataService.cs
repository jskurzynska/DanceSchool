using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class PostDataService: BaseService
    {
        public async Task PostPresenceList(ObservableCollection<ParticipantModel> participants,int groupId)
        {
            try
            {
                var client = GetClient();
                var participantsJson = JsonConvert.SerializeObject(participants);
                StringContent content = new StringContent(participantsJson, System.Text.Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync($"/api/attendance/{groupId}",content);

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
    }
}
