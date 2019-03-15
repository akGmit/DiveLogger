using MongoDB.Driver;
using System;

namespace DiveLogger.Utils
{
    public class DataBaseConnection 
    {
        public static IMongoDatabase DB { get; set; }

        public static IMongoDatabase Connect()
        {
            try
            {
                DB = new MongoClient("mongodb://divelogger:divelogger123@ds163119.mlab.com:63119/divelogger").GetDatabase("divelogger");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return DB;
        } 
    }
}
