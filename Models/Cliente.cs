using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace dotnetmongo
{
    public class Cliente
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        [BsonRequired()]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public void Salvar()
        {
          
          IMongoClient client = new MongoClient("mongodb://localhost");
          //mongodb://localhost:27017/dotnetMongoClientes
          
          IMongoDatabase database = client.GetDatabase("dotnetMongoClientes");            
          IMongoCollection<Cliente> clientesDB = database.GetCollection<Cliente>("clientes");

          clientesDB.InsertOne(this);
        }

        public IList<Cliente> Lista()
        {
          IMongoClient client = new MongoClient("mongodb://localhost");
          IMongoDatabase database = client.GetDatabase("dotnetMongoClientes");            
          IMongoCollection<Cliente> clientesDB = database.GetCollection<Cliente>("clientes");

          IMongoQueryable<Cliente> queryAbleClientes = clientesDB.AsQueryable()
                .OrderBy(x => x.Id)
                .Where(x => x.Nome.Contains("D"));

          IList<Cliente> items = queryAbleClientes.ToList();

          return items;
        }
    }
}
