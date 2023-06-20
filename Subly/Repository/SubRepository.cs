using SQLite;
using Subly.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subly.Repository
{
    public class SubRepository
    {
        string _dbPath;
        private SQLiteConnection dbConnection;
        public string statusMessage;

        public SubRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (dbConnection != null)
                return;

            dbConnection = new SQLiteConnection(_dbPath);
            dbConnection.CreateTable<Subscription>();
        }

        public List<Subscription> GetSubs()
        {
            try
            {
                Init();
                return dbConnection.Table<Subscription>().ToList();
            }
            catch (Exception)
            {
                statusMessage = "Failed to retrieve data.";
            }

            return new List<Subscription>();
        }

        public Subscription GetSub(int id)
        {
            try
            {
                Init();
                return dbConnection.Table<Subscription>().FirstOrDefault(q => q.Id == id);
            }
            catch (Exception)
            {
                statusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public int DeleteSub(int id)
        {
            try
            {
                Init();
                return dbConnection.Table<Subscription>().Delete(q => q.Id == id);
            }
            catch (Exception ex)
            {
                statusMessage = "Failed to delete data.";
            }

            return 0;
        }

        public void AddSub(Subscription subscription)
        {
            try
            {
                Init();
                if (subscription == null)
                    throw new Exception("Invalid Subscription Record");

                var result = dbConnection.Insert(subscription);
                statusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
            }
            catch (Exception ex)
            {
                statusMessage = "Failed to Insert data.";
            }
        }

        public void UpdateSub(Subscription subscription)
        {
            try
            {
                Init();
                if (subscription == null)
                    throw new Exception("Invalid Subscription Record");

                var result = dbConnection.Update(subscription);
                statusMessage = result == 0 ? "Update Failed" : "Update Successful";
            }
            catch (Exception ex)
            {
                statusMessage = "Failed to Update data.";
            }
        }
    }
}
