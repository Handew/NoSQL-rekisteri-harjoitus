using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoSQLtestia.Models
{
    public class Jasenet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Osoite { get; set; }
        public string Postinumero { get; set; }
        public string Sahkoposti { get; set; }
        public string Puhelin { get; set; }
        public DateTime JasenyydenAlkuPvm { get; set; }
    }
}