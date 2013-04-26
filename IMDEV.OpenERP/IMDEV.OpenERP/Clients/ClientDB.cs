using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Collections;

namespace IMDEV.OpenERP.Clients
{
    
    /// <summary>
    /// Classe proxi de base de connexion à un serveur XMLRPC OpenERP
    /// Encapsule le service "db" du service XMLRPC d'un serveur OpenERP
    /// </summary>
    /// <remarks></remarks>
    public class clientDB
    {
        protected IMDEV.Threading.ThreadStack.threadStack _work = new IMDEV.Threading.ThreadStack.threadStack();
        protected models.@base.connectionProperties _config;
        
        protected enum SERVICE_XMLRPC
        {
            db,
            common,
            @object,
            report,
        }
        
        public clientDB()
        {
            _config = new models.@base.connectionProperties();
        }
        
        public clientDB(string host, int port)
        {
            _config = new models.@base.connectionProperties();
            _config.host = host;
            _config.port = port;
        }
        
        public clientDB(string host)
        {
            _config = new models.@base.connectionProperties();
            _config.host = host;
            _config.port = 8069;
        }
        
        public bool checkIfBusy()
        {
            if (isBusy)
            {
                if (_config.busyThrowAnError)
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.ALREADY_BUSY);
                else
                    return true;
            }
            return false;
        }
        
        /// <summary>
        /// Permet l'interrogation direct du système de spool des tâches asynchrones
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public IMDEV.Threading.ThreadStack.threadStack worker
        {
            get { return _work; }
        }

        public void setHost(string host)
        {
            _config.host = host;
        }
        public void setHost(string host, int port)
        {
            _config.host = host;
            _config.port = port;
        }

