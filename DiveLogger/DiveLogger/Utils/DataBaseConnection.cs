using MongoDB.Driver;

namespace DiveLogger.Utils
{
    public class DataBaseConnection 
    {
        public static IMongoDatabase DB { get; set; }

        public static IMongoDatabase Connect()
        {
           return DB = new  MongoClient("mongodb://divelogger:divelogger123@ds163119.mlab.com:63119/divelogger").GetDatabase("divelogger");
        } 
    }
}
