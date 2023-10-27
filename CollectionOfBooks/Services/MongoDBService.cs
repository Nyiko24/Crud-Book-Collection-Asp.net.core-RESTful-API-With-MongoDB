using CollectionOfBooks.Models;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;

namespace CollectionOfBooks.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<BookCollection> _bookcollection;

        public MongoDBService(IOptions<MongoDBSettings> mongodbsettings) {
            MongoClient client = new MongoClient(mongodbsettings.Value.ConnectionSTRING);
            IMongoDatabase database = client.GetDatabase(mongodbsettings.Value.DatabaseName);
            _bookcollection = database.GetCollection<BookCollection>(mongodbsettings.Value.CollectionName);

                
        }
        
        public async Task CreateAsync(BookCollection bookcollection)
        {
            await _bookcollection.InsertOneAsync(bookcollection);
            return;

        }

        public async Task<List<BookCollection>> GetAllAsync()
        {
            var cursor = await _bookcollection.FindAsync(new BsonDocument());
            return await cursor.ToListAsync();
        }


        public async Task<List<BookCollection>> GetBooksByTypeAsync(string ISBN)
        {
            var filter = Builders<BookCollection>.Filter.Eq("ISBN", ISBN);
            var books = await _bookcollection.Find(filter).ToListAsync();
            return books;
        }


         public async Task<bool> UpdateBookByISBNAsync(string ISBN, BookCollection updatedBook)
        {
            var filter = Builders<BookCollection>.Filter.Eq("ISBN", ISBN);
            var update = Builders<BookCollection>.Update
                .Set("Title", updatedBook.Title) // Update other fields as needed
                .Set("Author", updatedBook.Author)
                .Set("Genre", updatedBook.Genre)
                .Set("PublicationYear", updatedBook.PublicationYear);


            var result = await _bookcollection.UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }


        public async Task<bool> DeleteBookByISBNAsync(string ISBN)
        {
            var filter = Builders<BookCollection>.Filter.Eq("ISBN", ISBN);
            var result = await _bookcollection.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }



    }
}
