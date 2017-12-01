using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Customer
{
  [BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; }
  public string name { get; set; }
  public DateTime dob { get; set; }
}