using System.Configuration;

namespace Gatherin.Common
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
