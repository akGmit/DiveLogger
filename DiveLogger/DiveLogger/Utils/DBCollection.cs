using DiveLogger.ViewModels;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiveLogger.Utils
{
    public static class DBCollection
    {
        private static string userNameList = "userNameList";
        //private static IMongoCollection<BsonDocument> collection;

        private static IMongoCollection<BsonDocument> Get_Collection(string collectionName)
        {
            return DataBaseConnection.DB.GetCollection<BsonDocument>(collectionName);
        }

        public static bool Create_User(UserModel newUser)
        {
            if(!UserNameExists(newUser.UserName))
            {
                Get_Collection("users").InsertOne(newUser.ToBsonDocument());
                return true;
            }
            return false;
        }

        public static bool LogIn(UserModel user)
        {
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = builder.Eq("UserName", user.UserName) & builder.Eq("Password", user.Password);
            long count = Get_Collection("users").Find(filter).CountDocuments();
            if(count == 1)
            {
                return true;
            }

            return false;
        }

        private static bool UserNameExists(string name) {
            FilterDefinition<BsonDocument> filter = new BsonDocument("UserName", name);
            long count = Get_Collection("users").Find(filter).CountDocuments();
            if(count > 0)
            {
                return true;
            }
            return false;
        }


    }
}
