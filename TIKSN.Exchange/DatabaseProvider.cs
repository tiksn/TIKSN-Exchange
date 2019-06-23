using Microsoft.Extensions.Configuration;
using TIKSN.Data.LiteDB;
using TIKSN.FileSystem;

namespace TIKSN.Exchange
{
    public class DatabaseProvider : LiteDbDatabaseProvider
    {
        public DatabaseProvider(IConfigurationRoot configuration, IKnownFolders knownFolders) : base(configuration, "Main", knownFolders.LocalAppData)
        {
        }
    }
}