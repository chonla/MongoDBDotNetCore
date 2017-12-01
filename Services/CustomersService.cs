using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

public class CustomerService
{
  private MongoClient client;
  private IMongoDatabase db;
  private IMongoCollection<Customer> col;

  public CustomerService()
  {
    this.client = new MongoClient("mongodb://localhost:27017");
    this.db = client.GetDatabase("data");
    this.col = this.db.GetCollection<Customer>("customers");
  }

  public async Task<IEnumerable<Customer>> All()
  {
    var list = await this.col.Find(new BsonDocument()).ToListAsync();
    return list;
  }

  public async Task<Customer> Get(string id)
  {
    var cust = await this.col.Find(x => x.Id == id).FirstAsync();
    return cust;
  }

  public async Task Add(Customer cust)
  {
    await this.col.InsertOneAsync(cust);
  }

  public async Task Update(string id, Customer cust)
  {
    await this.col.ReplaceOneAsync(x => x.Id == id, cust);
  }

  public async Task Remove(string id)
  {
    await this.col.DeleteOneAsync(x => x.Id == id);
  }
}