using MongoDB.Driver;
using POC_Backend.Application.Entities;
using POC_Backend.Infrastructure.Data.MongoDB;

namespace POC_Backend.Infrastructure.Data.Context
{
    public class DBContext : IDisposable
    {
        private readonly IMongoDatabase _db;
        private readonly IClientSessionHandle _session;
        private bool _disposed;

        public DBContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
            this._session = client.StartSession();
            this._session.StartTransaction();
        }

        //public IMongoCollection<Roulette> Roulettes => _db.GetCollection<Roulette>("Roulettes");
        //public IMongoCollection<Game> Games => _db.GetCollection<Game>("Games");
        //public IMongoCollection<Player> Players => _db.GetCollection<Player>("Players");

        public IMongoCollection<Answer> Answers => _db.GetCollection<Answer>("Answers");
        public IMongoCollection<Group> Groups => _db.GetCollection<Group>("Groups");
        public IMongoCollection<Post> Posts => _db.GetCollection<Post>("Posts");

        internal IClientSessionHandle Session => _session;

        public async Task SaveChangesAsync()
        {
            await this.Session.CommitTransactionAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    this.Session.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
