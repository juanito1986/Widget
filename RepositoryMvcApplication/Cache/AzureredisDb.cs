using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCache
{
    public static class AzureredisDb
    {
        public static IDatabase Cache()
        {
            var connectionString = string.Format("{0}:{1}", "127.0.0.1", 6379);

            IDatabase database = ConnectionMultiplexer.Connect(connectionString).GetDatabase();

            return database;
        }
    }
}
