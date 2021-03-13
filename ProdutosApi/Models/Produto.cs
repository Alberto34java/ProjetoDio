using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProdutosApi.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement]
        public string Nome { get; set; }
        [BsonElement]
        public double Preco { get; set; }
        [BsonElement]
        public string Descricao { get; set; }
        
    }
}