using System;
using AquarioVirtual.Domain.Interfaces;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AquarioVirtual.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : IModelBase
    {
        public T Add(T obj)
        {
            using (var database = new MongoHelper<T>())
            {
                var list = database.GetById(obj.Id);
                if (list == null)
                {
                    obj.Id = ObjectId.GenerateNewId().ToString();
                    database.Add(obj);
                }
                else
                {
                    var filter = Builders<T>.Filter.Eq(s => s.Id, list.Id);
                    var result = database.collection.ReplaceOneAsync(filter, obj);
                }
                return obj;
            }
        }

        public void Dispose()
        {

        }

        public IEnumerable<T> GetAll()
        {
            using (var database = new MongoHelper<T>())
            {
                return database.GetAll();
            }
        }

        public T GetById(string id)
        {
            using (var database = new MongoHelper<T>())
            {
                return database.GetById(id);
            }
        }

        public IEnumerable<T> GetFilter(string filter)
        {
            var result = new List<T>();
            return result;

        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            using (var database = new MongoHelper<T>())
            {
                return database.GetWhere(predicate);
            }
        }

        public void Remove(T obj)
        {
            using (var database = new MongoHelper<T>())
            {
                database.Remove(obj);
            }
        }

    }
}
