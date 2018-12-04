namespace ForumSystem.Data.Configurations
{
    public static class ConnectionConfig
    {
        //private static string myServerName = ServerConfig.MyServerName;
        private const string AlternativeServerName = "(LocalDb)\\MSSQLLocalDB";

        public static string ConnectionString = $@"Server={AlternativeServerName};Database=ForumSystem;Trusted_Connection=True";
    }
}
