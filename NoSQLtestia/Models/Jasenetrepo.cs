using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NoSQLtestia.Models
{
    public class JasenetRepo : IJasenetRepo
    {
        MongoDbContext db = new MongoDbContext();
        public async Task Add(Jasenet jasenet)
        {
            try
            {
                await db.Jasenet.InsertOneAsync(jasenet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                FilterDefinition<Jasenet> data = Builders<Jasenet>.Filter.Eq("Id", id);
                await db.Jasenet.DeleteOneAsync(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Jasenet> GetJasenet(string id)
        {
            try
            {
                FilterDefinition<Jasenet> filter = Builders<Jasenet>.Filter.Eq("Id", id);
                return await db.Jasenet.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Jasenet>> GetJasenet()
        {
            try
            {
                return await db.Jasenet.Find(_ => true).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(Jasenet jasenet)
        {
            try
            {
                await db.Jasenet.ReplaceOneAsync(filter: g => g.Id == jasenet.Id, replacement: jasenet);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}