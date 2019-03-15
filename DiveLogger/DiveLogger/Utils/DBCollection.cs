using DiveLogger.ViewModels;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Newtonsoft.Json;
using DiveLogger.Models;

namespace DiveLogger.Utils
{
    public static class DBCollection
    {
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
            object count = Get_Collection("users").Find(filter).CountDocuments();
            if (count == null || (long) count != 1)
            {
                return false;
            }
            return true;
        }

        public static async System.Threading.Tasks.Task<ObservableCollection<PostViewModel>> GetPostsAsync()
        {
            var documents = await Get_Collection("posts").Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Exclude("_id")).ToListAsync();
            var obj = documents.ToJson();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<PostViewModel>>(obj);
        }

        public static void SendPost(PostViewModel post)
        {
            Get_Collection("posts").InsertOne(post.ToBsonDocument());
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

        public static UserModel GetUserDocFromDB(UserModel user)
        {
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = builder.Eq("UserName", user.UserName) & builder.Eq("Password", user.Password);
            var userDoc = Get_Collection("users").Find(filter).Project(Builders<BsonDocument>.Projection.Exclude("_id")).Single();
            var userJson = userDoc.ToJson();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(userJson);
        }

        public static void UpdateUser(UserModel user)
        {
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = builder.Eq("UserName", user.UserName) & builder.Eq("Password", user.Password);
            Get_Collection("users").FindOneAndUpdate(filter, user.ToBsonDocument());
        }

    }
}
