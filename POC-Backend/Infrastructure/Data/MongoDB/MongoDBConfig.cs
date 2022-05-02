namespace POC_Backend.Infrastructure.Data.MongoDB
{
    public class MongoDBConfig
    {
        public string Database { get; set; } = string.Empty;
        public string Cluster { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConnectionString
        {
            get
            {
                return $@"mongodb+srv://{User}:{Password}@{Cluster}/{Database}?retryWrites=true&w=majority";
            }
        }
    }
}
