using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using MongoDB.Driver;  
using MongoDB.Bson; 

namespace testeAzureCosmos
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string connectionString =
  @"mongodb://cbc089ff-0ee0-4-231-b9ee:mvdryf61zp5Q5TmIyDHFcbG0l4nmdmir0REeapsEd7diRmXTK699jey7WPxt7QMJbfkaEVG5tFVsSqLe6xZA7A==@cbc089ff-0ee0-4-231-b9ee.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(connectionString)
            );
            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings);

            try{
                Console.WriteLine("Lista de databases: \n");
                var dbList = mongoClient.ListDatabases().ToList();
                dbList.ForEach(item =>
                {
                    Console.WriteLine(item);
                });

                Console.WriteLine("\n\n");

                Console.WriteLine("Lista de collections: \n");
                IMongoDatabase db = mongoClient.GetDatabase("01");
                var collectionList = db.ListCollections().ToList();
                collectionList.ForEach(item =>
                {
                    Console.WriteLine(item);
                });

                Console.WriteLine("\n\n");

                Console.WriteLine("Cretes:");

                //var personCollection = db.GetCollection<BsonDocument>("Collection1");
                var todoListCollection = db.GetCollection<BsonDocument>("ToDoList");

                //BsonElement person = new BsonElement("Nome", "Mitsuaki");
                //BsonDocument personDoc = new BsonDocument();
                //personDoc.Add(person);
                //personDoc.Add(new BsonElement("Idade", 23));
                //personDoc.Add(new BsonElement("Melhor caracterisca", "Sao tantas que nao cabe aqui"));

                //todoListCollection.InsertOne(personDoc);

                //Console.WriteLine("Cadastro inserido com sucesso!");

                Console.WriteLine("\n\n");

                Console.WriteLine("Resultado final:");

				Console.ForegroundColor = ConsoleColor.Green;
                var resultadoDoc = todoListCollection.Find(new BsonDocument()).ToList();
                resultadoDoc.ForEach(item => 
                {
                    Console.WriteLine(item);
                });


                Console.ForegroundColor = ConsoleColor.Red;
                var todoListCollectionClientes = db.GetCollection<Clientes>("ToDoList");

                var filter = new BsonDocument("Nome", "Mylena");

                var findEspecifico = todoListCollectionClientes.Find(filter).ToList();

                findEspecifico.ForEach(x =>
                {
                    Console.WriteLine(x.Nome);
                });



                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("Processo Finalizado!");
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }

        }
    }
}
