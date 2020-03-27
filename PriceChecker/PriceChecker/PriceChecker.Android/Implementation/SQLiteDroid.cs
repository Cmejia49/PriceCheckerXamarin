using System.IO;
using PriceChecker.sqliteHELPER;
using SQLite;
using PriceChecker.Droid.Implementation;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteDroid))]

namespace PriceChecker.Droid.Implementation
{
    public class SQLiteDroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "ProductDataBase";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}