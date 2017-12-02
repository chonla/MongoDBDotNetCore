using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

public class CustomerLinQService
{
  private MongoClient client;
  private IMongoDatabase db;
  private IMongoCollection<Customer> col;

  public CustomerLinQService()
  {
    this.client = new MongoClient("mongodb://localhost:27017");
    this.db = client.GetDatabase("data");
    this.col = this.db.GetCollection<Customer>("customers");
  }

  public async Task<List<Customer>> All()
  {
    var custs = await (this.col.AsQueryable()
            .Select(c => c))
            .ToListAsync();
    return custs;
  }

  public async Task<Customer> Get(string id)
  {
    var cust = await (this.col.AsQueryable()
              .Where(c => c.Id == id)
              .Select(c => c))
            .FirstAsync();
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