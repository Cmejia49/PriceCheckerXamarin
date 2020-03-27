using SQLite;
namespace PriceChecker.sqliteHELPER
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
