using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SummerTestApp.Models;

namespace SummerTestApp.Resources.DataHelper
{
    internal class DataBase
    {
        private readonly string _folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(_folder, "User.db")))
                {
                    connection.CreateTable<User>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool InsertIntoTableUser(User user)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(_folder, "User.db")))
                {
                    connection.Insert(user);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public List<User> SelectTablePerson()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(_folder, "User.db")))
                {
                    return connection.Table<User>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public bool UpdateTableUser(User user)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(_folder, "User.db")))
                {
                    connection.Query<User>(
                        "UPDATE User set CurrentDate=?,CurrentTime=?,CigPerDay=?,PacketPrice=?,Resin=?,Nicotin=? Where Id=?",
                        user.CurrentDate, user.CurrentTime, user.CigPerDay, user.PacketPrice, user.Resin, user.Nicotin);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool DeleteTableUser(User user)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(_folder, "User.db")))
                {
                    connection.Delete(user);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public bool SelectQueryTableUser(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(_folder, "User.db")))
                {
                    connection.Query<User>(
                        "SELECT * FROM User Where Id=?",
                        id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        private static DataBase _instance;

        private DataBase()
        {
        }

        public static DataBase GetInstance()
        {
            return _instance ?? (_instance = new DataBase());
        }
    }
}