        protected string url(SERVICE_XMLRPC extension)
        {
            if (_config.host == "") {
                throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.NO_HOST);
            }
            return ("http://" + _config.host + ":" + _config.port.ToString() + "/xmlrpc/" + extension.ToString());
        }
        
        /// <summary>
        /// Le système est-il déjà occupé par une requête en attente de réponse du serveur ?
        /// </summary>
        /// <value></value>
        /// <returns>True = occupé, Sinon False</returns>
        /// <remarks></remarks>
        public bool isBusy
        {
            get { return ( (_work == null) ? false : _work.IsBusy ); }
        }
        
        /// <summary>
        /// Retourne la liste des bases de données disponible sur ce serveur
        /// </summary>
        /// <returns>Liste de chaine</returns>
        /// <remarks></remarks>
        public List<string> listDatabase()
        {
            if (checkIfBusy()) 
                return null;

            return listDatabaseData();
        }
        
        private List<string> listDatabaseData()
        {
            Interfaces.IDB conn;
            string[] liste;
            List<string> retour=null;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IDB>();
                conn.Url = url(SERVICE_XMLRPC.db);
                liste = conn.readDatabase();
                if (liste != null)
                {
                    retour = new List<string>();
                    foreach (string ligne in liste)
                        retour.Add(ligne);
                }
            }
            catch (Exception ex)
            {
                if (_config.reportXmlRpcError)
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return retour;
        }
        
        /// <summary>
        /// Retourne la liste des bases de données disponible sur ce serveur en asynchrone
        /// </summary>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void listDatabaseAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.listDatabaseAsyncCall), callBack, null, prioritaire);
        }
        public void listDatabaseAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            listDatabaseAsync(callBack,false);
        }
        
        private void listDatabaseAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = listDatabaseData();
        }
        
        /// <summary>
        /// Liste les langues possibles de ce serveur
        /// </summary>
        /// <returns>Une liste d'objet aLanguage, contenant juste un code langue et le libellé, de chaque langue</returns>
        /// <remarks></remarks>
        public List<OpenERP.models.@base.aLanguage> listLanguage()
        {
            if (checkIfBusy())
                return null;

            return listLanguageData();
        }
        
        /// <summary>
        /// Liste les langues possibles de ce serveur en asynchrone
        /// </summary>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void listLanguageAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.listLanguageAsyncCall), callBack, null, prioritaire);
        }
        public void listLanguageAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            listLanguageAsync(callBack,false);
        }
        
        private void listLanguageAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = listLanguageData();
        }
        
        private List<models.@base.aLanguage> listLanguageData() {
            Interfaces.IDB conn;
            Array liste;
            List<models.@base.aLanguage> retour=null;

            models.@base.aLanguage lang;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IDB>();
                conn.Url = url(SERVICE_XMLRPC.db);
                liste = conn.listLanguage();
                if (liste!=null)
                {
                    retour = new List<models.@base.aLanguage>();
                    for (int i = 0; (i <= (liste.GetLength(0) - 1)); i++)
                    {
                        lang = new models.@base.aLanguage();
                        lang.id = (string)((System.Array)(liste.GetValue(i))).GetValue(0);
                        lang.name = (string)((System.Array)(liste.GetValue(i))).GetValue(1);
                        retour.Add(lang);
                    }
                }
            }
            catch (Exception ex)
            {
                if (_config.reportXmlRpcError)
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return retour;
        }
        
        private string serverVersionData() {
            Interfaces.IDB conn;
            string retour = "";
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IDB>();
                conn.Url = url(SERVICE_XMLRPC.db);
                retour = conn.ServerVersion();
            }
            catch (Exception ex)
            {
                if (_config.reportXmlRpcError)
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return retour;
        }
        
        /// <summary>
        /// Retourne la version du serveur, en texte
        /// </summary>
        /// <returns>Texte</returns>
        /// <remarks></remarks>
        public string serverVersion()
        {
            if (checkIfBusy())
                return null;

            return serverVersionData();
        }
        
        /// <summary>
        /// Retourne la version du serveur, en texte, en asynchrone
        /// </summary>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void serverVersionAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.versionServerAsyncCall), callBack, null, prioritaire);
        }
        public void serverVersionAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack)
        {
            serverVersionAsync(callBack,false);
        }
        
        private void versionServerAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = serverVersionData();
        }
        
        /// <summary>
        /// Permet de faire migrer les bases de données vers le nouveau système actuel (version du serveur OpenERP)
        /// </summary>
        /// <param name="db">Liste des bases de données à migrer</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool migrateDatabase(List<string> db)
        {
            if (checkIfBusy())
                return false;

            return migrateDatabaseData(db);
        }
        
        private bool migrateDatabaseData(List<string> db)
        {
            Interfaces.IDB conn;
            object retour;
            try
            {
                conn = XmlRpcProxyGen.Create<Interfaces.IDB>();
                conn.Url = url(SERVICE_XMLRPC.db);
                retour = conn.migrateDatabase(_config.password, db.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                if (_config.reportXmlRpcError)
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return false;
        }
        
        /// <summary>
        /// Permet de faire migrer les bases de données vers le nouveau système actuel (version du serveur OpenERP) en asynchrone
        /// </summary>
        /// <param name="db">Liste des bases de données à migrer</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void migrateDatabaseAsync(List<string> db, System.ComponentModel.RunWorkerCompletedEventHandler callBack, bool prioritaire)
        {
            Hashtable param = new Hashtable();
            param.Add("db", db);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.migrateDatabaseAsyncCall), callBack, param, prioritaire);
        }
        
        private void migrateDatabaseAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = migrateDatabaseData((List<string>)(((Hashtable)(e.Argument))["db"]));
        }
        
        /// <summary>
        /// Creer une nouvelle base de données
        /// </summary>
        /// <param name="dbName">Nom de la nouvelle base de données</param>
        /// <param name="adminPassword">Mot de passe administrateur du serveur OpenERP</param>
        /// <param name="userPassword">Mot de passe administrateur pour cette nouvelle base de données</param>
        /// <param name="withDemoData">Charge-t-on les données de démonstration dans cette base ?</param>
        /// <param name="language">Langue par défaut de la base</param>
        /// <returns>Un entier (numéro identifiant de la base ?)</returns>
        /// <remarks></remarks>
        public int createDatabase(string dbName, string adminPassword)
        {
            return createDatabase(dbName, adminPassword, "", false, "");
        }
        public int createDatabase(string dbName, string adminPassword, string userPassword)
        {
            return createDatabase(dbName, adminPassword, userPassword, false, "");
        }
        public int createDatabase(string dbName, string adminPassword, string userPassword, bool withDemoData)
        {
            return createDatabase(dbName, adminPassword, userPassword, withDemoData, "");
        }
        public int createDatabase(string dbName, string adminPassword, string userPassword, bool withDemoData, string language)
        {
            if (checkIfBusy())
                return -1;
            return createDatabaseData(dbName, adminPassword, userPassword, withDemoData, language);
        }
        
        private int createDatabaseData(string dbName, string adminPassword, string userPassword, bool withDemoData, string language)
        {
            Interfaces.IDB conn;
            object retour;
            string lang = language;
            int id;
            try
            {
                if (userPassword == "")
                    userPassword = adminPassword;
                if (lang == "")
                    lang = _config.defaultLanguage;

                conn = XmlRpcProxyGen.Create<Interfaces.IDB>();
                conn.Url = url(SERVICE_XMLRPC.db);
                retour = conn.createDatabase(adminPassword, dbName, withDemoData, lang, userPassword);
                if (int.TryParse((string)retour, out id))
                    return id;
            }
            catch (Exception ex)
            {
                if (_config.reportXmlRpcError)
                    throw new Systeme.exceptionOpenERP(Systeme.exceptionOpenERP.ERRORS.LIB_XMLRPC, ex.Message);
            }
            finally
            {
                conn = null;
            }
            return -1;
        }
        
        /// <summary>
        /// Creer une nouvelle base de données en asynchrone
        /// </summary>
        /// <param name="dbName">Nom de la nouvelle base de données</param>
        /// <param name="adminPassword">Mot de passe administrateur du serveur OpenERP</param>
        /// <param name="userPassword">Mot de passe administrateur pour cette nouvelle base de données</param>
        /// <param name="withDemoData">Charge-t-on les données de démonstration dans cette base ?</param>
        /// <param name="language">Langue par défaut de la base</param>
        /// <param name="callBack">Fonction appelée quand c'est terminé</param>
        /// <param name="prioritaire">Passe cette requete en priorité par rapport aux autres en attentes</param>
        /// <remarks></remarks>
        public void createDatabaseAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string dbName, string adminPassword)
        {
            createDatabaseAsync(callBack, dbName, adminPassword, "", false, "", false);
        }
        public void createDatabaseAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string dbName, string adminPassword, string userPassword)
        {
            createDatabaseAsync(callBack, dbName, adminPassword, userPassword, false, "", false);
        }
        public void createDatabaseAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string dbName, string adminPassword, string userPassword, bool withDemoData)
        {
            createDatabaseAsync(callBack, dbName, adminPassword, userPassword, withDemoData, "", false);
        }
        public void createDatabaseAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string dbName, string adminPassword, string userPassword, bool withDemoData, string language)
        {
            createDatabaseAsync(callBack, dbName, adminPassword, userPassword, withDemoData, language, false);
        }
        public void createDatabaseAsync(System.ComponentModel.RunWorkerCompletedEventHandler callBack, string dbName, string adminPassword, string userPassword, bool withDemoData, string language, bool prioritaire)
        {
            Hashtable param = new Hashtable();

            if (userPassword == "")
                userPassword = adminPassword;

            param.Add("dbName", dbName);
            param.Add("adminPassword", adminPassword);
            param.Add("userPassword", userPassword);
            param.Add("withDemoData", withDemoData);
            param.Add("language", language);
            _work.addTask(new System.ComponentModel.DoWorkEventHandler(this.createDatabaseAsyncCall), callBack, param, prioritaire);
        }
        
        private void createDatabaseAsyncCall(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            e.Result = createDatabaseData((string)((Hashtable)(e.Argument))["dbName"], (string)((Hashtable)(e.Argument))["adminPassword"], (string)((Hashtable)(e.Argument))["userPassword"], (bool)((Hashtable)(e.Argument))["withDemoData"], (string)((Hashtable)(e.Argument))["language"]);
        }
    }
}
