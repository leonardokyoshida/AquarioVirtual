using AquarioVirtual.Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AquarioVirtual.Infra
{
    public class MongoHelper<T> : IDisposable where T : IModelBase
    {
        const string databaseName = "AquarioVirtual";
        //string connectionString = "mongodb://localhost:27017";
        string connectionString =
  @"mongodb://mongo-aquariovirtual:xXVX2LMW5X2ebhM4HVEjTdqAIXrXYKJExe6q6HKx2GpCAnluD3gR10wRkst1kf6hKakoLWNA6LpvQIVC097IWw==@mongo-aquariovirtual.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";

        private IMongoDatabase database;
        public IMongoCollection<T> collection;
        private IMongoClient client;



        public MongoHelper()
        {
            CreateMongoDataBase();
            CreateMongoCollection();
        }

        private void CreateMongoDataBase()
        {

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
            client = new MongoClient(settings);


            //client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
        }

        private void CreateMongoCollection()
        {
            collection = database.GetCollection<T>(typeof(T).Name);
        }

        public Task Add(T obj)
        {
            var result = collection.InsertOneAsync(obj);
            return result;
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            var result = collection.Find<T>(x => true).ToListAsync().Result;
            return result;
        }

        public T GetById(string id)
        {
            var result = collection.Find<T>(x => x.Id.Equals(id)).FirstOrDefault();
            return result;

        }

        public System.Collections.Generic.IEnumerable<T> GetFilter(string filter)
        {
            throw new NotImplementedException();
        }


        public System.Collections.Generic.IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            var result = collection.Find<T>(predicate).ToListAsync().Result;
            return result;
        }

        public void Remove(T obj)
        {
            collection.DeleteOneAsync(Builders<T>.Filter.Eq(x => x.Id, obj.Id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(client);
            GC.SuppressFinalize(database);
            client = null;
            database = null;


        }
    }
}
