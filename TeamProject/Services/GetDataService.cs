using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamProject.Models;

namespace TeamProject.Services
{
    public class GetDataService : BaseService
    {
        public async Task<TrainerModel> GetTrainerInfo()
        {
            var trainer = new TrainerModel();
            try
            {
                var client = GetClient();
                client.DefaultRequestHeaders.Add("token", LoginSession.Token);

                var httpResponse = await client.GetAsync("/api/userData");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string result = await httpResponse.Content.ReadAsStringAsync();
                    trainer = JsonConvert.DeserializeObject<TrainerModel>(result);
                    return trainer;
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

        public async Task<ObservableCollection<GroupModel>> GetGroupsInfo()
        {
            var groups = new ObservableCollection<GroupModel>();
            try
            {
                var client = GetClient();
                client.DefaultRequestHeaders.Add("token", (string)AppService.LocalSettings.Values["loginToken"]);

                var httpResponse = await client.GetAsync("/api/myGroups");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string result = await httpResponse.Content.ReadAsStringAsync();
                    groups = JsonConvert.DeserializeObject<ObservableCollection<GroupModel>>(result);
                    return groups;
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
