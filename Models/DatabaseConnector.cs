using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedHookCraftWebsite.Models
{
    public class DatabaseConnector
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ProductCollectionName { get; set; }
    }
}
