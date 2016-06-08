using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;
using TestingClasses.Models;
using TestingClasses.Repositories;

namespace TestingClasses.Services
{
    public class ManageRepositoriesService
    {
        private readonly DbService _dbService = new DbService();
        private readonly GetDataService _getDataService = new GetDataService();
        public readonly Repository<TrainerModel> TrainerRepository = new Repository<TrainerModel>(DbService.DbConn);
        public readonly Repository<GroupModel> GroupRepository = new Repository<GroupModel>(DbService.DbConn);

        public ManageRepositoriesService()
        {
            _dbService.CreateDb();
        }

        public void ClearRepositories()
        {
            TrainerRepository.RemoveAll();
            GroupRepository.RemoveAll();
        }

        public async Task GetUserData()
        {
            TrainerRepository.RemoveAll();
            TrainerModel trainer = await _getDataService.GetTrainerInfo();
            TrainerRepository.Add(trainer);
        }

        public async Task GetGroups()
        {
            GroupRepository.RemoveAll();
            try
            {
                ObservableCollection<GroupModel> groups = await _getDataService.GetGroupsInfo();
                foreach (var groupModel in groups)
                {
                    GroupRepository.Add(groupModel);
                }
            }
            catch (Exception e)
            {
                MessageDialog dialog = new MessageDialog("Sprawdź połączenie z internetem!");
                await dialog.ShowAsync();
            }
           
        }

        public bool CheckIfTrainerDataExists()
        {
            return TrainerRepository.GetFirstItem() != null;
        }
    }
}
