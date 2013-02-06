using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace IMDEV.OpenERP.Interfaces
{
    [XmlRpcUrl("")]
    public interface IDB : IXmlRpcProxy
    {
        [XmlRpcMethod("list")]
        string[] readDatabase();

        [XmlRpcMethod("list_lang")]
        Array listLanguage();

        [XmlRpcMethod("server_version")]
        string ServerVersion();

        [XmlRpcMethod("migrate_databases")]
        object migrateDatabase(string motDePasse, Array db);

        [XmlRpcMethod("create")]
        object createDatabase(string motDePasse, string dbName, bool demoData, object langReal, string userPass);
    }
}
