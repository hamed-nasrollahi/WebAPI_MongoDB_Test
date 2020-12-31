using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WebAPI_MongoDB_Test
{
    public class MongoCRUD
    {
        private IMongoDatabase _db;
        private IMongoClient _client;

        public MongoCRUD(string mongoURI, string mongoDatabase)
        {
            _client = new MongoClient(mongoURI);
            _db = _client.GetDatabase(mongoDatabase);

        }
        
        public void InsertRecord<T>(string tabel, T record)
        {
            var _collection = _db.GetCollection<T>(tabel);
            _collection.InsertOne(record);
        }

        public List<T> LoadAllRecords<T>(string table)
        {
            var _collection = _db.GetCollection<T>(table);
            return _collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordByID<T>(string table, ObjectId Id)
        {
            var _collection = _db.GetCollection<T>(table);
            //find by using filter insted of lambda exp
            var filter = Builders<T>.Filter.Eq("_id",Id);

            return _collection.Find(filter).First();
        }

        public ReplaceOneResult UpsertRecord<T>(string table, ObjectId Id, T record)
        {
            var _collection = _db.GetCollection<T>(table);

            //it will replace the record if exist or if not exist will create new one
            return _collection.ReplaceOne(
                new BsonDocument("_id",Id),
                record,
                new ReplaceOptions { IsUpsert = true});
        }

        public void DeleteRecord<T>(string table, ObjectId Id)
        {
            var _collection = _db.GetCollection<T>(table);
            //find by using filter insted of lambda exp
            var filter = Builders<T>.Filter.Eq("_id", Id);

            _collection.DeleteOne(filter);
        }
    }
}
