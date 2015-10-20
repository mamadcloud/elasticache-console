using Amazon.ElastiCacheCluster;
using Enyim.Caching;
using Enyim.Caching.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticacheSample
{
    class Program
    {
        private static MemcachedClient _instance;

        public Program()
        {
            _instance = new MemcachedClient(new ElastiCacheClusterConfig("xxx", 11211));
        }

        static void Main(string[] args)
        {
            if(_instance == null) _instance = new MemcachedClient(new ElastiCacheClusterConfig("xxx", 11211));
            if (_instance == null) { Console.Write("Instance cannot be connected"); return; }
            if (args.Length < 2) return;
            switch (args[0].ToLower())
            {
                case "get":
                    Console.Write(Get(args[1]));
                    break;
                case "store":
                    bool result = Store(args[1], args[2]);
                    Console.Write(result ? "Storing is success" : "Storing is failed");
                    break;
            }
            //Console.ReadLine();
            return;
        }

        public static bool Store(string key, string value)
        {
            return _instance.Store(StoreMode.Set, key, value);
        }

        public static string Get(string key)
        {
            return _instance.Get(key) as string;
        }
    }
}
