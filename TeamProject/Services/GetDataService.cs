﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Security;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using TeamProject.Models;

namespace TeamProject.Services
{
    public class GetDataService : BaseService
    {
        public async Task<TrainerModel> GetTrainerInfo()
        {
            try
            {
                var client = GetClient();
                client.DefaultRequestHeaders.Add("token", (string)AppService.LocalSettings.Values["loginToken"]);

                var httpResponse = await client.GetAsync("/api/userData");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string result = await httpResponse.Content.ReadAsStringAsync();
                    var trainer = JsonConvert.DeserializeObject<TrainerModel>(result);
                    await GetUserPhoto(trainer.PhotoUrl);
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
    }
}
