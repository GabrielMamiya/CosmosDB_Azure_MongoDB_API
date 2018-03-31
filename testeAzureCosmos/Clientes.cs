using System;
using MongoDB.Driver;  
using MongoDB.Bson; 

namespace testeAzureCosmos
{
    public class Clientes
    {
        public MongoDB.Bson.ObjectId Id { get; set; }
        public string Nome { get; set; }

        public Clientes(MongoDB.Bson.ObjectId id, string Nome)
        {
            this.Id = id;
            this.Nome = Nome;
        }
    }
}
