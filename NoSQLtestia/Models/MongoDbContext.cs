using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace NoSQLtestia.Models
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _JasenetDb;
        public MongoDbContext()
        {
            var client = new MongoClient("mongodb+srv://Handew:KouluT35t1@cluster0.xs3ww.mongodb.net?retryWrites=true&w=majority");
            _JasenetDb = client.GetDatabase("JasenenrekisteriDB");
        }
        public IMongoCollection<Jasenet> Jasenet
        {
            get
            {
                return _JasenetDb.GetCollection<Jasenet>("Jasenet");
            }
        }
    }
}