using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using TeamProject.Models;
using TeamProject.Repositories;

namespace TeamProject.Services
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

        public async Task GetUserData()
        {
            TrainerModel trainer = await _getDataService.GetTrainerInfo();
            TrainerRepository.Add(trainer);
        }

        public async Task GetGroups()
        {
            ObservableCollection<GroupModel> groups = await _getDataService.GetGroupsInfo();
            foreach (var groupModel in groups)
            {
                GroupRepository.Add(groupModel);
            }
        }

        public bool CheckIfTrainerDataExists()
        {
            if (TrainerRepository.GetFirstItem() != null)
            {
                return true;
            }
            return false;
        }

    }
}
