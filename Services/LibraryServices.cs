using libraryAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace libraryAPI.Services;


public class libraryService {
    private IMongoCollection<Book> _BookCollection;
    public libraryService(IOptions<MongoDBSetting> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _BookCollection = database.GetCollection<Book>(mongoDBSettings.Value.CollectionName);
    }
    public async Task CreateAsync(Book book) { 
        await _BookCollection.InsertOneAsync(book);
        return;
    }
    public async Task<List<Book>> GetAsync() {
        return await _BookCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task AddBook(string _id, int itemsAvailable) {
        FilterDefinition<Book> filter = Builders<Book>.Filter.Eq("Id", _id);
        UpdateDefinition<Book> update = Builders<Book>.Update.Set<int>("itemsAvailable", itemsAvailable);
        await _BookCollection.UpdateOneAsync(filter, update);
        return;
    }
    public async Task DeleteAsync(string id) { 
        FilterDefinition<Book> filter = Builders<Book>.Filter.Eq("Id", id);
        await _BookCollection.DeleteOneAsync(filter);
        return;
    }

}