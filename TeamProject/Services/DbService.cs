using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using TeamProject.Models;

namespace TeamProject.Services
{
    public class DbService
    {
        private const string DbName = "db.sqlite";

        public static SQLiteConnection DbConn => new SQLiteConnection(
            new SQLitePlatformWinRT(),
            Path.Combine(ApplicationData.Current.LocalFolder.Path, DbName));

        public void CreateDb()
        {
            using (var dbConnection = DbConn)
            {
                dbConnection.CreateTable<TrainerModel>();
               // dbConnection.CreateTable<GroupModel>();
                //dbConnection.CreateTable<ParticipantModel>();
            }
        }

    }
}
