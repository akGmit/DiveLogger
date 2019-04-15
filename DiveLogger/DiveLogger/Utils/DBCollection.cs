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
    }
}
