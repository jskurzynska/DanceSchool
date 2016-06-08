using System.IO;
using Windows.Storage;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using TestingClasses.Models;

namespace TestingClasses.Services
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
                dbConnection.CreateTable<GroupModel>();
            }
        }

    }
}
