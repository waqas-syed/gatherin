using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Common
{
    /// <summary>
    /// Contains constants that are used in multiple places
    /// </summary>
    public class Constants
    {
        public static readonly string MongoServer = ConfigurationManager.AppSettings.Get("MongoServer");
        public static readonly string MongoDatabase = ConfigurationManager.AppSettings.Get("MongoDatabase");
    }
}
