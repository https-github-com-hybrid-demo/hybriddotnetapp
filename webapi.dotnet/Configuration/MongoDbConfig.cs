using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.dotnet.Configuration
{
    public class MongoDbConfig
    {
        public string Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool IsManaged { get; set; }
        public string ConnectionString
        {
            get
            {
               if (IsManaged == true) {
                    return $@"mongodb+srv://{User}:{Password}@{Host}/TodoDB?retryWrites=true&w=majority";
                } 
                return $@"mongodb://{User}:{Password}@{Host}:{Port}";
                
            }
        }
    }
}
