using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Security;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestingClasses.Models;

namespace TestingClasses.Services
{
    public class GetDataService : BaseService
    {
        public async Task<TrainerModel> GetTrainerInfo(HttpClient httpClient= null)
        {
            try
            {
                var client = GetClient();
                client.DefaultRequestHeaders.Add("token", (string)AppService.LocalSettings.Values["loginToken"]);
                if (httpClient != null)
                {
                    client = httpClient;
                }

                var httpResponse = await client.GetAsync("/api/userData");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string result = await httpResponse.Content.ReadAsStringAsync();
                    var trainer = JsonConvert.DeserializeObject<TrainerModel>(result);
                    if (trainer.PhotoUrl != null)
                    {
                        await GetUserPhoto(trainer.PhotoUrl);
                    }
                    return trainer;
                }
                string content = await httpResponse.Content.ReadAsStringAsync();
                throw new InvalidOperationException(content);
            }
            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }

        public async Task GetUserPhoto(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (var response = await client.GetAsync(url))
                    {
                        response.EnsureSuccessStatusCode();
                        using (var inputStream = await response.Content.ReadAsStreamAsync())
                        {
                            using (var ms = new MemoryStream())
                            {
                                inputStream.CopyTo(ms);
                                byte[] imageBytes = ms.ToArray();
                                AppService.SaveImageInAppSettings("userPhoto.png", imageBytes);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }

        public async Task<ObservableCollection<GroupModel>> GetGroupsInfo()
        {
            try
            {
                var client = GetClient();
                client.DefaultRequestHeaders.Add("token", (string)AppService.LocalSettings.Values["loginToken"]);

                var httpResponse = await client.GetAsync("/api/myGroups");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string result = await httpResponse.Content.ReadAsStringAsync();
                    var groups = JsonConvert.DeserializeObject<ObservableCollection<GroupModel>>(result);
                    return groups;
                }
                string content = await httpResponse.Content.ReadAsStringAsync();
                throw new InvalidOperationException(content);
            }
            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }

        public async Task<ObservableCollection<ParticipantModel>> GetPresenceList(int groupId)
        {
            try
            {
                var client = GetClient();
                client.DefaultRequestHeaders.Add("token", (string) AppService.LocalSettings.Values["loginToken"]);

                var httpResponse = await client.GetAsync($"/api/attendance/{groupId}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string result = await httpResponse.Content.ReadAsStringAsync();
                    var participants = JsonConvert.DeserializeObject<ObservableCollection<ParticipantModel>>(result);
                    return participants;
                }
                string content = await httpResponse.Content.ReadAsStringAsync();
                throw new InvalidOperationException(content);
            }
            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }

       public async Task<ObservableCollection<VoucherTemplateModel>> GetVoucherTemplates(int groupId)
        {
            try
            {
                var client = GetClient();
                client.DefaultRequestHeaders.Add("token", (string)AppService.LocalSettings.Values["loginToken"]);

                var httpResponse = await client.GetAsync($"/api/voucherTemplates/{groupId}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string result = await httpResponse.Content.ReadAsStringAsync();
                    var vouchers = JsonConvert.DeserializeObject<ObservableCollection<VoucherTemplateModel>>(result);
                    return vouchers;
                }
                string content = await httpResponse.Content.ReadAsStringAsync();
                throw new InvalidOperationException(content);
            }
            catch (Exception ex)
            {
                throw new SecurityException(ex.Message);
            }
        }
    }
}
