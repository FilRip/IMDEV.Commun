using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace IMDEV.OpenERP.Interfaces
{
    [XmlRpcUrl("")]
    public interface Icommon : IXmlRpcProxy
    {
        [XmlRpcMethod("login")]
        int login(string bdd , string utilisateur , string motDePasse );

        [XmlRpcMethod("login_message")]
        string loginMessage();

        [XmlRpcMethod("about")]
        string getAbout();

        [XmlRpcMethod("timezone_get")]
        string getTimeZone(string dbName, int userId, string password);

        // INFO : Nouvelle fonction, sortie du code du client lourd
        [XmlRpcMethod("get_available_updates")]
        object getAvailableUpdates(string motDePasse, string contractId, string contractPassword);

        [XmlRpcMethod("get_migration_scripts")]
        object getMigrationScripts(string motDePasse, string contractId, string contractPassword);

        // INFO : Nouvelle methode sortie du code du serveur
        [XmlRpcMethod("set_loglevel")]
        object set_logLevel(string motdePasse);

        [XmlRpcMethod("get_os_time")]
        object get_osTime(string motdePasse);

        [XmlRpcMethod("get_sqlcount")]
        object get_sqlCount(string motdePasse);
    }
}
